using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;
using Legendigital.Framework.Common.Utility;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.OrginationDepartmentManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemPostEdit")]
    public partial class UCSystemPostEdit : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SystemPostWrapper obj = SystemPostWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    this.txtCode.Text = ValueConvertUtil.ConvertStringValue(obj.Code);
                    this.txtDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
                    this.txtOrganizationID.Text = obj.OrganizationID.Name;
 

                    hidId.Text = id.ToString();


                    winSystemPostEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "Error Message : Data does not exist";
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

        protected void btnSaveSystemPost_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemPostWrapper obj = SystemPostWrapper.FindById(int.Parse(hidId.Text.Trim()));
                obj.Name = this.txtName.Text.Trim();
                obj.Code = this.txtCode.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();


                obj.LastModifyBy = this.ParentPage.CurrentLoginUser.UserID;
                obj.LastModifyAt = System.DateTime.Now; ;
                obj.LastModifyComment = "创建用户";


                SystemPostWrapper.Update(obj);

                winSystemPostEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
                return;
            }

        }

    }
}