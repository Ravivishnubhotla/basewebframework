using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;
using Legendigital.Framework.Common.Utility;


namespace Legendigital.Common.WebApp.MainPage
{
    public partial class Login : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            //List<SystemPrivilegeWrapper> aaa = SystemPrivilegeWrapper.TestFindResouceNameAndOPName("", "");

            //Console.WriteLine(aaa.Count);

            SystemSettingWrapper settingWrapper = SystemSettingWrapper.GetCurrentSystemSetting();

            extwinLogin.Title = settingWrapper.LocaLocalizationName + " " + settingWrapper.SystemVersion;
        }

        protected void BtnLogin_Click(object sender, DirectEventArgs e)
        {

            string loginID = this.txtUserName.Text.Trim();
            string password = this.txtPassWord.Text.Trim();

            SystemUserWrapper userWrapper = SystemUserWrapper.GetUserByLoginID(loginID);

            if (userWrapper == null)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = GetLocalResourceObject("msgLoginFailedUserPasswordError").ToString();
                SystemLogWrapper.LogUserLoginFailed(loginID, HttpUtil.GetIP(this.Request), GetLocalResourceObject("msgLoginFailedUserPasswordError").ToString(),System.DateTime.Now);
                return;
            }

            if (userWrapper.IsLockedOut)
            {
                if (SystemUserWrapper.CheckUserIfDeveloperAdminOrSystemAdmin(loginID))
                {
                    SystemUserWrapper.UnlockUser(loginID);
                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = GetLocalResourceObject("msgLoginFailedUserLockError").ToString();
                    SystemLogWrapper.LogUserLoginFailed(loginID, HttpUtil.GetIP(this.Request), GetLocalResourceObject("msgLoginFailedUserPasswordError").ToString(), System.DateTime.Now);
                    return;
                }
            }


            if (!Membership.ValidateUser(loginID, password))
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = GetLocalResourceObject("msgLoginFailedUserPasswordError").ToString();
                SystemLogWrapper.LogUserLoginFailed(loginID, HttpUtil.GetIP(this.Request), GetLocalResourceObject("msgLoginFailedUserPasswordError").ToString(), System.DateTime.Now);
                return;
            }

            LoginUser(loginID);
        }


        private void LoginUser(string loginID)
        {
            SystemUserWrapper userWrapper = SystemUserWrapper.GetInitalUserByLoginID(loginID);

            ClearLoginInfo();

            FormsAuthentication.SetAuthCookie(userWrapper.UserLoginID,
                                              false);

            UserCurrentLoginId = userWrapper.UserLoginID;

            SystemLogWrapper.LogUserLoginSuccessed(userWrapper, HttpUtil.GetIP(this.Request), System.DateTime.Now);

            Response.Redirect(FormsAuthentication.DefaultUrl);
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
