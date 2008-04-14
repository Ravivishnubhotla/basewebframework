namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public class HMACSHA256Generator : KeyHashGenerator
    {
        public HMACSHA256Generator() : base(new SHA256Generator())
        {
        }

        public HMACSHA256Generator(byte[] key) : base(new SHA256Generator())
        {
            this.Key = key;
        }

        protected override void CheckForKeyLength(byte[] key)
        {
            base.CheckForKeyLength(key);
        }
    }
}