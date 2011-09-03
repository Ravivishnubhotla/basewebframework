
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Commons;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    public partial class SystemDictionaryWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SystemDictionaryWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemDictionaryWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemDictionaryWrapper obj)
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

        public static void Delete(SystemDictionaryWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemDictionaryWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemDictionaryWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemDictionaryWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemDictionaryWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SystemDictionaryEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }

        public static List<SystemDictionaryWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemDictionaryWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SystemDictionaryWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                  pageQueryParams));

            return results;
        }

        public static List<SystemDictionaryWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            List<SystemDictionaryEntity> list = businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc);
            return ConvertToWrapperList(list);
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

 
    }
}
