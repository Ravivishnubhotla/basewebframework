using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;

namespace Legendigital.Framework.Common.Environments
{
    [Serializable]
    public class ServerEnvironmentInfo
    {
        /// <summary>
        /// 服务器计算机名
        /// </summary>
        public string ServerName { get; set; }
        /// <summary>
        /// 服务器IP地址
        /// </summary>
        public string ServerIP { get; set; }
        public string ServerDomain { get; set; }
        public string ServerPort { get; set; }
        public string ServerIIS { get; set; }
        public string ServerFilePath { get; set; }
        public string ServerPhyAppPath { get; set; }
        public string ServerAppPath { get; set; }
        public string ServerOS { get; set; }
        public string ServerRoot { get; set; }
        public string ServerProgramRoot { get; set; }
        public string ServerDotNetLang { get; set; }
        public string ServerDotNetVer { get; set; }
        public string ServerNowDate { get; set; }
        public string ServerLastStartToNow { get; set; }
        public string ServerMemSize { get; set; }
        public string ServerMemFreeSize { get; set; }
        public string ServerMemUseSize { get; set; }

        public string ServerExFileSize { get; set; }
        public string ServerExFileFreeSize { get; set; }
        public string ServerExMemSize { get; set; }
        public string ServerExMemFreeSize { get; set; }
        public string ServerLogicalDriver { get; set; }
        public string ServerCpuCount { get; set; }

        //[DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        //internal static void GetSystemDirectory(StringBuilder SysDir, int count);

        //[DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        //internal static void GetSystemInfo(ref CPU_INFO cpuinfo);

        //[DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        //internal static void GlobalMemoryStatus(ref MEMORY_INFO meminfo);

        public string GetOSInfo()
        {
            //Get Operating system information.
            OperatingSystem os = Environment.OSVersion;
            //Get version information about the os.
            Version vs = os.Version;

            //Variable to hold our return value
            string operatingSystem = "";

            if (os.Platform == PlatformID.Win32Windows)
            {
                //This is a pre-NT version of Windows
                switch (vs.Minor)
                {
                    case 0:
                        operatingSystem = "95";
                        break;
                    case 10:
                        if (vs.Revision.ToString() == "2222A")
                            operatingSystem = "98SE";
                        else
                            operatingSystem = "98";
                        break;
                    case 90:
                        operatingSystem = "Me";
                        break;
                    default:
                        break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3:
                        operatingSystem = "NT 3.51";
                        break;
                    case 4:
                        operatingSystem = "NT 4.0";
                        break;
                    case 5:
                        if (vs.Minor == 0)
                            operatingSystem = "2000";
                        else
                            operatingSystem = "XP";
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            operatingSystem = "Vista";
                        else
                            operatingSystem = "7";
                        break;
                    default:
                        break;
                }
            }
            //Make sure we actually got something in our OS check
            //We don't want to just return " Service Pack 2" or " 32-bit"
            //That information is useless without the OS version.
            if (operatingSystem != "")
            {
                //Got something.  Let's prepend "Windows" and get more info.
                operatingSystem = "Windows " + operatingSystem;
                //See if there's a service pack installed.
                if (os.ServicePack != "")
                {
                    //Append it to the OS name.  i.e. "Windows XP Service Pack 3"
                    operatingSystem += " " + os.ServicePack;
                }
                //Append the OS architecture.  i.e. "Windows XP Service Pack 3 32-bit"
                //operatingSystem += " " + getOSArchitecture().ToString() + "-bit";
            }
            //Return the information we've gathered.
            return operatingSystem;
        }

        public ServerEnvironmentInfo(HttpContext context)
        { 
            if(context!=null)
            {
                this.ServerName = context.Server.MachineName;
                this.ServerIP = context.Request.ServerVariables["LOCAl_ADDR"];
                this.ServerDomain = context.Request.ServerVariables["Server_Name"];
                this.ServerPort = context.Request.ServerVariables["Server_Port"];
                this.ServerIIS = context.Request.ServerVariables["Server_SoftWare"];
                this.ServerFilePath = context.Request.PhysicalPath;
                this.ServerPhyAppPath = context.Request.PhysicalApplicationPath;
                this.ServerAppPath = context.Request.ApplicationPath;
                this.ServerOS = GetOSInfo();
                //switch (Environment.OSVersion.Platform)
                //{
                //        Environment.OSVersion.VersionString
                //  case PlatformID.Win32S:
                //    this.ServerOS = "Win32S";
                //    break;
                //  case PlatformID.Win32Windows:
                //    int num1 = Environment.OSVersion.Version.Minor;
                //    switch (num1)
                //    {
                //      case 0:
                //        this.ServerOS = "Microsoft Windows 95";
                //        break;
                //      case 10:

                //        num1 = Environment.OSVersion.Version.Revision;
                //        string str4 = num1.ToString() == "2222A" ? "Microsoft Windows 98 Second Edition" : "Windows 98";
                //        this.ServerOS = str4;
                //        break;
                //      case 90:
                //        this.ServerOS = "Microsoft Windows Me";
                //        break;
                //    }
                //        break;
                //  case PlatformID.Win32NT:
                //    num1 = Environment.OSVersion.Version.Major;
                //    switch (num1)
                //    {
                //      case 3:
                //        this.ServerOS = "Microsoft Windows NT 3.51";
                //        break;
                //      case 4:
                //        this.ServerOS = "Microsoft Windows NT 4.0";
                //        break;
                //      case 5:
                //        num1 = Environment.OSVersion.Version.Minor;
                //        switch (num1)
                //        {
                //          case 0:
                //            this.ServerOS = "Microsoft Windows 2000";
                //            break;
                //          case 1:
                //            this.ServerOS = "Microsoft Windows XP";
                //            break;
                //          case 2:
                //            this.ServerOS = "Microsoft Windows 2003";
                //            break;
                //        }
                //            break;
                //      default :
                //        this.ServerOS = "Microsoft Windows NT";
                //        break;
                //    }
                //        break;
                //  case PlatformID.WinCE:
                //    this.ServerOS = "Microsoft Windows CE";
                //    break;
                //}

                //MEMORY_INFO meminfo = new  MEMORY_INFO();
                //GlobalMemoryStatus(ref meminfo);

            }
        }

        public struct CPU_INFO
        {
            public uint dwOemId;
            public uint dwPageSize;
            public uint lpMinimumApplicationAddress;
            public uint lpMaximumApplicationAddress;
            public uint dwActiveProcessorMask;
            public uint dwNumberOfProcessors;
            public uint dwProcessorType;
            public uint dwAllocationGranularity;
            public uint dwProcessorLevel;
            public uint dwProcessorRevision;
        }

        public struct MEMORY_INFO
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public uint dwTotalPhys;
            public uint dwAvailPhys;
            public uint dwTotalPageFile;
            public uint dwAvailPageFile;
            public uint dwTotalVirtual;
            public uint dwAvailVirtual;
        }
    }
}
