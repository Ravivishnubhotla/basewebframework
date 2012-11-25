  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Clients
{
 
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPAdPackAdd")]
    public partial class UCSPAdPackAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSPAdPackAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
            }
        }

        protected void btnSaveSPAdPack_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPAdPackWrapper adPack = SPAdPackWrapper.FindById(Convert.ToInt32(cmbAdPack.SelectedItem.Value.ToString()));

                decimal clientPrice = Convert.ToDecimal(numClientPrice.Value);

                SPAdAssignedHistortyWrapper.ClientAssignedAdPack(SPSClientID, adPack, clientPrice);
 
                winSPAdPackAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }

        public SPSClientWrapper SPSClientID
        {
            get
            {
                if (this.Request.QueryString["SPSClientID"] != null)
                {
                    return
                        SPSClientWrapper.FindById(int.Parse(this.Request.QueryString["SPSClientID"]));
                }
                return null;
            }
        }

        protected void storeAd_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            storeAd.DataSource = SPAdvertisementWrapper.FindAll();
            storeAd.DataBind();
        }

        protected void storeAdPack_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            if (cmbAd.SelectedItem != null)
            {
                this.storeAdPack.DataSource = SPAdPackWrapper.FindAllBySPAdID(SPAdvertisementWrapper.FindById(Convert.ToInt32(cmbAd.SelectedItem.Value)));
            }
            else
            {
                this.storeAdPack.DataSource = new List<SPAdPackWrapper>();
            }
            this.storeAdPack.DataBind();
        }
    }




}

