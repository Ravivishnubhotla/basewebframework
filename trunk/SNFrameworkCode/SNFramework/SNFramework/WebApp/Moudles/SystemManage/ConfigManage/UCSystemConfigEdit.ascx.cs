using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.ConfigManage
{

    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemConfigEdit")]
    public partial class UCSystemConfigEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SystemConfigWrapper obj = SystemConfigWrapper.FindById(id);

                if (obj != null)
                {
                    if (obj.ConfigGroupID!=null)
                        this.cmbGroup.SetValue(obj.ConfigGroupID.Id);
                    else
                        this.cmbGroup.ClearValue();
                    this.txtConfigKey.Text = obj.ConfigKey.ToString();
                    this.txtConfigValue.Text = obj.ConfigValue.ToString();
                    this.txtConfigDescription.Text = obj.ConfigDescription.ToString();


                    if (!string.IsNullOrEmpty(obj.ConfigDataType))
                        this.cmbDataType.SetValue(obj.ConfigDataType);
                    else
                        this.cmbDataType.ClearValue();


                    hidSystemConfigID.Text = id.ToString();


                    winSystemConfigEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "Error Message：Data does not exist";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message：" + ex.Message;
                return;
            }
        }

        protected void btnSaveSystemConfig_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemConfigWrapper obj = SystemConfigWrapper.FindById(int.Parse(hidSystemConfigID.Text.Trim()));

                if (this.cmbGroup.SelectedItem != null)
                    obj.ConfigGroupID = SystemConfigGroupWrapper.FindById(int.Parse(this.cmbGroup.SelectedItem.Value));
                else
                    obj.ConfigGroupID = null;

                string configValue = this.txtConfigValue.Text.Trim();

                if (this.cmbDataType.SelectedItem.Value.ToString() == DictionaryConst.Dictionary_System_DataType_int_Key)
                {
                    try
                    {
                        int.Parse(configValue);
                    }
                    catch (Exception ex)
                    {
                        ResourceManager.AjaxSuccess = false;
                        ResourceManager.AjaxErrorMessage = "请输入整数：" + ex.Message;
                        return;
                    }
                }
                else if (this.cmbDataType.SelectedItem.Value.ToString() == DictionaryConst.Dictionary_System_DataType_datetime_Key)
                {
                    try
                    {
                        DateTime.Parse(configValue);
                    }
                    catch (Exception ex)
                    {
                        ResourceManager.AjaxSuccess = false;
                        ResourceManager.AjaxErrorMessage = "请输入日期时间：" + ex.Message;
                        return;
                    }
                }
                else if (this.cmbDataType.SelectedItem.Value.ToString() == DictionaryConst.Dictionary_System_DataType_bool_Key)
                {
                    try
                    {
                        bool.Parse(configValue);
                    }
                    catch (Exception ex)
                    {
                        ResourceManager.AjaxSuccess = false;
                        ResourceManager.AjaxErrorMessage = "请输入布尔值：" + ex.Message;
                        return;
                    }
                }
                else if (this.cmbDataType.SelectedItem.Value.ToString() == DictionaryConst.Dictionary_System_DataType_decimal_Key)
                {
                    try
                    {
                        decimal.Parse(configValue);
                    }
                    catch (Exception ex)
                    {
                        ResourceManager.AjaxSuccess = false;
                        ResourceManager.AjaxErrorMessage = "请输入小数：" + ex.Message;
                        return;
                    }
                }

                obj.ConfigDataType = this.cmbDataType.SelectedItem.Value;

                obj.ConfigValue = this.txtConfigValue.Text.Trim();
                obj.ConfigDescription = this.txtConfigDescription.Text.Trim();
                obj.SortIndex = 1;



                SystemConfigWrapper.Update(obj);

                winSystemConfigEdit.Hide();
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