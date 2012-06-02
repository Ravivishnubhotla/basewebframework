using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Legendigital.Framework.Common.Utility;
using Newtonsoft.Json;
using SPS.Bussiness.Wrappers;

namespace SPS.Bussiness.DataAdapter
{
    public class HttpGetPostAdapter : IDataAdapter
    {
        private Hashtable requestParams;

        private string requestData;

        private string requestIP;

        private string requestFileName;

        private string requestSoucre;

        public string RequestSoucre
        {
            get { return requestSoucre; }
            set { requestSoucre = value; }
        }

        public static HashSet<string> recordParamsNames = new HashSet<string>() { "url", "query_string" };

        public static HashSet<string> filterParamsNames = new HashSet<string>() { ".basewebmanageframework", "currentloginid", "asp.net_sessionid" };

        private string requestSoucreParamsString;

        public string RequestSoucreParamsString
        {
            get { return requestSoucreParamsString; }
            set { requestSoucreParamsString = value; }
        }

        public string RequestData
        {
            get { return requestData; }
            set { requestData = value; }
        }

        public string RequestIp
        {
            get { return requestIP; }
            set { requestIP = value; }
        }

        public string RequestFileName
        {
            get { return requestFileName; }
            set { requestFileName = value; }
        }

        public Hashtable RequestParams
        {
            get { return requestParams; }
            set { requestParams = value; }
        }


        public HttpGetPostAdapter(HttpRequest request)
        {
            requestParams = PraseHttpGetPostRequestValue(request);

            requestData = JsonConvert.SerializeObject(requestParams);

            requestIP = GetIP(request);

            requestFileName = Path.GetFileName(request.PhysicalPath);

            requestSoucre = request.Url.ToString();

            requestSoucreParamsString = request.Url.Query;
        }

        public HttpGetPostAdapter(IDataAdapter request)
        {
            requestParams = new Hashtable();

            foreach (DictionaryEntry dictionaryEntry in request.RequestParams)
            {
                requestParams.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            }

            requestData = JsonConvert.SerializeObject(requestParams);

            requestIP = request.RequestIp;

            requestFileName = request.RequestFileName;

            requestSoucre = request.RequestSoucre;

            requestSoucreParamsString = request.RequestSoucreParamsString;
        }




        public static string GetIP(HttpRequest request)
        {
            string ip = string.Empty;
            try
            {
                if (request.ServerVariables["HTTP_VIA"] != null)
                {
                    ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Split(',')[0].Trim();
                }
                else
                {
                    ip = request.UserHostAddress;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ip;
        }

        public static Hashtable PraseHttpGetPostRequestValue(HttpRequest request)
        {
            Hashtable hb = new Hashtable();

            foreach (string key in request.Params.Keys)
            {
                if (string.IsNullOrEmpty(key))
                    continue;

                if (filterParamsNames.Contains(key.ToLower()))
                    continue;

                if ((recordParamsNames.Contains(key.ToLower())))
                {
                    hb.Add(key.ToLower(), request.Params[key.ToLower()]);
                    continue;
                }

                if (request.ServerVariables[key] == null)
                {
                    hb.Add(key.ToLower(), request.Params[key.ToLower()]);
                    continue;
                }

            }

            return hb;
        }

 


        public bool IsRequestContainValues(string fieldName, string value)
        {
            return requestParams.ContainsKey(fieldName.ToLower()) && requestParams[fieldName.ToLower()].ToString().ToLower().Trim().Contains(value.ToLower().Trim());
        }



        public string GetChannelCode()
        {

            string dataAdaptorUrl = Path.GetFileNameWithoutExtension(this.requestFileName);

            string fileExt = Path.GetExtension(this.requestFileName);

            string handlerName = "HttpGetPostAdapter";

            if (dataAdaptorUrl.ToLower().EndsWith((SPChannelWrapper.ChannelType_SPS + handlerName).ToLower()))
            {
                dataAdaptorUrl = GetDataAdaptorUrl(dataAdaptorUrl, SPChannelWrapper.ChannelType_SPS, handlerName.Length);
            }
            else if (dataAdaptorUrl.ToLower().EndsWith((SPChannelWrapper.ChannelType_IVRCS + handlerName).ToLower()))
            {
                dataAdaptorUrl = GetDataAdaptorUrl(dataAdaptorUrl, SPChannelWrapper.ChannelType_IVRCS, handlerName.Length);
            }
            else if (dataAdaptorUrl.ToLower().EndsWith((SPChannelWrapper.ChannelType_CustomCS + handlerName).ToLower()))
            {
                dataAdaptorUrl = GetDataAdaptorUrl(dataAdaptorUrl, SPChannelWrapper.ChannelType_CustomCS, handlerName.Length);
            }

            return dataAdaptorUrl + handlerName + fileExt;
        }

        public static string GetDataAdaptorUrl(string dataAdaptorUrl, string prefix, int handlerlength)
        {
            dataAdaptorUrl = dataAdaptorUrl.Substring(0, dataAdaptorUrl.Length - prefix.Length - handlerlength);

            return dataAdaptorUrl;
        }
    }
}
