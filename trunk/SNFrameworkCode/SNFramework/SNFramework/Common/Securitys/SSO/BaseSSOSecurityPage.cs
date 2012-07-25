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
        //public SystemUserWrapper CurrentLoginUser 
        //{
        //    get
        //    {
        //        if (Context.User == null)
        //        {
        //            Session[SSOProvider.Session_Key_LoginUser] = null;
        //            return null;
        //        }
        //        if (Session[SSOProvider.Session_Key_LoginUser] == null)
        //        {
        //            Session[SSOProvider.Session_Key_LoginUser] =
        //                SystemUserWrapper.GetInitalUserByLoginID(Context.User.Identity.Name);
        //        }
        //        return (SystemUserWrapper)Session[SSOProvider.Session_Key_LoginUser];
        //    }
        //    set { Session[SSOProvider.Session_Key_LoginUser] = value; }
        //}

        public BaseSSOSecurityPage CurrentSecurityPage
        {
            get
            {
                BaseSSOSecurityPage page = this.Page as BaseSSOSecurityPage;

                return page;
            }
        }

        protected SecurityMode pageSecurityMode = SecurityMode.Authentication;

        public SSOTokenInfo currentTokenInfo = null;

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



 

        /// <summary>
        /// 验证用户身份
        /// </summary>
        private void Authentication()
        {
            string ssf_Token_QueryString = Request.QueryString[SSOProvider.QUERY_STRING_NAME_SSFToken];

            object ssf_Token_Session = SSOProvider.GetSessionValue(SSOProvider.Session_Key_LoginUser);

            if (ssf_Token_Session == null && string.IsNullOrEmpty(ssf_Token_QueryString))
            {
                RedirectToLogon(LoginError.TokenWrong);
                return;
            }
 
            string string_Token = "";///看优先选用哪一个token

            if (string.IsNullOrEmpty(ssf_Token_QueryString))
            {
                string_Token = ssf_Token_Session.ToString();
            }
            else
            {
                string_Token = ssf_Token_QueryString;
            }

            SSOTokenInfo tokenInfo = SSOProvider.GetInfoFromSSFToken(string_Token, string_Token);

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

            if(ssf_Token_Session==null)
            {
                SSOProvider.SetSessionValue(SSOProvider.Session_Key_LoginUser, tokenInfo);
            }

            /////判断是否有权限访问该页
            //if (!userInfo.AccessList.ContainsValue(CurrentUrl))
            //{
            //    JumpToLoginPage(1);
            //    return;
            //}

 
            //SetValueForProperties(CurrentUserInfo, CurrentUrl);
            //////更新Token的信息
            //SSFSession.UpdateLoginInfoToSession(Session, String_Token, CurrentUserInfo);
            ////处理页面按钮权限问题
            //HidePageControl(CurrentUserInfo.AccessList, CurrentUrl);
            ////记录子系统使用日志
            //Log.LogSubSystemUseInsert(m_LoginUserInfo);
  

 

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
    }
}
