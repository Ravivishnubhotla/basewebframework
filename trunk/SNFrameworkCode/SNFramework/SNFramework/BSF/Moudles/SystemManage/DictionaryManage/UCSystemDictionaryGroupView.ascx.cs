using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;

namespace SNFramework.BSF.Moudles.SystemManage.DictionaryManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemDictionaryGroupView")]
    public partial class UCSystemDictionaryGroupView : System.Web.UI.UserControl
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SystemDictionaryGroupWrapper obj = SystemDictionaryGroupWrapper.FindById(id);

                if (obj != null)
                {



                    this.lblName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    this.lblCode.Text = ValueConvertUtil.ConvertStringValue(obj.Code);
                    this.lblDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
                    //this.lblIsEnable.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsEnable);
                    //this.lblIsSystem.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsSystem);





                    //hidLogID.Text = id.ToString();


                    winSystemDictionaryGroupView.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "ErrorMessage : Data does not exist";
                    return;
                }
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