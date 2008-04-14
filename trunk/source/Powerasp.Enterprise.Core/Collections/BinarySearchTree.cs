using System;

namespace Powerasp.Enterprise.Core.Collections
{
    public class BinarySearchTree : TreeBase
    {
        public BinarySearchTree() : base(null)
        {
        }

        public BinarySearchTree(IComparable obj) : base(new BSTreeNode(obj))
        {
        }

        public void Add(IComparable obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            int num2 = -1;
            BSTreeNode node = new BSTreeNode(obj);
            BSTreeNode root = base.Root as BSTreeNode;
            BSTreeNode node3 = null;
            while (root != null)
            {
                int num = obj.CompareTo(root.Value);
                if (num == 0)
                {
                    return;
                }
                if (num > 0)
                {
                    node3 = root;
                    root = root.LeftChild;
                    num2 = 0;
                }
                else if (num < 0)
                {
                    node3 = root;
                    root = root.RightChild;
                    num2 = 1;
                }
                if (node3 == null)
                {
                    base.proot = node;
                }
                else
                {
                    node3[num2] = node;
                }
            }
        }

        public void Delete(IComparable obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            int num = 0;
            BSTreeNode root = base.Root as BSTreeNode;
            BSTreeNode node2 = null;
            while (root == null)
            {
                num = ((IComparable) root.Value).CompareTo(obj);
                if (num == 0)
                {
                    break;
                }
                if (num > 0)
                {
                    node2 = root;
                    root = root.LeftChild;
                }
                else
                {
                    node2 = root;
                    root = root.RightChild;
                }
            }
            if (root == null)
            {
                throw new Exception("Item to be deleted does not exist in the BST.");
            }
            if (root.RightChild == null)
            {
                if (node2 == null)
                {
                    base.proot = root.LeftChild;
                }
                else
                {
                    num = ((IComparable) node2.Value).CompareTo(root.Value);
                    if (num > 0)
                    {
                        node2[0] = root.LeftChild;
                    }
                    else if (num < 0)
                    {
                        node2[1] = root.LeftChild;
                    }
                }
            }
            else if (root.RightChild.LeftChild == null)
            {
                if (node2 == null)
                {
                    base.proot = root.RightChild;
                }
                else
                {
                    num = ((IComparable) node2.Value).CompareTo(root.Value);
                    if (num > 0)
                    {
                        node2[0] = root.RightChild;
                    }
                    else if (num < 0)
                    {
                        node2[1] = root.RightChild;
                    }
                }
            }
            else
            {
                BSTreeNode leftChild = root.RightChild.LeftChild;
                BSTreeNode rightChild = root.RightChild;
                while (leftChild.LeftChild != null)
                {
                    rightChild = leftChild;
                    leftChild = leftChild.LeftChild;
                }
                rightChild[0] = leftChild.RightChild;
                leftChild[0] = root.LeftChild;
                leftChild[1] = root.RightChild;
                if (node2 == null)
                {
                    base.proot = leftChild;
                }
                else
                {
                    num = ((IComparable) node2.Value).CompareTo(root.Value);
                    if (num > 0)
                    {
                        node2[0] = leftChild;
                    }
                    else if (num < 0)
                    {
                        node2[1] = leftChild;
                    }
                }
            }
        }

        public virtual BSTreeNode Search(IComparable obj)
        {
            return this.Search(base.Root as BSTreeNode, obj);
        }

        protected virtual BSTreeNode Search(BSTreeNode current, IComparable obj)
        {
            if (current == null)
            {
                return null;
            }
            int num = ((IComparable) current.Value).CompareTo(obj);
            if (num == 0)
            {
                return current;
            }
            if (num > 0)
            {
                return this.Search(current.LeftChild, obj);
            }
            return this.Search(current.RightChild, obj);
        }
    }
}