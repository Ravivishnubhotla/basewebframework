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
            if (NOSQLConfig.NoSQL_Enable)
                return new PhoneAreaNOSQLCache();

            return new PhoneAreaMemoryCache();
        }
        public static ILinkIDCache GetLinkIDCache()
        {
            //if (NOSQLConfig.NoSQL_Enable)
            //    return new LinkIDNOSQLCache();

            return new LinkIDMemoryCache();
        }



        
    }
}
