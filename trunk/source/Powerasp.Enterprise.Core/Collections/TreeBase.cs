using System;
using System.Collections;
using Powerasp.Enterprise.Core.Collections;

namespace Powerasp.Enterprise.Core.Collections
{
    public abstract class TreeBase : ITree
    {
        protected ITreeNode proot;

        protected TreeBase(ITreeNode root)
        {
            this.proot = root;
        }

        public void Clear()
        {
            if (this.Root != null)
            {
                this.Root.RemoveAll();
            }
        }

        public ITreeNode[] Find(object obj, TreeTraversal traversal)
        {
            if (this.proot == null)
            {
                return null;
            }
            ArrayList ary = new ArrayList();
            this.Traversal(this.Root, traversal, obj, true, ref ary);
            return (ITreeNode[]) ary.ToArray(typeof(ITreeNode));
        }

        protected virtual bool Found(ITreeNode node, object obj)
        {
            if (node == null)
            {
                return false;
            }
            if (node.Value == null)
            {
                return (obj == null);
            }
            return node.Value.Equals(obj);
        }

        public static void MakeNull(ITree tree)
        {
            if (!(tree is TreeBase))
            {
                throw new NotSupportedException(Powerasp.Enterprise.Core.SR.NotSupported);
            }
            ((TreeBase) tree).proot = null;
        }

        public ITreeNode[] Traversal(TreeTraversal traversal)
        {
            ArrayList ary = new ArrayList();
            this.Traversal(this.Root, traversal, null, false, ref ary);
            return (ITreeNode[]) ary.ToArray(typeof(ITreeNode));
        }

        protected virtual void Traversal(ITreeNode node, TreeTraversal traversal, object obj, bool search, ref ArrayList ary)
        {
            if (node != null)
            {
                ITreeNode firstChild = null;
                switch (traversal)
                {
                    case TreeTraversal.PreOrder:
                        if (!search || (search && this.Found(node, obj)))
                        {
                            ary.Add(node);
                        }
                        for (int i = 0; i < node.Degree; i++)
                        {
                            firstChild = (i == 0) ? node.FirstChild : firstChild.NextSibling;
                            if (firstChild != null)
                            {
                                this.Traversal(firstChild, traversal, obj, search, ref ary);
                            }
                        }
                        return;

                    case TreeTraversal.InOrder:
                        if (!node.IsLeafe)
                        {
                            firstChild = node.FirstChild;
                            if (firstChild != null)
                            {
                                this.Traversal(firstChild, traversal, obj, search, ref ary);
                            }
                            if (!search || (search && this.Found(node, obj)))
                            {
                                ary.Add(node);
                            }
                            if (node.Degree <= 1)
                            {
                                break;
                            }
                            for (int j = 1; j < node.Degree; j++)
                            {
                                firstChild = firstChild.NextSibling;
                                if (firstChild != null)
                                {
                                    this.Traversal(firstChild, traversal, obj, search, ref ary);
                                }
                            }
                            return;
                        }
                        if (search && (!search || !this.Found(node, obj)))
                        {
                            break;
                        }
                        ary.Add(node);
                        return;

                    case TreeTraversal.PostOrder:
                        for (int k = 0; k < node.Degree; k++)
                        {
                            firstChild = (k == 0) ? node.FirstChild : firstChild.NextSibling;
                            if (firstChild != null)
                            {
                                this.Traversal(firstChild, traversal, obj, search, ref ary);
                            }
                        }
                        if (!search || (search && this.Found(node, obj)))
                        {
                            ary.Add(node);
                            return;
                        }
                        break;

                    default:
                        throw new NotSupportedException(Powerasp.Enterprise.Core.SR.NotSupported);
                }
            }
        }

        public ITreeNode Root
        {
            get
            {
                return this.proot;
            }
        }
    }
}