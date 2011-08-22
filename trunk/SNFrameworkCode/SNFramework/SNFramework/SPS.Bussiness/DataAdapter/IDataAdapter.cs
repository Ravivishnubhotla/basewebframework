using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPS.Bussiness.DataAdapter
{
    public interface IDataAdapter
    {
        string RequestSoucre { get; set; }

        string RequestSoucreParamsString { get; set; }

        string RequestData { get; set; }

        string RequestIp { get; set; }

        string RequestFileName { get; set; }

        Hashtable RequestParams { get; set; }

        string GetChannelCode();

        bool IsRequestContainValues(string fieldName, string value);
    }
}
