namespace SPS.Bussiness.Cache
{
    public interface ILinkIDCache
    {
        void AddLinkIDs(string linkid, int channelid);
        bool CheckLinkIDIsExisted(string linkid, int channelid);
    }
}