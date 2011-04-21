using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.RoleManage
{
    public partial class SystemRoleAssignedMenu : System.Web.UI.Page
    {
        public int RoleID
        {
            get
            {
                if (this.Request.QueryString["RoleID"] == null)
                {
                    return 0;
                }
                return Convert.ToInt32(this.Request.QueryString["RoleID"]);
            }
        }

        [DirectMethod]
        public string GetMenuById(int aid)
        {
            try
            {
                Ext.Net.TreeNodeCollection collect = new Ext.Net.TreeNodeCollection();
                Ext.Net.TreeNode root = InitRoot();
                List<SystemMenuWrapper> menus = SystemMenuWrapper.GetSystemMenusByApplication(aid);
                foreach (SystemMenuWrapper menu in menus)
                {
                    SystemMenuWrapper pMenu = menu.ParentMenuID;
                    if (pMenu == null)
                    {
                        LinqTree(menus, root, 0);
                        break;
                    }
                }

                collect.Add(root);
                ResourceManager.AjaxSuccess = true;
                return collect.ToJson();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(ex.Message);
                return "";
            }
        }


        private void LinqTree(List<SystemMenuWrapper> list, Ext.Net.TreeNode tnd, int mid)
        {
            if (list == null)
            {
                list = SystemMenuWrapper.FindAll();
            }
            IEnumerable<SystemMenuWrapper> result = null;
            if (mid == 0)
            {
                result = list.Where(menu => menu.ParentMenuID == null);
            }
            else
            {
                result = list.Where(delegate(SystemMenuWrapper menu)
                {
                    if (menu.ParentMenuID == null)
                    {
                        return false;
                    }
                    else
                    {
                        if (menu.ParentMenuID.MenuID == mid)
                            return true;
                        else
                            return false;
                    }
                });
            }
            List<string> menuString = SystemMenuWrapper.GetRoleAssignedMenuIDs(SystemRoleWrapper.FindById(RoleID));
            foreach (SystemMenuWrapper m in result)
            {
                Ext.Net.TreeNode tn = new Ext.Net.TreeNode();
                tn.Qtip = m.MenuID.ToString(); ;
                tn.Text = m.MenuName;

                if (menuString.Count > 0)
                {
                    tn.Checked = (menuString.Exists(id => id.ToString() == tn.Qtip)) ? ThreeStateBool.True : ThreeStateBool.False;
                }
                else
                {
                    tn.Checked = ThreeStateBool.False;
                }
                tnd.Nodes.Add(tn);

                if (list.Exists(delegate(SystemMenuWrapper menu)
                {
                    if (menu.ParentMenuID == null)
                    {
                        return false;
                    }
                    else
                    {
                        if (menu.ParentMenuID.MenuID == m.MenuID)
                            return true;
                        else
                            return false;
                    }
                }))
                {
                    LinqTree(list, tn, m.MenuID);
                }
            }
        }



        private Ext.Net.TreeNode InitRoot()
        {
            Ext.Net.TreeNode root = new Ext.Net.TreeNode();
            root.Draggable = false;
            root.Expanded = true;
            root.Text = "System Menu";
            root.Qtip = "Menu";
            TreePanel1.Root.Add(root);
            return root;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;
            InitRoot();
        }

        [DirectMethod]
        public void btnSaveRole(int app_id, string menu_ids)
        {
            try
            {
                int role_id = RoleID;
                SystemRoleWrapper obj = SystemRoleWrapper.FindById(role_id);
                SystemRoleWrapper.PatchAssignRoleMenusInApplication(obj, app_id, menu_ids.Split(','));
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(this.GetGlobalResourceObject("GlobalResource", "msgServerErrorMsg").ToString(), ex.Message);
            }
        }


        protected void storeSystemApplication_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            List<SystemApplicationWrapper> apps = new List<SystemApplicationWrapper>();

            if (RoleID != 0)
            {
                SystemRoleWrapper role = SystemRoleWrapper.FindById(RoleID);
                apps = SystemRoleWrapper.GetRoleAssignedApplications(role);
            }

            storeSystemApplication.DataSource = apps;
            storeSystemApplication.DataBind();

        }
    }

}
