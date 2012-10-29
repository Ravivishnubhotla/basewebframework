
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
    public partial class SPAdPackWrapper  : BaseSpringNHibernateWrapper<SPAdPackEntity, ISPAdPackServiceProxy, SPAdPackWrapper,int>
    { 
        #region Static Common Data Operation
		
		public static void Save(SPAdPackWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SPAdPackWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SPAdPackWrapper obj)
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

        public static void Delete(SPAdPackWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SPAdPackWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SPAdPackWrapper FindById(int id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SPAdPackWrapper> FindAll()
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SPAdPackWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }
		
		public static List<SPAdPackWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SPAdPackWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc, PageQueryParams pageQueryParams)
        {
			orderByFieldName = ProcessColumnName(orderByFieldName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, pageQueryParams, businessProxy));
        }
		

        public static List<SPAdPackWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
			orderByFieldName = ProcessColumnName(orderByFieldName);
		
	        ProcessQueryFilters(filters);
 
            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc,  businessProxy));;
        }
			
		#endregion


	    public string AssignedClientName
	    {
	        get
	        {
	            SPSClientWrapper client = SPAdAssignedHistortyWrapper.GetAdPackAssignedClient(this);
                if(client!=null)
                {
                    return client.Name;
                }
	            return "";
	        }
	    }
    }
}
