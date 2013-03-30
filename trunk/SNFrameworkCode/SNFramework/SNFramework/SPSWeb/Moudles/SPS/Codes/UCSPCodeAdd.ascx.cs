using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SPS.Bussiness.Code;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Codes
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

        public SPChannelWrapper ChannelID
        {
            get
            {
                if (this.Request.QueryString["ChannelID"] != null)
                {
                    return
                        SPChannelWrapper.FindById(int.Parse(this.Request.QueryString["ChannelID"]));
                }
                return null;
            }
        }

        protected void btnSaveSPCode_Click(object sender, DirectEventArgs e)
        {
            try
            {
                //SPCodeWrapper obj = new SPCodeWrapper();

                //obj.Name = ChannelID.Name + "-" + this.txtMO.Text.Trim() + "-" + this.txtSPCode.Text.Trim() + "-" + this.cmbMOType.SelectedItem.Value;
                //obj.Code = ChannelID.Name + "-" + this.txtMO.Text.Trim() + "-" + this.txtSPCode.Text.Trim() + "-" + this.cmbMOType.SelectedItem.Value;
                //obj.Description = this.txtDescription.Text.Trim();
                //obj.ChannelID = ChannelID;
                //obj.Mo = this.txtMO.Text.Trim();
                //obj.MOType = this.cmbMOType.SelectedItem.Value;
                //obj.OrderIndex = Convert.ToInt32(this.numOrderIndex.Text.Trim());
                //obj.SPCode = this.txtSPCode.Text.Trim();
                ////obj.Province = this.txtProvince.Text.Trim();
                ////obj.DisableCity = this.txtDisableCity.Text.Trim();
                //obj.IsDiable = false;

                ////obj.SPType = "1";
                ////obj.CodeLength = obj.Mo.Length;
                ////obj.DayLimit =  this.txtDayLimit.Text.Trim()  ;
                ////obj.MonthLimit = this.txtMonthLimit.Text.Trim();
                //obj.Price = Convert.ToDecimal(this.txtPrice.Text.Trim());
                ////obj.SendText = this.txtCodeSendText.Text.Trim();
                ////obj.HasFilters = this.chkHasFilters.Checked;
                ////obj.HasParamsConvert = this.chkHasParamsConvert.Checked;

                ////SPCodeWrapper.QuickAddCode(obj, this.chkHasSubCode.Checked, this.txtSubCode.Text.Trim());

                winSPCodeAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }

        protected void storeAreaCountList_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            storeAreaCountList.DataSource = new List<PhoneLimitAreaAssigned>();

            storeAreaCountList.DataBind();
        }
    }
}