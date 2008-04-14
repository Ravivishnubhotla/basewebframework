using System.Security.Cryptography;
using Powerasp.Enterprise.Core.Security.Cryptography;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public class RNGGenerator : RNDGenerator
    {
        public RNGGenerator() : base(new RNGCryptoServiceProvider())
        {
        }
    }
}