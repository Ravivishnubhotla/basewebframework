using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Web.ControlHelper;

namespace ExtJSConsole.Moudle.SystemManage.LogManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemLogAdd")]
    public partial class UCSystemLogAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSystemLogAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSystemLog_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemLogWrapper obj = new SystemLogWrapper();
                obj.LogLevel = this.txtLogLevel.Text.Trim();
                obj.LogType = this.txtLogType.Text.Trim();
                obj.LogDate = UIHelper.SaftGetDateTime(this.txtLogDate.Text.Trim()).HasValue ? UIHelper.SaftGetDateTime(this.txtLogDate.Text.Trim()).Value : System.DateTime.Now;
                obj.LogSource = this.txtLogSource.Text.Trim();
                obj.LogUser = this.txtLogUser.Text.Trim();
                obj.LogDescrption = this.txtLogDescrption.Text.Trim();
                obj.LogRequestInfo = this.txtLogRequestInfo.Text.Trim();
                obj.LogRelateMoudleID = Convert.ToInt32(this.txtLogRelateMoudleID.Text.Trim());
                obj.LogRelateMoudleDataID = Convert.ToInt32(this.txtLogRelateMoudleDataID.Text.Trim());
                obj.LogRelateUserID = Convert.ToInt32(this.txtLogRelateUserID.Text.Trim());
                obj.LogRelateDateTime = UIHelper.SaftGetDateTime(this.txtLogRelateDateTime.Text.Trim());





                SystemLogWrapper.Save(obj);

                winSystemLogAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }

}