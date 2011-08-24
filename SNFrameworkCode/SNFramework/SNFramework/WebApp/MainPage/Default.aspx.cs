using System;
using System.Collections.Generic;
using System.Web.Security;
using Ext.Net;
using System.Linq;
using Legendigital.Common.WebApp.AppCode;
using Legendigital.Framework.Common.BaseFramework;
using Legendigital.Framework.Common.BaseFramework.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;


namespace Legendigital.Common.WebApp.MainPage
{
    public partial class Default : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;
            

            this.Session["Ext.Net.Theme"] = Ext.Net.Theme.Default;
            this.cbTheme.SelectedItem.Value = this.ResourceManagerProxy1.Theme.ToString();
            this.lblUser.Text = string.Format("<b>{0}</b>", this.Context.User.Identity.Name.ToString());
            this.lblToday.Text = string.Format(GetLocalResourceObject("msgDateInfo").ToString(), System.DateTime.Now);

            SystemSettingWrapper settingWrapper = SystemSettingWrapper.GetCurrentSystemSetting();

            locSystemName.Text = settingWrapper.LocaLocalizationName + " " + settingWrapper.SystemVersion;
            locCopyRight.Text = settingWrapper.LocaLocalizationLisence;

            InitLeftMenu();
        }

        

        [DirectMethod]
        public string GetThemeUrl(string theme)
        {
            var temp = (Theme)Enum.Parse(typeof(Theme), theme);

            Session["Ext.Net.Theme"] = temp;

            return (temp == Ext.Net.Theme.Default) ? "Default" : this.ResolveUrl(ExtNet.ResourceManager.GetThemeUrl(temp));
        }

        private void InitLeftMenu()
        {
            List<NavMenu> navMenus = SystemMenuWrapper.GetUserAssignedNavMenuByUserLoginID(CurrentLoginUser.UserLoginID);

            foreach (NavMenu m in navMenus)
            {
                TreeNode topnode = WebUIHelper.CreateMainItem(m, LeftPanel);

                WebUIHelper.CreateSubItem(m, topnode, this);
            }
        }

 

        protected void btnExit_Click(object sender, DirectEventArgs e)
        {
            CurrentSecurityPage.ClearLoginInfo();
        }
    }
}
