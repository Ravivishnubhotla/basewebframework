using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;

namespace Legendigital.Common.Web.Moudles.SPS.Clients
{
    public partial class SPClientGroupReportContainer1 : System.Web.UI.Page
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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            dfReportEndDate.DateField.MaxDate = System.DateTime.Now.AddDays(-1);

            dfReportEndDate.DateField.Value = System.DateTime.Now.AddDays(-1);

            dfReportStartDate.DateField.MaxDate = System.DateTime.Now.AddDays(-1);

            dfReportStartDate.DateField.Value = System.DateTime.Now.AddDays(-8);
        }


        protected void btnRefresh_Click(object sender, AjaxEventArgs e)
        {
            this.ReportPanel.AutoLoad.Params.Clear();
            this.ReportPanel.AutoLoad.Params.Add(new Coolite.Ext.Web.Parameter("ClientGroupID", ClientGroupID.ToString()));
            this.ReportPanel.AutoLoad.Params.Add(new Coolite.Ext.Web.Parameter("StartDate", dfReportStartDate.DateField.SelectedDate.ToShortDateString()));
            this.ReportPanel.AutoLoad.Params.Add(new Coolite.Ext.Web.Parameter("EndDate", dfReportEndDate.DateField.SelectedDate.ToShortDateString()));
            this.ReportPanel.AutoLoad.Url = "SPClientGroupReportService1.aspx";
            this.ReportPanel.LoadContent();
        }
    }
}