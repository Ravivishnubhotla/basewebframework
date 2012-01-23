using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Reports
{
    public partial class ReportRecordDate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            dfStart.SelectedDate = System.DateTime.Now.AddDays(-1);
            dfStart.MaxDate = System.DateTime.Now.AddDays(-1);
 

            this.gridPanelSPDayReport.Reload();
        }




        protected void storeSPDayReport_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            List<SPDayReportWrapper> spDayReports = SPDayReportWrapper.QueryReport(dfStart.SelectedDate, dfStart.SelectedDate);

            storeSPDayReport.DataSource = spDayReports;
            storeSPDayReport.DataBind();

            this.lblTotalTotalCount.Text = spDayReports.Sum(p => p.TotalCount).ToString();
            this.lblTotalTotalSuccessCount.Text = spDayReports.Sum(p => p.TotalSuccessCount).ToString();
            this.lblTotalInterceptCount.Text = spDayReports.Sum(p => p.InterceptCount).ToString();
            this.lblTotalDownTotalCount.Text = spDayReports.Sum(p => p.DownTotalCount).ToString();
            this.lblTotalDownSycnSuccess.Text = spDayReports.Sum(p => p.DownSycnSuccess).ToString();
            this.lblTotalDownSycnFailed.Text = spDayReports.Sum(p => p.DownSycnFailed).ToString();
            this.lblTotalDownNotSycn.Text = spDayReports.Sum(p => p.DownNotSycn).ToString();
        }
    }
}