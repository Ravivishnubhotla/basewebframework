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

namespace BaseWebManager.MainPage
{
    public partial class Left : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;
            BindMenu();
        }


        /// <summary>
        /// 绑定主菜单
        /// </summary>
        private void BindMenu()
        {
            List<SystemMenu> mainList = new List<SystemMenu>();
            mainList.Add(new SystemMenu(1000, "系统应用", "#", "", true));
            mainList.Add(new SystemMenu(2000, "系统维护", "#", "", true));
            mainList.Add(new SystemMenu(3, "主菜单3", "#", "", true));
            mainList.Add(new SystemMenu(4, "主菜单4", "#", "", true));
            LeftMenu.DataSource = mainList;
            LeftMenu.DataBind();
        }

        private List<SystemMenu> GetMainList(SystemMenu mainMenu)
        {
            List<SystemMenu> subList;
            switch(mainMenu.MenuID)
            {
                case 1000:
                    subList = new List<SystemMenu>();
                    subList.Add(new SystemMenu(10000, "系统应用管理", this.ResolveUrl("~/Module/FrameWork/SystemApplicationManage/ApplicationManage/ListPage.aspx"), "", true));
                    subList.Add(new SystemMenu(10000, "系统角色管理", this.ResolveUrl("~/Module/FrameWork/SystemApplicationManage/RoleManage/ListPage.aspx"), "", true)); 
                    subList.Add(new SystemMenu(10000, "系统菜单管理", this.ResolveUrl("~/Module/FrameWork/SystemApplicationManage/MenuManage/ListPage.aspx"), "", true));
                    subList.Add(new SystemMenu(10000, "系统字典管理", this.ResolveUrl("~/Module/FrameWork/SystemApplicationManage/DictionaryManage/ListPage.aspx"), "", true));
                    subList.Add(new SystemMenu(10000, "系统事件查看", this.ResolveUrl("~/Module/FrameWork/SystemApplicationManage/LogEventView/ListPage.aspx"), "", true));
                    subList.Add(new SystemMenu(10000, "系统用户管理", this.ResolveUrl("~/Module/FrameWork/SystemApplicationManage/DictionaryManage/WebForm1.aspx"), "", true));
                    subList.Add(new SystemMenu(10000, "系统部门管理", this.ResolveUrl("~/Module/FrameWork/SystemApplicationManage/DepartmentManage/ListPage.aspx"), "", true));
                    subList.Add(new SystemMenu(10000, "系统用户组管理", this.ResolveUrl("~/Module/FrameWork/SystemApplicationManage/UserGroupManage/ListPage.aspx"), "", true));
                    subList.Add(new SystemMenu(10000, "短消息中心", this.ResolveUrl("~/Module/FrameWork/SystemApplicationManage/ShortMessageManage/ListPage.aspx"), "", true));   
                    break;
                case 2000:
                    subList = new List<SystemMenu>();
                    subList.Add(new SystemMenu(10000, "测试数据", this.ResolveUrl("~/Module/FrameWork/SystemApplicationManage/ApplicationManage/WebForm1.aspx"), "", true));
                    break;
                default:
                    subList = new List<SystemMenu>();
                    subList.Add(new SystemMenu(10000, "测试数据", this.ResolveUrl("#"), "", true));
                    break;
            }


            return subList;
        }


        protected void LeftMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            SystemMenu mainMenu= (SystemMenu)e.Item.DataItem;
            Repeater LeftSubID = (Repeater)e.Item.FindControl("LeftMenu_Sub");
            LeftSubID.DataSource = GetMainList(mainMenu);
            LeftSubID.DataBind();
        }
    }
}
