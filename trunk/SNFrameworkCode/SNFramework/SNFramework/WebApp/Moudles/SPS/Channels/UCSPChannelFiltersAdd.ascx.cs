using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Channels
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPChannelFiltersAdd")]
    public partial class UCSPChannelFiltersAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSPChannelFiltersAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
            }
        }

        protected void btnSaveSPChannelFilters_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPChannelFiltersWrapper obj = new SPChannelFiltersWrapper();
 
                obj.ParamsName = this.txtParamsName.Text.Trim();
                obj.FilterType = this.txtFilterType.Text.Trim();
                obj.FilterValue = this.txtFilterValue.Text.Trim();





                SPChannelFiltersWrapper.Save(obj);

                winSPChannelFiltersAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }
    }


}