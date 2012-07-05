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

        protected PageSecurityMode securityMode = PageSecurityMode.Authentication;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (securityMode == PageSecurityMode.Authentication)
            {
                Authentication();
            }
        }

        /// <summary>
        /// 验证用户身份
        /// </summary>
        private void Authentication()
        {
            //    string conn = ConfigurationManager.AppSettings[BSFConst.BSFConn];

            //    if (string.IsNullOrEmpty(conn))
            //    {
            //        //子系统自行添加转到错误页面
            //        return;
            //    }

            //    if (Session[BSFConst.IDENTITY_KEY] == null)//没有Session则重新获得
            //    {
            //        //没有传令牌摘要将重新登录
            //        if (Request.QueryString["_BSFToken"] == null)
            //        {
            //            GoLogon("传入的令牌参数不正确或系统超时,请重新登录");
            //            return;
            //        }

            //        string tips = string.Empty;
            //        _SessionObj = Security.GetTokenInfo(conn, Request.QueryString["_BSFToken"], Request.Url.AbsoluteUri, Request.FilePath);

            //        if (_SessionObj != null)
            //        {
            //            Session.Add(BSFConst.IDENTITY_KEY, _SessionObj);
            //        }
            //        else
            //        {
            //            GoLogon("系统超时或当前账号已在其他机器登陆,请重新登录");
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        _SessionObj = Session[BSFConst.IDENTITY_KEY];

            //        if (Request.QueryString["_BSFToken"] != null && Request.QueryString["_BSFToken"].Trim() != string.Empty)
            //        {
            //            //验证Session是否有效
            //            if (Security.CheckTokenInfo(conn, Request.QueryString["_BSFToken"], Request.Url.AbsoluteUri, Request.FilePath, ref _SessionObj))
            //            {
            //                Session[BSFConst.IDENTITY_KEY] = _SessionObj;
            //            }
            //            else//未知错误重新登录
            //            {
            //                GoLogon("当前账号已在其他机器登陆,请重新登录");
            //                return;
            //            }
            //        }
            //    }

            //    _CurrentSecurityInfo = null;

            //    //检查是否有本页面权限，用于验证是否是粘贴过来的页面数据
            //    if (!Security.CheckPageRight(conn, _SessionObj, Request.QueryString["_BSFToken"], Request.FilePath, ref _CurrentSecurityInfo))
            //    {
            //        Response.Write("<script>alert('" + Request.FilePath.Trim('/') + ",请将此对话框信息通知系统管理员!');</script>");
            //        //GoLogon(Request.FilePath.Trim('/') + "当前页面没有在功能模块中绑定，无权登陆");
            //        return;
            //    }
 
        }



    }
}