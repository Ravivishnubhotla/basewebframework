using System;
using System.Collections;
using System.IO;
using System.Threading;
using Powerasp.Enterprise.Core.Threading;

namespace Powerasp.Enterprise.Core.Caching
{
    public class FileCache
    {
        private static Hashtable __caches = Hashtable.Synchronized(new Hashtable());
        private DateTime _dateTimeLastChecked = DateTime.Now;
        private Interval _interval;
        private ArrayList _items = new ArrayList();
        private const int DefaultCheck = 5;

        private FileCache(int period)
        {
            this._interval = Interval.CreateInstance(period);
            this._interval.AddCallBack(new IntervalCallBack(this.Check));
        }

        public void Add(ISupportFileCached item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (!this._items.Contains(item))
            {
                lock (this._items.SyncRoot)
                {
                    if (!this._items.Contains(item))
                    {
                        this._items.Add(item);
                    }
                }
            }
        }

        public void Check()
        {
            this.Check(null);
        }

        private void Check(object state)
        {
            if (this._items.Count != 0)
            {
                DateTime now = DateTime.Now;
                try
                {
                    lock (this._items.SyncRoot)
                    {
                        if (this._items.Count != 0)
                        {
                            for (int i = 0; i < this._items.Count; i++)
                            {
                                if (this._items[i] is ISupportFileCached)
                                {
                                    this.CheckItem(this._items[i]);
                                }
                            }
                        }
                    }
                }
                finally
                {
                    this._dateTimeLastChecked = now;
                }
            }
        }

        private void CheckItem(object state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state");
            }
            string[] files = null;
            FileInfo info = null;
            ISupportFileCached cached = null;
            cached = state as ISupportFileCached;
            if (cached != null)
            {
                files = cached.Files;
                if (files.Length != 0)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (File.Exists(files[i]))
                        {
                            try
                            {
                                info = new FileInfo(files[i]);
                                if (info.LastWriteTime > this._dateTimeLastChecked)
                                {
                                    WorkThread.QueueItem(new WaitCallback(cached.FileReload), files[i]);
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
        }

        public static FileCache CreateInstance()
        {
            return CreateInstance(5);
        }

        public static FileCache CreateInstance(int period)
        {
            if (!__caches.ContainsKey(period))
            {
                lock (__caches.SyncRoot)
                {
                    if (!__caches.ContainsKey(period))
                    {
                        __caches.Add(period, new FileCache(period));
                    }
                }
            }
            return (__caches[period] as FileCache);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && (this._items != null))
            {
                lock (this._items.SyncRoot)
                {
                    this._items.Clear();
                }
                this._items = null;
            }
        }

        public void Remove(ISupportFileCached item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (this._items.Contains(item))
            {
                lock (this._items.SyncRoot)
                {
                    if (this._items.Contains(item))
                    {
                        this._items.Remove(item);
                    }
                }
            }
        }

        public void RemoveAt(int index)
        {
            if ((index < 0) || (index > (this._items.Count - 1)))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            ISupportFileCached item = null;
            lock (this._items.SyncRoot)
            {
                item = this._items[index] as ISupportFileCached;
            }
            if (item != null)
            {
                this.Remove(item);
            }
        }
    }
}