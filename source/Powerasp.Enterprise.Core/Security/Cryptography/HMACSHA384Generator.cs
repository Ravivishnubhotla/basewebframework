namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public class HMACSHA384Generator : KeyHashGenerator
    {
        public HMACSHA384Generator() : base(new SHA384Generator())
        {
        }

        public HMACSHA384Generator(byte[] key) : base(new SHA384Generator())
        {
            this.Key = key;
        }

        protected override void CheckForKeyLength(byte[] key)
        {
            base.CheckForKeyLength(key);
        }
    }
}