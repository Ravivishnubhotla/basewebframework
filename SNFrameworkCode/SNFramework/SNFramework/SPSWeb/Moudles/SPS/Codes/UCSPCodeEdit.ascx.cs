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
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPCodeEdit")]
    public partial class UCSPCodeEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SPCodeWrapper obj = SPCodeWrapper.FindById(id);

                if (obj != null)
                {
                    this.hidId.Text = obj.Id.ToString();
                    this.txtName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    this.txtDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
                    this.txtCode.Text = ValueConvertUtil.ConvertStringValue(obj.Code);

                    this.txtMO.Text = ValueConvertUtil.ConvertStringValue(obj.Mo);
                    this.cmbMOType.Value = ValueConvertUtil.ConvertStringValue(obj.MOType);
                    this.numOrderIndex.Text = obj.OrderIndex.ToString();
                    this.txtSPCode.Text = ValueConvertUtil.ConvertStringValue(obj.SPCode);
                    //if (!string.IsNullOrEmpty(obj.Province))
                    //    WebUIHelper.SetSelectMutilItems(mcmbProvince, "|", obj.Province); 
                    //this.txtProvince.Text = obj.Province.ToString();
                    //this.txtDisableCity.Text = ValueConvertUtil.ConvertStringValue(obj.DisableCity);
                    this.chkIsDiable.Checked = obj.IsDiable;


                    //this.txtDayLimit.Text = obj.DayLimit.ToString();
                    //this.txtMonthLimit.Text = obj.MonthLimit.ToString();
                    this.txtPrice.Text = obj.Price.ToString();
                    //this.txtCodeSendText.Text = ValueConvertUtil.ConvertStringValue(obj.SendText);
                    this.chkHasFilters.Checked = obj.HasFilters;
                    this.chkHasParamsConvert.Checked = obj.HasParamsConvert;



                    hidId.Text = id.ToString();


                    winSPCodeEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "Error Message:Data does not exist";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
                return;
            }
        }

        protected void btnSaveSPCode_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPCodeWrapper obj = SPCodeWrapper.FindById(int.Parse(hidId.Text.Trim()));
                obj.Id = Convert.ToInt32(this.hidId.Text.Trim());
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.Code = this.txtCode.Text.Trim();
                obj.Mo = this.txtMO.Text.Trim();
                obj.MOType = this.cmbMOType.SelectedItem.Value;
                obj.OrderIndex = Convert.ToInt32(this.numOrderIndex.Text.Trim());
                obj.SPCode = this.txtSPCode.Text.Trim();
                //obj.Province = this.txtProvince.Text.Trim();
                //obj.DisableCity = this.txtDisableCity.Text.Trim();
                obj.IsDiable = this.chkIsDiable.Checked;

                //obj.CodeLength = obj.Mo.Length;
                //obj.DayLimit =  this.txtDayLimit.Text.Trim();
                //obj.MonthLimit = this.txtMonthLimit.Text.Trim();
                obj.Price = Convert.ToDecimal(this.txtPrice.Text.Trim());
                //obj.SendText = this.txtCodeSendText.Text.Trim();
                obj.HasFilters = this.chkHasFilters.Checked;
                obj.HasParamsConvert = this.chkHasParamsConvert.Checked;

                SPCodeWrapper.Update(obj);

                winSPCodeEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息:" + ex.Message;
                return;
            }

        }
    }
}