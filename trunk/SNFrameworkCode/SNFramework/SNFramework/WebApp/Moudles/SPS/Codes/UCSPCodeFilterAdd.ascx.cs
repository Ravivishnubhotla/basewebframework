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


    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPCodeFilterAdd")]
    public partial class UCSPCodeFilterAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSPCodeFilterAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
            }
        }

        protected void btnSaveSPCodeFilter_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPCodeFilterWrapper obj = new SPCodeFilterWrapper();
 
                obj.ParamsName = this.txtParamsName.Text.Trim();
                obj.FilterType = this.txtFilterType.Text.Trim();
                obj.FilterValue = this.txtFilterValue.Text.Trim();





                SPCodeFilterWrapper.Save(obj);

                winSPCodeFilterAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }
    }



}