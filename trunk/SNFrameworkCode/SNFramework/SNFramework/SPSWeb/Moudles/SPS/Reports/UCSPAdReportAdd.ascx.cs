  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Web.ControlHelper;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Reports
{
 
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPAdReportAdd")]
    public partial class UCSPAdReportAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSPAdReportAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
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

        protected void btnSaveSPAdReport_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPAdReportWrapper obj = new SPAdReportWrapper();
          //obj.ID = Convert.ToInt32(this.numID.Value.Trim());        	
                obj.SPAdID = Convert.ToInt32(this.cmbAd.SelectedItem.Value);
                obj.SPPackID = SPAdPackWrapper.FindById(Convert.ToInt32(this.cmbAdPack.Value));
                obj.SPClientID = SPSClientWrapper.FindById(Convert.ToInt32(this.cmbClient.Value));
                obj.ReportDate = this.dateReportDate.SelectedDate;
                obj.ClientCount = Convert.ToInt32(this.numClientCount.Value);
                obj.AdCount = Convert.ToInt32(this.numAdCount.Value);
                obj.AdAmount = 1;
                obj.CreateAt = System.DateTime.Now;
                obj.LastModifyAt = System.DateTime.Now;
                SPAdReportWrapper.SaveNewReport(obj);

                winSPAdReportAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }

        protected void storeClient_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            storeClient.DataSource = SPSClientWrapper.FindAll();
            storeClient.DataBind();

        }
    }




}

