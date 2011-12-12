using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Providers;
 

namespace Legendigital.Common.Web.Moudles.SystemManage.UserManage
{
    public partial class SystemUserChangePwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChangePassword_Click(object sender, AjaxEventArgs e)
        {
            if (UserID != 0)
            {
                string loginID = SystemUserWrapper.FindById(UserID).UserLoginID;
                if (!((NHibernateMembershipProvider)Membership.Provider).ChangePassword(loginID, this.txtNewPassword.Text.Trim()))
                {
                    ScriptManager.AjaxSuccess = false;
                    ScriptManager.AjaxErrorMessage = "修改密码失败！";
                    return;
                }
            }

            ScriptManager.AjaxSuccess = true;
        }

        public int UserID
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString["UserID"]))
                {
                    return Convert.ToInt32(this.Request.QueryString["UserID"]);
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}