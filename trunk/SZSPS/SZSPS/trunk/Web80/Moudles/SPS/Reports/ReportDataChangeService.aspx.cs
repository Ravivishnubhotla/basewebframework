﻿using System;
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
    public partial class ReportDataChangeService : System.Web.UI.Page
    {
        public int ReportClientChannleID
        {
            get
            {
                if (this.Request.QueryString["ChannleClientSettingID"] == null)
                    return 0;
                return Convert.ToInt32(this.Request.QueryString["ChannleClientSettingID"]);
            }
        }

        public int ReportChannleID
        {
            get
            {
                if (this.Request.QueryString["ChannleID"] == null)
                    return 0;
                return Convert.ToInt32(this.Request.QueryString["ChannleID"]);
            }
        }

        public int TimeIntercept
        {
            get
            {
                if (this.Request.QueryString["TimeIntercept"] == null)
                    return 0;
                return Convert.ToInt32(this.Request.QueryString["TimeIntercept"]);
            }
        }

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


        private void BindData()
        {
            DataTable tb = SPDayReportWrapper.GetDataChangeReport(StartDate, EndDate, ReportChannleID, ReportClientChannleID, TimeIntercept);

            ReportDataSource rds = new ReportDataSource("DataSet1", tb);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);

            string reportName = string.Format("【{0}】-【{1}】数据省份分部报表", StartDate.ToString("yyyy-MM-dd"), EndDate.ToString("yyyy-MM-dd"));

            if (ReportChannleID == 0)
            {
                reportName = "全平台" + reportName;
            }
            else
            {
                SPChannelWrapper channel = SPChannelWrapper.FindById(ReportChannleID);

                if (ReportClientChannleID == 0)
                {
                    reportName = string.Format("通道【{0}】", channel.Name) + reportName;
                }
                else
                {
                    SPClientChannelSettingWrapper clientChannelSetting = SPClientChannelSettingWrapper.FindById(ReportClientChannleID);

                    reportName = string.Format("通道【{0}】", channel.Name) + string.Format("指令【{0}】", clientChannelSetting.MoCode) + reportName;
                }
            }

            ReportParameter rpReportName = new ReportParameter();
            rpReportName.Name = "ReportName";
            rpReportName.Values.Add(reportName);


            ReportViewer1.LocalReport.SetParameters(
             new ReportParameter[] { rpReportName });


            ReportViewer1.LocalReport.Refresh();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
                return;
            FixReportDefinition(this.Server.MapPath("ReportDataChange1.rdl"));
            ReportViewer1.LocalReport.ReportPath = this.Server.MapPath("ReportDataChange1.rdl");
            BindData();
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

        protected void ReportViewer1_ReportRefresh(object sender, CancelEventArgs e)
        {
            BindData();
        }
    }
}