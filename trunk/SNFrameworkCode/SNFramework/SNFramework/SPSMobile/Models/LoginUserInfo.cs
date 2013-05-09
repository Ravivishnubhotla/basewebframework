using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPSMobile.Models
{
    public class LoginUserInfo
    {
        public string LoginID { get; set; }
        public string Password { get; set; }
        public bool SaveLoginStatus { get; set; }
    }
}