using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Powerasp.Enterprise.Core.BaseManager.BaseDataUIPage.EditFunction;
using Powerasp.Enterprise.Core.BaseManager.Domain;
using Powerasp.Enterprise.Core.BaseManager.Service;
using Powerasp.Enterprise.Core.BaseManager.Web;
using Powerasp.Enterprise.Core.Web.BasePage;

namespace BaseWebManager.Module.FrameWork.SystemApplicationManage.ApplicationManage
{
    public partial class EditPage : SystemApplicationEditUIPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.LoadData())
                return;

            if (this.Page.IsPostBack)
                return;

            this.txtSystemApplicationName.Text = this.CurrentDataItem.SystemApplicationName.ToString();
            this.txtSystemApplicationDescription.Text = this.CurrentDataItem.SystemApplicationDescription.ToString();
            this.txtSystemApplicationUrl.Text = this.CurrentDataItem.SystemApplicationUrl.ToString();

        }


        protected void btnReturn_Click(object sender, EventArgs e)
        {
            this.ReturnListPage();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //验证不通过返回
            if (!this.Page.IsValid)
                return;

            SystemApplication obj = this.CurrentDataItem;

            obj.SystemApplicationName = this.txtSystemApplicationName.Text.Trim();
            obj.SystemApplicationDescription = this.txtSystemApplicationDescription.Text.Trim();
            obj.SystemApplicationUrl = this.txtSystemApplicationUrl.Text.Trim();



            //更新数据
            this.UpdateCurrentData(obj);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            this.DeleteCurrentObject();
        }

    }




}
