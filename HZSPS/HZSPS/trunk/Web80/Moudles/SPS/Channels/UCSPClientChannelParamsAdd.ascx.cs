using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.Channels
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPClientChannelParamsAdd")]
    public partial class UCSPClientChannelParamsAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                SPChannelWrapper spChannelWrapper = SPChannelWrapper.FindById(ChannleID);

                this.hidClientID.Text = spChannelWrapper.Id.ToString();

                this.lblClientName.Text = spChannelWrapper.Name;

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
                SPChannelDefaultClientSycnParamsWrapper obj = new SPChannelDefaultClientSycnParamsWrapper();
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.IsEnable = this.chkIsEnable.Checked;
                obj.IsRequired = this.chkIsRequired.Checked;
                obj.ChannelID = SPChannelWrapper.FindById(Convert.ToInt32(this.hidClientID.Text.Trim()));
                obj.MappingParams = this.cmbMappingParams.SelectedItem.Value.Trim();
                obj.Title = this.txtTitle.Text.Trim();
                SPChannelDefaultClientSycnParamsWrapper.Save(obj);

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