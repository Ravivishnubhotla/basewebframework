using System;
using Powerasp.Enterprise.Core.Collections;

namespace Powerasp.Enterprise.Core.Collections
{
    public class SingleLink : Link
    {
        public override void Insert(int index, object value)
        {
            if ((index < 0) || (index > base.Count))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if (base.Count == 0)
            {
                base.proot = new Node(value, null);
            }
            else if (index == 0)
            {
                base.proot = new Node(value, base.proot);
            }
            else if (index == base.Count)
            {
                this.GetNode(base.Count - 1).Next = new Node(value, null);
            }
            else
            {
                ILinkNode node = this.GetNode(index - 1);
                ILinkNode next = node.Next;
                node.Next = new Node(value, next);
            }
            base.plastIndex++;
        }

        public override void RemoveAt(int index)
        {
            if ((index < 0) || (index >= base.Count))
            {
                throw new ArgumentNullException("index");
            }
            ILinkNode next = this.GetNode(index).Next as Node;
            if (index > 0)
            {
                this.GetNode(index - 1).Next = next;
            }
            else
            {
                base.proot = next;
            }
            base.plastIndex--;
        }

        private class Node : LinkNode
        {
            public static readonly SingleLink.Node Empty = new SingleLink.Node(null);

            public Node() : this(null)
            {
            }

            public Node(object value) : this(value, null)
            {
            }

            public Node(object value, ILinkNode next) : base(value, next)
            {
            }
        }
    }
}