using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Common.Logging;
using SPS.Bussiness.ConstClass;
using SPS.Bussiness.HttpUtils;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.AppCode
{
    public class SPSDataRecievedHandler : IHttpHandler
    {
        protected static ILog logger = LogManager.GetLogger(typeof(SPSDataRecievedHandler));

 

        public void ProcessRequest(HttpContext context)
        {
                try
                {
                    HttpRequestLog httpRequestLog = new HttpRequestLog(context.Request);

                    //检测是否存在ashx
                    if (string.IsNullOrEmpty(httpRequestLog.DataAdaptorUrl))
                    {
                        LogWarnInfo(httpRequestLog, "请求失败：没有指定ashx路径。\n", 0, 0);

                        return;
                    }

                    SPChannelWrapper channel = SPChannelWrapper.GetChannelByDataAdaptorUrl(httpRequestLog.DataAdaptorUrl);

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
                    if (channel.IsMonitorRequest.HasValue && channel.IsMonitorRequest.Value)
                    {
                        SPMonitoringRequestWrapper.SaveRequest(httpRequestLog, channel);
                    }

                    //初始化参数，包含添加固定参数逻辑
                    if (channel.NeedInitParams)
                    {
                        channel.InitParams(httpRequestLog);
                    }

                    //过滤请求
                    if(channel.HasFilters.HasValue && channel.HasFilters.Value)
                    {
                        if (channel.CheckRequestIsFilters(httpRequestLog))
                        {
                            LogWarnInfo(httpRequestLog, "请求失败：\n" + "通道“" + channel.Name + "”属于过滤请求。\n", channel.Id, 0);

                            context.Response.Write(channel.GetFailedCode(httpRequestLog));
                        }
                    }

                    //参数转换
                    if (channel.IsParamsConvert.HasValue && channel.IsParamsConvert.Value)
                    {
                        channel.ParamsConvert(httpRequestLog);
                    }

                    RequestType requestType = channel.GetRequestType(httpRequestLog);

                    RequestErrorType requestError = RequestErrorType.NoError;

                    string errorMessage = "";

                    bool requestOK = false;

                    if(requestType==RequestType.DataReport)
                    {
                        requestOK = channel.ProcessRequest(httpRequestLog, out requestError, out errorMessage);
                    }
                    else if (requestType == RequestType.StatusReport)
                    {
                        requestOK = channel.ProcessStatusReport(httpRequestLog, out requestError, out errorMessage);
                    }
                    else if (requestType == RequestType.DataStatusReport)
                    {
                        requestOK = channel.ProcessDataStatusReport(httpRequestLog, out requestError, out errorMessage);
                    }

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
                    HttpRequestLog failRequest = new HttpRequestLog(context.Request);
 

                    string errorMessage = "处理请求失败:\n错误信息：" + ex.Message;

                    logger.Error(errorMessage + "\n请求信息:\n" + failRequest.RequestData, ex);

 
                }
                catch (Exception e)
                {
                    logger.Error("处理请求失败:\n错误信息：" + e.Message);
                }
            }
        }

        private void LogWarnInfo(HttpRequestLog httpRequestLog, string errorInfo, int channelID, int clientID)
        {
            logger.Warn(errorInfo + "\n请求信息：\n" + httpRequestLog.RequestData);

 
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
