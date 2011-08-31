using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Utility;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst
{
    public class SysDictionaryWrapper
    {
        private static Dictionary<string, Dictionary<string,string>>  dictionarys = new Dictionary<string, Dictionary<string, string>>();

        static  SysDictionaryWrapper()
        {
            InitData();
        }

        private static void InitData()
        {
            dictionarys = new Dictionary<string, Dictionary<string, string>>();

            List<SystemDictionaryWrapper> dictionaryWrappers = SystemDictionaryWrapper.FindAllByGroupIdAndOrder();

            foreach (SystemDictionaryWrapper dictionaryWrapper in dictionaryWrappers)
            {
                if(!dictionarys.ContainsKey(dictionaryWrapper.SystemDictionaryGroupID.Code))
                {
                    dictionarys.Add(dictionaryWrapper.SystemDictionaryGroupID.Code, new Dictionary<string, string>());
                }
                dictionarys[dictionaryWrapper.SystemDictionaryGroupID.Code].Add(dictionaryWrapper.SystemDictionaryKey, dictionaryWrapper.SystemDictionaryValue);
            }
        }

        public static void RefreshCache()
        {
            InitData();
        }

        public static List<NameListItem> GetAllGroup()
        {
            List<NameListItem> nameListItems = new List<NameListItem>();
            
            foreach (KeyValuePair<string,Dictionary<string, string>> nameListItem in dictionarys)
            {
                nameListItems.Add(new NameListItem() { Name = nameListItem.Key});
            }

            return nameListItems;
        }



    }
}