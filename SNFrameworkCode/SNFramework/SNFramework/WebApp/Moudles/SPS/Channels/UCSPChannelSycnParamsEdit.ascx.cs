using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Channels
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPChannelSycnParamsEdit")]
    public partial class UCSPChannelSycnParamsEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SPChannelSycnParamsWrapper obj = SPChannelSycnParamsWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    this.txtDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
                    this.chkIsEnable.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsEnable);

                    this.cmbChannelParamsType.SetValue(obj.ParamsType);
                    this.cmbParamsMappingName.SetValue(obj.MappingParams);
 
                    this.txtParamsValue.Text = ValueConvertUtil.ConvertStringValue(obj.ParamsValue);
 




                    hidId.Text = id.ToString();


                    winSPChannelSycnParamsEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "ErrorMessage:Data does not exist";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
                return;
            }
        }

        protected void btnSaveSPChannelSycnParams_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPChannelSycnParamsWrapper obj = SPChannelSycnParamsWrapper.FindById(int.Parse(hidId.Text.Trim()));
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.IsEnable = this.chkIsEnable.Checked;
 
                obj.MappingParams = this.cmbParamsMappingName.SelectedItem.Value;
 
                obj.ParamsValue = this.txtParamsValue.Text.Trim();
                obj.ParamsType = this.cmbChannelParamsType.SelectedItem.Value;


                SPChannelSycnParamsWrapper.Update(obj);

                winSPChannelSycnParamsEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
                return;
            }

        }
    }

}