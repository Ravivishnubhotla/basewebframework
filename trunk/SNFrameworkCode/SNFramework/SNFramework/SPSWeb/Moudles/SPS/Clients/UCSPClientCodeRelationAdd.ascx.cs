using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Web;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Clients
{

    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPClientCodeRelationAdd")]
    public partial class UCSPClientCodeRelationAdd : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void storeSPChannel_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.storeSPChannel.DataSource = SPChannelWrapper.FindAll();

            this.storeSPChannel.DataBind();
        }



        protected void storeSPCode_Refresh(object sender, StoreRefreshDataEventArgs e)
        {

            if (cmbChannel.SelectedItem != null)
            {
                this.storeSPCode.DataSource = SPCodeWrapper.GetAvaiableCodeForClient(SPChannelWrapper.FindById(Convert.ToInt32(cmbChannel.SelectedItem.Value)), SPSClientID);
            }
            else
            {
                this.storeSPCode.DataSource = new List<SPCodeWrapper>();
            }



            this.storeSPCode.DataBind();
        }



        public SPSClientWrapper SPSClientID
        {
            get
            {
                if (this.Request.QueryString["SPSClientID"] != null)
                {
                    return
                        SPSClientWrapper.FindById(int.Parse(this.Request.QueryString["SPSClientID"]));
                }
                return null;
            }
        }


        [DirectMethod]
        public void Show()
        {
            try
            {
                SPSClientWrapper client = SPSClientID;


                this.txtPrice.Text = client.DefaultPrice.ToString();
                this.txtInterceptRate.Text = client.InterceptRate.ToString();
                this.txtSycnNotInterceptCount.Text = client.SycnNotInterceptCount.ToString();
                this.chkSyncData.Checked = client.SyncData;


                if (client.SyncDataSetting != null)
                {
                    this.txtSycnDataUrl.Text = client.SyncDataSetting.SycnMOUrl;
                    this.txtSycnOkMessage.Text = client.SyncDataSetting.SycnMOOkMessage;
                    this.txtSycnFailedMessage.Text = client.SyncDataSetting.SycnMOFailedMessage;
                    this.txtSycnRetryTimes.Text = client.SyncDataSetting.SycnRetryTimes.ToString();
                }
 
                this.winSPClientCodeRelationAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }

        [DirectMethod]
        public void SaveClientCodeRelation()
        {

            SPCodeWrapper codeWrapper = SPCodeWrapper.FindById(Convert.ToInt32(cmbCode.SelectedItem.Value));

            DateTime changeDate = System.DateTime.Now;
            
            int changeUserID = this.ParentPage.CurrentLoginUser.UserID;
            
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

                codeWrapper.ChangeClient(SPSClientID,
                                    changeDate, changeUserID, price, interceptRate, syncData, sycnNotInterceptCount,sycnRetryTimes,dataSycnSetting
                                    );

                winSPClientCodeRelationAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSPClientCodeRelation_Click(object sender, DirectEventArgs e)
        {

            SPCodeWrapper codeWrapper = SPCodeWrapper.FindById(Convert.ToInt32(cmbCode.SelectedItem.Value));

            if (!string.IsNullOrEmpty(codeWrapper.AssignedClientName))
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "警告",
                    Message = string.Format("该代码已经分配给客户{0}，确认转给客户{1}？", codeWrapper.AssignedClientName, SPSClientID.Name),
                    Width = 300,
                    Buttons = MessageBox.Button.OKCANCEL,
                    Multiline = false,
                    AnimEl = this.btnSavelSPClientCodeRelation.ClientID,
                    Fn = new JFunction { Fn = "beforeSaveClientCodeRelation" }
                });
                //X.Msg.Confirm("警告", string.Format("该代码已经分配给客户{0}，确认转给客户{1}？", codeWrapper.AssignedClientName, SPSClientID.Name), new JFunction { Fn = "beforeSaveClientCodeRelation" }).Show();
                return;
            }

            if (codeWrapper.AssignedClientName == SPSClientID.Name)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format("该代码已经分配给客户{0},不能重复分配", SPSClientID.Name);
                if (cmbChannel.SelectedItem != null)
                {
                    this.storeSPCode.DataSource = SPCodeWrapper.GetAvaiableCodeForClient(SPChannelWrapper.FindById(Convert.ToInt32(cmbChannel.SelectedItem.Value)), SPSClientID);
                }
                else
                {
                    this.storeSPCode.DataSource = new List<SPCodeWrapper>();
                }



                this.storeSPCode.DataBind();
                return;
            }



            SaveClientCodeRelation();



        }
    }

}