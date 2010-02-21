using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using TreeNodeCollection=Coolite.Ext.Web.TreeNodeCollection;

namespace ExtJSConsole.Moudle.SystemManage.MenuManage
{
    public partial class SystemMenuListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            List<SystemApplicationWrapper> systemApplicationWrappers = SystemApplicationWrapper.FindAll();

            storeSystemApplication.DataSource = systemApplicationWrappers;

            storeSystemApplication.DataBind();

            if (systemApplicationWrappers.Count>0)
            {
                cbApplication.SelectedIndex = 0;

                List<NavMenu> menus = SystemMenuWrapper.GetNavMenuByApplication(systemApplicationWrappers[0]);

                TreeNodeCollection treeNodeCollection = new TreeNodeCollection();

            }






        }

        protected void storeSystemApplication_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            storeSystemApplication.DataSource = SystemApplicationWrapper.FindAll();

            storeSystemApplication.DataBind();

        }


        [AjaxMethod]
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


        private TreeNodeCollection BuildTree(List<NavMenu> menus,string rootName)
        {
            TreeNodeCollection nodes = new TreeNodeCollection();

            Coolite.Ext.Web.TreeNode root = new Coolite.Ext.Web.TreeNode();
            root.Text = rootName;
            root.Icon = Icon.Folder;
            nodes.Add(root);

            if (menus == null || menus.Count ==0)
                return nodes;

            return nodes;
        }



    }
}
