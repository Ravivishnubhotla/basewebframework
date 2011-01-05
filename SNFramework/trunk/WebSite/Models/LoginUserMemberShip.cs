using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class LoginUserMemberShip
    {
        private string loginID;
        private int dataID;
        private bool isVip;
        private DateTime vipStartDate;
        private DateTime vipEndDate;
        private DateTime loginTime;
        private DateTime lastTime;
        private string lastVisitUrl;
        private string isGuest;

        public DateTime LoginTime
        {
            get { return loginTime; }
            set { loginTime = value; }
        }

        public DateTime LastTime
        {
            get { return lastTime; }
            set { lastTime = value; }
        }

        public string LastVisitUrl
        {
            get { return lastVisitUrl; }
            set { lastVisitUrl = value; }
        }

        public string IsGuest
        {
            get { return isGuest; }
            set { isGuest = value; }
        }

        public string LoginId
        {
            get { return loginID; }
            set { loginID = value; }
        }

        public int DataId
        {
            get { return dataID; }
            set { dataID = value; }
        }

        public bool IsVip
        {
            get { return isVip; }
            set { isVip = value; }
        }

        public DateTime VipStartDate
        {
            get { return vipStartDate; }
            set { vipStartDate = value; }
        }

       public DateTime VipEndDate
        {
            get { return vipEndDate; }
            set { vipEndDate = value; }
        }
    }
}