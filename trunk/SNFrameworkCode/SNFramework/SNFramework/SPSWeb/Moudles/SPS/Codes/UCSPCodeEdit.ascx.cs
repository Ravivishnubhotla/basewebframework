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
                    this.hidSPCodeID.Text = obj.Id.ToString();
                    this.txtDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
 

                    this.txtMO.Text = ValueConvertUtil.ConvertStringValue(obj.Mo);
                    this.lblCodeType.Text = obj.MoCode;
 
                    this.txtSPCode.Text = ValueConvertUtil.ConvertStringValue(obj.SPCode);
 
                    this.chkIsDiable.Checked = obj.IsDiable;

 
                    this.txtPrice.Text = obj.Price.ToString();
                    //this.txtCodeSendText.Text = ValueConvertUtil.ConvertStringValue(obj.SendText);
                    this.chkHasFilters.Checked = obj.HasFilters;
                    this.chkHasParamsConvert.Checked = obj.HasParamsConvert;


 


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


    }
}