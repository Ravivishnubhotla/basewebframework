using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;
 

namespace Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings
{
    public partial class SPClientChannelSettingFiltersListPage : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            this.gridPanelSPClientChannelSettingFilters.Reload();
        }

        public int ChannleClientID
        {
            get
            {
                if (this.Request.QueryString["ChannleClientID"] == null)
                    return 0;
                return Convert.ToInt32(this.Request.QueryString["ChannleClientID"]);
            }

        }


        [AjaxMethod]
        public void DeleteRecord(int id)
        {
            try
            {
                SPClientChannelSettingFiltersWrapper.DeleteByID(id);

                ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ScriptManager.AjaxSuccess = false;
                ScriptManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }

        protected void storeSPClientChannelSettingFilters_Refresh(object sender, StoreRefreshDataEventArgs e)
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


            List<SPClientChannelSettingFiltersWrapper> datas;

            if (ChannleClientID > 0)
            {
                datas = SPClientChannelSettingFiltersWrapper.FindAllByOrderByAndFilterAndClientChannelSettingID(sortFieldName, (e.Dir == SortDirection.DESC), pageIndex, limit, SPClientChannelSettingWrapper.FindById(ChannleClientID), out recordCount);
            }
            else
            {
                datas = SPClientChannelSettingFiltersWrapper.FindAllByOrderBy(sortFieldName, (e.Dir == SortDirection.DESC), pageIndex, limit, out recordCount);
            }


            storeSPClientChannelSettingFilters.DataSource = datas;
            e.TotalCount = recordCount;

            storeSPClientChannelSettingFilters.DataBind();

        }
    }

}