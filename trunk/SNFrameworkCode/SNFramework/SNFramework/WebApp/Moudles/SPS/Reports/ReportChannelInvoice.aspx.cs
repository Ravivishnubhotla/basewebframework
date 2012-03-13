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
    public partial class ReportChannelInvoice : System.Web.UI.Page
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

        protected void storeSPChannel_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.storeSPChannel.DataSource = SPChannelWrapper.FindAll();

            this.storeSPChannel.DataBind();
        }


        protected void btnQuery_Click(object sender, DirectEventArgs e)
        {
            this.ReportPanel.AutoLoad.Params.Clear();

            if (cmbChannel.SelectedItem != null && cmbChannel.SelectedItem.Value != null)
            {
                this.ReportPanel.AutoLoad.Params.Add(new Ext.Net.Parameter("ChannelID", cmbChannel.SelectedItem.Value.ToString()));
            }


            if (cmbCode.SelectedItem != null && cmbCode.SelectedItem.Value != null)
            {
                this.ReportPanel.AutoLoad.Params.Add(new Ext.Net.Parameter("CodeID", cmbCode.SelectedItem.Value.ToString()));
            }
 

            if (dfStart.SelectedValue!=null)
                this.ReportPanel.AutoLoad.Params.Add(new Ext.Net.Parameter("StartDate", dfStart.SelectedDate.ToString("yyyy-MM-dd hh:mm:ss")));
            if (dfEnd.SelectedValue != null)
                this.ReportPanel.AutoLoad.Params.Add(new Ext.Net.Parameter("EndDate", dfEnd.SelectedDate.ToString("yyyy-MM-dd hh:mm:ss")));
            this.ReportPanel.AutoLoad.Url = "ReportChannelInvoiceService.aspx";
            this.ReportPanel.LoadContent();
        }

        protected void storeSPCode_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            SPChannelWrapper channel = null;

            if (this.cmbChannel.SelectedItem != null)
            {
                channel = SPChannelWrapper.FindById(Convert.ToInt32(this.cmbChannel.SelectedItem.Value));
            }

            if (channel != null)
            {
                this.storeSPCode.DataSource = SPCodeWrapper.FindAllByChannelID(channel);
            }
            else
            {
                this.storeSPCode.DataSource = new List<SPCodeWrapper>();
            }

            this.storeSPCode.DataBind();
        }
    }
}