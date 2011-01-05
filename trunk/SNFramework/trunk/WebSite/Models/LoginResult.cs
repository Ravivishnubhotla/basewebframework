using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class LoginResult
    {
        private bool isLoginOK;
        private string resultMessage;

        public bool IsLoginOk
        {
            get { return isLoginOK; }
            set { isLoginOK = value; }
        }

        public string ResultMessage
        {
            get { return resultMessage; }
            set { resultMessage = value; }
        }
    }
}