using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace ExtJSConsole.Moudle.SystemManage.PermissionManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemPrivilegeEdit")]
    public partial class UCSystemPrivilegeEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SystemPrivilegeWrapper obj = SystemPrivilegeWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtPrivilegeCnName.Text = obj.PrivilegeCnName.ToString();
                    this.txtPrivilegeEnName.Text = obj.PrivilegeEnName.ToString();
                    this.txtDescription.Text = obj.Description.ToString();
                    this.txtPrivilegeCategory.Text = obj.PrivilegeCategory.ToString();



                    hidSystemPrivilegeID.Text = id.ToString();


                    winSystemPrivilegeEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "错误信息：数据不存在";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }
        }

        protected void btnSaveSystemPrivilege_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemPrivilegeWrapper obj = SystemPrivilegeWrapper.FindById(int.Parse(hidSystemPrivilegeID.Text.Trim()));
                obj.PrivilegeCnName = this.txtPrivilegeCnName.Text.Trim();
                obj.PrivilegeEnName = this.txtPrivilegeEnName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.PrivilegeCategory = this.txtPrivilegeCategory.Text.Trim();

                SystemPrivilegeWrapper.Update(obj);

                winSystemPrivilegeEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }

        }
    }



}