using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SL.Drawing.Web
{
    public static class UIHelper
    {
        public static string GetRootUrl()
        {
            HttpContext context = HttpContext.Current;

            if (context == null)
                return "";

            string rootUrl = "";

            if (context.Request.Url.Port == 80)
                rootUrl = string.Format("{0}://{1}/{0}{2}", context.Request.Url.Scheme,
                                     context.Request.Url.Host, context.Request.ApplicationPath);
            else
            {
                rootUrl = string.Format("{0}://{1}:{2}{3}", context.Request.Url.Scheme,
                                 context.Request.Url.Host,
                                 context.Request.Url.Port, context.Request.ApplicationPath);
            }




            return rootUrl;
        }
    }
}