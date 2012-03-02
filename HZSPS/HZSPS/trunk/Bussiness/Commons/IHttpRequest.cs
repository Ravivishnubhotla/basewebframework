using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LD.SPPipeManage.Bussiness.Commons
{
    public interface IHttpRequest
    {
        string RequestUrl { get; set; }

        string RequestQueryString { get; set; }

        string RequestData { get; set; }

        string RequestIp { get; set; }

        string RequestFileName { get; set; }

        Hashtable RequestParams { get; set; }

        string GetChannelCode();

        bool IsRequestContainValues(string fieldName, string value);
    }
}
