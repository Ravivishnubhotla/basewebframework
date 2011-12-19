using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Legendigital.Framework.Common.BaseFramework.Web;
using SPS.Bussiness.Wrappers;
using Ext.Net;
using Legendigital.Framework.Common.Web.ControlHelper;

namespace Legendigital.Common.WebApp.Moudles.SPS.Clients
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

            if(cmbChannel.SelectedItem!=null)
            {
                this.storeSPCode.DataSource = SPCodeWrapper.FindAllByChannelID(SPChannelWrapper.FindById(Convert.ToInt32(cmbChannel.SelectedItem.Value)));
            }
            else
            {
                this.storeSPCode.DataSource = new List<SPCodeWrapper>();
            }



            this.storeSPChannel.DataBind();
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
 
                this.txtSycnDataUrl.Text = client.SycnDataUrl;
                this.txtSycnOkMessage.Text = client.SycnOkMessage;
                this.txtSycnFailedMessage.Text = client.SycnFailedMessage;
                this.txtSycnRetryTimes.Text = client.SycnRetryTimes.ToString();
                

  


                this.winSPClientCodeRelationAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
            }
        }


        [DirectMethod]
        public void SaveClientCodeRelation()
        {
            try
            {
                SPCodeWrapper code = SPCodeWrapper.FindById(Convert.ToInt32(cmbCode.SelectedItem.Value));

                SPClientCodeRelationWrapper obj = new SPClientCodeRelationWrapper();

                obj.Price = Convert.ToDecimal(this.txtPrice.Text.Trim());
                obj.InterceptRate = Convert.ToDecimal(this.txtInterceptRate.Text.Trim());
                obj.UseClientDefaultSycnSetting = false;
                obj.SyncData = this.chkSyncData.Checked;
                obj.ClientID = SPSClientID;
                obj.CodeID = code;
                obj.SycnRetryTimes = this.txtSycnRetryTimes.Text.Trim();
                obj.SyncType = "1";
                obj.SycnDataUrl = this.txtSycnDataUrl.Text.Trim();
                obj.SycnOkMessage = this.txtSycnOkMessage.Text.Trim();
                obj.SycnFailedMessage = this.txtSycnFailedMessage.Text.Trim();
                obj.StartDate = System.DateTime.Now;
                obj.EndDate = null;
                obj.IsEnable = true;
                obj.SycnNotInterceptCount = Convert.ToInt32(this.txtSycnNotInterceptCount.Text.Trim());
                obj.CreateBy = this.ParentPage.CurrentLoginUser.UserID;
                obj.CreateAt = System.DateTime.Now;
                obj.LastModifyBy = this.ParentPage.CurrentLoginUser.UserID;
                obj.LastModifyAt = System.DateTime.Now;





                SPClientCodeRelationWrapper.Save(obj);

                winSPClientCodeRelationAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }
 

        protected void btnSaveSPClientCodeRelation_Click(object sender, DirectEventArgs e)
        {
            SPCodeWrapper code = SPCodeWrapper.FindById(Convert.ToInt32(cmbCode.SelectedItem.Value));

            List<SPClientCodeRelationWrapper> spClientCodeRelations = SPClientCodeRelationWrapper.FindAllByCodeID(code);

            var findClientAssignedCode = spClientCodeRelations.Find(p => (p.ClientID.Id == SPSClientID.Id && p.IsEnable));

            if (findClientAssignedCode!=null)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息:该指令已经分配给该客户";
                return;
            }

            var findClientAssignedCodes =
                spClientCodeRelations.FindAll(p=>p.IsEnable);

            if (findClientAssignedCodes.Count>0)
            {
                X.Msg.Confirm("警告", "该指令已经分配给其他的客户，确认更改客户？", new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "#{DirectMethods}.SaveClientCodeRelation(false)",
                        Text = "确认"
                    },
                    No = new MessageBoxButtonConfig
                    {
                        Handler = "",
                        Text = "取消"
                    }
                }).Show();
            }
            else
            {
                SaveClientCodeRelation();
            }

        }
    }


}