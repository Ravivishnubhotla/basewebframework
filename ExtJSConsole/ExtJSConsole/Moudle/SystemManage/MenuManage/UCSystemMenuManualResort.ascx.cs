using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;


namespace ExtJSConsole.Moudle.SystemManage.MenuManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemMenuManualResort")]
    public partial class UCSystemMenuManualResort : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(string pmenuID)
        {
            if (pmenuID == "")
                return;

            //storeSubMenus.AutoLoadParams[0].Value = pmenuID;


            winSystemMenuManualResort.Show();
        }


        [DirectMethod]
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

                ResourceManager.AjaxSuccess = true;
                return;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = ex.Message;
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
            int pid = Convert.ToInt32(hidSortPMenuID.Value);
            int aid = Convert.ToInt32(hidSortAppID.Value);

            if (pid ==  -1)
            {
                this.storeSubMenus.DataSource = new List<SystemMenuWrapper>();
                this.storeSubMenus.DataBind();
            }
            else
            {
                if (pid == 0)
                {
                    this.storeSubMenus.DataSource = SystemMenuWrapper.GetTopMenuByAppID(aid);
                    this.storeSubMenus.DataBind();
                }
                else
                {
                    this.storeSubMenus.DataSource = SystemMenuWrapper.GetMenuByParentID(pid);
                    this.storeSubMenus.DataBind();               
                }
            }

        }
    }
}