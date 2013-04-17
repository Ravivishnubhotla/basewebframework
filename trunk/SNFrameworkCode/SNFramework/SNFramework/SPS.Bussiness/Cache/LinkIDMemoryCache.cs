using System;
using System.Collections.Generic;
using Common.Logging;

namespace SPS.Bussiness.Cache
{
    public class LinkIDMemoryCache : ILinkIDCache
    {
        private static ILog logger = LogManager.GetLogger(typeof(LinkIDMemoryCache));

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

        protected const int MaxCacheItems = 800000;

        public void AddLinkIDs(string linkid, int channelid)
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

        public bool CheckLinkIDIsExisted(string linkid, int channelid)
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
