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


    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPChannelParamsAdd")]
    public partial class UCSPChannelParamsAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSPChannelParamsAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }

        protected void btnSaveSPChannelParams_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPChannelParamsWrapper obj = new SPChannelParamsWrapper();
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.IsEnable = this.chkIsEnable.Checked;
                obj.IsRequired = this.chkIsRequired.Checked;
                obj.ParamsType = this.txtParamsType.Text.Trim();
 
                obj.ParamsMappingName = this.txtParamsMappingName.Text.Trim();
                obj.Title = this.txtTitle.Text.Trim();
                obj.ShowInClientGrid = this.chkShowInClientGrid.Checked;
                obj.ParamsValue = this.txtParamsValue.Text.Trim();





                SPChannelParamsWrapper.Save(obj);

                winSPChannelParamsAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }
    }


}