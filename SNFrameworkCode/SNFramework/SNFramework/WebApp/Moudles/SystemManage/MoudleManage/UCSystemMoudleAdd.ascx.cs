using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.MoudleManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemMoudleAdd")]
    public partial class UCSystemMoudleAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSystemMoudleAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage：" + ex.Message;
            }
        }

        protected void btnSaveSystemMoudle_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemMoudleWrapper obj = new SystemMoudleWrapper();
                obj.MoudleNameCn = this.txtMoudleNameCn.Text.Trim();
                obj.MoudleNameEn = this.txtMoudleNameEn.Text.Trim();
                obj.MoudleNameDb = this.txtMoudleNameDb.Text.Trim();
                obj.MoudleDescription = this.txtMoudleDescription.Text.Trim();
                obj.ApplicationID = null;
                obj.MoudleIsSystemMoudle = this.chkMoudleIsSystemMoudle.Checked;





                SystemMoudleWrapper.Save(obj);

                winSystemMoudleAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage：" + ex.Message;
            }
        }
    }

}