using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPS.Bussiness.Code
{
    [Serializable]
    public class SPDayReport
    {
        #region 公共属性


        public int Id { get; set; }
        public DateTime ReportDate { get; set; }
        public int TotalCount { get; set; }
        public int TotalSuccessCount { get; set; }
        public int InterceptCount { get; set; }
        public int DownTotalCount { get; set; }
        public int DownSycnSuccess { get; set; }
        public int DownSycnFailed { get; set; }
        public int DownNotSycn { get; set; }
        public int ClientID { get; set; }
        public int ChannelID { get; set; }
        public int CodeID { get; set; }
        public string ChannelID_Name { get; set; }
        public string ClientID_Name { get; set; }
        public string CodeID_MoCode { get; set; }
        

        #endregion 


    }
}
