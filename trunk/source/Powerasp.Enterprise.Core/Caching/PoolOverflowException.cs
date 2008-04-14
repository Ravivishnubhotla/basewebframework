using System;

namespace Powerasp.Enterprise.Core.Caching
{
    public class PoolOverflowException : OverflowException
    {
        public PoolOverflowException(string message) : base(string.Empty)
        {
        }
    }
}