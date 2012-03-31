using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.Web.UI;
using ScriptManager = Coolite.Ext.Web.ScriptManager;
using SortDirection = Coolite.Ext.Web.SortDirection;

namespace Legendigital.Common.Web.Moudles.SPS.Codes
{
    public partial class SPCodeInfoList : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;


            ReportViewHelper.FixReportDefinition(this.Server.MapPath("CodeInfoExport.rdl"));
            rptvExport.LocalReport.ReportPath = this.Server.MapPath("CodeInfoExport.rdl");

            btnExport.Hidden = IsSPCommUser;

            this.gridPanelSPCodeInfo.Reload();
        }

        public bool IsSPCommUser
        {
            get
            {
                return this.Context.User.IsInRole("SPCOM");
            }
        }


        [AjaxMethod]
        public void DeleteRecord(int id)
        {
            try
            {
                SPCodeInfoWrapper.DeleteByID(id);

                ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ScriptManager.AjaxSuccess = false;
                ScriptManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }

        protected void storeSPChannel_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            List<QueryFilter> filters = new List<QueryFilter>();

            filters.Add(new QueryFilter(SPChannelWrapper.PROPERTY_NAME_ISDISABLE, "false", FilterFunction.EqualTo));

            List<SPChannelWrapper> channels = SPChannelWrapper.FindAllByOrderByAndFilter(filters, SPChannelWrapper.PROPERTY_NAME_ID, true);

            storeSPChannel.DataSource = channels;

            storeSPChannel.DataBind();
        }

 

        protected void storeSPCodeInfo_Refresh(object sender, StoreRefreshDataEventArgs e)
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

            List<QueryFilter> queryFilters = new List<QueryFilter>();

            int channelID = 0;

            if (this.cmbSChannelID.SelectedItem != null && this.cmbSChannelID.SelectedItem.Value!="")
            {
                channelID = Convert.ToInt32(this.cmbSChannelID.SelectedItem.Value);
            }

            if (this.cmbSOperatorType.SelectedItem != null && this.cmbSOperatorType.SelectedItem.Value != "")
                queryFilters.Add(new QueryFilter(SPCodeInfoWrapper.PROPERTY_NAME_OPERATORTYPE, this.cmbSOperatorType.SelectedItem.Value, FilterFunction.EqualTo));

            if (this.cmbSProvince.SelectedItem != null && this.cmbSProvince.SelectedItem.Value != "")
                queryFilters.Add(new QueryFilter(SPCodeInfoWrapper.PROPERTY_NAME_PROVINCE, this.cmbSProvince.SelectedItem.Value, FilterFunction.Contains));

            if (!string.IsNullOrEmpty(this.txtSMo.Text))
                queryFilters.Add(new QueryFilter(SPCodeInfoWrapper.PROPERTY_NAME_MO, this.txtSMo.Text.Trim(), FilterFunction.Contains));

            if (!string.IsNullOrEmpty(this.txtSPort.Text))
                queryFilters.Add(new QueryFilter(SPCodeInfoWrapper.PROPERTY_NAME_SPCODE, this.txtSPort.Text.Trim(), FilterFunction.Contains));

            if (this.cmbSEnbale.SelectedItem != null && this.cmbSEnbale.SelectedItem.Value != "")
                queryFilters.Add(new QueryFilter(SPCodeInfoWrapper.PROPERTY_NAME_ISENABLE, this.cmbSEnbale.SelectedItem.Value.Equals("1").ToString(), FilterFunction.EqualTo));

            if (this.cmbLimit.SelectedItem != null && this.cmbLimit.SelectedItem.Value != "")
                queryFilters.Add(new QueryFilter(SPCodeInfoWrapper.PROPERTY_NAME_ISLIMIT, this.cmbLimit.SelectedItem.Value.Equals("1").ToString(), FilterFunction.EqualTo));

            storeSPCodeInfo.DataSource = SPCodeInfoWrapper.FindAllByOrderByAndFilterAndChannelID(channelID, queryFilters, sortFieldName, (e.Dir == SortDirection.DESC), pageIndex, limit, out recordCount);
            e.TotalCount = recordCount;

            storeSPCodeInfo.DataBind();
        }


        protected void ExportToExcel(object sender, EventArgs e)
        {
            List<QueryFilter> queryFilters = new List<QueryFilter>();

            int channelID = 0;

            if (this.cmbSChannelID.SelectedItem != null && this.cmbSChannelID.SelectedItem.Value != "")
            {
                channelID = Convert.ToInt32(this.cmbSChannelID.SelectedItem.Value);
            }

            if (this.cmbSOperatorType.SelectedItem != null && this.cmbSOperatorType.SelectedItem.Value != "")
                queryFilters.Add(new QueryFilter(SPCodeInfoWrapper.PROPERTY_NAME_OPERATORTYPE, this.cmbSOperatorType.SelectedItem.Value, FilterFunction.EqualTo));

            if (this.cmbSProvince.SelectedItem != null && this.cmbSProvince.SelectedItem.Value != "")
                queryFilters.Add(new QueryFilter(SPCodeInfoWrapper.PROPERTY_NAME_PROVINCE, this.cmbSProvince.SelectedItem.Value, FilterFunction.Contains));

            if (!string.IsNullOrEmpty(this.txtSMo.Text))
                queryFilters.Add(new QueryFilter(SPCodeInfoWrapper.PROPERTY_NAME_MO, this.txtSMo.Text.Trim(), FilterFunction.Contains));

            if (!string.IsNullOrEmpty(this.txtSPort.Text))
                queryFilters.Add(new QueryFilter(SPCodeInfoWrapper.PROPERTY_NAME_SPCODE, this.txtSPort.Text.Trim(), FilterFunction.Contains));

            if (this.cmbSEnbale.SelectedItem != null && this.cmbSEnbale.SelectedItem.Value != "")
                queryFilters.Add(new QueryFilter(SPCodeInfoWrapper.PROPERTY_NAME_ISENABLE, this.cmbSEnbale.SelectedItem.Value.Equals("1").ToString(), FilterFunction.EqualTo));

            if (this.cmbLimit.SelectedItem != null && this.cmbLimit.SelectedItem.Value != "")
                queryFilters.Add(new QueryFilter(SPCodeInfoWrapper.PROPERTY_NAME_ISLIMIT, this.cmbLimit.SelectedItem.Value.Equals("1").ToString(), FilterFunction.EqualTo));



            List<SPCodeInfoWrapper> dataSource = SPCodeInfoWrapper.FindAllByOrderByAndChannelID(channelID, queryFilters, "", false);

            byte[] reportFile = ReportViewHelper.ExportListToExcel(this.rptvExport, dataSource, "DataSet1", "自定义数据导出报表");

            this.Response.Clear();
            this.Response.ContentType = "application/vnd.ms-excel";
            this.Response.AddHeader("Content-Disposition", "attachment; filename=submittedData.xls");
            this.Response.BinaryWrite(reportFile);
            this.Response.End();
        }
    }
}