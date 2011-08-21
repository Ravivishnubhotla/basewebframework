using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Codes
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
                        //this.txtID.Text = obj.ID.ToString();
                        this.txtName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                        this.txtDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
                        this.txtCode.Text = ValueConvertUtil.ConvertStringValue(obj.Code);
                        this.txtChannelID.Text = obj.ChannelID.ToString();
                        //this.txtMO.Text = ValueConvertUtil.ConvertStringValue(obj.MO);
                        this.txtMOType.Text = ValueConvertUtil.ConvertStringValue(obj.MOType);
                        this.txtOrderIndex.Text = obj.OrderIndex.ToString();
                        this.txtSPCode.Text = ValueConvertUtil.ConvertStringValue(obj.SPCode);
                        this.txtProvince.Text = ValueConvertUtil.ConvertStringValue(obj.Province);
                        this.txtDisableCity.Text = ValueConvertUtil.ConvertStringValue(obj.DisableCity);
                        this.chkIsDiable.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsDiable);
                        this.txtSPType.Text = ValueConvertUtil.ConvertStringValue(obj.SPType);
                        this.txtCodeLength.Text = obj.CodeLength.ToString();
                        this.txtDayLimit.Text = obj.DayLimit.ToString();
                        this.txtMonthLimit.Text = obj.MonthLimit.ToString();
                        this.txtPrice.Text = obj.Price.ToString();
                        this.txtSendText.Text = ValueConvertUtil.ConvertStringValue(obj.SendText);
                        this.chkHasFilters.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.HasFilters);




                        hidId.Text = id.ToString();


                        winSPCodeEdit.Show();

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

            protected void btnSaveSPCode_Click(object sender, DirectEventArgs e)
            {
                try
                {
                    SPCodeWrapper obj = SPCodeWrapper.FindById(int.Parse(hidId.Text.Trim()));
                    obj.Id = Convert.ToInt32(this.txtID.Text.Trim());
                    obj.Name = this.txtName.Text.Trim();
                    obj.Description = this.txtDescription.Text.Trim();
                    obj.Code = this.txtCode.Text.Trim();
                    obj.ChannelID = Convert.ToInt32(this.txtChannelID.Text.Trim());
                    //obj.MO = this.txtMO.Text.Trim();
                    obj.MOType = this.txtMOType.Text.Trim();
                    obj.OrderIndex = Convert.ToInt32(this.txtOrderIndex.Text.Trim());
                    obj.SPCode = this.txtSPCode.Text.Trim();
                    obj.Province = this.txtProvince.Text.Trim();
                    obj.DisableCity = this.txtDisableCity.Text.Trim();
                    obj.IsDiable = this.chkIsDiable.Checked;
                    obj.SPType = this.txtSPType.Text.Trim();
                    obj.CodeLength = Convert.ToInt32(this.txtCodeLength.Text.Trim());
                    obj.DayLimit = Convert.ToInt32(this.txtDayLimit.Text.Trim());
                    obj.MonthLimit = Convert.ToInt32(this.txtMonthLimit.Text.Trim());
                    obj.Price = Convert.ToDecimal(this.txtPrice.Text.Trim());
                    obj.SendText = this.txtSendText.Text.Trim();
                    obj.HasFilters = this.chkHasFilters.Checked;


                    SPCodeWrapper.Update(obj);

                    winSPCodeEdit.Hide();
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