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

    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemEmailTemplateView")]
    public partial class UCSystemEmailTemplateView : BaseUserControl
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



                    this.lblName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    this.lblCode.Text = ValueConvertUtil.ConvertStringValue(obj.Code);
                    this.lblDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
 
                    this.lblTitleTemplate.Text = ValueConvertUtil.ConvertStringValue(obj.TitleTemplate);
                    this.lblBodyTemplate.Text = ValueConvertUtil.ConvertStringValue(obj.BodyTemplate);
                    this.lblIsHtmlEmail.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsHtmlEmail).ToString();
                    this.lblIsEnable.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsEnable).ToString();
 
 
                    //hidLogID.Text = id.ToString();


                    winSystemEmailTemplateView.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "Error Message :Data does not exist";
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


    }


}