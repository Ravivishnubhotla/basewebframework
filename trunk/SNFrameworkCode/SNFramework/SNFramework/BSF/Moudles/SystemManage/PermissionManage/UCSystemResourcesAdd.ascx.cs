using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace SNFramework.BSF.Moudles.SystemManage.PermissionManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemResourcesAdd")]
    public partial class UCSystemResourcesAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show(int pID)
        {
            try
            {
                if (pID == 0)
                {
                    this.lblParentResourcesName.Text = "As root resource";
                }
                else
                {
                    this.lblParentResourcesName.Text =
                        SystemResourcesWrapper.FindById(pID).ResourcesNameCn;
                }

                this.hidParentResourcesID.Value = pID;
                this.winSystemResourcesAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }

        protected void btnSaveSystemResources_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemResourcesWrapper obj = new SystemResourcesWrapper();

                int pid = Convert.ToInt32(this.hidParentResourcesID.Value);

                if (pid > 0)
                {
                    obj.ParentResourcesID = SystemResourcesWrapper.FindById(pid);
                }
                else
                {
                    obj.ParentResourcesID = null;
                }


                obj.ResourcesNameCn = this.txtResourcesNameCn.Text.Trim();
                obj.ResourcesNameEn = this.txtResourcesNameEn.Text.Trim();
                obj.ResourcesDescription = this.txtResourcesDescription.Text.Trim();

                obj.ResourcesIsRelateUser = this.chkResourcesIsRelateUser.Checked;






                SystemResourcesWrapper.Save(obj);

                winSystemResourcesAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }


    }
}