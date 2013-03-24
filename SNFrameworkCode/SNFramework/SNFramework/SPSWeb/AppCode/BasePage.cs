using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using Legendigital.Framework.Common.Securitys.SSO;

namespace SPSWeb.AppCode
{
    public class BasePage : BaseSSOSecurityPage
    {
        public static string BSFWebRoot
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["BSFWebRoot"]; }
        }

        public string BuildBSFWebUrl(string url)
        {
            Uri uri = new Uri(BSFWebRoot + url);

            return SSOProvider.AddSSFTokenToUrl(uri.ToString(), SSOProvider.GetSSOKeyFromPage(this));
        }
    }
}