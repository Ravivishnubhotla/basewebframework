using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Channels
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


        public SPChannelWrapper ChannelID
        {
            get
            {
                if (this.Request.QueryString["ChannelID"] != null)
                {
                    return
                        SPChannelWrapper.FindById(int.Parse(this.Request.QueryString["ChannelID"]));
                }
                return null;
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
                obj.ParamsType = this.cmbChannelParamsType.SelectedItem.Value.Trim();
                obj.ChannelID = ChannelID;
                obj.ParamsMappingName = this.cmbParamsMappingName.SelectedItem.Value.Trim();
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