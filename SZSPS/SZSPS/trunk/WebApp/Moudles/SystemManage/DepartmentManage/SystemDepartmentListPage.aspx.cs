using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;
using Legendigital.Framework.Common.Web.UI;
using Ext.Net;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.DepartmentManage
{
    public partial class SystemDepartmentListPage : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }



        [DirectMethod]
        public void DeleteData(string id)
        {

            try
            {
                int menuID = int.Parse(id);

                SystemDepartmentWrapper.DeleteByID(menuID);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception e)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(e.Message);
                return;
            }

        }


        [DirectMethod]
        public string GetTreeNodes()
        {
            List<TypedTreeNodeItem<SystemDepartmentWrapper>> menus = SystemDepartmentWrapper.GetAllDepartment();

            return BuildTree(menus).ToJson();
        }

        private TreeNodeCollection BuildTree(List<TypedTreeNodeItem<SystemDepartmentWrapper>> items)
        {
            TreeNodeCollection nodes = new TreeNodeCollection();

            TreeNode root = new TreeNode();
            root.Text = "All Department";
            root.Icon = Icon.Group;

            nodes.Add(root);

            if (items == null || items.Count == 0)
                return nodes;

            foreach (TypedTreeNodeItem<SystemDepartmentWrapper> menu in items)
            {
                TreeNode mainNode = new TreeNode();
                mainNode.Text = menu.Name;
                mainNode.NodeID = menu.Id;

                mainNode.Icon = Icon.Group;

                mainNode.CustomAttributes.Add(new ConfigItem("ID", menu.Id, ParameterMode.Value));
                GenerateSubTreeNode(mainNode, menu);
                root.Nodes.Add(mainNode);
            }

            return nodes;
        }


        private void GenerateSubTreeNode(TreeNode mainNode, TypedTreeNodeItem<SystemDepartmentWrapper> menu)
        {
            foreach (TypedTreeNodeItem<SystemDepartmentWrapper> sMenu in menu.SubNodes)
            {
                TreeNode subNode = new TreeNode();
                subNode.Text = sMenu.Name;
                subNode.NodeID = sMenu.Id;

                subNode.Icon = Icon.Group;

                mainNode.CustomAttributes.Add(new ConfigItem("ID", menu.Id, ParameterMode.Value));
                GenerateSubTreeNode(subNode, sMenu);
                mainNode.Nodes.Add(subNode);
            }
        }
    }
}
