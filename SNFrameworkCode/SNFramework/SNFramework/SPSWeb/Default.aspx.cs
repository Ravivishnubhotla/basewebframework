using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Legendigital.Framework.Common.Securitys.SSO;
using SPSWeb.AppCode;

namespace SPSWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SSOConfig.SystemAuthenticationMode == SSOConfig.AuthenticationMode.SSOMode)
            {
                SSOProvider.RedirectToBSFDefaultUrl(this);
            }
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}