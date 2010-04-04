using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace ExtJSConsole.Moudle.SystemManage.UserManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemUserEdit")]
    public partial class UCSystemUserEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
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

        protected void btnSaveSystemUser_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemUserWrapper obj = SystemUserWrapper.FindById(int.Parse(hidSystemUserID.Text.Trim()));

                obj.UserName = this.txtUserName.Text.Trim();
                obj.UserEmail = this.txtUserEmail.Text.Trim();
                obj.Comments = this.txtComments.Text.Trim();

                SystemUserWrapper.Update(obj);

                winSystemUserEdit.Hide();
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