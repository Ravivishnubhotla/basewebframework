using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Common.Logging;
using LD.SPPipeManage.Bussiness.Commons;
using LD.SPPipeManage.Bussiness.Wrappers;
using Newtonsoft.Json;

namespace Legendigital.Common.Web.AppClass
{
    public enum RequestType
    {
        Normal,
        StateReport
    }

    public class SPRecievedHandler : IHttpHandler
    {
        protected static ILog logger = LogManager.GetLogger(typeof(SPRecievedHandler));

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                HttpGetPostRequest httpGetPostRequest = new HttpGetPostRequest(context.Request);

                //检测是否存在ashx
                if (string.IsNullOrEmpty(httpGetPostRequest.RequestFileName))
                {
                    LogWarnInfo(httpGetPostRequest, "请求失败：没有指定ashx路径。\n",0,0);

                    return;
                }

                SPChannelWrapper channel = SPChannelWrapper.GetChannelByPath(httpGetPostRequest.GetChannelCode());

                //如果没有找到通道
                if (channel == null)
                {
                    LogWarnInfo(httpGetPostRequest, "处理请求失败：无法找到对应的通道。\n", 0, 0);

                    return;
                }
                //如果通道未能运行
                if (channel.CStatus != ChannelStatus.Run)
                {
                    LogWarnInfo(httpGetPostRequest, "请求失败：\n" + "通道“" + channel.Name + "”未运行。\n", channel.Id, 0);

                    context.Response.Write(channel.GetFailedCode());

                    return;
                }
                //如果通道是监视通道，记录请求。
                if (channel.IsMonitoringRequest.HasValue && channel.IsMonitoringRequest.Value)
                {
                    SPMonitoringRequestWrapper.SaveRequest(httpGetPostRequest, channel.Id);
                }
                //如果状态报告通道
                if (channel.RecStatReport.HasValue && channel.RecStatReport.Value)
                {
                    RequestError requestError1 = new RequestError();

                    bool result1 = false;

                    if (channel.HasRequestTypeParams.HasValue && channel.HasRequestTypeParams.Value)
                    {
                        //报告状态请求
                        if (httpGetPostRequest.IsRequestContainValues(channel.RequestTypeParamName, channel.RequestReportTypeValue))
                        {
                            if (httpGetPostRequest.IsRequestContainValues(channel.StatParamsName, channel.StatParamsValues))
                            {
                                result1 = channel.RecState(httpGetPostRequest, httpGetPostRequest.RequestParams[channel.StatParamsName.ToLower()].ToString(), out requestError1);
                            }
                            else
                            {
                                channel.SaveStatReport(httpGetPostRequest, httpGetPostRequest.RequestParams[channel.StatParamsName.ToLower()].ToString());

                                context.Response.Write(channel.GetOkCode(context));

                                return;
                            }
                        }
                        //发送数据请求
                        else if (httpGetPostRequest.IsRequestContainValues(channel.RequestTypeParamName, channel.RequestDataTypeValue))
                        {
                            result1 = channel.ProcessStateRequest(httpGetPostRequest, out requestError1);
                        }
                        else
                        {
                            LogWarnInfo(httpGetPostRequest, "未知类型请求", channel.Id, 0);

                            context.Response.Write(channel.GetFailedCode());

                            return;
                        }
                    }
                    else
                    {
                        if (httpGetPostRequest.RequestParams.ContainsKey(channel.StatParamsName.ToLower()))
                        {
                            if (httpGetPostRequest.IsRequestContainValues(channel.StatParamsName, channel.StatParamsValues))
                            {
                                if (channel.StatSendOnce.HasValue && channel.StatSendOnce.Value)
                                {
                                    result1 = channel.ProcessRequest(httpGetPostRequest, out requestError1);
                                }
                                else
                                {
                                    result1 = channel.RecState(httpGetPostRequest, httpGetPostRequest.RequestParams[channel.StatParamsName.ToLower()].ToString(), out requestError1);
                                }
                            }
                            else
                            {
                                channel.SaveStatReport(httpGetPostRequest, httpGetPostRequest.RequestParams[channel.StatParamsName.ToLower()].ToString());

                                context.Response.Write(channel.GetOkCode(context));

                                return;
                            }
                        }
                        else
                        {
                            result1 = channel.ProcessStateRequest(httpGetPostRequest, out requestError1);
                        }
                    }

                    //正确数据返回OK
                    if (result1)
                    {
                        context.Response.Write(channel.GetOkCode(context));
                        return;
                    }

                    

                    //重复数据返回OK
                    if (requestError1.ErrorType == RequestErrorType.RepeatLinkID)
                    {
                        logger.Warn(requestError1.ErrorMessage);
                        context.Response.Write(channel.GetOkCode(context));
                        return;
                    }

                    //其他错误类型记录错误请求
                    LogWarnInfo(httpGetPostRequest, requestError1.ErrorMessage, channel.Id, 0);

                    context.Response.Write(channel.GetFailedCode());

                    return;
            
                }

                RequestError requestError;

                bool result = channel.ProcessRequest(httpGetPostRequest, out requestError);

                if (result)
                {
                    context.Response.Write(channel.GetOkCode(context));
                    
                    return;
                }

                //重复数据返回OK
                if (requestError.ErrorType == RequestErrorType.RepeatLinkID)
                {
                    logger.Warn(requestError.ErrorMessage);
                    context.Response.Write(channel.GetOkCode(context));
                    return;
                }

                LogWarnInfo(httpGetPostRequest, requestError.ErrorMessage, channel.Id, 0);

                context.Response.Write(channel.GetFailedCode());
 
            }
            catch (Exception ex)
            {
                try
                {
                    HttpGetPostRequest failRequest = new HttpGetPostRequest(context.Request);

                    string errorMessage = "处理请求失败:\n错误信息：" + ex.Message + "\n请求信息:\n" + failRequest.RequestData;

                    logger.Error(errorMessage, ex);

                    SPFailedRequestWrapper.SaveFailedRequest(failRequest, errorMessage, 0, 0);
                }
                catch (Exception e)
                {
                    logger.Error("处理请求失败:\n错误信息：" + e.Message);
                }
            }
        }

        private void LogWarnInfo(HttpGetPostRequest httpGetPostRequest,string errorInfo,int channelID,int clientID)
        {
            logger.Warn(errorInfo + "请求信息：\n" + httpGetPostRequest.RequestData);

            SPFailedRequestWrapper.SaveFailedRequest(httpGetPostRequest, errorInfo, channelID, clientID);
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
