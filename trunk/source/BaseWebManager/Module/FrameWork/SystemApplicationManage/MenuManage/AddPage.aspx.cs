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
using Powerasp.Enterprise.Core.BaseManager.Domain;
using Powerasp.Enterprise.Core.BaseManager.Service;
using Powerasp.Enterprise.Core.Web.BasePage;

namespace BaseWebManager.Module.FrameWork.SystemApplicationManage.MenuManage
{
    public partial class AddPage : BaseSecurityPage
    {
        private SystemMenuService systemMenuServiceInstance;

        public SystemMenuService SystemMenuServiceInstance
        {
            set { systemMenuServiceInstance = value; }
        }

        private SystemApplicationService systemApplicationServiceInstance;

        public SystemApplicationService SystemApplicationServiceInstance
        {
            set { systemApplicationServiceInstance = value; }
        }



        protected void Page_Load(object sender, EventArgs e)
        {

            if (this.IsPostBack)
                return;

            try
            {
                int parentMenuID = -1;
                int.TryParse(this.Request.QueryString["pid"], out parentMenuID);

                int applicationID = -1;
                int.TryParse(this.Request.QueryString["appid"], out applicationID);

                SystemApplication application = systemApplicationServiceInstance.FindById(applicationID);

                if (parentMenuID == 0)
                {
                    this.lblParentMenuName.Text = application.SystemApplicationName;
                    this.txtMenuUrl.ReadOnly = true;
                    return;
                }
                else if (parentMenuID > 0)
                {
                    SystemMenu parentMenu = systemMenuServiceInstance.FindById(parentMenuID);
                    this.lblParentMenuName.Text = parentMenu.MenuName;
                    return;
                }
                else
                {
                    this.lblParentMenuName.Text = "参数错误：无法添加子菜单！";
                    this.btnSave.Enabled = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                this.lblParentMenuName.Text = "系统错误：" + ex.Message;
                this.btnSave.Enabled = false;
                return;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int parentMenuID = -1;
            int.TryParse(this.Request.QueryString["pid"], out parentMenuID);

            int applicationID = -1;
            int.TryParse(this.Request.QueryString["appid"], out applicationID);

            SystemApplication application = systemApplicationServiceInstance.FindById(applicationID);


            if (parentMenuID >= 0)
            {
                SystemMenu systemMenu = systemMenuServiceInstance.GetNewDomainInstance();
                if (parentMenuID == 0)
                    systemMenu.ParentMenuID = null;
                else
                    systemMenu.ParentMenuID = systemMenuServiceInstance.FindById(parentMenuID);
                systemMenu.MenuName = this.txtMenuName.Text.Trim();
                systemMenu.MenuDescription = this.txtMenuDescription.Value.Trim();

                systemMenu.MenuUrl = this.txtMenuUrl.Text;
                systemMenu.MenuIsSystemMenu = false;
                systemMenu.MenuIsEnable = true;

                systemMenu.ApplicationID = application;

                systemMenuServiceInstance.Create(systemMenu);

                //string showscript = "alert('添加子菜单成功！');window.dialogArguments.document.getElementById('" +
                //                    this.Request.QueryString["chid"] + "').value='" + parentMenuID +
                //                    "';window.dialogArguments.document.getElementById('" +
                //    this.Request.QueryString["cRebtn"] + "').click();window.close();";

                string showscript = "alert('添加子菜单成功！');window.dialogArguments.document.getElementById('" +
    this.Request.QueryString["cRebtn"] + "').click();window.close();";


                Anthem.Manager.AddScriptForClientSideEval(showscript);
            }
            else
            {
                Anthem.Manager.AddScriptForClientSideEval("alert('添加子菜单失败！');");
            }

        }
    }
}
