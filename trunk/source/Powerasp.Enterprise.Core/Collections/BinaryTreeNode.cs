using System;

namespace Powerasp.Enterprise.Core.Collections
{
    public class BinaryTreeNode : TreeNodeBase
    {
        public BinaryTreeNode() : this(null)
        {
        }

        public BinaryTreeNode(object obj) : this(obj, Empty, Empty)
        {
        }

        public BinaryTreeNode(object obj, ITreeNode left, ITreeNode right)
        {
            base.pvalue = obj;
            base.AddNode(left);
            base.AddNode(right);
        }

        protected BinaryTreeNode GetChildNode(int index)
        {
            if ((index < 0) || (index >= 2))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            BinaryTreeNode node = this[index] as BinaryTreeNode;
            if (node == null)
            {
                return null;
            }
            return node;
        }

        internal static BinaryTreeNode Empty
        {
            get
            {
                return new BinaryTreeNode(null, null, null);
            }
        }

        public BinaryTreeNode LeftChild
        {
            get
            {
                return this.GetChildNode(0);
            }
            set
            {
                this[0] = value;
            }
        }

        protected override int MaxDegree
        {
            get
            {
                return 2;
            }
        }

        public BinaryTreeNode RightChild
        {
            get
            {
                return this.GetChildNode(1);
            }
            set
            {
                this[1] = value;
            }
        }
    }
}