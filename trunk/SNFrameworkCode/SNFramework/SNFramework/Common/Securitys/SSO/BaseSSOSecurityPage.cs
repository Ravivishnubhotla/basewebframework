using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Xml;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;

namespace Legendigital.Framework.Common.Securitys.SSO
{
    public class BaseSSOSecurityPage : System.Web.UI.Page
    {

        public BaseSSOSecurityPage CurrentSecurityPage
        {
            get
            {
                BaseSSOSecurityPage page = this.Page as BaseSSOSecurityPage;

                return page;
            }
        }

        protected SecurityMode pageSecurityMode = SecurityMode.Authentication;

        protected SSOTokenInfo currentTokenInfo = null;

        public SSOTokenInfo CurrentTokenInfo
        {
            get
            {
                string string_Token = this.SSOToken;

                if (string.IsNullOrEmpty(string_Token))
                    return null;

                return SSOProvider.GetInfoFromSSFToken(string_Token);
            }
        }
        public SystemUserWrapper CurrentLoginUser
        {
            get
            {
                return SystemUserWrapper.FindByLoginID(CurrentTokenInfo.LoginUserID);
            }
        }


        



        //页面初始化
        protected override void OnInit(EventArgs e)
        {
            //处理跨域的问题
            Response.AddHeader("P3P", "CP=CAO PSA OUR");

            base.OnInit(e);

            if (pageSecurityMode == SecurityMode.Authentication)
            {
                Authentication();
            }
            else
            {
                GetLoginUserInfo();
            }
        }

        protected string CurrentUrl
        {
            get
            {
                string currentUrl = "";
                if (string.IsNullOrEmpty(Request.Url.Query))
                {
                    currentUrl = Request.Url.AbsoluteUri.ToLower();
                }
                else
                {
                    currentUrl = Request.Url.AbsoluteUri.Replace(Request.Url.Query, "").ToLower();
                }
                return currentUrl;
            }
        }

        public string SSOToken
        {
            get
            {
                return SSOProvider.GetSSOKeyFromPage(this);
            }
        }


        /// <summary>
        /// 验证用户身份
        /// </summary>
        private void Authentication()
        {
            string string_Token = this.SSOToken;


            if (string.IsNullOrEmpty(string_Token))
            {
                RedirectToLogon(LoginError.TokenWrong);
                return;
            }

            SSOTokenInfo tokenInfo = SSOProvider.GetInfoFromSSFToken(string_Token);

            //判断Token是否在有效期内
            if (!(tokenInfo.LoginDate.AddHours(SSOProvider.SSFTokenValidationPeriod) > DateTime.Now))
            {
                RedirectToLogon(LoginError.TokenExpired);
                return;
            }
                
            SystemUserWrapper userInfo = SystemUserWrapper.FindByLoginID(tokenInfo.LoginUserID);

            //单点登录判断
            if (tokenInfo.SSOKey != userInfo.SSOKey)
            {
                RedirectToLogon(LoginError.HasLoginInOtherPlace);
                return;
            }

            if (SSOProvider.GetSessionValue(SSOProvider.Session_Key_LoginUser) == null)
            {
                SSOProvider.SetSessionValue(SSOProvider.Session_Key_LoginUser, tokenInfo);
            }
 
        }



        private void GetLoginUserInfo()
        {
            //throw new NotImplementedException();
        }

        private void RedirectToLogon(LoginError error)
        {
 
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
        public void ClearLoginInfo()
        {
            Session[SSOProvider.Session_Key_LoginUser] = null;
            FormsAuthentication.SignOut();
        }
    }
}
