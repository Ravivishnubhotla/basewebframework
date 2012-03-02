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
    public partial class ClientGroupToDayReportPage : SPClientGroupViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            int id = this.ClientGroupID;

            storeSPClient.BaseParams.Add(new Parameter("ClientGroupID", id.ToString(), ParameterMode.Value));

            winRrovinceReport.AutoLoad.Params.Clear();

            winRrovinceReport.AutoLoad.Params.Add(new Parameter("ChannleID", "0", ParameterMode.Value));
            winRrovinceReport.AutoLoad.Params.Add(new Parameter("ClientID", "0", ParameterMode.Value));
            winRrovinceReport.AutoLoad.Params.Add(new Parameter("StartDate", System.DateTime.Now.ToShortDateString(), ParameterMode.Value));
            winRrovinceReport.AutoLoad.Params.Add(new Parameter("EndDate", System.DateTime.Now.ToShortDateString(), ParameterMode.Value));
            winRrovinceReport.AutoLoad.Params.Add(new Parameter("DataType", "downcountdetail", ParameterMode.Value));
            winRrovinceReport.AutoLoad.Params.Add(new Parameter("IsClientShow", "1", ParameterMode.Value));

            this.hidId.Text = id.ToString();
        }


        public int SPClientID
        {
            get
            {
                if (this.cmbClientID.SelectedItem == null)
                    return 0;
                if (this.cmbClientID.SelectedItem.Value == "")
                    return 0;
                return Convert.ToInt32(this.cmbClientID.SelectedItem.Value);
            }
        }

        public int SPClientGroupID
        {
            get
            {
                if (this.hidId.Text == "")
                {
                    this.hidId.Text = this.ClientGroupID.ToString();
                }
                return Convert.ToInt32(this.hidId.Text);
            }
        }


        protected void storeTodayReport_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            DataTable dt = this.GetDataTable(this.SPClientID, SPClientGroupID);

            this.txtTotalCount.Text = "共计：" + dt.Compute(" Sum(Count) ", " 1=1 ").ToString();

            this.storeTodayReport.DataSource = dt;
            this.storeTodayReport.DataBind();
        }

        private DataTable GetDataTable(int spClientId, int spClientGroupId)
        {
            DataTable dt = null;

            if (spClientId>0)
            {
                dt = SPDayReportWrapper.GetTodayReportByClientID(spClientId);
            }
            else
            {
                dt = SPDayReportWrapper.GetTodayReportByClientGroupID(spClientGroupId);              
            }
            

            DataTable table = new DataTable();

            table.Columns.AddRange(new DataColumn[] {
            new DataColumn("CHour")   { ColumnName = "CHour",    DataType = typeof(string) },
            new DataColumn("Count")     { ColumnName = "Count",      DataType = typeof(int) }
            });


            int chour = System.DateTime.Now.Hour;

            for (int i = 0; i <= chour; i++)
            {
                DataRow[] drs;

                drs = dt.Select(string.Format(" CHour = {0} ",i));
 

                int count = 0;

                if (drs.Length > 0)
                {
                    foreach (DataRow dataRow in drs)
                    {
                        count += Convert.ToInt32(dataRow["Total"]);                  
                    } 

                }

                table.Rows.Add(new object[] { i.ToString("D2") + ":00", count.ToString() });
            }

            return table;
        }

        protected void storeSPClient_OnRefresh(object sender, StoreRefreshDataEventArgs e)
        {
            SPClientGroupWrapper clientGroup = SPClientGroupWrapper.FindById(this.ClientGroupID);

            storeSPClient.DataSource = SPClientWrapper.FindAllBySPClientGroupID(clientGroup);
            storeSPClient.DataBind();
        }
    }
}