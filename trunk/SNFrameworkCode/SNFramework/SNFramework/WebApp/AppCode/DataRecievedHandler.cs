using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Logging;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using SPS.Bussiness.DataAdapter;
using SPS.Bussiness.HttpUtils;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.AppCode
{
    public abstract class DataRecievedHandler : IHttpHandler
    {
        protected static ILog logger = LogManager.GetLogger(typeof(SPSDataRecievedHandler));

        protected abstract void PreProcessRequest(IDataAdapter httpRequestLog);

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                IDataAdapter httpRequestLog = GetHttpRequestLog(context);

                //检测是否存在ashx
                if (string.IsNullOrEmpty(httpRequestLog.RequestFileName))
                {
                    LogWarnInfo(httpRequestLog, "请求失败：没有指定ashx路径。\n", 0, 0);

                    return;
                }

                string dataAdaptorUrl = httpRequestLog.GetChannelCode();

                SPChannelWrapper channel = SPChannelWrapper.GetChannelByDataAdaptorUrl(dataAdaptorUrl);

                //如果没有找到通道
                if (channel == null)
                {
                    LogWarnInfo(httpRequestLog, "处理请求失败：无法找到对应的通道。\n", 0, 0);

                    return;
                }

                //如果通道未能运行
                if (channel.ChannelStatus != DictionaryConst.Dictionary_ChannelStatus_Run_Key)
                {
                    LogWarnInfo(httpRequestLog, "请求失败：\n" + "通道“" + channel.Name + "”未运行。\n", channel.Id, 0);

                    context.Response.Write(channel.GetFailedCode(httpRequestLog));

                    return;
                }

                //如果通道是监视通道，记录请求。
                if (channel.IsMonitorRequest)
                {
                    SPMonitoringRequestWrapper.SaveRequest(httpRequestLog, channel);
                }

                //过滤请求
                if (channel.HasFilters)
                {
                    if (channel.CheckRequestIsFilters(httpRequestLog))
                    {
                        LogWarnInfo(httpRequestLog, "请求失败：\n" + "通道“" + channel.Name + "”属于过滤请求。\n", channel.Id, 0);

                        context.Response.Write(channel.GetFailedCode(httpRequestLog));
                    }
                }

                //参数转换
                if (channel.IsParamsConvert)
                {
                    channel.ParamsConvert(httpRequestLog);
                }

                PreProcessRequest(httpRequestLog);

                bool requestOK;
                string errorMessage;

                RequestErrorType requestError = RecievedRequest(httpRequestLog, channel, out requestOK, out errorMessage);

                //正确数据返回OK
                if (requestOK)
                {
                    context.Response.Write(channel.GetOkCode(httpRequestLog));
                    return;
                }

                //重复数据返回OK
                if (requestError == RequestErrorType.RepeatLinkID)
                {
                    logger.Warn(errorMessage);
                    context.Response.Write(channel.GetOkCode(httpRequestLog));
                    return;
                }

                //其他错误类型记录错误请求
                LogWarnInfo(httpRequestLog, errorMessage, channel.Id, 0);

                context.Response.Write(channel.GetFailedCode(httpRequestLog));

                return;
            }
            catch (Exception ex)
            {
                try
                {
                    IDataAdapter failRequest = GetHttpRequestLog(context);


                    string errorMessage = "处理请求失败:\n错误信息：" + ex.Message;

                    logger.Error(errorMessage + "\n请求信息:\n" + failRequest.RequestData, ex);


                }
                catch (Exception e)
                {
                    logger.Error("处理请求失败:\n错误信息：" + e.Message);
                }
            }
        }

        protected abstract RequestErrorType RecievedRequest(IDataAdapter httpRequestLog, SPChannelWrapper channel,
                                                        out bool requestOK, out string errorMessage);

        protected void LogWarnInfo(IDataAdapter httpRequestLog, string errorInfo, int channelID, int clientID)
        {
            logger.Warn(errorInfo + "\n请求信息：\n" + httpRequestLog.RequestData);
        }

        protected static HttpGetPostAdapter GetHttpRequestLog(HttpContext context)
        {
            return new HttpGetPostAdapter(context.Request);
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