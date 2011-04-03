using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.DictionaryManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemDictionaryEdit")]
    public partial class UCSystemDictionaryEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SystemDictionaryWrapper obj = SystemDictionaryWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtSystemDictionaryCategoryID.Text = obj.SystemDictionaryCategoryID.ToString();
                    this.txtSystemDictionaryKey.Text = obj.SystemDictionaryKey.ToString();
                    this.txtSystemDictionaryValue.Text = obj.SystemDictionaryValue.ToString();
                    this.txtSystemDictionaryDesciption.Text = obj.SystemDictionaryDesciption.ToString();
                    this.txtSystemDictionaryOrder.Text = obj.SystemDictionaryOrder.ToString();
                    this.chkSystemDictionaryIsEnable.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.SystemDictionaryIsEnable);


                    hidSystemDictionaryID.Text = id.ToString();
                    winSystemDictionaryEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "ErrorMessage：Data does not exist";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage：" + ex.Message;
                return;
            }
        }

        protected void btnSaveSystemDictionary_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemDictionaryWrapper obj = SystemDictionaryWrapper.FindById(int.Parse(hidSystemDictionaryID.Text.Trim()));
                obj.SystemDictionaryCategoryID = this.txtSystemDictionaryCategoryID.Text.Trim();
                obj.SystemDictionaryKey = this.txtSystemDictionaryKey.Text.Trim();
                obj.SystemDictionaryValue = this.txtSystemDictionaryValue.Text.Trim();
                obj.SystemDictionaryDesciption = this.txtSystemDictionaryDesciption.Text.Trim();
                obj.SystemDictionaryOrder = Convert.ToInt32(this.txtSystemDictionaryOrder.Text.Trim());
                obj.SystemDictionaryIsEnable = this.chkSystemDictionaryIsEnable.Checked;


                SystemDictionaryWrapper.Update(obj);

                winSystemDictionaryEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage：" + ex.Message;
                return;
            }

        }
    }


}