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
        public ChannelSendSettings SendSetting { get; set; }
        public string OkMessage { get; set; }
        public int TimeOut { get; set; }
        public int SendInterval { get; set; }
        public int RetryTimes { get; set; }
        public List<HttpGetSenderTaskItem> SendDataItems { get; set; }

        public HttpGetSenderTask(ChannelSendSettings sendSetting, string okMessage, int timeOut, int sendInterval, int retryTimes, int RandomSendCounts)
        {
            SendSetting = sendSetting;
            OkMessage = okMessage;
            TimeOut = timeOut;
            SendInterval = sendInterval;
            RetryTimes = retryTimes;

            this.SendDataItems = new List<HttpGetSenderTaskItem>();

            for (int i = 0; i < RandomSendCounts; i++)
            {
                string sendUrl = sendSetting.DataUrl;

                foreach (DictionaryEntry templateSendUrlParamItem in sendSetting.DataUrlParams)
                {
                    if (templateSendUrlParamItem.Key.ToString().StartsWith(ChannelSendSettings.ParamsPrefix + "N"))
                    {
                        sendUrl = sendUrl.Replace(templateSendUrlParamItem.Key.ToString(), NumberGenerator.GetRandNumber((int)templateSendUrlParamItem.Value));
                    }
                }
 
                HttpGetSenderTaskItem httpGetSenderTaskItem = new HttpGetSenderTaskItem(sendUrl, OkMessage);
                httpGetSenderTaskItem.TimeOut = TimeOut;
                httpGetSenderTaskItem.TaskIndex = i;
                this.SendDataItems.Add(httpGetSenderTaskItem);         
            }

 
        }
    }
}
