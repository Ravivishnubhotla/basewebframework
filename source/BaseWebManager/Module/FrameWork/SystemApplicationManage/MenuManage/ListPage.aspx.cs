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
using Powerasp.Enterprise.Core.BaseManager.Domain;
using Powerasp.Enterprise.Core.BaseManager.Service;
using Powerasp.Enterprise.Core.Web.BasePage;
using Powerasp.Enterprise.Core.Web.ControlHelper;
using Powerasp.Enterprise.Core.Web.UI.WebControls;

namespace BaseWebManager.Module.FrameWork.SystemApplicationManage.MenuManage
{
    public partial class ListPage : BaseSecurityPage
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
            if (this.Page.IsPostBack)
                return;

            this.ddlSelectApplication.DataSource = systemApplicationServiceInstance.FindAll();
            this.ddlSelectApplication.DataTextField = SystemApplication.PROPERTY_NAME_SYSTEMAPPLICATIONNAME;
            this.ddlSelectApplication.DataValueField = SystemApplication.PROPERTY_NAME_SYSTEMAPPLICATIONID;
            this.ddlSelectApplication.DataBind();
            this.ddlSelectApplication.SelectedIndex = 0;

            BindManageMenuTreeByApplicationIDAndSelectNodeID(this.ddlSelectApplication.SelectedValue, "0");
        }

        private int CurrentSelectMenuID
        {
            get
            {
                int menuID = 0;
                int.TryParse(this.tvMenus.SelectedNode.Value, out menuID);
                return menuID;
            }
        }

        private void BindManageMenuTreeByApplicationIDAndSelectNodeID(string appID, string selectNodeID)
        {
            if (appID != "")
            {
                int selectAppId = int.Parse(appID);
                SystemApplication selectApp = systemApplicationServiceInstance.FindById(selectAppId);
                if (selectApp != null)
                {
                    this.tvMenus.Nodes.Clear();
                    this.tvMenus.Nodes.Add(systemMenuServiceInstance.GenerateManageWebTreeNodeByApplication(selectApp, this.ResolveUrl("~/images/Menu/control_panel.gif"), this.ResolveUrl("~/images/Menu/folders.gif"), this.ResolveUrl("~/images/Menu/folder.gif")));
                }
                TreeNode selectNode;
                if(selectNodeID=="0")
                {
                    selectNode = this.tvMenus.Nodes[0];
                    selectNode.Select();
                }
                else
                {
                    selectNode = TreeViewHelper.GetWebTreeViewNodeByValue(this.tvMenus, selectNodeID.ToString());
                    selectNode.Select();
                }
                SelectNode(selectNode);
                this.tvMenus.ExpandAll();
            }
        }

        protected void ddlSelectApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindManageMenuTreeByApplicationIDAndSelectNodeID(this.ddlSelectApplication.SelectedValue, "0");
        }



        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            try
            {
                int menuID = CurrentSelectMenuID;
                SystemMenu systemMenu = systemMenuServiceInstance.FindById(menuID);
                if (systemMenu != null)
                {
                    systemMenu.MenuName = this.txtMenuName.Text.Trim();
                    systemMenu.MenuDescription = this.txtMenuDescription.Value.Trim();
                    systemMenu.MenuUrl = this.txtMenuUrl.Text.Trim();
                    systemMenuServiceInstance.Update(systemMenu);
                    if (systemMenu.ParentMenuID == null)
                        BindManageMenuTreeByApplicationIDAndSelectNodeID(this.ddlSelectApplication.SelectedValue, "0");
                    else
                        BindManageMenuTreeByApplicationIDAndSelectNodeID(this.ddlSelectApplication.SelectedValue, menuID.ToString());
                    this.lblMessage.Text = "更新菜单成功！";
                }
                else
                {
                    BindManageMenuTreeByApplicationIDAndSelectNodeID(this.ddlSelectApplication.SelectedValue, "0");
                }

            }
            catch (Exception ex)
            {
                this.lblMessage.Text = "系统错误：" + ex.Message;
                this.btnSave.Disabled = true;
            }
        }

        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
            try
            {
                int menuID = CurrentSelectMenuID;
                int parentMenuID = 0;
                SystemMenu systemMenu = systemMenuServiceInstance.FindById(menuID);
                if (systemMenu != null)
                {
                    if (systemMenu.ParentMenuID != null)
                        parentMenuID = systemMenu.ParentMenuID.MenuID;
                    systemMenuServiceInstance.Delete(systemMenu);
                    BindManageMenuTreeByApplicationIDAndSelectNodeID(this.ddlSelectApplication.SelectedValue, parentMenuID.ToString());
                    this.lblMessage.Text = "删除菜单成功！";
                }
                else
                {
                    BindManageMenuTreeByApplicationIDAndSelectNodeID(this.ddlSelectApplication.SelectedValue, "0");
                }
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = "系统错误：" + ex.Message;
                this.btnSave.Disabled = true;
            }
        }

        protected void btnUp_ServerClick(object sender, EventArgs e)
        {
            try
            {
                int menuID = CurrentSelectMenuID;
                if (menuID > 0)
                {
                    SystemMenu systemMenu = systemMenuServiceInstance.FindById(menuID);
                    systemMenuServiceInstance.MovePostion(systemMenu, 1);
                    BindManageMenuTreeByApplicationIDAndSelectNodeID(this.ddlSelectApplication.SelectedValue, menuID.ToString());
                    this.lblMessage.Text = "向上移动菜单成功！";
                }
                else
                {
                    BindManageMenuTreeByApplicationIDAndSelectNodeID(this.ddlSelectApplication.SelectedValue, "0");
                }
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = "系统错误：" + ex.Message;
                this.btnSave.Disabled = true;
            }
        }

        protected void btnDown_ServerClick(object sender, EventArgs e)
        {
            try
            {
                int menuID = CurrentSelectMenuID;
                if (menuID > 0)
                {
                    SystemMenu systemMenu = systemMenuServiceInstance.FindById(menuID);
                    systemMenuServiceInstance.MovePostion(systemMenu, -1);
                    BindManageMenuTreeByApplicationIDAndSelectNodeID(this.ddlSelectApplication.SelectedValue, menuID.ToString());
                    this.lblMessage.Text = "向上移动菜单成功！";
                }
                else
                {
                    BindManageMenuTreeByApplicationIDAndSelectNodeID(this.ddlSelectApplication.SelectedValue, "0");
                }
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = "系统错误：" + ex.Message;
                this.btnSave.Disabled = true;
            }
        }

        protected void btnReSorted_ServerClick(object sender, EventArgs e)
        {
            try
            {
                int menuID = CurrentSelectMenuID;
                if (menuID > 0)
                {
                    SystemMenu systemMenu = systemMenuServiceInstance.FindById(menuID);
                    systemMenuServiceInstance.ReSortedSubmenu(systemMenu);
                    BindManageMenuTreeByApplicationIDAndSelectNodeID(this.ddlSelectApplication.SelectedValue, menuID.ToString());
                }
                else
                {
                    systemMenuServiceInstance.ReSortedSubmenu(null);
                    BindManageMenuTreeByApplicationIDAndSelectNodeID(this.ddlSelectApplication.SelectedValue, "0");
                }

                this.lblMessage.Text = "菜单重新排序成功！";
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = "系统错误：" + ex.Message;
                this.btnSave.Disabled = true;
            }
        }

        private void SetButtonProperty(SuperWebTreeNode node)
        {
            this.btnAddSubMenu.Visible = node.CanAddSubItem;
            this.btnAddSubMenu.Disabled = !node.AllowAddSubItem;
            this.btnSave.Visible = node.CanModify;
            this.btnSave.Disabled = !node.AllowModify;
            this.btnDelete.Visible = node.CanDelete;
            this.btnDelete.Disabled = !node.AllowDelete;
            this.btnUp.Visible = node.CanMoveUp;
            this.btnUp.Disabled = !node.AllowMoveUp;
            this.btnDown.Visible = node.CanMoveDown;
            this.btnDown.Disabled = !node.AllowMoveDown;
            this.btnReSorted.Visible = node.CanResortSub;
            this.btnReSorted.Disabled = !node.AllowResortSub;
            InputControlHelper.ClearInputButton(btnAddSubMenu,new string[] {"onclick", "Title"});
            InputControlHelper.ClearInputButton(btnSave, new string[] { "Title" });
            InputControlHelper.ClearInputButton(btnDelete, new string[] { "Title" });
            InputControlHelper.ClearInputButton(btnUp, new string[] { "Title" });
            InputControlHelper.ClearInputButton(btnDown, new string[] { "Title" });
            InputControlHelper.ClearInputButton(btnReSorted, new string[] { "Title" });


            if (node.CanDelete && !node.AllowDelete)
            {
                this.btnDelete.Attributes["Title"] = "请先删除下面的子菜单。";
            }
            
            if (node.CanMoveUp && !node.AllowMoveUp)
            {
                this.btnUp.Attributes["Title"] = "该菜单是第一个，无法上移。";
            }

            if (node.CanMoveDown && !node.AllowMoveDown)
            {
                this.btnDown.Attributes["Title"] = "该菜单是最后一个，无法下移。";
            }
        }

        private void SelectNode(TreeNode selectNode)
        {
            SuperWebTreeNode node = (SuperWebTreeNode)selectNode;
            SetButtonProperty(node);

            this.txtMenuName.ReadOnly = false;
            this.txtMenuDescription.Attributes.Remove("readOnly");
            this.txtMenuUrl.ReadOnly = false;

            int menuID = CurrentSelectMenuID;

            switch (selectNode.Depth)
            {
                case 0:
                    this.txtMenuName.ReadOnly = true;
                    this.txtMenuDescription.Attributes["readOnly"] = "true";
                    this.txtMenuUrl.ReadOnly = true;

                    this.lblParentMenuName.Text = "无";
                    this.txtMenuName.Text = "";
                    this.txtMenuDescription.Value = "";
                    this.txtMenuUrl.Text = "";

                    this.btnAddSubMenu.Attributes["onclick"] =
"OpenDialogHelper.openModalDlg(\"AddPage.aspx?mode=new&appid=" + this.ddlSelectApplication.SelectedValue + "&cRebtn=" + this.btnReset.ClientID + "&pid=0" + "\", window, 420, 280);";

                    break;
                case 1:
                    this.txtMenuUrl.ReadOnly = true;
                    this.txtMenuUrl.Text = "";
                    try
                    {
                        SystemMenu systemMenu = systemMenuServiceInstance.FindById(menuID);
                        this.lblParentMenuName.Text = "根菜单";
                        this.txtMenuName.Text = systemMenu.MenuName;
                        this.txtMenuDescription.Value = systemMenu.MenuDescription;;
                        this.btnAddSubMenu.Attributes["onclick"] =
        "OpenDialogHelper.openModalDlg(\"AddPage.aspx?mode=new&appid=" + this.ddlSelectApplication.SelectedValue + "&pid=" + menuID.ToString() + "&cRebtn=" + this.btnReset.ClientID + "\", window, 420, 280);";
                    }
                    catch (Exception ex)
                    {
                        this.lblMessage.Text = "系统错误：" + ex.Message;
                        this.btnSave.Disabled = true;
                    }

                    break;
                case 2:
                    try
                    {
                        SystemMenu systemMenu = systemMenuServiceInstance.FindById(menuID);
                        this.lblParentMenuName.Text = systemMenu.ParentMenuID.MenuName;
                        this.txtMenuName.Text = systemMenu.MenuName;
                        this.txtMenuDescription.Value = systemMenu.MenuDescription;
                        this.txtMenuUrl.Text = systemMenu.MenuUrl;
                    }
                    catch (Exception ex)
                    {
                        this.lblMessage.Text = "系统错误：" + ex.Message;
                        this.btnSave.Disabled = true;
                    }
                    break;
                default:
                    break;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            string selectNodeID = CurrentSelectMenuID.ToString();
            BindManageMenuTreeByApplicationIDAndSelectNodeID(this.ddlSelectApplication.SelectedValue, selectNodeID);
        }

        protected void tvMenus_SelectedNodeChanged(object sender, EventArgs e)
        {
            string selectNodeID = CurrentSelectMenuID.ToString();
            BindManageMenuTreeByApplicationIDAndSelectNodeID(this.ddlSelectApplication.SelectedValue, selectNodeID);
        }
    }
}
