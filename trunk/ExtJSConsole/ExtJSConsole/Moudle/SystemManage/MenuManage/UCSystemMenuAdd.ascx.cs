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
                    this.fsMenuIsCategory.CheckboxToggle = false;
                }
                else
                {
                    this.lblParentMenuName.Text =
                        SystemMenuWrapper.FindById(int.Parse(parentID)).MenuName;
                    this.hidPMenuID.Text = parentID;
                    this.fsMenuIsCategory.Disabled = false;
                    this.fsMenuIsCategory.CheckboxToggle = true;
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
                SystemMenuWrapper menuWrapper = new SystemMenuWrapper();
                menuWrapper.MenuName = this.txtMenuName.Text.Trim();
                menuWrapper.MenuDescription = this.txtMenuDescription.Text.Trim();
                menuWrapper.ApplicationID = SystemApplicationWrapper.FindById(int.Parse(this.hidApplicationID.Text));
                menuWrapper.MenuIsSystemMenu = true;
                menuWrapper.MenuIsEnable = true;
    
                if (this.hidPMenuID.Text.Trim() != "")
                {
                    menuWrapper.MenuOrder = SystemMenuWrapper.GetNewMaxMenuOrder(int.Parse(this.hidPMenuID.Text.Trim()), int.Parse(this.hidApplicationID.Text));
                    menuWrapper.ParentMenuID = SystemMenuWrapper.FindById(int.Parse(this.hidPMenuID.Text.Trim()));
                }
                else
                {
                    menuWrapper.MenuOrder = SystemMenuWrapper.GetNewMaxMenuOrder(0,int.Parse(this.hidApplicationID.Text));
                }

                menuWrapper.MenuIsCategory = !this.fsMenuIsCategory.CheckboxToggle;

                if (menuWrapper.MenuIsCategory)
                {
                    menuWrapper.MenuIconUrl = this.txtMenuIconUrl.Text.Trim();
                    menuWrapper.MenuUrl = this.txtMenuUrl.Text.Trim();
                    menuWrapper.MenuType = this.cmbMenuType.SelectedItem.Value;
                    menuWrapper.MenuUrlTarget = this.cmbMenuUrlTarget.SelectedItem.Value;
                }


                SystemMenuWrapper.Save(menuWrapper);

                winSystemMenuAdd.Hide();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }
}