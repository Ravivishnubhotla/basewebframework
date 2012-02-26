using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Common.Web.AppClass;

namespace Legendigital.Common.Web.Moudles.SPS.ClientsView
{
    public partial class ClientChannleView : SPSClientViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            this.gridPanelSPChannel.Reload();
        }

 

        protected void storeSPChannel_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            List<SPChannelWrapper> channels = SPClientChannelSettingWrapper.GetChannelByClient(SPClientWrapper.FindById(this.SPClientID));

            storeSPChannel.DataSource = channels;

            storeSPChannel.DataBind();
        }
    }
}
