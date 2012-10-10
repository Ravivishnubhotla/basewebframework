using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Legendigital.Framework.Common.Securitys.SSO;

namespace SPSWeb.MainPage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SSOConfig.SystemAuthenticationMode == SSOConfig.AuthenticationMode.SSOMode)
            {
                SSOProvider.RedirectToBSFLoginUrl(this);
            }
        }
    }
}