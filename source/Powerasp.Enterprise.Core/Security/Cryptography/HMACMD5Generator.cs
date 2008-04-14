namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public class HMACMD5Generator : KeyHashGenerator
    {
        public HMACMD5Generator() : base(new MD5Generator())
        {
        }

        public HMACMD5Generator(byte[] key) : base(new MD5Generator())
        {
            this.Key = key;
        }

        protected override void CheckForKeyLength(byte[] key)
        {
            base.CheckForKeyLength(key);
        }
    }
}