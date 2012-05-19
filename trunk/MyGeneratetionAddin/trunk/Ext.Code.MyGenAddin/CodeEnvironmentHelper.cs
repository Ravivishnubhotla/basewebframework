using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Code.MyGenAddin
{
    public static class CodeEnvironmentHelper
    {
        public static string MachineName
        {
            get { return System.Environment.MachineName; }
        }

        public static string DomainName
        {
            get { return System.Environment.UserDomainName ; }
        }

        public static string CurrentUserName
        {
            get { return System.Environment.UserName ; }
        }

        public static string CurrentDateTime
        {
            get { return System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"); }
        }
 
    }
}
