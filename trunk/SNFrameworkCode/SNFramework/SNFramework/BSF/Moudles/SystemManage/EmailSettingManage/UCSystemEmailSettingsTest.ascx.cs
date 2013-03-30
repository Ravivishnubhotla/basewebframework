using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;

namespace SNFramework.BSF.Moudles.SystemManage.EmailSettingManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemEmailSettingsTest")]
    public partial class UCSystemEmailSettingsTest : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show(int id)
        {
            SystemEmailSettingsWrapper obj = SystemEmailSettingsWrapper.FindById(id);

            if (obj != null)
            {
                hidEmailSettingID.Text = id.ToString();
                winSystemEmailSettingsTest.Show();
            }
            else
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message : Data does not exist";
            }
        }

        protected void btnTestSystemEmailSettings_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemEmailSettingsWrapper obj = SystemEmailSettingsWrapper.FindById(int.Parse(hidEmailSettingID.Text.Trim()));

                List<string> toMails = new List<string>();

                toMails.Add(this.txtMail.Text.Trim());

                string title = this.txtTitle.Text.Trim();

                string content = this.txtContext.Text.Trim();

                toMails.Add(this.txtMail.Text.Trim());

                SystemEmailSettingsWrapper.SendMail(toMails, title, content, true, obj, MailType.SendSync);
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message : " + ex.Message;
            }
        }
    }
}