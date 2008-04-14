using Powerasp.Enterprise.Core.Collections;

namespace Powerasp.Enterprise.Core.Collections
{
    public abstract class LinkNode : ILinkNode
    {
        private ILinkNode _next;
        private object _value;

        protected LinkNode(object value, ILinkNode next)
        {
            this._value = value;
            this._next = next;
        }

        public ILinkNode Next
        {
            get
            {
                return this._next;
            }
            set
            {
                this._next = value;
            }
        }

        public object Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }
}