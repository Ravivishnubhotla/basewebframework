using System;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public class WeakKeyException : Exception
    {
        public WeakKeyException(string message) : base(message)
        {
        }
    }
}