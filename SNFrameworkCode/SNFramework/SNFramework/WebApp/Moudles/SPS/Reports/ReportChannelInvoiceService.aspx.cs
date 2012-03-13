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
    public partial class ReportChannelInvoiceService : System.Web.UI.Page
    {

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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
                return;

            ReportViewHelper.FixReportDefinition(this.Server.MapPath("RecordExportTemplateForChannel.rdl"));
            rptvContainer.LocalReport.ReportPath = this.Server.MapPath("RecordExportTemplateForChannel.rdl");
            BindData();
        }

        private void BindData()
        {
            DataTable tb = SPDayReportWrapper.QueryChannelInvoiceReport(StartDate, EndDate, ChannelID, CodeID).Tables[0];

            string reportName = string.Format("【{0}】-【{1}】通道结算报表", StartDate.Value.ToString("yyyy-MM-dd"),
                                  EndDate.Value.ToString("yyyy-MM-dd"));

            ReportViewHelper.BindDataTableToReport(rptvContainer, tb, "DataSet1", reportName);
        }



        protected void rptvContainer_ReportRefresh(object sender, CancelEventArgs e)
        {
            BindData();
        }
    }
}