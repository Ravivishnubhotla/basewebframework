using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.SqlGeneration.Schema;

namespace SPSUtil.AppCode
{
    [Serializable]
    public class SPSTestTask
    {
        [SubSonicPrimaryKey] 
        public int Id { get; set; }
        public int SPSRequestTestId { get; set; }
        public bool IsMutilThead { get; set; }
        public int MutilTheadCount { get; set; }
        public int Interval { get; set; }
        public int TestCount { get; set; }
    }
}
