using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
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
                SPCodeWrapper obj = new SPCodeWrapper();


                obj.Description = this.txtDescription.Text.Trim();
                obj.ChannelID = ChannelID;

                obj.IsMatchCase = chkIsMatchCase.Checked;


                if (!chkIsMatchCase.Checked)
                    obj.Mo = this.txtMO.Text.Trim();
                else
                    obj.Mo = this.txtMO.Text;


                obj.MOType = this.cmbCodeType.SelectedItem.Value;
                obj.MOLength = obj.Mo.Length;
                obj.MOType = this.cmbCodeType.SelectedItem.Value;
                obj.OrderIndex = 1;
                obj.SPCode = this.txtSPCode.Text.Trim();
                obj.SPCodeType = "1";
                obj.SPCodeLength = obj.SPCode.Length;
                obj.IsDiable = this.chkIsDiable.Checked;

                obj.LimitProvince = this.chkLimitProvince.Checked;
                obj.LimitProvinceArea = WebUIHelper.GetSelectMutilItems(this.mfLimitProvinceArea, ",");

                obj.HasPhoneLimit = this.chkHasPhoneLimit.Checked;

                obj.HasFilters = this.chkHasFilters.Checked;
                obj.HasParamsConvert = this.chkHasParamsConvert.Checked;
                obj.HasPhoneLimit = this.chkHasPhoneLimit.Checked;

                obj.Price = Convert.ToDecimal(this.nfPrice.Text.Trim());

                obj.Description = this.txtDescription.Text.Trim();

                //obj.SendText = this.txtCodeSendText.Text.Trim();

                obj.Name = ChannelID.Name + "-" + obj.MoCode;
                obj.Code = ChannelID.Name + "-" + obj.MoCode;

                SPCodeWrapper.QuickAddCode(obj,this.txtSubCodes.Text);

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