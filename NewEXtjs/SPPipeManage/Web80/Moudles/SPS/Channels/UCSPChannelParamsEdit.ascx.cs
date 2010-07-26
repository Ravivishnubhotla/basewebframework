using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;


namespace Legendigital.Common.Web.Moudles.SPS.Channels
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPChannelParamsEdit")]
    public partial class UCSPChannelParamsEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SPChannelParamsWrapper obj = SPChannelParamsWrapper.FindById(id);

                if (obj != null)
                {
                    this.hidId.Value = obj.Id.ToString();
                    this.txtName.Text = obj.Name.ToString();
                    this.txtDescription.Text = obj.Description.ToString();
                    this.chkIsEnable.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsEnable);
                    this.chkIsRequired.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsRequired);
                    this.cmbParamsType.SetValue(obj.ParamsType.ToString());
                    this.lblChannelName.Text = obj.ChannelID.Name.ToString();
                    this.cmbParamsMappingName.SetValue(obj.ParamsMappingName.ToString());
                    this.txtTitle.Text = obj.Title;
                    this.chkShowInClientGrid.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.ShowInClientGrid);


                    hidId.Text = id.ToString();


                    winSPChannelParamsEdit.Show();

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

        protected void btnSaveSPChannelParams_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPChannelParamsWrapper obj = SPChannelParamsWrapper.FindById(int.Parse(hidId.Text.Trim()));

                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.IsEnable = this.chkIsEnable.Checked;
                obj.IsRequired = this.chkIsRequired.Checked;
                obj.ParamsType = this.cmbParamsType.SelectedItem.Value.ToString();
                obj.ParamsMappingName = this.cmbParamsMappingName.SelectedItem.Value.ToString();
                obj.Title = this.txtTitle.Text.Trim();
                obj.ShowInClientGrid = this.chkShowInClientGrid.Checked;


                SPChannelParamsWrapper.Update(obj);

                winSPChannelParamsEdit.Hide();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }

        }
    }


}