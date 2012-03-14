using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Reports
{
    public partial class ReportClientInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            dfStart.SelectedDate = System.DateTime.Now.AddDays(-3);
            dfStart.MaxDate = System.DateTime.Now.AddDays(-1);
            dfEnd.SelectedDate = System.DateTime.Now.AddDays(-1);
            dfEnd.MaxDate = System.DateTime.Now.AddDays(-1);
        }

        protected void storeSPClient_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.storeSPClient.DataSource = SPSClientWrapper.FindAll();

            this.storeSPClient.DataBind();
        }


        protected void btnQuery_Click(object sender, DirectEventArgs e)
        {
            this.ReportPanel.AutoLoad.Params.Clear();

            if (cmbClient.SelectedItem != null && cmbClient.SelectedItem.Value != null)
            {
                this.ReportPanel.AutoLoad.Params.Add(new Ext.Net.Parameter("ClientID", cmbClient.SelectedItem.Value.ToString()));
            }


            if (cmbCode.SelectedItem != null && cmbCode.SelectedItem.Value != null)
            {
                this.ReportPanel.AutoLoad.Params.Add(new Ext.Net.Parameter("CodeID", cmbCode.SelectedItem.Value.ToString()));
            }


            if (dfStart.SelectedValue != null)
                this.ReportPanel.AutoLoad.Params.Add(new Ext.Net.Parameter("StartDate", dfStart.SelectedDate.ToString("yyyy-MM-dd hh:mm:ss")));
            if (dfEnd.SelectedValue != null)
                this.ReportPanel.AutoLoad.Params.Add(new Ext.Net.Parameter("EndDate", dfEnd.SelectedDate.ToString("yyyy-MM-dd hh:mm:ss")));
            this.ReportPanel.AutoLoad.Url = "ReportClientInvoiceService.aspx";
            this.ReportPanel.LoadContent();
        }

        protected void storeSPCode_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            SPSClientWrapper client = null;

            if (this.cmbClient.SelectedItem != null)
            {
                client = SPSClientWrapper.FindById(Convert.ToInt32(this.cmbClient.SelectedItem.Value));
            }

            if (client != null)
            {
                this.storeSPCode.DataSource = client.GetAllAssignedCode();
            }
            else
            {
                this.storeSPCode.DataSource = new List<SPCodeWrapper>();
            }

            this.storeSPCode.DataBind();

        }
    }
}