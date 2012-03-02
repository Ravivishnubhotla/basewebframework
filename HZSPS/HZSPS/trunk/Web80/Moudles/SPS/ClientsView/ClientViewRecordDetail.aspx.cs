using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Common.Web.AppClass;
using Parameter = Coolite.Ext.Web.Parameter;

namespace Legendigital.Common.Web.Moudles.SPS.ClientsView
{
    public partial class ClientViewRecordDetail : SPSClientViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            this.dfReportStartDate.DateField.Value = System.DateTime.Now.Date;

            this.dfReportEndDate.DateField.Value = System.DateTime.Now.Date;

            this.hidId.Text = this.SPClientID.ToString();

            this.storeSPChannel.BaseParams.Add(new Coolite.Ext.Web.Parameter("ClinetID", this.SPClientID.ToString()));

        }


        public int ChannelID
        {
            get
            {
                int channelID = 0;

                if (this.cmbChannelID.SelectedItem != null && !string.IsNullOrEmpty(this.cmbChannelID.SelectedItem.Value))
                {
                    channelID = int.Parse(this.cmbChannelID.SelectedItem.Value);
                }

                return channelID;
            }
        }

        protected void btnRefresh_Click(object sender, AjaxEventArgs e)
        {
            this.pnlDataView.AutoLoad.Url = "ClientViewRecordListPage.aspx";
            this.pnlDataView.AutoLoad.Params.Clear();
            this.pnlDataView.AutoLoad.Params.Add(new Parameter("ChannleID", ChannelID.ToString()));
            this.pnlDataView.AutoLoad.Params.Add(new Parameter("ClientID", SPClientID.ToString()));
            this.pnlDataView.AutoLoad.Params.Add(new Parameter("StartDate",this.dfReportStartDate.DateField.Value.ToString(), true));
            this.pnlDataView.AutoLoad.Params.Add(new Parameter("EndDate", this.dfReportEndDate.DateField.Value.ToString(), true));
            this.pnlDataView.LoadContent();
        }

    }



}
