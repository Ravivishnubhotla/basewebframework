﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Legendigital.Framework.Common.Utility;

namespace LD.SPPipeManage.Bussiness.Commons
{
    [Serializable]
    public class HttpGetPostRequest
    {
        private Hashtable requestParams;

        private string requestData;

        private string requestIP;

        private string requestFileName;

        private string requestUrl;

        public string RequestUrl
        {
            get { return requestUrl; }
            set { requestUrl = value; }
        }

        private string requestQueryString;

        public string RequestQueryString
        {
            get { return requestQueryString; }
            set { requestQueryString = value; }
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


        public HttpGetPostRequest(HttpRequest request)
        {
            requestParams = PraseHttpGetPostRequestValue(request);

            requestData = SerializeUtil.ToJson(requestParams);

            requestIP = GetIP(request);

            requestFileName = Path.GetFileNameWithoutExtension(request.PhysicalPath);

            requestUrl = request.Url.ToString();

            requestQueryString = request.Url.Query;
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
            }
            return ip;
        }

        public static Hashtable PraseHttpGetPostRequestValue(HttpRequest request)
        {
            Hashtable hb = new Hashtable();

            foreach (string key in request.Params.Keys)
            {
                if (!string.IsNullOrEmpty(key))
                    hb.Add(key.ToLower(), request.Params[key.ToLower()]);
            }

            return hb;
        }

 


        public bool IsRequestContainValues(string fieldName, string value)
        {
            return requestParams.ContainsKey(fieldName.ToLower()) && requestParams[fieldName.ToLower()].ToString().ToLower().Trim().Contains(value.ToLower().Trim());
        }



        public string GetChannelCode()
        {
            return this.requestFileName.Substring(0, this.requestFileName.Length - ("Recieved").Length);
        }
    }
}