using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPSUtil.AppCode
{
    [Serializable]
    public class SPSTestParams
    {
        public int Id { get; set; }
        public int SPSRequestTestId { get; set; }
        public string Name { get; set; }
        public string TestValue { get; set; }


    }
}
