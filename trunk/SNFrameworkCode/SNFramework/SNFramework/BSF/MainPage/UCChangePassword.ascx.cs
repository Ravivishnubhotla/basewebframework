using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Providers;
using SNFramework.BSF.AppCode;

namespace SNFramework.BSF.MainPage
{
    public partial class UCChangePassword : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChangePassword_Click(object sender, DirectEventArgs e)
        {



            if (!Membership.Provider.ValidateUser(this.ParentPage.CurrentLoginUser.UserLoginID, this.txtPassword.Text.Trim()))
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = GetLocalResourceObject("msgPasswordInvalid").ToString();
                return;
            }

            if (!((NHibernateMembershipProvider)Membership.Provider).ChangePassword(this.ParentPage.CurrentLoginUser.UserLoginID, this.txtNewPassword.Text.Trim()))
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = GetLocalResourceObject("msgPasswordChangeFailed").ToString();
                return;
            }


            ResourceManager.AjaxSuccess = true;
        }
    }
}