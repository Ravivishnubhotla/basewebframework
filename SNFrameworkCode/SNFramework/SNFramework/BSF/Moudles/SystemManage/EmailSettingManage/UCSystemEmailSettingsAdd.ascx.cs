using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Web.ControlHelper;


namespace SNFramework.BSF.Moudles.SystemManage.EmailSettingManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemEmailSettingsAdd")]
    public partial class UCSystemEmailSettingsAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSystemEmailSettingsAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message : " + ex.Message;
            }
        }

        protected void btnSaveSystemEmailSettings_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemEmailSettingsWrapper obj = new SystemEmailSettingsWrapper();
                obj.Name = this.txtName.Text.Trim();
                obj.Code = this.txtCode.Text.Trim();
                obj.Descriprsion = this.txtDescriprsion.Text.Trim();
                obj.Host = this.txtHost.Text.Trim();
                obj.Port = this.txtPort.Text.Trim();
                obj.Ssl = this.chkSSL.Checked;
                obj.FromEmail = this.txtFromEmail.Text.Trim();
                obj.FromName = this.txtFromName.Text.Trim();
                obj.LoginEmail = this.txtLoginEmail.Text.Trim();
                obj.LoginPassword = this.txtLoginPassword.Text.Trim();
                obj.IsEnable = this.chkIsEnable.Checked;
                obj.IsDefault = this.chkIsDefault.Checked;
                //obj.CreateDate = System.DateTime.Now;        	
                obj.CreateBy = 1;





                SystemEmailSettingsWrapper.Save(obj);

                winSystemEmailSettingsAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message : " + ex.Message;
            }
        }
    }
}