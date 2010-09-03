using System;
using System.Web;

namespace Legendigital.Framework.Common.Utility
{
    public static class StringUtil
    {
        public static string GetRandNumber(int lenght)
        {
            string randNumber = "";
            var ra = new Random();
            for (int i = 0; i < lenght; i++)
            {
                randNumber += (ra.Next(1,10) - 1).ToString();
            }
            return randNumber;
        }


        public static string WebStringEncrypt(string content)
        {
            byte[] buffer = HttpContext.Current.Request.ContentEncoding.GetBytes(content);
            return HttpUtility.UrlEncode(Convert.ToBase64String(buffer));
        }

        public static string WebStringDecrypt(string encryptContent)
        {
            byte[] buffer = Convert.FromBase64String(encryptContent);
            return HttpContext.Current.Request.ContentEncoding.GetString(buffer);
        }
    }


}