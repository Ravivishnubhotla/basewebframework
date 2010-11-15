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
        protected DateTime GetDT()
        {
            switch (System.DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return System.DateTime.Now.AddDays(-7);
                case DayOfWeek.Tuesday:
                    return System.DateTime.Now.AddDays(-8);
                case DayOfWeek.Wednesday:
                    return System.DateTime.Now.AddDays(-9);
                case DayOfWeek.Thursday:
                    return System.DateTime.Now.AddDays(-10);
                case DayOfWeek.Friday:
                    return System.DateTime.Now.AddDays(-11);
                case DayOfWeek.Saturday:
                    return System.DateTime.Now.AddDays(-12);
                case DayOfWeek.Sunday:
                    return System.DateTime.Now.AddDays(-13);

            }

            return DateTime.Now;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            this.dfReportStartDate.DateField.Value = System.DateTime.Now.AddDays(-10).Date;

            this.dfReportStartDate.DateField.MaxDate = System.DateTime.Now.AddDays(-1).Date;

            this.dfReportStartDate.DateField.MinDate = GetDT();

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

            DateTime startDate = Convert.ToDateTime(this.dfReportStartDate.DateField.Value);

            if (startDate < GetDT())
            {
                startDate = GetDT();
            }


            if(SPClientID>0)
            {
                tb = SPDayReportWrapper.GetCountReportByClientID(this.SPClientID, startDate, Convert.ToDateTime(this.dfReportEndDate.DateField.Value));
            }
            else
            {
                tb = SPDayReportWrapper.GetCountReportByClientGroupID(this.SPClientGroupID, startDate, Convert.ToDateTime(this.dfReportEndDate.DateField.Value));             
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