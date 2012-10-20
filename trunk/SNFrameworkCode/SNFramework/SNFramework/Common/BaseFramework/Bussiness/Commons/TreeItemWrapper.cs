using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.Entity;
using Legendigital.Framework.Common.Web.UI;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Commons
{
    public abstract class TreeItemWrapper<DomainType, ServiceProxyType, WrapperType, EntityKeyType> : BaseSpringNHibernateWrapper<DomainType, ServiceProxyType, WrapperType, EntityKeyType>, ITreeItemWrapper
        where DomainType : BaseTableEntity<EntityKeyType>
        where ServiceProxyType : IBaseSpringNHibernateEntityServiceProxy<DomainType, EntityKeyType>
        where WrapperType : TreeItemWrapper<DomainType, ServiceProxyType, WrapperType, EntityKeyType>, ITreeItemWrapper
    {
 

        #region Construtor

        protected TreeItemWrapper(DomainType entityObj)
            : base(entityObj)
        {
        }

        #endregion

        public abstract List<ITreeItemWrapper> FindAllItems();
        public abstract ITreeItemWrapper ParentDataItemID { get; }

        public abstract string NodeName { get; }
        public abstract string NodeCode { get; }

        public bool CheckIsRoot(WrapperType obj)
        {
            return obj.ParentDataItemID == null;
        }

        public object DataKeyId {
            get { return this.GetDataEntityKey(); }
        }

        protected TypedTreeNodeItem<WrapperType> GetTreeNodeItemByDataItem(WrapperType item, TypedTreeNodeItem<WrapperType> pnode)
        {
            TypedTreeNodeItem<WrapperType> topnode = new TypedTreeNodeItem<WrapperType>();

            topnode.Id = item.DataKeyId.ToString();
            topnode.Name = item.NodeName;
            topnode.DataItem = item;
            topnode.ParentNode = pnode;

            return topnode;
        }

        public List<TypedTreeNodeItem<WrapperType>> GetAllTreeItems()
        {
            List<TypedTreeNodeItem<WrapperType>> nodes = new List<TypedTreeNodeItem<WrapperType>>();

            List<WrapperType> allItems = FindAllWrapperItems();

            if (allItems == null || allItems.Count <= 0)
                return nodes;

            List<WrapperType> topItems = allItems.FindAll(p => (CheckIsRoot(p)));

            foreach (WrapperType topItem in topItems)
            {
                TypedTreeNodeItem<WrapperType> topnode = GetTreeNodeItemByDataItem(topItem, null);

                AddSubItems(topnode, topItem, allItems);

                nodes.Add(topnode);
            }

            return nodes;
        }

        private List<WrapperType> FindAllWrapperItems()
        {
            List<ITreeItemWrapper> treeItems = FindAllItems();

            List<WrapperType> wrappers = new List<WrapperType>();

            foreach (ITreeItemWrapper treeItemWrapper in treeItems)
            {
                WrapperType wrapper = treeItemWrapper as WrapperType;

               if(wrapper!=null)
                   wrappers.Add(wrapper);
            }

            return wrappers;
        }

        public void AddSubItems(TypedTreeNodeItem<WrapperType> mnode, WrapperType mainItem, List<WrapperType> items)
        {
            List<WrapperType> subItems = items.FindAll(p => CheckGetSubItems(p, mainItem));

            foreach (WrapperType subItem in subItems)
            {
                TypedTreeNodeItem<WrapperType> subnode = GetTreeNodeItemByDataItem(subItem, mnode);

                AddSubItems(subnode, subItem, items);

                mnode.SubNodes.Add(subnode);
            }

        }

        protected bool CheckGetSubItems(WrapperType subitem, WrapperType mainItem)
        {
            if (subitem.ParentDataItemID==null)
            {
                return (mainItem == null || mainItem.DataKeyId.ToString() == "0");
            }
            return subitem.ParentDataItemID.DataKeyId.ToString() == mainItem.DataKeyId.ToString();
        }


    }
}
