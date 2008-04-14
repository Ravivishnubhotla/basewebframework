using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Powerasp.Enterprise.Core.Web.Security
{
    public class LoginPermissionPrincipal : IPrincipal
    {
        public LoginPermissionPrincipal(IIdentity _IID,List<string> roles)
        {
            identity = _IID;
            _roles = roles;
        }


        private IIdentity identity;
        private List<string> _roles;

        public bool IsInRole(string role)
        {
            return _roles.Contains(role);
        }

        public IIdentity Identity
        {
            get { return identity; }
        }
    }
}
