using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;
namespace SNFramework.BSF.Moudles.SystemManage.PermissionManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemResourcesEdit")]
    public partial class UCSystemResourcesEdit : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SystemResourcesWrapper obj = SystemResourcesWrapper.FindById(id);

                if (obj != null)
                {
                    if (obj.ParentResourcesID == null)
                    {
                        this.lblParentResourcesName.Text = "As root resource";
                    }
                    else
                    {
                        this.lblParentResourcesName.Text = obj.ParentResourcesID.ResourcesNameCn;
                    }


                    this.hidResourcesID.Text = obj.ResourcesID.ToString();
                    this.txtResourcesNameCn.Text = ValueConvertUtil.ConvertStringValue(obj.ResourcesNameCn);
                    this.txtResourcesNameEn.Text = ValueConvertUtil.ConvertStringValue(obj.ResourcesNameEn);
                    this.txtResourcesDescription.Text = ValueConvertUtil.ConvertStringValue(obj.ResourcesDescription);

                    this.chkResourcesIsRelateUser.Checked = obj.ResourcesIsRelateUser;





                    hidResourcesID.Text = id.ToString();


                    winSystemResourcesEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "Error Message:Data does not exist";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
                return;
            }
        }

        protected void btnSaveSystemResources_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemResourcesWrapper obj = SystemResourcesWrapper.FindById(int.Parse(hidResourcesID.Text.Trim()));

                obj.ResourcesNameCn = this.txtResourcesNameCn.Text.Trim();
                obj.ResourcesNameEn = this.txtResourcesNameEn.Text.Trim();
                obj.ResourcesDescription = this.txtResourcesDescription.Text.Trim();

                obj.ResourcesIsRelateUser = this.chkResourcesIsRelateUser.Checked;



                SystemResourcesWrapper.Update(obj);

                winSystemResourcesEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
                return;
            }

        }

    }
}