using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Channels
{
    /// <summary>
    /// Summary description for TestClientChannel
    /// </summary>
    public class TestClientChannel : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if (SPChannelWrapper.CaculteRandom(80))
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("failed");
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