using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.Clients
{
    public partial class SPClientGroupCodeListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.gridPanelSPClientChannelSetting.Reload();
        }

        public int ClientGroupID
        {
            get
            {
                if (this.Request.QueryString["ClientGroupID"] == null)
                    return 0;
                return Convert.ToInt32(this.Request.QueryString["ClientGroupID"]);
            }

        }

        protected void storeSPClientChannelSetting_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            SPClientGroupWrapper clientGroup = SPClientGroupWrapper.FindById(ClientGroupID);

            storeSPClientChannelSetting.DataSource = clientGroup.GetAllChannelClientSetting();
 
            storeSPClientChannelSetting.DataBind();

        }
    }
}