using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;

namespace PhotoAblum.Web.Admin.MainPage
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

            if (username.ToLower() == "admin" && password.ToLower() == "123456")
            {
                FormsAuthentication.SetAuthCookie(username.ToLower(), false);
                Response.Redirect("Default.aspx");
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
    }
}
