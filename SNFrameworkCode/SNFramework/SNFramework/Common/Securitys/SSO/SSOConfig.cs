using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Legendigital.Framework.Common.Utility;

namespace Legendigital.Framework.Common.Securitys.SSO
{
    public static class SSOConfig
    {

        public enum AuthenticationMode
        {
            SSOMode,
            TestMode
        }

        public const string CFG_NAME_AUTHENTICATIONMODE = "AuthenticationMode";
        public const string CFG_NAME_BSFWEBROOT = "BSFWebRoot";
        public const string CFG_NAME_CURRENTAPPLICATIONCODE = "CurrentApplicationCode";


        public static AuthenticationMode SystemAuthenticationMode
        {
            get
            {
                if(ConfigurationUtil.GetConfigValue(CFG_NAME_AUTHENTICATIONMODE, "SSOMode")=="TestMode")
                    return AuthenticationMode.TestMode;
                return AuthenticationMode.SSOMode;
            }
        }

        public static string BSFWebRoot
        {
            get { return ConfigurationUtil.GetConfigValue(CFG_NAME_BSFWEBROOT, ""); }
        }

        public static string CurrentApplicationCode
        {
            get { return ConfigurationUtil.GetConfigValue(CFG_NAME_CURRENTAPPLICATIONCODE, ""); }
        }



    }
}
