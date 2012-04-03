using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.NHibernate;

namespace Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings
{
    public partial class SPCodeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

 
        }

        public int ChannleID
        {
 
            get
            {
                if (this.cmbChannelID.SelectedItem == null)
                    return 0;
                if (this.cmbChannelID.SelectedItem.Value == "")
                    return 0;
                return Convert.ToInt32(this.cmbChannelID.SelectedItem.Value);
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

 

            string province = this.txtMO.Text.Trim();

            string port = this.txtPort.Text.Trim();


            List<SPClientChannelSettingWrapper> spClientChannelSettingWrappers = SPClientChannelSettingWrapper.FindAllByOrderByAndFilterAndChannelIDAndCodeAndPort(sortFieldName, (e.Dir == SortDirection.DESC), ChannleID, province, port, pageIndex,
                                                                                limit, out recordCount);
 

            storeSPClientChannelSetting.DataSource = spClientChannelSettingWrappers;
            e.TotalCount = recordCount;

            storeSPClientChannelSetting.DataBind();

        }

        protected void storeSPChannel_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            List<QueryFilter> filters = new List<QueryFilter>();

            filters.Add(new QueryFilter(SPChannelWrapper.PROPERTY_NAME_ISDISABLE, "false", FilterFunction.EqualTo));

            List<SPChannelWrapper> channels = SPChannelWrapper.FindAllByOrderByAndFilter(filters, SPChannelWrapper.PROPERTY_NAME_ID, true);

            storeSPChannel.DataSource = channels;

            storeSPChannel.DataBind();
        }

        protected void storeSPClientGroup_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            List<QueryFilter> filters = new List<QueryFilter>();

            List<SPClientGroupWrapper> channels = SPClientGroupWrapper.FindAllByOrderByAndFilter(filters, SPClientGroupWrapper.PROPERTY_NAME_ID, true);

            storeSPClientGroup.DataSource = channels;

            storeSPClientGroup.DataBind();
        }
    }
}