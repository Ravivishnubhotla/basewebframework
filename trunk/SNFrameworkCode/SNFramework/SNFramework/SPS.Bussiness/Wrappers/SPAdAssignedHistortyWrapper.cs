
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using System.Runtime.Serialization;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace SPS.Bussiness.Wrappers 
{
	[Serializable]
	[DataContract]
	//[JsonObject(MemberSerialization.OptIn)]
    public partial class SPAdAssignedHistortyWrapper  : BaseSpringNHibernateWrapper<SPAdAssignedHistortyEntity, ISPAdAssignedHistortyServiceProxy, SPAdAssignedHistortyWrapper,int>
    { 
        #region Static Common Data Operation
		
		public static void Save(SPAdAssignedHistortyWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SPAdAssignedHistortyWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SPAdAssignedHistortyWrapper obj)
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

        public static void Delete(SPAdAssignedHistortyWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SPAdAssignedHistortyWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SPAdAssignedHistortyWrapper FindById(int id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SPAdAssignedHistortyWrapper> FindAll()
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SPAdAssignedHistortyWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }
		
		public static List<SPAdAssignedHistortyWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SPAdAssignedHistortyWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc, PageQueryParams pageQueryParams)
        {
			orderByFieldName = ProcessColumnName(orderByFieldName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, pageQueryParams, businessProxy));
        }
		

        public static List<SPAdAssignedHistortyWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
			orderByFieldName = ProcessColumnName(orderByFieldName);
		
	        ProcessQueryFilters(filters);
 
            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc,  businessProxy));;
        }
			
		#endregion

 

    }
}
