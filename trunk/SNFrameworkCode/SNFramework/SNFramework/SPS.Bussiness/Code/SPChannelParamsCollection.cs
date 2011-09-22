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
            return requestLog.RequestParams[this[key]].ToString();
        }
    }
}
