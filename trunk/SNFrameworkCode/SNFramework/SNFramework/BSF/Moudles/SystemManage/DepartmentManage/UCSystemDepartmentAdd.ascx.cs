using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace SNFramework.BSF.Moudles.SystemManage.DepartmentManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemDepartmentAdd")]
    public partial class UCSystemDepartmentAdd : System.Web.UI.UserControl
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
                    this.lblParentMenuName.Text = "As root department";
                }
                else
                {
                    this.lblParentMenuName.Text =
                        SystemDepartmentWrapper.FindById(pID).DepartmentNameCn;
                }

                this.hidParentDepartmentID.Value = pID;


                this.winSystemDepartmentAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(this.GetGlobalResourceObject("GlobalResource", "msgServerErrorMsg").ToString(), ex.Message);
            }
        }


        public int OrginationID
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString["OrginationID"]))
                {
                    return Convert.ToInt32(this.Request.QueryString["OrginationID"]);
                }
                return 0;
            }
        }

        protected void btnSaveSystemDepartment_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemDepartmentWrapper obj = new SystemDepartmentWrapper();

                int pid = Convert.ToInt32(this.hidParentDepartmentID.Value);

                if (pid > 0)
                {
                    obj.ParentDepartmentID = SystemDepartmentWrapper.FindById(pid);
                }
                else
                {
                    obj.ParentDepartmentID = null;
                }

                obj.DepartmentNameCn = this.txtDepartmentNameCn.Text.Trim();
                obj.DepartmentNameEn = this.txtDepartmentNameEn.Text.Trim();
                obj.DepartmentDecription = this.txtDepartmentDecription.Text.Trim();
                obj.DepartmentSortIndex = SystemDepartmentWrapper.GetNewMaxOrder(pid);
                obj.OrganizationID = SystemOrganizationWrapper.FindById(OrginationID);
                SystemDepartmentWrapper.Save(obj);

                winSystemDepartmentAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(this.GetGlobalResourceObject("GlobalResource", "msgServerErrorMsg").ToString(), ex.Message);
            }
        }
    }
}