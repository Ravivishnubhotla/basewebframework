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

    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSystemMenuEdit")]
    public partial class UCSystemMenuEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SystemMenuWrapper menu = SystemMenuWrapper.FindById(id);

                if (menu != null)
                {
                    this.hidMenuID.Text = menu.MenuID.ToString();
                    this.hidApplicationID.Text = menu.ApplicationID.SystemApplicationID.ToString();
                    this.lblApplicationName.Text = menu.ApplicationID.SystemApplicationName;


                    if (menu.ParentMenuID == null)
                    {
                        this.lblParentMenuName.Text = "作为主菜单";
                        this.fsMenuIsCategory.Disabled = true;
                        this.fsMenuIsCategory.CheckboxToggle = false;
                    }
                    else
                    {
                        this.lblParentMenuName.Text =
                        menu.ParentMenuID.MenuName;
                        this.hidPMenuID.Text = menu.ParentMenuID.MenuID.ToString();
                        this.fsMenuIsCategory.Disabled = false;
                        this.fsMenuIsCategory.CheckboxToggle = true;
                    }

                    this.txtMenuName.Text = menu.MenuName;
                    this.txtMenuDescription.Text = menu.MenuDescription;
                    this.chkMenuIsSystemMenu.Checked = (menu.MenuIsSystemMenu.HasValue ? menu.MenuIsSystemMenu.Value : false);
                    this.chkMenuIsEnable.Checked = (menu.MenuIsEnable.HasValue ? menu.MenuIsSystemMenu.Value : false);

                    this.fsMenuIsCategory.Collapsed = menu.MenuIsCategory;


                    if (!menu.MenuIsCategory)
                    {
                        this.txtMenuIconUrl.Text = menu.MenuIconUrl;
                        this.txtMenuUrl.Text = menu.MenuUrl;
                        if (string.IsNullOrEmpty(menu.MenuType))
                            this.cmbMenuType.SelectedIndex = 0;
                        else
                            this.cmbMenuType.SetValue(menu.MenuType);
                        if (string.IsNullOrEmpty(menu.MenuUrlTarget))
                            this.cmbMenuUrlTarget.SelectedIndex = 0;
                        else
                            this.cmbMenuUrlTarget.SetValue(menu.MenuUrlTarget);
                    }
                    else
                    {
                        this.txtMenuIconUrl.Text = "";
                        this.txtMenuUrl.Text = "";
                        this.cmbMenuType.SelectedIndex = 0;
                        this.cmbMenuUrlTarget.SelectedIndex = 0;
                    }

                    winSystemMenuEdit.Show();

                }
                else
                {
                    Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                    Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：数据不存在";
                    return;
                }
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }
        }

        protected void btnSaveSystemMenu_Click(object sender, AjaxEventArgs e)
        {

            try
            {
                SystemMenuWrapper menuWrapper = SystemMenuWrapper.FindById(int.Parse(this.hidMenuID.Text));

                if (menuWrapper == null)
                {
                    winSystemMenuEdit.Hide();
                    Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                    Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：数据不存在";
                    return;
                }

                menuWrapper.MenuName = this.txtMenuName.Text.Trim();
                menuWrapper.MenuDescription = this.txtMenuDescription.Text.Trim();
                menuWrapper.ApplicationID = SystemApplicationWrapper.FindById(int.Parse(this.hidApplicationID.Text));
                menuWrapper.MenuIsSystemMenu = this.chkMenuIsSystemMenu.Checked;
                menuWrapper.MenuIsEnable = this.chkMenuIsEnable.Checked;

                if (this.hidPMenuID.Text.Trim() != "")
                {
                    menuWrapper.MenuOrder = SystemMenuWrapper.GetNewMaxMenuOrder(int.Parse(this.hidPMenuID.Text.Trim()), int.Parse(this.hidApplicationID.Text));
                    menuWrapper.ParentMenuID = SystemMenuWrapper.FindById(int.Parse(this.hidPMenuID.Text.Trim()));
                }
                else
                {
                    menuWrapper.MenuOrder = SystemMenuWrapper.GetNewMaxMenuOrder(0, int.Parse(this.hidApplicationID.Text));
                }

                menuWrapper.MenuIsCategory = this.fsMenuIsCategory.Collapsed;

                if (!menuWrapper.MenuIsCategory)
                {
                    menuWrapper.MenuIconUrl = this.txtMenuIconUrl.Text.Trim();
                    menuWrapper.MenuUrl = this.txtMenuUrl.Text.Trim();
                    menuWrapper.MenuType = this.cmbMenuType.SelectedItem.Value;
                    menuWrapper.MenuUrlTarget = this.cmbMenuUrlTarget.SelectedItem.Value;
                }
                else
                {
                    menuWrapper.MenuIconUrl = "";
                    menuWrapper.MenuUrl = "";
                    menuWrapper.MenuType = "1";
                    menuWrapper.MenuUrlTarget = "1";
                }


                SystemMenuWrapper.Update(menuWrapper);

                winSystemMenuEdit.Hide();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }
}