using System;
using System.Collections;
using System.Threading;
using Powerasp.Enterprise.Core.Threading;

namespace Powerasp.Enterprise.Core.Threading
{
    public class TimeoutChecker
    {
        private bool _checking;
        private Interval _interval;
        private IList _items;
        private const int DefaultCheckSecond = 1;

        public TimeoutChecker() : this(1)
        {
        }

        public TimeoutChecker(int second)
        {
            this._checking = false;
            this._items = new ArrayList();
            this._interval = Interval.CreateInstance(second);
            this._interval.AddCallBack(new IntervalCallBack(this.Check));
        }

        public void Add(IReleasable item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            WeakReference reference = new WeakReference(item, false);
            lock (this._items.SyncRoot)
            {
                this._items.Add(reference);
            }
        }

        public void ChangeInterval(int seconds)
        {
            lock (this)
            {
                if (this._interval != null)
                {
                    this._interval.RemoveCallBack(new IntervalCallBack(this.Check));
                }
                this._interval = Interval.CreateInstance(seconds);
                this._interval.AddCallBack(new IntervalCallBack(this.Check));
            }
        }

        protected virtual void Check()
        {
            if (!this._checking)
            {
                try
                {
                    lock (this)
                    {
                        if (this._checking)
                        {
                            return;
                        }
                        this._checking = true;
                    }
                    int index = 0;
                    lock (this._items.SyncRoot)
                    {
                        while (index < this._items.Count)
                        {
                            if (this._items[index] == null)
                            {
                                this._items.RemoveAt(index);
                            }
                            else
                            {
                                WeakReference state = this._items[index] as WeakReference;
                                if ((state == null) || !state.IsAlive)
                                {
                                    this._items.RemoveAt(index);
                                    continue;
                                }
                                IReleasable target = state.Target as IReleasable;
                                if ((target == null) || target.IsExpired)
                                {
                                    this._items.RemoveAt(index);
                                    WorkThread.QueueItem(new WaitCallback(this.ReleaseItem), state);
                                    continue;
                                }
                                index++;
                            }
                        }
                    }
                }
                finally
                {
                    this._checking = false;
                }
            }
        }

        ~TimeoutChecker()
        {
            this._items.Clear();
            this._items = null;
            this._interval.RemoveCallBack(new IntervalCallBack(this.Check));
            this._interval = null;
        }

        protected virtual void ReleaseItem(object state)
        {
            if (state != null)
            {
                WeakReference reference = state as WeakReference;
                if (reference != null)
                {
                    if (reference.IsAlive)
                    {
                        IReleasable target = reference.Target as IReleasable;
                        if (target != null)
                        {
                            target.Release();
                        }
                    }
                    reference = null;
                }
            }
        }
    }
}