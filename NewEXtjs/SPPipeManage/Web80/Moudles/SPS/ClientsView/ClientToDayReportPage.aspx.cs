using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Common.Web.AppClass;

namespace Legendigital.Common.Web.Moudles.SPS.ClientsView
{
    public partial class ClientToDayReportPage : SPSClientViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Ext.IsAjaxRequest)
            {
                this.hidId.Text = this.ClientID.ToString();
                this.Store1.DataSource = this.GetDataTable();
                this.Store1.DataBind();
            }
        }

        protected void Store1_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            this.Store1.DataSource = this.GetDataTable();
            this.Store1.DataBind();
        }


        private DataTable GetDataTable()
        {
            int clientID = this.ClientID;
            
            DataTable table = new DataTable();



            table.Columns.AddRange(new DataColumn[] {
            new DataColumn("CHour")   { ColumnName = "CHour",    DataType = typeof(string) },
            new DataColumn("Count")     { ColumnName = "Count",      DataType = typeof(int) }
            });


            int chour = System.DateTime.Now.Hour;

            for (int i = 0; i <= chour; i++)
            {
                table.Rows.Add(new object[] { i.ToString("D2") + ":00", 1 + clientID });
                ;
            }

            return table;
        }
    }
}
