using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Clients
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPSClientEdit")]
    public partial class UCSPSClientEdit : System.Web.UI.UserControl
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
                    this.txtDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
                    this.txtRecieveDataUrl.Text = ValueConvertUtil.ConvertStringValue(obj.RecieveDataUrl);
                    this.txtUserID.Text = obj.UserID.ToString();
                    this.chkSyncData.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.SyncData);
                    this.txtOkMessage.Text = ValueConvertUtil.ConvertStringValue(obj.OkMessage);
                    this.txtFailedMessage.Text = ValueConvertUtil.ConvertStringValue(obj.FailedMessage);
                    this.txtSyncType.Text = ValueConvertUtil.ConvertStringValue(obj.SyncType);
                    this.txtAlias.Text = ValueConvertUtil.ConvertStringValue(obj.Alias);
                    this.txtInterceptRate.Text = obj.InterceptRate.ToString();
                    this.txtDefaultPrice.Text = obj.DefaultPrice.ToString();




                    hidId.Text = id.ToString();


                    winSPSClientEdit.Show();

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
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.RecieveDataUrl = this.txtRecieveDataUrl.Text.Trim();
                obj.UserID = Convert.ToInt32(this.txtUserID.Text.Trim());
                obj.SyncData = this.chkSyncData.Checked;
                obj.OkMessage = this.txtOkMessage.Text.Trim();
                obj.FailedMessage = this.txtFailedMessage.Text.Trim();
                obj.SyncType = this.txtSyncType.Text.Trim();
                obj.Alias = this.txtAlias.Text.Trim();
                obj.InterceptRate = Convert.ToDecimal(this.txtInterceptRate.Text.Trim());
                obj.DefaultPrice = Convert.ToDecimal(this.txtDefaultPrice.Text.Trim());


                SPSClientWrapper.Update(obj);

                winSPSClientEdit.Hide();
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