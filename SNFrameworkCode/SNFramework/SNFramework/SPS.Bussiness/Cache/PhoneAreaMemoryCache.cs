using System.Collections.Generic;
using System.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using SPS.Bussiness.Code;

namespace SPS.Bussiness.Cache
{
    public class PhoneAreaMemoryCache : IPhoneAreaCache
    {
        protected const string PhoneInfos_Key = "PhoneInfos";

        protected static Dictionary<string, PhoneArea> PhoneInfos
        {
            get
            {
                if (HttpContext.Current.Cache[PhoneInfos_Key] == null)
                {
                    HttpContext.Current.Cache[PhoneInfos_Key] = GetAllPhoneDictionary();
                }
                return HttpContext.Current.Cache[PhoneInfos_Key] as Dictionary<string, PhoneArea>;
            }
        }

        protected static Dictionary<string, PhoneArea> GetAllPhoneDictionary()
        {
            List<SystemPhoneAreaWrapper> phoneAreaWrappers = SystemPhoneAreaWrapper.FindAll();

            Dictionary<string, PhoneArea> allPhoneDictionar = new Dictionary<string, PhoneArea>();

            foreach (SystemPhoneAreaWrapper phoneAreaWrapper in phoneAreaWrappers)
            {
                PhoneArea phoneArea = new PhoneArea();
                phoneArea.City = phoneAreaWrapper.City;
                phoneArea.Province = phoneAreaWrapper.Province;
                phoneArea.OperatorType = phoneAreaWrapper.OperatorType;
                allPhoneDictionar.Add(phoneAreaWrapper.PhonePrefix, phoneArea);
            }

            return allPhoneDictionar;
        }

        public PhoneArea GetPhoneAreaByPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return null;
            if (phoneNumber.Length < 7)
                return null;
            return PhoneInfos[phoneNumber.Substring(0, 7)];
        }
    }
}
