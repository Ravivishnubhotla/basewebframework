using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;

namespace LD.SPPipeManage.Bussiness.Wrappers
{


    public static class LinkIDQueryCache
    {

        private static ILog logger = LogManager.GetLogger(typeof(LinkIDQueryCache));

        public static HashSet<string> cachedLinkIDs;

        private static readonly object obj = new object();

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
                    lock (obj)
                    {
                        GetDbCachedLinkIDs();
                    }
                }
                return cachedLinkIDs;
            }
        }

        public const int MaxCacheItems = 900000;

        public static void AddLinkIDs(string linkid, int channelid)
        {

            try
            {
                lock (obj)
                {
                    string key = GetKey(channelid, linkid);

                    if (!CachedLinkIDs.Contains(key))
                    {
                        CachedLinkIDs.Add(key);
                    }


                    if (CachedLinkIDs.Count > MaxCacheItems)
                    {
                        GetDbCachedLinkIDs();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
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
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }


    }
}
