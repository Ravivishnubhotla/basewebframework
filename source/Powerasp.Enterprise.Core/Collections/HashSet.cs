using System;
using System.Collections;

namespace Powerasp.Enterprise.Core.Collections
{
    public class HashSet : SetBase
    {
        protected static readonly object HashObject = new object();
        protected IDictionary plist;

        public HashSet() : this(new Hashtable())
        {
        }

        public HashSet(IDictionary list)
        {
            this.plist = list;
        }

        public override void Add(object obj)
        {
            object obj2;
            this.ParseObject(obj, out obj2, out obj);
            this.Add(obj2, obj);
        }

        public virtual void Add(object key, object obj)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (this.Contain(key))
            {
                this.plist[key] = obj;
            }
            else
            {
                this.plist.Add(key, obj);
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

        protected virtual void ParseObject(object obj, out object key, out object hashObj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            key = obj;
            hashObj = obj;
        }

        public override void Remove(object obj)
        {
            object obj2;
            this.ParseObject(obj, out obj2, out obj);
            if (this.Contain(obj2))
            {
                this.plist.Remove(obj2);
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