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
    public partial class ReportRecordDateRange : System.Web.UI.Page
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
            storeSPDayReport.DataSource = SPDayReportWrapper.QueryReport(dfStart.SelectedDate, dfEnd.SelectedDate);
            storeSPDayReport.DataBind();
        }
    }
}