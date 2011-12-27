using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Reports
{
    public partial class ReportDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            //SPSClientWrapper spClientWrapper = SPSClientWrapper.FindById(this.SPClientID);

            //SPClientChannelSettingWrapper clientChannelSettingWrapper = spClientWrapper.DefaultClientChannelSetting;

            //bool isSycnData = (clientChannelSettingWrapper != null && clientChannelSettingWrapper.SyncData.HasValue &&
            //                   clientChannelSettingWrapper.SyncData.Value);

            //storeData.Reader.Add(GetJsonReaderByDataTable(SPChannelWrapper.FindById(this.ChannleID), isSycnData));

            //this.GridPanel1.StoreID = "storeData";

            //this.PagingToolBar1.StoreID = "storeData";
        }


        public SPChannelWrapper ChannelID
        {
            get
            {
                if (this.Request.QueryString["ChannelID"] != null)
                {
                    return
                        SPChannelWrapper.FindById(int.Parse(this.Request.QueryString["ChannelID"]));
                }
                return null;
            }
        }

        public SPCodeWrapper CodeID
        {
            get
            {
                if (this.Request.QueryString["CodeID"] != null)
                {
                    return
                        SPCodeWrapper.FindById(int.Parse(this.Request.QueryString["CodeID"]));
                }
                return null;
            }
        }


        public SPSClientWrapper ClientID
        {
            get
            {
                if (this.Request.QueryString["ClientID"] != null)
                {
                    return
                        SPSClientWrapper.FindById(int.Parse(this.Request.QueryString["ClientID"]));
                }
                return null;
            }
        }

        public string DataType
        {
            get
            {
                if (this.Request.QueryString["DataType"] != null)
                {
                    return this.Request.QueryString["DataType"];
                }
                return "";
            }
        }

        public DateTime? StartDate
        {
            get
            {
                if (this.Request.QueryString["StartDate"] != null)
                {
                    return Convert.ToDateTime(this.Request.QueryString["StartDate"]);
                }
                return null;
            }
        }

        public DateTime? EndDate
        {
            get
            {
                if (this.Request.QueryString["EndDate"] != null)
                {
                    return Convert.ToDateTime(this.Request.QueryString["EndDate"]);
                }
                return null;
            }
        }

        protected void storeData_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
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


            PageQueryParams pageQueryParams = new PageQueryParams();
            pageQueryParams.PageSize = limit;
            pageQueryParams.PageIndex = pageIndex;

            storeData.DataSource = SPRecordWrapper.QueryRecordByPage(this.ChannelID, this.CodeID, this.ClientID, this.DataType, this.StartDate.Value, this.EndDate.Value,new List<QueryFilter>(), sortFieldName, (e.Dir == Ext.Net.SortDirection.DESC), pageQueryParams);
            storeData.DataBind();

        }

        protected void storeData_Submit(object sender, StoreSubmitDataEventArgs e)
        {
            

        }
    }
}