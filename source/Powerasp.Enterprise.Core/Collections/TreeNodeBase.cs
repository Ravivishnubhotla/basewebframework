using System;
using Powerasp.Enterprise.Core.Collections;

namespace Powerasp.Enterprise.Core.Collections
{
    public abstract class TreeNodeBase : ITreeNode
    {
        protected ITreeNodeList pchildren;
        protected int pdepth;
        protected int plevel;
        protected ITreeNode pparent;
        protected object pvalue;

        protected TreeNodeBase() : this(new TreeNodeList())
        {
        }

        protected TreeNodeBase(ITreeNodeList children)
        {
            this.pdepth = 0;
            this.pparent = null;
            this.pchildren = children;
        }

        protected void AddNode(ITreeNode node)
        {
            if (this.pchildren.Contains(node))
            {
                throw new ArgumentException("");
            }
            if (this.Degree >= this.MaxDegree)
            {
                throw new IndexOutOfRangeException("");
            }
            this.pchildren.Add(node);
            this.PlusDepthAndLevel(node as TreeNodeBase);
        }

        protected ITreeNode FindNode(object obj)
        {
            for (int i = 0; i < this.pchildren.Count; i++)
            {
                if (((ITreeNode) this.pchildren[i]).Value == obj)
                {
                    return (ITreeNode) this.pchildren[i];
                }
            }
            return null;
        }

        protected virtual ITreeNode GetNextNode(ITreeNode node)
        {
            if ((node != null) && !node.IsRoot)
            {
                int index = node.Parent.IndexOf(node);
                if (((index != -1) && (node.Parent.Degree != 1)) && (index != (this.Parent.Degree - 1)))
                {
                    return node.Parent.GetNode(index + 1);
                }
            }
            return null;
        }

        public virtual ITreeNode GetNode(int index)
        {
            if ((index < 0) || (index >= this.pchildren.Count))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if (this.pchildren[index] == null)
            {
                return null;
            }
            return (ITreeNode) this.pchildren[index];
        }

        protected virtual ITreeNode GetPreviousNode(ITreeNode node)
        {
            if ((node != null) && !node.IsRoot)
            {
                int index = node.Parent.IndexOf(node);
                if (((index != -1) && (node.Parent.Degree != 1)) && (index != 0))
                {
                    return node.Parent.GetNode(index - 1);
                }
            }
            return null;
        }

        protected ITreeNode GetRootNode()
        {
            return this.GetRootNode(this);
        }

        protected virtual ITreeNode GetRootNode(ITreeNode node)
        {
            if (node.IsRoot)
            {
                return node;
            }
            return this.GetRootNode(node.Parent);
        }

        public virtual int IndexOf(ITreeNode node)
        {
            for (int i = 0; i < this.pchildren.Count; i++)
            {
                if ((this.pchildren[i] != null) && this.pchildren[i].Equals(node))
                {
                    return i;
                }
            }
            return -1;
        }

        protected virtual void MinusChildLevel(TreeNodeBase node)
        {
            if (node != null)
            {
                if (node.IsRoot)
                {
                    node.plevel = 0;
                }
                else
                {
                    node.plevel = node.Parent.Level + 1;
                }
                node.plevel = this.Level + 1;
                if (node.Degree > 0)
                {
                    for (int i = 0; i < node.Degree; i++)
                    {
                        this.MinusChildLevel(node[i] as TreeNodeBase);
                    }
                }
            }
        }

