using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Clients
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPSClientAdd")]
    public partial class UCSPSClientAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSPSClientAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
            }
        }

        protected void btnSaveSPSClient_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPSClientWrapper obj = new SPSClientWrapper();
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                //obj.RecieveDataUrl = this.txtRecieveDataUrl.Text.Trim();
                //obj.UserID = Convert.ToInt32(this.txtUserID.Text.Trim());
                //obj.SyncData = this.chkSyncData.Checked;
                //obj.OkMessage = this.txtOkMessage.Text.Trim();
                //obj.FailedMessage = this.txtFailedMessage.Text.Trim();
                obj.SyncType = this.txtSyncType.Text.Trim();
                obj.Alias = this.txtAlias.Text.Trim();
                obj.InterceptRate = Convert.ToDecimal(this.txtInterceptRate.Text.Trim());
                obj.DefaultPrice = Convert.ToDecimal(this.txtDefaultPrice.Text.Trim());





                SPSClientWrapper.Save(obj);

                winSPSClientAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }
    }


}