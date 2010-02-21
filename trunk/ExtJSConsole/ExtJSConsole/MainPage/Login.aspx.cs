using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace ExtJSConsole.MainPage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void BtnLogin_Click(object sender, AjaxEventArgs e)
        {
            string username = this.txtUserName.Text.Trim();
            string password = this.txtPassWord.Text.Trim();

            if (Membership.ValidateUser(username, password))
            {
                SystemUserWrapper user = SystemUserWrapper.GetUserByLoginID(username);

                FormsAuthentication.SetAuthCookie(user.UserLoginID,
                                                  false);

                Response.Redirect(FormsAuthentication.DefaultUrl);
            }
            else
            {
                Ext.Msg.Show(new MessageBox.Config
                                 {
                                     Title = "返回提示",
                                     Message = "用户名或密码错误,请确认!",
                                     Icon = MessageBox.Icon.ERROR,
                                     Buttons = MessageBox.Button.OK
                                 });
            }
        }

        //protected void btnLogin_Click(object sender, AjaxEventArgs e)
        //{
        //    this.Window1.Hide();

        //    string template = "<br /><b>LOGIN SUCCESS</b><br /><br />Username: {0}<br />Password: {1}";
        //    string username = this.txtUsername.Text;
        //    string password = this.txtPassword.Text;

        //    if (Membership.ValidateUser(this.txtUsername.Text.Trim(), this.txtPassword.Text.Trim()))
        //    {
        //        FormsAuthentication.SetAuthCookie(this.txtUsername.Text.Trim(),
        //                                                  false);
        //        Response.Redirect(FormsAuthentication.DefaultUrl);
        //    }



        //}
    }
}
