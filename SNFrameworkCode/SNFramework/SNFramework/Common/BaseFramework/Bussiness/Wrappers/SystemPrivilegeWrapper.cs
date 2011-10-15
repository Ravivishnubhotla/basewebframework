
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    [DataObject()]
    public partial class SystemPrivilegeWrapper : BaseSpringNHibernateWrapper<SystemPrivilegeEntity, ISystemPrivilegeServiceProxy, SystemPrivilegeWrapper>
    {
        #region Static Common Data Operation

        public static void Save(SystemPrivilegeWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SystemPrivilegeWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemPrivilegeWrapper obj)
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

        public static void Delete(SystemPrivilegeWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemPrivilegeWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemPrivilegeWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemPrivilegeWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemPrivilegeWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemPrivilegeWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }


        public static List<SystemPrivilegeWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemPrivilegeWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            List<SystemPrivilegeWrapper> results = null;

            ProcessQueryFilters(filters);

            results = ConvertToWrapperList(
                    FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy));

            return results;
        }

        #endregion



        public string OperationName
	    {
	        get
	        {
                if (this.OperationID == null)
                    return "";
                return this.OperationID.OperationNameCn;
	        }
	    }

	    public string ResourceName
	    {
	        get
	        {
                if (this.ResourcesID == null)
                    return "";
	            return this.ResourcesID.ResourcesNameCn;
	        }
	    }

 

 

 

        public const string ColumnName_CategoryName = "CategoryName";
        public const string TableName_CategoryName = "CategoryNames";


	    public static void QuickGeneratePrivilege(int resourceid)
	    {
            SystemResourcesWrapper systemResourcesWrapper = SystemResourcesWrapper.FindById(resourceid);

            if (systemResourcesWrapper != null)
            {
                businessProxy.QuickGeneratePrivilege(systemResourcesWrapper.Entity);
            }
	    }

        public static List<SystemPrivilegeWrapper> TestFindResouceNameAndOPName(string resourceName,string opName)
        {
            return ConvertToWrapperList(businessProxy.TestFindResouceNameAndOPName(resourceName, opName));
        }
    }
}
