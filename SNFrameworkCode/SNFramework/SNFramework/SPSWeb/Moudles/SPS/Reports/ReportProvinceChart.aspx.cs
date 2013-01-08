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

namespace SPSWeb.Moudles.SPS.Reports
{
    public partial class ReportProvinceChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
                return;

            ReportViewHelper.FixReportDefinition(this.Server.MapPath("ReportProvinceChart.rdl"));
            rptvContainer.LocalReport.ReportPath = this.Server.MapPath("ReportProvinceChart.rdl");
            BindData();
        }

        public int? ChannelID
        {
            get
            {
                if (this.Request.QueryString["ChannelID"] != null)
                {
                    return int.Parse(this.Request.QueryString["ChannelID"]);
                }
                return null;
            }
        }

        public int? CodeID
        {
            get
            {
                if (this.Request.QueryString["CodeID"] != null)
                {
                    return int.Parse(this.Request.QueryString["CodeID"]);
                }
                return null;
            }
        }


        public int? ClientID
        {
            get
            {
                if (this.Request.QueryString["ClientID"] != null)
                {
                    return int.Parse(this.Request.QueryString["ClientID"]);
                }
                return null;
            }
        }

        public string DataType
        {
            get
            {
                if (this.Request.QueryString["DataType"] != null)
                {
                    return this.Request.QueryString["DataType"];
                }
                return "";
            }
        }

        public DateTime? StartDate
        {
            get
            {
                if (this.Request.QueryString["StartDate"] != null)
                {
                    return Convert.ToDateTime(this.Request.QueryString["StartDate"]);
                }
                return null;
            }
        }

        public DateTime? EndDate
        {
            get
            {
                if (this.Request.QueryString["EndDate"] != null)
                {
                    return Convert.ToDateTime(this.Request.QueryString["EndDate"]);
                }
                return null;
            }
        }

        private void BindData()
        {
            DataTable tb = SPDayReportWrapper.QueryRecordProvine(StartDate, EndDate, DataType, ChannelID, CodeID, ClientID).Tables[0];

            ReportDataSource rds = new ReportDataSource("DataSet1", tb);
            rptvContainer.LocalReport.DataSources.Clear();
            rptvContainer.LocalReport.DataSources.Add(rds);

            string reportName = string.Format("【{0}】-【{1}】数据省份分布报表", StartDate.Value.ToString("yyyy-MM-dd"), EndDate.Value.ToString("yyyy-MM-dd"));

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