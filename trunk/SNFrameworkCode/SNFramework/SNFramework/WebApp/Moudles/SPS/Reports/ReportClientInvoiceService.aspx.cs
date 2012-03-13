using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Legendigital.Framework.Common.Web.UI;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Reports
{
    public partial class ReportClientInvoiceService : System.Web.UI.Page
    {
 

        public int? CodeID
        {
            get
            {
                if (this.Request.QueryString["CodeID"] != null)
                {
                    return
                         int.Parse(this.Request.QueryString["CodeID"]);
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
                    return
                         int.Parse(this.Request.QueryString["ClientID"]);
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
            DataTable tb = SPDayReportWrapper.QueryClientInvoiceReport(StartDate, EndDate, ClientID, CodeID).Tables[0];

            string reportName = string.Format("【{0}】-【{1}】客户结算报表", StartDate.Value.ToString("yyyy-MM-dd"),
                                  EndDate.Value.ToString("yyyy-MM-dd"));

            ReportViewHelper.BindDataTableToReport(rptvContainer, tb, "DataSet1", reportName);
        }



        protected void rptvContainer_ReportRefresh(object sender, CancelEventArgs e)
        {
            BindData();
        }
    }
}