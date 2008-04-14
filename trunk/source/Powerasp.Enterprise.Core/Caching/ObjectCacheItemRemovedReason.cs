namespace Powerasp.Enterprise.Core.Caching
{
    public enum ObjectCacheItemRemovedReason
    {
        DependencyChanged,
        Expired,
        Removed,
        Underused
    }
}