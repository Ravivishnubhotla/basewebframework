
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
    public partial class SystemPrivilegeWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SystemPrivilegeWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemPrivilegeWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemPrivilegeWrapper obj)
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

        public static void Delete(SystemPrivilegeWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemPrivilegeWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemPrivilegeWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemPrivilegeWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemPrivilegeWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SystemPrivilegeEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }

        public static List<SystemPrivilegeWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemPrivilegeWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SystemPrivilegeWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams));

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

 

        public static List<SystemPrivilegeWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }

 

        public const string ColumnName_CategoryName = "CategoryName";
        public const string TableName_CategoryName = "CategoryNames";


	    public static void QuickGeneratePrivilege(int resourceid)
	    {
            SystemResourcesWrapper systemResourcesWrapper = SystemResourcesWrapper.FindById(resourceid);

            if (systemResourcesWrapper != null)
            {
                businessProxy.QuickGeneratePrivilege(systemResourcesWrapper.entity);
            }
	    }
    }
}
