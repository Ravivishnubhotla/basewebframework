using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Powerasp.Enterprise.Core.BaseManager.Domain;
using Powerasp.Enterprise.Core.BaseManager.Service;
using Powerasp.Enterprise.Core.BaseManager.Web;
using Powerasp.Enterprise.Core.Web.BasePage;
using Powerasp.Enterprise.Core.Web.WebUtil;

namespace BaseWebManager.MainPage
{
    public partial class Login : BaseWebContainerPage
    {
        private SystemUserService systemUserServiceInstance;

        public SystemUserService SystemUserServiceInstance
        {
            set { systemUserServiceInstance = value; }
        }

        private SystemSettingService systemSettingServiceInstance;

        public SystemSettingService SystemSettingServiceInstance
        {
            set { systemSettingServiceInstance = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.Page.IsPostBack)
                return;
            SystemSetting systemSetting = systemSettingServiceInstance.GetCurrentSystemSetting();
            this.Page.Header.Title = systemSetting.SystemName;
            this.Page.Header.Controls.Add(this.ParseControl("<link rel='stylesheet' href='"+this.ResolveUrl("~/css/Site_Css.css")+"' type='text/css' />"));
            this.Page.Header.Controls.Add(this.ParseControl("<script language='javascript' src='" + this.ResolveUrl("~/js/checkform.js") + "/'></script>"));
            this.lblSystemName.Text = " <b>" + systemSetting.SystemName + "</b><br/><font size='2' color='#999999' face='Verdana, Arial, Helvetica, sans-serif'>" + systemSetting.SystemVersion + "</font>	";
            this.lblLisence.Text = systemSetting.SystemLisence;

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SystemUser user =
                systemUserServiceInstance.GetUserByLoginIDAndPassword(this.txtLoginName.Text.Trim(), this.txtLoginPassword.Text.Trim());

            if (user != null)
            {
                systemUserServiceInstance.WebUserLoginIn(user, false, HttpContext.Current);
                WebMessageBox.ShowOperationOkMessage("登陆成功！", string.Format("欢迎您{0}，成功登入。您的IP为：{1}！", this.txtLoginName.Text.Trim(), WebHelper.GetIPAddress()), this.ResolveUrl("~/MainPage/Default.aspx"));
            }
            else
            {
                WebMessageBox.ShowOperationFailedMessage("登陆失败！", "请重新输入用户名密码", this.ResolveUrl("~/MainPage/Login.aspx"));
            }
        }



    }
}
