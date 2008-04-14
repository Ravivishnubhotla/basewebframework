using System;
using System.Collections;

namespace Powerasp.Enterprise.Core.Collections
{
    public class Set : SetBase
    {
        protected IList plist;

        public Set() : this(new ArrayList())
        {
        }

        public Set(IList list)
        {
            this.plist = list;
        }

        public override void Add(object obj)
        {
            if (!this.Contain(obj))
            {
                this.plist.Add(obj);
            }
        }

        public override void Clear()
        {
            this.plist.Clear();
        }

        public override bool Contain(object obj)
        {
            return this.plist.Contains(obj);
        }

        public override void CopyTo(Array array, int index)
        {
            this.plist.CopyTo(array, index);
        }

        public override IEnumerator GetEnumerator()
        {
            return this.plist.GetEnumerator();
        }

        public override void Remove(object obj)
        {
            if (this.Contain(obj))
            {
                this.plist.Remove(obj);
            }
        }

        public override int Count
        {
            get
            {
                return this.plist.Count;
            }
        }

        public override bool IsSynchronized
        {
            get
            {
                return this.plist.IsSynchronized;
            }
        }

        public override object SyncRoot
        {
            get
            {
                return this.plist.SyncRoot;
            }
        }
    }
}