
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
    public partial class SystemTerminologyWrapper : BaseSpringNHibernateWrapper<SystemTerminologyEntity, ISystemTerminologyServiceProxy, SystemTerminologyWrapper, int>
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

        public static void DeleteByID(int id)
        {
            DeleteByID(id, businessProxy);
        }

        public static void PatchDeleteByIDs(int[] ids)
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

        public static SystemTerminologyWrapper FindById(int id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemTerminologyWrapper> FindAll()
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemTerminologyWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }

        public static List<SystemTerminologyWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemTerminologyWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemTerminologyWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            orderByFieldName = ProcessColumnName(orderByFieldName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy)); 
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


        public static List<SystemTerminologyWrapper> FindAllByCode(string terminologyCode)
        {
            return ConvertToWrapperList(businessProxy.FindAllByCode(terminologyCode));
        }

	    public static bool IsExisted(string terminologyCode, string lang)
	    {
            return businessProxy.IsExisted(terminologyCode, lang);
	    }

	    public static void QuickAdd(string terminologyCode, string lang)
	    {
	        SystemTerminologyWrapper systemTerminology = new SystemTerminologyWrapper();
	        systemTerminology.Name = terminologyCode;
            systemTerminology.Code = terminologyCode;
            systemTerminology.Description = terminologyCode;
	        systemTerminology.Text = "";
            systemTerminology.LanguageType = lang;
	        systemTerminology.CreateAt = System.DateTime.Now;
            systemTerminology.LastModifyAt = System.DateTime.Now;
            SystemTerminologyWrapper.Save(systemTerminology);
	    }
    }
}
