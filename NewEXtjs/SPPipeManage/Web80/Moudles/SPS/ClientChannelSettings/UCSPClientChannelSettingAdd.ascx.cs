﻿using System;
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


        [AjaxMethod]
        public void Show()
        {
            try
            {
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

                obj.ChannelID = SPChannelWrapper.FindById(Convert.ToInt32(this.cmbChannelID.SelectedItem.Value.ToString()));
                obj.ClinetID = SPClientWrapper.FindById(Convert.ToInt32(this.cmbClinetID.SelectedItem.Value.ToString()));        	
                obj.InterceptRate = Convert.ToInt32(this.txtInterceptRate.Text.Trim());
                obj.UpRate = 0;
                obj.DownRate = 0;
                if (this.cmbChannelCodeParamsName.SelectedItem != null)
                    obj.CommandColumn = this.cmbChannelCodeParamsName.SelectedItem.Value;
                else
                    obj.CommandColumn = "";
                obj.CommandType = this.cmbCommandType.SelectedItem.Value.ToString();
                obj.CommandCode = this.txtCommandCode.Text.Trim();

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