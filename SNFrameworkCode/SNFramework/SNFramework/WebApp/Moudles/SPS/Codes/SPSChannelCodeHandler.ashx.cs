using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Legendigital.Common.WebApp.Moudles.SPS.Codes
{
    /// <summary>
    /// Summary description for SPSChannelCodeHandler
    /// </summary>
    public class SPSChannelCodeHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.QueryString["ClientID"]))
            {

            }


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