using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace SPSUtil.AppCode
{
    public class PhoneArea
    {
        public ObjectId Id { get; set; }
        public string PhonePrefix { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string OperatorType { get; set; }
    }
}
