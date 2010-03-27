using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Web.UI;
using TreeNode=Coolite.Ext.Web.TreeNode;
using TreeNodeCollection=Coolite.Ext.Web.TreeNodeCollection;

namespace ExtJSConsole.Moudle.SystemManage.DepartmentManage
{
    public partial class SystemDepartmentListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        [AjaxMethod]
        public string GetTreeNodes()
        {
            List<TypedTreeNodeItem<SystemDepartmentWrapper>> menus = SystemDepartmentWrapper.GetAllDepartment();

            return BuildTree(menus).ToJson();
        }

        private TreeNodeCollection BuildTree(List<TypedTreeNodeItem<SystemDepartmentWrapper>> items)
        {
            TreeNodeCollection nodes = new TreeNodeCollection();

            TreeNode root = new TreeNode();
            root.Text = "所有部门";
            root.Icon = Icon.Folder;

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