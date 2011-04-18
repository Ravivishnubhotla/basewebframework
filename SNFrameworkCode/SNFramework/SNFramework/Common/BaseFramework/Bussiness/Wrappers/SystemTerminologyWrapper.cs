
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    public partial class SystemTerminologyWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SystemTerminologyWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemTerminologyWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemTerminologyWrapper obj)
        {
            businessProxy.SaveOrUpdate(obj.entity);
        }

        public static void DeleteAll()
        {
            businessProxy.DeleteAll();
        }

        public static void DeleteByID(object id)
        {
            businessProxy.DeleteByID(id);
        }

        public static void PatchDeleteByIDs(object[] ids)
        {

            businessProxy.PatchDeleteByIDs(ids);
        }

        public static void Delete(SystemTerminologyWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemTerminologyWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemTerminologyWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemTerminologyWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemTerminologyWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SystemTerminologyEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }
		
		public static List<SystemTerminologyWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc,pageQueryParams);
        }


        public static List<SystemTerminologyWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SystemTerminologyWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,pageQueryParams));

            return results;
        }
		

        public static List<SystemTerminologyWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion

        public static string GetLocalizationName(string name, string localizationType)
        {
            name = name.Trim();

            if (!name.StartsWith("[L]"))
                return name;

            string localName = GetLocalizationNameByTypeAndCode(localizationType, name.Replace("[L]",""));

            if (string.IsNullOrEmpty(localName))
                return name;

            return localName;
        }

        private static Dictionary<string, Dictionary<string, string>> languages;

        static SystemTerminologyWrapper()
        {
            InitData();
        }

	    private static void InitData()
	    {
	        languages = new Dictionary<string, Dictionary<string, string>>();

	        List<SystemTerminologyWrapper> systemTerminologyWrappers = SystemTerminologyWrapper.FindAll();

	        foreach (SystemTerminologyWrapper systemTerminologyWrapper in systemTerminologyWrappers)
	        {
	            if(!languages.ContainsKey(systemTerminologyWrapper.Code))
	            {
	                Dictionary<string, string> dictionary = new Dictionary<string, string>();
	                languages.Add(systemTerminologyWrapper.Code,new Dictionary<string, string>());

	            }
	            languages[systemTerminologyWrapper.Code].Add(systemTerminologyWrapper.LanguageType,systemTerminologyWrapper.Text);
	        }
	    }


        public static void ResetData()
        {
            InitData();
        }

	    private static string GetLocalizationNameByTypeAndCode(string localizationType, string localizationCode)
	    {
            if (languages.ContainsKey(localizationCode) && languages[localizationCode].ContainsKey(localizationType))
                return languages[localizationCode][localizationType];
	        return "";
	    }


 


    }
}
