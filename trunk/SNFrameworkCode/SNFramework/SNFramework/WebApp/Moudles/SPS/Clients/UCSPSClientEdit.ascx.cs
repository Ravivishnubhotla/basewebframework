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

                    this.txtInterceptRate.Text = obj.InterceptRate.ToString();
                    this.txtDefaultPrice.Text = obj.DefaultPrice.ToString();
                    this.txtNotInterceptCount.Text = obj.SycnNotInterceptCount.ToString();
                    this.numShowDayRecord.Text = obj.DefaultShowRecordDays.ToString();

                    this.chkSyncData.Checked = obj.SyncData;

                    if (obj.SyncData)
                    {
                        this.txtFailedMessage.Show();
                        this.txtOkMessage.Show();
                        this.txtRecieveDataUrl.Show();
                        this.txtSycnRetryTimes.Show();

                        if (obj.SyncDataSetting!=null)
                        {
                            this.txtFailedMessage.Text = obj.SyncDataSetting.SycnMOFailedMessage;
                            this.txtOkMessage.Text = obj.SyncDataSetting.SycnMOOkMessage;
                            this.txtRecieveDataUrl.Text = obj.SyncDataSetting.SycnMOUrl;
                            if(obj.SyncDataSetting.SycnRetryTimes.HasValue)
                                this.txtSycnRetryTimes.Text = obj.SyncDataSetting.SycnRetryTimes.Value.ToString();
                            else
                                this.txtSycnRetryTimes.Text = "3"; 
                        }
                        else
                        {
                            this.txtFailedMessage.Text = "";
                            this.txtOkMessage.Text = "";
                            this.txtRecieveDataUrl.Text = "";
                            this.txtSycnRetryTimes.Text = "3";      
                        }


                    }
                    else
                    {
                        this.txtFailedMessage.Hide();
                        this.txtOkMessage.Hide();
                        this.txtRecieveDataUrl.Hide();
                        this.txtSycnRetryTimes.Hide();
                        this.txtFailedMessage.Text = "";
                        this.txtOkMessage.Text = "";
                        this.txtRecieveDataUrl.Text = "";
                        this.txtSycnRetryTimes.Text = "3";
                    }


                    hidId.Text = id.ToString();


                    winSPSClientEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "Error Message:Data does not exist";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
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
 
                obj.InterceptRate = Convert.ToDecimal(this.txtInterceptRate.Text.Trim());
                obj.DefaultPrice = Convert.ToDecimal(this.txtDefaultPrice.Text.Trim());
                obj.SycnNotInterceptCount = Convert.ToInt32(this.txtNotInterceptCount.Text.Trim());
                obj.DefaultShowRecordDays = Convert.ToInt32(this.numShowDayRecord.Text.Trim());
                obj.SyncData = chkSyncData.Checked;

                if (obj.SyncDataSetting == null)
                {
                    obj.SyncDataSetting = new SPSDataSycnSettingWrapper();

                    SPSDataSycnSettingWrapper.Save(obj.SyncDataSetting);
                }



                if (obj.SyncData)
                {
                    obj.SyncDataSetting.SycnMO = true;
                    obj.SyncDataSetting.SycnMOUrl = txtRecieveDataUrl.Text.Trim();
                    obj.SyncDataSetting.SycnMOOkMessage = txtOkMessage.Text.Trim();
                    obj.SyncDataSetting.SycnMOFailedMessage = txtFailedMessage.Text.Trim();
                    obj.SyncDataSetting.SycnRetryTimes = Convert.ToInt32(txtSycnRetryTimes.Text);
                }
                else
                {
                    obj.SyncDataSetting.SycnMO = false;
                    obj.SyncDataSetting.SycnMOUrl = "";
                    obj.SyncDataSetting.SycnMOOkMessage = "";
                    obj.SyncDataSetting.SycnMOFailedMessage = "";
                    obj.SyncDataSetting.SycnRetryTimes = 3;
                }


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