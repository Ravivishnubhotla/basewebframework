using System;
using System.Collections;
using Powerasp.Enterprise.Core.Caching;
using Powerasp.Enterprise.Core.Events;
using Powerasp.Enterprise.Core.Threading;

namespace Powerasp.Enterprise.Core.Caching
{
    public class ObjectCache : IObjectCache
    {
        private TimeoutChecker _checker;
        private SortedList _items;
        public static readonly ObjectCache Default = new ObjectCache();
        protected const int DefaultMaxCount = 0x10013;
        protected const int DefaultPeriod = 5;

        public event EventHandler ItemChanged;

        public event EventHandler ItemReleased;

        public ObjectCache() : this(5)
        {
        }

        public ObjectCache(int period)
        {
            this._items = SortedList.Synchronized(new SortedList());
            this._checker = new TimeoutChecker(period);
        }

        private void Add(CacheItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (!item.IsExpired && !this._items.ContainsKey(item.Key))
            {
                lock (this._items.SyncRoot)
                {
                    if (!this._items.ContainsKey(item.Key))
                    {
                        if (this._items.Count >= this.MaxCount)
                        {
                            this._items.RemoveAt(0);
                        }
                        item.Releasing += new CancelEventHandler(this.Item_OnReleasing);
                        item.Released += new EventHandler(this.Item_OnReleased);
                        item.Changed += new EventHandler(this.Item_OnChanged);
                        this._items.Add(item.Key, item);
                        this._checker.Add(item);
                    }
                }
            }
        }

        public void Add(object key, object value)
        {
            this.Add(key, value, DateTime.MaxValue);
        }

        public void Add(object key, object value, IScheduleExpression expression)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (value == null)
            {
                throw new ArgumentNullException("@value");
            }
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            CacheItem item = this.Wrap(key, value);
            this.Add(item);
            Schedule.AddSchedule(new ScheduleCallBack(item.Release), expression);
        }

        public void Add(object key, object value, DateTime absoluteExpiration)
        {
            this.Add(key, value, absoluteExpiration, null);
        }

        public void Add(object key, object value, int seconds)
        {
            this.Add(key, value, new TimeSpan(0, 0, seconds));
        }

        public void Add(object key, object value, TimeSpan slidingExpiration)
        {
            this.Add(key, value, DateTime.Now.Add(slidingExpiration));
        }

        public void Add(object key, object value, DateTime absoluteExpiration, ICacheDependency dependency)
        {
            this.Add(key, value, absoluteExpiration, dependency, null);
        }

