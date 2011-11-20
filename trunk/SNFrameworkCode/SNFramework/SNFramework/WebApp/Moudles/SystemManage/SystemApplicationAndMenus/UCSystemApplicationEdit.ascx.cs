using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.SystemApplicationAndMenus
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemApplicationEdit")]
    public partial class UCSystemApplicationEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SystemApplicationWrapper systemApplication = SystemApplicationWrapper.FindById(id);

                if (systemApplication != null)
                {
                    this.formPanelSystemApplicationEdit.SetValues(systemApplication);

                    //txtSystemApplicationName.Text = systemApplication.SystemApplicationName;
                    //txtSystemApplicationDescription.Text = systemApplication.SystemApplicationDescription;
                    //txtSystemApplicationUrl.Text = systemApplication.SystemApplicationUrl;
                    //chkSystemApplicationIsSystemApplication.Checked = (systemApplication.SystemApplicationIsSystemApplication.HasValue) ? systemApplication.SystemApplicationIsSystemApplication.Value : false;

                    //hidSystemApplicationID.Text = id.ToString();




                    winSystemApplicationEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "错误信息:数据不存在！";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息:" + ex.Message;
                return;
            }
        }

        protected void btnSaveSystemApplication_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemApplicationWrapper systemApplication = SystemApplicationWrapper.FindById(int.Parse(hidSystemApplicationID.Text.Trim()));
                systemApplication.SystemApplicationName = txtSystemApplicationName.Text.Trim();
                systemApplication.SystemApplicationCode = txtSystemApplicationCode.Text.Trim();
                systemApplication.SystemApplicationDescription = txtSystemApplicationDescription.Text.Trim();
                systemApplication.SystemApplicationUrl = txtSystemApplicationUrl.Text.Trim();
                systemApplication.SystemApplicationIsSystemApplication = chkSystemApplicationIsSystemApplication.Checked;
                SystemApplicationWrapper.Update(systemApplication);

                winSystemApplicationEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息:" + ex.Message;
                return;
            }
        }
    }
}