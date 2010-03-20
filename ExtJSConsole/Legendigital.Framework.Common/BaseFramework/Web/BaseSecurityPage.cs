using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web.Security;
using System.Web.UI;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;


namespace Legendigital.Framework.Common.BaseFramework.Web
{
    public class BaseSecurityPage : Spring.Web.UI.Page
    {
        protected DateTime startDateTime;

        public SystemUserWrapper CurrentLoginUser
        {
            get
            {
                if (Context.User == null)
                {
                    Session["CurrentLoginUser"] = null;
                    return null;
                }
                if (Session["CurrentLoginUser"] == null)
                {
                    Session["CurrentLoginUser"] =
                        SystemUserWrapper.GetInitalUserByLoginID(Context.User.Identity.Name);
                }
                return (SystemUserWrapper) Session["CurrentLoginUser"];
            }
        }

        public void ClearLoginInfo()
        {
            Session["CurrentLoginUser"] = null;
            FormsAuthentication.SignOut();
        }

        public string[] CurrentLoginUserAssignedRole
        {
            get
            {
                return SystemUserWrapper.GetRolesForUser(Context.User.Identity.Name);
            }
        }

        public void CurrentLoginUserSignOut()
        {
            Session["CurrentLoginUser"] = null;
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        public bool CurrentUserHasPermission(string permissionCode)
        {
            return SystemUserWrapper.UserHasPermission(this.CurrentLoginUser, permissionCode);
        }

        //    protected override void InitializeCulture()
    //    {
    //        Thread.CurrentThread.CurrentCulture =
    //CultureInfo.CreateSpecificCulture("zh-CN");
    //        Thread.CurrentThread.CurrentUICulture = new
    //            CultureInfo("zh-CN");

    //        base.InitializeCulture();
    //    }

        protected override void OnPreInit(System.EventArgs e)
        {
            startDateTime = DateTime.Now;
            this.Page.Theme = "Default";
            base.OnPreInit(e);
        }

        public const string TemplatePageLoadJs = @"<script language='javascript'>
var pageLoadTime = {0};
</script>";

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            TimeSpan ts = DateTime.Now - startDateTime;
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("serverPageLoadTime"))
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "serverPageLoadTime", string.Format(TemplatePageLoadJs, ts.TotalMilliseconds));
        }


    }
}