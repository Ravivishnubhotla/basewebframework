using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Web.UI
{
    public class TypedTreeNodeItem<T>
    {
        private string id;
        private string name;
        private TypedTreeNodeItem<T> parentNode;
        private List<TypedTreeNodeItem<T>> subNodes = new List<TypedTreeNodeItem<T>>();
        private T dataitem;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public TypedTreeNodeItem<T> ParentNode
        {
            get { return parentNode; }
            set { parentNode = value; }
        }

        public T DataItem
        {
            get { return dataitem; }
            set { dataitem = value; }
        }

        public List<TypedTreeNodeItem<T>> SubNodes
        {
            get { return subNodes; }
            set { subNodes = value; }
        }
    }
}
