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
using Powerasp.Enterprise.Core.BaseManager.BaseDataUIPage.ViewFunction;
using Powerasp.Enterprise.Core.BaseManager.Service;
using Powerasp.Enterprise.Core.BaseManager.Web;

namespace BaseWebManager.Module.FrameWork.SystemApplicationManage.UserGroupManage
{
    public partial class ViewPage : SystemUserGroupViewUIPage
    {

        protected SystemRoleService systemRoleServiceInstance;

        public SystemRoleService SystemRoleServiceInstance
        {
            set { systemRoleServiceInstance = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.LoadData())
                return;

            if (this.Page.IsPostBack)
                return;

            this.lblGroupNameCn.Text = this.CurrentDataItem.GroupNameCn.ToString();
            this.lblGroupNameEn.Text = this.CurrentDataItem.GroupNameEn.ToString();
            this.lblGroupDescription.Text = this.CurrentDataItem.GroupDescription.ToString();

            this.dgAssignedRole.DataSource = systemRoleServiceInstance.FindAll();
            this.dgAssignedRole.DataBind();

            List<int> roleIDList = systemUserGroupServiceInstance.GetUserGroupAssignedroleIDList(this.CurrentDataItem);

            foreach (DataListItem item in this.dgAssignedRole.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chk = (CheckBox)item.FindControl("chkAssignedRole");
                    if (chk != null)
                        chk.Checked = roleIDList.Contains(int.Parse(chk.Attributes["value"]));
                }
            }

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

        protected void btnSaveAssignedRole_Click(object sender, EventArgs e)
        {
            List<int> roleIDList = new List<int>();

            foreach (DataListItem item in this.dgAssignedRole.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chk = (CheckBox)item.FindControl("chkAssignedRole");
                    if (chk != null && chk.Checked)
                        roleIDList.Add(int.Parse(chk.Attributes["value"]));
                }
            }

            try
            {
                systemUserGroupServiceInstance.SaveUserGroupAssignedRoleIDList(roleIDList, this.CurrentDataItem);
                WebMessageBox.ShowOperationOkMessage("操作成功", "用户保存系统用户组分配角色成功", this.ResolveUrl(this.GetListPageUrl()));
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception e1)
            {
                WebMessageBox.ShowOperationFailedMessage("操作失败", "用户保存系统用户组分配角色失败，错误原因：" + e1.Message, this.ResolveUrl(this.GetListPageUrl()));
            }
        }



    }
}
