using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SPSUtil.AppCode
{
    public class HttpGetSenderTask
    {
        public string TemplateSendUrl { get; set; }
        public string OkMessage { get; set; }
        public int TimeOut { get; set; }
        public int SendInterval { get; set; }
        public int RetryTimes { get; set; }
        public Hashtable TemplateSendUrlParams { get; set; }
        public List<HttpGetSenderTaskItem> SendItems { get; set; }

        public HttpGetSenderTask(string templateSendUrl, string okMessage, int timeOut, int sendInterval, int retryTimes,int RandomSendCounts)
        {
            TemplateSendUrl = templateSendUrl;
            OkMessage = okMessage;
            TimeOut = timeOut;
            SendInterval = sendInterval;
            RetryTimes = retryTimes;
            TemplateSendUrlParams = new Hashtable();

            Regex regex = new Regex(@"(?<={\$).*?(?=})");

            MatchCollection mc = regex.Matches(TemplateSendUrl);

            foreach (Match match in mc)
            {
                if(!TemplateSendUrlParams.Contains("{$" + match.Value + "}"))
                {
                    TemplateSendUrlParams.Add("{$" + match.Value + "}",Convert.ToInt32(match.Value.Substring(1,match.Value.Length-1)));
                }
            }

            this.SendItems = new List<HttpGetSenderTaskItem>();

            for (int i = 0; i < RandomSendCounts; i++)
            {
                string sendUrl = TemplateSendUrl;

                foreach (DictionaryEntry templateSendUrlParamItem in TemplateSendUrlParams)
                {
                    if(templateSendUrlParamItem.Key.ToString().StartsWith("{$N"))
                    {
                        sendUrl = sendUrl.Replace(templateSendUrlParamItem.Key.ToString(), NumberGenerator.GetRandNumber((int)templateSendUrlParamItem.Value));
                    }
                }
 
                HttpGetSenderTaskItem httpGetSenderTaskItem = new HttpGetSenderTaskItem(sendUrl, OkMessage);
                httpGetSenderTaskItem.TimeOut = TimeOut;
                httpGetSenderTaskItem.TaskIndex = i;
                this.SendItems.Add(httpGetSenderTaskItem);         
            }

 
        }
    }
}
