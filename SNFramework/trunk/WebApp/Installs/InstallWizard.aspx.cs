using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Providers;

namespace Legendigital.Common.WebApp.Installs
{
    public partial class InstallWizard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }




        protected void btnFinished_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SortedList<string,string> installParams = new SortedList<string, string>();
                
                installParams.Add("sysName",this.txtName.Text.Trim());
                installParams.Add("sysDescription", this.txtDescription.Text.Trim());
                installParams.Add("sysVersion", this.txtVersion.Text.Trim());
                installParams.Add("sysCopyRight", this.txtCopyRight.Text.Trim());

                //installParams.Add("sysDevAdminPass", this.txtDevAdminPassword.Text.Trim());
                //installParams.Add("sysSysAdminPass", this.txtSysAdminPassword.Text.Trim());

                try
                {
                    if (SystemUserWrapper.GetUserByLoginID(SystemUserWrapper.DEV_USER_ID) == null)
                    {
                        Membership.CreateUser(SystemUserWrapper.DEV_USER_ID, this.txtDevAdminPassword.Text.Trim(), SystemUserWrapper.DEV_USER_ID + "@163.com");
                    }
                    else
                    {
                        ((NHibernateMembershipProvider) Membership.Provider).ChangePassword(SystemUserWrapper.DEV_USER_ID,
                                                                                            this.txtDevAdminPassword.Text.
                                                                                                Trim());
                    }
                }
                catch (Exception ex)
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
                    return;
                }

                try
                {
                    if (SystemUserWrapper.GetUserByLoginID(SystemUserWrapper.SYS_USER_ID) == null)
                    {
                        Membership.CreateUser(SystemUserWrapper.SYS_USER_ID, this.txtSysAdminPassword.Text.Trim(), SystemUserWrapper.SYS_USER_ID + "@163.com");           
                    }
                    else
                    {
                        ((NHibernateMembershipProvider)Membership.Provider).ChangePassword(SystemUserWrapper.SYS_USER_ID,
                                                                                           this.txtSysAdminPassword.Text.
                                                                                               Trim());
                    }
                }
                catch (Exception ex)
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
                    return;
                }

                installParams.Add("sysMenuLan", this.cmbMenuLan.SelectedItem.Value.Trim());

                SystemSettingWrapper.InstallSystem(installParams);
 

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }

        protected void Next_Click(object sender, DirectEventArgs e)
        {
            int index = int.Parse(e.ExtraParams["index"]);

            if ((index + 1) < this.WizardPanel.Items.Count)
            {
                this.WizardPanel.ActiveIndex = index + 1;
            }

            this.CheckButtons();
        }

        protected void Prev_Click(object sender, DirectEventArgs e)
        {
            int index = int.Parse(e.ExtraParams["index"]);

            if ((index - 1) >= 0)
            {
                this.WizardPanel.ActiveIndex = index - 1;
            }

            this.CheckButtons();
        }

        private void CheckButtons()
        {
            int index = this.WizardPanel.ActiveIndex;

            this.btnNext.Disabled = index == (this.WizardPanel.Items.Count - 1);
            this.btnPrev.Disabled = index == 0;
        }
    }
}