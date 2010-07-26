using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;


namespace Legendigital.Common.Web.Moudles.SPS.Clients
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPSendClientParamsEdit")]
    public partial class UCSPSendClientParamsEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SPSendClientParamsWrapper obj = SPSendClientParamsWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtName.Text = obj.Name.ToString();
                    this.txtDescription.Text = obj.Description.ToString();
                    this.chkIsEnable.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsEnable);
                    this.chkIsRequired.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsRequired);
                    this.lblClientName.Text = obj.ClientID.Name.ToString();
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
                SPSendClientParamsWrapper obj = SPSendClientParamsWrapper.FindById(int.Parse(hidId.Text.Trim()));
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.IsEnable = this.chkIsEnable.Checked;
                obj.IsRequired = this.chkIsRequired.Checked;
                obj.MappingParams = this.cmbMappingParams.SelectedItem.Value.Trim();
                obj.Title = this.txtTitle.Text.Trim();

                SPSendClientParamsWrapper.Update(obj);

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