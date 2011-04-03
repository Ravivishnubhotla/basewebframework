
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
    public partial class SystemResourcesWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SystemResourcesWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemResourcesWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemResourcesWrapper obj)
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

        public static void Delete(SystemResourcesWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemResourcesWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemResourcesWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemResourcesWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemResourcesWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SystemResourcesEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }

        public static List<SystemResourcesWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemResourcesWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SystemResourcesWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,pageQueryParams));

            return results;
        }
		

		
		#endregion

    }
}
