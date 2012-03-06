using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPS.Bussiness.Code
{
    public class SPInterceptRateCache
    {
        private SPInterceptRateCache()
        {
        }

        private static SPInterceptRateCache interceptRateCache;
        private static object _lock = new object();

        public SPInterceptRateCache CurrentInterceptRateCache
        {
            get
            {
                if (interceptRateCache == null)
                {
                    lock (_lock)
                    {
                        if (interceptRateCache == null)
                        {
                            interceptRateCache = new SPInterceptRateCache();
                        }
                    }
                }
                return interceptRateCache;
            }
        }




    }
}
