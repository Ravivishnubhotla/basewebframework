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
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPChannelParamsAdd")]
    public partial class UCSPChannelParamsAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [AjaxMethod]
        public void Show(int channelID)
        {
            try
            {
                SPChannelWrapper spChannelWrapper = SPChannelWrapper.FindById(channelID);

                this.hidChannelID.Text = channelID.ToString();

                this.lblChannelName.Text = spChannelWrapper.Name;

                this.winSPChannelParamsAdd.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSPChannelParams_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPChannelParamsWrapper obj = new SPChannelParamsWrapper();

                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.IsEnable = this.chkIsEnable.Checked;
                obj.IsRequired = this.chkIsRequired.Checked;
                obj.ParamsType = this.cmbParamsType.SelectedItem.Value.Trim();
                obj.ChannelID = SPChannelWrapper.FindById(Convert.ToInt32(this.hidChannelID.Text.Trim()));
                obj.ParamsMappingName = this.cmbParamsMappingName.SelectedItem.Text.Trim();

                SPChannelParamsWrapper.Save(obj);

                winSPChannelParamsAdd.Hide();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }


    }


}