using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Legendigital.Framework.Common.BaseFramework;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using System.Web.Script.Serialization;
using Ext.Net;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.UserManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemUserAssignedRole")]
    public partial class UCSystemUserAssignedRole : System.Web.UI.UserControl
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
            SystemUserWrapper systemUserWrapper = SystemUserWrapper.FindById(UserID);
            List<SystemRoleWrapper> list1 = SystemRoleWrapper.FindAll();//得到所有的角色
            List<string> list2 = SystemUserWrapper.GetUserAssignedRoleIDs(systemUserWrapper);//得到用户的所有角色编号
            List<SystemRoleWrapper> list3 = list1.FindAll(p => !list2.Contains(p.RoleID.ToString()));
            Store1.DataSource = list3;
            Store1.DataBind();
        }

        private void InitStore2()
        {
            SystemUserWrapper systemUserWrapper = SystemUserWrapper.FindById(UserID);
            List<string> list2 = SystemUserWrapper.GetUserAssignedRoleIDs(systemUserWrapper);
            List<SystemRoleWrapper> list3 = new List<SystemRoleWrapper>();
            foreach (string s in list2)
            {
                list3.Add(SystemRoleWrapper.FindById(Int32.Parse(s)));
            }
            Store2.DataSource = list3;
            Store2.DataBind();
        }

        [DirectMethod]
        public void Save_UserRole(string json)
        {
            try
            {
                KeyValuePair<string, string>[] selectIDs = JSON.Deserialize<KeyValuePair<string, string>[]>(json);
                List<String> list = new List<string>();
                foreach (KeyValuePair<string, string> row in selectIDs)
                {
                    list.Add(row.Key);
                }
                SystemUserWrapper.PatchAssignUserRoles(SystemUserWrapper.FindById(UserID), list);
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }

        [DirectMethod]
        public void Show(int userID)
        {
            try
            {
                this.UserID = userID;
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

        public int UserID
        {
            get
            {
                object obj = HiddenUserID.Value;
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
                this.HiddenUserID.Value = value;
            }
        }
    } 
}