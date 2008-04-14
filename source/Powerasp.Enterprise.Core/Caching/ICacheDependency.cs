namespace Powerasp.Enterprise.Core.Caching
{
    public interface ICacheDependency
    {
        bool HasChanged { get; }
    }
}