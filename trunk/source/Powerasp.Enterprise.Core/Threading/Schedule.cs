using System;
using System.Collections;
using System.Threading;
using Powerasp.Enterprise.Core.Threading;

namespace Powerasp.Enterprise.Core.Threading
{
    public class Schedule
    {
        private static Interval _interval = Interval.CreateInstance(1);
        private static Queue _removeItems = Queue.Synchronized(new Queue());
        private static ArrayList _scheduleItems = ArrayList.Synchronized(new ArrayList());

        static Schedule()
        {
            _interval.AddCallBack(new IntervalCallBack(Schedule.InvokeCallBack));
            _interval = Interval.CreateInstance(10);
            _interval.AddCallBack(new IntervalCallBack(Schedule.Clear));
        }

        public static void AddSchedule(ScheduleCallBack callBack, IScheduleExpression expression)
        {
            if (callBack == null)
            {
                throw new ArgumentNullException("callBack");
            }
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            ScheduledItem item = null;
            lock (_scheduleItems.SyncRoot)
            {
                item = new ScheduledItem(callBack, expression);
                _scheduleItems.Add(item);
            }
        }

        private static void Clear()
        {
            ScheduledItem item = null;
            if (_removeItems.Count > 0)
            {
                lock (_removeItems.SyncRoot)
                {
                    if (_removeItems.Count > 0)
                    {
                        while (_removeItems.Count > 0)
                        {
                            item = _removeItems.Dequeue() as ScheduledItem;
                            if (item != null)
                            {
                                object obj3;
                                Monitor.Enter(obj3 = _scheduleItems.SyncRoot);
                                try
                                {
                                    _scheduleItems.Remove(item);
                                    continue;
                                }
                                catch
                                {
                                    continue;
                                }
                                finally
                                {
                                    Monitor.Exit(obj3);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void InvokeCallBack()
        {
            if (_scheduleItems.Count > 0)
            {
                lock (_scheduleItems.SyncRoot)
                {
                    if (_scheduleItems.Count > 0)
                    {
                        DateTime now = DateTime.Now;
                        for (int i = 0; i < _scheduleItems.Count; i++)
                        {
                            try
                            {
                                ScheduledItem state = _scheduleItems[i] as ScheduledItem;
                                if (state != null)
                                {
                                    state.SetCheckTime(now);
                                    WorkThread.QueueItem(new WaitCallback(Schedule.InvokeCallBackItem), state);
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

        private static void InvokeCallBackItem(object state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state");
            }
            ScheduledItem item = null;
            item = state as ScheduledItem;
            if ((item != null) && item.CanInvoke)
            {
                try
                {
                    item.InvokeCallBack();
                }
                catch
                {
                }
                finally
                {
                    if (item.Expression.Once)
                    {
                        lock (_removeItems.SyncRoot)
                        {
                            _removeItems.Enqueue(item);
                        }
                    }
                }
            }
        }

        private class ScheduledItem
        {
            private ScheduleCallBack _callBack;
            private DateTime _checkedTime;
            private IScheduleExpression _expression;

            private ScheduledItem()
            {
                this._checkedTime = DateTime.MinValue;
                this._checkedTime = DateTime.MinValue;
            }

            internal ScheduledItem(ScheduleCallBack callBack, IScheduleExpression expression) : this()
            {
                if (callBack == null)
                {
                    throw new ArgumentNullException("callBack");
                }
                if (expression == null)
                {
                    throw new ArgumentNullException("expression");
                }
                this._callBack = callBack;
                this._expression = expression;
            }

            internal void InvokeCallBack()
            {
                if (this._callBack != null)
                {
                    WorkThread.QueueItem(new WaitCallback(this._callBack.Invoke), this._checkedTime);
                }
            }

            internal void SetCheckTime(DateTime checkedTime)
            {
                this._checkedTime = checkedTime;
            }

            public bool CanInvoke
            {
                get
                {
                    return this._expression.CanInvoke(this._checkedTime);
                }
            }

            public IScheduleExpression Expression
            {
                get
                {
                    return this._expression;
                }
            }
        }
    }
}