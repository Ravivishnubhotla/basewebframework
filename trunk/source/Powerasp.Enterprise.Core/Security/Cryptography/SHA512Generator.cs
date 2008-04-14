using System.Security.Cryptography;
using Powerasp.Enterprise.Core.Security.Cryptography;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public class SHA512Generator : HashGenerator
    {
        public SHA512Generator() : base(new SHA512Managed())
        {
        }
    }
}