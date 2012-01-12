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
    public partial class ReportSearchList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void storeSPChannel_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.storeSPChannel.DataSource = SPChannelWrapper.FindAll();

            this.storeSPChannel.DataBind();
        }


        protected void storeData_Refresh(object sender, StoreRefreshDataEventArgs e)
        {

            storeData.DataSource = new List<SPRecordWrapper>();
            storeData.DataBind();
 
            //PageQueryParams pageQueryParams = WebUIHelper.GetPageQueryParamFromStoreRefreshDataEventArgs(e,
            //                                                                                             this.
            //                                                                                                 PagingToolBar1);

            //RecordSortor recordSortor = WebUIHelper.GetRecordSortorFromStoreRefreshDataEventArgs(e);

            //SPChannelWrapper channel = null;

            //if(this.cmbChannel.SelectedItem!=null)
            //{
            //    channel = SPChannelWrapper.FindById(Convert.ToInt32(this.cmbChannel.SelectedItem.Value));
            //}

            //SPSClientWrapper client = null;

            //if(this.cmbClient.SelectedItem!=null)
            //{
            //    client = SPSClientWrapper.FindById(Convert.ToInt32(this.cmbClient.SelectedItem.Value));
            //}

            //SPCodeWrapper code = null;

            //if(this.cmbCode.SelectedItem!=null)
            //{
            //    code = SPCodeWrapper.FindById(Convert.ToInt32(this.cmbCode.SelectedItem.Value));
            //}


            //storeData.DataSource = SPRecordWrapper.QueryRecordByPage(channel, code, client, SPRecordWrapper.DayReportType_AllUp, null, null, new List<QueryFilter>(), recordSortor.OrderByColumnName, recordSortor.IsDesc,pageQueryParams);
            //storeData.DataBind();

        }

        protected void storeSPClient_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.storeSPClient.DataSource = SPSClientWrapper.FindAll();

            this.storeSPClient.DataBind();
        }

        protected void storeSPCode_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            SPChannelWrapper channel = null;

            if (this.cmbChannel.SelectedItem != null)
            {
                channel = SPChannelWrapper.FindById(Convert.ToInt32(this.cmbChannel.SelectedItem.Value));
            }

            if (channel!=null)
            {
                this.storeSPCode.DataSource = SPCodeWrapper.FindAllByChannelID(channel);
            }
            else
            {
                this.storeSPCode.DataSource = new List<SPCodeWrapper>();               
            }

            this.storeSPCode.DataBind();
 
        }
    }
}