using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Legendigital.Framework.Common.Environments;

namespace SNFramework.BSF.Moudles.SystemManage.ServerInfo
{
    public partial class SystemServerInfomation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServerEnvironmentInfo serverEnvironment = new ServerEnvironmentInfo(this.Context);
            this.lblServerName.Text = serverEnvironment.ServerName;
            this.lblServerIP.Text = serverEnvironment.ServerIP;
            this.lblServerDomain.Text = serverEnvironment.ServerDomain;
            this.lblServerPort.Text = serverEnvironment.ServerPort;
            this.lblServerIIS.Text = serverEnvironment.ServerIIS;
            this.lblServerOS.Text = serverEnvironment.ServerOS;
        }
    }
}