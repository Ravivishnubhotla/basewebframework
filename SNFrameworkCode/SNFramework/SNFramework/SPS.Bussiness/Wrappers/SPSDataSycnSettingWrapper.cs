
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Serialization;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace SPS.Bussiness.Wrappers 
{
	[Serializable]
	[DataContract]
	//[JsonObject(MemberSerialization.OptIn)]
    public partial class SPSDataSycnSettingWrapper  : BaseSpringNHibernateWrapper<SPSDataSycnSettingEntity, ISPSDataSycnSettingServiceProxy, SPSDataSycnSettingWrapper,int>
    { 
        #region Static Common Data Operation
		
		public static void Save(SPSDataSycnSettingWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SPSDataSycnSettingWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SPSDataSycnSettingWrapper obj)
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

        public static void Delete(SPSDataSycnSettingWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SPSDataSycnSettingWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SPSDataSycnSettingWrapper FindById(int id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SPSDataSycnSettingWrapper> FindAll()
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SPSDataSycnSettingWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }
		
		public static List<SPSDataSycnSettingWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SPSDataSycnSettingWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc, PageQueryParams pageQueryParams)
        {
			orderByFieldName = ProcessColumnName(orderByFieldName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, pageQueryParams, businessProxy));
        }
		

        public static List<SPSDataSycnSettingWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
			orderByFieldName = ProcessColumnName(orderByFieldName);
		
	        ProcessQueryFilters(filters);
 
            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc,  businessProxy));;
        }
			
		#endregion

 

    }
}
