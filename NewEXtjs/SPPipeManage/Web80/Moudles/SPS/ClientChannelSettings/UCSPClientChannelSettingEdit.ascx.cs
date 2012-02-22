using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPClientChannelSettingEdit")]
    public partial class UCSPClientChannelSettingEdit : System.Web.UI.UserControl
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
                    if (obj.ChannelID!=null)
                    {
                        this.lblChannelName.Text = obj.ChannelID.Name;
                    }
                    else
                    {
                        this.lblChannelName.Text = "";
                    }
                    if (obj.ClinetID!=null)
                    {
                        this.lblClientName.Text = obj.ClinetID.Name;
                    }
                    else
                    {
                        this.lblClientName.Text = "";
                    }

                    if (obj.Name!=null)
                        this.txtName.Text = obj.Name.ToString();
                    else
                        this.txtName.Text = "";


                    if (obj.Description!=null)
                        this.txtDescription.Text = obj.Description.ToString();
                    else
                        this.txtDescription.Text = "";

                    if (obj.ChannelCode != null)
                        this.txtChannleCode.Text = obj.ChannelCode.ToString();
                    else
                        this.txtChannleCode.Text = "";


 

              	    this.txtInterceptRate.Text = obj.InterceptRate.ToString();


                    if (obj.OrderIndex.HasValue)
                        this.numOrderIndex.SetValue(obj.OrderIndex.Value);
                    else
                        this.numOrderIndex.Text = "";

                    if (!string.IsNullOrEmpty(obj.CommandColumn))
                        this.cmbChannelCodeParamsName.SetValue(obj.CommandColumn);
                    else
                        this.cmbChannelCodeParamsName.SetValue("");

                    this.cmbCommandType.SetValue(obj.CommandType.ToString());

                    if (obj.CommandCode != null)
              	        this.txtCommandCode.Text = obj.CommandCode.ToString();
                    else
                        this.txtCommandCode.Text = "";

                    this.fsAllowSycnData.CheckboxToggle = obj.SyncData.HasValue && obj.SyncData.Value;

                    this.fsAllowSycnData.Collapsed = !this.fsAllowSycnData.CheckboxToggle;

                    this.chkDisable.Checked = obj.Disable.HasValue && obj.Disable.Value;

                    this.txtDefaultNoInterceptCount.Text = obj.DefaultNoInterceptCount.ToString();

                    if (obj.SyncData.HasValue && obj.SyncData.Value)
                    {
                        if (obj.SyncDataUrl != null)
                            this.txtSyncDataUrl.Text = obj.SyncDataUrl;
                        else
                            this.txtSyncDataUrl.Text = "";



                        if (!string.IsNullOrEmpty(obj.SyncType))
                            this.cmbSycnType.SetInitValue(obj.SyncType);
                        else
                            this.cmbSycnType.SelectedIndex = 0;

                        if (obj.OkMessage != null)
                            this.txtOkMessage.Text = obj.OkMessage;
                        else
                            this.txtOkMessage.Text = "";


                        if (obj.FailedMessage != null)
                            this.txtFailedMessage.Text = obj.FailedMessage;
                        else
                            this.txtFailedMessage.Text = "";


                    }
                    else
                    {
                        this.txtSyncDataUrl.Text = "";
                        this.cmbSycnType.SetValue("");
                        this.txtOkMessage.Text = "";
                        this.txtFailedMessage.Text = "";
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
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.InterceptRate = Convert.ToInt32(this.txtInterceptRate.Text.Trim());
                obj.UpRate = 0;
                obj.DownRate = 0;
                obj.OrderIndex = Convert.ToInt32(this.numOrderIndex.Text.Trim());
                if (this.cmbChannelCodeParamsName.SelectedItem != null)
                    obj.CommandColumn = this.cmbChannelCodeParamsName.SelectedItem.Value;
                else
                    obj.CommandColumn = "";
                obj.CommandType = this.cmbCommandType.SelectedItem.Value.ToString();
                obj.CommandCode = this.txtCommandCode.Text;
                obj.Disable = this.chkDisable.Checked;
                obj.ChannelCode = this.txtChannleCode.Text.Trim();
                obj.DefaultNoInterceptCount = Convert.ToInt32(this.txtDefaultNoInterceptCount.Text);
 


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
                    if (this.cmbSycnType.SelectedItem != null)
                        obj.SyncType = this.cmbSycnType.SelectedItem.Value;
                    else
                        obj.SyncType = "1";
                    obj.OkMessage = this.txtOkMessage.Text.Trim();
                    obj.FailedMessage = this.txtFailedMessage.Text.Trim();
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