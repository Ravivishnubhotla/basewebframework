using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Powerasp.Enterprise.Core.BaseManager.Domain;
using Powerasp.Enterprise.Core.BaseManager.Service;
using Powerasp.Enterprise.Core.Web.BasePage;

namespace BaseWebManager.MainPage
{
    public partial class Default : BaseSecurityPage
    {

        private SystemUserService systemUserServiceInstance;

        public SystemUserService SystemUserServiceInstance
        {
            set { systemUserServiceInstance = value; }
        }

        private SystemSettingService systemSettingServiceInstance;

        public SystemSettingService SystemSettingServiceInstance
        {
            set { systemSettingServiceInstance = value; }
        }

        public int MenuStyle = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;
            SystemSetting systemSetting = systemSettingServiceInstance.GetCurrentSystemSetting();
            this.MenuStyle = 0;
            this.lblLoginMessage.Text = "<b>" + systemSetting.SystemName + "</b><font size='2' color='#999999' face='Verdana, Arial, Helvetica, sans-serif'>版本" + systemSetting.SystemVersion + "<br /></font>";
            if(this.CurrentLoginUser!=null)
            {
                this.lblLoginMessage.Text += "当前登录用户：" + this.CurrentLoginUser.UserName;
                if(this.CurrentLoginUser.DepartmentID!=null)
                    this.lblLoginMessage.Text += "，所属部门：" + this.CurrentLoginUser.DepartmentID.DepartmentNameCn + "。";
                List<SystemRole> roles =
                    systemUserServiceInstance.GetUserAssignedRoleByUserLoginID(this.CurrentLoginUser.UserLoginID);
                if (roles.Count>0)
                {
                    this.lblLoginMessage.ToolTip = "当前用户分配角色：";
                    foreach (SystemRole role in roles)
                    {
                        this.lblLoginMessage.ToolTip += role.RoleName+",";
                    }
                }


            }

            this.lblLisence.Text = systemSetting.SystemLisence;
        }



        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            systemUserServiceInstance.WebUserLoginOut(HttpContext.Current);
        }
    }
}
