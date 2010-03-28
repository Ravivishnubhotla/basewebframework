using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;

namespace ExtJSConsole.Moudle.SystemManage.RoleManage
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSystemRoleEdit")]
    public partial class UCSystemRoleEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SystemRoleWrapper obj = SystemRoleWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtRoleName.Text = obj.RoleName.ToString();
                    this.txtRoleDescription.Text = obj.RoleDescription.ToString();
                    this.chkRoleIsSystemRole.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.RoleIsSystemRole);



                    hidSystemRoleID.Text = id.ToString();


                    winSystemRoleEdit.Show();

                }
                else
                {
                    ScriptManager.AjaxSuccess = false;
                    ScriptManager.AjaxErrorMessage = "错误信息：数据不存在";
                    return;
                }
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }
        }

        protected void btnSaveSystemRole_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SystemRoleWrapper obj = SystemRoleWrapper.FindById(int.Parse(hidSystemRoleID.Text.Trim()));
                obj.RoleName = this.txtRoleName.Text.Trim();
                obj.RoleDescription = this.txtRoleDescription.Text.Trim();
                obj.RoleIsSystemRole = this.chkRoleIsSystemRole.Checked;

                SystemRoleWrapper.Update(obj);

                winSystemRoleEdit.Hide();
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }

        }
    }


}