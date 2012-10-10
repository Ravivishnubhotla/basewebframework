using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPSWeb.Moudles.SPS.Clients
{
    /// <summary>
    /// Summary description for SPClientHandler
    /// </summary>
    public class SPClientHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
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