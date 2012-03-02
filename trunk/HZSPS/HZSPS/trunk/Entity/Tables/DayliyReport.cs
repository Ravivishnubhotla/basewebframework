using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD.SPPipeManage.Bussiness.Wrappers
{
    public class DayliyReport
    {
        public DateTime ReportDate { get; set; }
        public int SPClientID { get; set; }
        public int TotalCount { get; set; }
        public int InterceptCount { get; set; }
        public int DownCount { get; set; }
        public int SycnCount { get; set; }
    }
}
