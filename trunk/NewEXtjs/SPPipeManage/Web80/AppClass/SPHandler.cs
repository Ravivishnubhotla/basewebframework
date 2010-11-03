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
    public class SPHandler : IHttpHandler
    {
        protected static ILog logger = LogManager.GetLogger(typeof(SPHandler));


        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(context.Request.PhysicalPath);

                Hashtable recivedata = GetRequestValue(context);

                string recievdData = JsonConvert.SerializeObject(recivedata);

                if (string.IsNullOrEmpty(fileName))
                {
                    logger.Error("Process Request Error:not file Name.\n" + "Request Info:\n" + GetRequestInfo(context.Request));

                    SPFailedRequestWrapper.SaveFailedRequest(context.Request, GetRealIP(), recievdData,"Process Request Error:not file Name.\n",0,0);

                    return;
                }


                fileName = fileName.Substring(0, fileName.Length - ("Recieved").Length);


                SPChannelWrapper channel = SPChannelWrapper.GetChannelByPath(fileName);

                if (channel != null)
                {
                    if (channel.CStatus != ChannelStatus.Run)
                    {
                        logger.Error("Process Request Error:\n" + " Channel " + channel.Name + " is not run Request Info:\n" + GetRequestInfo(context.Request));
                        SPFailedRequestWrapper.SaveFailedRequest(context.Request, GetRealIP(), recievdData, "Process Request Error:\n" + " Channel " + channel.Name + " is not run Request Info:\n", channel.Id, 0);
                        return;
                    }

                    //bool result = channel.ProcessRequest(PraseHttpGetPostRequestValue(context), GetRealIP(), recievdData, context.Request);

                    //if (result)
                    //    context.Response.Write(channel.GetOkCode());
                    //else
                    //{
                    //    logger.Error("Process Request Error:Request failed.\n" + "Request Info:\n" + GetRequestInfo(context.Request));

                    //    SPFailedRequestWrapper.SaveFailedRequest(context.Request, GetRealIP(), recievdData, "Process Request Error:Request failed.\n", channel.Id, 0);
                    //}
                }
                else
                {
                    logger.Error("Process Request Error:Can't find channle.\n" + "Request Info:\n" + GetRequestInfo(context.Request));
                    SPFailedRequestWrapper.SaveFailedRequest(context.Request, GetRealIP(), recievdData, "Process Request Error:Can't find channle.\n",0,0);
                }
            }
            catch (Exception ex)
            {
                logger.Error("Process Request Error:\n" + "Request Info:\n" + GetRequestInfo(context.Request), ex);

                try
                {
                    Hashtable recivedata = GetRequestValue(context);

                    string recievdData = JsonConvert.SerializeObject(recivedata);

                    SPFailedRequestWrapper.SaveFailedRequest(context.Request, GetRealIP(), recievdData, "Process Request Error:" + ex.Message + "\n", 0, 0);
                }
                catch (Exception e)
                {
                    logger.Error("失败请求保存失败.\n" + "Request Info:\n" + GetRequestInfo(context.Request));
                    SPFailedRequestWrapper.SaveFailedRequest(context.Request, GetRealIP(), GetRequestInfo(context.Request), "Process Request Error:" + e.Message + "\n", 0, 0);
                }

                return;
            }
        }

        private string GetRequestInfo(HttpRequest request)
        {
            Hashtable hb = new Hashtable();

            foreach (string key in request.Params.Keys)
            {
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
                logger.Error("Get IP Error:", ex);
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
