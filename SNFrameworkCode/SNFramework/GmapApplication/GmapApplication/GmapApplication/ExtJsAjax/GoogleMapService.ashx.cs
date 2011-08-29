using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace GmapApplication.ExtJsAjax
{
    /// <summary>
    /// Summary description for GoogleMapService
    /// </summary>
    public class GoogleMapService : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.QueryString["ServiceType"]))
                return;

            string serviceType = context.Request.QueryString["ServiceType"];

            string responseText = "";

            string errorText = "";

            Uri uri = null;

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            switch (serviceType)
            {
                case "geocode":
                    
                    foreach (var key in context.Request.QueryString.AllKeys)
                    {
                        if(key.Equals("ServiceType"))
                            continue;

                        queryString.Add(key, context.Request.QueryString[key]);
                    }

                    uri = new Uri(string.Format("http://maps.google.com/maps/api/geocode/json?{0}", queryString.ToString()));
 
                    break;

            }
 

            if (uri!=null && SendRequest(uri.ToString(),10000,out responseText,out errorText))
            {
                context.Response.ContentType = "application/json";
                context.Response.Write(responseText);
                return;
            }



        }

        private static bool SendRequest(string requesturl, int timeOut, out string returnMessage, out string errorMessage)
        {
            try
            {
                errorMessage = "";

                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(requesturl);

                webRequest.Timeout = timeOut;
                webRequest.Method = "GET";

                HttpWebResponse webResponse = null;

                webResponse = (HttpWebResponse)webRequest.GetResponse();


                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.Default);
                    returnMessage = sr.ReadToEnd();
                    errorMessage = "";
                    return true;
                }
                returnMessage = "";
                errorMessage = webResponse.StatusCode.ToString();
                return false;
            }
            catch (Exception e)
            {
                returnMessage = "";
                errorMessage = e.Message;
                return false;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}