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
using Powerasp.Enterprise.Core.BaseManager.Domain;
using Powerasp.Enterprise.Core.BaseManager.Service;
using Powerasp.Enterprise.Core.BaseManager.Web;
using Powerasp.Enterprise.Core.Web.BasePage;
using Powerasp.Enterprise.Core.Web.ControlHelper;

namespace BaseWebManager.Module.FrameWork.SystemApplicationManage.RoleManage
{
    public partial class ViewPage : SystemRoleViewUIPage
    {
        private SystemApplicationService systemApplicationServiceInstance;

        public SystemApplicationService SystemApplicationServiceInstance
        {
            set { systemApplicationServiceInstance = value; }
        }

        private SystemMenuService systemMenuServiceInstance;

        public SystemMenuService SystemMenuServiceInstance
        {
            set { systemMenuServiceInstance = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.LoadData())
                return;

            if (this.Page.IsPostBack)
                return;

            this.lblRoleName.Text = this.CurrentDataItem.RoleName.ToString();
            this.lblRoleDescription.Text = this.CurrentDataItem.RoleDescription.ToString();
            this.lblRoleIsSystemRole.Text = this.CurrentDataItem.RoleIsSystemRole.ToString();

            this.dgAssignedRole.DataSource = systemApplicationServiceInstance.FindAll();
            this.dgAssignedRole.DataBind();

            List<int> applicatonIDList = systemRoleServiceInstance.GetRoleAssignedApplicatonIDList(this.CurrentDataItem);

            foreach (DataListItem  item in this.dgAssignedRole.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chk = (CheckBox)item.FindControl("chkAssignedRole");
                    if (chk != null)
                        chk.Checked = applicatonIDList.Contains(int.Parse(chk.Attributes["value"]));
                }
            }

            this.ddlSelectApplication.DataSource = systemApplicationServiceInstance.FindAll();
            this.ddlSelectApplication.DataTextField = SystemApplication.PROPERTY_NAME_SYSTEMAPPLICATIONNAME;
            this.ddlSelectApplication.DataValueField = SystemApplication.PROPERTY_NAME_SYSTEMAPPLICATIONID;
            this.ddlSelectApplication.DataBind();
            this.ddlSelectApplication.SelectedIndex = 0;

            BindManageMenuTreeByApplicationIDAndSelectNodeArray(this.ddlSelectApplication.SelectedValue,
                                                               systemRoleServiceInstance.GetRoleAssigedMenuIDs(this.CurrentDataItem));

        }


        private void BindManageMenuTreeByApplicationIDAndSelectNodeArray(string appID, List<string> selectNodeID)
        {
            if (appID != "")
            {
                int selectAppId = int.Parse(appID);
                SystemApplication selectApp = systemApplicationServiceInstance.FindById(selectAppId);
                if (selectApp != null)
                {
                    this.tvMenus.Nodes.Clear();
                    this.tvMenus.Nodes.Add(systemMenuServiceInstance.GenerateSelectAssignedWebTreeNodeByApplication(selectApp, this.ResolveUrl("~/images/Menu/control_panel.gif"), this.ResolveUrl("~/images/Menu/folders.gif"), this.ResolveUrl("~/images/Menu/folder.gif")));
                }
                TreeViewHelper.CheckTreeViewByValues(this.tvMenus, selectNodeID);
                this.tvMenus.ExpandAll();
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            this.ReturnListPage();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            this.GoToEditPage();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            this.DeleteCurrentObject();
        }

        protected void btnSaveAssignedApplication_Click(object sender, EventArgs e)
        {
            List<int> applicatonIDList = new List<int>();

            foreach (DataListItem item in this.dgAssignedRole.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chk = (CheckBox)item.FindControl("chkAssignedRole");
                    if (chk != null && chk.Checked)
                        applicatonIDList.Add(int.Parse(chk.Attributes["value"]));
                }
            }

            try
            {
                systemRoleServiceInstance.SaveRoleAssignedApplicatonIDList(applicatonIDList, this.CurrentDataItem);
                WebMessageBox.ShowOperationOkMessage("操作成功", "用户保存系统角色分配应用成功", this.ResolveUrl(this.GetListPageUrl()));
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception e1)
            {
                WebMessageBox.ShowOperationFailedMessage("操作失败", "用户保存系统角色分配应用失败，错误原因：" + e1.Message, this.ResolveUrl(this.GetListPageUrl()));
            }


        }

        protected void ddlSelectApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindManageMenuTreeByApplicationIDAndSelectNodeArray(this.ddlSelectApplication.SelectedValue, systemRoleServiceInstance.GetRoleAssigedMenuIDs(this.CurrentDataItem));
            this.tabList.ActiveTabIndex = 2;
        }

        protected void btnSaveAssignedMenu_Click(object sender, EventArgs e)
        {

            List<int> menuIDList = TreeViewHelper.GetTreeViewCheckValue(this.tvMenus);

            try
            {
                systemRoleServiceInstance.SaveRoleAssignedMenuIDList(menuIDList, this.CurrentDataItem);
                WebMessageBox.ShowOperationOkMessage("操作成功", "用户保存系统角色分配菜单成功", this.ResolveUrl(this.GetListPageUrl()));
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception e1)
            {
                WebMessageBox.ShowOperationFailedMessage("操作失败", "用户保存系统角色分配菜单失败，错误原因：" + e1.Message, this.ResolveUrl(this.GetListPageUrl()));
            }


        }

    }


}
