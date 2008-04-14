using System;
using Powerasp.Enterprise.Core.BaseManager.BaseDataUIPage.ViewFunction;
using Powerasp.Enterprise.Core.BaseManager.Domain;
using Powerasp.Enterprise.Core.BaseManager.Service;
using Powerasp.Enterprise.Core.Web.BasePage;

namespace BaseWebManager.Module.FrameWork.SystemApplicationManage.ApplicationManage
{
    public partial class ViewPage : SystemApplicationViewUIPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.LoadData())
                return;

            if (this.Page.IsPostBack)
                return;

            this.lblSystemApplicationName.Text = this.CurrentDataItem.SystemApplicationName.ToString();
            this.lblSystemApplicationDescription.Text = this.CurrentDataItem.SystemApplicationDescription.ToString();
            this.lblSystemApplicationUrl.Text = this.CurrentDataItem.SystemApplicationUrl.ToString();

        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            ReturnListPage();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GoToEditPage();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteCurrentObject();
        }



    }

}
