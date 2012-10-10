using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Utility
{
    /// <summary>
    /// 配置帮助类
    /// </summary>
    public class ConfigurationUtil
    {
        public static string GetConfigValue(string configValue, string defaultValue)
        {
            if (string.IsNullOrEmpty(configValue))
            {
                return defaultValue;
            }
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[configValue]))
            {
                return ConfigurationManager.AppSettings[configValue];
            }
            return defaultValue;
        }
    }
}