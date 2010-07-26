using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Common.Web.AppClass;
using Newtonsoft.Json;

namespace Legendigital.Common.Web.Moudles.SPS.ClientsView
{
    public partial class ClientViewRecord : SPSClientViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;
            
            this.dfReportStartDate.DateField.Value = System.DateTime.Now.Date;

            this.dfReportEndDate.DateField.Value = System.DateTime.Now.Date;

            this.hidId.Text = this.ClientID.ToString();

            this.storeSPChannel.BaseParams.Add(new Coolite.Ext.Web.Parameter("ClinetID", this.ClientID.ToString()));


            //if (ChannelID > 0)
            //{
            //    SPChannelWrapper channel = SPChannelWrapper.FindById(ChannelID);

            //    if (channel != null)
            //    {
            //        Hashtable channelParams = channel.GetFieldMappings();

            //        foreach (DictionaryEntry dictionaryEntry in channelParams)
            //        {
            //            string pName = dictionaryEntry.Value.ToString();

            //            this.gridPanelSPClientChannelSetting.ColumnModel.Columns.Add(NewColumn("col" + pName, pName.ToLower(), "Values", string.Format("var cparams = Ext.decode(record.data.Values); return cparams.{0};", pName.ToLower())));
            //        }
            //    }
            //}

            this.gridPanelSPClientChannelSetting.Reload();
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

            //if (ChannelID > 0)
            //{
            //    SPChannelWrapper channel = SPChannelWrapper.FindById(ChannelID);

            //    if (channel != null)
            //    {
            //        Hashtable channelParams = channel.GetFieldMappings();

            //        foreach (DictionaryEntry dictionaryEntry in channelParams)
            //        {
            //            string pName = dictionaryEntry.Value.ToString();

            //            this.gridPanelSPClientChannelSetting.ColumnModel.Columns.Add(NewColumn("col" + pName, pName.ToLower(), "Values", string.Format("var cparams = Ext.decode(record.data.Values); return cparams.{0};", pName.ToLower())));
            //        }
            //    }
            //}


            List<SPPaymentInfoWrapper> list = SPPaymentInfoWrapper.FindAllByOrderByAndCleintIDAndChanneLIDAndDateNoIntercept(ChannelID, this.ClientID, Convert.ToDateTime(this.dfReportStartDate.DateField.Value), Convert.ToDateTime(this.dfReportEndDate.DateField.Value), sortFieldName, (e.Dir == Coolite.Ext.Web.SortDirection.DESC), pageIndex, limit, out recordCount);

            if (list.Count > 0)
            {
                foreach (SPPaymentInfoWrapper spPaymentInfoWrapper in list)
                {
                    spPaymentInfoWrapper.Values = JsonConvert.SerializeObject(
                        spPaymentInfoWrapper.GetValues(
                            JsonConvert.DeserializeObject<Hashtable>(spPaymentInfoWrapper.RequestContent)));
                }
            }

            store1.DataSource = list;
            e.TotalCount = recordCount;

            store1.DataBind();
           

        }
    }
}
