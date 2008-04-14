using System.Security.Cryptography;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public class HMACSHA1Generator : KeyHashAlgorithmGenerator
    {
        public HMACSHA1Generator() : base(new HMACSHA1())
        {
        }

        public HMACSHA1Generator(byte[] key) : base(new HMACSHA1(key))
        {
        }

        protected override void CheckForKeyLength(byte[] key)
        {
            base.CheckForKeyLength(key);
        }
    }
}