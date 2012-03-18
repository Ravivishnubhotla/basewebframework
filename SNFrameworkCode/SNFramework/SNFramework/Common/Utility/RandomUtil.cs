using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Utility
{
    public static class RandomUtil
    {
        public static bool CaculteRandom(int randomNumber)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());

            return (random.Next(0, 99) <= randomNumber);
        }
    }
}
