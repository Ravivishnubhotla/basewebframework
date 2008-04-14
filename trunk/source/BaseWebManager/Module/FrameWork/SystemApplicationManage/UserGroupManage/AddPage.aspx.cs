using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Powerasp.Enterprise.Core.BaseManager.BaseDataUIPage.AddFunction;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace BaseWebManager.Module.FrameWork.SystemApplicationManage.UserGroupManage
{
    public partial class AddPage : SystemUserGroupAddUIPage
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

            SystemUserGroup obj = new SystemUserGroup();
            obj.GroupNameCn = this.txtGroupNameCn.Text.Trim();
            obj.GroupNameEn = this.txtGroupNameEn.Text.Trim();
            obj.GroupDescription = this.txtGroupDescription.Text.Trim();

            //添加数据
            this.SaveCurrentData(obj);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            this.ReturnListPage();
        }
    }

}
