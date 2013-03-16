using System;
using System.Collections.Generic;
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


    }
}