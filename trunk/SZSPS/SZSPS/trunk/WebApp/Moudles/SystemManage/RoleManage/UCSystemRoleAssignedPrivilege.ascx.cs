using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using System.Web.Script.Serialization;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.RoleManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemRoleAssignedPrivilege")]
    public partial class UCSystemRoleAssignedPrivilege : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;
        }

        protected void Store1_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            //List<SystemPrivilegeWrapper> list1 = SystemPrivilegeWrapper.FindAll();
            //Store1.DataSource = list1;
            //Store1.DataBind();
        }

        protected void Store2_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            //List<SystemPrivilegeWrapper> warppers = e.Object<SystemPrivilegeWrapper>();
            //List<SystemPrivilegeWrapper> warppers = new JavaScriptSerializer().Deserialize<List<SystemPrivilegeWrapper>>(json);
            //foreach (SystemPrivilegeWrapper warpper in warppers)
            //{
            //    list.Add(warpper.PrivilegeID.ToString());
            //}
        }

        private void InitStore1()
        {
            SystemRoleWrapper systemRoleWrapper = SystemRoleWrapper.FindById(RoleID);
            List<SystemPrivilegeWrapper> list1 = SystemPrivilegeWrapper.FindAll();
            List<string> list2 = SystemRoleWrapper.GetRoleAssignedPermissions(systemRoleWrapper);
            List<SystemPrivilegeWrapper> list3 = list1.FindAll(p => !list2.Contains(p.PrivilegeID.ToString()));
            Store1.DataSource = list3;
            Store1.DataBind();
        }

        private void InitStore2()
        {
            SystemRoleWrapper systemRoleWrapper = SystemRoleWrapper.FindById(RoleID);
            List<string> list2 = SystemRoleWrapper.GetRoleAssignedPermissions(systemRoleWrapper);
            List<SystemPrivilegeWrapper> list3 = new List<SystemPrivilegeWrapper>();
            foreach (string s in list2)
            {
                list3.Add(SystemPrivilegeWrapper.FindById(Int32.Parse(s)));
            }
            Store2.DataSource = list3;
            Store2.DataBind();
        }

        [DirectMethod]
        public void Save_RolePermission(string json)
        {
            try
            {
                KeyValuePair<string, string>[] selectIDs = JSON.Deserialize<KeyValuePair<string, string>[]>(json);
                List<String> list = new List<string>();
                foreach (KeyValuePair<string, string> row in selectIDs)
                {
                    list.Add(row.Key);
                }
                SystemRoleWrapper.PatchAssignRolePermissions(SystemRoleWrapper.FindById(RoleID), list);
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }

        [DirectMethod]
        public void Show(int roleID)
        {
            try
            {
                this.RoleID = roleID;
                InitStore1();
                InitStore2();
                this.Window1.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }

        public int RoleID
        {
            get
            {
                object obj = HiddenRoleID.Value;
                int i = 0;
                if (obj != null)
                {
                    if (!String.IsNullOrEmpty(obj.ToString()))
                    {
                        i = Convert.ToInt32(obj);
                    }
                }
                return i;
            }
            set
            {
                this.HiddenRoleID.Value = value;
            }
        }
    }
}