using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using Powerasp.Enterprise.Core.Web.ControlHelper;

namespace Powerasp.Enterprise.Core.Web.UI.WebControls
{
    [ToolboxData("<{0}:TreeViewExenter runat=server></{0}:TreeViewExenter>")]
    [Designer(typeof (ControlDesigner))]
    public class TreeViewExenter : Control
    {
        private TreeView extenderTreeView = null;

        [Description("扩展的GridView控件ID")]
        [Themeable(false)]
        public string TargetTreeViewID
        {
            get { return (string) ViewState["TargetTreeViewID"]; }

            set { ViewState["TargetTreeViewID"] = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (string.IsNullOrEmpty(this.TargetTreeViewID.Trim()))
                throw new ArgumentNullException("TargetTreeViewID", "TargetGridViewID not allow null.");

            extenderTreeView = (TreeView)this.Parent.FindControl(TargetTreeViewID);

            // 注册向数组中添加成员的脚本
            if (!this.extenderTreeView.Page.ClientScript.IsStartupScriptRegistered(String.Format("yy_stv_cascadeCheckbox_{0}", this.extenderTreeView.ID)))
            {
                this.extenderTreeView.Page.ClientScript.RegisterStartupScript
                (
                    this.GetType(),
                    String.Format("yy_stv_cascadeCheckbox_{0}", this.extenderTreeView.ID),
                    String.Format("yy_stv_ccTreeView_pre.push('{0}');", UIHelper.GetChildControlPrefix(this.extenderTreeView)),
                    true
                );
            }

        }



        protected override void OnPreRender(EventArgs e)
        {
            //// 注册所需脚本
            //if (
            //    !this.Page.ClientScript.IsClientScriptIncludeRegistered(this.GetType(),
            //                                                            "TreeViewExntender_scriptLibrary"))
            //{
            //    string sc = this.Page.ClientScript.GetWebResourceUrl
            //        (
            //        this.GetType(), "Powerasp.Enterprise.Core.Web.UI.WebControls.Resources.ScriptLibrary.js"
            //        );

            //    this.Page.ClientScript.RegisterClientScriptInclude
            //        (
            //        this.GetType(),
            //        "TreeViewExntender_scriptLibrary",
            //        sc
            //        );
            //}
            base.OnPreRender(e);
        }
    }
}