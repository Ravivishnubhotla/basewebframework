
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using Legendigital.Framework.Common.BaseFramework.Providers;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Exceptions;
using Spring.Context.Support;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    public partial class SystemUserWrapper
    {
        public const string DEV_USER_ID = "DeveloperAdministrator";
        public const string SYS_USER_ID = "SystemAdministrator";

        #region Static Common Data Operation
		
		public static void Save(SystemUserWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemUserWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemUserWrapper obj)
        {
            businessProxy.SaveOrUpdate(obj.entity);
        }

        public static void DeleteAll()
        {
            businessProxy.DeleteAll();
        }

        public static void DeleteByID(object id)
        {
            businessProxy.DeleteByID(id);
        }

        public static void PatchDeleteByIDs(object[] ids)
        {

            businessProxy.PatchDeleteByIDs(ids);
        }

        public static void Delete(SystemUserWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemUserWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemUserWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemUserWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemUserWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SystemUserEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SystemUserWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SystemUserWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SystemUserWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

		
		#endregion

	    #region 构造器

	    public SystemUserWrapper(int id)
	    {
	        UserCreateDate = DateTime.Now;
	        LastActivityDate = DateTime.Now;
	        LastLoginDate = DateTime.Now;
	        LastLockedOutDate = DateTime.Now;
	        LastPasswordChangeDate = DateTime.Now;
	        FailedPwdAnsAttemptWndStart = DateTime.Now;
	        FailedPwdAttemptWndStart = DateTime.Now;
	        Applications = new ArrayList();
	        UserID = id;
	    }

	    public SystemUserWrapper(string name) // : base(name)
	    {
	        UserCreateDate = DateTime.Now;
	        LastActivityDate = DateTime.Now;
	        LastLoginDate = DateTime.Now;
	        LastLockedOutDate = DateTime.Now;
	        LastPasswordChangeDate = DateTime.Now;
	        FailedPwdAnsAttemptWndStart = DateTime.Now;
	        FailedPwdAttemptWndStart = DateTime.Now;
	        Applications = new ArrayList();
	    }

	    #endregion



        internal static readonly ISystemPrivilegeServiceProxy systemPrivilegeParameterServiceProxy = ((BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(BaseFrameworkServiceProxyContainer)))).SystemPrivilegeServiceProxyInstance;



        private IList applications = null;

        public IList Applications
        {
            get
            {
                if (applications == null)
                    applications = new ArrayList();
                return applications;
            }
            set
            {
                applications = value;
            }
        }

        public SystemUserWrapper FromMembershipUser(MembershipUser mu)
        {
            UserID = Convert.ToInt32(mu.ProviderUserKey);
            UserLoginID = mu.UserName;
            UserEmail = mu.Email;
            PasswordQuestion = mu.PasswordQuestion;
            Comments = mu.Comment;
            IsApproved = mu.IsApproved;
            IsLockedOut = mu.IsLockedOut;
            UserCreateDate = mu.CreationDate;
            LastActivityDate = mu.LastActivityDate;
            LastLoginDate = mu.LastLoginDate;
            LastPasswordChangeDate = mu.LastPasswordChangedDate;
            LastLockedOutDate = mu.LastLockoutDate;
            return this;
        }

        public MembershipUser ToMembershipUser(string providerName)
        {
            return new MembershipUser(providerName, UserLoginID, UserID, UserEmail, PasswordQuestion, Comments,
                                      IsApproved, IsLockedOut, UserCreateDate, LastLoginDate,
                                      LastActivityDate, LastPasswordChangeDate, LastLockedOutDate);
        }

        public static bool IsUserInRole(string username, string roleName)
        {
            return businessProxy.IsUserInRole(username, roleName);
        }

        public static string[] GetRolesForUser(string username)
        {
            return businessProxy.GetRolesForUser(username);
        }

        /// <summary>
        /// 通过用户登陆ID获取用户
        /// </summary>
        /// <param name="loginID"></param>
        /// <returns></returns>
        public static SystemUserWrapper GetUserByLoginID(string loginID)
        {
            return businessProxy.GetUserByLoginId(loginID);
        }

        /// <summary>
        /// 通过用户ID获取初始化系统用户
        /// </summary>
        /// <param name="loginID"></param>
        /// <returns></returns>
        public static SystemUserWrapper GetInitalUserByLoginID(string loginID)
        {
            return businessProxy.GetInitalUserByLoginID(loginID);
        }
        /// <summary>
        /// 通过Email获取系统用户
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static SystemUserWrapper GetUserByEmail(string email)
        {
            return businessProxy.GetUserByEmail(email);
        }
        /// <summary>
        /// 通过用户登陆ID删除用户
        /// </summary>
        /// <param name="loginID">登陆ID</param>
        /// <param name="deleteAllRelatedData"></param>
        public static void DeleteUser(string loginID, bool deleteAllRelatedData)
        {
            businessProxy.DeleteUser(loginID, deleteAllRelatedData);
        }

        public static List<SystemUserWrapper> FindAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            return businessProxy.FindAllUsers(pageIndex, pageSize, out totalRecords);
        }

        public static int FindOnlineUsersCount(DateTime time)
        {
            return businessProxy.FindOnlineUsersCount(time);
        }

        public static List<SystemUserWrapper> FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            return businessProxy.FindUsersByLoginId(usernameToMatch, pageIndex, pageSize, out totalRecords);
        }

        public static List<SystemUserWrapper> FindUsersByEmail(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            return businessProxy.FindUsersByEmail(usernameToMatch, pageIndex, pageSize, out totalRecords);
        }

        /// <summary>
        /// 获取用户分配的所有的角色
        /// </summary>
        /// <param name="userWrapper"></param>
        /// <returns></returns>
        public static List<string> GetUserAssignedRoleIDs(SystemUserWrapper userWrapper)
        {
            if (userWrapper == null)
                throw new ArgumentNullException("userWrapper");

            List<SystemRoleEntity> assignedRoles = businessProxy.GetUserAssignedRoleByUser(userWrapper.entity);

            List<string> roleIDs = new List<string>();

            foreach (SystemRoleEntity role in assignedRoles)
            {
                roleIDs.Add(role.RoleID.ToString());
            }

            return roleIDs;
        }

        /// <summary>
        /// 用户是否具备权限
        /// </summary>
        /// <param name="userWrapper"></param>
        /// <param name="permissionCode"></param>
        /// <returns></returns>
        public static bool UserHasPermission(SystemUserWrapper userWrapper, string permissionCode)
        {
            if (userWrapper == null)
                throw new ArgumentNullException("userWrapper");
            if (string.IsNullOrEmpty(permissionCode))
                throw new ArgumentNullException("permissionCode");

            if(businessProxy.CheckUserIfDeveloperAdminOrSystemAdmin(userWrapper))
                return true;

            SystemPrivilegeEntity permission = systemPrivilegeParameterServiceProxy.FindByPermissionCode(permissionCode);

            if (permission == null)
                throw new ArgumentNullException(string.Format("Permission '{0}' not existed!", permissionCode), "permissionCode");

            return businessProxy.UserHasPermission(userWrapper.entity, permission);
        }

        /// <summary>
        /// 批量更新用户分配的角色
        /// </summary>
        /// <param name="userWrapper"></param>
        /// <param name="roleids"></param>
        public static void PatchAssignUserRoles(SystemUserWrapper userWrapper, List<string> roleids)
        {
            if (userWrapper == null)
                throw new ArgumentNullException("userWrapper");
            if (roleids == null)
                throw new ArgumentNullException("roleids");

            businessProxy.PatchAssignUserRoles(userWrapper.entity, roleids);
        }

        /// <summary>
        /// 分页获取所有的通过认证的用户
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
	    public static List<SystemUserWrapper> FindAuthenticatedUserAll(int pageIndex, int pageSize, out int totalRecords)
	    {
            return ConvertToWrapperList(businessProxy.FindAuthenticatedUserAll(pageIndex, pageSize, out totalRecords));
	    }

        /// <summary>
        /// 用户类型显示名
        /// </summary>
        public string DisplayNameUserType
        {
            get { return SysDictionaryWrapper.ParseUserRoleTypeDictionaryKey(this.UserType); }
        }





    }
}