        protected void MinusDepthAndLevel(TreeNodeBase childNode)
        {
            if (childNode != null)
            {
                bool flag = true;
                childNode.pparent = null;
                this.MinusChildLevel(childNode);
                if ((this.Depth == (childNode.Depth + 1)) && (this.Degree > 0))
                {
                    for (int i = 0; i < this.Degree; i++)
                    {
                        if (this[i].Depth == (this.Depth - 1))
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                if (flag)
                {
                    this.SetParentDepth(this);
                }
            }
        }

        protected virtual void PlusChildLevel(TreeNodeBase node)
        {
            if (node != null)
            {
                node.plevel = this.Level + 1;
                if (node.Degree > 0)
                {
                    for (int i = 0; i < node.Degree; i++)
                    {
                        this.PlusChildLevel(node[i] as TreeNodeBase);
                    }
                }
            }
        }

        protected void PlusDepthAndLevel(TreeNodeBase childNode)
        {
            if (childNode != null)
            {
                this.PlusChildLevel(childNode);
                childNode.pparent = this;
                this.PlusParentDepth(childNode);
            }
        }

        protected virtual void PlusParentDepth(TreeNodeBase node)
        {
            if (!this.IsRoot)
            {
                ITreeNode node2 = node;
                for (TreeNodeBase base2 = node.Parent as TreeNodeBase; base2 != null; base2 = node2.Parent as TreeNodeBase)
                {
                    if (base2.pdepth <= node2.Depth)
                    {
                        base2.pdepth = node2.Depth + 1;
                    }
                    node2 = base2;
                }
            }
        }

        public void RemoveAll()
        {
            while (this.pchildren.Count > 0)
            {
                this.RemoveAt(0);
            }
        }

        public void RemoveAt(int index)
        {
            if ((index < 0) || (index >= this.pchildren.Count))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            this.RemoveNode((ITreeNode) this.pchildren[index]);
        }

        protected void RemoveNode(ITreeNode node)
        {
            if (node == null)
            {
                throw new ArgumentException("node");
            }
            if (!this.pchildren.Contains(node))
            {
                throw new ArgumentException("node");
            }
            this.pchildren.Remove(node);
            this.MinusDepthAndLevel(node as TreeNodeBase);
        }

        protected virtual void SetNodeDepth(TreeNodeBase node)
        {
            int num = 0;
            if (node.Degree > 0)
            {
                for (int i = 0; i < node.Degree; i++)
                {
                    if (num < (node[i].Depth + 1))
                    {
                        num = node[i].Depth + 1;
                    }
                }
            }
            node.pdepth = num;
        }

        protected virtual void SetParentDepth(TreeNodeBase node)
        {
            TreeNodeBase parent = node;
            while (true)
            {
                this.SetNodeDepth(parent);
                if (parent.IsRoot)
                {
                    return;
                }
                parent = parent.Parent as TreeNodeBase;
            }
        }

        public int Degree
        {
            get
            {
                return this.pchildren.Count;
            }
        }

        public int Depth
        {
            get
            {
                return this.pdepth;
            }
        }

        public ITreeNode FirstChild
        {
            get
            {
                if (this.pchildren.Count <= 0)
                {
                    return null;
                }
                return this.GetNode(0);
            }
        }

        public bool IsChild
        {
            get
            {
                if (this.pparent == null)
                {
                    return false;
                }
                return true;
            }
        }

        public bool IsLeafe
        {
            get
            {
                if (this.pchildren.Count != 0)
                {
                    return false;
                }
                return true;
            }
        }

        public bool IsRoot
        {
            get
            {
                if (this.pparent != null)
                {
                    return false;
                }
                return true;
            }
        }

        public virtual ITreeNode this[int index]
        {
            get
            {
                if ((index < 0) || (index >= this.Degree))
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                return this.GetNode(index);
            }
            set
            {
                if ((index < 0) || (index >= this.Degree))
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                ITreeNode node = this.pchildren[index] as ITreeNode;
                if (node != value)
                {
                    this.pchildren[index] = value;
                    if (node != null)
                    {
                        this.MinusDepthAndLevel(value as TreeNodeBase);
                    }
                    if (value != null)
                    {
                        this.PlusDepthAndLevel(value as TreeNodeBase);
                    }
                }
            }
        }

        public ITreeNode LastChild
        {
            get
            {
                if (this.pchildren.Count <= 0)
                {
                    return null;
                }
                return this.GetNode(this.Degree - 1);
            }
        }

        public int Level
        {
            get
            {
                return this.plevel;
            }
        }

        protected virtual int MaxDegree
        {
            get
            {
                return 0x7fffffff;
            }
        }

        public ITreeNode NextSibling
        {
            get
            {
                return this.GetNextNode(this);
            }
        }

        public ITreeNode Parent
        {
            get
            {
                return this.pparent;
            }
            set
            {
                this.pparent = value;
            }
        }

        public ITreeNode PreviousSibling
        {
            get
            {
                return this.GetPreviousNode(this);
            }
        }

        public ITreeNode Root
        {
            get
            {
                return this.GetRootNode(this);
            }
        }

        public object Value
        {
            get
            {
                return this.pvalue;
            }
        }
    }
}