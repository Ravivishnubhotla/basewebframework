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
using Legendigital.Framework.Common.BaseFramework.Web;

namespace Legendigital.Common.Web.Moudles.SPS.Channels
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "SPChannelQuickAdd")]
    public partial class SPChannelQuickAdd : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [AjaxMethod]
        public void Show()
        {
            try
            {
                this.winSPChannelQuickAdd.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }


        protected void btnSaveSPChannel_Click(object sender, AjaxEventArgs e)
        {
            if (SPChannelWrapper.GetChannelByPath(this.txtFuzzyCommand.Text.Trim()) != null)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：提交别名已存在！";
                return;
            }


            string loginID = "default" + this.txtFuzzyCommand.Text.Trim();

            if (SystemUserWrapper.GetUserByLoginID(loginID) != null)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：用户登录ID已存在！";
                return;
            }

            try
            {
                SPChannelWrapper obj = new SPChannelWrapper();
                obj.Name = this.txtName.Text.Trim();
                obj.Description = obj.Name;
                obj.Area = "";
                obj.ChannelCode = this.txtChannelCode.Text.Trim();
                obj.FuzzyCommand = this.txtFuzzyCommand.Text.Trim();
                obj.Port = "";
                obj.ChannelType = "";
                obj.Price = 0;
                obj.Rate = 0;
                obj.ChannelCodeParamsName = "cpid";
                obj.IsAllowNullLinkID = chkIsAllowNullLinkID.Checked;
                obj.Status = 0;
                obj.CreateTime = System.DateTime.Now;
                obj.CreateBy = this.ParentPage.CurrentLoginUser.UserID;
                obj.OkMessage = "ok";
                obj.FailedMessage = "failed";
                obj.RecStatReport = chkRecStatReport.Checked;
                obj.StatParamsName = txtStatParamName.Text.Trim();
                obj.StatParamsValues = txtStatValues.Text.Trim();
                obj.IsDisable = false;
                

                Membership.CreateUser(loginID, "123456", loginID + "@163.com");

                SystemUserWrapper clientUser = SystemUserWrapper.GetUserByLoginID(loginID);

                clientUser.UserName = loginID;

                SystemUserWrapper.Update(clientUser);

                SystemRoleWrapper clientRole = SystemRoleWrapper.GetRoleByName("SPDownUser");

                SystemUserWrapper.PatchAssignUserRoles(clientUser, new List<string> { clientRole.RoleID.ToString() });


                SPChannelWrapper.QuickAdd(obj, this.txtLinkParamsName.Text.Trim(), this.txtMobileParamsName.Text.Trim(),this.txtSPcodeParamsName.Text.Trim() , this.txtMoParamsName.Text.Trim(), clientUser.UserID);

                obj.RefreshChannelInfo();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }
}