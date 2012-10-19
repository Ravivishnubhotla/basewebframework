
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
    public partial class SystemAttachmentWrapper : BaseSpringNHibernateWrapper<SystemAttachmentEntity, ISystemAttachmentServiceProxy, SystemAttachmentWrapper, int>
    {
        #region Static Common Data Operation

        public static void Save(SystemAttachmentWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SystemAttachmentWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemAttachmentWrapper obj)
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

        public static void Delete(SystemAttachmentWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemAttachmentWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemAttachmentWrapper FindById(int id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemAttachmentWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemAttachmentWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }

        public static List<SystemAttachmentWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemAttachmentWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemAttachmentWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            orderByFieldName = ProcessColumnName(orderByFieldName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy));  
        }

        #endregion

 

    }
}
