using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Legendigital.Framework.Common.Utility;

namespace SPS.Bussiness.Cache
{
    public static class NOSQLConfig
    {
        public static bool NoSQL_Enable
        {
            get
            {
                bool noSQL_Enable = false;
                return Boolean.TryParse(ConfigurationUtil.GetConfigValue("NoSQL.Enable", "0"), out noSQL_Enable);
                return noSQL_Enable;
            }
        }
        public static string NoSQL_DBConnString
        {
            get { return ConfigurationUtil.GetConfigValue("NoSQL.DBConnString", ""); }
        }
        public static string NoSQL_DbName
        {
            get { return ConfigurationUtil.GetConfigValue("NoSQL.DbName", ""); }
        }
        public static string NoSQL_CollectionName
        {
            get { return ConfigurationUtil.GetConfigValue("NoSQL.CollectionName", ""); }
        }
    }
}
