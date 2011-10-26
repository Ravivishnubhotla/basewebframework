
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
    public partial class SystemResourcesWrapper : TreeItemWrapper<SystemResourcesEntity, ISystemResourcesServiceProxy, SystemResourcesWrapper>
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
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemResourcesWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemResourcesWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }


        public static List<SystemResourcesWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemResourcesWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            List<SystemResourcesWrapper> results = null;

            ProcessQueryFilters(filters);

            results = ConvertToWrapperList(
                    FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy));

            return results;
        }

        #endregion



        public override List<SystemResourcesWrapper> FindAllItems()
        {
            return SystemResourcesWrapper.FindAll();
        }

        protected override bool CheckIsRoot(SystemResourcesWrapper obj)
        {
            if (obj == null)
                return false;
            return (obj.ParentResourcesID == null);
        }

        protected override TypedTreeNodeItem<SystemResourcesWrapper> GetTreeNodeItemByDataItem(SystemResourcesWrapper item, TypedTreeNodeItem<SystemResourcesWrapper> parentNode)
        {
            TypedTreeNodeItem<SystemResourcesWrapper> node = new TypedTreeNodeItem<SystemResourcesWrapper>();
            node.Id = item.ResourcesID.ToString();
            node.Name = item.ResourcesNameCn;
            node.Code = item.ResourcesNameEn;
            node.DataItem = item.ParentResourcesID;
            node.ParentNode = parentNode;
            return node;
        }

        public static List<TypedTreeNodeItem<SystemResourcesWrapper>> GetAllTreeNodesItems()
        {
            return new SystemResourcesWrapper().GetAllTreeItems();
        }

        protected override bool CheckGetSubItems(SystemResourcesWrapper subitem, SystemResourcesWrapper mainItem)
        {
            return (subitem.ParentResourcesID != null) && (subitem.ParentResourcesID.ResourcesID == mainItem.ResourcesID);
        }

	}

 
}
