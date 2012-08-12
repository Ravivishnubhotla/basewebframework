using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Securitys.SSO
{
    public class BaseSSOSecurityUserControl : System.Web.UI.UserControl
    {
        public BaseSSOSecurityPage ParentPage
        {
            get
            {
                return (BaseSSOSecurityPage)this.Page;
            }
        }

    }
}
