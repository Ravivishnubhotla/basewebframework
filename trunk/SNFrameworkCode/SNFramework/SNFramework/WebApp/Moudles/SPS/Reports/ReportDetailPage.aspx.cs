using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
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

 

            GridPanel1.Reload();

            //SPSClientWrapper spClientWrapper = SPSClientWrapper.FindById(this.SPClientID);

            //SPClientChannelSettingWrapper clientChannelSettingWrapper = spClientWrapper.DefaultClientChannelSetting;

            //bool isSycnData = (clientChannelSettingWrapper != null && clientChannelSettingWrapper.SyncData.HasValue &&
            //                   clientChannelSettingWrapper.SyncData.Value);

            //storeData.Reader.Add(GetJsonReaderByDataTable(SPChannelWrapper.FindById(this.ChannleID), isSycnData));

            //this.GridPanel1.StoreID = "storeData";

            //this.PagingToolBar1.StoreID = "storeData";
        }


        public bool ShowForClient
        {

            get
            {
                if (this.Request.QueryString["ShowMode"] != null)
                {
                    return
                        this.Request.QueryString["ShowMode"].Equals("Client");
                }
                return false;
            }
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
            PageQueryParams pageQueryParams = WebUIHelper.GetPageQueryParamFromStoreRefreshDataEventArgs(e, this.PagingToolBar1);
            RecordSortor recordSortor = WebUIHelper.GetRecordSortorFromStoreRefreshDataEventArgs(e);

            storeData.DataSource = SPRecordWrapper.QueryRecordByPage(this.ChannelID, this.CodeID, this.ClientID, this.DataType, this.StartDate.Value, this.EndDate.Value, new List<QueryFilter>(), recordSortor.OrderByColumnName, recordSortor.IsDesc, pageQueryParams);
            e.Total = pageQueryParams.RecordCount;
            storeData.DataBind();

        }

        protected void storeData_Submit(object sender, StoreSubmitDataEventArgs e)
        {


        }
    }
}