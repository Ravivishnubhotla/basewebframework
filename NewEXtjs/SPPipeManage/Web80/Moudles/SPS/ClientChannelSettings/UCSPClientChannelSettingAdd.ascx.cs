using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using ListItem = Coolite.Ext.Web.ListItem;

namespace Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPClientChannelSettingAdd")]
    public partial class UCSPClientChannelSettingAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Ext.IsAjaxRequest)
                return;
        }


        public int ChannleID
        {
            get
            {
                if (this.Request.QueryString["ChannleID"] == null)
                    return 0;
                return Convert.ToInt32(this.Request.QueryString["ChannleID"]);
            }
        }


        [AjaxMethod]
        public void Show()
        {
            try
            {
                //if (ChannleID>0)
                //{
                //    //this.cmbChannelID.SetValue(ChannleID);
                //    this.cmbChannelID.Disabled = true;
                //}
                //else
                //{
                //    this.cmbChannelID.Disabled = false;                
                //}

                this.winSPClientChannelSettingAdd.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSPClientChannelSetting_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPClientChannelSettingWrapper obj = new SPClientChannelSettingWrapper();

                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.ChannelID = SPChannelWrapper.FindById(Convert.ToInt32(this.cmbChannelID.SelectedItem.Value.ToString()));
                obj.ClinetID = SPClientWrapper.FindById(Convert.ToInt32(this.cmbClinetID.SelectedItem.Value.ToString()));        	
                obj.InterceptRate = Convert.ToInt32(this.txtInterceptRate.Text.Trim());
                obj.OrderIndex = Convert.ToInt32(this.numOrderIndex.Text.Trim());
                obj.UpRate = 0;
                obj.DownRate = 0;
                if (this.cmbChannelCodeParamsName.SelectedItem != null)
                    obj.CommandColumn = this.cmbChannelCodeParamsName.SelectedItem.Value;
                else
                    obj.CommandColumn = "";
                obj.CommandType = this.cmbCommandType.SelectedItem.Value.ToString();
                obj.CommandCode = this.txtCommandCode.Text.Trim();

                if (!this.fsAllowSycnData.Collapsed)
                {
                    obj.SyncData = true;
                    obj.SyncDataUrl = this.txtSyncDataUrl.Text.Trim();
                    if (this.cmbSycnType.SelectedItem != null)
                        obj.SyncType = this.cmbSycnType.SelectedItem.Value;
                    obj.OkMessage = this.txtOkMessage.Text.Trim();
                    obj.FailedMessage = this.txtFailedMessage.Text.Trim();
                }
                else
                {
                    obj.SyncData = false;
                }


                SPClientChannelSettingWrapper.Save(obj);

                winSPClientChannelSettingAdd.Hide();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }



    }

}