using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Exceptions
{
    public class DataValidationException : Exception
    {
        public DataValidationException(string message)
            : base(message)
        {
        }
    }
}
