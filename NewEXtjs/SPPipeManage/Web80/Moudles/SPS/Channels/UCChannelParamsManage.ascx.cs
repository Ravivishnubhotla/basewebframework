using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.Channels
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCChannelParamsManage")]
    public partial class UCChannelParamsManage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                this.hidChannelSelect.Text = id.ToString();
                this.winSPChannelParamsList.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }
        }


        [AjaxMethod]
        public void DeleteRecord(int id)
        {
            try
            {
                SPChannelParamsWrapper.DeleteByID(id);

                ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ScriptManager.AjaxSuccess = false;
                ScriptManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }

        protected void storeSPChannelParams_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            int channelID = 0;


            if(!string.IsNullOrEmpty(e.Parameters["channelID"]))
            {
                try
                {
                    channelID = int.Parse(e.Parameters["channelID"]);
                }
                catch
                {
                }
            }


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

            storeSPChannelParams.DataSource = SPChannelParamsWrapper.FindAllByOrderBy(sortFieldName, (e.Dir == SortDirection.DESC), pageIndex, limit, channelID, out recordCount);
            e.TotalCount = recordCount;

            storeSPChannelParams.DataBind();

        }
    }
}