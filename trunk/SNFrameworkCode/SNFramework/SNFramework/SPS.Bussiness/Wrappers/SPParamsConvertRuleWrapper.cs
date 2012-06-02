
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
    public partial class SPParamsConvertRuleWrapper  : BaseSpringNHibernateWrapper<SPParamsConvertRuleEntity, ISPParamsConvertRuleServiceProxy, SPParamsConvertRuleWrapper,int>
    { 
        #region Static Common Data Operation
		
		public static void Save(SPParamsConvertRuleWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SPParamsConvertRuleWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SPParamsConvertRuleWrapper obj)
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

        public static void Delete(SPParamsConvertRuleWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SPParamsConvertRuleWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SPParamsConvertRuleWrapper FindById(int id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SPParamsConvertRuleWrapper> FindAll()
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SPParamsConvertRuleWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }
		
		public static List<SPParamsConvertRuleWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SPParamsConvertRuleWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc, PageQueryParams pageQueryParams)
        {
			orderByFieldName = ProcessColumnName(orderByFieldName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, pageQueryParams, businessProxy));
        }
		

        public static List<SPParamsConvertRuleWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
			orderByFieldName = ProcessColumnName(orderByFieldName);
		
	        ProcessQueryFilters(filters);
 
            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc,  businessProxy));;
        }
			
		#endregion

 

    }
}
