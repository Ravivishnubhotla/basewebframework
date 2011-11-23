
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
    public partial class SystemResourcesWrapper : BaseSpringNHibernateWrapper<SystemResourcesEntity, ISystemResourcesServiceProxy, SystemResourcesWrapper>, ITreeItemWrapper
	{
        #region Static Common Data Operation

        public static void Save(SystemResourcesWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SystemResourcesWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemResourcesWrapper obj)
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

        public static void Delete(SystemResourcesWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemResourcesWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemResourcesWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemResourcesWrapper> FindAll()
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemResourcesWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }

        public static List<SystemResourcesWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemResourcesWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemResourcesWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            orderByFieldName = ProcessColumnName(orderByFieldName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy)); 
        }

        #endregion



        public List<ITreeItemWrapper> FindAllItems()
        {
            List<ITreeItemWrapper> treeItems = new List<ITreeItemWrapper>();

            List<SystemResourcesWrapper> organizationWrappers = FindAll();

            foreach (SystemResourcesWrapper organization in organizationWrappers)
            {
                treeItems.Add(organization);
            }

            return treeItems;
        }

        public ITreeItemWrapper ParentDataItemID
        {
            get { return this.ParentResourcesID; }
        }

 

        public string Name
        {
            get { return this.ResourcesNameCn; }
        }

        public string Code
        {
            get { return this.ResourcesNameEn; }
        }

        public object DataKeyId
        {
            get { return this.ResourcesID; }
        }

 

 

 

	}

 
}
