using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using SNFramework.BSF.AppCode;

namespace SNFramework.BSF.Moudles.SystemManage.UserManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemUserEdit")]
    public partial class UCSystemUserEdit : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ExtNet.IsAjaxRequest)
                return;
            //Ext.Net.TreeNode root = InitRoot();
            //LinqTree(null, root);
        }



        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SystemUserWrapper obj = SystemUserWrapper.FindById(id);

                if (obj != null)
                {
                    txtUserName.Text = Convert.ToString(obj.UserName);
                    txtUserEmail.Text = Convert.ToString(obj.UserEmail);
                    txtComments.Text = Convert.ToString(obj.Comments);

                    hidSystemUserID.Text = id.ToString();



                    winSystemUserEdit.Show();
                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "Error Message : Data is not exist!";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message : " + ex.Message;
                return;
            }
        }

        protected void btnSaveSystemUser_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemUserWrapper obj = SystemUserWrapper.FindById(int.Parse(hidSystemUserID.Text.Trim()));




                obj.UserName = txtUserName.Text.Trim();
                obj.UserEmail = txtUserEmail.Text.Trim();
                obj.Comments = txtComments.Text.Trim();




                SystemUserWrapper.Update(obj);
                winSystemUserEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message :" + ex.Message;
                return;
            }
        }


    }
}