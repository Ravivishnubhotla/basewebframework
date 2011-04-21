using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.RoleManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemRoleEdit")]
    public partial class UCSystemRoleEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SystemRoleWrapper obj = SystemRoleWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtRoleName.Text = obj.RoleName;
                    this.txtRoleDescription.Text = obj.RoleDescription;
                    this.txtRoleCode.Text = obj.RoleCode;
                    this.chkRoleIsSystemRole.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.RoleIsSystemRole);



                    hidSystemRoleID.Text = id.ToString();


                    winSystemRoleEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "错误信息：数据不存在";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(this.GetGlobalResourceObject("GlobalResource", "msgServerErrorMsg").ToString(), ex.Message);
                return;
            }
        }

        protected void btnSaveSystemRole_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemRoleWrapper obj = SystemRoleWrapper.FindById(int.Parse(hidSystemRoleID.Text.Trim()));
                obj.RoleName = this.txtRoleName.Text.Trim();
                obj.RoleCode = this.txtRoleCode.Text.Trim();
                obj.RoleDescription = this.txtRoleDescription.Text.Trim();
                obj.RoleIsSystemRole = this.chkRoleIsSystemRole.Checked;

                SystemRoleWrapper.Update(obj);

                winSystemRoleEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(this.GetGlobalResourceObject("GlobalResource", "msgServerErrorMsg").ToString(), ex.Message);
                return;
            }

        }
    }

}