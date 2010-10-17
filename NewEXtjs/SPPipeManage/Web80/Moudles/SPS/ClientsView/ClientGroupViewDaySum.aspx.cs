using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Common.Web.AppClass;

namespace Legendigital.Common.Web.Moudles.SPS.ClientsView
{
    public partial class ClientGroupViewDaySum : SPClientGroupViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            this.dfReportStartDate.DateField.Value = System.DateTime.Now.AddDays(-10).Date;

            this.dfReportStartDate.DateField.MaxDate = System.DateTime.Now.AddDays(-1).Date;

            this.dfReportEndDate.DateField.Value = System.DateTime.Now.AddDays(-1).Date;

            this.dfReportEndDate.DateField.MaxDate = System.DateTime.Now.AddDays(-1).Date;

            int id = this.ClientGroupID;

            storeSPClient.BaseParams.Add(new Parameter("ClientGroupID", id.ToString(), ParameterMode.Value));

            this.hidId.Text = id.ToString();

            //this.gridPanelSPClientChannelSetting.Reload();
        }


        protected void store1_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            DataTable tb = null;

            if(SPClientID>0)
            {
                tb = SPDayReportWrapper.GetCountReportByClientID(this.SPClientID, Convert.ToDateTime(this.dfReportStartDate.DateField.Value), Convert.ToDateTime(this.dfReportEndDate.DateField.Value));
            }
            else
            {
                tb = SPDayReportWrapper.GetCountReportByClientGroupID(this.SPClientGroupID, Convert.ToDateTime(this.dfReportStartDate.DateField.Value), Convert.ToDateTime(this.dfReportEndDate.DateField.Value));             
            }

              

            store1.DataSource = tb;
            store1.DataBind();


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

        protected void storeSPClient_OnRefresh(object sender, StoreRefreshDataEventArgs e)
        {
            SPClientGroupWrapper clientGroup = SPClientGroupWrapper.FindById(this.ClientGroupID);

            storeSPClient.DataSource = SPClientWrapper.FindAllBySPClientGroupID(clientGroup);
            storeSPClient.DataBind();
        }
    }



}