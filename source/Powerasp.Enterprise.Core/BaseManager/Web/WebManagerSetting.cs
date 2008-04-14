using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Powerasp.Enterprise.Core.BaseManager.Web
{
    public static class WebManagerSetting
    {
        public static bool IsDebug
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["DispError"]);
            }
        }
    }
}
