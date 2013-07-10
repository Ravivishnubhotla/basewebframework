using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Caching;
using CSScriptLibrary;
using Common.Logging;
using LD.SPPipeManage.Bussiness.Commons;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.AppClass
{
    public abstract class SPXmlRecievedHandler : IHttpHandler
    {
        protected static ILog logger = LogManager.GetLogger(typeof(SPXmlRecievedHandler));

        private string xmlString = string.Empty;

        protected abstract string GetXmlNodeName();

        protected abstract string GetChannelCodeName(HttpContext context);

        private bool saveLogFailedRequestToDb = false;

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                xmlString = HttpXmlPostRequest.GetXmlPostValueFromRequest(context.Request);

                //logger.Error(xmlString);

                IHttpRequest httpRequest = new HttpXmlPostRequest(context.Request, xmlString, GetXmlNodeName());

                //检测是否存在ashx
                if (string.IsNullOrEmpty(httpRequest.RequestFileName))
                {
                    LogWarnInfo(httpRequest, "请求失败：没有指定ashx路径。\n", 0, 0);

                    return;
                }

                SPChannelWrapper channel = SPChannelWrapper.GetChannelByPath(GetChannelCodeName(context));

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

                if (channel.HasConvertRule.HasValue && channel.HasConvertRule.Value)
                {
                    try
                    {
                        PreProcessRequest(httpRequest.RequestParams, context, channel.FuzzyCommand);
                    }
                    catch (Exception ex)
                    {
                        LogWarnInfo(httpRequest, "数据转换错误：" + ex.Message, channel.Id, 0);
                    }
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
                                //channel.SaveStatReport(httpRequest, httpRequest.RequestParams[channel.StatParamsName.ToLower()].ToString());

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
                                //channel.SaveStatReport(httpRequest, httpRequest.RequestParams[channel.StatParamsName.ToLower()].ToString());

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
                    IHttpRequest failRequest = new HttpXmlPostRequest(context.Request, xmlString, GetXmlNodeName());

                    string errorMessage = "处理请求失败:\n错误信息：" + ex.Message;

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

        private static MethodDelegate GetMethodDelegateFromRecName(string fileName, HttpContext context)
        {
            string codeText = File.ReadAllText(fileName);

            Assembly assembly = CSScript.LoadCode(codeText);

            return new AsmHelper(assembly).GetStaticMethod();
        }


        public const string spsRules = "sps_rules_";

        private static void PreProcessRequest(Hashtable requestParams, HttpContext context, string recName)
        {
            if (context.Cache[spsRules + recName] == null)
            {
                string fileName = context.Server.MapPath("~/ConvertRules/" + recName + ".txt");

                if (!File.Exists(fileName))
                    return;

                context.Cache.Insert(spsRules + recName, GetMethodDelegateFromRecName(fileName, context), new CacheDependency(fileName));
            }
            else
            {
                if (context.Cache[spsRules + recName] is MethodDelegate)
                {
                    MethodDelegate processMethod = context.Cache[spsRules + recName] as MethodDelegate;

                    if (processMethod != null)
                        processMethod(requestParams);
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