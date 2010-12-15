using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.Clients
{
    public partial class SPClientGroupReport : System.Web.UI.Page
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

            this.gridPanelSPClientChannelSetting.Reload();
        }

 

        protected void store1_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            DataTable tb = SPDayReportWrapper.GetClientGroupPriceReport(ClientGroupID,Convert.ToDateTime( dfReportStartDate.DateField.Value).Date, Convert.ToDateTime(this.dfReportEndDate.DateField.Value).Date);

            store1.DataSource = tb;
            store1.DataBind();
        }
    }
}