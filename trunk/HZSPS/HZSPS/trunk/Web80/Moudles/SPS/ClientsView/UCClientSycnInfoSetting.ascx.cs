using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.ClientsView
{
            [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCClientSycnInfoSetting")]
    public partial class UCClientSycnInfoSetting : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SPClientChannelSettingWrapper obj = SPClientChannelSettingWrapper.FindById(id);

                if (obj != null)
                {
 

                    this.txtShowCode.Text = obj.ChannelClientCode;


                    if (obj.Name != null)
                        this.txtName.Text = obj.ClinetID.DisplayName;
                    else
                        this.txtName.Text = "";


                    if (obj.Description != null)
                        this.txtDescription.Text = obj.Description.ToString();
                    else
                        this.txtDescription.Text = "";

                    this.lblChanneCode.Text = obj.ChannelCode;

                    if (obj.ChannelCode != null)
                        this.lblChanneCode.Text = obj.ChannelCode.ToString();
                    else
                        this.lblChanneCode.Text = "";

 




                    this.fsAllowSycnData.CheckboxToggle = obj.SyncData.HasValue && obj.SyncData.Value;

                    this.fsAllowSycnData.Collapsed = !this.fsAllowSycnData.CheckboxToggle;
                    if (!string.IsNullOrEmpty(obj.ClinetID.SPClientGroupID.DefaultSycnMoUrl))
                        this.fsAllowSycnData.Disabled = false;
                    else
                        this.fsAllowSycnData.Disabled = true;

                    if (obj.SyncData.HasValue && obj.SyncData.Value)
                    {
                        if (obj.SyncDataUrl != null)
                            this.txtSyncDataUrl.Text = obj.SyncDataUrl;
                        else
                            this.txtSyncDataUrl.Text = "";
                    }
                    else
                    {
                        this.txtSyncDataUrl.Text = "";
                    }



                    hidId.Text = id.ToString();

                    winSPClientChannelSettingEdit.Show();

                }
                else
                {
                    ScriptManager.AjaxSuccess = false;
                    ScriptManager.AjaxErrorMessage = "错误信息：数据不存在";
                    return;
                }
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }
        }

        protected void btnSaveSPClientChannelSetting_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPClientChannelSettingWrapper obj = SPClientChannelSettingWrapper.FindById(int.Parse(hidId.Text.Trim()));

                if (!this.fsAllowSycnData.Collapsed)
                {

                    if (!this.txtSyncDataUrl.Text.Trim().ToLower().StartsWith("http://"))
                    {
                        Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                        Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：提交地址一定要以http://开头";
                        return;
                    }




                    obj.SyncData = true;
                    obj.SyncDataUrl = this.txtSyncDataUrl.Text.Trim();
 
                    obj.SyncType = "1";
                    obj.OkMessage = "ok";
                    obj.FailedMessage = "failed";
                }
                else
                {
                    obj.SyncData = false;
                    obj.SyncDataUrl = "";
                    obj.SyncType = "";
                    obj.OkMessage = "";
                    obj.FailedMessage = "";
                    obj.SyncType = "1";
                }


                SPClientChannelSettingWrapper.Update(obj);

                obj.ChannelID.RefreshChannelInfo();

                winSPClientChannelSettingEdit.Hide();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }

        }


 
    }
}