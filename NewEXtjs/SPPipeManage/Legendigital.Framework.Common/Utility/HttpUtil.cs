using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace Legendigital.Framework.Common.Utility
{
    public static class HttpUtil
    {
        public static string GenerateFullUrl(string url)
        {
            string urlTemplate = "";

            if(HttpContext.Current.Request.Url.Port == 80)
            {
                urlTemplate = "Http://{0}";
            }
            else
            {
                urlTemplate = "Http://{0}:{1}";           
            }

            if(!url.StartsWith("/"))
            {
                urlTemplate += "/";
            }

            if (HttpContext.Current.Request.Url.Port == 80)
                return string.Format(urlTemplate + url, HttpContext.Current.Request.Url.Host);
            else
                return string.Format(urlTemplate + url, HttpContext.Current.Request.Url.Host, HttpContext.Current.Request.Url.Port);
        }


        public static string GetIP(HttpRequest request)
        {
            string ip = string.Empty;
            try
            {
                if (request.ServerVariables["HTTP_VIA"] != null)
                {
                    ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Split(',')[0].Trim();
                }
                else
                {
                    ip = request.UserHostAddress;
                }
                if (ip == "::1")
                {
                    ip = "127.0.0.1";
                }
            }
            catch (Exception ex)
            {
            }
            return ip;
        }

        public static string ParseLocation(string strIP)
        {
            try
            {
                string sURL = "http://www.youdao.com/smartresult-xml/search.s?type=ip&q="+strIP+"";//youdao的URL
                string stringIpAddress = "";
                using (XmlReader read = XmlReader.Create(sURL))//获取youdao返回的xml格式文件内容
                {
                    while (read.Read())
                    {
                        switch (read.NodeType)
                        {
                            case XmlNodeType.Text://取xml格式文件当中的文本内容
                                if (string.Format("{0}", read.Value).ToString().Trim() != strIP)//youdao返回的xml格式文件内容一个是IP，另一个是IP地址，如果不是IP那么就是IP地址
                                {
                                    stringIpAddress=string.Format("{0}", read.Value).ToString().Trim();//赋值
                                }
                                break;
                                //other
                        }
                    }
                }
                return stringIpAddress;
            }
            catch (Exception ex)
            {
                return "未知地址";
            }
        }
    }
}
