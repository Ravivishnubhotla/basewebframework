using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Web.ControlHelper;
using MenuItem = System.Web.UI.WebControls.MenuItem;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.UserManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemUserAdd")]
    public partial class UCSystemUserAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;
            Ext.Net.TreeNode root = InitRoot();
            LinqTree(null, root, 0);
        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSystemUserAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSystemUser_Click(object sender, DirectEventArgs e)
        {
            string loginID = this.txtUserLoginID.Text.Trim();

            if (SystemUserWrapper.GetUserByLoginID(loginID) != null)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：User LoginID is exist!";
                return;
            }


            try
            {
                if (!string.IsNullOrEmpty(this.txtUserEmail.Text.Trim()))
                    Membership.CreateUser(loginID, this.txtUserPassword.Text.Trim(), this.txtUserEmail.Text.Trim());
                else
                    Membership.CreateUser(loginID, this.txtUserPassword.Text.Trim());


                SystemUserWrapper obj = SystemUserWrapper.GetUserByLoginID(loginID);


                if (obj != null)
                {
                    obj.UserName = this.txtUserName.Text.Trim();
                    obj.Comments = this.txtComments.Text.Trim();

                    object did = hiddenDepartment1.Value;
                    if (did != null)
                    {
                        string sdid = did.ToString();
                        if (!string.IsNullOrEmpty(sdid))
                        {
                            SystemDepartmentWrapper departmentWrapper = SystemDepartmentWrapper.FindById(Convert.ToInt32(sdid));
                            if (departmentWrapper != null)
                            {
                                obj.DepartmentID = departmentWrapper;
                            }
                        }
                    }

                    SystemUserWrapper.Update(obj);
                }
                winSystemUserAdd.Hide();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        private void LinqTree(List<SystemDepartmentWrapper> list, Ext.Net.TreeNode tnd, int did)
        {
            if (list == null)
            {
                list = SystemDepartmentWrapper.FindAll();
            }
            IEnumerable<SystemDepartmentWrapper> result = null;
            if (did == 0)
            {
                result = list.Where(department => department.ParentDepartmentID == null);
            }
            else
            {
                result = list.Where(delegate(SystemDepartmentWrapper department)
                {
                    if (department.ParentDepartmentID == null)
                    {
                        return false;
                    }
                    else
                    {
                        return department.ParentDepartmentID.DepartmentID == did ? true : false;
                    }
                });
            }

            foreach (SystemDepartmentWrapper d in result)
            {
                Ext.Net.TreeNode tn = new Ext.Net.TreeNode();
                tn.Qtip = d.DepartmentID.ToString(); ;
                tn.Text = d.DepartmentNameEn;
                tn.CustomAttributes.Add(new ConfigItem("did", d.DepartmentID.ToString(), ParameterMode.Value));
                tnd.Nodes.Add(tn);

                if (list.Exists(delegate(SystemDepartmentWrapper department)
                {
                    if (department.ParentDepartmentID == null)
                    {
                        return false;
                    }
                    else
                    {
                        return department.ParentDepartmentID.DepartmentID == d.DepartmentID ? true : false;
                    }
                }))
                {
                    LinqTree(list, tn, d.DepartmentID);
                }
            }
        }

        private Ext.Net.TreeNode InitRoot()
        {
            Ext.Net.TreeNode root = new Ext.Net.TreeNode();
            root.Draggable = false;
            root.Expanded = true;
            root.Text = "System Deparment";
            root.Qtip = "Deparment";
            TreePanel1.Root.Add(root);
            return root;
        }
    }
}