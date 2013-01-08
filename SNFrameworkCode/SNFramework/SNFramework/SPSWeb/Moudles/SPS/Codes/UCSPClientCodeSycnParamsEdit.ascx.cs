using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Codes
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPClientCodeSycnParamsEdit")]
    public partial class UCSPClientCodeSycnParamsEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SPClientCodeSycnParamsWrapper obj = SPClientCodeSycnParamsWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    this.txtDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
                    this.chkIsEnable.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsEnable);
                    this.chkIsRequired.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsRequired);
                    this.txtCodeID.Text = obj.CodeID.ToString();
                    this.txtMappingParams.Text = ValueConvertUtil.ConvertStringValue(obj.MappingParams);
                    this.txtTitle.Text = ValueConvertUtil.ConvertStringValue(obj.Title);
                    this.txtParamsValue.Text = ValueConvertUtil.ConvertStringValue(obj.ParamsValue);
                    this.txtParamsType.Text = ValueConvertUtil.ConvertStringValue(obj.ParamsType);




                    hidId.Text = id.ToString();


                    winSPClientCodeSycnParamsEdit.Show();

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

        protected void btnSaveSPClientCodeSycnParams_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPClientCodeSycnParamsWrapper obj = SPClientCodeSycnParamsWrapper.FindById(int.Parse(hidId.Text.Trim()));
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.IsEnable = this.chkIsEnable.Checked;
                obj.IsRequired = this.chkIsRequired.Checked;

                obj.MappingParams = this.txtMappingParams.Text.Trim();
                obj.Title = this.txtTitle.Text.Trim();
                obj.ParamsValue = this.txtParamsValue.Text.Trim();
                obj.ParamsType = this.txtParamsType.Text.Trim();


                SPClientCodeSycnParamsWrapper.Update(obj);

                winSPClientCodeSycnParamsEdit.Hide();
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