using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.SqlGeneration.Schema;

namespace SPSUtil.AppCode
{
    [Serializable]
    public class SPSTestParams
    {
        [SubSonicPrimaryKey] 
        public int Id { get; set; }
        public int SPSRequestTestId { get; set; }
        [SubSonicStringLength(200)] 
        public string Name { get; set; }
        [SubSonicStringLength(2000)] 
        public string TestValue { get; set; }


    }
}
