using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Legendigital.Common.Web.Services
{
    [Serializable]
    public class SPSSendUrlEntity
    {
        public int ClientID { get; set; }
        public int ChannelID { get; set; }
        public int SycnRetryTimes { get; set; }
        public string SendUrl { get; set; }
        public int PaymentID { get; set; }
    }
}