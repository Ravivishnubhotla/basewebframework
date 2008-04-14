using System;
using System.Collections;
using System.Threading;

namespace Powerasp.Enterprise.Core.Threading
{
    public class Interval
    {
        private static Hashtable __intervalTable = Hashtable.Synchronized(new Hashtable());
        private static Timer __timer = new Timer(new TimerCallback(Interval.InvokeCallBack), null, 0, 0x3e8);
        private IntervalItem _item;
        private int _second = 0;
        private const int DefaultPeriod = 0x3e8;

        private Interval()
        {
            this._second = 0;
        }

        public void AddCallBack(IntervalCallBack callBack)
        {
            if (callBack == null)
            {
                throw new ArgumentNullException("callBack");
            }
            lock (this._item.CallBackList.SyncRoot)
            {
                if (!this._item.CallBackList.Contains(callBack))
                {
                    this._item.CallBackList.Add(callBack);
                }
            }
        }

        private static void CallBackList(object state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state");
            }
            ArrayList list = null;
            IntervalCallBack back = null;
            list = state as ArrayList;
            if (list == null)
            {
                throw new ArgumentException("state not is ArrayList");
            }
            for (int i = 0; i < list.Count; i++)
            {
                back = list[i] as IntervalCallBack;
                if (back != null)
                {
                    new Thread(new ThreadStart(back.Invoke)).Start();
                }
            }
        }

        public static void ChangeInterval(Interval interval, int second)
        {
            if (interval == null)
            {
                throw new ArgumentNullException("interval");
            }
            if (second < 0)
            {
                throw new ArgumentException("second must big than zero!");
            }
            if (interval._second == second)
            {
            }
        }

        public static Interval CreateInstance()
        {
            return CreateInstance(0x3e8);
        }

        public static Interval CreateInstance(int second)
        {
            if (second < 0)
            {
                throw new ArgumentException("second must big than zero!");
            }
            Interval interval = null;
            if (!__intervalTable.ContainsKey(second))
            {
                lock (__intervalTable.SyncRoot)
                {
                    if (!__intervalTable.ContainsKey(second))
                    {
                        interval = new Interval();
                        interval._second = second;
                        interval._item = new IntervalItem(second);
                        __intervalTable.Add(second, interval);
                    }
                }
            }
            return (Interval) __intervalTable[second];
        }

        private static void InvokeCallBack(object state)
        {
            if (__intervalTable.Count > 0)
            {
                lock (typeof(Interval))
                {
                    if (__intervalTable.Count > 0)
                    {
                        foreach (object obj2 in __intervalTable.Keys)
                        {
                            try
                            {
                                Interval interval = __intervalTable[obj2] as Interval;
                                if (interval != null)
                                {
                                    if (interval._item.IsExpired)
                                    {
                                        try
                                        {
                                            WorkThread.QueueItem(new WaitCallback(Interval.CallBackList), interval._item.CallBackList);
                                            continue;
                                        }
                                        catch
                                        {
                                            continue;
                                        }
                                        finally
                                        {
                                            interval._item.Reset();
                                        }
                                    }
                                    interval._item.Increment();
                                }
                                continue;
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                }
            }
        }

        public void RemoveCallBack(IntervalCallBack callBack)
        {
            if (callBack == null)
            {
                throw new ArgumentNullException("method");
            }
            lock (this._item.CallBackList.SyncRoot)
            {
                if (this._item.CallBackList.Contains(callBack))
                {
                    this._item.CallBackList.Remove(callBack);
                }
            }
        }

        private class IntervalItem
        {
            private ArrayList _callBackList;
            private int _count;
            private int _second;

            private IntervalItem()
            {
                this._count = 0;
                this._second = 0;
                this._callBackList = ArrayList.Synchronized(new ArrayList());
            }

            public IntervalItem(int second) : this()
            {
                this._second = second;
            }

            public void Increment()
            {
                lock (this)
                {
                    Interlocked.Increment(ref this._count);
                }
            }

            public void Reset()
            {
                lock (this)
                {
                    this._count = 0;
                }
            }

            internal ArrayList CallBackList
            {
                get
                {
                    return this._callBackList;
                }
            }

            internal bool IsExpired
            {
                get
                {
                    if (this._second != this._count)
                    {
                        return false;
                    }
                    return true;
                }
            }
        }
    }
}