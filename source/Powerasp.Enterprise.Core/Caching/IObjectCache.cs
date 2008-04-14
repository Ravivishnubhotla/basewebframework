using System;
using System.Collections;
using Powerasp.Enterprise.Core.Caching;

namespace Powerasp.Enterprise.Core.Caching
{
    public interface IObjectCache
    {
        event EventHandler ItemChanged;

        event EventHandler ItemReleased;

        void Add(object key, object value);
        void Add(object key, object value, DateTime absoluteExpiration);
        void Add(object key, object value, int seconds);
        void Add(object key, object value, TimeSpan slidingExpiration);
        void Add(object key, object value, DateTime absoluteExpiration, ICacheDependency dependency);
        void Add(object key, object value, DateTime absoluteExpiration, ICacheDependency dependency, ObjectCacheItemRemovedCallback callback);
        bool Contains(object key);
        object GetObject(object key);
        void Remove(object key);
        void SetObject(object key, object value);

        bool IsSynchronized { get; }

        object this[object key] { get; set; }

        ICollection Keys { get; }

        object SyncRoot { get; }
    }
}