using System.Security.Cryptography;
using Powerasp.Enterprise.Core.Security.Cryptography;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public class SHA1Generator : HashGenerator
    {
        public SHA1Generator() : base(new SHA1Managed())
        {
        }
    }
}