using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using SPS.Bussiness.DataAdapter;
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

        public List<SPChannelParamsWrapper> Items
        {
            get { return this.cpparams; }
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

        public string GetRequsetValueByKey(IDataAdapter requestLog, string key)
        {
            if (requestLog.RequestParams.ContainsKey(this[key]))
                return requestLog.RequestParams[this[key]].ToString();
            else
                return "";
        }

        public string LinkIDFromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_LinkID_Key);
        }

        public string MoFromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_MO_Key);
        }

        public string SPCodeFromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_SpNumber_Key);
        }

        public string MobileFromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_Mobile_Key);
        }

        public string ProvinceFromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_Province_Key);
        }
        public string CityFromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_City_Key);
        }

        public string CreateDateFromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_CreateDate_Key);
        }

        public string FeeTimeFromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_FeeTime_Key);
        }

        public string StartTimeFromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_StartTime_Key);
        }

        public string EndTimeFromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_EndTime_Key);
        }


        public string StateFromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_State_Key);
        }

        public string ExtendField1FromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_ExtendField1_Key);
        }
        public string ExtendField2FromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_ExtendField2_Key);
        }
        public string ExtendField3FromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_ExtendField3_Key);
        }
        public string ExtendField4FromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_ExtendField4_Key);
        }
        public string ExtendField5FromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_ExtendField5_Key);
        }
        public string ExtendField6FromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_ExtendField6_Key);
        }
        public string ExtendField7FromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_ExtendField7_Key);
        }
        public string ExtendField8FromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_ExtendField8_Key);
        }
        public string ExtendField9FromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_ExtendField9_Key);
        }
        public string ExtendField10FromRequset(IDataAdapter requestLog)
        {
            return GetRequsetValueByKey(requestLog, DictionaryConst.Dictionary_SPField_ExtendField10_Key);
        }
    }
}
