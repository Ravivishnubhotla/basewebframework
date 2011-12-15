using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.OrginationDepartmentManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemPostAdd")]
    public partial class UCSystemPostAdd : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show(int orgid)
        {
            try
            {
                this.txtOrganizationID.Text = SystemOrganizationWrapper.FindById(orgid).Name;
             
                this.hidOrgID.Value = orgid;

                this.winSystemPostAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }

        protected void btnSaveSystemPost_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemPostWrapper obj = new SystemPostWrapper();
                obj.Name = this.txtName.Text.Trim();
                obj.Code = this.txtCode.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.OrganizationID = SystemOrganizationWrapper.FindById(Convert.ToInt32(this.hidOrgID.Text.Trim()));
                obj.CreateBy = this.ParentPage.CurrentLoginUser.UserID;
                obj.CreateAt = System.DateTime.Now;
                obj.LastModifyBy = this.ParentPage.CurrentLoginUser.UserID;
                obj.LastModifyAt = System.DateTime.Now; ;
                obj.LastModifyComment = "创建用户";





                SystemPostWrapper.Save(obj);

                winSystemPostAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }
    }
}