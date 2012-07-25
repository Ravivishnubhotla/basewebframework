using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Clients
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPSClientAdd")]
    public partial class UCSPSClientAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            this.numShowDayRecord.Text = SystemConfigConst.CFG_DEFAULT_VALUE_SPSCLIENTDAYCOUNTS;
            this.txtNotInterceptCount.Text = SystemConfigConst.CFG_DEFAULT_VALUE_SPSCLIENTNOINTERCEPTCOUNT;
            this.txtDefaultPrice.Text = "1";
            this.txtInterceptRate.Text = SystemConfigConst.CFG_DEFAULT_VALUE_SPSCLIENTINTERCEPTRATE;
            this.txtUserPasword.Text = SystemConfigConst.Config_SysDefaultUserpass;
            this.txtSycnRetryTimes.Text = SystemConfigConst.Config_SpsClientSendtryTimes.ToString();


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
                ResourceManager.AjaxErrorMessage = "错误信息:" + ex.Message;
            }
        }

        protected void btnSaveSPSClient_Click(object sender, DirectEventArgs e)
        {
            try
            {
                string loginID = txtUserID.Text.Trim();

                string password = txtUserPasword.Text.Trim();

                if(SystemUserWrapper.FindByLoginID(loginID)!=null)
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "错误信息:用户已存在。";
                }


                SPSClientWrapper obj = new SPSClientWrapper();
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                //obj.RecieveDataUrl = this.txtRecieveDataUrl.Text.Trim();
                //obj.UserID = Convert.ToInt32(this.txtUserID.Text.Trim());
                //obj.SyncData = this.chkSyncData.Checked;
                //obj.OkMessage = this.txtOkMessage.Text.Trim();
                //obj.FailedMessage = this.txtFailedMessage.Text.Trim();
                //obj.SyncType = this.txtSyncType.Text.Trim();
                //obj.Alias = this.txtAlias.Text.Trim();
                obj.InterceptRate = Convert.ToDecimal(this.txtInterceptRate.Text.Trim());
                obj.DefaultPrice = Convert.ToDecimal(this.txtDefaultPrice.Text.Trim());
                obj.SycnNotInterceptCount = Convert.ToInt32(this.txtNotInterceptCount.Text.Trim());
                obj.DefaultShowRecordDays = Convert.ToInt32(this.numShowDayRecord.Text.Trim());
                obj.SyncData = chkSyncData.Checked;



                if (obj.SyncData)
                {
                    SPSDataSycnSettingWrapper spsDataSycnSetting = new SPSDataSycnSettingWrapper();

                    spsDataSycnSetting.SycnRetryTimes = Convert.ToInt32(txtSycnRetryTimes.Text);

                    spsDataSycnSetting.SycnMO = fsSyncMO.Collapsed;

                    if (spsDataSycnSetting.SycnMO.HasValue && spsDataSycnSetting.SycnMO.Value)
                    {
                        spsDataSycnSetting.SycnMOUrl = txtSycnMOUrl.Text.Trim();
                        spsDataSycnSetting.SycnMOOkMessage = txtSycnMOOkMessage.Text.Trim();
                        spsDataSycnSetting.SycnMOFailedMessage = txtSycnMOFailedMessage.Text.Trim();
                    }
                    else
                    {
                        spsDataSycnSetting.SycnMOUrl = "";
                        spsDataSycnSetting.SycnMOOkMessage = "";
                        spsDataSycnSetting.SycnMOFailedMessage = "";                 
                    }

                    spsDataSycnSetting.SycnMR = fsSyncMR.Collapsed;

                    if (spsDataSycnSetting.SycnMR.HasValue && spsDataSycnSetting.SycnMR.Value)
                    {
                        spsDataSycnSetting.SycnMRUrl = txtSycnMRUrl.Text.Trim();
                        spsDataSycnSetting.SycnMROkMessage = txtSycnMROkMessage.Text.Trim();
                        spsDataSycnSetting.SycnMRFailedMessage = txtSycnMRFailedMessage.Text.Trim();
                    }
                    else
                    {
                        spsDataSycnSetting.SycnMRUrl = "";
                        spsDataSycnSetting.SycnMROkMessage = "";
                        spsDataSycnSetting.SycnMRFailedMessage = "";
                    }

                    spsDataSycnSetting.SycnSate = fsSyncState.Collapsed;

                    if (spsDataSycnSetting.SycnSate.HasValue && spsDataSycnSetting.SycnSate.Value)
                    {
                        spsDataSycnSetting.SycnSateUrl = txtSycnStateUrl.Text.Trim();
                        spsDataSycnSetting.SycnSateOkMessage = txtSycnStateOkMessage.Text.Trim();
                        spsDataSycnSetting.SycnSateFailedMessage = txtSycnStateFailedMessage.Text.Trim();
                    }
                    else
                    {
                        spsDataSycnSetting.SycnSateUrl = "";
                        spsDataSycnSetting.SycnSateOkMessage = "";
                        spsDataSycnSetting.SycnSateFailedMessage = "";
                    }

                    SPSDataSycnSettingWrapper.Save(spsDataSycnSetting);

                    obj.SyncDataSetting = spsDataSycnSetting;

                }

                SPSClientWrapper.QuickAdd(obj, loginID, password);

                winSPSClientAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息:" + ex.Message;
            }
        }
    }


}