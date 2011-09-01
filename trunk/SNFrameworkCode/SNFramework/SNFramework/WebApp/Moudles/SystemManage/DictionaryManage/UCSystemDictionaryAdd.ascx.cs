using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
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
                lblDictionaryGroup.Text = DictionaryGroup.Name;

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
                obj.SystemDictionaryGroupID = DictionaryGroup;
                obj.SystemDictionaryKey = this.txtSystemDictionaryKey.Text.Trim();
                obj.SystemDictionaryValue = this.txtSystemDictionaryValue.Text.Trim();
                obj.SystemDictionaryDesciption = this.txtSystemDictionaryDesciption.Text.Trim();
                obj.SystemDictionaryOrder = Convert.ToInt32(this.txtSystemDictionaryOrder.Text.Trim());
                obj.SystemDictionaryIsEnable = this.chkSystemDictionaryIsEnable.Checked;
                obj.SystemDictionaryIsSystem = this.chkSystemDictionaryIsSystem.Checked;

                SystemDictionaryWrapper.Save(obj);

                SysDictionaryWrapper.RefreshCache();

                winSystemDictionaryAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage：" + ex.Message;
            }
        }

        public SystemDictionaryGroupWrapper DictionaryGroup
        {
            get
            {
                if (this.Request.QueryString["DictionaryGroupID"] != null)
                {
                    return
                        SystemDictionaryGroupWrapper.FindById(int.Parse(this.Request.QueryString["DictionaryGroupID"]));
                }
                return null;
            }
        }


    }


}