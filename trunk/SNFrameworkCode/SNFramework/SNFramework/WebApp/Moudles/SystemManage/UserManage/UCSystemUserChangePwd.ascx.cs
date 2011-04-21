using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Web.Security;
using Legendigital.Framework.Common.BaseFramework.Providers;
using Legendigital.Framework.Common.BaseFramework.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.UserManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemUserChangePwd")]
    public partial class UCSystemUserChangePwd : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChangePassword_Click(object sender, DirectEventArgs e)
        {
            if (UserID != 0)
            {
                string loginID = SystemUserWrapper.FindById(UserID).UserLoginID;
                if (!((NHibernateMembershipProvider)Membership.Provider).ChangePassword(loginID, this.txtNewPassword.Text.Trim()))
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "Change Password Failed!";
                    return;
                }
            }

            ResourceManager.AjaxSuccess = true;
        }

        [DirectMethod]
        public void Show(int userID)
        {
            try
            {
                this.UserID = userID;
                this.winChangePassword.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(this.GetGlobalResourceObject("GlobalResource", "msgServerErrorMsg").ToString(), ex.Message);
            }
        }

        public int UserID
        {
            get
            {
                object obj = HiddenUserID.Value;
                int i = 0;
                if (obj != null)
                {
                    if (!String.IsNullOrEmpty(obj.ToString()))
                    {
                        i = Convert.ToInt32(obj);
                    }
                }
                return i;
            }
            set
            {
                this.HiddenUserID.Value = value;
            }
        }
    }
}