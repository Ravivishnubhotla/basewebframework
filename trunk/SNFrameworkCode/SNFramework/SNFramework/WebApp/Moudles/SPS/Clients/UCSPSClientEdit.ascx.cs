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
 
                        this.txtSycnRetryTimes.Show();
                        fsSyncMO.Show();
                        fsSyncMR.Hide();
                        fsSyncState.Hide();

                        if (obj.SyncDataSetting!=null)
                        {
                            if (obj.SyncDataSetting.SycnMO.HasValue && obj.SyncDataSetting.SycnMO.Value)
                            {
                                fsSyncMO.Collapsed = true;
                                this.txtSycnMOFailedMessage.Text = obj.SyncDataSetting.SycnMOFailedMessage;
                                this.txtSycnMOOkMessage.Text = obj.SyncDataSetting.SycnMOOkMessage;
                                this.txtSycnMOUrl.Text = obj.SyncDataSetting.SycnMOUrl;
                            }
                            else
                            {
                                fsSyncMO.Collapsed = false;
                                this.txtSycnMOFailedMessage.Text = "";
                                this.txtSycnMOOkMessage.Text = "";
                                this.txtSycnMOUrl.Text = "";               
                            }

                            if (obj.SyncDataSetting.SycnMR.HasValue && obj.SyncDataSetting.SycnMR.Value)
                            {
                                fsSyncMR.Collapsed = true;
                                this.txtSycnMRFailedMessage.Text = obj.SyncDataSetting.SycnMRFailedMessage;
                                this.txtSycnMROkMessage.Text = obj.SyncDataSetting.SycnMROkMessage;
                                this.txtSycnMRUrl.Text = obj.SyncDataSetting.SycnMRUrl;
                            }
                            else
                            {
                                fsSyncMR.Collapsed = false;
                                this.txtSycnMRFailedMessage.Text = "";
                                this.txtSycnMROkMessage.Text = "";
                                this.txtSycnMRUrl.Text = "";
                            }


                            if (obj.SyncDataSetting.SycnSate.HasValue && obj.SyncDataSetting.SycnSate.Value)
                            {
                                fsSyncState.Collapsed = true;
                                this.txtSycnStateFailedMessage.Text = obj.SyncDataSetting.SycnSateFailedMessage;
                                this.txtSycnStateOkMessage.Text = obj.SyncDataSetting.SycnSateOkMessage;
                                this.txtSycnStateUrl.Text = obj.SyncDataSetting.SycnSateUrl;
                            }
                            else
                            {
                                fsSyncState.Collapsed = false;
                                this.txtSycnStateFailedMessage.Text = "";
                                this.txtSycnStateOkMessage.Text = "";
                                this.txtSycnStateUrl.Text = "";
                            }

                            if(obj.SyncDataSetting.SycnRetryTimes.HasValue)
                                this.txtSycnRetryTimes.Text = obj.SyncDataSetting.SycnRetryTimes.Value.ToString();
                            else
                                this.txtSycnRetryTimes.Text = "3"; 
                        }
                    }
                    else
                    {
                        fsSyncMO.Hide();
                        fsSyncMR.Hide();
                        fsSyncState.Hide();
                        this.txtSycnRetryTimes.Hide();
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
                    if(obj.SyncDataSetting == null)
                    {
                        SPSDataSycnSettingWrapper spsDataSycnSetting = new SPSDataSycnSettingWrapper();

                        SPSDataSycnSettingWrapper.Save(spsDataSycnSetting);

                        obj.SyncDataSetting = spsDataSycnSetting;
                    }

                    obj.SyncDataSetting.SycnRetryTimes = Convert.ToInt32(txtSycnRetryTimes.Text);

                    obj.SyncDataSetting.SycnMO = fsSyncMO.Collapsed;

                    if (obj.SyncDataSetting.SycnMO.HasValue && obj.SyncDataSetting.SycnMO.Value)
                    {
                        obj.SyncDataSetting.SycnMOUrl = txtSycnMOUrl.Text.Trim();
                        obj.SyncDataSetting.SycnMOOkMessage = txtSycnMOOkMessage.Text.Trim();
                        obj.SyncDataSetting.SycnMOFailedMessage = txtSycnMOFailedMessage.Text.Trim();
                    }
                    else
                    {
                        obj.SyncDataSetting.SycnMOUrl = "";
                        obj.SyncDataSetting.SycnMOOkMessage = "";
                        obj.SyncDataSetting.SycnMOFailedMessage = "";
                    }

                    obj.SyncDataSetting.SycnMR = fsSyncMR.Collapsed;

                    if (obj.SyncDataSetting.SycnMR.HasValue && obj.SyncDataSetting.SycnMR.Value)
                    {
                        obj.SyncDataSetting.SycnMRUrl = txtSycnMRUrl.Text.Trim();
                        obj.SyncDataSetting.SycnMROkMessage = txtSycnMROkMessage.Text.Trim();
                        obj.SyncDataSetting.SycnMRFailedMessage = txtSycnMRFailedMessage.Text.Trim();
                    }
                    else
                    {
                        obj.SyncDataSetting.SycnMRUrl = "";
                        obj.SyncDataSetting.SycnMROkMessage = "";
                        obj.SyncDataSetting.SycnMRFailedMessage = "";
                    }

                    obj.SyncDataSetting.SycnSate = fsSyncState.Collapsed;

                    if (obj.SyncDataSetting.SycnSate.HasValue && obj.SyncDataSetting.SycnSate.Value)
                    {
                        obj.SyncDataSetting.SycnSateUrl = txtSycnStateUrl.Text.Trim();
                        obj.SyncDataSetting.SycnSateOkMessage = txtSycnStateOkMessage.Text.Trim();
                        obj.SyncDataSetting.SycnSateFailedMessage = txtSycnStateFailedMessage.Text.Trim();
                    }
                    else
                    {
                        obj.SyncDataSetting.SycnSateUrl = "";
                        obj.SyncDataSetting.SycnSateOkMessage = "";
                        obj.SyncDataSetting.SycnSateFailedMessage = "";
                    }

                    SPSDataSycnSettingWrapper.Save(obj.SyncDataSetting);
 
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