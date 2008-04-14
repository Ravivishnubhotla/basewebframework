using System;
using System.Collections;
using Powerasp.Enterprise.Core.Collections;

namespace Powerasp.Enterprise.Core.Collections
{
    public abstract class Link : ILink, IList, ICollection, IEnumerable
    {
        protected int plastIndex = 0;
        protected ILinkNode proot = null;

        protected Link()
        {
        }

        public int Add(object value)
        {
            this.Insert(this.Count, value);
            return (this.Count - 1);
        }

        public void AddRange(ICollection collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            foreach (object obj2 in collection)
            {
                this.Add(obj2);
            }
        }

        public void Clear()
        {
            this.plastIndex = 0;
            this.proot = null;
            GC.Collect();
        }

        public bool Contains(object value)
        {
            if (this.IndexOf(value) < 0)
            {
                return false;
            }
            return true;
        }

        public void CopyTo(Array array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if ((index < 0) || (index >= this.Count))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if (array.Length < (this.Count - index))
            {
                throw new ArgumentOutOfRangeException("array is of insufficient size.");
            }
            ILinkNode next = this.GetNode(index);
            for (int i = index; i < this.Count; i++)
            {
                array.SetValue(next.Value, (int) (index - (index - i)));
                next = next.Next;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new LinkEnumerator(this);
        }

        protected internal virtual ILinkNode GetNode(int index)
        {
            if ((index < 0) || (index >= this.Count))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            ILinkNode proot = this.proot;
            for (int i = 0; i < index; i++)
            {
                proot = proot.Next;
            }
            return proot;
        }

        public int IndexOf(object value)
        {
            ILinkNode proot = this.proot;
            for (int i = 0; i < this.Count; i++)
            {
                if (proot.Value == value)
                {
                    return i;
                }
                proot = proot.Next;
            }
            return -1;
        }

        public abstract void Insert(int index, object value);
        public void Remove(object value)
        {
            int index = this.IndexOf(value);
            if (index == -1)
            {
                throw new ArgumentException("Not exist object in link.");
            }
            this.RemoveAt(index);
        }

        public abstract void RemoveAt(int index);

        public int Count
        {
            get
            {
                return this.plastIndex;
            }
        }

        public virtual bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public virtual bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public object this[int index]
        {
            get
            {
                if ((index < 0) || (index > this.Count))
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                return this.GetNode(index).Value;
            }
            set
            {
                if ((index < 0) || (index > this.Count))
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                this.GetNode(index).Value = value;
            }
        }

        public virtual object SyncRoot
        {
            get
            {
                return this;
            }
        }

        public class LinkEnumerator : IEnumerator
        {
            private ILinkNode _current;
            private int _index;
            private Link _link;

            internal LinkEnumerator(Link link)
            {
                if (link == null)
                {
                    throw new ArgumentNullException("link");
                }
                this._link = link;
                this._index = -1;
                this._current = null;
            }

            public bool MoveNext()
            {
                if (this._index >= (this._link.Count - 1))
                {
                    return false;
                }
                if (this._index++ == -1)
                {
                    this._current = this._link.GetNode(0);
                }
                else
                {
                    this._current = this._current.Next;
                }
                return true;
            }

            public void Reset()
            {
                this._index = -1;
                this._current = null;
            }

            public object Current
            {
                get
                {
                    return this._current.Value;
                }
            }
        }
    }
}