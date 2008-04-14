using System.Security.Cryptography;
using Powerasp.Enterprise.Core.Security.Cryptography;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public class SHA256Generator : HashGenerator
    {
        public SHA256Generator() : base(new SHA256Managed())
        {
        }
    }
}