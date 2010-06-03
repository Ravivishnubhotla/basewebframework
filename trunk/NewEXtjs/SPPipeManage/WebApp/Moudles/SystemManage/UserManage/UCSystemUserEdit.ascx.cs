using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.UserManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemUserEdit")]
    public partial class UCSystemUserEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;
            Ext.Net.TreeNode root = InitRoot();
            LinqTree(null, root, 0);
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
                        if (department.ParentDepartmentID.DepartmentID == did)
                            return true;
                        else
                            return false;
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
                        if (department.ParentDepartmentID.DepartmentID == d.DepartmentID)
                            return true;
                        else
                            return false;
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

        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SystemUserWrapper obj = SystemUserWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtUserName.Text = Convert.ToString(obj.UserName);
                    this.txtUserEmail.Text = Convert.ToString(obj.UserEmail);
                    this.txtComments.Text = Convert.ToString(obj.Comments);

                    hidSystemUserID.Text = id.ToString();
                    if (obj.DepartmentID == null)
                    {
                        DropDownField1.SetValue("", "");
                    }
                    else
                    {
                        DropDownField1.SetValue(obj.DepartmentID.DepartmentNameEn, obj.DepartmentID.DepartmentID.ToString());
                    }
                    winSystemUserEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "错误信息：Data is not exist!";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }
        }

        protected void btnSaveSystemUser_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemUserWrapper obj = SystemUserWrapper.FindById(int.Parse(hidSystemUserID.Text.Trim()));
                obj.UserName = this.txtUserName.Text.Trim();
                obj.UserEmail = this.txtUserEmail.Text.Trim();
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
                winSystemUserEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }

        }
    }

}