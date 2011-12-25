using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Reports
{
    public partial class ReportCountRecordToday : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;



            this.gridPanelSPDayReport.Reload();
        }


 

        protected void storeSPDayReport_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            storeSPDayReport.DataSource = SPDayReportWrapper.CaculateReport(System.DateTime.Now.Date);
            storeSPDayReport.DataBind();
        }
    }
}