using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.SqlGeneration.Schema;

namespace SPSUtil.AppCode
{
    public enum SPSRequestType
    {
        HttpGet,
        HttpPost,
        HttpXMLPost
    }

    [Serializable]
    public class SPSRequestTest
    {
        [SubSonicPrimaryKey] 
        public int Id { get; set; }
        [SubSonicStringLength(200)] 
        public string Name { get; set; }
        [SubSonicStringLength(2000)] 
        public string Description { get; set; }
        public SPSRequestType RequestType { get; set; }




    }
}
