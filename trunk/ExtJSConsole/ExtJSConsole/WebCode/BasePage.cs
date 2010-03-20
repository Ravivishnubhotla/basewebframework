using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace ExtJSConsole.WebCode
{
    public class BasePage : Spring.Web.UI.Page
    {
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
                return (SystemUserWrapper)Session["CurrentLoginUser"];
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






    }
}
