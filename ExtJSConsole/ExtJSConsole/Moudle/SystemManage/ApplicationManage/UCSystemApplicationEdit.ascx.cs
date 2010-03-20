using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using ScriptManager=Coolite.Ext.Web.ScriptManager;

namespace ExtJSConsole.Moudle.SystemManage.ApplicationManage
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSystemApplicationEdit")]
    public partial class UCSystemApplicationEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SystemApplicationWrapper systemApplication = SystemApplicationWrapper.FindById(id);

                if (systemApplication != null)
                {
                    txtSystemApplicationName.Text = systemApplication.SystemApplicationName;
                    txtSystemApplicationDescription.Text = systemApplication.SystemApplicationDescription;
                    txtSystemApplicationUrl.Text = systemApplication.SystemApplicationUrl;
                    chkSystemApplicationIsSystemApplication.Checked = (systemApplication.SystemApplicationIsSystemApplication.HasValue) ? systemApplication.SystemApplicationIsSystemApplication.Value : false;

                    hidSystemApplicationID.Text = id.ToString();


                    winSystemApplicationEdit.Show();

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

        protected void btnSaveSystemApplication_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SystemApplicationWrapper systemApplication = SystemApplicationWrapper.FindById(int.Parse(hidSystemApplicationID.Text.Trim()));
                systemApplication.SystemApplicationName = txtSystemApplicationName.Text.Trim();
                systemApplication.SystemApplicationDescription = txtSystemApplicationDescription.Text.Trim();
                systemApplication.SystemApplicationUrl = txtSystemApplicationUrl.Text.Trim();
                systemApplication.SystemApplicationIsSystemApplication = chkSystemApplicationIsSystemApplication.Checked;
                SystemApplicationWrapper.Update(systemApplication);

                winSystemApplicationEdit.Hide();
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