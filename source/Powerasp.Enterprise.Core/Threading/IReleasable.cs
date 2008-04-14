namespace Powerasp.Enterprise.Core.Threading
{
    public interface IReleasable
    {
        void Release();

        bool IsExpired { get; }
    }
}