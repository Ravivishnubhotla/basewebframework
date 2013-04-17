using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPS.Bussiness.Cache
{
    public static class CacheProviderFactory
    {
        public static IPhoneAreaCache GetPhoneAreaCache()
        {
            return new PhoneAreaMemoryCache();
        }
        public static ILinkIDCache GetLinkIDCache()
        {
            return new LinkIDMemoryCache();
        }



        
    }
}
