using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;
using Legendigital.Framework.Common.Web.ControlHelper;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.EmailSettingManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemEmailSettingsEdit")]
    public partial class UCSystemEmailSettingsEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SystemEmailSettingsWrapper obj = SystemEmailSettingsWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    this.txtDescriprsion.Text = ValueConvertUtil.ConvertStringValue(obj.Descriprsion);
                    this.txtHost.Text = ValueConvertUtil.ConvertStringValue(obj.Host);
                    this.txtPort.Text = ValueConvertUtil.ConvertStringValue(obj.Port);
                    this.chkSSL.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.Ssl);
                    this.txtFromEmail.Text = ValueConvertUtil.ConvertStringValue(obj.FromEmail);
                    this.txtFromName.Text = ValueConvertUtil.ConvertStringValue(obj.FromName);
                    this.txtLoginEmail.Text = ValueConvertUtil.ConvertStringValue(obj.LoginEmail);
                    this.txtLoginPassword.Text = ValueConvertUtil.ConvertStringValue(obj.LoginPassword);
                    this.chkIsEnable.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsEnable);
                    this.chkIsDefault.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsDefault);
 




                    hidEmailSettingID.Text = id.ToString();


                    winSystemEmailSettingsEdit.Show();

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

        protected void btnSaveSystemEmailSettings_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemEmailSettingsWrapper obj = SystemEmailSettingsWrapper.FindById(int.Parse(hidEmailSettingID.Text.Trim()));
                obj.Name = this.txtName.Text.Trim();
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
 


                SystemEmailSettingsWrapper.Update(obj);

                winSystemEmailSettingsEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
                return;
            }

        }
    }




}