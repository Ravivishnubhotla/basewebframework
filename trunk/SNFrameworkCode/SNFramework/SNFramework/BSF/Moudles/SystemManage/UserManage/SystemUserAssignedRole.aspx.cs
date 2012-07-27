using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace SNFramework.BSF.Moudles.SystemManage.UserManage
{
    public partial class SystemUserAssignedRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;
        }

        protected void Store1_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            SystemUserWrapper systemUserWrapper = SystemUserWrapper.FindById(UserID);
            List<SystemRoleWrapper> list1 = SystemRoleWrapper.FindAll();//得到所有的角色
            List<string> list2 = SystemUserWrapper.GetUserAssignedRoleIDs(systemUserWrapper);//得到用户的所有角色编号
            List<SystemRoleWrapper> list3 = list1.FindAll(p => !list2.Contains(p.RoleID.ToString()));
            Store1.DataSource = list3;
            Store1.DataBind();
        }

        protected void Store2_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
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
                List<SystemRoleWrapper> selectIDs = JSON.Deserialize<List<SystemRoleWrapper>>(json);
                List<String> list = new List<string>();
                foreach (SystemRoleWrapper row in selectIDs)
                {
                    list.Add(row.RoleID.ToString());
                }
                SystemUserWrapper.PatchAssignUserRoles(SystemUserWrapper.FindById(UserID), list);
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(this.GetGlobalResourceObject("GlobalResource", "msgServerErrorMsg").ToString(), ex.Message);
            }
        }



        public int UserID
        {
            get
            {
                if (this.Request.QueryString["UserID"] == null)
                {
                    return 0;
                }
                return Convert.ToInt32(this.Request.QueryString["UserID"]);
            }
        }
    }
}