using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace ExtJSConsole.Moudle.SystemManage.MoudleManage
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSystemMoudleAdd")]
    public partial class UCSystemMoudleAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [AjaxMethod]
        public void Show()
        {
            try
            {
                this.winSystemMoudleAdd.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSystemMoudle_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SystemMoudleWrapper obj = new SystemMoudleWrapper();
                obj.MoudleNameCn = this.txtMoudleNameCn.Text.Trim();
                obj.MoudleNameEn = this.txtMoudleNameEn.Text.Trim();
                obj.MoudleNameDb = this.txtMoudleNameDb.Text.Trim();
                obj.MoudleDescription = this.txtMoudleDescription.Text.Trim();
                //obj.ApplicationID = Convert.ToInt32(this.txtApplicationID.Text.Trim());
                obj.MoudleIsSystemMoudle = this.chkMoudleIsSystemMoudle.Checked;


                SystemMoudleWrapper.Save(obj);

                winSystemMoudleAdd.Hide();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }
}