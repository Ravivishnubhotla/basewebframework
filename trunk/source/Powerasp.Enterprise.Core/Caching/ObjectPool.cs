using System;
using System.Collections;
using System.Threading;
using Powerasp.Enterprise.Core.Caching;
using Powerasp.Enterprise.Core.Events;
using Powerasp.Enterprise.Core.Threading;

namespace Powerasp.Enterprise.Core.Caching
{
    public abstract class ObjectPool : IObjectPool
    {
        private TimeoutChecker _checker;
        private bool _forcefreeing = false;
        protected const int DefaultCapacity = 0x10;
        protected const int DefaultForceCount = 0x10;
        protected const int DefaultMaxPoolSize = 0x1000;
        protected const int DefaultMinPoolSize = 0x40;
        protected const int InvaildIndex = -1;
        private IList parrays;
        protected Queue pemptyIndexs = new Queue();
        protected IDictionary pindexer = new Hashtable();

        protected ObjectPool()
        {
            this.InitializePool();
            this._checker = new TimeoutChecker();
        }

        private int AllocIdentifier()
        {
            if (this.pemptyIndexs.Count == 0)
            {
                this.ExtendCapacity();
            }
            lock (this.pemptyIndexs.SyncRoot)
            {
                if (this.pemptyIndexs.Count == 0)
                {
                    this.ExtendCapacity();
                }
                return (int) this.pemptyIndexs.Dequeue();
            }
        }

        public bool Contains(object key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            return this.pindexer.Contains(key);
        }

        private void ExtendCapacity()
        {
            if (this.CurrentSize >= this.MaxPoolSize)
            {
                if (this.ForceRelease)
                {
                    this.ForceFree();
                }
                if (this.pemptyIndexs.Count == 0)
                {
                    throw new PoolOverflowException("Pool is full.");
                }
            }
            else
            {
                int currentSize = this.CurrentSize;
                PoolItem[] itemArray = new PoolItem[this.Capacity];
                for (int i = 0; i < itemArray.Length; i++)
                {
                    this.pemptyIndexs.Enqueue(currentSize + i);
                }
                this.parrays[this.ArraySize] = itemArray;
            }
        }

        ~ObjectPool()
        {
            if (this.parrays != null)
            {
                this.parrays.Clear();
                this.parrays = null;
            }
            for (int i = 0; i < 10; i++)
            {
                GC.Collect();
            }
        }

        public void ForceFree()
        {
            if (!this._forcefreeing)
            {
                try
                {
                    lock (this)
                    {
                        if (this._forcefreeing)
                        {
                            return;
                        }
                        this._forcefreeing = true;
                    }
                    IList freedIndexs = this.GetFreedIndexs(this.ForceCount);
                    this.Free(freedIndexs);
                }
                finally
                {
                    this._forcefreeing = false;
                }
            }
        }

        private void Free(IList indexs)
        {
            if (indexs == null)
            {
                throw new ArgumentNullException("indexs");
            }
            if (indexs.Count != 0)
            {
                for (int i = 0; i < indexs.Count; i++)
                {
                    int state = (int) indexs[i];
                    if (state != -1)
                    {
                        WorkThread.QueueItem(new WaitCallback(this.FreeItem), state);
                    }
                }
            }
        }

        private void FreeItem(object state)
        {
            this.RemoveAt((int) state);
        }

        protected virtual IList GetFreedIndexs(int number)
        {
            int num2 = 0;
            IList list2 = new int[this.pindexer.Count];
            lock (this.pindexer.SyncRoot)
            {
                foreach (object obj2 in this.pindexer.Values)
                {
                    list2[num2++] = (int) obj2;
                }
            }
            if (number >= this.pindexer.Count)
            {
                return list2;
            }
            int index = -1;
            IList list = new ArrayList(number);
            IList list3 = new ArrayList(list2.Count);
            DateTime freeTime = this.GetFreeTime();
            for (int i = 0; i < list2.Count; i++)
            {
                PoolItem item;
                index = (int) list2[i];
                try
                {
                    item = this.GetItem(index);
                }
                catch (NullReferenceException)
                {
                    continue;
                }
                if (item.TimeLastAccessed <= freeTime)
                {
                    list.Add(index);
                    if (list.Count < number)
                    {
                        continue;
                    }
                    break;
                }
                list3.Add(index);
            }
            if (list.Count < number)
            {
                for (int j = 0; j < list3.Count; j++)
                {
                    if (list.Count >= number)
                    {
                        return list;
                    }
                    list.Add(list3);
                }
            }
            return list;
        }

