using System;
using System.Threading;
using Powerasp.Enterprise.Core.Threading;

namespace Powerasp.Enterprise.Core.Threading
{
    public class ScheduleExpressionDaily : IScheduleExpression
    {
        private bool _checkSecond;
        private bool _locked;
        private DateTime _timeLastInvoked;
        private TimeSpan _timeOfDay;

        private ScheduleExpressionDaily()
        {
            this._locked = false;
            this._timeLastInvoked = DateTime.Now;
        }

        public ScheduleExpressionDaily(TimeSpan timeOfDay) : this(timeOfDay, DateTime.Now)
        {
        }

        public ScheduleExpressionDaily(TimeSpan timeOfDay, DateTime timeStart) : this(timeOfDay, timeStart, false)
        {
        }

        public ScheduleExpressionDaily(TimeSpan timeOfDay, DateTime timeStart, bool checkSecond) : this()
        {
            if (timeOfDay.Days > 1)
            {
                throw new ArgumentException("timeOfDay must less than 1 day.");
            }
            this._timeOfDay = timeOfDay;
            this._timeLastInvoked = timeStart;
            this._checkSecond = checkSecond;
        }

        public bool CanInvoke(DateTime now)
        {
            bool state = false;
            if ((((now > this._timeLastInvoked) && (this._timeOfDay.Hours == now.Hour)) && ((this._timeOfDay.Minutes == now.Minute) && this._checkSecond)) && ((this._timeOfDay.Seconds != now.Second) && !this._locked))
            {
                try
                {
                    this.Lock();
                    state = true;
                }
                catch
                {
                    state = false;
                }
                finally
                {
                    new Timer(new TimerCallback(this.Unlock), state, 0xea60, -1);
                }
            }
            return state;
        }

        public void Lock()
        {
            if (!this._locked)
            {
                lock (this)
                {
                    if (!this._locked)
                    {
                        this._locked = true;
                    }
                }
            }
        }

        public void Unlock()
        {
            this.Unlock(null);
        }

        private void Unlock(object state)
        {
            if (this._locked)
            {
                lock (this)
                {
                    if (this._locked)
                    {
                        this._locked = false;
                        this._timeLastInvoked = DateTime.Now;
                    }
                }
            }
        }

        public DateTime LastInvoked
        {
            get
            {
                return this._timeLastInvoked;
            }
        }

        public bool Once
        {
            get
            {
                return false;
            }
        }
    }
}