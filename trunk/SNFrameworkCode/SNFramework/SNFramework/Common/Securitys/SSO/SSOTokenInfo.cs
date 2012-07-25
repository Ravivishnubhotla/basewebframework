using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Securitys.SSO
{




    public class SSOTokenInfo
    {
        public int LoginUserKey { get; set; }
        public string LoginUserID { get; set; }
        public string Email { get; set; }
        
        public string Password { get; set; }
        public DateTime LoginDate { get; set; }
        public string IPAddress { get; set; }
        public string SSOKey { get; set; }
        public SSOUserType UserType { get; set; }
    }
}
