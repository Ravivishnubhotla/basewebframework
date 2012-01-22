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
            if (X.IsAjaxRequest)
                return;
            this.dfStart.SelectedDate = System.DateTime.Now.Date.AddDays(-7);
        }


        protected void storeSPChannel_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.storeSPChannel.DataSource = SPChannelWrapper.FindAll();

            this.storeSPChannel.DataBind();
        }


        protected void storeData_Refresh(object sender, StoreRefreshDataEventArgs e)
        {

            //storeData.DataSource = new List<SPRecordWrapper>();
            //storeData.DataBind();

            PageQueryParams pageQueryParams = WebUIHelper.GetPageQueryParamFromStoreRefreshDataEventArgs(e,
                                                                                                         this.
                                                                                                             PagingToolBar1);

            RecordSortor recordSortor = WebUIHelper.GetRecordSortorFromStoreRefreshDataEventArgs(e);

            SPChannelWrapper channel = null;

            if (this.cmbChannel.SelectedItem != null)
            {
                channel = SPChannelWrapper.FindById(Convert.ToInt32(this.cmbChannel.SelectedItem.Value));
            }

            SPSClientWrapper client = null;

            if (this.cmbClient.SelectedItem != null)
            {
                client = SPSClientWrapper.FindById(Convert.ToInt32(this.cmbClient.SelectedItem.Value));
            }

            SPCodeWrapper code = null;

            if (this.cmbCode.SelectedItem != null)
            {
                code = SPCodeWrapper.FindById(Convert.ToInt32(this.cmbCode.SelectedItem.Value));
            }

            DateTime? startDate = null;

            if (this.dfStart.SelectedValue != null)
            {
                startDate = this.dfStart.SelectedDate;
            }

            DateTime? endDate = null;

            if (this.dfEnd.SelectedValue != null)
            {
                endDate = this.dfEnd.SelectedDate;
            }

            List<QueryFilter> queryFilters = new List<QueryFilter>();

            if(!string.IsNullOrEmpty(this.txtPhoneNumber.Text.Trim()))
            {
                queryFilters.Add(new QueryFilter(SPRecordWrapper.PROPERTY_NAME_MOBILE, this.txtPhoneNumber.Text.Trim(),FilterFunction.StartsWith));
            }

            if (!string.IsNullOrEmpty(this.txtLinkID.Text.Trim()))
            {
                queryFilters.Add(new QueryFilter(SPRecordWrapper.PROPERTY_NAME_LINKID, this.txtLinkID.Text.Trim(), FilterFunction.StartsWith));
            }

            if (!string.IsNullOrEmpty(this.txtSpNumber.Text.Trim()))
            {
                queryFilters.Add(new QueryFilter(SPRecordWrapper.PROPERTY_NAME_SPNUMBER, this.txtSpNumber.Text.Trim(), FilterFunction.StartsWith));
            }

            if (!string.IsNullOrEmpty(this.txtMo.Text.Trim()))
            {
                queryFilters.Add(new QueryFilter(SPRecordWrapper.PROPERTY_NAME_MO, this.txtMo.Text.Trim(), FilterFunction.StartsWith));
            }

            if (this.cmbIntercepter.SelectedItem != null && this.cmbIntercepter.SelectedItem.Value != null)
            {
                queryFilters.Add(new QueryFilter(SPRecordWrapper.PROPERTY_NAME_ISINTERCEPT, (this.cmbIntercepter.SelectedItem.Value == "1").ToString(), FilterFunction.EqualTo));
            }

            if (this.cmbStatus.SelectedItem != null && this.cmbStatus.SelectedItem.Value != null)
            {
                queryFilters.Add(new QueryFilter(SPRecordWrapper.PROPERTY_NAME_ISSTATOK, (this.cmbStatus.SelectedItem.Value == "1").ToString(), FilterFunction.EqualTo));
            }

            if (this.cmbSycnStatus.SelectedItem != null && this.cmbSycnStatus.SelectedItem.Value != null)
            {
                queryFilters.Add(new QueryFilter(SPRecordWrapper.PROPERTY_NAME_ISSYCNSUCCESSED, (this.cmbSycnStatus.SelectedItem.Value=="1").ToString(), FilterFunction.EqualTo));
            }

            if (this.cmbProvince.SelectedItem != null && this.cmbProvince.SelectedItem.Value != null)
            {
                queryFilters.Add(new QueryFilter(SPRecordWrapper.PROPERTY_NAME_PROVINCE, this.cmbProvince.SelectedItem.Value.ToString(), FilterFunction.EqualTo));
            }

            if (this.cmbOperateType.SelectedItem != null && this.cmbOperateType.SelectedItem.Value != null)
            {
                queryFilters.Add(new QueryFilter(SPRecordWrapper.PROPERTY_NAME_OPERATORTYPE, this.cmbOperateType.SelectedItem.Value.ToString(), FilterFunction.EqualTo));
            }

            storeData.DataSource = SPRecordWrapper.QueryRecordByPage(channel, code, client, SPRecordWrapper.DayReportType_AllUp, startDate, endDate, queryFilters, recordSortor.OrderByColumnName, recordSortor.IsDesc, pageQueryParams);
            e.Total = pageQueryParams.RecordCount;
            storeData.DataBind();

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