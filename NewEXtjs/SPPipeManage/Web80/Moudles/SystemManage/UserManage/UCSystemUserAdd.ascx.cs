using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using System.Web.Security;

namespace Legendigital.Common.Web.Moudles.SystemManage.UserManage
{

    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSystemUserAdd")]
    public partial class UCSystemUserAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

        }

        [AjaxMethod]
        public void Show()
        {
            try
            {
                this.winSystemUserAdd.Show();
            }
            catch (Exception ex)
            {
                ScriptManager.AjaxSuccess = false;
                ScriptManager.AjaxErrorMessage = "错误信息: " + ex.Message;
            }
        }

        protected void btnSaveSystemUser_Click(object sender, AjaxEventArgs e)
        {
            string loginID = this.txtUserLoginID.Text.Trim();

            if (SystemUserWrapper.GetUserByLoginID(loginID) != null)
            {
                ScriptManager.AjaxSuccess = false;
                ScriptManager.AjaxErrorMessage = "错误信息: 用户登录ID已经存在！";
                return;
            }


            try
            {
                if (!string.IsNullOrEmpty(this.txtUserEmail.Text.Trim()))
                    Membership.CreateUser(loginID, this.txtUserPassword.Text.Trim(), this.txtUserEmail.Text.Trim());
                else
                    Membership.CreateUser(loginID, this.txtUserPassword.Text.Trim());

                SystemUserWrapper user = SystemUserWrapper.GetUserByLoginID(loginID);

                if (user != null)
                {
                    user.UserType = "SPCOM";
                    SystemUserWrapper.Update(user);
                }

                SystemUserWrapper.PatchAssignUserRoles(user, new List<string>() { SystemRoleWrapper.GetRoleByName("SPCOM").RoleID.ToString()});

                 
                winSystemUserAdd.Hide();
            }
            catch (Exception ex)
            {
                ScriptManager.AjaxSuccess = false;
                ScriptManager.AjaxErrorMessage = "错误信息: " + ex.Message;
            }
        }
    }
}