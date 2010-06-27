using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.Reports
{
    public partial class ReportChannel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Ext.IsAjaxRequest)
            {
                //dfReportDate.DateField.Value = System.DateTime.Now;
                this.Store1.DataSource = SPDayReportWrapper.GetDayliyReport(System.DateTime.Now);
                this.Store1.DataBind();
            }
        }



        protected void Store1_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            this.Store1.DataSource = SPDayReportWrapper.GetDayliyReport(System.DateTime.Now);
            this.Store1.DataBind();
        }
    }
}
