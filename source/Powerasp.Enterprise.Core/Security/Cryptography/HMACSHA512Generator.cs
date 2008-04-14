namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public class HMACSHA512Generator : KeyHashGenerator
    {
        public HMACSHA512Generator() : base(new SHA512Generator())
        {
        }

        public HMACSHA512Generator(byte[] key) : base(new SHA512Generator())
        {
            this.Key = key;
        }

        protected override void CheckForKeyLength(byte[] key)
        {
            base.CheckForKeyLength(key);
        }
    }
}