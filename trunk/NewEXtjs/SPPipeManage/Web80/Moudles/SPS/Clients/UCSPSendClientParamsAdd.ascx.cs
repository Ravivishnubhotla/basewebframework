using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.Clients
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPSendClientParamsAdd")]
    public partial class UCSPSendClientParamsAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [AjaxMethod]
        public void Show(int clientID)
        {
            try
            {
                SPClientWrapper spClientWrapper = SPClientWrapper.FindById(clientID);

                this.hidClientID.Text = clientID.ToString();

                this.lblClientName.Text = spClientWrapper.Name;

                this.winSPSendClientParamsAdd.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSPSendClientParams_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPSendClientParamsWrapper obj = new SPSendClientParamsWrapper();
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.IsEnable = this.chkIsEnable.Checked;
                obj.IsRequired = this.chkIsRequired.Checked;
                obj.ClientID = SPClientWrapper.FindById(Convert.ToInt32(this.hidClientID.Text.Trim()));
                obj.MappingParams = this.cmbMappingParams.SelectedItem.Value.Trim();

                SPSendClientParamsWrapper.Save(obj);

                winSPSendClientParamsAdd.Hide();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }



    }

}