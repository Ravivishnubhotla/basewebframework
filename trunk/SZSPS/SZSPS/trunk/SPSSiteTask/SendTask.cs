using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPSSiteTask.SPDataService;

namespace SPSSiteTask
{
    public class SendTask
    {
        private bool isEnd = false;
        private List<int> channeClientIDs = new List<int>();
        private string host;
        private DateTime startDate;
        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private List<SPSSendUrlEntity> sendUrls;

        public string Host
        {
            get { return host; }
            set { host = value; }
        }

        public bool IsEnd
        {
            get { return isEnd; }
            set { isEnd = value; }
        }

        public List<int> ChanneClientIds
        {
            get { return channeClientIDs; }
            set { channeClientIDs = value; }
        }

 
    }
}
