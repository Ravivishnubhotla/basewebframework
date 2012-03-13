using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Web.UI;
using Microsoft.Reporting.WebForms;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Reports
{
    public class ReportSearchCondition
    {
        public RecordSortor RecordSortor { get; set; }

        public SPChannelWrapper Channel { get; set; }

        public SPSClientWrapper Client { get; set; }

        public SPCodeWrapper Code { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public List<QueryFilter> QueryFilters { get; set; }
    }


    public partial class ReportSearchList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;
            this.dfStart.SelectedDate = System.DateTime.Now.Date.AddDays(-7);
            ReportViewHelper.FixReportDefinition(this.Server.MapPath("RecordExportTemplateForChannel.rdl"));
            rptvExport.LocalReport.ReportPath = this.Server.MapPath("RecordExportTemplateForChannel.rdl");
        }


        protected void storeSPChannel_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.storeSPChannel.DataSource = SPChannelWrapper.FindAll();

            this.storeSPChannel.DataBind();
        }


        protected void storeData_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            PageQueryParams pageQueryParams = WebUIHelper.GetPageQueryParamFromStoreRefreshDataEventArgs(e,
                                                                                                         this.
                                                                                                             PagingToolBar1);

            ReportSearchCondition reportSearchCondition = GetReportSearchCondition(WebUIHelper.GetRecordSortorFromStoreRefreshDataEventArgs(e));

            storeData.DataSource = SPRecordWrapper.QueryRecordByPage(reportSearchCondition.Channel, reportSearchCondition.Code, reportSearchCondition.Client, SPRecordWrapper.DayReportType_AllUp, reportSearchCondition.StartDate, reportSearchCondition.EndDate, reportSearchCondition.QueryFilters, reportSearchCondition.RecordSortor.OrderByColumnName, reportSearchCondition.RecordSortor.IsDesc, pageQueryParams);
            e.Total = pageQueryParams.RecordCount;
            storeData.DataBind();

        }

        private ReportSearchCondition GetReportSearchCondition(RecordSortor eSortor)
        {
            ReportSearchCondition reportSearchCondition = new ReportSearchCondition();

            reportSearchCondition.RecordSortor = eSortor;

            reportSearchCondition.Channel = null;

            if (this.cmbChannel.SelectedItem != null)
            {
                reportSearchCondition.Channel = SPChannelWrapper.FindById(Convert.ToInt32(this.cmbChannel.SelectedItem.Value));
            }

            reportSearchCondition.Client = null;

            if (this.cmbClient.SelectedItem != null)
            {
                reportSearchCondition.Client = SPSClientWrapper.FindById(Convert.ToInt32(this.cmbClient.SelectedItem.Value));
            }

            reportSearchCondition.Code = null;

            if (this.cmbCode.SelectedItem != null)
            {
                reportSearchCondition.Code = SPCodeWrapper.FindById(Convert.ToInt32(this.cmbCode.SelectedItem.Value));
            }

            reportSearchCondition.StartDate = null;

            if (this.dfStart.SelectedValue != null)
            {
                reportSearchCondition.StartDate = this.dfStart.SelectedDate;
            }

            reportSearchCondition.EndDate = null;

            if (this.dfEnd.SelectedValue != null)
            {
                reportSearchCondition.EndDate = this.dfEnd.SelectedDate;
            }

            reportSearchCondition.QueryFilters = new List<QueryFilter>();

            if (!string.IsNullOrEmpty(this.txtPhoneNumber.Text.Trim()))
            {
                reportSearchCondition.QueryFilters.Add(new QueryFilter(SPRecordWrapper.PROPERTY_NAME_MOBILE,
                                                                       this.txtPhoneNumber.Text.Trim(),
                                                                       FilterFunction.StartsWith));
            }

            if (!string.IsNullOrEmpty(this.txtLinkID.Text.Trim()))
            {
                reportSearchCondition.QueryFilters.Add(new QueryFilter(SPRecordWrapper.PROPERTY_NAME_LINKID,
                                                                       this.txtLinkID.Text.Trim(), FilterFunction.StartsWith));
            }

            if (!string.IsNullOrEmpty(this.txtSpNumber.Text.Trim()))
            {
                reportSearchCondition.QueryFilters.Add(new QueryFilter(SPRecordWrapper.PROPERTY_NAME_SPNUMBER,
                                                                       this.txtSpNumber.Text.Trim(), FilterFunction.StartsWith));
            }

            if (!string.IsNullOrEmpty(this.txtMo.Text.Trim()))
            {
                reportSearchCondition.QueryFilters.Add(new QueryFilter(SPRecordWrapper.PROPERTY_NAME_MO, this.txtMo.Text.Trim(),
                                                                       FilterFunction.StartsWith));
            }

            if (this.cmbIntercepter.SelectedItem != null && this.cmbIntercepter.SelectedItem.Value != null)
            {
                reportSearchCondition.QueryFilters.Add(new QueryFilter(SPRecordWrapper.PROPERTY_NAME_ISINTERCEPT,
                                                                       (this.cmbIntercepter.SelectedItem.Value == "1").ToString(),
                                                                       FilterFunction.EqualTo));
            }

            if (this.cmbStatus.SelectedItem != null && this.cmbStatus.SelectedItem.Value != null)
            {
                reportSearchCondition.QueryFilters.Add(new QueryFilter(SPRecordWrapper.PROPERTY_NAME_ISSTATOK,
                                                                       (this.cmbStatus.SelectedItem.Value == "1").ToString(),
                                                                       FilterFunction.EqualTo));
            }

            if (this.cmbSycnStatus.SelectedItem != null && this.cmbSycnStatus.SelectedItem.Value != null)
            {
                reportSearchCondition.QueryFilters.Add(new QueryFilter(SPRecordWrapper.PROPERTY_NAME_ISSYCNSUCCESSED,
                                                                       (this.cmbSycnStatus.SelectedItem.Value == "1").ToString(),
                                                                       FilterFunction.EqualTo));
            }

            if (this.cmbProvince.SelectedItem != null && this.cmbProvince.SelectedItem.Value != null)
            {
                reportSearchCondition.QueryFilters.Add(new QueryFilter(SPRecordWrapper.PROPERTY_NAME_PROVINCE,
                                                                       this.cmbProvince.SelectedItem.Value.ToString(),
                                                                       FilterFunction.EqualTo));
            }

            if (this.cmbOperateType.SelectedItem != null && this.cmbOperateType.SelectedItem.Value != null)
            {
                reportSearchCondition.QueryFilters.Add(new QueryFilter(SPRecordWrapper.PROPERTY_NAME_OPERATORTYPE,
                                                                       this.cmbOperateType.SelectedItem.Value.ToString(),
                                                                       FilterFunction.EqualTo));
            }
            return reportSearchCondition;
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

            if (channel != null)
            {
                this.storeSPCode.DataSource = SPCodeWrapper.FindAllByChannelID(channel);
            }
            else
            {
                this.storeSPCode.DataSource = new List<SPCodeWrapper>();
            }

            this.storeSPCode.DataBind();

        }

 

        protected void ExportToExcel(object sender, EventArgs e)
        {
            RecordSortor recordSortor = new RecordSortor();

            recordSortor.OrderByColumnName = "";

            ReportSearchCondition reportSearchCondition = GetReportSearchCondition(recordSortor);

            List<SPRecordWrapper> dataSource = SPRecordWrapper.QueryRecord(reportSearchCondition.Channel, reportSearchCondition.Code, reportSearchCondition.Client, SPRecordWrapper.DayReportType_AllUp, reportSearchCondition.StartDate, reportSearchCondition.EndDate, reportSearchCondition.QueryFilters, reportSearchCondition.RecordSortor.OrderByColumnName, reportSearchCondition.RecordSortor.IsDesc);

            byte[] reportFile = ReportViewHelper.ExportListToExcel(this.rptvExport, dataSource, "DataSet1", "自定义数据导出报表");

            this.Response.Clear();
            this.Response.ContentType = "application/vnd.ms-excel";
            this.Response.AddHeader("Content-Disposition", "attachment; filename=submittedData.xls");
            this.Response.BinaryWrite(reportFile);
            this.Response.End();
        }
    }
}