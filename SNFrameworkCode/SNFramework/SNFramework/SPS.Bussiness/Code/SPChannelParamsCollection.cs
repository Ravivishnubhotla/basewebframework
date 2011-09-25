using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using SPS.Bussiness.HttpUtils;
using SPS.Bussiness.Wrappers;

namespace SPS.Bussiness.Code
{
    public class SPChannelParamsCollection
    {
        private List<SPChannelParamsWrapper> cpparams = null;

        private SPChannelParamsCollection()
        {
        }

        public SPChannelParamsCollection(List<SPChannelParamsWrapper> cpparams)
        {
            this.cpparams = cpparams;
        }

        public string this[string paramKey]
        {
            get
            {
                SPChannelParamsWrapper spcpw =
                    cpparams.Find(p => (p.ParamsMappingName.Equals(paramKey)));

                if (spcpw != null)
                    return spcpw.Name.ToLower();

                return DictionaryConst.Dictionary_SPField_State_Key.ToLower();
            }
        }

        public string GetRequsetValueByKey(HttpRequestLog requestLog,string key)
        {
            if (requestLog.RequestParams.ContainsKey(this[key]))
                return requestLog.RequestParams[this[key]].ToString();
            else
                return "";
        }

        public string LinkIDFromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_LinkID_Key);
        }

        public string MoFromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_MO_Key);
        }

        public string SPCodeFromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_SpNumber_Key);
        }

        public string MobileFromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_Mobile_Key);
        }

        public string ProvinceFromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_Province_Key);
        }
        public string CityFromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_City_Key);
        }

        public string CreateDateFromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_CreateDate_Key);
        }

        public string FeeTimeFromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_FeeTime_Key);
        }

        public string StartTimeFromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_StartTime_Key);
        }

        public string EndTimeFromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_EndTime_Key);
        }


        public string StateFromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_State_Key);
        }

        public string ExtendField1FromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_ExtendField1_Key);
        }
        public string ExtendField2FromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_ExtendField2_Key);
        }
        public string ExtendField3FromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_ExtendField3_Key);
        }
        public string ExtendField4FromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_ExtendField4_Key);
        }
        public string ExtendField5FromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_ExtendField5_Key);
        }
        public string ExtendField6FromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_ExtendField6_Key);
        }
        public string ExtendField7FromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_ExtendField7_Key);
        }
        public string ExtendField8FromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_ExtendField8_Key);
        }
        public string ExtendField9FromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_ExtendField9_Key);
        }
        public string ExtendField10FromRequset(HttpRequestLog requestLog)
        {
            return GetRequsetValueByKey(requestLog, ConstClass.DictionaryConst.Dictionary_SPField_ExtendField10_Key);
        }
    }
}
