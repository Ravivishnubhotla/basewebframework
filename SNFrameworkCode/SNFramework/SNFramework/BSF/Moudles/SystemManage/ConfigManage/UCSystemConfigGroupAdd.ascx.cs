using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace SNFramework.BSF.Moudles.SystemManage.ConfigManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemConfigGroupAdd")]
    public partial class UCSystemConfigGroupAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSystemConfigGroupAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
            }
        }

        protected void btnSaveSystemConfigGroup_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemConfigGroupWrapper obj = new SystemConfigGroupWrapper();
                obj.Name = this.txtName.Text.Trim();
                obj.Code = this.txtCode.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.IsEnable = this.chkIsEnable.Checked;
                obj.IsSystem = this.chkIsSystem.Checked;





                SystemConfigGroupWrapper.Save(obj);

                winSystemConfigGroupAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }
    }
}