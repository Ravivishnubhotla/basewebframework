﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework;
using Legendigital.Framework.Common.BaseFramework.Bussiness;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;


namespace ExtJSConsole.Moudle.SystemManage.MenuManage
{
    public partial class SystemMenuListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            //storeSystemApplication.DataSource = SystemApplicationWrapper.FindAll();

            //storeSystemApplication.DataBind();
        }

        protected void storeSystemApplication_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            storeSystemApplication.DataSource = SystemApplicationWrapper.FindAll();

            storeSystemApplication.DataBind();
        }


       [DirectMethod]
        public void AutoMaticSortSubItems(string appid, string pmenuID)
        {
            try
            {
                int menuID = int.Parse(pmenuID);

                int iappID = int.Parse(appid);

                SystemMenuWrapper.AutoMaticSortSubItems(iappID, menuID);

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
        public void DeleteMenu(string smenuID)
        {

            try
            {
                int menuID = int.Parse(smenuID);

                SystemMenuWrapper.DeleteByID(menuID);

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
        public string GetTreeNodes(string selectNodeID)
        {
            int applicationid = int.Parse(selectNodeID);

            SystemApplicationWrapper applicationWrapper = SystemApplicationWrapper.FindById(applicationid);

            if (applicationWrapper != null)
            {
                List<NavMenu> menus = SystemMenuWrapper.GetNavMenuByApplication(applicationWrapper);

                return BuildTree(menus, applicationWrapper.SystemApplicationName).ToJson();
                ;
            }

            return "";
        }


        private TreeNodeCollection BuildTree(List<NavMenu> menus, string rootName)
        {
            TreeNodeCollection nodes = new TreeNodeCollection();

            TreeNode root = new TreeNode();
            root.Text = rootName;
            root.Icon = Icon.Folder;

            nodes.Add(root);

            if (menus == null || menus.Count == 0)
                return nodes;

            foreach (var menu in menus)
            {
                TreeNode mainNode = new TreeNode();
                mainNode.Text = menu.Name;
                mainNode.NodeID = menu.Id;
                if (menu.IsCategory)
                    mainNode.Icon = Icon.Folder;
                else
                    mainNode.Icon = Icon.ApplicationForm;
                mainNode.CustomAttributes.Add(new ConfigItem("IsGroup", "1", ParameterMode.Value));
                mainNode.CustomAttributes.Add(new ConfigItem("MenuID", menu.Id, ParameterMode.Value));
                GenerateSubTreeNode(mainNode, menu);
                root.Nodes.Add(mainNode);
            }

            return nodes;
        }

        private void GenerateSubTreeNode(TreeNode mainNode, NavMenu menu)
        {
            foreach (var sMenu in menu.SubMenus)
            {
                TreeNode subNode = new TreeNode();
                subNode.Text = sMenu.Name;
                subNode.NodeID = sMenu.Id;
                if (sMenu.IsCategory)
                    subNode.Icon = Icon.Folder;
                else
                    subNode.Icon = Icon.ApplicationForm;
                subNode.CustomAttributes.Add(new ConfigItem("IsGroup", (sMenu.IsCategory ? "1" : "0"), ParameterMode.Value));
                subNode.CustomAttributes.Add(new ConfigItem("MenuID", menu.Id, ParameterMode.Value));
                GenerateSubTreeNode(subNode, sMenu);
                mainNode.Nodes.Add(subNode);
            }
        }
    }
}
