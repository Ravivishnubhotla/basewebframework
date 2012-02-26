using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Common.Web.AppClass;

namespace Legendigital.Common.Web.Moudles.SPS.ClientsView
{
    public partial class ClientMobileReportView : SPClientGroupViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            int id = this.ClientGroupID;

            this.dfReportEndDate.DateField.Value = System.DateTime.Now.Date;

            this.dfReportStartDate.DateField.Value = System.DateTime.Now.Date;

            SPClientGroupWrapper spClientGroupWrapper = SPClientGroupWrapper.FindById(this.ClientGroupID);

            this.dfReportStartDate.DateField.MinDate = spClientGroupWrapper.GetDT();

            storeSPClient.BaseParams.Add(new Coolite.Ext.Web.Parameter("ClientGroupID", id.ToString(), ParameterMode.Value));

            this.hidId.Text = id.ToString();
        }

        protected void storeSPClient_OnRefresh(object sender, StoreRefreshDataEventArgs e)
        {
            SPClientGroupWrapper clientGroup = SPClientGroupWrapper.FindById(this.ClientGroupID);

            storeSPClient.DataSource = SPClientWrapper.FindAllBySPClientGroupID(clientGroup);
            storeSPClient.DataBind();
        }


        public int SPClientID
        {
            get
            {
                if (this.cmbClientID.SelectedItem == null)
                    return 0;
                if (this.cmbClientID.SelectedItem.Value == "")
                    return 0;
                return Convert.ToInt32(this.cmbClientID.SelectedItem.Value);
            }
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

        protected void store1_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            DateTime startDate = Convert.ToDateTime(this.dfReportStartDate.DateField.Value);

            SPClientGroupWrapper spClientGroupWrapper = SPClientGroupWrapper.FindById(this.ClientGroupID);

            if (startDate < spClientGroupWrapper.GetDT())
            {
                startDate = spClientGroupWrapper.GetDT();
            }

            DateTime endDate = Convert.ToDateTime(this.dfReportEndDate.DateField.Value);


            store1.DataSource = SPPaymentInfoWrapper.GetClientMobileCount(SPClientID, startDate, endDate);
 

            store1.DataBind();
        }
    }
}