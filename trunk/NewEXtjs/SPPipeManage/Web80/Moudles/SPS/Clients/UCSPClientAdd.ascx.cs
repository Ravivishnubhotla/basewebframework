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

namespace Legendigital.Common.Web.Moudles.SPS.Clients
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPClientAdd")]
    public partial class UCSPClientAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int ClientGroupID
        {
            get
            {
                if (this.Request.QueryString["ClientGroupID"] == null)
                    return 0;
                return Convert.ToInt32(this.Request.QueryString["ClientGroupID"]);
            }

        }

        [AjaxMethod]
        public void Show()
        {
            try
            {
                if (ClientGroupID > 0)
                {
                    this.cmbClientGroupID.Hide();
                }
                this.winSPClientAdd.Show();


            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSPClient_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                //string loginID = this.txtRelateUserLoginID.Text.Trim();

                //if (SystemUserWrapper.GetUserByLoginID(loginID) != null)
                //{
                //    Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                //    Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：用户登录ID已存在！";
                //    return;
                //}

               


                SPClientWrapper obj = new SPClientWrapper();
                obj.Name = this.txtName.Text.Trim();
                obj.Alias = this.txtAlias.Text.Trim();
                obj.IsDefaultClient = false;


                
                obj.Description = this.txtDescription.Text.Trim();

                if (ClientGroupID<=0)
                {
                    obj.SPClientGroupID =
                        SPClientGroupWrapper.FindById(Convert.ToInt32(this.cmbClientGroupID.SelectedItem.Value));
                }
                else
                {
                    obj.SPClientGroupID = SPClientGroupWrapper.FindById(ClientGroupID);                
                }




                //obj.RecieveDataUrl = this.txtRecieveDataUrl.Text.Trim();
                //obj.SyncData = this.chkSyncDate.Checked;
                //obj.OkMessage = this.txtOkMessage.Text.Trim();
                //obj.FailedMessage = this.txtFailedMessage.Text.Trim();
                //obj.SyncType = this.cmbSycnType.SelectedItem.Value;


                //Membership.CreateUser(loginID, this.txtRelateUserPassword.Text.Trim(), this.txtRelateUserLoginID.Text.Trim()+"@163.com");


                //SystemUserWrapper clientUser = SystemUserWrapper.GetUserByLoginID(loginID);

                //clientUser.UserName = loginID;

                //SystemUserWrapper.Update(clientUser);

                //SystemRoleWrapper clientRole = SystemRoleWrapper.GetRoleByName("SPDownUser");

                //SystemUserWrapper.PatchAssignUserRoles(clientUser, new List<string> { clientRole.RoleID.ToString() });

                //obj.UserID = clientUser.UserID;
 
                SPClientWrapper.Save(obj);

                winSPClientAdd.Hide();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }





    }

}