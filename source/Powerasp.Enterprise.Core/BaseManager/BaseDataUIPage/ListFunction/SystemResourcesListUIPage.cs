﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Powerasp.Enterprise.Core.BaseManager.Domain;
using Powerasp.Enterprise.Core.BaseManager.Service;
using Powerasp.Enterprise.Core.Web.BasePage;
using Powerasp.Enterprise.Core.Attribute;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDataUIPage.ListFunction
{
	[WebDataModule("系统资源")]
    public class SystemResourcesListUIPage : BaseDataListPage<SystemResources>
    {
        protected SystemResourcesService systemResourcesServiceInstance;

        public SystemResourcesService SystemResourcesServiceInstance
        {
            set { systemResourcesServiceInstance = value; }
        }

        protected override SystemResources LoadDataByID(int id)
        {
            return systemResourcesServiceInstance.FindById(id);
        }

        protected override void DeleteDataByID(int id)
        {
            systemResourcesServiceInstance.DeleteByID(id);
        }

        protected override int GetDomainID(SystemResources obj)
        {
            return obj.ResourcesID;
        }
    }
}



