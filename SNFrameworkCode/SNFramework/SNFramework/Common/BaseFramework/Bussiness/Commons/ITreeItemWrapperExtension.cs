using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Legendigital.Framework.Common.Web.UI;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Commons
{
    public static class ITreeItemWrapperExtension
    {
        public static List<TypedTreeNodeItem<ITreeItemWrapper>> GetAllTreeItems(this ITreeItemWrapper self)
        {
            List<TypedTreeNodeItem<ITreeItemWrapper>> nodes = new List<TypedTreeNodeItem<ITreeItemWrapper>>();

            List<ITreeItemWrapper> allItems = self.FindAllItems();

            if (allItems == null || allItems.Count <= 0)
                return nodes;

            List<ITreeItemWrapper> topItems = allItems.FindAll(p => (self.CheckIsRoot(p)));

            foreach (ITreeItemWrapper topItem in topItems)
            {
                TypedTreeNodeItem<ITreeItemWrapper> topnode = self.GetTreeNodeItemByDataItem(topItem, null);

                self.AddSubItems(topnode, topItem, allItems);

                nodes.Add(topnode);
            }

            return nodes;
        }

        public static void AddSubItems(this ITreeItemWrapper self,TypedTreeNodeItem<ITreeItemWrapper> mnode, ITreeItemWrapper mainItem, List<ITreeItemWrapper> items)
        {
            List<ITreeItemWrapper> subItems = items.FindAll(p => self.CheckGetSubItems(p, mainItem));

            foreach (ITreeItemWrapper subItem in subItems)
            {
                TypedTreeNodeItem<ITreeItemWrapper> subnode = self.GetTreeNodeItemByDataItem(subItem, mnode);

                self.AddSubItems(subnode, subItem, items);

                mnode.SubNodes.Add(subnode);
            }

        }

        public static bool CheckIsRoot(this ITreeItemWrapper self, ITreeItemWrapper obj)
        {
            if (obj == null)
                return false;
            return (obj.ParentDataItemID == null);
        }

        public static TypedTreeNodeItem<ITreeItemWrapper> GetTreeNodeItemByDataItem(this ITreeItemWrapper self, ITreeItemWrapper item, TypedTreeNodeItem<ITreeItemWrapper> pnode)
        {
            TypedTreeNodeItem<ITreeItemWrapper> node = new TypedTreeNodeItem<ITreeItemWrapper>();
            node.Id = item.DataKeyId.ToString();
            node.Name = item.Name;
            node.Code = item.Code;
            node.DataItem = item.ParentDataItemID;
            node.ParentNode = pnode;
            return node;
        }

        public static bool CheckGetSubItems(this ITreeItemWrapper self, ITreeItemWrapper subitem, ITreeItemWrapper mainItem)
        {
            return (subitem.ParentDataItemID != null) && (subitem.ParentDataItemID.DataKeyId.ToString().Equals(mainItem.DataKeyId.ToString()));
        }
    }
}
