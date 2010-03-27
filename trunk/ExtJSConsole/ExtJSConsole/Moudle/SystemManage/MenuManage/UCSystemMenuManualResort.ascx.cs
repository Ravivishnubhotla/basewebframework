using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using ListItem = Coolite.Ext.Web.ListItem;
using ScriptManager=Coolite.Ext.Web.ScriptManager;

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


        [AjaxMethod]
        public void SaveNewOrder(string ids)
        {
            try
            {
                Dictionary<string, string>[] sortItems = JSON.Deserialize<Dictionary<string, string>[]>(ids);

                List<int> sortIDs = new List<int>();

                foreach (Dictionary<string, string> row in sortItems)
                {
                    sortIDs.Add(int.Parse(row["value"].ToString()));
                }

                SystemMenuWrapper.UpdateOrder(sortIDs);

                ScriptManager.AjaxSuccess = true;
                return;
            }
            catch (Exception ex)
            {
                ScriptManager.AjaxSuccess = false;
                ScriptManager.AjaxErrorMessage = ex.Message;
                return;
            }

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