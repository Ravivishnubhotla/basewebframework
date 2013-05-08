using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Common.Logging;

namespace SPS.Bussiness.HttpUtils
{
    public class UrlPatchSender
    {

        private static ILog logger = LogManager.GetLogger(typeof(UrlPatchSender));


        public const int MinSendTreadCount = 10;
        public UrlPatchSendSetting SendSetting { get; set; }
        public List<UrlSendTask> SendUrlSendTasks { get; set; }
        public int TotalSendCount { get; set; }
        public int HasProcessCount { get; set; }
        public int HasProcessSuccess { get; set; }

        private int MaxSendTreadCount = 10;


        // 创建一个委托，返回类型为void，两个参数
        public delegate void UrlSendedHandler(object sender, UrlSendEventArgs e);
        // 将创建的委托和特定事件关联,在这里特定的事件为KeyDown
        public event UrlSendedHandler UrlSended;

        public void FireUrlSended(object sender, UrlSendEventArgs e)
        {
            if (UrlSended != null)
            {
                UrlSended(this, e);
            }
        }

        private UrlPatchSender()
        {

        }

        public UrlPatchSender(UrlPatchSendSetting _sendSetting, List<UrlSendTask> _sendUrlSendTasks)
        {
            MaxSendTreadCount = Math.Max(_sendSetting.SendThreadCount, MinSendTreadCount);

            TotalSendCount = _sendUrlSendTasks.Count;
        }


        public void Send()
        {
            SortedList<string,List<UrlSendTask>> hostSendUrls = new SortedList<string, List<UrlSendTask>>();

            foreach (UrlSendTask sendUrlSendTask in SendUrlSendTasks)
            {
                sendUrlSendTask.Host = sendUrlSendTask.GetHost();
                if (!hostSendUrls.ContainsKey(sendUrlSendTask.Host))
                {
                    hostSendUrls.Add(sendUrlSendTask.Host,new List<UrlSendTask>());
                }
                hostSendUrls[sendUrlSendTask.Host].Add(sendUrlSendTask);
            }

            ThreadPool.SetMinThreads(MinSendTreadCount, MinSendTreadCount);

            ThreadPool.SetMaxThreads(MaxSendTreadCount, MaxSendTreadCount);

            foreach (KeyValuePair<string, List<UrlSendTask>> hostSendTasks in hostSendUrls)
            {
                ThreadPool.QueueUserWorkItem(SendAction, hostSendTasks);

                Thread.Sleep(10000);
            }
        }

        private void SendAction(object request)
        {
            KeyValuePair<string, List<UrlSendTask>> sendTask = (KeyValuePair<string, List<UrlSendTask>>)request;

            logger.Info("批量发送“" + sendTask.Key + "”请求开始");

            try
            {
                int i = 0;

                int titalCOunt = sendTask.Value.Count;

                foreach (UrlSendTask urlSendTask in sendTask.Value)
                {
                    try
                    {
                        int retryTimes = 0;

                        bool requestOk = false;

                        do
                        {

                            string errorMessage = string.Empty;

                            requestOk = SendTask(urlSendTask, out errorMessage);

                            if (!requestOk)
                            {
                                //FireUrlSendedFailedToReTry();

                                Thread.Sleep(SendSetting.SendInterval);
                            }

                            retryTimes++;

                            if (retryTimes >= SendSetting.RetryTimes)
                                break;

                        } while (!requestOk);

                        //FireUrlSendedSuccess();
                    }
                    catch (Exception ex)
                    {
                        //FireUrlSendedFailedToSkip();
                    }


                    FireUrlSended(this, new UrlSendEventArgs(urlSendTask));
                }
            }
            catch (Exception ex)
            {
                //FireHostUrlSendedFailed();
            }
 
        }

        private bool SendTask(UrlSendTask sendUrlTask,out string errorMessage)
        {
            throw new NotImplementedException();
        }


        private static bool SendRequest(string requesturl, int timeOut, string okMessage, string repeatLinkIDCode, out string errorMessage)
        {
            try
            {
                errorMessage = "";

                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(requesturl);

                webRequest.Timeout = timeOut;

                HttpWebResponse webResponse = null;

                webResponse = (HttpWebResponse)webRequest.GetResponse();


                if (webResponse.StatusCode == HttpStatusCode.OK)
                {

                    StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.Default);

                    string responseText = sr.ReadToEnd();

                    List<string> repeatCode = new List<string>();

                    repeatCode.AddRange(repeatLinkIDCode.Split(("|").ToCharArray()));

                    bool result = responseText.Trim().ToLower().Equals(okMessage) || repeatCode.Contains(responseText.Trim());

                    if (!result)
                        errorMessage = responseText;

                    return result;
                }


                errorMessage = "页面响应失败:" + webResponse.StatusCode.ToString();

                return false;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return false;
            }
        }
    }
}
