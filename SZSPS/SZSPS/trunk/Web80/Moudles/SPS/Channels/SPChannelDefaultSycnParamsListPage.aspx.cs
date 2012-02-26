using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.Channels
{
    public partial class SPChannelDefaultSycnParamsListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;
            this.gridPanelSPSendClientParams.Reload();
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
                SPChannelDefaultClientSycnParamsWrapper.DeleteByID(id);

                ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ScriptManager.AjaxSuccess = false;
                ScriptManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }


        [AjaxMethod]
        public void PatchAdd()
        {
            try
            {
                SPChannelDefaultClientSycnParamsWrapper.PatchAdd(ChannleID);

                ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ScriptManager.AjaxSuccess = false;
                ScriptManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }




        protected void storeSPSendClientParams_Refresh(object sender, StoreRefreshDataEventArgs e)
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

            storeSPSendClientParams.DataSource = SPChannelDefaultClientSycnParamsWrapper.FindAllByOrderByAndFilterAndChannelID(sortFieldName, (e.Dir == Coolite.Ext.Web.SortDirection.DESC), pageIndex, limit, SPChannelWrapper.FindById(this.ChannleID), out recordCount);
            e.TotalCount = recordCount;

            storeSPSendClientParams.DataBind();

        }


    }
}