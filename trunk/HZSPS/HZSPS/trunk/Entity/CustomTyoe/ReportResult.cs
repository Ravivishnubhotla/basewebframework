using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD.SPPipeManage.Entity.CustomTyoe
{
    [Serializable]
    public class ReportResult
    {
        public DateTime ReportDate { get; set; }
        public int TotalCount { get; set; }
        public int DownCount { get; set; }
        public int InterceptCount { get; set; }
        public int DownSycnCount { get; set; }
        public decimal InterceptRate { get; set; }

    }
}
