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

namespace Powerasp.Enterprise.Core.BaseManager.BaseDataUIPage.ViewFunction
{
	[WebDataModule("权限参数")]
    public class SystemPrivilegeParameterViewUIPage : BaseDataViewPage<SystemPrivilegeParameter>
    {
        protected SystemPrivilegeParameterService systemPrivilegeParameterServiceInstance;

        public SystemPrivilegeParameterService SystemPrivilegeParameterServiceInstance
        {
            set { systemPrivilegeParameterServiceInstance = value; }
        }
		 protected override SystemPrivilegeParameter LoadDataByID(int id)
        {
            return systemPrivilegeParameterServiceInstance.FindById(id);
        }

        protected override void DeleteDataByID(int id)
        {
            systemPrivilegeParameterServiceInstance.DeleteByID(id);
        }

    }
}



