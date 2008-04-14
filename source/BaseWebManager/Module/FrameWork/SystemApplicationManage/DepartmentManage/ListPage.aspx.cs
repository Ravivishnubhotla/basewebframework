using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Powerasp.Enterprise.Core.BaseManager.Service;
using Powerasp.Enterprise.Core.Web.BasePage;

namespace BaseWebManager.Module.FrameWork.SystemApplicationManage.DepartmentManage
{
    public partial class ListPage : BaseSecurityPage
    {
        private SystemDepartmentService systemDepartmentServiceInstance;

        public SystemDepartmentService SystemDepartmentServiceInstance
        {
            set { systemDepartmentServiceInstance = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            BindManageDepartmentTreeBySelectNodeID("0");
        }

        private void BindManageDepartmentTreeBySelectNodeID(string selectNodeID)
        {

            this.tvDepartments.Nodes.Clear();

            this.tvDepartments.Nodes.Add(
                systemDepartmentServiceInstance.GenerateManageWebTreeNodeByParentDepartment(
                    this.ResolveUrl("~/images/ICON/depRoot.ico"), this.ResolveUrl("~/images/ICON/depItem.ico"),0));

            //TreeNode selectNode;
            //if (selectNodeID == "0")
            //{
            //    selectNode = this.tvMenus.Nodes[0];
            //    selectNode.Select();
            //}
            //else
            //{
            //    selectNode = TreeViewHelper.GetWebTreeViewNodeByValue(this.tvMenus, selectNodeID.ToString());
            //    selectNode.Select();
            //}
            //SelectNode(selectNode);
            this.tvDepartments.Nodes[0].Select();
            this.tvDepartments.ExpandAll();
        }

        protected void tvDepartments_SelectedNodeChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {

        }

        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {

        }

        protected void btnUp_ServerClick(object sender, EventArgs e)
        {

        }

        protected void btnDown_ServerClick(object sender, EventArgs e)
        {

        }

        protected void btnReSorted_ServerClick(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}
