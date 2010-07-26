using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;


namespace Legendigital.Common.Web.Moudles.SPS.Clients
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCClientParamsSetting")]
    public partial class UCClientParamsSetting : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            this.gridPanelSPSendClientParams.Reload();
        }


        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                this.hidClientSelect.Text = id.ToString();

                SPClientWrapper clientWrapper = SPClientWrapper.FindById(id);

                this.winSPChannelParamsList.Title = "[" + clientWrapper.Name + "]下家参数管理";


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
                SPSendClientParamsWrapper.DeleteByID(id);

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
            int clientID = 0;


            if (!string.IsNullOrEmpty(e.Parameters["clientID"]))
            {
                try
                {
                    clientID = int.Parse(e.Parameters["clientID"]);
                }
                catch
                {
                }
            }

            if(clientID==0)
            {
                storeSPSendClientParams.DataSource =new List<SPSendClientParamsWrapper>();
                e.TotalCount = 0;
                return;
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

            storeSPSendClientParams.DataSource = SPSendClientParamsWrapper.FindAllByOrderByAndClientID(sortFieldName, (e.Dir == SortDirection.DESC), pageIndex, limit, clientID, out recordCount);
            e.TotalCount = recordCount;

            storeSPSendClientParams.DataBind();

        }

    }
}