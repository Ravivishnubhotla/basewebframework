using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPS.Bussiness.Wrappers;

namespace SPS.Bussiness.Code
{
    [Serializable]
    public class SPInterceptRateItem
    {
        public int ChannelID { get; set; }
        public int ClientID { get; set; }
        public int CodeID { get; set; }
        public int AllCount { get; set; }
        public int InterceptCount { get; set; }

        public decimal InterceptRate {
            get
            {
                if (AllCount <= 0)
                    return decimal.Zero;

                return (decimal)((decimal)InterceptCount / (decimal)AllCount);
            }
        }
    }
}
