using System;

namespace Powerasp.Enterprise.Core.Collections
{
    public class BSTreeNode : TreeNodeBase
    {
        internal BSTreeNode(IComparable obj)
        {
            base.pvalue = obj;
            base.AddNode(null);
            base.AddNode(null);
        }

        protected BSTreeNode GetChildNode(int index)
        {
            if ((index < 0) || (index >= 2))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            BSTreeNode node = this[index] as BSTreeNode;
            if (node == null)
            {
                this[index] = null;
            }
            return node;
        }

        public BSTreeNode LeftChild
        {
            get
            {
                return this.GetChildNode(0);
            }
        }

        protected override int MaxDegree
        {
            get
            {
                return 2;
            }
        }

        public BSTreeNode RightChild
        {
            get
            {
                return this.GetChildNode(1);
            }
        }
    }
}