using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Web.UI;


namespace Legendigital.Common.WebApp.Moudles.SystemManage.PermissionManage
{
    public partial class SystemResourcesAndPriviliege : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public string GetTreeNodes()
        {
            List<TypedTreeNodeItem<SystemResourcesWrapper>> nodes = SystemResourcesWrapper.GetAllTreeNodesItems();

            return WebUIHelper.BuildTree<SystemResourcesWrapper>(nodes,"All Resources",Icon.Bricks).ToJson();
        }


    }
}