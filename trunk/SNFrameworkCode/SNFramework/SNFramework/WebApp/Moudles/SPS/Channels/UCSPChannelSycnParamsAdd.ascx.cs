using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Channels
{

    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPChannelSycnParamsAdd")]
    public partial class UCSPChannelSycnParamsAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSPChannelSycnParamsAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
            }
        }

        protected void btnSaveSPChannelSycnParams_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPChannelSycnParamsWrapper obj = new SPChannelSycnParamsWrapper();
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.IsEnable = this.chkIsEnable.Checked;
 
                obj.MappingParams = this.txtMappingParams.Text.Trim();
                obj.Title = this.txtTitle.Text.Trim();
                obj.ParamsValue = this.txtParamsValue.Text.Trim();
                obj.ParamsType = this.txtParamsType.Text.Trim();





                SPChannelSycnParamsWrapper.Save(obj);

                winSPChannelSycnParamsAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }
    }


}