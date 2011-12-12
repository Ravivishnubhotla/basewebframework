using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Commons;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Web.UI;
using Legendigital.Framework.Common.BaseFramework.Web;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.OrginationDepartmentManage
{
    public partial class SystemOrginationDepartmentManage : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public string GetTreeNodes()
        {
            List<TypedTreeNodeItem<ITreeItemWrapper>> nodes = (new SystemOrganizationWrapper()).GetAllTreeItems();

            return WebUIHelper.BuildTree<ITreeItemWrapper>(nodes, "All Organizations", Icon.Bricks).ToJson();
        }
    }
}