using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.Clients
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPSendClientParamsClone")]
    public partial class UCSPSendClientParamsClone : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show(int clientID)
        {
            try
            {
                SPClientWrapper spClientWrapper = SPClientWrapper.FindById(clientID);

                this.hidClientID.Text = clientID.ToString();

                winSPSendClientParamsClone.Title = string.Format("下家[{0}]复制通道参数", spClientWrapper.Name);

                this.winSPSendClientParamsClone.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

    }
}