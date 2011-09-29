using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web.Security;
using System.Web.UI;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;


namespace Legendigital.Framework.Common.BaseFramework.Web
{
    public class BaseSecurityPage : System.Web.UI.Page
    {
        protected DateTime startDateTime;

        public const string  Session_Key_LoginUser = "CurrentLoginUser";

        public SystemUserWrapper CurrentLoginUser
        {
            get
            {
                if (Context.User == null)
                {
                    Session[Session_Key_LoginUser] = null;
                    return null;
                }
                if (Session[Session_Key_LoginUser] == null)
                {
                    Session[Session_Key_LoginUser] =
                        SystemUserWrapper.GetInitalUserByLoginID(Context.User.Identity.Name);
                }
                return (SystemUserWrapper)Session[Session_Key_LoginUser];
            }
            set { Session[Session_Key_LoginUser] = value; }
        }

        public BaseSecurityPage CurrentSecurityPage
        {
            get
            {
                BaseSecurityPage page = this.Page as BaseSecurityPage;

                return page;
            }
        }


        public void  RefreshUser()
        {
            Session[Session_Key_LoginUser] =
                        SystemUserWrapper.GetInitalUserByLoginID(Context.User.Identity.Name);
        }

        public void ClearLoginInfo()
        {
            //if (CurrentLoginUser!=null)
            //    SystemLogWrapper.LogUserLoginOutSuccessed(CurrentLoginUser, HttpUtil.GetIP(this.Request), System.DateTime.Now);
            Session[Session_Key_LoginUser] = null;   
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
            Session[Session_Key_LoginUser] = null;
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        public bool CurrentUserHasPermission(string permissionCode)
        {
            return SystemUserWrapper.UserHasPermission(this.CurrentLoginUser, permissionCode);
        }


        public bool CurrentLoginUserIsDevelopeAdmin()
        {
            if(CurrentLoginUser==null)
                return false;
            if(CurrentLoginUser.UserLoginID == SystemUserWrapper.DEV_USER_ID)
            {
                return true;
            }

            return false;
        }

        protected override void InitializeCulture()
        {
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CHS");
            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("zh-CN");

            base.InitializeCulture();
        }

        //protected override void OnPreInit(System.EventArgs e)
        //{
        //    this.Page.Theme = "Default";
        //    base.OnPreInit(e);
        //}



 


    }
}