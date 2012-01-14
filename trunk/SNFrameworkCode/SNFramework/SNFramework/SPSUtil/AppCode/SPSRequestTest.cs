using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public SPSRequestType RequestType { get; set; }




    }
}
