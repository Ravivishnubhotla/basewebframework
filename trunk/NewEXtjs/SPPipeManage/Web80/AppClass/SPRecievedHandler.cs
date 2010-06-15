using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Common.Logging;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.AppClass
{
    public class SPRecievedHandler : IHttpHandler
    {
        protected ILog logger = LogManager.GetLogger(typeof(SPRecievedHandler));


        public void ProcessRequest(HttpContext context)
        {
            string fileName = Path.GetFileNameWithoutExtension(context.Request.PhysicalPath);

            SPChannelWrapper channel = SPChannelWrapper.GetChannelByPath(fileName);

            if (channel != null)
            {
                bool result = channel.ProcessRequest(GetRequestValue(context), GetRealIP());

                if(!result)
                    context.Response.StatusCode = 500; 
            }
            else
            {
                context.Response.StatusCode = 500; 
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
            catch (Exception e)
            {

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
