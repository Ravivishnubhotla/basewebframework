
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
    public partial class SystemRoleMenuRelationWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SystemRoleMenuRelationWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemRoleMenuRelationWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemRoleMenuRelationWrapper obj)
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

        public static void Delete(SystemRoleMenuRelationWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemRoleMenuRelationWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemRoleMenuRelationWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemRoleMenuRelationWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemRoleMenuRelationWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SystemRoleMenuRelationEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }

        public static List<SystemRoleMenuRelationWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemRoleMenuRelationWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SystemRoleMenuRelationWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                  pageQueryParams));

            return results;
        }
		

		
		#endregion

    }
}
