using System;
using System.Collections;
using Powerasp.Enterprise.Core.Collections;

namespace Powerasp.Enterprise.Core.Collections
{
    public abstract class SetBase : ISet, ICollection, IEnumerable, ICloneable
    {
        protected SetBase()
        {
        }

        public abstract void Add(object obj);
        public void AddRange(object[] objs)
        {
            for (int i = 0; i < objs.Length; i++)
            {
                this.Add(objs[i]);
            }
        }

        public void AddRange(ICollection c)
        {
            foreach (object obj2 in c)
            {
                this.Add(obj2);
            }
        }

        public abstract void Clear();
        public object Clone()
        {
            ISet set = (ISet) Activator.CreateInstance(base.GetType());
            set.AddRange(this);
            return set;
        }

        public abstract bool Contain(object obj);
        public abstract void CopyTo(Array array, int index);
        public virtual ISet ExclusiveOr(ISet s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            ISet set = this.Clone() as ISet;
            if (set == null)
            {
                throw new ArgumentException("Invoke ISet.Clone error.");
            }
            foreach (object obj2 in s)
            {
                if (set.Contain(obj2))
                {
                    set.Remove(obj2);
                    continue;
                }
                set.Add(obj2);
            }
            return set;
        }

        public static ISet ExclusiveOr(ISet s1, ISet s2)
        {
            return s1.ExclusiveOr(s2);
        }

        public abstract IEnumerator GetEnumerator();
        public virtual ISet Intersect(ISet s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            ISet set = this.Union(s);
            if (set == null)
            {
                throw new ArgumentException("Invoke ISet.Union error.");
            }
            ArrayList list = new ArrayList();
            foreach (object obj2 in set)
            {
                if (this.Contain(obj2) && s.Contain(obj2))
                {
                    continue;
                }
                list.Add(obj2);
            }
            set.RemoveRange(list.ToArray());
            return set;
        }

        public static ISet Intersect(ISet s1, ISet s2)
        {
            return s1.Intersect(s2);
        }

        public virtual ISet Minus(ISet s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            ISet set = this.Clone() as ISet;
            if (set == null)
            {
                throw new ArgumentException("Invoke ISet.Clone error.");
            }
            foreach (object obj2 in s)
            {
                if (set.Contain(obj2))
                {
                    set.Remove(obj2);
                }
            }
            return set;
        }

        public static ISet Minus(ISet s1, ISet s2)
        {
            return s1.Minus(s2);
        }

        public static SetBase operator +(SetBase s1, SetBase s2)
        {
            return (Union(s1, s2) as SetBase);
        }

        public static SetBase operator &(SetBase s1, SetBase s2)
        {
            return (Union(s1, s2) as SetBase);
        }

        public static SetBase operator |(SetBase s1, SetBase s2)
        {
            return (Intersect(s1, s2) as SetBase);
        }

        public static SetBase operator /(SetBase s1, SetBase s2)
        {
            return (ExclusiveOr(s1, s2) as SetBase);
        }

        public static SetBase operator ^(SetBase s1, SetBase s2)
        {
            return (ExclusiveOr(s1, s2) as SetBase);
        }

        public static SetBase operator *(SetBase s1, SetBase s2)
        {
            return (Intersect(s1, s2) as SetBase);
        }

        public static SetBase operator -(SetBase s1, SetBase s2)
        {
            return (Minus(s1, s2) as SetBase);
        }

        public abstract void Remove(object obj);
        public void RemoveRange(object[] objs)
        {
            for (int i = 0; i < objs.Length; i++)
            {
                this.Remove(objs[i]);
            }
        }

        public void RemoveRange(ICollection c)
        {
            foreach (object obj2 in c)
            {
                this.Remove(obj2);
            }
        }

        public object[] ToArray()
        {
            ArrayList list = new ArrayList();
            foreach (object obj2 in this)
            {
                list.Add(obj2);
            }
            return list.ToArray();
        }

        public Array ToArray(Type type)
        {
            ArrayList list = new ArrayList();
            foreach (object obj2 in this)
            {
                list.Add(obj2);
            }
            return list.ToArray(type);
        }

        public virtual ISet Union(ISet s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            ISet set = this.Clone() as ISet;
            if (set == null)
            {
                throw new ArgumentException("Invoke ISet.Clone error.");
            }
            set.AddRange(s);
            return set;
        }

        public static ISet Union(ISet s1, ISet s2)
        {
            return s1.Union(s2);
        }

        public abstract int Count { get; }

        public abstract bool IsSynchronized { get; }

        public abstract object SyncRoot { get; }
    }
}