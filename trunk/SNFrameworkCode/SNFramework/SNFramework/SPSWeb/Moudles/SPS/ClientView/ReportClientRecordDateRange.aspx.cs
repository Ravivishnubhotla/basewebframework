using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.ClientView
{
    public partial class ReportClientRecordDateRange : SPClientViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            dfStart.SelectedDate = System.DateTime.Now.AddDays(-3);
            dfStart.MaxDate = System.DateTime.Now.AddDays(-1);
            dfEnd.SelectedDate = System.DateTime.Now.AddDays(-1);
            dfEnd.MaxDate = System.DateTime.Now.AddDays(-1);

            this.gridPanelSPDayReport.Reload();
        }




        protected void storeSPDayReport_Refresh(object sender, StoreRefreshDataEventArgs e)
        {

            List<SPDayReportWrapper> spDayReports = SPDayReportWrapper.QueryReport(dfStart.SelectedDate, dfEnd.SelectedDate, this.Client);

            storeSPDayReport.DataSource = spDayReports;
            storeSPDayReport.DataBind();


            this.lblTotalDownTotalCount.Text = spDayReports.Sum(p => p.DownTotalCount).ToString();
            this.lblTotalDownSycnSuccess.Text = spDayReports.Sum(p => p.DownSycnSuccess).ToString();
            this.lblTotalDownSycnFailed.Text = spDayReports.Sum(p => p.DownSycnFailed).ToString();

        }
    }
}