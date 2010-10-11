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
                Hashtable requestData = GetRequestValue(context);

                string recievdData = JsonConvert.SerializeObject(requestData);

                string fileName = Path.GetFileNameWithoutExtension(context.Request.PhysicalPath);

                if (string.IsNullOrEmpty(fileName))
                {
                    logger.Error("请求失败：没有指定ashx路径。\n" + "请求信息：\n" + GetRequestInfo(context.Request));

                    SPFailedRequestWrapper.SaveFailedRequest(context.Request, GetRealIP(), recievdData, "请求失败：没有指定ashx路径。\n", 0, 0);

                    return;
                }

                fileName = fileName.Substring(0, fileName.Length - ("Recieved").Length);


                SPChannelWrapper channel = SPChannelWrapper.GetChannelByPath(fileName);

                if (channel != null)
                {
                    if (channel.CStatus != ChannelStatus.Run)
                    {
                        logger.Error("请求失败：\n" + "通道“" + channel.Name + "”未运行。\n请求信息：\n" + GetRequestInfo(context.Request));
                        SPFailedRequestWrapper.SaveFailedRequest(context.Request, GetRealIP(), recievdData, "请求失败：\n" + "通道“" + channel.Name + "”未运行。\n请求信息：\n", channel.Id, 0);
                        return;
                    }

                    if (channel.RecStatReport.HasValue && channel.RecStatReport.Value)
                    {

                        RequestError requestError1 = new RequestError();

                        bool result1 = false;

                        if (channel.HasRequestTypeParams.HasValue && channel.HasRequestTypeParams.Value)
                        {
                            //报告状态请求
                            if(IsRequestContainValues(requestData,channel.RequestTypeParamName,channel.RequestReportTypeValue))
                            {
                                if (IsRequestContainValues(requestData, channel.StatParamsName, channel.StatParamsValues))
                                {
                                    result1 = channel.RecState(GetRequestValue(context), recievdData, context.Request.Url.Query, requestData[channel.StatParamsName.ToLower()].ToString(), out requestError1);
                                }
                                else
                                {
                                    channel.SaveStatReport(requestData, recievdData, context.Request.Url.Query, requestData[channel.StatParamsName.ToLower()].ToString());

                                    context.Response.Write(channel.GetOkCode());

                                    return;
                                }
                            }
                            //发送数据请求
                            else if (IsRequestContainValues(requestData, channel.RequestTypeParamName, channel.RequestDataTypeValue))
                            {
                                result1 = channel.ProcessStateRequest(GetRequestValue(context), GetRealIP(), recievdData, context.Request, out requestError1);
                            }
                            else
                            {
                                SPFailedRequestWrapper.SaveFailedRequest(context.Request, GetRealIP(), recievdData, "未知类型请求", channel.Id, 0);

                                logger.Error("未知类型请求:" + GetRequestInfo(context.Request));

                                return;                                                        
                            }
                        }
                        else
                        {
                            if (requestData.ContainsKey(channel.StatParamsName.ToLower()))
                            {
                                if (IsRequestContainValues(requestData, channel.StatParamsName, channel.StatParamsValues))
                                {
                                    result1 = channel.RecState(GetRequestValue(context), recievdData, context.Request.Url.Query, requestData[channel.StatParamsName.ToLower()].ToString(), out requestError1);
                                }
                                else
                                {
                                    channel.SaveStatReport(requestData, recievdData, context.Request.Url.Query, requestData[channel.StatParamsName.ToLower()].ToString());
                                    
                                    context.Response.Write(channel.GetOkCode());

                                    return;                      
                                }
                            }
                            else
                            {
                                result1 = channel.ProcessStateRequest(GetRequestValue(context), GetRealIP(), recievdData, context.Request, out requestError1);
                            }                            
                        }

                        if (result1)
                        {
                            context.Response.Write(channel.GetOkCode());
                            return;
                        }
                        else
                        {
                            logger.Error(requestError1.ErrorMessage);

                            SPFailedRequestWrapper.SaveFailedRequest(context.Request, GetRealIP(), recievdData, requestError1.ErrorMessage, channel.Id, 0);
                            return;
                        }
                    }



                    RequestError requestError;

                    bool result = channel.ProcessRequest(GetRequestValue(context), GetRealIP(), recievdData, context.Request, out requestError);

                    if (result)
                        context.Response.Write(channel.GetOkCode());
                    else
                    {
                        logger.Error(requestError.ErrorMessage);

                        SPFailedRequestWrapper.SaveFailedRequest(context.Request, GetRealIP(), recievdData, requestError.ErrorMessage, channel.Id, 0);
                    }
                }
                else
                {
                    logger.Error("处理请求失败：无法找到对应的通道。\n" + "请求信息：\n" + GetRequestInfo(context.Request));
                    SPFailedRequestWrapper.SaveFailedRequest(context.Request, GetRealIP(), recievdData, "处理请求失败：无法找到对应的通道。\n", 0, 0);
                }
            }
            catch (Exception ex)
            {
                logger.Error("处理请求失败:\n" + "请求信息:\n" + GetRequestInfo(context.Request), ex);

                try
                {
                    Hashtable recivedata = GetRequestValue(context);

                    string recievdData = JsonConvert.SerializeObject(recivedata);

                    SPFailedRequestWrapper.SaveFailedRequest(context.Request, GetRealIP(), recievdData, "处理请求失败：" + ex.Message + "\n", 0, 0);
                }
                catch (Exception e)
                {
                    logger.Error("失败请求保存失败.\n" + "请求信息系:\n" + GetRequestInfo(context.Request));
                    SPFailedRequestWrapper.SaveFailedRequest(context.Request, GetRealIP(), GetRequestInfo(context.Request), "请求错误:" + ex.Message + "\n", 0, 0);
                }

                return;
            }
        }


        private bool IsRequestContainValues(Hashtable requestData, string fieldName,string value)
        {
            return requestData.ContainsKey(fieldName.ToLower()) && requestData[fieldName.ToLower()].ToString().ToLower().Trim().Contains(value.ToLower().Trim());
        }

        private string GetRequestInfo(HttpRequest request)
        {
            Hashtable hb = new Hashtable();

            foreach (string key in request.Params.Keys)
            {
                if (!string.IsNullOrEmpty(key))
                    hb.Add(key.ToLower(), request.Params[key.ToLower()]);
            }

            return JsonConvert.SerializeObject(hb);
        }





        public static string GetRealIP()
        {
            string ip = string.Empty;
            try
            {
                if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                {
                    ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Split(',')[0].Trim();
                }
                else
                {
                    ip = HttpContext.Current.Request.UserHostAddress;
                }
            }
            catch (Exception ex)
            {
                logger.Error("获取IP错误:", ex);
            }
            return ip;
        }



        private Hashtable GetRequestValue(HttpContext requestContext)
        {
            Hashtable hb = new Hashtable();

            foreach (string key in requestContext.Request.Params.Keys)
            {
                hb.Add(key.ToLower(), requestContext.Request.Params[key.ToLower()]);
            }

            return hb;
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
