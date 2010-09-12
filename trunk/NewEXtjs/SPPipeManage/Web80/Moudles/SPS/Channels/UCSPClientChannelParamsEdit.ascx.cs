using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;
using ScriptManager = Coolite.Ext.Web.ScriptManager;

namespace Legendigital.Common.Web.Moudles.SPS.Channels
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPClientChannelParamsEdit")]
    public partial class UCSPClientChannelParamsEdit : System.Web.UI.UserControl
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
        public void Show(int id)
        {
            try
            {
                SPChannelDefaultClientSycnParamsWrapper obj = SPChannelDefaultClientSycnParamsWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtName.Text = obj.Name.ToString();
                    this.txtDescription.Text = obj.Description.ToString();
                    this.chkIsEnable.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsEnable);
                    this.chkIsRequired.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsRequired);
                    this.lblClientName.Text = obj.ChannelID.Name.ToString();
                    this.cmbMappingParams.SetValue(obj.MappingParams.ToString());
                    this.txtTitle.Text = obj.Title;



                    hidId.Text = id.ToString();


                    winSPSendClientParamsEdit.Show();

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

        protected void btnSaveSPSendClientParams_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPChannelDefaultClientSycnParamsWrapper obj = SPChannelDefaultClientSycnParamsWrapper.FindById(int.Parse(hidId.Text.Trim()));
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.IsEnable = this.chkIsEnable.Checked;
                obj.IsRequired = this.chkIsRequired.Checked;
                obj.MappingParams = this.cmbMappingParams.SelectedItem.Value.Trim();
                obj.Title = this.txtTitle.Text.Trim();

                SPChannelDefaultClientSycnParamsWrapper.Update(obj);

                winSPSendClientParamsEdit.Hide();
            }
            catch
                (Exception
                ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }

        }
    }
}