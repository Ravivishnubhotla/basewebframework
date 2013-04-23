using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SPS.Bussiness.Wrappers;
using SPSWeb.AppCode;

namespace SPSWeb.Moudles.SPS.Codes
{
    public partial class SPCodeChangeClient : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            SPCodeWrapper obj = CodeID;

            if (obj != null)
            {
                this.lblChannelName.Text = obj.ChannelID_Name;

                this.lblMoCodeCode.Text = obj.MoCode;

                this.lblAssignedClient.Text = obj.AssignedClientName;

                this.lblPrice.Text = obj.Price.ToString();

                this.lblIsDiable.Text = obj.IsDiable.ToString();

                this.lblProvinceLimitInfo.Text = obj.ProvinceLimitInfo.ToString();

                this.lblPhoneLimitInfo.Text = obj.PhoneLimitInfo.ToString();

            }


        }

        protected void btnSaveSPCode_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPCodeWrapper codeWrapper = CodeID;

                SPSClientWrapper client =
                    SPSClientWrapper.FindById(Convert.ToInt32(cmbAssignedClient.SelectedItem.Value));


                DateTime changeDate = System.DateTime.Now;

                int changeUserID = this.CurrentLoginUser.UserID;

                decimal price = Convert.ToDecimal(this.txtPrice.Text.Trim());

                decimal interceptRate = Convert.ToDecimal(this.txtInterceptRate.Text.Trim());

                bool syncData = this.chkSyncData.Checked;

                int sycnNotInterceptCount = Convert.ToInt32(this.txtSycnNotInterceptCount.Text.Trim());

                string sycnRetryTimes = this.txtSycnRetryTimes.Text.Trim();

                SPSDataSycnSettingWrapper dataSycnSetting = null;

                if (syncData)
                {
                    dataSycnSetting = new SPSDataSycnSettingWrapper();

                    dataSycnSetting.SycnMO = true;
                    dataSycnSetting.SyncType = "1";
                    dataSycnSetting.SycnMOUrl = this.txtSycnDataUrl.Text.Trim();
                    dataSycnSetting.SycnMOOkMessage = this.txtSycnOkMessage.Text.Trim();
                    dataSycnSetting.SycnMOFailedMessage = this.txtSycnFailedMessage.Text.Trim();
                }


                try
                {

                    codeWrapper.ChangeClient(client,
                                        changeDate, changeUserID, price, interceptRate, syncData, sycnNotInterceptCount, sycnRetryTimes, dataSycnSetting
                                        );

                }
                catch (Exception ex)
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                }

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息:" + ex.Message;
            }

        }

        public SPCodeWrapper CodeID
        {
            get
            {
                if (this.Request.QueryString["CodeID"] != null)
                {
                    return
                        SPCodeWrapper.FindById(int.Parse(this.Request.QueryString["CodeID"]));
                }
                return null;
            }
        }
    }
}