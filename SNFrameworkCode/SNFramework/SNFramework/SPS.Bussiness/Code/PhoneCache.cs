using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using SPS.Bussiness.Wrappers;

namespace SPS.Bussiness.Code
{
    public class PhoneCache
    {
        public const string PhoneInfos_Key = "PhoneInfos";

        public static Dictionary<string, PhoneAreaInfo> PhoneInfos
        {
            get
            {
                if (HttpContext.Current.Cache[PhoneInfos_Key] == null)
                {
                    HttpContext.Current.Cache[PhoneInfos_Key] = SystemPhoneAreaWrapper.GetAllPhoneInfos_Key();
                }
                return HttpContext.Current.Cache[PhoneInfos_Key] as Dictionary<string, PhoneAreaInfo>;
            }
        }

        public static PhoneAreaInfo GetPhoneAreaByPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return null;
            if (phoneNumber.Length < 7)
                return null;
            return PhoneInfos[phoneNumber.Substring(0, 7)];
        }
    }
}
