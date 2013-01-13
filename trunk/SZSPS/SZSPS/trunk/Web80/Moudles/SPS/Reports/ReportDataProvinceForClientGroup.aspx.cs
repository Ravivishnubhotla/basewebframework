using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.NHibernate;

namespace Legendigital.Common.Web.Moudles.SPS.Reports
{
    public partial class ReportDataProvinceForClientGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            this.dfReportStartDate.DateField.Value = System.DateTime.Now.AddDays(-5).Date;
            this.dfReportEndDate.DateField.Value = System.DateTime.Now.Date;

        }


        protected void btnRefresh_Click(object sender, AjaxEventArgs e)
        {
            if (cmbCode.SelectedItem == null)
                return;

            this.ReportPanel.AutoLoad.Params.Clear();
            this.ReportPanel.AutoLoad.Params.Add(new Coolite.Ext.Web.Parameter("ChannleID", cmbChannelID.SelectedItem.Value.ToString()));
            this.ReportPanel.AutoLoad.Params.Add(new Coolite.Ext.Web.Parameter("ChannleClientSettingID", cmbCode.SelectedItem.Value.ToString()));
            this.ReportPanel.AutoLoad.Params.Add(new Coolite.Ext.Web.Parameter("StartDate", dfReportStartDate.DateField.SelectedDate.ToString("yyyy-MM-dd hh:mm:ss")));
            this.ReportPanel.AutoLoad.Params.Add(new Coolite.Ext.Web.Parameter("EndDate", dfReportEndDate.DateField.SelectedDate.ToString("yyyy-MM-dd hh:mm:ss")));
            this.ReportPanel.AutoLoad.Url = "ReportDataProvinceForClientGroupService.aspx";
            this.ReportPanel.LoadContent();
        }

        protected void storeSPClientGroup_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
 
            List<SPClientGroupWrapper> channels = SPClientGroupWrapper.FindAll();

            storeSPClientGroup.DataSource = channels;

            storeSPClientGroup.DataBind();

        }

        protected void storeSPChannelClientSetting_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            int clientGroupID = int.Parse(e.Parameters["SPClientGroupID"].ToString());

            SPClientGroupWrapper channelWrapper = SPClientGroupWrapper.FindById(clientGroupID);

            storeSPChannelClientSetting.DataSource = channelWrapper.GetAllChannelClientSetting();

            storeSPChannelClientSetting.DataBind();
        }
    }
}