        protected virtual DateTime GetFreeTime()
        {
            DateTime time2;
            DateTime time4;
            int index = -1;
            DateTime timeLastAccessed = time2 = DateTime.MaxValue;
            DateTime time3 = time4 = DateTime.MinValue;
            IList list = new ArrayList(this.pindexer.Count);
            lock (this.pindexer.SyncRoot)
            {
                foreach (object obj2 in this.pindexer.Values)
                {
                    list.Add(obj2);
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                index = (int) list[i];
                try
                {
                    PoolItem item = this.GetItem(index);
                    if (item.TimeLastAccessed < timeLastAccessed)
                    {
                        timeLastAccessed = item.TimeLastAccessed;
                    }
                    else if (item.TimeLastAccessed < time2)
                    {
                        time2 = item.TimeLastAccessed;
                    }
                    if (item.TimeLastAccessed > time3)
                    {
                        time3 = item.TimeLastAccessed;
                    }
                    else if (item.TimeLastAccessed > time4)
                    {
                        time4 = item.TimeLastAccessed;
                    }
                }
                catch (NullReferenceException)
                {
                }
            }
            return new DateTime(((timeLastAccessed.Ticks + time2.Ticks) + time3.Ticks) + time4.Ticks);
        }

        protected virtual PoolItem GetItem(int index)
        {
            int num;
            int num2;
            if ((index < 0) || (index > this.CurrentSize))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            PoolItem item = null;
            this.ParseIndex(index, out num2, out num);
            lock (this.parrays.SyncRoot)
            {
                IList list = (object[]) this.parrays[num2];
                if (list != null)
                {
                    lock (list.SyncRoot)
                    {
                        item = list[num] as PoolItem;
                    }
                }
            }
            if (item == null)
            {
                throw new NullReferenceException("cann't found object by specialed index.");
            }
            return item;
        }

        protected object GetObject(int index)
        {
            PoolItem item = null;
            object obj2;
            try
            {
                item = this.GetItem(index);
                item.Accesse();
                obj2 = this.Unwrap(item);
            }
            catch (NullReferenceException)
            {
                throw new IndexOutOfRangeException("cann't found item by special index.");
            }
            return obj2;
        }

        public virtual object GetObject(object key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            int index = this.IndexOf(key);
            if (index == -1)
            {
                throw new ArgumentException("Invaild key.");
            }
            return this.GetObject(index);
        }

        protected virtual int IndexOf(object key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (!this.pindexer.Contains(key))
            {
                return -1;
            }
            lock (this.pindexer.SyncRoot)
            {
                if (!this.pindexer.Contains(key))
                {
                    return -1;
                }
                return (int) this.pindexer[key];
            }
        }

        protected virtual void InitializePool()
        {
            int num = this.MaxPoolSize / this.Capacity;
            this.parrays = new object[num];
            while (this.pemptyIndexs.Count < this.MinPoolSize)
            {
                this.ExtendCapacity();
            }
        }

        private void Item_OnAfterReleased(object sender, EventArgs e)
        {
        }

        private void Item_OnBeforeReleased(object sender, CancelEventArgs e)
        {
            PoolItem item = sender as PoolItem;
            if (item == null)
            {
                e.Cancel = false;
            }
            else
            {
                int index = item.Index;
                this.SetItem(index, null);
                if (this.pindexer.Contains(item.Key))
                {
                    lock (this.pindexer.SyncRoot)
                    {
                        if (this.pindexer.Contains(item.Key))
                        {
                            this.pindexer.Remove(item.Key);
                        }
                    }
                }
                this.pemptyIndexs.Enqueue(index);
            }
        }

        protected void ParseIndex(int index, out int arraysIndex, out int itemIndex)
        {
            if ((index < 0) || (index >= (this.parrays.Count * this.Capacity)))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            arraysIndex = 0;
            itemIndex = index;
            if (index >= this.Capacity)
            {
                arraysIndex = Math.DivRem(index, this.Capacity, out itemIndex);
            }
        }

        protected virtual void Remove(object key)
        {
            int index = this.IndexOf(key);
            if (index == -1)
            {
                throw new ArgumentException("invaild key.");
            }
            this.RemoveAt(index);
        }

        protected virtual void RemoveAt(int index)
        {
            if ((index < 0) || (index > this.MaxPoolSize))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            try
            {
                this.GetItem(index).Release();
            }
            catch (NullReferenceException)
            {
            }
        }

        protected virtual void SetItem(int index, PoolItem item)
        {
            int num;
            int num2;
            this.ParseIndex(index, out num2, out num);
            lock (this.parrays.SyncRoot)
            {
                IList list = (object[]) this.parrays[num2];
                if (list == null)
                {
                    list = new PoolItem[this.Capacity];
                }
                lock (list.SyncRoot)
                {
                    list[num] = item;
                }
            }
        }

        public void SetObject(object key, object obj)
        {
            int index = -1;
            if (this.pindexer.Contains(key))
            {
                lock (this.pindexer.SyncRoot)
                {
                    if (this.pindexer.Contains(key))
                    {
                        index = (int) this.pindexer[key];
                    }
                }
            }
            try
            {
                if (index == -1)
                {
                    throw new NullReferenceException("invaild index");
                }
                this.GetItem(index).Value = obj;
            }
            catch (NullReferenceException)
            {
            }
            return;
            //PoolItem item = this.Wrap(key, obj);
            //this.SetItem(item.Index, item);
        }

        private object Unwrap(PoolItem item)
        {
            return item.Value;
        }

        private PoolItem Wrap(object key, object obj)
        {
            PoolItem item;
            int index = this.AllocIdentifier();
            try
            {
                item = new PoolItem(index, key, obj, this.SlidingExpiration);
            }
            catch (Exception exception)
            {
                this.pemptyIndexs.Enqueue(index);
                throw exception;
            }
            lock (this.pindexer.SyncRoot)
            {
                this.pindexer[key] = index;
            }
            item.BeforeReleased += new CancelEventHandler(this.Item_OnBeforeReleased);
            item.AfterReleased += new EventHandler(this.Item_OnAfterReleased);
            this._checker.Add(item);
            return item;
        }

        protected virtual int ArraySize
        {
            get
            {
                int num = 0;
                num = 0;
                while (num < this.parrays.Count)
                {
                    if (this.parrays[num] == null)
                    {
                        return num;
                    }
                    num++;
                }
                return num;
            }
        }

        protected virtual int Capacity
        {
            get
            {
                return 0x10;
            }
        }

        protected virtual int CurrentSize
        {
            get
            {
                return (this.ArraySize * this.Capacity);
            }
        }

        protected virtual int ForceCount
        {
            get
            {
                return 0x10;
            }
        }

        public virtual bool ForceRelease
        {
            get
            {
                return true;
            }
        }

        public virtual int MaxPoolSize
        {
            get
            {
                return 0x1000;
            }
        }

        public virtual int MinPoolSize
        {
            get
            {
                return 0x40;
            }
        }

        protected virtual TimeSpan SlidingExpiration
        {
            get
            {
                return PoolItem.DefaultSlidingExpiration;
            }
        }

        public class PoolItem : IReleasable
        {
            private int _index;
            private object _key;
            private DateTime _lastAccessed;
            private TimeSpan _timeout;
            private object _value;
            internal static readonly TimeSpan DefaultSlidingExpiration = new TimeSpan(0, 0, 30, 0, 0);

            public event EventHandler Accessed;

            public event EventHandler AfterReleased;

            public event CancelEventHandler BeforeReleased;

            internal PoolItem(int index, object key, object value, TimeSpan timeout)
            {
                if (key == null)
                {
                    throw new ArgumentNullException("key");
                }
                this._index = index;
                this._key = key;
                this._value = value;
                this._timeout = timeout;
                this._lastAccessed = DateTime.UtcNow;
            }

            public void Accesse()
            {
                this._lastAccessed = DateTime.UtcNow;
                if (this.Accessed != null)
                {
                    this.Accessed(this, EventArgs.Empty);
                }
            }

            public void Release()
            {
                CancelEventArgs e = new CancelEventArgs(false);
                if (this.BeforeReleased != null)
                {
                    this.BeforeReleased(this, e);
                }
                if (!e.Cancel)
                {
                    if (this._value is IDisposable)
                    {
                        ((IDisposable) this._value).Dispose();
                    }
                    this._value = null;
                    if (this.AfterReleased != null)
                    {
                        this.AfterReleased(this, EventArgs.Empty);
                    }
                }
            }

            public int Index
            {
                get
                {
                    return this._index;
                }
            }

            public bool IsExpired
            {
                get
                {
                    DateTime utcNow = DateTime.UtcNow;
                    return (this._lastAccessed.Add(this._timeout) < utcNow);
                }
            }

            public object Key
            {
                get
                {
                    return this._key;
                }
            }

            public DateTime TimeLastAccessed
            {
                get
                {
                    return this._lastAccessed.ToLocalTime();
                }
                set
                {
                    this._lastAccessed = value.ToUniversalTime();
                }
            }

            public object Value
            {
                get
                {
                    this.Accesse();
                    return this._value;
                }
                set
                {
                    this._value = value;
                    this.Accesse();
                }
            }
        }
    }
}