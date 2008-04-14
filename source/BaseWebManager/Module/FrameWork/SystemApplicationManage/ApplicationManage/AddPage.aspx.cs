using System;
using System.Collections.Generic;
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
using BaseWebManager.UC;
using Powerasp.Enterprise.Core.BaseManager.BaseDataUIPage.AddFunction;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace BaseWebManager.Module.FrameWork.SystemApplicationManage.ApplicationManage
{
    public partial class AddPage : SystemApplicationAddUIPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //验证不通过返回
            if (!this.Page.IsValid)
                return;

            SystemApplication obj = new SystemApplication();
            obj.SystemApplicationName = this.txtSystemApplicationName.Text.Trim();
            obj.SystemApplicationDescription = this.txtSystemApplicationDescription.Text.Trim();
            obj.SystemApplicationUrl = this.txtSystemApplicationUrl.Text.Trim();

            //添加数据
            this.SaveCurrentData(obj);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            this.ReturnListPage();
        }
    }
}
