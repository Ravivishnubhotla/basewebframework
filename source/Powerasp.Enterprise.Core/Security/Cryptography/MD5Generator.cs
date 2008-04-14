using System.Security.Cryptography;
using Powerasp.Enterprise.Core.Security.Cryptography;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public class MD5Generator : HashGenerator
    {
        public MD5Generator() : base(new MD5CryptoServiceProvider())
        {
        }
    }
}