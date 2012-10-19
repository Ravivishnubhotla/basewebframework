
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Commons;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    public partial class SystemDictionaryWrapper : BaseSpringNHibernateWrapper<SystemDictionaryEntity, ISystemDictionaryServiceProxy, SystemDictionaryWrapper, int>
    {
        #region Static Common Data Operation

        public static void Save(SystemDictionaryWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SystemDictionaryWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemDictionaryWrapper obj)
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

        public static void Delete(SystemDictionaryWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemDictionaryWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemDictionaryWrapper FindById(int id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemDictionaryWrapper> FindAll()
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemDictionaryWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }

        public static List<SystemDictionaryWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemDictionaryWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemDictionaryWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            orderByFieldName = ProcessColumnName(orderByFieldName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy)); 
        }

        #endregion

        /// <summary>
        /// 获取指定类别下的所有字典项
        /// </summary>
        /// <param name="categoryName">字典类别名</param>
        /// <returns></returns>
        public static List<SystemDictionaryWrapper> GetDictionaryByGroupCode(string groupCode)
        {
            return ConvertToWrapperList(businessProxy.GetDictionaryByGroupCode(groupCode));
        }
        /// <summary>
        /// 解析指定类别下的字典键值
        /// </summary>
        /// <param name="categoryName">字典类别名</param>
        /// <param name="key">键值</param>
        /// <returns></returns>
        public static string ParseDictionaryValueByGroupCodeAndKey(string groupCode, string key)
        {
            return businessProxy.ParseDictionaryValueByGroupCodeAndKey(groupCode, key);
        }

 
 

	    public static List<SystemDictionaryWrapper> FindAllByGroupIdAndOrder()
	    {
            return ConvertToWrapperList(businessProxy.FindAllByGroupIdAndOrder());
	    }

	    public static void PatchAdd(string category, bool hasValue, string categoryItems)
	    {
            businessProxy.PatchAdd(category, hasValue, categoryItems);
	    }

        public string GroupName
        {
            get
            {
                if (this.SystemDictionaryGroupID == null)
                    return "";
                return SystemDictionaryGroupID.Name;
            }
        }

        public string Key
	    {
	        get { return this.SystemDictionaryKey; }
	    }
        public string Code
        {
            get { return this.SystemDictionaryCode; }
        }
        public string Value
        {
            get { return this.SystemDictionaryValue; }
        }


        public string LocaLocalizationName
        {
            get
            {
                return SystemTerminologyWrapper.GetLocalizationName(this.SystemDictionaryValue, Thread.CurrentThread.CurrentUICulture.ToString().ToLower());
            }
        }

    }
}
