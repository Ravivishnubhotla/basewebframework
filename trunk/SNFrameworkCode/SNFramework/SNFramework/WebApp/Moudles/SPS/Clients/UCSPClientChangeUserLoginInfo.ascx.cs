using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Providers;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Clients
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPClientChangeUserLoginInfo")]
    public partial class UCSPClientChangeUserLoginInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SPSClientWrapper obj = SPSClientWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);

                    SystemUserWrapper clientUser = SystemUserWrapper.FindById(obj.UserID);

                    this.txtUserID.Text = clientUser.UserLoginID;

                    chkChangePassword.Checked = false;

                    this.txtUserPasword.Text = "";

                    hidId.Text = id.ToString();


                    winSPClientChangeUserLoginInfo.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "ErrorMessage:Data does not exist";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
                return;
            }
        }

        protected void btnSaveSPSClient_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPSClientWrapper obj = SPSClientWrapper.FindById(int.Parse(hidId.Text.Trim()));

                SystemUserWrapper clientUser = SystemUserWrapper.FindById(obj.UserID);

                if (clientUser.UserLoginID!=this.txtUserID.Text.Trim())
                {
                    if (SystemUserWrapper.GetUserByLoginID(this.txtUserID.Text.Trim()) != null)
                    {
                        ResourceManager.AjaxSuccess = false;
                        ResourceManager.AjaxErrorMessage = "错误信息:用户已存在。";
                    }

                }


                clientUser.UserLoginID = this.txtUserID.Text.Trim();

                SPSClientWrapper.Update(obj);

                if(this.chkChangePassword.Checked && !string.IsNullOrEmpty(this.txtUserPasword.Text.Trim()))
                {
                    if (!((NHibernateMembershipProvider)Membership.Provider).ChangePassword(clientUser.UserLoginID, this.txtUserPasword.Text.Trim()))
                    {
                        ResourceManager.AjaxSuccess = false;
                        ResourceManager.AjaxErrorMessage = "Change Password Failed!";
                        return;
                    }               
                }



                winSPClientChangeUserLoginInfo.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
                return;
            }

        }
    }
}