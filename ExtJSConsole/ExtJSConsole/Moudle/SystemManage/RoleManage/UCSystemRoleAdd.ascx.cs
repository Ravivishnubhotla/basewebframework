using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace ExtJSConsole.Moudle.SystemManage.RoleManage
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSystemRoleAdd")]
    public partial class UCSystemRoleAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [AjaxMethod]
        public void Show()
        {
            try
            {
                this.winSystemRoleAdd.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSystemRole_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SystemRoleWrapper obj = new SystemRoleWrapper();
                obj.RoleName = this.txtRoleName.Text.Trim();
                obj.RoleDescription = this.txtRoleDescription.Text.Trim();
                obj.RoleIsSystemRole = this.chkRoleIsSystemRole.Checked;


                SystemRoleWrapper.Save(obj);

                winSystemRoleAdd.Hide();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }

}