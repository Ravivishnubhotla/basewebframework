using System;
using System.Runtime.InteropServices;
using Powerasp.Enterprise.Core.Globalization;

namespace Powerasp.Enterprise.Core.Globalization
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ChineseDate
    {
        internal static readonly DateTime StartDay;
        internal DateTime idate;
        internal bool ileapMonth;
        internal DateTime ilunarDate;
        internal ChineseDate(DateTime date)
        {
            if ((date.Year < 0x76d) || (date.Year > 0x802))
            {
                throw new ArgumentOutOfRangeException("date");
            }
            this.idate = date;
            this.ileapMonth = false;
            this.ilunarDate = new DateTime(0x76c, 1, 1);
        }

        internal int SpanDays
        {
            get
            {
                TimeSpan span = new TimeSpan(this.idate.Ticks - StartDay.Ticks);
                return span.Days;
            }
        }
        public string AnimalsSymbolName
        {
            get
            {
                return ChineseCalendar.GetAnimalsSymbolName(this);
            }
        }
        public string YearEraName
        {
            get
            {
                return ChineseCalendar.GetYearEraName(this);
            }
        }
        public string LunarMonth
        {
            get
            {
                return ChineseCalendar.GetLunarMonth(this);
            }
        }
        public string LunarDay
        {
            get
            {
                return ChineseCalendar.GetLunarDay(this);
            }
        }
        public string LunarHolDay
        {
            get
            {
                return ChineseCalendar.GetLunarHolDay(this);
            }
        }
        public bool IsLeapMonth
        {
            get
            {
                return this.ileapMonth;
            }
        }
        static ChineseDate()
        {
            StartDay = new DateTime(0x76d, 1, 1);
        }
    }
}