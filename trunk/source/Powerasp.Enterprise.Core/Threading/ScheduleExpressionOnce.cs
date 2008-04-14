using System;
using Powerasp.Enterprise.Core.Threading;

namespace Powerasp.Enterprise.Core.Threading
{
    public class ScheduleExpressionOnce : IScheduleExpression
    {
        private SchedulePrecision _precision;
        private DateTime _time;

        public ScheduleExpressionOnce(DateTime dateTime) : this(dateTime, SchedulePrecision.Second)
        {
        }

        public ScheduleExpressionOnce(DateTime dateTime, SchedulePrecision precision)
        {
            this._time = dateTime;
            this._precision = precision;
        }

        public bool CanInvoke(DateTime now)
        {
            string format = null;
            switch (this._precision)
            {
                case SchedulePrecision.Second:
                    format = "yyyy-MM dd HH:ss";
                    break;

                case SchedulePrecision.Minute:
                    format = "yyyy-MM dd HH:mm";
                    break;

                case SchedulePrecision.Hour:
                    format = "yyyy-MM dd HH";
                    break;

                case SchedulePrecision.Day:
                    format = "yyyy-MM-dd";
                    break;

                case SchedulePrecision.DayOfWeek:
                    format = "yyyy-MM dddd";
                    break;

                case SchedulePrecision.Month:
                    format = "yyyy-MM";
                    break;

                case SchedulePrecision.Year:
                    format = "yyyy";
                    break;

                default:
                    return false;
            }
            return (this._time.ToString(format) == now.ToString(format));
        }

        public bool Once
        {
            get
            {
                return true;
            }
        }
    }
}