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

namespace Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPClientChannelSettingPatchAdd1")]
    public partial class UCSPClientChannelSettingPatchAdd1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        public int ChannleID
        {
            get
            {
                if (this.Request.QueryString["ChannleID"] == null)
                    return 0;
                return Convert.ToInt32(this.Request.QueryString["ChannleID"]);
            }
        }


        [AjaxMethod]
        public void Show()
        {
            try
            {
                this.winSPChannelClientSetingQuickAdd.Title = "快速添加指令";

                this.txtLoginID.Text = "";

                this.cmbCodeType.Disabled = false;
                this.cmbCodeType.SelectedIndex = 0;

                this.txtCode.Text = "";

                this.numOrderIndex.Text = "1";

                this.txtChannelCode.Text = "";

                this.chkHasSubCode.Checked = false;


                this.txtSubCode.Text = "";


                this.winSPChannelClientSetingQuickAdd.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }


        [AjaxMethod]
        public void ShowAddSub(int id, string subCode)
        {
            try
            {
                SPClientChannelSettingWrapper channelSettingWrapper = SPClientChannelSettingWrapper.FindById(id);

                if (channelSettingWrapper.CommandType != "3")
                {
                    Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                    Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：只有模糊指令才可以加子代码";
                    return;
                }

                this.winSPChannelClientSetingQuickAdd.Title = string.Format("为指令“{0}”快速添加子指令", channelSettingWrapper.CommandCode);

                this.txtLoginID.Text = channelSettingWrapper.ClinetID.UserLoginID + subCode;

                this.cmbCodeType.Disabled = true;
                this.cmbCodeType.SelectedIndex = 1;

                this.txtCode.Text = channelSettingWrapper.CommandCode + subCode;

                this.numOrderIndex.Text = (channelSettingWrapper.OrderIndex + 1).ToString();

                if (channelSettingWrapper.DefaultClientPrice.HasValue)
                    this.numDefaultPrice.Text = channelSettingWrapper.DefaultClientPrice.Value.ToString();
                else
                    this.numDefaultPrice.Text = "0";

                this.txtChannelCode.Text = channelSettingWrapper.ChannelCode;

                this.chkHasSubCode.Checked = false;

                this.txtSubCode.Text = "";

                this.winSPChannelClientSetingQuickAdd.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSPSendClientParams_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                string codeType = "1";
 
                if(cmbCodeType.SelectedItem!=null)
                {
                    codeType = cmbCodeType.SelectedItem.Value;
                }


                SPChannelWrapper channelWrapper = SPChannelWrapper.FindById(ChannleID);

                string mainUserLoginID = this.txtLoginID.Text.Trim();

                if (SystemUserWrapper.GetUserByLoginID(mainUserLoginID) != null)
                {
                    Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                    Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：用户登录ID“" + mainUserLoginID + "”已存在！";
                    return;
                }

                string subCode = this.txtSubCode.Text.Trim();

                List<string> subcodes = new List<string>();

                if(codeType == "2" && chkHasSubCode.Checked &&!string.IsNullOrEmpty(subCode))
                {
                    subcodes.AddRange(subCode.Split('|'));
                }

                foreach (string scode in subcodes)
                {
                    string subUserLoginID = mainUserLoginID + scode;

                    if (SystemUserWrapper.GetUserByLoginID(subUserLoginID) != null)
                    {
                        Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                        Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：用户登录ID“" + subUserLoginID + "”已存在！";
                        return;
                    }
                }

                int mainloginuserID = AddClientUser(mainUserLoginID);

                List<CodeUserID> codeUserIds = new List<CodeUserID>();

                foreach (string scode in subcodes)
                {
                    CodeUserID codeUserID = new CodeUserID();
                    codeUserID.Code = scode;
                    string subUserLoginID = mainUserLoginID + scode;
                    codeUserID.UserID = AddClientUser(subUserLoginID);
                    codeUserIds.Add(codeUserID);
                }




                SPClientWrapper.QuickAdd(this.txtLoginID.Text.Trim(), this.txtCode.Text.Trim(), channelWrapper, mainloginuserID, codeUserIds, txtChannelCode.Text.Trim(), Convert.ToInt32(this.numOrderIndex.Value), this.chkHasSubCode.Checked, codeType, this.txtAllowAndDisableArea.Text.Trim(), this.txtGetway.Text.Trim(), this.txtDayLimit.Text.Trim(), this.txtMonthLimit.Text.Trim(), this.txtSendText.Text.Trim(), Convert.ToDecimal(numDefaultPrice.Value));

                channelWrapper.RefreshChannelInfo();

                winSPChannelClientSetingQuickAdd.Hide();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        private int AddClientUser(string loginID)
        {
            Membership.CreateUser(loginID, "123456", loginID + "@163.com");


            SystemUserWrapper clientUser = SystemUserWrapper.GetUserByLoginID(loginID);

            clientUser.UserName = loginID;

            SystemUserWrapper.Update(clientUser);

            SystemRoleWrapper clientRole = SystemRoleWrapper.GetRoleByName("SPDownUser");

            SystemUserWrapper.PatchAssignUserRoles(clientUser, new List<string> { clientRole.RoleID.ToString() });

            return clientUser.UserID;
        }
    }
}