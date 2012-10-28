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

            if (codeWrapper.ClientCodeRelation != null)
            {
                if (codeWrapper.ClientCodeRelation.ClientID.Id == SPSClientID.Id)
                    return;

                codeWrapper.ClientCodeRelation.IsEnable = false;
                codeWrapper.ClientCodeRelation.EndDate = System.DateTime.Now;

                SPClientCodeRelationWrapper.Update(codeWrapper.ClientCodeRelation);
            }

            try
            {
                SPClientCodeRelationWrapper obj = new SPClientCodeRelationWrapper();

                obj.Price = Convert.ToDecimal(this.txtPrice.Text.Trim());
                obj.InterceptRate = Convert.ToDecimal(this.txtInterceptRate.Text.Trim());
                obj.UseClientDefaultSycnSetting = false;
                obj.SyncData = this.chkSyncData.Checked;
                obj.ClientID = SPSClientID;
                obj.CodeID = codeWrapper;
                obj.SycnRetryTimes = this.txtSycnRetryTimes.Text.Trim();

                if (obj.SyncData)
                {
                    SPSDataSycnSettingWrapper spsDataSycnSetting = new SPSDataSycnSettingWrapper();

                    spsDataSycnSetting.SycnMO = true;
                    spsDataSycnSetting.SyncType = "1";
                    spsDataSycnSetting.SycnMOUrl = this.txtSycnDataUrl.Text.Trim();
                    spsDataSycnSetting.SycnMOOkMessage = this.txtSycnOkMessage.Text.Trim();
                    spsDataSycnSetting.SycnMOFailedMessage = this.txtSycnFailedMessage.Text.Trim();

                    SPSDataSycnSettingWrapper.Save(spsDataSycnSetting);

                    obj.SyncDataSetting = spsDataSycnSetting;
                }

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