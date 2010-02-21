using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Legendigital.Framework.Common.Utility
{
    public static class CryptographyUtil
    {
        public static string BytesToHexString(byte[] bytes)
        {
            StringBuilder builder = new StringBuilder(0x40);
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(string.Format("{0:X2}", bytes[i]));
            }
            return builder.ToString();
        }

        public static string CreateKey(int numBytes)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] data = new byte[numBytes];
            provider.GetBytes(data);
            return BytesToHexString(data);
        }
    }
}