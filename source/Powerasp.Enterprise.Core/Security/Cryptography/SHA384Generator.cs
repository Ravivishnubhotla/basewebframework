using System.Security.Cryptography;
using Powerasp.Enterprise.Core.Security.Cryptography;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public class SHA384Generator : HashGenerator
    {
        public SHA384Generator() : base(new SHA384Managed())
        {
        }
    }
}