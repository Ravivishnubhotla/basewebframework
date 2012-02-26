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
                    this.txtConfigKey.Text = obj.ConfigKey.ToString();
                    this.txtConfigValue.Text = obj.ConfigValue.ToString();
                    this.txtConfigDescription.Text = obj.ConfigDescription.ToString();
                    this.txtSortIndex.Text = obj.SortIndex.ToString();




                    hidSystemConfigID.Text = id.ToString();


                    winSystemConfigEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "错误信息：数据不存在！";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }
        }

        protected void btnSaveSystemConfig_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemConfigWrapper obj = SystemConfigWrapper.FindById(int.Parse(hidSystemConfigID.Text.Trim()));
                obj.ConfigKey = this.txtConfigKey.Text.Trim();
                obj.ConfigValue = this.txtConfigValue.Text.Trim();
                obj.ConfigDescription = this.txtConfigDescription.Text.Trim();
                obj.SortIndex = Convert.ToInt32(this.txtSortIndex.Text.Trim());


                SystemConfigWrapper.Update(obj);

                winSystemConfigEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }

        }
    }

}