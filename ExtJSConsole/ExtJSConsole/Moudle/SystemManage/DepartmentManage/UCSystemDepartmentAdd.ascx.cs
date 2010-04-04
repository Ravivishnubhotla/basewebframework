using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace ExtJSConsole.Moudle.SystemManage.DepartmentManage
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
                    this.lblParentMenuName.Text = "作为根部门";
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
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
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

                SystemDepartmentWrapper.Save(obj);

                winSystemDepartmentAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }

}