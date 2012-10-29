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
    public partial class ReportAdDataRange  : SPClientViewPage
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

        protected void storeSPAdReport_Refresh(object sender, StoreRefreshDataEventArgs e)
        {



            List<SPAdReportWrapper> spDayReports = SPAdReportWrapper.QueryReport(dfStart.SelectedDate, dfEnd.SelectedDate,this.Client);

            storeSPAdReport.DataSource = spDayReports;
            storeSPAdReport.DataBind();
 
            this.lblTotalDownSycnSuccess.Text = spDayReports.Sum(p => p.ClientCount).ToString();

        }
    }
}