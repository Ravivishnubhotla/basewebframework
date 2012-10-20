using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using Ext.Net;
 

namespace SNFramework.BSF.Files
{
    public partial class FileManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            cPath.Value = this.Server.MapPath("~/Files/");
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


        [DirectMethod]
        public string DeleteSelectedFiles(string selectedFiles)
        {
            Dictionary<string, string>[] selectedFilesData = JSON.Deserialize<Dictionary<string, string>[]>(selectedFiles);

            string currentPath = cPath.Value.ToString();

            if (currentPath == "")
                currentPath = this.Server.MapPath("~/Files/");

            foreach (Dictionary<string, string> row in selectedFilesData)
            {
                string filename = row["Name"];

                try
                {
                    File.Delete(Path.Combine(currentPath,filename));
                }
                catch (Exception ex)
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = ex.Message;
                    return "";
                }
            }

            return "";
        }
 
        private TreeNodeCollection BuildDirectorysTree(string rootNavPath)
        {
            TreeNodeCollection nodes = new TreeNodeCollection();

            TreeNode root = new TreeNode();
            root.Text = rootNavPath;
            root.Icon = Icon.TimeGo;

            nodes.Add(root);

            string dirNav = this.Server.MapPath(rootNavPath);

            if (!dirNav.EndsWith("\\"))
            {
                dirNav += "\\";
            }

            string[] dirs = Directory.GetDirectories(dirNav);

            for (int i = 0; i < dirs.Length; i++)
            {
                DirectoryInfo directory = new DirectoryInfo(dirs[i]);
                TreeNode mainNode = new TreeNode();
                mainNode.Text = directory.Name;
                //mainNode.Leaf = false;
                mainNode.NodeID = "Node" + (dirs[i]).GetHashCode().ToString();
                mainNode.CustomAttributes.Add(new ConfigItem("Path", dirs[i] + "\\", ParameterMode.Value));
                mainNode.Icon = Icon.Folder;
                GenerateSubTreeNode(mainNode, dirs[i], dirs[i] + "\\");
                root.Nodes.Add(mainNode);
            }

            return nodes;
        }

        private void GenerateSubTreeNode(TreeNode mainNode, string subPath, string dirPath)
        {
            string[] dirs = Directory.GetDirectories(subPath);

            for (int i = 0; i < dirs.Length; i++)
            {
                DirectoryInfo directory = new DirectoryInfo(dirs[i]);
                TreeNode subNode = new TreeNode();
                subNode.Text = directory.Name;
                //subNode.Leaf = false;
                subNode.NodeID = "Node" + (subPath + dirs[i]).GetHashCode().ToString();
                subNode.CustomAttributes.Add(new ConfigItem("Path", dirs[i] + "\\", ParameterMode.Value));
                subNode.Icon = Icon.Folder;
                GenerateSubTreeNode(subNode, dirs[i], dirs[i] + "\\");
                mainNode.Nodes.Add(subNode);
            }
        }

        protected void storeFiles_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            if (cPath.Value == "")
                cPath.Value = this.Server.MapPath("~/Files/");

            string[] files = System.IO.Directory.GetFiles(cPath.Value.ToString());

            List<FileInf> data = new List<FileInf>(files.Length);

            foreach (string fileName in files)
            {
                data.Add(new FileInf(fileName, this.Server.MapPath("~/images/FileExts")));
            }

            storeFiles.DataSource = data;
            storeFiles.DataBind();
        }
    }
}