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
    public partial class SPALLClientGroupReportService : System.Web.UI.Page
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
            FixReportDefinition(this.Server.MapPath("SPSALLClientGroupAmount.rdl"));
            ReportViewer1.LocalReport.ReportPath = this.Server.MapPath("SPSALLClientGroupAmount.rdl");
            BindData();
        }

        private void BindData()
        {
            DataTable tb = SPDayReportWrapper.GetALlClientGroupPriceReport(StartDate.Date, EndDate.Date);

            foreach (DataRow row in tb.Rows)
            {
                string moCode = "";

                if (row["ClientID"] != null && row["ClientID"] != System.DBNull.Value && !string.IsNullOrEmpty(row["ClientID"].ToString()))
                {
                    SPClientWrapper client = SPClientWrapper.FindById((int) row["ClientID"]);

                    if(client!=null)
                    {
                        SPClientChannelSettingWrapper channelSetting = client.DefaultClientChannelSetting;

                        if(channelSetting!=null)
                        {
                            moCode = channelSetting.MoCode;
                        }
                    }


                }


                row["ClientAliasName"] = row["ClientAliasName"] + " " + row["ClientID"].ToString() + " " + moCode;
            }
            


            ReportDataSource rds = new ReportDataSource("DataSet2", tb);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
 

            ReportParameter rpStartDate = new ReportParameter();
            rpStartDate.Name = "StartDate";
            rpStartDate.Values.Add(StartDate.ToShortDateString());

            ReportParameter rpEndDate = new ReportParameter();
            rpEndDate.Name = "EndDate";
            rpEndDate.Values.Add(EndDate.ToShortDateString());


            ReportViewer1.LocalReport.SetParameters(
             new ReportParameter[] {  rpStartDate, rpEndDate });



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