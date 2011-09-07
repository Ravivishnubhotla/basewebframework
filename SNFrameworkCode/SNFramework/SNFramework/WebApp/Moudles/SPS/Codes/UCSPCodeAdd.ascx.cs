using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Codes
{

    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPCodeAdd")]
    public partial class UCSPCodeAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSPCodeAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
            }
        }

        protected void btnSaveSPCode_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPCodeWrapper obj = new SPCodeWrapper();
                //obj.ID = Convert.ToInt32(this.txtID.Text.Trim());
                //obj.Name = this.txtName.Text.Trim();
                //obj.Description = this.txtDescription.Text.Trim();
                //obj.Code = this.txtCode.Text.Trim();
                //obj.ChannelID = Convert.ToInt32(this.txtChannelID.Text.Trim());
                //obj.MO = this.txtMO.Text.Trim();
                //obj.MOType = this.txtMOType.Text.Trim();
                //obj.OrderIndex = Convert.ToInt32(this.txtOrderIndex.Text.Trim());
                obj.SPCode = this.txtSPCode.Text.Trim();
                obj.Province = this.txtProvince.Text.Trim();
                obj.DisableCity = this.txtDisableCity.Text.Trim();
                //obj.IsDiable = this.chkIsDiable.Checked;
                //obj.SPType = this.txtSPType.Text.Trim();
                //obj.CodeLength = Convert.ToInt32(this.txtCodeLength.Text.Trim());
                obj.DayLimit =  this.txtDayLimit.Text.Trim()  ;
                obj.MonthLimit = this.txtMonthLimit.Text.Trim());
                //obj.Price = Convert.ToDecimal(this.txtPrice.Text.Trim());
                //obj.SendText = this.txtSendText.Text.Trim();
                //obj.HasFilters = this.chkHasFilters.Checked;





                SPCodeWrapper.Save(obj);

                winSPCodeAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }
    }



}