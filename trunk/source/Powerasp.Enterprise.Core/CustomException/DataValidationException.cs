using System;
using System.Collections.Generic;
using System.Text;

namespace Powerasp.Enterprise.Core.CustomException
{
    public class DataValidationException : System.Exception
    {
        public DataValidationException(string message)
            : base(message)
        {
        }
    }
}
