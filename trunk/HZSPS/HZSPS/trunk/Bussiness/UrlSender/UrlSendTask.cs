using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD.SPPipeManage.Bussiness.UrlSender
{
    [Serializable]
    public class UrlSendTask
    {
        public string OkMessage { get; set; }
        public string SendUrl { get; set; }
        public int PaymentID { get; set; }
    }
}
