using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;


namespace Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings
{
    public partial class SPClientChannelSettingListPage : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            if (ChannleID>0)
            {
                this.gridPanelSPClientChannelSetting.Header = false;
            }

            this.gridPanelSPClientChannelSetting.Reload();
        }

        public int ChannleID
        {
            get
            {
                if (this.Request.QueryString["ChannleID"] == null)
                    return 0;
                return Convert.ToInt32(this.Request.QueryString["ChannleID"]);
            }

        }


        [AjaxMethod]
        public void DeleteRecord(int id)
        {
            try
            {
                SPClientChannelSettingWrapper.DeleteByID(id);

                ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ScriptManager.AjaxSuccess = false;
                ScriptManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }

        protected void storeSPClientChannelSetting_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            int recordCount = 0;
            string sortFieldName = "";
            if (e.Sort != null)
                sortFieldName = e.Sort;

            if (sortFieldName == "ChannelClientRuleMatch")
                sortFieldName = "CommandCode";
            else if (sortFieldName == "ChannelClientCode")
                sortFieldName = "CommandCode";
 


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

            List<SPClientChannelSettingWrapper> spClientChannelSettingWrappers;

            if(ChannleID>0)
            {
                spClientChannelSettingWrappers = SPClientChannelSettingWrapper.FindAllByOrderByAndFilterAndChannelID(sortFieldName, (e.Dir == SortDirection.DESC), pageIndex, limit, SPChannelWrapper.FindById(ChannleID), out recordCount); 
            }
            else
            {
                spClientChannelSettingWrappers = SPClientChannelSettingWrapper.FindAllByOrderBy(sortFieldName, (e.Dir == SortDirection.DESC), pageIndex, limit, out recordCount); 
            }

            storeSPClientChannelSetting.DataSource = spClientChannelSettingWrappers;
            e.TotalCount = recordCount;

            storeSPClientChannelSetting.DataBind();

        }
    }

}
