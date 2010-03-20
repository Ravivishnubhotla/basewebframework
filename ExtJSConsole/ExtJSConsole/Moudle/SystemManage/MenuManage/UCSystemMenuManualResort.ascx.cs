using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using ListItem = Coolite.Ext.Web.ListItem;

namespace ExtJSConsole.Moudle.SystemManage.MenuManage
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSystemMenuManualResort")]
    public partial class UCSystemMenuManualResort : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show(string pmenuID)
        {
            //if (pmenuID == "")
            //    return;

            //storeSubMenu.AutoLoadParams[0].Value = pmenuID;

            winSystemMenuManualResort.Show();
        }

        protected void btnResortSystemMenu_Click(object sender, AjaxEventArgs e)
        {
            foreach (ListItem item in this.MultiSelect1.Items)
            {
                Console.WriteLine(item.Value);
            }


            winSystemMenuManualResort.Hide();
        }

        //protected void storeSubMenu_Refresh(object sender, StoreRefreshDataEventArgs e)
        //{
        //    if (e.Parameters[0].Value == "")
        //        return;


        //    List<SystemMenuWrapper> menus = SystemMenuWrapper.GetMenuByParentID(int.Parse(e.Parameters[0].Value));

        //    storeSubMenu.DataSource = SystemApplicationWrapper.FindAll();

        //    storeSubMenu.DataBind();
        //}
        protected void storeSubMenus_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            if (e.Parameters["ParentMenuID"] == "-1")
            {
                this.storeSubMenus.DataSource = new List<SystemMenuWrapper>();
                this.storeSubMenus.DataBind();
            }
            else
            {
                if(e.Parameters["ParentMenuID"] == "0")
                {
                    this.storeSubMenus.DataSource = SystemMenuWrapper.GetTopMenuByAppID(int.Parse(e.Parameters["AppID"]));
                    this.storeSubMenus.DataBind();
                }
                else
                {
                    this.storeSubMenus.DataSource = SystemMenuWrapper.GetMenuByParentID(int.Parse(e.Parameters["ParentMenuID"]));
                    this.storeSubMenus.DataBind();               
                }
            }

        }
    }
}