using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;

namespace ExtJSConsole.Moudle.SystemManage.DictionaryManage
{

    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSystemDictionaryEdit")]
    public partial class UCSystemDictionaryEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
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
                    this.txtSystemDictionaryOrder.Value = obj.SystemDictionaryOrder;
                    this.chkSystemDictionaryIsEnable.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.SystemDictionaryIsEnable);



                    hidSystemDictionaryID.Text = id.ToString();


                    winSystemDictionaryEdit.Show();

                }
                else
                {
                    ScriptManager.AjaxSuccess = false;
                    ScriptManager.AjaxErrorMessage = "错误信息：数据不存在";
                    return;
                }
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }
        }

        protected void btnSaveSystemDictionary_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SystemDictionaryWrapper obj = SystemDictionaryWrapper.FindById(int.Parse(hidSystemDictionaryID.Text.Trim()));
                obj.SystemDictionaryCategoryID = this.txtSystemDictionaryCategoryID.Text.Trim();
                obj.SystemDictionaryKey = this.txtSystemDictionaryKey.Text.Trim();
                obj.SystemDictionaryValue = this.txtSystemDictionaryValue.Text.Trim();
                obj.SystemDictionaryDesciption = this.txtSystemDictionaryDesciption.Text.Trim();
                obj.SystemDictionaryOrder = Convert.ToInt32(this.txtSystemDictionaryOrder.Value);
                obj.SystemDictionaryIsEnable = this.chkSystemDictionaryIsEnable.Checked;

                SystemDictionaryWrapper.Update(obj);

                winSystemDictionaryEdit.Hide();
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }

        }
    }



}