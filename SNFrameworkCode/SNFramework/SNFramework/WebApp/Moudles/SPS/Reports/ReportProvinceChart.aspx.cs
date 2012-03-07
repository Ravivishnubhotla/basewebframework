using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Legendigital.Framework.Common.Web.UI;
using Microsoft.Reporting.WebForms;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Reports
{
    public partial class ReportProvinceChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
                return;
            //ReportViewHelper.EnableFormat(rptvContainer,ReportViewHelper.ReportViewer_RenderFormat_IMAGE);
            //ReportViewHelper.EnableFormat(rptvContainer, ReportViewHelper.ReportViewer_RenderFormat_HTML);
            //ReportViewHelper.EnableFormat(rptvContainer, ReportViewHelper.ReportViewer_RenderFormat_RGDI);
            ReportViewHelper.FixReportDefinition(this.Server.MapPath("ReportProvinceChart.rdl"));
            rptvContainer.LocalReport.ReportPath = this.Server.MapPath("ReportProvinceChart.rdl");
            BindData();
        }

        private void BindData()
        {
            DataTable tb = SPDayReportWrapper.QueryDayChannelProvine(System.DateTime.Now.Date.AddDays(-3), System.DateTime.Now.Date, 0).Tables[0];

            ReportDataSource rds = new ReportDataSource("DataSet1", tb);
            rptvContainer.LocalReport.DataSources.Clear();
            rptvContainer.LocalReport.DataSources.Add(rds);

            string reportName = string.Format("【{0}】-【{1}】数据省份分布报表", System.DateTime.Now.Date.AddDays(-3).ToString("yyyy-MM-dd"), System.DateTime.Now.Date.ToString("yyyy-MM-dd"));

            ReportParameter rpReportName = new ReportParameter();
            rpReportName.Name = "ReportName";
            rpReportName.Values.Add(reportName);

            rptvContainer.LocalReport.SetParameters(
             new ReportParameter[] { rpReportName });

            rptvContainer.LocalReport.Refresh();
        }

        protected void rptvContainer_ReportRefresh(object sender, CancelEventArgs e)
        {
            BindData();
        }
    }
}