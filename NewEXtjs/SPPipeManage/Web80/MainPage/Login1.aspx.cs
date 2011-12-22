using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;
using Legendigital.Framework.Common.Utility;

namespace Legendigital.Common.Web.MainPage
{
    public partial class Login1 : BaseSecurityPage
    {
 

 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;
            SystemSettingWrapper settingWrapper = SystemSettingWrapper.GetCurrentSystemSetting();
            this.Page.Header.Title = settingWrapper.SystemName + " " + settingWrapper.SystemVersion;
            this.lblSystemName.Text = " <b>" + settingWrapper.SystemName + "</b><br/><font size='2' color='#999999' face='Verdana, Arial, Helvetica, sans-serif'>" + settingWrapper.SystemVersion + "</font>	";
            this.lblLisence.Text = settingWrapper.SystemLisence;

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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = this.txtLoginName.Text.Trim();
            string password = this.txtLoginPassword.Text.Trim();

            SystemUserWrapper userWrapper = SystemUserWrapper.GetUserByLoginID(username);

            string ip = HttpUtil.GetIP(Request);

            if (userWrapper == null)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "登录失败,用户名或者密码错误！";
                //SystemLogWrapper.AddSecurityLog(username, System.DateTime.Now, "用户名不存在", HttpUtil.GetIP(Request), HttpUtil.ParseLocation(Request), SystemLogWrapper.SecurityLogType.LoginFailed);
                return;
            }

            if (!userWrapper.IsApproved)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "登录失败,用户已失效！";
                SystemLogWrapper.AddSecurityLog(userWrapper.UserLoginID, System.DateTime.Now, "用户已失效", ip, HttpUtil.ParseLocation(ip), SystemLogWrapper.SecurityLogType.LoginFailed);
                return;
            }

            if (userWrapper.IsLockedOut)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "登录失败,用户被锁定！";
                SystemLogWrapper.AddSecurityLog(userWrapper.UserLoginID, System.DateTime.Now, "用户被锁定", ip, HttpUtil.ParseLocation(ip), SystemLogWrapper.SecurityLogType.LoginFailed);
                return;
            }


            if (Membership.ValidateUser(username, password))
            {
                FormsAuthentication.SetAuthCookie(userWrapper.UserLoginID,
                                                          false);

                CurrentLoginUser = SystemUserWrapper.GetInitalUserByLoginID(userWrapper.UserLoginID);

                SystemLogWrapper.AddSecurityLog(userWrapper.UserLoginID, System.DateTime.Now, "", ip, HttpUtil.ParseLocation(ip), SystemLogWrapper.SecurityLogType.LoginSuccessful);

                Response.Redirect(FormsAuthentication.DefaultUrl);
            }
            else
            {

                lblMessage.Visible = true;
                lblMessage.Text = "登录失败,用户名或者密码错误！";
                SystemLogWrapper.AddSecurityLog(username, System.DateTime.Now, "密码错误", ip, HttpUtil.ParseLocation(ip), SystemLogWrapper.SecurityLogType.LoginFailed);
                return;

            }

 
        }
    }
}