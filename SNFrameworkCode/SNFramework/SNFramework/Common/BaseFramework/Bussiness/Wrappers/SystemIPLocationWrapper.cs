
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
    public partial class SystemIPLocationWrapper : BaseSpringNHibernateWrapper<SystemIPLocationEntity, ISystemIPLocationServiceProxy, SystemIPLocationWrapper, int>
    { 
        #region Static Common Data Operation
		
		public static void Save(SystemIPLocationWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SystemIPLocationWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemIPLocationWrapper obj)
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

        public static void Delete(SystemIPLocationWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemIPLocationWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemIPLocationWrapper FindById(int id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemIPLocationWrapper> FindAll()
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemIPLocationWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }
		
		public static List<SystemIPLocationWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemIPLocationWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc, PageQueryParams pageQueryParams)
        {
			orderByFieldName = ProcessColumnName(orderByFieldName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, pageQueryParams, businessProxy));
        }
		

        public static List<SystemIPLocationWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
			orderByFieldName = ProcessColumnName(orderByFieldName);
		
	        ProcessQueryFilters(filters);
 
            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc,  businessProxy));;
        }
			
		#endregion

 

    }
}
