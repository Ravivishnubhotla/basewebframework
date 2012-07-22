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
    public partial class SPClientAddToGroup : System.Web.UI.Page
    {
        public int ClientGroupID
        {
            get
            {
                if (this.Request.QueryString["ClientGroupID"] == null)
                    return 0;
                return Convert.ToInt32(this.Request.QueryString["ClientGroupID"]);
            }

        }

        protected void btnSave_Click(object sender, AjaxEventArgs e)
        {


            try
            {
                if (this.cmbClientID.SelectedItem != null)
                {

                    int spClientID = int.Parse(this.cmbClientID.SelectedItem.Value.ToString());


                    SPClientWrapper spClientWrapper = SPClientWrapper.FindById(spClientID);




                    spClientWrapper.SPClientGroupID = SPClientGroupWrapper.FindById(ClientGroupID);


                    SPClientWrapper.Update(spClientWrapper);


                    spClientWrapper.UpdateSyncDataSetting(spClientWrapper.SPClientGroupID.DefaultInterceptRate);

                }

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            SPClientGroupWrapper spClientGroupWrapper = SPClientGroupWrapper.FindById(ClientGroupID);

            this.lblClientGroupName.Text = spClientGroupWrapper.Name;
        }

        protected void storeSClienAdd_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            storeSClienAdd.DataSource = SPClientWrapper.FindAllNotInClientGroup(ClientGroupID);
            storeSClienAdd.DataBind();
        }
    }
}