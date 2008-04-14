using System;
using System.Security.Cryptography;
using Powerasp.Enterprise.Core.Security.Cryptography;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public class MACTripleDESGenerator : KeyHashAlgorithmGenerator
    {
        public MACTripleDESGenerator() : base(new MACTripleDES())
        {
        }

        public MACTripleDESGenerator(byte[] key) : base(new MACTripleDES(key))
        {
        }

        protected override void CheckForKeyLength(byte[] key)
        {
            if ((key.Length != 0x10) && (key.Length != 0x18))
            {
                throw new ArgumentException("Invaild key length");
            }
            base.CheckForKeyLength(key);
        }
    }
}