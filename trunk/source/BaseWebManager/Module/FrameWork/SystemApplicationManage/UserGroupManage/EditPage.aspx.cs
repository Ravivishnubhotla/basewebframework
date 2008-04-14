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
using Powerasp.Enterprise.Core.BaseManager.BaseDataUIPage.EditFunction;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace BaseWebManager.Module.FrameWork.SystemApplicationManage.UserGroupManage
{
    public partial class EditPage : SystemUserGroupEditUIPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.LoadData())
                return;

            if (this.Page.IsPostBack)
                return;

            this.txtGroupNameCn.Text = this.CurrentDataItem.GroupNameCn.ToString();
            this.txtGroupNameEn.Text = this.CurrentDataItem.GroupNameEn.ToString();
            this.txtGroupDescription.Text = this.CurrentDataItem.GroupDescription.ToString();

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

            SystemUserGroup obj = this.CurrentDataItem;

            obj.GroupNameCn = this.txtGroupNameCn.Text.Trim();
            obj.GroupNameEn = this.txtGroupNameEn.Text.Trim();
            obj.GroupDescription = this.txtGroupDescription.Text.Trim();



            //更新数据
            this.UpdateCurrentData(obj);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            this.DeleteCurrentObject();
        }

    }
}
