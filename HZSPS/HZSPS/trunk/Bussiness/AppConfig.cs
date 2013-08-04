using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace LD.SPPipeManage.Bussiness
{
    public static class AppConfig
    {
        private const string Key_IsGamePlatform = "IsGamePlatform";
        private const string Key_GamePlatformOutReportLink = "GamePlatformOutReportLink";

        

        public static bool IsGamePlatform
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings[Key_IsGamePlatform]))
                    return false;

                return (ConfigurationManager.AppSettings[Key_IsGamePlatform] == "1");
            }
        }

        public static string GamePlatformOutReportLink
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings[Key_GamePlatformOutReportLink]))
                    return "";

                return ConfigurationManager.AppSettings[Key_GamePlatformOutReportLink];
            }
        }
    }
}
