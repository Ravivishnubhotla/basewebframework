using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SPSUtil.AppCode
{
    public class HttpGetSenderTaskItem : IProgressTaskItem
    {

        public ProcessResult result = null;
        private int timeOut = 3000;
        public ProcessResult Result
        {
            get { return result; }
            set { result = value; }
        }

        public int TimeOut
        {
            get { return timeOut; }
            set { timeOut = value; }
        }

        public int TaskIndex { get; set; }
        public string SendUrl { get; set; }
        public string OkMessage { get; set; }
        public string ErrorMessage { get; set; }
        public string ResponseMessage { get; set; }
        public bool RequestOk { get; set; }




        public HttpGetSenderTaskItem(string sendUrl, string okMessage)
        {
            SendUrl = sendUrl;

            //for (int i = minGNumber; i <= maxGNumber; i++)
            //{
            //    templateUrl = templateUrl.Replace("{GN" + i.ToString() + "}", NumberGenerator.GetRandNumber(i));
            //}

            OkMessage = okMessage;
        }

        public void Process()
        {
            try
            {
                RequestOk = false;

                string errorMessage = string.Empty;

                string responseMessage = string.Empty;


                RequestOk = SendRequest(SendUrl, timeOut, OkMessage, out errorMessage, out responseMessage);

                this.ErrorMessage = errorMessage;

                this.ResponseMessage = responseMessage;

                if (RequestOk)
                {
                    result = new ProcessResult();
                    result.IsSuccess = RequestOk;
                    result.Message = string.Format("发送成功!响应消息{0}\n", this.ResponseMessage);
                    result.ErrorMessage = "";
                }
                else
                {
                    result = new ProcessResult();
                    result.IsSuccess = RequestOk;
                    result.Message = string.Format("发送失败!响应消息{0}\n", ResponseMessage);
                    result.ErrorMessage = errorMessage;
                }

            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
                this.RequestOk = false;
                result = new ProcessResult();
                result.IsSuccess = this.RequestOk;
                result.Message = string.Format("发送失败!错误消息{0}\n", ex.Message);
                result.ErrorMessage = ex.Message;
            }


        }

        private static bool SendRequest(string requesturl, int timeOut, string okMessage, out string errorMessage, out string responseText)
        {
            try
            {
                errorMessage = "";

                responseText = "";

                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(requesturl);

                webRequest.Timeout = timeOut;

                HttpWebResponse webResponse = null;

                webResponse = (HttpWebResponse)webRequest.GetResponse();


                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.Default);

                    responseText = sr.ReadToEnd();

                    bool result = responseText.Trim().ToLower().Equals(okMessage);

                    if (!result)
                    {
                        errorMessage = responseText;
                    }

                    return result;
                }

                errorMessage = "web error Status:" + webResponse.StatusCode.ToString();

                return false;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                responseText = e.Message;
                return false;
            }
        }
    }
}
