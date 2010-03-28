using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace ExtJSConsole.Moudle.SystemManage.UserManage
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSystemUserEdit")]
    public partial class UCSystemUserEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SystemUserWrapper obj = SystemUserWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtUserName.Text = obj.UserName.ToString();
                    this.txtUserEmail.Text = obj.UserEmail.ToString();
                    this.txtComments.Text = obj.Comments.ToString();

                    hidSystemUserID.Text = id.ToString();


                    winSystemUserEdit.Show();

                }
                else
                {
                    ScriptManager.AjaxSuccess = false;
                    ScriptManager.AjaxErrorMessage = "错误信息：数据不存在";
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

        protected void btnSaveSystemUser_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SystemUserWrapper obj = SystemUserWrapper.FindById(int.Parse(hidSystemUserID.Text.Trim()));

                obj.UserName = this.txtUserName.Text.Trim();
                obj.UserEmail = this.txtUserEmail.Text.Trim();
                obj.Comments = this.txtComments.Text.Trim();

                SystemUserWrapper.Update(obj);

                winSystemUserEdit.Hide();
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }

        }
    }


}