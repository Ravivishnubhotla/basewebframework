using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;


namespace Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings
{
        [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPClientChannelSettingChangeClientAndUser")]
    public partial class UCSPClientChannelSettingChangeClientAndUser : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
 
        }

        protected void btnSaveSPClient_Click(object sender, AjaxEventArgs e)
        {
            try
            {

                SPClientChannelSettingWrapper obj = SPClientChannelSettingWrapper.FindById(int.Parse(hidId.Text.Trim()));

                string clientName = this.txtClientName.Text.Trim();
                string clientAlias = this.txtClientAlias.Text.Trim();
                string userID = this.txtLoginUserID.Text.Trim();
                string userPassword = this.txtLoginPassword.Text.Trim();

                //if (SPClientWrapper.FindByName(clientName) != null)
                //{
                //    Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                //    Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：存在同名的下家";
                //}

                if (SystemUserWrapper.GetUserByLoginID(userID) != null)
                {
                    Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                    Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：存在同名的登陆用户";

                    return;
                }

                int loginUserID = AddClientUser(userID, userPassword);

                int newclientID = obj.ChangeClientUser(clientName, clientAlias, userID, loginUserID);

                SPClientWrapper clientWrapper = SPClientWrapper.FindById(newclientID);

                if (obj.DefaultClientPrice.HasValue)
                    clientWrapper.SetClientPrice(obj.DefaultClientPrice.Value);

                winSPClientChannelSettingChangeClientAndUser.Hide();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }


        private int AddClientUser(string loginID,string password)
        {
            Membership.CreateUser(loginID, password, loginID + "@163.com");


            SystemUserWrapper clientUser = SystemUserWrapper.GetUserByLoginID(loginID);

            clientUser.UserName = loginID;

            SystemUserWrapper.Update(clientUser);

            SystemRoleWrapper clientRole = SystemRoleWrapper.GetRoleByName("SPDownUser");

            SystemUserWrapper.PatchAssignUserRoles(clientUser, new List<string> { clientRole.RoleID.ToString() });

            return clientUser.UserID;
        }

        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SPClientChannelSettingWrapper obj = SPClientChannelSettingWrapper.FindById(id);

                if (obj != null)
                {
                    if (obj.ChannelID != null)
                    {
                        this.lblChannelName.Text = obj.ChannelID.Name;
                    }
                    else
                    {
                        this.lblChannelName.Text = "";
                    }

                    if (obj.ClinetID != null)
                    {
                        this.lblOldClientName.Text = obj.ClinetID.Name;
                        this.lblOldLoginUserID.Text = obj.ClinetID.UserLoginID;
                    }
                    else
                    {
                        this.lblOldClientName.Text = "";
                        this.lblOldLoginUserID.Text = "";
                    }

                    this.lblCode.Text = obj.ChannelClientCode;

                    this.txtClientAlias.Text = "";
                    this.txtClientName.Text = "";
                    this.txtLoginPassword.Text = "123456";
                    this.txtLoginUserID.Text = "";

                    hidId.Text = id.ToString();

                    winSPClientChannelSettingChangeClientAndUser.Show();


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
    }
}