using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;


namespace Legendigital.Common.WebApp.Moudles.SystemManage.RoleManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemRoleAssignedApplication")]
    public partial class UCSystemRoleAssignedApplication : System.Web.UI.UserControl
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
            List<SystemApplicationWrapper> list1 = SystemApplicationWrapper.FindAll();
            List<SystemApplicationWrapper> list2 = SystemRoleWrapper.GetRoleAssignedApplications(systemRoleWrapper);
            List<int> list = new List<int>();
            foreach(SystemApplicationWrapper wrapper in list2)
            {
                list.Add(wrapper.SystemApplicationID);
            }
            IEnumerable<SystemApplicationWrapper> list3 = list1.FindAll(p => !list.Contains(p.SystemApplicationID));
            Store1.DataSource = list3;
            Store1.DataBind();
        }

        private void InitStore2()
        {
            SystemRoleWrapper systemRoleWrapper = SystemRoleWrapper.FindById(RoleID);
            List<SystemApplicationWrapper> list2 = SystemRoleWrapper.GetRoleAssignedApplications(systemRoleWrapper);
            Store2.DataSource = list2;
            Store2.DataBind();
        }

        [DirectMethod]
        public void Save_RoleApplication(string json)
        {
            try
            {
                KeyValuePair<string, string>[] selectIDs = JSON.Deserialize<KeyValuePair<string, string>[]>(json);
                List<String> list = new List<string>();
                foreach (KeyValuePair<string, string> row in selectIDs)
                {
                    list.Add(row.Key);
                }
                SystemRoleWrapper.PatchAssignRoleApplications(SystemRoleWrapper.FindById(RoleID), list);
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