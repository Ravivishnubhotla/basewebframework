using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SPS.Bussiness.DataAdapter
{
    public class RequestContentAdapter : IDataAdapter
    {
        public string ChannelCode { get; set; }
        public string RequestSoucre { get; set; }
        public string RequestSoucreParamsString { get; set; }
        public string RequestData { get; set; }
        public string RequestIp { get; set; }
        public string RequestFileName { get; set; }
        public Hashtable RequestParams { get; set; }

        public RequestContentAdapter(string _requestData)
        {
            ChannelCode = "";

            RequestParams = JsonConvert.DeserializeObject<Hashtable>(_requestData);

            RequestData = _requestData;

            RequestIp = "";

            RequestFileName = "";

            RequestSoucre = "";

            RequestSoucreParamsString = "";
        }

        public string GetChannelCode()
        {
            return ChannelCode;
        }

        public bool IsRequestContainValues(string fieldName, string value)
        {
            return RequestParams.ContainsKey(fieldName.ToLower()) && RequestParams[fieldName.ToLower()].ToString().ToLower().Trim().Contains(value.ToLower().Trim());
        }
    }
}
