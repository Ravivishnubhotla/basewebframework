using System;
using System.IO;
using System.Net;
using System.Text;

namespace Legendigital.Framework.Common.Web.Request
{
    public class WebRequestHelper
    {




        public static WebRequestResult SendRequest(string requesturl, int timeOut)
        {
            WebRequestResult result = new WebRequestResult();

            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(requesturl);

                webRequest.Timeout = timeOut;

                HttpWebResponse webResponse = null;

                webResponse = (HttpWebResponse)webRequest.GetResponse();


                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.Default);

                    result.ResponseText = sr.ReadToEnd();

                    result.IsSuccess = true;

                    result.ErrorMessage = "";

                    return result;
                }

                result.ResponseText = "";

                result.ErrorMessage = "web error Status:" + webResponse.StatusCode.ToString();

                result.IsSuccess = false;

                return result;
            }
            catch (Exception e)
            {

                result.ResponseText = "";

                result.ErrorMessage = e.Message;

                result.IsSuccess = false;

                return result;
            }
        }



    }
}
