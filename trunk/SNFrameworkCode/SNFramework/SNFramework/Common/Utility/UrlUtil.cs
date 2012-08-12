using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Utility
{
    public static class UrlUtil
    {
        public static string CombineWebUrl(string hostUrl, string rootUrl)
        {
            if (!hostUrl.EndsWith("/"))
            {
                hostUrl = hostUrl + "/";
            }

            if (rootUrl.StartsWith("~/"))
            {
                rootUrl = rootUrl.Replace("~/", "/");
            }

            if (!rootUrl.StartsWith("/"))
            {
                rootUrl = "/" + rootUrl;
            }

            return hostUrl + rootUrl.Substring(1, rootUrl.Length - 1);
        }
    }
}
