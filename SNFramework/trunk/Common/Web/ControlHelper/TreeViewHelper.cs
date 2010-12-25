using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace Legendigital.Framework.Common.Web.ControlHelper
{
    public static class TreeViewHelper
    {
        public static void SelectWebTreeViewNodeByValue(TreeView tv, string selectValue)
        {
            foreach (TreeNode node in tv.Nodes)
            {
                if(node.Value == selectValue)
                {
                    node.Select();
                    return;
                }
                SelectWebTreeViewNodeByValue(node, selectValue);
            }
        }
        public static TreeNode GetWebTreeViewNodeByValue(TreeView tv, string selectValue)
        {
            foreach (TreeNode node in tv.Nodes)
            {
                TreeNode selectNode = null;
                if (node.Value == selectValue)
                {
                    node.Select();
                    return node;
                }
                selectNode = GetWebTreeViewNodeByValue(node, selectValue);
                if (selectNode != null)
                    return selectNode;
            }
            return null;
        }

        public static void CheckTreeViewByValues(TreeView tv, List<string> selectValues)
        {
            foreach (TreeNode node in tv.Nodes)
            {
                CheckTreeViewNodeByValues(node, selectValues);
            }
        }

        public static void CheckTreeViewNodeByValues(TreeNode node, List<string> selectValues)
        {
            foreach (TreeNode childNode in node.ChildNodes)
            {
                childNode.Checked = selectValues.Contains(childNode.Value);
                CheckTreeViewNodeByValues(childNode, selectValues);
            }
        }

        public static void CheckTreeViewByValue(TreeView tv, string selectValue)
        {
            foreach (TreeNode node in tv.Nodes)
            {
                CheckTreeViewNodeByValues(node, selectValue);
            }
        }

        public static void CheckTreeViewNodeByValues(TreeNode node, string selectValue)
        {
            foreach (TreeNode childNode in node.ChildNodes)
            {
                childNode.Checked = (childNode.Value == selectValue);
                CheckTreeViewNodeByValues(childNode, selectValue);
            }
        }

        private static TreeNode GetWebTreeViewNodeByValue(TreeNode node, string selectValue)
        {
            foreach (TreeNode childNode in node.ChildNodes)
            {
                TreeNode selectNode = null;
                if (childNode.Value == selectValue)
                {
                    childNode.Select();
                    return childNode;
                }
                selectNode = GetWebTreeViewNodeByValue(childNode, selectValue);
                if (selectNode != null)
                    return selectNode;
            }
            return null;
        }

        public static List<int> GetTreeViewCheckValue(TreeView tv)
        {
            List<int> checkValues = new List<int>();
            foreach (TreeNode node in tv.CheckedNodes)
            {
                checkValues.Add(int.Parse(node.Value));
            }
            return checkValues;
        }


        private static void SelectWebTreeViewNodeByValue(TreeNode node, string selectValue)
        {
            foreach (TreeNode childNode in node.ChildNodes)
            {
                if (childNode.Value == selectValue)
                {
                    childNode.Select();
                    return;
                }
                SelectWebTreeViewNodeByValue(childNode, selectValue);
            }
        }
    }
}