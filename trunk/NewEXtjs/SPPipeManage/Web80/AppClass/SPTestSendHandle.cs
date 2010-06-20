using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Logging;
using LD.SPPipeManage.Bussiness.Wrappers;
using Newtonsoft.Json;

namespace Legendigital.Common.Web.AppClass
{
    public class SPTestSendHandle : IHttpHandler
    {
        protected static ILog logger = LogManager.GetLogger(typeof(SPTestSendHandle));


        public void ProcessRequest(HttpContext context)
        {
            try
            {
                Hashtable recivedata = GetRequestValue(context);

                string recievdData = JsonConvert.SerializeObject(recivedata);

                SPTestRecievedWrapper spTestRecievedWrapper = new SPTestRecievedWrapper();

                spTestRecievedWrapper.ChannelID = null;

                spTestRecievedWrapper.ClientID = null;

                spTestRecievedWrapper.RecievedSendUrl = VirtualPathUtility.GetFileName(context.Request.PhysicalPath);

                spTestRecievedWrapper.RecievedDate = DateTime.Now;

                spTestRecievedWrapper.RecievedContent = recievdData;

                spTestRecievedWrapper.RecievedIP = GetRealIP();

                SPTestRecievedWrapper.Save(spTestRecievedWrapper);
            }
            catch (Exception e)
            {
                logger.Error("Process Request Error:", e);
                context.Response.StatusCode = 500;
                return;
            }




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
                hb.Add(key, requestContext.Request.Params[key]);
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
