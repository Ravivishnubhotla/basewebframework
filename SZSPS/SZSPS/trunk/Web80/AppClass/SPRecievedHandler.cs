﻿using System;
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

        private bool saveLogFailedRequestToDb = false;

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                IHttpRequest httpRequest = new HttpGetPostRequest(context.Request);

                //context.Request.s

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


                if (channel.Id == 88)
                {
                    if (httpRequest.RequestParams.ContainsKey("command"))
                    {
                        if (httpRequest.RequestParams["command"].ToString().ToLower().Equals("z6"))
                        {
                            httpRequest.RequestParams["command"] = " 6";
                        }
                    }
                    if (httpRequest.RequestParams.ContainsKey("command"))
                    {
                        if (httpRequest.RequestParams["command"].ToString().ToLower().Equals("71") && httpRequest.RequestParams["sp_no"].ToString().ToLower().Equals("1066885031"))
                        {
                            httpRequest.RequestParams["command"] = "7";
                        }
                    }
                }
                if (channel.Id == 66)
                {
                    if (httpRequest.RequestParams.ContainsKey("spnumber")&&httpRequest.RequestParams.ContainsKey("momsg"))
                    {
                        if (httpRequest.RequestParams["momsg"].ToString().ToLower().StartsWith("8dm") && httpRequest.RequestParams["spnumber"].ToString().ToLower().Equals("106268001"))
                        {
                            httpRequest.RequestParams["spnumber"] = "106268000";
                        }
                    }
                }


                if (channel.FuzzyCommand.Trim().ToLower().Equals("quantt"))
                {
                    if (httpRequest.RequestParams.ContainsKey("reportcode"))
                    {
                        if (!string.IsNullOrEmpty(httpRequest.RequestParams["reportcode"].ToString()))
                        {
                            httpRequest.RequestParams.Add("status", httpRequest.RequestParams["reportcode"].ToString().Substring(0, 1));
                            httpRequest.RequestParams.Add("msg", httpRequest.RequestParams["reportcode"].ToString().Substring(1, httpRequest.RequestParams["reportcode"].ToString().Length - 1));
                        }
                    }
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

                    //分类型请求
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
                    IHttpRequest failRequest = new HttpGetPostRequest(context.Request);

                    string errorMessage = "处理请求失败:\n错误信息：" + ex.Message ;

                    logger.Error(errorMessage + "\n请求信息:\n" + failRequest.RequestData, ex);

                    if (saveLogFailedRequestToDb)
                        SPFailedRequestWrapper.SaveFailedRequest(failRequest, errorMessage, 0, 0);
                }
                catch (Exception e)
                {
                    logger.Error("处理请求失败:\n错误信息：" + e.Message);
                }
            }
        }

        private void LogWarnInfo(IHttpRequest httpRequest, string errorInfo, int channelID, int clientID)
        {
            logger.Warn(errorInfo + "请求信息：\n" + httpRequest.RequestData);

            if (saveLogFailedRequestToDb)
                SPFailedRequestWrapper.SaveFailedRequest(httpRequest, errorInfo, channelID, clientID);
        }

        public static MethodDelegate GetMethodDelegateFromRecName(string fileName, HttpContext context)
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
