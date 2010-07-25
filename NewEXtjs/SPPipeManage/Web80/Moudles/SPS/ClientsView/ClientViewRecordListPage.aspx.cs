using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    public partial class ClientViewRecordListPage : SPSClientViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;


            string title = "";

            if(this.ChannleID>0)
            {
                SPChannelWrapper channelWrapper = SPChannelWrapper.FindById(this.ChannleID);

                if (channelWrapper != null)
                {
                    title += " 通道 " + channelWrapper.Name;
                }
            }
            else
            {
                title += " 全部通道 ";                
            }

            if (this.QClientID > 0)
            {
                SPClientWrapper clientWrapper = SPClientWrapper.FindById(this.QClientID);

                if (clientWrapper != null)
                {
                    title += " 下家 " + clientWrapper.Name;
                }
            }
            else
            {
                title += " 全部下家 ";
            }


            if (this.StartDate != DateTime.MinValue)
            {
                title += " 从 " + this.StartDate.ToShortDateString();
            }


            if (this.EndDate != DateTime.MinValue)
            {
                title += " 至 " + this.EndDate.ToShortDateString();
            }
            else        
            {
                title += " 至今 ";               
            }


            if (ChannleID > 0)
            {
                SPChannelWrapper channel = SPChannelWrapper.FindById(ChannleID);

                if (channel != null)
                {
                    Hashtable channelParams = channel.GetFieldMappings();

                    foreach (DictionaryEntry dictionaryEntry in channelParams)
                    {
                        string pName = dictionaryEntry.Value.ToString();

                        this.gridPanelSPClientChannelSetting.ColumnModel.Columns.Add(NewColumn("col" + pName, pName.ToLower(), "Values", string.Format("var cparams = Ext.decode(record.data.Values); return cparams.{0};", pName.ToLower())));
                    }
                }
            }

            this.gridPanelSPClientChannelSetting.Title =title;

            this.gridPanelSPClientChannelSetting.Reload();
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

        public int ChannleID
        {
            get
            {
                if(!string.IsNullOrEmpty(this.Request.QueryString["ChannleID"]))
                {
                    return Convert.ToInt32(this.Request.QueryString["ChannleID"]);
                }
                return 0;
            }
        }

        public int QClientID
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString["ClientID"]))
                {
                    return Convert.ToInt32(this.Request.QueryString["ClientID"]);
                }
                return 0;
            }
        }


        public DateTime StartDate
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString["StartDate"]))
                {
                    return Convert.ToDateTime(this.Request.QueryString["StartDate"].Replace("\"", ""));
                }
                return DateTime.MinValue;
            }
        }


        public DateTime EndDate
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString["EndDate"]))
                {
                    return Convert.ToDateTime(this.Request.QueryString["EndDate"].Replace("\"",""));
                }
                return DateTime.MinValue;
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

            DataTable dt = SPPaymentInfoWrapper.FindAllDataTableByOrderByAndCleintIDAndChanneLIDAndDateNoIntercept(ChannleID, this.ClientID, Convert.ToDateTime(this.StartDate), Convert.ToDateTime(this.EndDate), sortFieldName, (e.Dir == Coolite.Ext.Web.SortDirection.DESC), pageIndex, limit, out recordCount);

            if (ChannleID > 0)
            {


            }

            


            //List<SPPaymentInfoWrapper> list = SPPaymentInfoWrapper.FindAllByOrderByAndCleintIDAndChanneLIDAndDateNoIntercept(ChannleID, this.ClientID, Convert.ToDateTime(this.StartDate), Convert.ToDateTime(this.EndDate), sortFieldName, (e.Dir == Coolite.Ext.Web.SortDirection.DESC), pageIndex, limit, out recordCount);

            //if (list.Count > 0)
            //{
            //    foreach (SPPaymentInfoWrapper spPaymentInfoWrapper in list)
            //    {
            //        spPaymentInfoWrapper.Values = JsonConvert.SerializeObject(
            //            spPaymentInfoWrapper.GetValues(
            //                JsonConvert.DeserializeObject<Hashtable>(spPaymentInfoWrapper.RequestContent)));
            //    }
            //}

            store1.DataSource = dt;
            e.TotalCount = recordCount;

            store1.DataBind();


        }
    }
}
