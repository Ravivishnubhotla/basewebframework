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
    public abstract class TreeItemWrapper<DomainType, ServiceProxyType, WrapperType> : BaseSpringNHibernateWrapper<DomainType, ServiceProxyType, WrapperType>
        where DomainType : BaseTableEntity
        where ServiceProxyType : IBaseSpringNHibernateEntityServiceProxy<DomainType>
        where WrapperType : BaseSpringNHibernateWrapper<DomainType, ServiceProxyType, WrapperType>
    {
        public TreeItemWrapper(DomainType entityObj) : base(entityObj)
        {
        }

        public abstract List<WrapperType> FindAllItems();

        protected abstract bool CheckIsRoot(WrapperType obj);

        protected abstract TypedTreeNodeItem<WrapperType> GetTreeNodeItemByDataItem(WrapperType item, TypedTreeNodeItem<WrapperType> pnode);






        public List<TypedTreeNodeItem<WrapperType>> GetAllTreeItems()
        {
            List<TypedTreeNodeItem<WrapperType>> nodes = new List<TypedTreeNodeItem<WrapperType>>();

            List<WrapperType> allItems = FindAllItems();

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

        protected abstract bool CheckGetSubItems(WrapperType subitem, WrapperType mainItem);
    }
}
