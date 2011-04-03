using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.EmailSettingManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemEmailSettingsView")]
    public partial class UCSystemEmailSettingsView : System.Web.UI.UserControl
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


 
                    this.lblName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    this.lblDescriprsion.Text = ValueConvertUtil.ConvertStringValue(obj.Descriprsion);
                    this.lblHost.Text = ValueConvertUtil.ConvertStringValue(obj.Host);
                    this.lblPort.Text = ValueConvertUtil.ConvertStringValue(obj.Port);
                    this.lblSSL.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.Ssl).ToString();
                    this.lblFromEmail.Text = ValueConvertUtil.ConvertStringValue(obj.FromEmail);
                    this.lblFromName.Text = ValueConvertUtil.ConvertStringValue(obj.FromName);
                    this.lblLoginEmail.Text = ValueConvertUtil.ConvertStringValue(obj.LoginEmail);
                    this.lblLoginPassword.Text = ValueConvertUtil.ConvertStringValue(obj.LoginPassword);
                    this.lblIsEnable.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsEnable).ToString();
                    this.lblIsDefault.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsDefault).ToString();
                    this.lblCreateDate.Text = obj.CreateDate.ToString();
                    this.lblCreateBy.Text = obj.CreateBy.ToString();





                    //hidLogID.Text = id.ToString();


                    winSystemEmailSettingsView.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "Error Message : Data does not exist";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message : " + ex.Message;
                return;
            }
        }


    }

}