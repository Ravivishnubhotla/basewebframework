namespace Powerasp.Enterprise.Core.Caching
{
    public interface IObjectPool
    {
        bool Contains(object key);
        void ForceFree();
        object GetObject(object key);
        void SetObject(object key, object obj);

        int MaxPoolSize { get; }

        int MinPoolSize { get; }
    }
}