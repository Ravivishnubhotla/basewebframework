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


    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPChannelParamsEdit")]
    public partial class UCSPChannelParamsEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SPChannelParamsWrapper obj = SPChannelParamsWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    this.txtDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
                    this.chkIsEnable.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsEnable);
                    this.chkIsRequired.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsRequired);

                    this.txtTitle.Text = ValueConvertUtil.ConvertStringValue(obj.Title);
                    this.chkShowInClientGrid.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.ShowInClientGrid);
                    this.txtParamsValue.Text = ValueConvertUtil.ConvertStringValue(obj.ParamsValue);

                    this.cmbChannelParamsType.SetValue(obj.ParamsType);
                    this.cmbParamsMappingName.SetValue(obj.ParamsMappingName);


                    hidId.Text = id.ToString();


                    winSPChannelParamsEdit.Show();


 

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

        protected void btnSaveSPChannelParams_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPChannelParamsWrapper obj = SPChannelParamsWrapper.FindById(int.Parse(hidId.Text.Trim()));
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.IsEnable = this.chkIsEnable.Checked;
                obj.IsRequired = this.chkIsRequired.Checked;
                obj.ParamsType = this.cmbChannelParamsType.SelectedItem.Value.Trim();
 
                obj.ParamsMappingName = this.cmbParamsMappingName.SelectedItem.Value.Trim();
                obj.Title = this.txtTitle.Text.Trim();
                obj.ShowInClientGrid = this.chkShowInClientGrid.Checked;
                obj.ParamsValue = this.txtParamsValue.Text.Trim();


                SPChannelParamsWrapper.Update(obj);

                winSPChannelParamsEdit.Hide();
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