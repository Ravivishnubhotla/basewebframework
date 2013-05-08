using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPS.Bussiness.HttpUtils
{
    public class UrlSendEventArgs : EventArgs
    {
        private UrlSendTask sendTask;

        public UrlSendEventArgs(UrlSendTask _sendTask) : base()
        {
            this.sendTask = _sendTask;
        }

        public UrlSendTask SendTask
        {
            get
            {
                return sendTask;
            }
        }
    }
}
