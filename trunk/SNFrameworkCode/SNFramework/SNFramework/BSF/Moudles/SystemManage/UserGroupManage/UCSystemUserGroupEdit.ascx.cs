using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace SNFramework.BSF.Moudles.SystemManage.UserGroupManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemUserGroupEdit")]
    public partial class UCSystemUserGroupEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SystemUserGroupWrapper obj = SystemUserGroupWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtGroupNameCn.Text = obj.GroupNameCn.ToString();
                    this.txtGroupNameEn.Text = obj.GroupNameEn.ToString();
                    this.txtGroupDescription.Text = obj.GroupDescription.ToString();




                    hidGroupID.Text = id.ToString();


                    winSystemUserGroupEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "Error Message：Data does not exist";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message：" + ex.Message;
                return;
            }
        }

        protected void btnSaveSystemUserGroup_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemUserGroupWrapper obj = SystemUserGroupWrapper.FindById(int.Parse(hidGroupID.Text.Trim()));
                obj.GroupNameCn = this.txtGroupNameCn.Text.Trim();
                obj.GroupNameEn = this.txtGroupNameEn.Text.Trim();
                obj.GroupDescription = this.txtGroupDescription.Text.Trim();


                SystemUserGroupWrapper.Update(obj);

                winSystemUserGroupEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message：" + ex.Message;
                return;
            }

        }
    }
}