        public void Add(object key, object value, DateTime absoluteExpiration, ICacheDependency dependency, ObjectCacheItemRemovedCallback callback)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            CacheItem item = this.Wrap(key, value);
            if (absoluteExpiration != DateTime.MaxValue)
            {
                item.AbsoluteExpiration = absoluteExpiration.AddSeconds(-1.0);
            }
            if (dependency != null)
            {
                item.Dependency = dependency;
            }
            if (callback != null)
            {
                item.Callback = callback;
            }
            this.Add(item);
        }

        public void Clear()
        {
            if (this._items != null)
            {
                this._items.Clear();
            }
        }

        public bool Contains(object key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (this._items == null)
            {
                return false;
            }
            return this._items.ContainsKey(key);
        }

        ~ObjectCache()
        {
            this._checker = null;
            if (this._items != null)
            {
                this._items.Clear();
                this._items = null;
            }
            GC.Collect();
        }

        public object GetObject(object key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (this._items.ContainsKey(key))
            {
                lock (this._items.SyncRoot)
                {
                    if (this._items.ContainsKey(key))
                    {
                        return this.Unwrap(this._items[key]);
                    }
                }
            }
            return null;
        }

        protected virtual void Item_OnChanged(object sender, EventArgs e)
        {
            if (this.ItemChanged != null)
            {
                this.ItemChanged(sender, e);
            }
        }

        protected virtual void Item_OnReleased(object sender, EventArgs e)
        {
            CacheItem item = sender as CacheItem;
            if (item != null)
            {
                item.Releasing -= new CancelEventHandler(this.Item_OnReleasing);
                item.Released -= new EventHandler(this.Item_OnReleased);
                item.Changed -= new EventHandler(this.Item_OnChanged);
                if (this.ItemReleased != null)
                {
                    this.ItemReleased(sender, e);
                }
            }
        }

        protected virtual void Item_OnReleasing(object sender, CancelEventArgs e)
        {
            CacheItem item = sender as CacheItem;
            if ((item != null) && this._items.Contains(item.Key))
            {
                this._items.Remove(item.Key);
            }
        }

        public void Remove(object key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            this.Remove(key, ObjectCacheItemRemovedReason.Removed);
        }

        protected virtual void Remove(object key, ObjectCacheItemRemovedReason reason)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if ((this._items != null) && this._items.ContainsKey(key))
            {
                lock (this._items.SyncRoot)
                {
                    if (this._items.ContainsKey(key))
                    {
                        CacheItem item = this._items[key] as CacheItem;
                        if (item != null)
                        {
                            item.RemovedReason = reason;
                            item.Release();
                        }
                    }
                }
            }
        }

        public void SetObject(object key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (!this.Contains(key))
            {
                this.Add(this.Wrap(key, value));
            }
            else
            {
                CacheItem item = this._items[key] as CacheItem;
                if (item == null)
                {
                    this.Remove(key, ObjectCacheItemRemovedReason.Underused);
                    this.SetObject(key, value);
                }
                item.Value = value;
            }
        }

        private object Unwrap(object value)
        {
            CacheItem item = value as CacheItem;
            if (item == null)
            {
                return null;
            }
            return item.Value;
        }

        private CacheItem Wrap(object key, object value)
        {
            return new CacheItem(key, value);
        }

        public bool IsSynchronized
        {
            get
            {
                return this._items.IsSynchronized;
            }
        }

        public object this[object key]
        {
            get
            {
                return this.GetObject(key);
            }
            set
            {
                this.SetObject(key, value);
            }
        }

        public ICollection Keys
        {
            get
            {
                return this._items.Keys;
            }
        }

        public virtual int MaxCount
        {
            get
            {
                return 0x10013;
            }
        }

        public virtual int Period
        {
            get
            {
                return 5;
            }
        }

        public object SyncRoot
        {
            get
            {
                return this._items.SyncRoot;
            }
        }

        public class CacheItem : IReleasable
        {
            private DateTime _absoluteExpiration;
            private ObjectCacheItemRemovedCallback _callback;
            private DateTime _dateCreated;
            private ICacheDependency _dependency;
            private object _key;
            private ObjectCacheItemRemovedReason _removedReason;
            private object _value;
            protected const int DefaultReleaseSecond = 300;

            public event EventHandler Changed;

            public event CancelEventHandler Changing;

            public event EventHandler Disposed;

            public event EventHandler Released;

            public event CancelEventHandler Releasing;

            internal CacheItem(object key, object value) : this(key, value, null)
            {
            }

            internal CacheItem(object key, object value, CacheKeyDependency dependency)
            {
                if (key == null)
                {
                    throw new ArgumentNullException("key");
                }
                this._key = key;
                this._value = value;
                this._removedReason = ObjectCacheItemRemovedReason.Underused;
                this._dateCreated = DateTime.UtcNow;
                this._absoluteExpiration = this._dateCreated.AddSeconds(300.0);
                this._dependency = dependency;
                this._callback = null;
            }

            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
                if (this.Disposed != null)
                {
                    this.Disposed(this, EventArgs.Empty);
                }
            }

            private void Dispose(bool disposing)
            {
                if (disposing)
                {
                    this._value = null;
                }
            }

            public void Release()
            {
                CancelEventArgs e = new CancelEventArgs(false);
                if (this.Releasing != null)
                {
                    this.Releasing(this, e);
                }
                if (!e.Cancel)
                {
                    if (this.Callback != null)
                    {
                        this.Callback(this.Key, this.Value, ObjectCacheItemRemovedReason.Underused);
                    }
                    this.Dispose();
                    if (this.Released != null)
                    {
                        this.Released(this, EventArgs.Empty);
                    }
                }
            }

            internal void Release(object state)
            {
                this.Release();
            }

            public DateTime AbsoluteExpiration
            {
                get
                {
                    return this._absoluteExpiration.ToLocalTime();
                }
                set
                {
                    this._absoluteExpiration = value.ToUniversalTime();
                }
            }

            public ObjectCacheItemRemovedCallback Callback
            {
                get
                {
                    return this._callback;
                }
                set
                {
                    this._callback = value;
                }
            }

            public DateTime DateTimeCreated
            {
                get
                {
                    return this._dateCreated.ToLocalTime();
                }
            }

            public ICacheDependency Dependency
            {
                get
                {
                    return this._dependency;
                }
                set
                {
                    this._dependency = value;
                }
            }

            public bool IsExpired
            {
                get
                {
                    if (this._absoluteExpiration <= DateTime.UtcNow)
                    {
                        this._removedReason = ObjectCacheItemRemovedReason.Expired;
                        return true;
                    }
                    if ((this._dependency != null) && this._dependency.HasChanged)
                    {
                        this._removedReason = ObjectCacheItemRemovedReason.DependencyChanged;
                        return true;
                    }
                    return false;
                }
            }

            public object Key
            {
                get
                {
                    return this._key;
                }
            }

            internal ObjectCacheItemRemovedReason RemovedReason
            {
                set
                {
                    this._removedReason = value;
                }
            }

            public object Value
            {
                get
                {
                    return this._value;
                }
                set
                {
                    CancelEventArgs e = new CancelEventArgs(false);
                    if (this.Changing != null)
                    {
                        this.Changing(this, e);
                    }
                    if (!e.Cancel)
                    {
                        this._value = value;
                        if (this.Changed != null)
                        {
                            this.Changed(this, EventArgs.Empty);
                        }
                    }
                }
            }
        }
    }
}