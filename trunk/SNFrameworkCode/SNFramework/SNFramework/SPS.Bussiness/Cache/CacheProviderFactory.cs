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
                return new PhoneAreaMemoryCache();

            return new PhoneAreaNOSQLCache();
        }
        public static ILinkIDCache GetLinkIDCache()
        {
            //if (NOSQLConfig.NoSQL_Enable)
            //    return new LinkIDMemoryCache();

            return new LinkIDNOSQLCache();
        }



        
    }
}
