using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Web.Request
{
    public class WebRequestResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string ResponseText { get; set; }
    }
}
