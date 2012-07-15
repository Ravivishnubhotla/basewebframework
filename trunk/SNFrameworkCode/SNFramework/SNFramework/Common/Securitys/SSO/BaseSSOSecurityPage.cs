using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;

namespace Legendigital.Framework.Common.Securitys.SSO
{
    public class BaseSSOSecurityPage : System.Web.UI.Page
    {
   
        public SystemUserWrapper CurrentLoginUser
        {
            get
            {
                if (Context.User == null)
                {
                    Session[SSOProvider.Session_Key_LoginUser] = null;
                    return null;
                }
                if (Session[SSOProvider.Session_Key_LoginUser] == null)
                {
                    Session[SSOProvider.Session_Key_LoginUser] =
                        SystemUserWrapper.GetInitalUserByLoginID(Context.User.Identity.Name);
                }
                return (SystemUserWrapper)Session[SSOProvider.Session_Key_LoginUser];
            }
            set { Session[SSOProvider.Session_Key_LoginUser] = value; }
        }

        public BaseSecurityPage CurrentSecurityPage
        {
            get
            {
                BaseSecurityPage page = this.Page as BaseSecurityPage;

                return page;
            }
        }

        protected SecurityMode pageSecurityMode = SecurityMode.Authentication;
        public SystemUserWrapper currentLoginUser = null;

        //页面初始化
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (pageSecurityMode == SecurityMode.Authentication)
            {
                Authentication();
            }
        }

        /// <summary>
        /// 验证用户身份
        /// </summary>
        private void Authentication()
        {
 

        }

        private void GetLoginUserInfo()
        {
            throw new NotImplementedException();
        }

        private void RedirectToLogon(string errorMessage)
        {
            throw new NotImplementedException();
        }

        //public void RefreshUser()
        //{
        //    Session[SSOProvider.Session_Key_LoginUser] =
        //                SystemUserWrapper.GetInitalUserByLoginID(Context.User.Identity.Name);
        //}

        //public void ClearLoginInfo()
        //{
        //    //if (CurrentLoginUser!=null)
        //    //    SystemLogWrapper.LogUserLoginOutSuccessed(CurrentLoginUser, HttpUtil.GetIP(this.Request), System.DateTime.Now);
        //    Session[SSOProvider.Session_Key_LoginUser] = null;
        //    FormsAuthentication.SignOut();
        //}

        //public string[] CurrentLoginUserAssignedRole
        //{
        //    get
        //    {
        //        return SystemUserWrapper.GetRolesForUser(Context.User.Identity.Name);
        //    }
        //}

        //public void CurrentLoginUserSignOut()
        //{
        //    Session[SSOProvider.Session_Key_LoginUser] = null;
        //    FormsAuthentication.SignOut();
        //    FormsAuthentication.RedirectToLoginPage();
        //}

        //public bool CurrentUserHasPermission(string permissionCode)
        //{
        //    return SystemUserWrapper.UserHasPermission(this.CurrentLoginUser, permissionCode);
        //}

        //public bool CurrentLoginUserIsDevelopeAdmin()
        //{
        //    if (CurrentLoginUser == null)
        //        return false;
        //    if (CurrentLoginUser.UserLoginID == SystemUserWrapper.DEV_USER_ID)
        //    {
        //        return true;
        //    }

        //    return false;
        //}






        //protected override void OnLoad(EventArgs e)
        //{
        //    //处理跨域的问题
        //    Response.AddHeader("P3P", "CP=CAO PSA OUR");

        //    if (SecurityMode == Enum.SSFEnum.SecurityMode.Normal)
        //    {
        //        AUTH();
        //    }
        //    else
        //    {
        //        GetLoginUserInfo();
        //    }
        //    base.OnLoad(e);
        //}
    }
}
