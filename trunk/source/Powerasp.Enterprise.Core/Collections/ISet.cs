using System;
using System.Collections;

namespace Powerasp.Enterprise.Core.Collections
{
    public interface ISet : ICollection, IEnumerable, ICloneable
    {
        void Add(object obj);
        void AddRange(ICollection c);
        void AddRange(object[] objs);
        void Clear();
        bool Contain(object obj);
        ISet ExclusiveOr(ISet s);
        ISet Intersect(ISet s);
        ISet Minus(ISet s);
        void Remove(object obj);
        void RemoveRange(ICollection c);
        void RemoveRange(object[] objs);
        object[] ToArray();
        Array ToArray(Type type);
        ISet Union(ISet s);
    }
}