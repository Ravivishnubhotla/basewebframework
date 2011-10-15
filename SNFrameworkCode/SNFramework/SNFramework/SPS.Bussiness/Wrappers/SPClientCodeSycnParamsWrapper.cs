
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace SPS.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPClientCodeSycnParamsWrapper : BaseSpringNHibernateWrapper<SPClientCodeSycnParamsEntity, ISPClientCodeSycnParamsServiceProxy, SPClientCodeSycnParamsWrapper>
    {
        #region Static Common Data Operation

        public static void Save(SPClientCodeSycnParamsWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SPClientCodeSycnParamsWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SPClientCodeSycnParamsWrapper obj)
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

        public static void Delete(SPClientCodeSycnParamsWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SPClientCodeSycnParamsWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SPClientCodeSycnParamsWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SPClientCodeSycnParamsWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPClientCodeSycnParamsWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SPClientCodeSycnParamsWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }


        public static List<SPClientCodeSycnParamsWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SPClientCodeSycnParamsWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            List<SPClientCodeSycnParamsWrapper> results = null;

            ProcessQueryFilters(filters);

            results = ConvertToWrapperList(
                    FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy));

            return results;
        }

        #endregion

    }
}
