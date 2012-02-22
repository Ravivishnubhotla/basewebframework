using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LD.SPPipeManage.Bussiness.Wrappers;
using Microsoft.Reporting.WebForms;

namespace Legendigital.Common.Web.Moudles.SPS.Reports
{
    public partial class SPALLClientGroupReportService1 : System.Web.UI.Page
    {
        public DateTime StartDate
        {
            get
            {
                if (this.Request.QueryString["StartDate"] == null)
                    return DateTime.Now;
                return Convert.ToDateTime(this.Request.QueryString["StartDate"]);
            }
        }

        public DateTime EndDate
        {
            get
            {
                if (this.Request.QueryString["EndDate"] == null)
                    return DateTime.Now;
                return Convert.ToDateTime(this.Request.QueryString["EndDate"]);
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
                return;
            FixReportDefinition(this.Server.MapPath("SPSALLClientGroupAmount1.rdl"));
            ReportViewer1.LocalReport.ReportPath = this.Server.MapPath("SPSALLClientGroupAmount1.rdl");
            BindData();
        }

        private void BindData()
        { 
            DataTable tb = SPDayReportWrapper.GetClientGroupTotalReport(StartDate.Date, EndDate.Date);

            ReportDataSource rds = new ReportDataSource("DataSet1", tb);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
 
            string reportName = string.Format("【{0}】-【{1}】下家结算报表", StartDate.ToString("yyyy-MM-dd"), EndDate.ToString("yyyy-MM-dd"));
 
            ReportParameter rpReportName = new ReportParameter();
            rpReportName.Name = "ReportName";
            rpReportName.Values.Add(reportName);

            ReportViewer1.LocalReport.SetParameters(
             new ReportParameter[] { rpReportName });
 
            ReportViewer1.LocalReport.Refresh();
        }

        public void FixReportDefinition(string reportPath)
        {
            string strReport = System.IO.File.ReadAllText(reportPath, System.Text.Encoding.UTF8);
            if (strReport.Contains("http://schemas.microsoft.com/sqlserver/reporting/2010/01/reportdefinition"))
            {
                strReport = strReport.Replace("<Report xmlns:rd=\"http://schemas.microsoft.com/SQLServer/reporting/reportdesigner\" xmlns:cl=\"http://schemas.microsoft.com/sqlserver/reporting/2010/01/componentdefinition\" xmlns=\"http://schemas.microsoft.com/sqlserver/reporting/2010/01/reportdefinition\">", "<Report xmlns:rd=\"http://schemas.microsoft.com/SQLServer/reporting/reportdesigner\" xmlns=\"http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition\">");
                strReport = strReport.Replace("<ReportSections>", "").Replace("<ReportSection>", "").Replace("</ReportSection>", "").Replace("</ReportSections>", "");
            }
            byte[] bytReport = System.Text.Encoding.UTF8.GetBytes(strReport);

            if (File.Exists(reportPath))
            {
                File.Delete(reportPath);
            }

            File.WriteAllBytes(reportPath, bytReport);
        }


        protected void ReportViewer1_ReportRefresh(object sender, System.ComponentModel.CancelEventArgs e)
        {
            BindData();
        }
    }
}