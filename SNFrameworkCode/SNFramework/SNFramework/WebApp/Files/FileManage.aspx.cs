using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using Legendigital.Framework.Common.BaseFramework;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using TreeNode = Ext.Net.TreeNode;
using TreeNodeCollection = Ext.Net.TreeNodeCollection;

namespace Legendigital.Common.WebApp.Files
{
    public partial class FileManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;


        }

        [DirectMethod]
        public string GetTreeNodes(string rootPath)
        {
            if (!string.IsNullOrEmpty(rootPath))
            {
                string root = "~/Files" + rootPath;

                return BuildDirectorysTree(root).ToJson();
            }

            return "";
        }

        private TreeNodeCollection BuildDirectorysTree(string rootNavPath)
        {
            TreeNodeCollection nodes = new TreeNodeCollection();

            TreeNode root = new TreeNode();
            root.Text = rootNavPath;
            root.Icon = Icon.Folder;

            nodes.Add(root);

            string dirNav = this.Server.MapPath(rootNavPath);

            string[] dirs = Directory.GetDirectories(dirNav);

            for (int i = 0; i < dirs.Length; i++)
            {
                DirectoryInfo directory = new DirectoryInfo(dirs[i]);
                TreeNode mainNode = new TreeNode();
                mainNode.Text = directory.Name;
                mainNode.Leaf = false;
                mainNode.NodeID = "Node"+(dirs[i]).GetHashCode().ToString();
                mainNode.Icon = Icon.Folder;
                GenerateSubTreeNode(mainNode, dirs[i]);
                root.Nodes.Add(mainNode);              
            }

            return nodes;
        }

        private void GenerateSubTreeNode(TreeNode mainNode, string subPath)
        {
            string[] dirs = Directory.GetDirectories(subPath);

            for (int i = 0; i < dirs.Length; i++)
            {
                DirectoryInfo directory = new DirectoryInfo(dirs[i]);
                TreeNode subNode = new TreeNode();
                subNode.Text = directory.Name;
                subNode.Leaf = false;
                subNode.NodeID = "Node" + (subPath + dirs[i]).GetHashCode().ToString();
                subNode.Icon = Icon.Folder;
                GenerateSubTreeNode(subNode, dirs[i]);
                mainNode.Nodes.Add(subNode);
            }
        }

        protected void storeFiles_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            string[] files = System.IO.Directory.GetFiles(@"D:\TDDownload");

            List<object> data = new List<object>(files.Length);


            foreach (string fileName in files)
            {
                System.IO.FileInfo file = new System.IO.FileInfo(fileName);
                data.Add(new
                {
                    name = file.Name,
                    size = file.Length,
                    lastmod = file.LastAccessTime
                });
            }
 
            storeFiles.DataSource = data;
            storeFiles.DataBind();
        }
    }
}