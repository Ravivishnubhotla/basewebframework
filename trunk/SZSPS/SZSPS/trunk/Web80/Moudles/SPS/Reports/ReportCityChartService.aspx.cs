using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class ReportCityChartService : System.Web.UI.Page
    {
        public int ReportClientChannleID
        {
            get
            {
                if (string.IsNullOrEmpty(this.Request.QueryString["ChannleClientSettingID"]))
                    return 0;
                return Convert.ToInt32(this.Request.QueryString["ChannleClientSettingID"]);
            }
        }

        public int ReportID
        {
            get
            {
                if (string.IsNullOrEmpty(this.Request.QueryString["ReportID"]))
                    return 0;
                return Convert.ToInt32(this.Request.QueryString["ReportID"]);
            }
        }

        public DateTime StartDate
        {
            get
            {
                if (string.IsNullOrEmpty(this.Request.QueryString["StartDate"]))
                    return DateTime.Now;
                return Convert.ToDateTime(this.Request.QueryString["StartDate"]);
            }
        }

        public DateTime EndDate
        {
            get
            {
                if (string.IsNullOrEmpty(this.Request.QueryString["EndDate"]))
                    return DateTime.Now;
                return Convert.ToDateTime(this.Request.QueryString["EndDate"]);
            }
        }

        public string Province
        {
            get
            {
                if (string.IsNullOrEmpty(this.Request.QueryString["Province"]))
                    return "";
                return this.Request.QueryString["Province"].Trim();
            }
        }

        public string ReportType
        {
            get
            {
                if (string.IsNullOrEmpty(this.Request.QueryString["ReportType"]))
                    return "";
                return this.Request.QueryString["ReportType"].Trim();
            }
        }



        private void BindData()
        {
            DataTable tb = null;
                
            if(ReportType=="1")
            {
                tb = SPDayReportWrapper.GetProvinceCityReport(StartDate, EndDate, ReportID, ReportClientChannleID, Province);
            }
            else if (ReportType == "2")
            {
                tb = SPDayReportWrapper.GetProvinceCityReportForClientGroup(StartDate, EndDate, ReportID, ReportClientChannleID, Province);     
            }
                
               

            ReportDataSource rds = new ReportDataSource("DataSet1", tb);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);


            string reporttypeName = "";

            if(ReportType=="1")
            {
                reporttypeName = "通道";
            }
            else if (ReportType == "2")
            {
                reporttypeName = "下家组";           
            }

            string reportName = string.Format("【{0}】-【{1}】数据分部报表", StartDate.ToString("yyyy-MM-dd"), EndDate.ToString("yyyy-MM-dd"));

            if (ReportID == 0)
            {
                reportName = "全平台" + reportName;
            }
            else
            {
                string name = "";
                if (ReportType == "1")
                {
                    name = SPChannelWrapper.FindById(ReportID).Name;
                }
                else if (ReportType == "2")
                {
                    name = SPClientGroupWrapper.FindById(ReportID).Name;
                }
 

                if (ReportClientChannleID == 0)
                {
                    reportName = string.Format(reporttypeName + "【{0}】", name) + reportName;
                }
                else
                {
                    SPClientChannelSettingWrapper clientChannelSetting = SPClientChannelSettingWrapper.FindById(ReportClientChannleID);

                    reportName = string.Format(reporttypeName + "【{0}】", name) + string.Format("指令【{0}】", clientChannelSetting.MoCode) + reportName;
                }
            }

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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
                return;
            FixReportDefinition(this.Server.MapPath("ReportCityChart.rdl"));
            ReportViewer1.LocalReport.ReportPath = this.Server.MapPath("ReportCityChart.rdl");
            BindData();
        }

        protected void ReportViewer1_ReportRefresh(object sender, CancelEventArgs e)
        {
            BindData();
        }
    }
}