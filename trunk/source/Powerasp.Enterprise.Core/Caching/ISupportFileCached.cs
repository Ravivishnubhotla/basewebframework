namespace Powerasp.Enterprise.Core.Caching
{
    public interface ISupportFileCached
    {
        void FileReload(object state);

        string[] Files { get; }
    }
}