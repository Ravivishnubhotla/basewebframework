
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Commons;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Web.UI;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers 
{
	[Serializable]
    public partial class SystemOrganizationWrapper : BaseSpringNHibernateWrapper<SystemOrganizationEntity, ISystemOrganizationServiceProxy, SystemOrganizationWrapper>, ITreeItemWrapper
    { 
        #region Static Common Data Operation
		
		public static void Save(SystemOrganizationWrapper obj,int saveUserID)
		{
		    obj.CreateAt = System.DateTime.Now;
		    obj.CreateBy = saveUserID;
            Save(obj, businessProxy);
        }

        public static void Update(SystemOrganizationWrapper obj, int updateUserID,string updateComment)
        {
            obj.LastModifyAt = System.DateTime.Now;
            obj.LastModifyBy = updateUserID;
            obj.LastModifyComment = updateComment;
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemOrganizationWrapper obj)
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

        public static void Delete(SystemOrganizationWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemOrganizationWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemOrganizationWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemOrganizationWrapper> FindAll()
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemOrganizationWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }
		
		public static List<SystemOrganizationWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemOrganizationWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc, PageQueryParams pageQueryParams)
        {
			orderByFieldName = ProcessColumnName(orderByFieldName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, pageQueryParams, businessProxy));
        }
		

        public static List<SystemOrganizationWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
			orderByFieldName = ProcessColumnName(orderByFieldName);
		
	        ProcessQueryFilters(filters);
 
            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc,  businessProxy));;
        }
			
		#endregion

        public List<ITreeItemWrapper> FindAllItems()
	    {
            List<ITreeItemWrapper> treeItems = new List<ITreeItemWrapper>();

            List<SystemOrganizationWrapper> organizationWrappers = FindAll();

            foreach (SystemOrganizationWrapper organization in organizationWrappers)
            {
                treeItems.Add(organization);
            }

            return treeItems;
	    }

	    public ITreeItemWrapper ParentDataItemID
	    {
            get { return this.ParentID; }
	    }

	    public object DataKeyId
	    {
            get { return this.Id; }
	    }

 
    }
}
