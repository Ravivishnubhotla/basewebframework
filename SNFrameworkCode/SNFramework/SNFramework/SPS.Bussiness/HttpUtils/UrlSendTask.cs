using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPS.Bussiness.HttpUtils
{
    [Serializable]
    public class UrlSendTask
    {
        public string OkMessage { get; set; }
        public string SendUrl { get; set; }
        public int RecordID { get; set; }
    }
}
