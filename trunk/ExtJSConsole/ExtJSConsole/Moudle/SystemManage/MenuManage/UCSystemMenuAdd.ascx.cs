using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace ExtJSConsole.Moudle.SystemManage.MenuManage
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSystemMenuAdd")]
    public partial class UCSystemMenuAdd : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [AjaxMethod]
        public void Show(string applicationId, string parentID)
        {
            SystemApplicationWrapper application = SystemApplicationWrapper.FindById(int.Parse(applicationId));

            if(application!=null)
            {
                this.hidApplicationID.Text = application.SystemApplicationID.ToString();
                this.lblApplicationName.Text = application.SystemApplicationName;


                if(parentID == "")
                {
                    this.lblParentMenuName.Text = "作为主菜单";
                    this.fsMenuIsCategory.Disabled = true;
                }

                this.txtMenuName.Text = "";
                this.txtMenuDescription.Text = "";

                

            }

            this.winSystemMenuAdd.Show();


        }

        protected void btnSaveSystemMenu_Click(object sender, AjaxEventArgs e)
        {

            try
            {
     

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }
}