
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
    public partial class SystemTerminologyWrapper : BaseSpringNHibernateWrapper<SystemTerminologyEntity, ISystemTerminologyServiceProxy, SystemTerminologyWrapper>
    {
        #region Static Common Data Operation

        public static void Save(SystemTerminologyWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SystemTerminologyWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemTerminologyWrapper obj)
        {
            SaveOrUpdate(obj, businessProxy);
        }

        public static void DeleteAll()
        {
            DeleteAll(businessProxy);
        }

        public static void DeleteByID(object id)
        {
            DeleteByID(id, businessProxy);
        }

        public static void PatchDeleteByIDs(object[] ids)
        {

            PatchDeleteByIDs(ids, businessProxy);
        }

        public static void Delete(SystemTerminologyWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemTerminologyWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemTerminologyWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemTerminologyWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemTerminologyWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemTerminologyWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }


        public static List<SystemTerminologyWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemTerminologyWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            List<SystemTerminologyWrapper> results = null;

            ProcessQueryFilters(filters);

            results = ConvertToWrapperList(
                    FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy));

            return results;
        }

        #endregion

        public static string GetLocalizationName(string name, string localizationType)
        {
            name = name.Trim();

            if (!name.StartsWith("[L]"))
                return name;

            string localName = GetLocalizationNameByTypeAndCode(localizationType.ToLower(), name.Replace("[L]", ""));

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
	            languages[systemTerminologyWrapper.Code].Add(systemTerminologyWrapper.LanguageType.ToLower(),systemTerminologyWrapper.Text);
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
