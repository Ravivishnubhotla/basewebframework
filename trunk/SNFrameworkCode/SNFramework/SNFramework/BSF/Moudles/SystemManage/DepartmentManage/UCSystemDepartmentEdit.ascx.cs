using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace SNFramework.BSF.Moudles.SystemManage.DepartmentManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemDepartmentEdit")]
    public partial class UCSystemDepartmentEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SystemDepartmentWrapper obj = SystemDepartmentWrapper.FindById(id);

                if (obj != null)
                {

                    if (obj.ParentDepartmentID == null)
                    {
                        this.lblParentMenuName.Text = "As root department";
                    }
                    else
                    {
                        this.lblParentMenuName.Text = obj.ParentDepartmentID.DepartmentNameCn;
                    }


                    this.txtDepartmentNameCn.Text = obj.DepartmentNameCn.ToString();
                    this.txtDepartmentNameEn.Text = obj.DepartmentNameEn.ToString();
                    this.txtDepartmentDecription.Text = obj.DepartmentDecription.ToString();


                    hidDepartmentID.Text = id.ToString();


                    winSystemDepartmentEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "Error Message:Record not existed.";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(this.GetGlobalResourceObject("GlobalResource", "msgServerErrorMsg").ToString(), ex.Message);
                return;
            }
        }

        protected void btnSaveSystemDepartment_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemDepartmentWrapper obj = SystemDepartmentWrapper.FindById(int.Parse(hidDepartmentID.Text.Trim()));
                //obj.ParentDepartmentID = Convert.ToInt32(this.txtParentDepartmentID.Text.Trim());
                obj.DepartmentNameCn = this.txtDepartmentNameCn.Text.Trim();
                obj.DepartmentNameEn = this.txtDepartmentNameEn.Text.Trim();
                obj.DepartmentDecription = this.txtDepartmentDecription.Text.Trim();
                SystemDepartmentWrapper.Update(obj);

                winSystemDepartmentEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(this.GetGlobalResourceObject("GlobalResource", "msgServerErrorMsg").ToString(), ex.Message);
                return;
            }

        }
    }
}