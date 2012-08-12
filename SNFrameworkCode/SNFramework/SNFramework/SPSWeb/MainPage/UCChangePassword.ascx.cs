using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Providers;
using Legendigital.Framework.Common.Securitys.SSO;

namespace SPSWeb.MainPage
{
    public partial class UCChangePassword : BaseSSOSecurityUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChangePassword_Click(object sender, DirectEventArgs e)
        {



            if (!Membership.Provider.ValidateUser(this.ParentPage.CurrentTokenInfo.LoginUserID, this.txtPassword.Text.Trim()))
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = GetLocalResourceObject("msgPasswordInvalid").ToString();
                return;
            }

            if (!((NHibernateMembershipProvider)Membership.Provider).ChangePassword(this.ParentPage.CurrentTokenInfo.LoginUserID, this.txtNewPassword.Text.Trim()))
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = GetLocalResourceObject("msgPasswordChangeFailed").ToString();
                return;
            }


            ResourceManager.AjaxSuccess = true;
        }
    }
}