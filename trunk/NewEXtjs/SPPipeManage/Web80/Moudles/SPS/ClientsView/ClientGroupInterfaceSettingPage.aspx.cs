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
    public partial class ClientGroupInterfaceSettingPage : SPClientGroupViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            int id = this.ClientGroupID;

            storeSPClient.BaseParams.Add(new Parameter("ClientGroupID", id.ToString(), ParameterMode.Value));

            this.hidId.Text = id.ToString();
        }

        public int SPClientGroupID
        {
            get
            {
                if (this.hidId.Text == "")
                {
                    this.hidId.Text = this.ClientGroupID.ToString();
                }
                return Convert.ToInt32(this.hidId.Text);
            }
        }


        protected void storeSPClient_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.storeSPClient.DataSource = SPClientWrapper.FindAllBySPClientGroupID(SPClientGroupWrapper.FindById(SPClientGroupID));
            this.storeSPClient.DataBind();
        }
    }
}