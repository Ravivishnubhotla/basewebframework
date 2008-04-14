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
using Powerasp.Enterprise.Core.BaseManager.BaseDataUIPage.AddFunction;
using Powerasp.Enterprise.Core.BaseManager.Domain;
using Powerasp.Enterprise.Core.BaseManager.Service;
using Powerasp.Enterprise.Core.BaseManager.Web;
using Powerasp.Enterprise.Core.Web.BasePage;

namespace BaseWebManager.Module.FrameWork.SystemApplicationManage.RoleManage
{
    public partial class AddPage : SystemRoleAddUIPage
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

            SystemRole obj = new SystemRole();
            obj.RoleName = this.txtRoleName.Text.Trim();
            obj.RoleDescription = this.txtRoleDescription.Text.Trim();
            obj.RoleIsSystemRole = this.chkRoleIsSystemRole.Checked;

            //添加数据
            this.SaveCurrentData(obj);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            this.ReturnListPage();
        }
    }
}
