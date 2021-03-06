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


namespace Powerasp.Enterprise.Core.BaseManager.BaseDataUIPage.AddFunction
{
	[WebDataModule("角色权限分配")]
    public class SystemPrivilegeInRolesAddUIPage : BaseDataAddPage<SystemPrivilegeInRoles>
    {
        protected SystemPrivilegeInRolesService systemPrivilegeInRolesServiceInstance;

        public SystemPrivilegeInRolesService SystemPrivilegeInRolesServiceInstance
        {
            set { systemPrivilegeInRolesServiceInstance = value; }
        }
        protected override void SaveData(SystemPrivilegeInRoles obj)
        {
            systemPrivilegeInRolesServiceInstance.Create(obj);
        }
    }
}



