using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;

namespace Legendigital.Common.WebApp.MainPage
{
    public partial class Login : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(X.IsAjaxRequest)
                return;

            SystemSettingWrapper settingWrapper = SystemSettingWrapper.GetCurrentSystemSetting();

            extwinLogin.Title = settingWrapper.SystemName + " " + settingWrapper.SystemVersion;
        }

        protected void BtnLogin_Click(object sender, DirectEventArgs e)
        {

            string username = this.txtUserName.Text.Trim();
            string password = this.txtPassWord.Text.Trim();

            SystemUserWrapper userWrapper = SystemUserWrapper.GetUserByLoginID(username);

            if (userWrapper == null)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "登录失败,用户名或者密码错误！";
                return;
            }


            if (Membership.ValidateUser(username, password))
            {
                FormsAuthentication.SetAuthCookie(userWrapper.UserLoginID,
                                                          false);

                CurrentLoginUser = SystemUserWrapper.GetInitalUserByLoginID(userWrapper.UserLoginID); ;

                Response.Redirect(FormsAuthentication.DefaultUrl);
            }
            else
            {

                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "登录失败,用户名或者密码错误！";
                return;

            }
        }

        protected string UserCurrentLoginId
        {
            get
            {

                HttpCookie Cookie = Request.Cookies["CurrentLoginId"];

                if (Cookie != null)
                {
                    return Cookie.Value;
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                if (Response.Cookies["CurrentLoginId"] != null)
                {
                    HttpCookie cookie = Response.Cookies["CurrentLoginId"];
                    cookie.Value = value;
                    cookie.Expires = DateTime.Now.AddDays(180);
                }
                else
                {
                    HttpCookie cookie = new HttpCookie("CurrentLoginId");
                    cookie.Value = value;
                    cookie.Expires = DateTime.Now.AddDays(180);

                }
            }
        }
    
    }
}
