using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.ClientGroups
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPClientGroupAdd")]
    public partial class UCSPClientGroupAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [AjaxMethod]
        public void Show()
        {
            try
            {
                this.winSPClientGroupAdd.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSPClientGroup_Click(object sender, AjaxEventArgs e)
        {
            string loginID = this.txtUserID.Text.Trim();

            if (SystemUserWrapper.GetUserByLoginID(loginID) != null)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：用户登录ID已存在！";
                return;
            }



            try
            {
                SPClientGroupWrapper obj = new SPClientGroupWrapper();
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.DefaultSycnMoUrl = this.txtDefaultSycnMoUrl.Text.Trim();
                obj.DefaultInterceptRate = Convert.ToInt32(this.txtDefaultInterceptRate.Text);
                obj.DefaultNoInterceptCount = Convert.ToInt32(this.txtDefaultNoInterceptCount.Text);

                if (cmbSelectAssignedUser.SelectedItem != null && !string.IsNullOrEmpty(cmbSelectAssignedUser.SelectedItem.Value))
                    obj.AssignedUserID = Convert.ToInt32(cmbSelectAssignedUser.SelectedItem.Value);
                else
                    obj.AssignedUserID = null;


                Membership.CreateUser(loginID, this.txtUserPass.Text.Trim(), this.txtUserID.Text.Trim() + "@163.com");


                SystemUserWrapper clientUser = SystemUserWrapper.GetUserByLoginID(loginID);

                clientUser.UserName = loginID;

                SystemUserWrapper.Update(clientUser);

                SystemRoleWrapper clientRole = SystemRoleWrapper.GetRoleByName("SPDownGroupUser");

                SystemUserWrapper.PatchAssignUserRoles(clientUser, new List<string> { clientRole.RoleID.ToString() });

                obj.UserID = clientUser.UserID;

                SPClientGroupWrapper.Save(obj);

                winSPClientGroupAdd.Hide();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }





    }
}