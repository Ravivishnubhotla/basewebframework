using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD.SPPipeManage.Bussiness.Wrappers
{
    public static class LinkIDQueryCache
    {
        public static HashSet<string> cachedLinkIDs;

        private static void GetDbCachedLinkIDs()
        {
            cachedLinkIDs = new HashSet<string>();
        }

        private static HashSet<string> CachedLinkIDs 
        {
            get
            {
                if (cachedLinkIDs == null)
                {
                    GetDbCachedLinkIDs();
                }
                return cachedLinkIDs;
            }
        }

        public const int MaxCacheItems = 600000;

        public static void AddLinkIDs(string linkid, int channelid)
        {

            try
            {
                string key = GetKey(channelid, linkid);

                if(!CachedLinkIDs.Contains(key))
                {
                    CachedLinkIDs.Add(key);
                }


                if (CachedLinkIDs.Count > MaxCacheItems)
                {
                    GetDbCachedLinkIDs();
                }
            }
            catch 
            {
                 
            }
        }

        private static string GetKey(int channelid, string linkid)
        {
            return channelid.ToString("D5") + "-" + linkid;
        }

        public static bool CheckLinkIDIsExisted(string linkid, int channelid)
        {
            try
            {
                string key = GetKey(channelid, linkid);

                return CachedLinkIDs.Contains(key);
            }
            catch
            {
                return false;
            }
        }


    }
}
