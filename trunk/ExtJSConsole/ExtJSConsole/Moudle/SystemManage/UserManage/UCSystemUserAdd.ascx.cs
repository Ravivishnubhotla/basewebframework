using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Web.ControlHelper;
using MenuItem=System.Web.UI.WebControls.MenuItem;

namespace ExtJSConsole.Moudle.SystemManage.UserManage
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSystemUserAdd")]
    public partial class UCSystemUserAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSystemUser_Click(object sender, AjaxEventArgs e)
        {
            string loginID = this.txtUserLoginID.Text.Trim();

            if (SystemUserWrapper.GetUserByLoginID(loginID)!=null)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：用户登录ID已存在！";
                return;
            }


            try
            {

                if(!string.IsNullOrEmpty(this.txtUserEmail.Text.Trim()))
                    Membership.CreateUser(loginID, this.txtUserPassword.Text.Trim(), this.txtUserEmail.Text.Trim());
                else
                    Membership.CreateUser(loginID, this.txtUserPassword.Text.Trim());


                SystemUserWrapper obj = SystemUserWrapper.GetUserByLoginID(loginID);


                if (obj!=null)
                {
                    obj.UserName = this.txtUserName.Text.Trim();
                    obj.Comments = this.txtComments.Text.Trim();

                    SystemUserWrapper.Update(obj);
                }


                winSystemUserAdd.Hide();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }

}