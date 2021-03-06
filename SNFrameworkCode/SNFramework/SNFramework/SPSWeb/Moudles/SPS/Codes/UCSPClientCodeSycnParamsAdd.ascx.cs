﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Codes
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPClientCodeSycnParamsAdd")]
    public partial class UCSPClientCodeSycnParamsAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSPClientCodeSycnParamsAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
            }
        }

        protected void btnSaveSPClientCodeSycnParams_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPClientCodeSycnParamsWrapper obj = new SPClientCodeSycnParamsWrapper();
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.IsEnable = this.chkIsEnable.Checked;
                obj.IsRequired = this.chkIsRequired.Checked;

                obj.MappingParams = this.txtMappingParams.Text.Trim();
                obj.Title = this.txtTitle.Text.Trim();
                obj.ParamsValue = this.txtParamsValue.Text.Trim();
                obj.ParamsType = this.txtParamsType.Text.Trim();





                SPClientCodeSycnParamsWrapper.Save(obj);

                winSPClientCodeSycnParamsAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }
    }
}