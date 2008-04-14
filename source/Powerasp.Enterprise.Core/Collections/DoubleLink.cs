using System;

namespace Powerasp.Enterprise.Core.Collections
{
    public class DoubleLink : Link
    {
        public override void Insert(int index, object value)
        {
            if ((index < 0) || (index > base.Count))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if (base.Count == 0)
            {
                base.proot = new Node(value, null, null);
            }
            else
            {
                Node proot;
                if (index == 0)
                {
                    proot = base.proot as Node;
                    base.proot = new Node(value, null, proot);
                    proot.Previous = (Node) base.proot;
                }
                else
                {
                    Node previous;
                    if (index == base.Count)
                    {
                        previous = this.GetNode(index - 1) as Node;
                        previous.Next = new Node(value, previous, null);
                    }
                    else
                    {
                        proot = this.GetNode(index) as Node;
                        previous = proot.Previous as Node;
                        Node node2 = new Node(value, previous, proot);
                        previous.Next = node2;
                        proot.Previous = node2;
                    }
                }
            }
            base.plastIndex++;
        }

        public override void RemoveAt(int index)
        {
            if ((index < 0) || (index >= base.Count))
            {
                throw new ArgumentNullException("index");
            }
            Node node = this.GetNode(index) as Node;
            Node previous = node.Previous as Node;
            Node next = node.Next as Node;
            if (index == 0)
            {
                base.proot = next;
            }
            node = null;
            if (previous != null)
            {
                next.Previous = previous;
            }
            if (next != null)
            {
                previous.Next = next;
            }
            base.plastIndex--;
        }

        private class Node : LinkNode
        {
            private ILinkNode _previous;
            public static readonly DoubleLink.Node Empty = new DoubleLink.Node(null, null, null);

            public Node() : this(null)
            {
            }

            public Node(object value) : this(value, null, null)
            {
            }

            public Node(object value, ILinkNode previous, ILinkNode next) : base(value, next)
            {
                this._previous = previous;
            }

            public ILinkNode Previous
            {
                get
                {
                    return this._previous;
                }
                set
                {
                    this._previous = value;
                }
            }
        }
    }
}