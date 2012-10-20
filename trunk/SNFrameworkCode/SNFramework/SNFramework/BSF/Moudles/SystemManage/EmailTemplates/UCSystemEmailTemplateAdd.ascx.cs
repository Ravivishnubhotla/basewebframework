using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using SNFramework.BSF.AppCode;
using Legendigital.Framework.Common.Web.ControlHelper;

namespace SNFramework.BSF.Moudles.SystemManage.EmailTemplates
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemEmailTemplateAdd")]
    public partial class UCSystemEmailTemplateAdd : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSystemEmailTemplateAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message : " + ex.Message;
            }
        }

        protected void btnSaveSystemEmailTemplate_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemEmailTemplateWrapper obj = new SystemEmailTemplateWrapper();

                obj.Name = this.txtName.Text.Trim();
                obj.Code = this.txtCode.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.TemplateType = this.cmbTemplateType.SelectedItem.Value.Trim();
                obj.TitleTemplate = this.txtTitleTemplate.Text.Trim();
                obj.BodyTemplate = this.txtBodyTemplate.Text.Trim();
                obj.IsHtmlEmail = this.chkIsHtmlEmail.Checked;
                obj.IsEnable = this.chkIsEnable.Checked;
                //obj.CreateDate = System.DateTime.Now;






                SystemEmailTemplateWrapper.Save(obj);

                winSystemEmailTemplateAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message : " + ex.Message;
            }
        }
    }
}