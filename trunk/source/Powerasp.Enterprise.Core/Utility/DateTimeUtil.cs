using System;

namespace Powerasp.Enterprise.Core.Utility
{
    public class DateTimeUtil
    {
        public static int GetCurrentTimeZone()
        {
            DateTime now = DateTime.Now;
            DateTime time2 = now.ToUniversalTime();
            TimeSpan span = new TimeSpan(now.Ticks - time2.Ticks);
            return span.Hours;
        }
    }
}