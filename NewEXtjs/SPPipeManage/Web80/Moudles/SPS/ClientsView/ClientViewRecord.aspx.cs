using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Common.Web.AppClass;

namespace Legendigital.Common.Web.Moudles.SPS.ClientsView
{
    public partial class ClientViewRecord : SPSClientViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            this.dfReportStartDate.DateField.SetValue(System.DateTime.Now);

            this.dfReportEndDate.DateField.SetValue(System.DateTime.Now);

            this.hidId.Text = this.ClientID.ToString();

            this.storeSPChannel.BaseParams.Add(new Coolite.Ext.Web.Parameter("ClinetID", this.ClientID.ToString()));

            this.gridPanelSPClientChannelSetting.Reload();
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


            int channelID = 0;

            if (this.cmbChannelID.SelectedItem != null && !string.IsNullOrEmpty(this.cmbChannelID.SelectedItem.Value))
            {
                channelID = int.Parse(this.cmbChannelID.SelectedItem.Value);
            }

            storeSPChannel.DataSource = SPPaymentInfoWrapper.FindAllByOrderByAndCleintIDAndChanneLIDAndDate(channelID, this.ClientID, Convert.ToDateTime(this.dfReportStartDate.DateField.Value), Convert.ToDateTime(this.dfReportEndDate.DateField.Value), sortFieldName, (e.Dir == Coolite.Ext.Web.SortDirection.DESC), pageIndex, limit, out recordCount);
            e.TotalCount = recordCount;

            storeSPChannel.DataBind();
           

        }
    }
}
