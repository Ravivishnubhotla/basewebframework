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

namespace Legendigital.Common.WebApp.Moudles.SystemManage.EmailTemplates
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemEmailTemplateEdit")]
    public partial class UCSystemEmailTemplateEdit : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SystemEmailTemplateWrapper obj = SystemEmailTemplateWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    this.txtCode.Text = ValueConvertUtil.ConvertStringValue(obj.Code);
                    this.txtDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
  
                    this.txtTitleTemplate.Text = ValueConvertUtil.ConvertStringValue(obj.TitleTemplate);
                    this.txtBodyTemplate.Text = ValueConvertUtil.ConvertStringValue(obj.BodyTemplate);
                    this.chkIsHtmlEmail.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsHtmlEmail);
                    this.chkIsEnable.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsEnable);
 




                    hidEmailTemplateID.Text = id.ToString();


                    winSystemEmailTemplateEdit.Show();

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

        protected void btnSaveSystemEmailTemplate_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemEmailTemplateWrapper obj = SystemEmailTemplateWrapper.FindById(int.Parse(hidEmailTemplateID.Text.Trim()));
                obj.Name = this.txtName.Text.Trim();
                obj.Code = this.txtCode.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
 
                obj.TitleTemplate = this.txtTitleTemplate.Text.Trim();
                obj.BodyTemplate = this.txtBodyTemplate.Text.Trim();
                obj.IsHtmlEmail = this.chkIsHtmlEmail.Checked;
                obj.IsEnable = this.chkIsEnable.Checked;
 


                SystemEmailTemplateWrapper.Update(obj);

                winSystemEmailTemplateEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message : " + ex.Message;
                return;
            }

        }
    }


}