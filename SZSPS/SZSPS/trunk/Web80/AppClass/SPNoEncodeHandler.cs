using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Logging;
using LD.SPPipeManage.Bussiness.Commons;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.AppClass
{
    public class SPNoEncodeHandler : IHttpHandler
    {
        protected static ILog logger = LogManager.GetLogger(typeof(SPNoEncodeHandler));

 

        public void ProcessRequest(HttpContext context)
        {
            foreach (var key1 in context.Request.Params.AllKeys)
            {
                context.Response.Write(string.Format("{0}:{1}<br/>", key1, context.Request.Params[key1]));
            }
 

            foreach (var key in context.Request.ServerVariables.AllKeys)
            {
                context.Response.Write(string.Format("{0}:{1}<br/>", key, context.Request.ServerVariables[key]));
            }
        }

        private void LogWarnInfo(IHttpRequest httpRequest, string errorInfo, int channelID, int clientID)
        {
            logger.Warn(errorInfo + "请求信息：\n" + httpRequest.RequestData);

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