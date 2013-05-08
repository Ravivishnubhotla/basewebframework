using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPS.Bussiness.HttpUtils
{
    [Serializable]
    public class UrlPatchSendSetting
    {
        public int TimeOut { get; set; }
        public int SendInterval { get; set; }
        public int RetryTimes { get; set; }
        public int SendThreadCount { get; set; }
    }
}
