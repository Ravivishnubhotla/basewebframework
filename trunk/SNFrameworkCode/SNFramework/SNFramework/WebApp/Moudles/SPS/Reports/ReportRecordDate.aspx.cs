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
            storeSPDayReport.DataSource = SPDayReportWrapper.QueryReport(dfStart.SelectedDate, dfStart.SelectedDate);
            storeSPDayReport.DataBind();
        }
    }
}