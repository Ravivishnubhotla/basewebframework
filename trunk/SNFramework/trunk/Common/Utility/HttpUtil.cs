using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Legendigital.Framework.Common.Utility
{
    public static class HttpUtil
    {
        public static string GenerateFullUrl(string url)
        {
            string urlTemplate = "";

            if(HttpContext.Current.Request.Url.Port == 80)
            {
                urlTemplate = "Http://{0}";
            }
            else
            {
                urlTemplate = "Http://{0}:{1}";           
            }

            if(!url.StartsWith("/"))
            {
                urlTemplate += "/";
            }

            if (HttpContext.Current.Request.Url.Port == 80)
                return string.Format(urlTemplate + url, HttpContext.Current.Request.Url.Host);
            else
                return string.Format(urlTemplate + url, HttpContext.Current.Request.Url.Host, HttpContext.Current.Request.Url.Port);
        }
    }
}
