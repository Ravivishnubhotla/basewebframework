using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Legendigital.Framework.Common.BaseFramework.Web;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Masters
{
    public partial class BaseAdminMasterPage : System.Web.UI.MasterPage
    {
        public BaseSecurityPage CurrentSecurityPage
        {
            get
            {
                BaseSecurityPage page = this.Page as BaseSecurityPage;

                return page;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            this.lblUser.Text = string.Format("<b>{0}</b>,Today is {1:D}", this.CurrentSecurityPage.CurrentLoginUser.UserLoginID, System.DateTime.Now);


            List<SystemMenuWrapper> list = SystemMenuWrapper.FindAll();
            List<SystemMenuWrapper> list1 = LinqTree(list, 0);
            for (int i = 0; i < list1.Count; i++)
            {
                Toolbar2.Items.Insert(i + 1, InitButton(list, list1[i].MenuID, list1[i].MenuName));
            }
        }


        private Ext.Net.Button InitButton(List<SystemMenuWrapper> list, int bID, string bName)
        {
            Ext.Net.Button btn = new Button();
            btn.Text = bName;
            btn.Icon = Icon.Application;

            Menu menu = new Menu();
            btn.Menu.Add(menu);

            List<SystemMenuWrapper> list2 = LinqTree(list, bID);

            foreach (SystemMenuWrapper w in list2)
            {
                menu.Items.Add(InitMentItem(w.MenuName, w.MenuUrl));
            }
            return btn;
        }

        private Ext.Net.MenuItem InitMentItem(string mName, string mUrl)
        {
            MenuItem mi = new MenuItem();
            mi.Text = mName;
            mi.Icon = Icon.Application;
            mi.Href = this.ResolveUrl(mUrl);
            return mi;
        }

        private List<SystemMenuWrapper> LinqTree(List<SystemMenuWrapper> list, int mid)
        {
            List<SystemMenuWrapper> result = null;
            if (mid == 0)
            {
                result = list.FindAll(menu => menu.ParentMenuID == null);
            }
            else
            {
                result = list.FindAll(delegate(SystemMenuWrapper menu)
                {
                    if (menu.ParentMenuID == null)
                    {
                        return false;
                    }
                    else
                    {
                        return menu.ParentMenuID.MenuID == mid ? true : false;
                    }
                });
            }
            return result;
        }

        protected void btnExit_Click(object sender, DirectEventArgs e)
        {
            CurrentSecurityPage.ClearLoginInfo();
        }

    }
}
