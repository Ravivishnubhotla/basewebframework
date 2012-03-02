﻿using System;
using System.Collections.Generic;
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
            if (!string.IsNullOrEmpty(configValue))
            {
                return configValue;
            }
            return defaultValue;
        }


        public static string ReadStringAppSetting(string appKey, string defaultValue)
        {
             if (System.Configuration.ConfigurationManager.AppSettings[appKey]==null)
             {
                 return defaultValue;
             }
            return System.Configuration.ConfigurationManager.AppSettings[appKey];
        }

        public static int ReadIntAppSetting(string appKey, int defaultValue)
        {
            return Convert.ToInt32(ReadStringAppSetting(appKey, defaultValue.ToString()));
        }


    }
}