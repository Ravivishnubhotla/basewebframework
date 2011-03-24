﻿using System;
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
    public class SPXmlHandler : IHttpHandler
    {
        protected static ILog logger = LogManager.GetLogger(typeof(SPXmlHandler));

        private string xmlString = string.Empty;

        private bool saveLogFailedRequestToDb = false;

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                xmlString = HttpXmlPostRequest.GetXmlPostValueFromRequest(context.Request);

                //logger.Error(xmlString);

                IHttpRequest httpRequest = new HttpXmlPostRequest(context.Request, xmlString);

                //检测是否存在ashx
                if (string.IsNullOrEmpty(httpRequest.RequestFileName))
                {
                    LogWarnInfo(httpRequest, "请求失败：没有指定ashx路径。\n", 0, 0);

                    return;
                }

                SPChannelWrapper channel = SPChannelWrapper.GetChannelByPath(httpRequest.GetChannelCode());

                //如果没有找到通道
                if (channel == null)
                {
                    LogWarnInfo(httpRequest, "处理请求失败：无法找到对应的通道。\n", 0, 0);

                    return;
                }

                saveLogFailedRequestToDb = channel.LogFailedRequestToDb;

                //如果通道未能运行
                if (channel.CStatus != ChannelStatus.Run)
                {
                    LogWarnInfo(httpRequest, "请求失败：\n" + "通道“" + channel.Name + "”未运行。\n", channel.Id, 0);

                    context.Response.Write(channel.GetFailedCode(httpRequest));

                    return;
                }
                //如果通道是监视通道，记录请求。
                if (channel.IsMonitoringRequest.HasValue && channel.IsMonitoringRequest.Value)
                {
                    SPMonitoringRequestWrapper.SaveRequest(httpRequest, channel.Id);
                }
                //如果状态报告通道
                if (channel.RecStatReport.HasValue && channel.RecStatReport.Value)
                {
                    RequestError requestError1 = new RequestError();

                    bool result1 = false;

                    if (channel.HasRequestTypeParams.HasValue && channel.HasRequestTypeParams.Value)
                    {
                        //报告状态请求
                        if (httpRequest.IsRequestContainValues(channel.RequestTypeParamName, channel.RequestReportTypeValue))
                        {
                            if (httpRequest.IsRequestContainValues(channel.StatParamsName, channel.StatParamsValues))
                            {
                                result1 = channel.RecState(httpRequest, httpRequest.RequestParams[channel.StatParamsName.ToLower()].ToString(), out requestError1);
                            }
                            else
                            {
                                channel.SaveStatReport(httpRequest, httpRequest.RequestParams[channel.StatParamsName.ToLower()].ToString());

                                context.Response.Write(channel.GetOkCode(httpRequest));

                                return;
                            }
                        }
                        //发送数据请求
                        else if (httpRequest.IsRequestContainValues(channel.RequestTypeParamName, channel.RequestDataTypeValue))
                        {
                            result1 = channel.ProcessStateRequest(httpRequest, out requestError1);
                        }
                        else
                        {
                            LogWarnInfo(httpRequest, "未知类型请求", channel.Id, 0);

                            context.Response.Write(channel.GetFailedCode(httpRequest));

                            return;
                        }
                    }
                    else
                    {
                        if (httpRequest.RequestParams.ContainsKey(channel.StatParamsName.ToLower()))
                        {
                            if (httpRequest.IsRequestContainValues(channel.StatParamsName, channel.StatParamsValues))
                            {
                                if (channel.StatSendOnce.HasValue && channel.StatSendOnce.Value)
                                {
                                    result1 = channel.ProcessRequest(httpRequest, out requestError1);
                                }
                                else
                                {
                                    result1 = channel.RecState(httpRequest, httpRequest.RequestParams[channel.StatParamsName.ToLower()].ToString(), out requestError1);
                                }
                            }
                            else
                            {
                                channel.SaveStatReport(httpRequest, httpRequest.RequestParams[channel.StatParamsName.ToLower()].ToString());

                                context.Response.Write(channel.GetOkCode(httpRequest));

                                return;
                            }
                        }
                        else
                        {
                            result1 = channel.ProcessStateRequest(httpRequest, out requestError1);
                        }
                    }

                    //正确数据返回OK
                    if (result1)
                    {
                        context.Response.Write(channel.GetOkCode(httpRequest));
                        return;
                    }



                    //重复数据返回OK
                    if (requestError1.ErrorType == RequestErrorType.RepeatLinkID)
                    {
                        logger.Warn(requestError1.ErrorMessage);
                        context.Response.Write(channel.GetOkCode(httpRequest));
                        return;
                    }

                    //其他错误类型记录错误请求
                    LogWarnInfo(httpRequest, requestError1.ErrorMessage, channel.Id, 0);

                    context.Response.Write(channel.GetFailedCode(httpRequest));

                    return;

                }

                RequestError requestError;

                bool result = channel.ProcessRequest(httpRequest, out requestError);

                if (result)
                {
                    context.Response.Write(channel.GetOkCode(httpRequest));

                    return;
                }

                //重复数据返回OK
                if (requestError.ErrorType == RequestErrorType.RepeatLinkID)
                {
                    logger.Warn(requestError.ErrorMessage);
                    context.Response.Write(channel.GetOkCode(httpRequest));
                    return;
                }

                LogWarnInfo(httpRequest, requestError.ErrorMessage, channel.Id, 0);

                context.Response.Write(channel.GetFailedCode(httpRequest));

            }
            catch (Exception ex)
            {
                try
                {
                    IHttpRequest failRequest = new HttpXmlPostRequest(context.Request, xmlString);

                    string errorMessage = "处理请求失败:\n错误信息：" + ex.Message ;

                    logger.Error(errorMessage + "\n请求信息:\n" + failRequest.RequestData, ex);
                    if (saveLogFailedRequestToDb)
                        SPFailedRequestWrapper.SaveFailedRequest(failRequest, errorMessage, 0, 0);
                }
                catch (Exception e)
                {
                    logger.Error("处理请求失败:\n错误信息：" + e.Message + xmlString);
                }
            }
        }

        private void LogWarnInfo(IHttpRequest httpRequest, string errorInfo, int channelID, int clientID)
        {
            logger.Warn(errorInfo + "请求信息：\n" + httpRequest.RequestData);

            if (saveLogFailedRequestToDb)
                SPFailedRequestWrapper.SaveFailedRequest(httpRequest, errorInfo, channelID, clientID);
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
