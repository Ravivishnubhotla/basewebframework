using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Utility
{
    [Serializable]
    public class ServerInfo
    {
        public string ServerName { get; set; }
        public string ServerVer { get; set; }
        public string ServerIP { get; set; }

        public string ServerDomain { get; set; }
        public string ServerOutTime { get; set; }
        public string ServerNow { get; set; }

        public string ServerSessionTotal { get; set; }
        public string ServerApplicationTotal { get; set; }

        public string IISVer { get; set; }
        public string NetVer { get; set; }


        public string ProPath { get; set; }
        public string ProPath_2 { get; set; }
        public string ServerRunTime { get; set; }


        public string WebsiteSize { get; set; }
        public string WebsiteDiskSize { get; set; }
 




    }


    [Serializable]
    public class BrowerInfo
    {
        public string Brower_IP { get; set; }
        public string Brower_OSVer { get; set; }
        public string Brower_Brower { get; set; }
        public string Brower_BrowerVer { get; set; }
        public string Brower_Javscript { get; set; }
        public string Brower_VBScript { get; set; }
        public string Brower_JavaApplets { get; set; }
        public string Brower_Cookies { get; set; }
        public string Brower_Language { get; set; }
        public string Brower_Frame { get; set; }
    }

    [Serializable]
    public class DbInfo
    {
        public string DB_IP { get; set; }
        public string DB_Name { get; set; }
        public string DB_Size { get; set; }
        public string DB_LogSize { get; set; }
        public string DB_PathDiskInfo { get; set; }
    }

    public class ServerInfoUtil
    {
        public static ServerInfo GetServerInfo()
        {
            ServerInfo serverInfo = new ServerInfo();
            return serverInfo;
        }
    }
}
