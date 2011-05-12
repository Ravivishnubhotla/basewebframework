using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Legendigital.Framework.Common.Web.UI;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Commons
{
    public abstract class TreeItemWrapper<T>
    {
        public abstract List<T> FindAllItems();

        protected abstract bool CheckIsRoot(T obj);

        protected abstract TypedTreeNodeItem<T> GetTreeNodeItemByDataItem(T item,TypedTreeNodeItem<T> pnode);






        public List<TypedTreeNodeItem<T>> GetAllTreeItems()
        {
            List<TypedTreeNodeItem<T>> nodes = new List<TypedTreeNodeItem<T>>();

            List<T> allItems = FindAllItems();

            List<T> topItems = allItems.FindAll(p => (CheckIsRoot(p)));

            foreach (T topItem in topItems)
            {
                TypedTreeNodeItem<T> topnode = GetTreeNodeItemByDataItem(topItem,null);

                AddSubItems(topnode, topItem, allItems);

                nodes.Add(topnode);
            }

            return nodes;
        }

        public void AddSubItems(TypedTreeNodeItem<T> mnode, T mainItem, List<T> items)
        {
            List<T> subItems = items.FindAll(p => CheckGetSubItems(p,mainItem));

            foreach (T subItem in subItems)
            {
                TypedTreeNodeItem<T> subnode = GetTreeNodeItemByDataItem(subItem, mnode);

                AddSubItems(subnode, subItem, items);

                mnode.SubNodes.Add(subnode);
            }

        }

        protected abstract bool CheckGetSubItems(T subitem,T mainItem);
    }
}
