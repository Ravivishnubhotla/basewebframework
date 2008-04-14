using System;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public class InvaildKeyLengthException : Exception
    {
        public InvaildKeyLengthException(string message) : base(message)
        {
        }
    }
}