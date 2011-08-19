
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
    public partial class SystemLogWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SystemLogWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemLogWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemLogWrapper obj)
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

        public static void Delete(SystemLogWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemLogWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemLogWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemLogWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemLogWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SystemLogEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }

        public static List<SystemLogWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemLogWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SystemLogWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams));

            return results;
        }
		

		
		#endregion


        //public void LogWrapperOp(int id,string title,string content,DateTime logTime)
        //{

        //}
    }
}
