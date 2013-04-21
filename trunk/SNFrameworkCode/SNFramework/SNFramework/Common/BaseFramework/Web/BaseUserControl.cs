using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Legendigital.Framework.Common.Securitys.SSO;
using Spring.Web.UI;

namespace Legendigital.Framework.Common.BaseFramework.Web
{
    public class BaseUserControl : System.Web.UI.UserControl
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