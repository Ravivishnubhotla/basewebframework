﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
        public List<HttpGetSenderTaskItem> SendReportItems { get; set; }

        public HttpGetSenderTask(ChannelSendSettings sendSetting, string okMessage, int timeOut, int sendInterval, int retryTimes, int RandomSendCounts)
        {
            SendSetting = sendSetting;
            OkMessage = okMessage;
            TimeOut = timeOut;
            SendInterval = sendInterval;
            RetryTimes = retryTimes;

            this.SendDataItems = new List<HttpGetSenderTaskItem>();
            this.SendReportItems = new List<HttpGetSenderTaskItem>();

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

                if(this.SendSetting.SendTwice())
                {
                    string reportUrl = sendSetting.ReportUrl;

                    foreach (DictionaryEntry templateReportUrlParamItem in sendSetting.ReportUrlParams)
                    {
                        if (templateReportUrlParamItem.Key.ToString().StartsWith(ChannelSendSettings.ParamsPrefix + "N"))
                        {
                            sendUrl = sendUrl.Replace(templateReportUrlParamItem.Key.ToString(), NumberGenerator.GetRandNumber((int)templateReportUrlParamItem.Value));
                        }
                    }

                    HttpGetSenderTaskItem httpGetReportSenderTaskItem = new HttpGetSenderTaskItem(reportUrl, OkMessage);
                    httpGetSenderTaskItem.TimeOut = TimeOut;
                    httpGetSenderTaskItem.TaskIndex = i;
                    this.SendReportItems.Add(httpGetReportSenderTaskItem);
                }




            }




 
        }

        public HttpGetSenderTask(List<string> alllinks,string okMessage)
        {
            OkMessage = okMessage;
            TimeOut = 10000;
            SendInterval = 10;
            RetryTimes = 2;

            this.SendDataItems = new List<HttpGetSenderTaskItem>();

            for (int i = 0; i < alllinks.Count; i++)
            {
                HttpGetSenderTaskItem httpGetSenderTaskItem = new HttpGetSenderTaskItem(alllinks[i], OkMessage);
                httpGetSenderTaskItem.TimeOut = TimeOut;
                httpGetSenderTaskItem.TaskIndex = i;
                this.SendDataItems.Add(httpGetSenderTaskItem);
            }
        }

        public HttpGetSenderTask(ChannelSendSettings sendSetting, string okMessage, int timeOut, int sendInterval, int retryTimes,DataTable table)
        {
            SendSetting = sendSetting;
            OkMessage = okMessage;
            TimeOut = timeOut;
            SendInterval = sendInterval;
            RetryTimes = retryTimes;

            this.SendDataItems = new List<HttpGetSenderTaskItem>();
            this.SendReportItems = new List<HttpGetSenderTaskItem>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                string sendUrl = sendSetting.DataUrl;

                foreach (KeyValuePair<string, string> templateSendUrlParamItem in sendSetting.GetDataParamNames())
                {
                    sendUrl = sendUrl.Replace(templateSendUrlParamItem.Key, table.Rows[i][templateSendUrlParamItem.Value].ToString());
                }
 
                HttpGetSenderTaskItem httpGetSenderTaskItem = new HttpGetSenderTaskItem(sendUrl, OkMessage);
                httpGetSenderTaskItem.TimeOut = TimeOut;
                httpGetSenderTaskItem.TaskIndex = i;
                this.SendDataItems.Add(httpGetSenderTaskItem);

                if(this.SendSetting.SendTwice())
                {
                    string reportUrl = sendSetting.ReportUrl;

                    foreach (KeyValuePair<string, string> templateReportUrlParamItem in sendSetting.GetReportParamNames())
                    {
                        sendUrl = sendUrl.Replace(templateReportUrlParamItem.Key, table.Rows[i][templateReportUrlParamItem.Value].ToString());
                    }

                    HttpGetSenderTaskItem httpGetReportSenderTaskItem = new HttpGetSenderTaskItem(reportUrl, OkMessage);
                    httpGetSenderTaskItem.TimeOut = TimeOut;
                    httpGetSenderTaskItem.TaskIndex = i;
                    this.SendReportItems.Add(httpGetReportSenderTaskItem);
                }




            }
        }
    }
}
