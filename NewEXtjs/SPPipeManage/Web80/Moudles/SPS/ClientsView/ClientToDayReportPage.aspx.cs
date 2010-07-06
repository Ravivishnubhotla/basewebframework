using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Common.Web.AppClass;
using Parameter = Coolite.Ext.Web.Parameter;

namespace Legendigital.Common.Web.Moudles.SPS.ClientsView
{
    public partial class ClientToDayReportPage : SPSClientViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Ext.IsAjaxRequest)
            {
                this.hidId.Text = this.ClientID.ToString();

                this.storeSPChannel.BaseParams.Add(new Coolite.Ext.Web.Parameter("ClinetID", this.ClientID.ToString()));


                int channelID = 0;

                if(this.cmbChannelID.SelectedItem!=null)
                {
                    channelID = int.Parse(this.cmbChannelID.SelectedItem.Value);
                }

                this.Store1.DataSource = this.GetDataTable(this.ClientID, channelID);
                this.Store1.DataBind();
            }
        }

        protected void Store1_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            int channelID = 0;

            if (this.cmbChannelID.SelectedItem != null)
            {
                channelID = int.Parse(this.cmbChannelID.SelectedItem.Value);
            }

            this.Store1.DataSource = this.GetDataTable(this.ClientID, channelID);
            this.Store1.DataBind();
        }


        private DataTable GetDataTable(int clientID,int channelID)
        {
            DataTable dt = SPDayReportWrapper.GetTodayReport(clientID, channelID);

            DataTable table = new DataTable();

            table.Columns.AddRange(new DataColumn[] {
            new DataColumn("CHour")   { ColumnName = "CHour",    DataType = typeof(string) },
            new DataColumn("Count")     { ColumnName = "Count",      DataType = typeof(int) }
            });


            int chour = System.DateTime.Now.Hour;

            for (int i = 0; i <= chour; i++)
            {
                int count = 0;

                DataRow[] drs = dt.Select(string.Format(" ChannelID = {0} and  ClientID =  {1} and  CHour = {2} ", channelID, clientID, chour));

                if (drs.Length>0)
                {
                    if(drs[0]["Total"]!=System.DBNull.Value)
                    {
                        count = Convert.ToInt32(drs[0]["Total"]);
                    }
                }

                table.Rows.Add(new object[] { i.ToString("D2") + ":00", count.ToString() });
            }

            return table;
        }
    }
}
