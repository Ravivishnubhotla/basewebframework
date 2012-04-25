using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SLHotSpot.Web
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(File.ReadAllText(context.Server.MapPath("~/DataFiles/" + "M001001_F1_0" + ".txt")));
            context.Response.End();
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