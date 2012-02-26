
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;


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

        public static List<SystemDictionaryWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SystemDictionaryEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SystemDictionaryWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SystemDictionaryWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SystemDictionaryWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

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
        public static List<SystemDictionaryWrapper> GetDictionaryByCategoryName(string categoryName)
        {
            return ConvertToWrapperList(businessProxy.GetDictionaryByCategoryName(categoryName));
        }
        /// <summary>
        /// 解析指定类别下的字典键值
        /// </summary>
        /// <param name="categoryName">字典类别名</param>
        /// <param name="key">键值</param>
        /// <returns></returns>
        public static string ParseDictionaryValueByCategoryNameAndKey(string categoryName,string key)
        {
            return businessProxy.ParseDictionaryValueByCategoryNameAndKey(categoryName, key);
        }

        /// <summary>
        /// 获取所有的字典类别名
        /// </summary>
        /// <returns></returns>
	    public static List<string> GetAllCategoryNames()
	    {
            return businessProxy.GetAllCategoryNames();
	    }
    }
}
