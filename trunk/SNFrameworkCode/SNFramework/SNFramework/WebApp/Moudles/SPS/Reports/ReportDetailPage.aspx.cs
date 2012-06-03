using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Web.UI;
using Microsoft.Reporting.WebForms;
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



            ReportViewHelper.FixReportDefinition(this.Server.MapPath("RecordExportTemplateForChannel.rdl"));
            rptvExport.LocalReport.ReportPath = this.Server.MapPath("RecordExportTemplateForChannel.rdl");

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


        protected void ExportToExcel(object sender, EventArgs e)
        {
            RecordSortor recordSortor = new RecordSortor();

            recordSortor.OrderByColumnName = "";



            List<SPRecordWrapper> dataSource = SPRecordWrapper.QueryRecord(this.ChannelID, this.CodeID, this.ClientID, this.DataType, this.StartDate.Value, this.EndDate.Value, new List<QueryFilter>(), recordSortor.OrderByColumnName, recordSortor.IsDesc);


            byte[] reportFile = ReportViewHelper.ExportListToExcel(this.rptvExport, dataSource, "DataSet1", "自定义数据导出报表");

 
            this.Response.Clear();
            this.Response.ContentType = "application/vnd.ms-excel";
            this.Response.AddHeader("Content-Disposition", "attachment; filename=submittedData.xls");
            this.Response.BinaryWrite(reportFile);
            this.Response.End();
        }
 
    }
}