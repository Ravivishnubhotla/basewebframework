using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.ConfigManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemConfigAdd")]
    public partial class UCSystemConfigAdd : System.Web.UI.UserControl
    {

        protected void storeSystemConfigGroup_Refresh(object sender, StoreRefreshDataEventArgs e)
        {


            storeSystemConfigGroup.DataSource = SystemConfigGroupWrapper.FindAll();
 

            storeSystemConfigGroup.DataBind();

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSystemConfigAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message：" + ex.Message;
            }
        }

        protected void btnSaveSystemConfig_Click(object sender, DirectEventArgs e)
        {
            try
            {
                if(SystemConfigWrapper.CheckIfExistedConfigByKey(this.txtConfigKey.Text.Trim()))
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "Error Message : config '" + this.txtConfigKey.Text.Trim() + "' is existed  ,Please change key name.";
                    return;
                }


                SystemConfigWrapper obj = new SystemConfigWrapper();
                if (this.cmbGroup.SelectedItem != null)
                    obj.ConfigGroupID = SystemConfigGroupWrapper.FindById(int.Parse(this.cmbGroup.SelectedItem.Value));
                else
                    obj.ConfigGroupID = null;
                obj.ConfigKey = this.txtConfigKey.Text.Trim();
                obj.ConfigValue = this.txtConfigValue.Text.Trim();
                obj.ConfigDescription = this.txtConfigDescription.Text.Trim();
                obj.SortIndex = 1;
                obj.ConfigDataType = this.cmbDataType.SelectedItem.Value;





                SystemConfigWrapper.Save(obj);

                winSystemConfigAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message ：" + ex.Message;
            }
        }

        protected void storeDictionary_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            Store store = sender as Store;

            string dictionaryGroupCode = e.Parameters["DictionaryGroupCode"];

            List<SystemDictionaryWrapper> alldictionarys = SystemDictionaryWrapper.GetDictionaryByGroupCode(dictionaryGroupCode);

            List<object[]> dictionaryItems = new List<object[]>();

            foreach (SystemDictionaryWrapper systemDictionaryWrapper in alldictionarys)
            {
                dictionaryItems.Add(new object[] { systemDictionaryWrapper.SystemDictionaryKey, systemDictionaryWrapper.SystemDictionaryValue, systemDictionaryWrapper.SystemDictionaryCode });
            }

            store.DataSource = dictionaryItems;
            store.DataBind(); 


        }
    }
}