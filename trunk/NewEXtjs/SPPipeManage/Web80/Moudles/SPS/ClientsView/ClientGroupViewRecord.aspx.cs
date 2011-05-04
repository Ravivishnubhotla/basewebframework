using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Common.Web.AppClass;
using Newtonsoft.Json;

namespace Legendigital.Common.Web.Moudles.SPS.ClientsView
{
    public partial class ClientGroupViewRecord : SPClientGroupViewPage
    {
 


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            int id = this.ClientGroupID;

            this.dfReportEndDate.DateField.Value = System.DateTime.Now.Date;

            this.dfReportStartDate.DateField.Value = System.DateTime.Now.Date;

            SPClientGroupWrapper spClientGroupWrapper = SPClientGroupWrapper.FindById(this.ClientGroupID);

            this.dfReportStartDate.DateField.MinDate = spClientGroupWrapper.GetDT();

            storeSPClient.BaseParams.Add(new Parameter("ClientGroupID", id.ToString(), ParameterMode.Value));

            this.hidId.Text = id.ToString();
        }

        protected void storeSPClient_OnRefresh(object sender, StoreRefreshDataEventArgs e)
        {
            SPClientGroupWrapper clientGroup = SPClientGroupWrapper.FindById(this.ClientGroupID);

            storeSPClient.DataSource = SPClientWrapper.FindAllBySPClientGroupID(clientGroup);
            storeSPClient.DataBind();
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
                if (this.hidId.Text=="")
                {
                    this.hidId.Text = this.ClientGroupID.ToString();
                }
                return Convert.ToInt32(this.hidId.Text);
            }
        }


        private Column NewColumn(string id, string header, string dataIndex, string renderHandler)
        {
            Column col1 = new Column();
            col1.ColumnID = id;
            col1.Header = header;
            col1.Sortable = false;
            col1.DataIndex = dataIndex;
            if (!string.IsNullOrEmpty(renderHandler))
            {
                if (col1.Renderer == null)
                    col1.Renderer = new Renderer();
                col1.Renderer.Handler = renderHandler;
            }
            return col1;
        }

        public int ChannelID
        {
            get
            {
                int channelID = 0;

                return channelID;
            }
        }


        protected void store1_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            int recordCount = 0;
            string sortFieldName = "";
            if (e.Sort != null)
                sortFieldName = e.Sort;

            int startIndex = 0;

            if (e.Start > -1)
            {
                startIndex = e.Start;
            }

            int limit = this.PagingToolBar1.PageSize;

            int pageIndex = 1;

            if ((startIndex % limit) == 0)
                pageIndex = startIndex / limit + 1;
            else
                pageIndex = startIndex / limit;


            List<SPPaymentInfoWrapper> list = null;

            DateTime startDate = Convert.ToDateTime(this.dfReportStartDate.DateField.Value);

            SPClientGroupWrapper spClientGroupWrapper = SPClientGroupWrapper.FindById(this.ClientGroupID);

            if (startDate < spClientGroupWrapper.GetDT())
            {
                startDate = spClientGroupWrapper.GetDT();
            }

            string province = "";

            if (this.cmbProvince.SelectedItem != null)
            {
                province = this.cmbProvince.SelectedItem.Value;
            }

            string city = "";

            if (!string.IsNullOrEmpty(this.txtCity.Text.Trim()))
            {
                city = this.txtCity.Text.Trim();
            }

            string phone = "";

            if(!string.IsNullOrEmpty(this.txtMoblie.Text.Trim()))
            {
                phone = this.txtMoblie.Text.Trim();
            }

            if (SPClientID > 0)
            {
                list = SPPaymentInfoWrapper.FindAllByOrderByAndCleintIDAndChanneLIDAndDateAndProviceNoIntercept(ChannelID, SPClientID, startDate, Convert.ToDateTime(this.dfReportEndDate.DateField.Value), province, city, phone, sortFieldName, (e.Dir == Coolite.Ext.Web.SortDirection.DESC), pageIndex, limit, out recordCount);
            }
            else
            {
                list = SPPaymentInfoWrapper.FindAllByOrderByAndSPClientGroupIDAndDateAndProviceNoIntercept(SPClientGroupID, startDate, Convert.ToDateTime(this.dfReportEndDate.DateField.Value), province, city, phone, sortFieldName, (e.Dir == Coolite.Ext.Web.SortDirection.DESC), pageIndex, limit, out recordCount);
            }
                   
            store1.DataSource = list;
            e.TotalCount = recordCount;

            store1.DataBind();


        }
    }
}