 

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Reports
{
 
    public partial class SPAdReportListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            dfStart.SelectedDate = System.DateTime.Now.Date.AddDays(-2);
            dfStart.MaxDate = System.DateTime.Now.Date;
            dfEnd.SelectedDate = System.DateTime.Now.Date;
            dfEnd.MaxDate = System.DateTime.Now.Date;

 

            this.gridPanelSPAdReport.Reload();
        }


        [DirectMethod]
        public void DeleteRecord(int id)
        {
            try
            {
                SPAdReportWrapper.DeleteByID(id);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }

        protected void storeSPAdReport_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
 
 

            List<SPAdReportWrapper> spDayReports = SPAdReportWrapper.QueryReport(dfStart.SelectedDate, dfEnd.SelectedDate);

            storeSPAdReport.DataSource = spDayReports;
            storeSPAdReport.DataBind();

            this.lblTotalTotalSuccessCount.Text = spDayReports.Sum(p => p.AdCount).ToString();
            this.lblTotalDownSycnSuccess.Text = spDayReports.Sum(p => p.ClientCount).ToString();

        }
    }



}

			
