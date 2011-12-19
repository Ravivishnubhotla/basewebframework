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

namespace Legendigital.Common.Web.Moudles.SPS.Clients
{
    public partial class SPClientGroupReportService1 : System.Web.UI.Page
    {
        public int ClientGroupID
        {
            get
            {
                if (this.Request.QueryString["ClientGroupID"] == null)
                    return 0;
                return Convert.ToInt32(this.Request.QueryString["ClientGroupID"]);
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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
                return;
            FixReportDefinition(this.Server.MapPath("SPClientGroupAmountReport1.rdl"));
            ReportViewer1.LocalReport.ReportPath = this.Server.MapPath("SPClientGroupAmountReport1.rdl");
            BindData();
        }

        private void BindData()
        {
            DataTable tb = SPDayReportWrapper.GetAllDayDownReport(StartDate.Date, EndDate.Date);

            DataTable rtp = tb.Clone();

            foreach (DataRow row in tb.Rows)
            {
                if(row["ClientGroupID"]!=System.DBNull.Value)
                {
                    int clientGroupID = (int) row["ClientGroupID"];

                    if(clientGroupID==ClientGroupID)
                    {
                        rtp.ImportRow(row);
                    }
                }
            }
            rtp.AcceptChanges();

            rtp.Columns.Add("CodeName");
            rtp.Columns.Add("Price",typeof(decimal));
            rtp.Columns.Add("Amount", typeof(decimal));

            rtp.AcceptChanges();

            foreach (DataRow row in rtp.Rows)
            {
                int channleClientID = (int)row["ChannleClientID"];
                int recordCount = (int)row["RecordCount"];

                SPClientChannelSettingWrapper clientChannelSetting =
                    SPClientChannelSettingWrapper.FindById(channleClientID);

                row.BeginEdit();
                row["CodeName"] = clientChannelSetting.ClinetID.Alias;
                row["Price"] = clientChannelSetting.ClinetID.Price;
                row["Amount"] = clientChannelSetting.ClinetID.Price * recordCount;
                row.EndEdit();


            }

            rtp.AcceptChanges();

            SPClientGroupWrapper clientGroup = SPClientGroupWrapper.FindById(ClientGroupID);

            string reportName = string.Format("下家组【{2}】 【{0}】-【{1}】结算报表", StartDate.ToString("yyyy-MM-dd"), EndDate.ToString("yyyy-MM-dd"), clientGroup.Name);


            ReportDataSource rds = new ReportDataSource("DataSet1", rtp);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);

            SPClientGroupWrapper clientGroupWrapper = SPClientGroupWrapper.FindById(ClientGroupID);


            ReportParameter rpName = new ReportParameter();
            rpName.Name = "ReportName";
            rpName.Values.Add(reportName);

 


            ReportViewer1.LocalReport.SetParameters(
             new ReportParameter[] { rpName });



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