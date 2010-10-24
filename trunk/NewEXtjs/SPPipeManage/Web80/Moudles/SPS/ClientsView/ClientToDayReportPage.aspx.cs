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
                this.hidId.Text = this.SPClientID.ToString();

                int channelID = 0;

                SPClientChannelSettingWrapper channelSettingWrapper = SPClientWrapper.FindById(this.SPClientID).DefaultClientChannelSetting; 

                DataTable dt = this.GetDataTable(this.SPClientID, channelID, "");



                winRrovinceReport.AutoLoad.Params.Clear();

                winRrovinceReport.AutoLoad.Params.Add(new Parameter("ChannleID", channelSettingWrapper.ChannelID.Id.ToString(), ParameterMode.Value));
                winRrovinceReport.AutoLoad.Params.Add(new Parameter("ClientID", channelSettingWrapper.ClinetID.Id.ToString(), ParameterMode.Value));
                winRrovinceReport.AutoLoad.Params.Add(new Parameter("StartDate", System.DateTime.Now.ToShortDateString(), ParameterMode.Value));
                winRrovinceReport.AutoLoad.Params.Add(new Parameter("EndDate", System.DateTime.Now.ToShortDateString(), ParameterMode.Value));
                winRrovinceReport.AutoLoad.Params.Add(new Parameter("DataType", "downcountdetail", ParameterMode.Value));
                winRrovinceReport.AutoLoad.Params.Add(new Parameter("IsClientShow", "1", ParameterMode.Value));


                
                //                <ext:Parameter Name="ChannleID" Mode="Raw" Value="0">
                //</ext:Parameter>
                //<ext:Parameter Name="ClientID" Mode="Raw" Value="0">
                //</ext:Parameter>
                //<ext:Parameter Name="StartDate" Mode="Raw" Value="2009-1-1">
                //</ext:Parameter>
                //<ext:Parameter Name="EndDate" Mode="Raw" Value="2009-1-1">
                //</ext:Parameter>
                //<ext:Parameter Name="DataType" Mode="Raw" Value="0">
                //</ext:Parameter>

                //winRrovinceReport.AutoLoad.Params["ChannleID"] = channelSettingWrapper.ChannelID.Id.ToString();
                //winRrovinceReport.AutoLoad.Params["ClientID"] = channelSettingWrapper.ClinetID.Id.ToString();
                //winRrovinceReport.AutoLoad.Params["StartDate"] = System.DateTime.Now.ToShortDateString();
                //winRrovinceReport.AutoLoad.Params["EndDate"] = System.DateTime.Now.ToShortDateString();
                //winRrovinceReport.AutoLoad.Params["DataType"] = "downcountdetail";

                

                this.txtTotalCount.Text = "共计：" + dt.Compute(" Sum(Count) ", " 1=1 ").ToString();

                this.Store1.DataSource = dt;
                this.Store1.DataBind();
            }
        }

        protected void Store1_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            int channelID = 0;

            string province = "";

            if(cmbProvince.SelectedItem !=null)
            {
                province = (cmbProvince.SelectedItem).ToString();
            }

            DataTable dt = this.GetDataTable(this.SPClientID, channelID, province);

            this.txtTotalCount.Text = "共计：" + dt.Compute(" Sum(Count) ", " 1=1 ").ToString();

            this.Store1.DataSource = dt;
            this.Store1.DataBind();
        }


        private DataTable GetDataTable(int clientID,int channelID,string province)
        {
            DataTable dt = SPDayReportWrapper.GetTodayReportByProvince(clientID, channelID, province);

            DataTable table = new DataTable();

            table.Columns.AddRange(new DataColumn[] {
            new DataColumn("CHour")   { ColumnName = "CHour",    DataType = typeof(string) },
            new DataColumn("Count")     { ColumnName = "Count",      DataType = typeof(int) }
            });

            int chour = System.DateTime.Now.Hour;

            for (int i = 0; i <= chour; i++)
            {
                DataRow[] drs;

                if (channelID!=0)
                {
                    drs = dt.Select(string.Format(" ChannelID = {0} and  ClientID =  {1} and  CHour = {2} ", channelID, clientID, i));
                }
                else
                {
                    drs = dt.Select(string.Format(" ClientID =  {1} and  CHour = {2} ", channelID, clientID, i));               
                }

                int count = 0;

                if (drs.Length>0)
                {
                    if (drs[0]["Total"] != System.DBNull.Value)
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
