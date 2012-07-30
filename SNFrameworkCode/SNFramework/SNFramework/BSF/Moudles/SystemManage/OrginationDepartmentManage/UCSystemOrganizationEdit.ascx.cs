using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;
using Legendigital.Framework.Common.Utility;
using Legendigital.Framework.Common.Web.ControlHelper;

namespace SNFramework.BSF.Moudles.SystemManage.OrginationDepartmentManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemOrganizationEdit")]
    public partial class UCSystemOrganizationEdit : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SystemOrganizationWrapper obj = SystemOrganizationWrapper.FindById(id);

                if (obj != null)
                {


                    if (obj.ParentID == null)
                    {
                        this.lblParentOrgName.Text = "As root org";
                    }
                    else
                    {
                        this.lblParentOrgName.Text =
                            obj.ParentID.Name;
                    }



                    this.txtName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    this.txtShortName.Text = ValueConvertUtil.ConvertStringValue(obj.ShortName);
                    this.txtCode.Text = ValueConvertUtil.ConvertStringValue(obj.Code);
                    this.txtDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
                    this.txtLogoUrl.Text = ValueConvertUtil.ConvertStringValue(obj.LogoUrl);
                    this.txtType.Text = ValueConvertUtil.ConvertStringValue(obj.Type);
                    this.txtMasterName.Text = ValueConvertUtil.ConvertStringValue(obj.MasterName);
                    this.chkIsMainOrganization.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsMainOrganization);
                    if (obj.ParentID != null)
                        this.txtParentID.Text = obj.ParentID.Name;
                    else
                        this.txtParentID.Text = "As Root Org";
                    this.txtTelPhone.Text = ValueConvertUtil.ConvertStringValue(obj.TelPhone);
                    this.txtFaxNumber.Text = ValueConvertUtil.ConvertStringValue(obj.FaxNumber);
                    this.txtWebSite.Text = ValueConvertUtil.ConvertStringValue(obj.WebSite);
                    this.txtEmail.Text = ValueConvertUtil.ConvertStringValue(obj.Email);





                    hidId.Text = id.ToString();


                    winSystemOrganizationEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "ErrorMessage:Data does not exist";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
                return;
            }
        }

        protected void btnSaveSystemOrganization_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemOrganizationWrapper obj = SystemOrganizationWrapper.FindById(int.Parse(hidId.Text.Trim()));
                obj.Name = this.txtName.Text.Trim();
                obj.ShortName = this.txtShortName.Text.Trim();
                obj.Code = this.txtCode.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.LogoUrl = this.txtLogoUrl.Text.Trim();
                obj.Type = this.txtType.Text.Trim();
                obj.MasterName = this.txtMasterName.Text.Trim();
                obj.IsMainOrganization = this.chkIsMainOrganization.Checked;
                obj.TelPhone = this.txtTelPhone.Text.Trim();
                obj.FaxNumber = this.txtFaxNumber.Text.Trim();
                obj.WebSite = this.txtWebSite.Text.Trim();
                obj.Email = this.txtEmail.Text.Trim();



                SystemOrganizationWrapper.Update(obj, this.ParentPage.CurrentLoginUser.UserID, "更新组织信息");

                winSystemOrganizationEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
                return;
            }

        }

    }
}