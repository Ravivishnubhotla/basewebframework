using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;


namespace Legendigital.Common.WebApp.Moudles.SystemManage.DictionaryManage
{


    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemDictionaryAdd")]
    public partial class UCSystemDictionaryAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSystemDictionaryAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage：" + ex.Message;
            }
        }

        protected void btnSaveSystemDictionary_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemDictionaryWrapper obj = new SystemDictionaryWrapper();
                obj.SystemDictionaryCategoryID = this.txtSystemDictionaryCategoryID.Text.Trim();
                obj.SystemDictionaryKey = this.txtSystemDictionaryKey.Text.Trim();
                obj.SystemDictionaryValue = this.txtSystemDictionaryValue.Text.Trim();
                obj.SystemDictionaryDesciption = this.txtSystemDictionaryDesciption.Text.Trim();
                obj.SystemDictionaryOrder = Convert.ToInt32(this.txtSystemDictionaryOrder.Text.Trim());
                obj.SystemDictionaryIsEnable = this.chkSystemDictionaryIsEnable.Checked;





                SystemDictionaryWrapper.Save(obj);

                winSystemDictionaryAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage：" + ex.Message;
            }
        }
    }


}