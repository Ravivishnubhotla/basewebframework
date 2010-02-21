using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;

namespace Legendigital.Framework.Common.Web.ControlHelper
{
    public static class InputControlHelper
    {
        public static void ClearInputButton(HtmlInputButton btn,string[] clearAtrr)
        {
            foreach (string s in clearAtrr)
            {
                btn.Attributes.Remove(s);
            }
        }

        //public static void SetTreeViewAddSubItemButton(HtmlInputButton addSubItemButton, SuperWebTreeNode currentNode, string btnResetID,string moreUrlParams,string addUrl)
        //{
        //    addSubItemButton.Visible = currentNode.CanAddSubItem;
        //    addSubItemButton.Disabled = !currentNode.AllowAddSubItem;
        //    InputControlHelper.ClearInputButton(addSubItemButton, new string[] { "onclick", "title" });
        //    string urlAddSubItem =
        //        string.Format("OpenDialogHelper.openModalDlg(\"{0}?pid={1}&cRebtn={2}{3}\", window, 420, 280);", addUrl, currentNode.Value, btnResetID, moreUrlParams);
        //    addSubItemButton.Attributes["onclick"] = urlAddSubItem;
        //    addSubItemButton.Attributes["title"] = "";
        //}
    }
}