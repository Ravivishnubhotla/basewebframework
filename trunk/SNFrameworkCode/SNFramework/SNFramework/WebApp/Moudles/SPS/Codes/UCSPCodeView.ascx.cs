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

    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPCodeView")]
    public partial class UCSPCodeView : System.Web.UI.UserControl
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



                    //this.lblID.Text = obj.ID.ToString();
                    this.lblName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    this.lblDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
                    this.lblCode.Text = ValueConvertUtil.ConvertStringValue(obj.Code);
                    this.lblChannelID.Text = obj.ChannelID.ToString();
                    //this.lblMO.Text = ValueConvertUtil.ConvertStringValue(obj.MO);
                    this.lblMOType.Text = ValueConvertUtil.ConvertStringValue(obj.MOType);
                    this.lblOrderIndex.Text = obj.OrderIndex.ToString();
                    this.lblSPCode.Text = ValueConvertUtil.ConvertStringValue(obj.SPCode);
                    this.lblProvince.Text = ValueConvertUtil.ConvertStringValue(obj.Province);
                    this.lblDisableCity.Text = ValueConvertUtil.ConvertStringValue(obj.DisableCity);
                    //this.lblIsDiable.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsDiable);
                    this.lblSPType.Text = ValueConvertUtil.ConvertStringValue(obj.SPType);
                    this.lblCodeLength.Text = obj.CodeLength.ToString();
                    this.lblDayLimit.Text = obj.DayLimit.ToString();
                    this.lblMonthLimit.Text = obj.MonthLimit.ToString();
                    this.lblPrice.Text = obj.Price.ToString();
                    this.lblSendText.Text = ValueConvertUtil.ConvertStringValue(obj.SendText);
                    //this.lblHasFilters.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.HasFilters);





                    //hidLogID.Text = id.ToString();


                    winSPCodeView.Show();

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
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
                return;
            }
        }


    }






}