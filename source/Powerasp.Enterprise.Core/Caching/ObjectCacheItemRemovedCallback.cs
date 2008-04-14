namespace Powerasp.Enterprise.Core.Caching
{
    public delegate void ObjectCacheItemRemovedCallback(object key, object value, ObjectCacheItemRemovedReason reason);
}