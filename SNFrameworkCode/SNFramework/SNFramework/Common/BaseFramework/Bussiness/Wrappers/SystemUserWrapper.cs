
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Xml;
using Common.Logging;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Commons;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Aop;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using Legendigital.Framework.Common.BaseFramework.Providers;
using Legendigital.Framework.Common.BaseFramework.Web;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Exceptions;
using Legendigital.Framework.Common.Utility;
using Spring.Context.Support;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
    [Serializable]
    public partial class SystemUserWrapper : BaseAuditableWrapper<SystemUserEntity, ISystemUserServiceProxy, SystemUserWrapper, int>
    {
        public static string DEV_USER_ID = "DeveloperAdministrator";
        public static string SYS_USER_ID = "SystemAdministrator";
        public static string SYSOPTOR_USER_ID = "SystemOperator";



        #region Static Common Data Operation

        public static void Save(SystemUserWrapper obj, int saveUserID)
        {
            obj.CreateAt = System.DateTime.Now;
            obj.CreateBy = saveUserID;
            obj.LastModifyComment = string.Format("创建用户'{0}'成功！", obj.UserLoginID);
            Save(obj, businessProxy);
        }

        public static void Update(SystemUserWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemUserWrapper obj)
        {
            SaveOrUpdate(obj, businessProxy);
        }

        public static void DeleteAll()
        {
            DeleteAll(businessProxy);
        }

        public static void DeleteByID(int id)
        {
            DeleteByID(id, businessProxy);
        }

        public static void PatchDeleteByIDs(int[] ids)
        {

            PatchDeleteByIDs(ids, businessProxy);
        }

        public static void Delete(SystemUserWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemUserWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemUserWrapper FindById(int id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemUserWrapper> FindAll()
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemUserWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }

        public static List<SystemUserWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemUserWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams, businessProxy));     
        }


        public static List<SystemUserWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            orderByFieldName = ProcessColumnName(orderByFieldName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy)); 
        }

        #endregion

        #region 构造器

 

 

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


        public static string EncodePassword(int userPasswordFormat,string password, string validationKey)
        {
            MembershipPasswordFormat passwordFormat = (MembershipPasswordFormat) userPasswordFormat;

            string str = password;
            switch (passwordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    return str;

                case MembershipPasswordFormat.Hashed:
                    {
                        return str;
                        //if (string.IsNullOrEmpty(validationKey))
                        //{
                        //    validationKey = machineKey.ValidationKey;
                        //}
                        //var hmacsha = new HMACSHA1 { Key = HexToByte(validationKey) };
                        //return Convert.ToBase64String(hmacsha.ComputeHash(Encoding.Unicode.GetBytes(password)));
                    }
                case MembershipPasswordFormat.Encrypted:
                    return str;
                    //return Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)));
            }

            return str;
        }
 

        public static void ChangePassword(string loginID, string newPassword)
        {
            SystemUserWrapper user = SystemUserWrapper.FindByLoginID(loginID);

            if (user == null)
                return;


            user.UserPassword = EncodePassword(user.PasswordFormat, newPassword, user.PasswordSalt);
            user.LastPasswordChangeDate = DateTime.Now;
            user.LastActivityDate = DateTime.Now;
            SystemUserWrapper.Update(user);
   
        }

        /// <summary>
        /// 通过用户登陆ID获取用户
        /// </summary>
        /// <param name="loginID"></param>
        /// <returns></returns>
        public static SystemUserWrapper FindByLoginID(string loginID)
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

        /// <summary>
        /// 生成SSO单点登陆Key
        /// </summary>
        /// <param name="loginID">用户ID</param>
        /// <returns></returns>
        public static string GenerateSSOKey(string loginID)
        {
            string ssoKey = Guid.NewGuid().ToString();

            SystemUserWrapper user = SystemUserWrapper.FindByLoginID(loginID);

            if (user!=null)
            {
                user.SSOKey = ssoKey;
                SystemUserWrapper.Update(user);
                return ssoKey;
            }

            return "";
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

        public static List<SystemRoleWrapper> GetUserWrappersAssignedRoleIDs(SystemUserWrapper userWrapper)
        {
            if (userWrapper == null)
                throw new ArgumentNullException("userWrapper");

            List<SystemRoleEntity> assignedRoles = businessProxy.GetUserAssignedRoleByUser(userWrapper.entity);

            return SystemRoleWrapper.ConvertToWrapperList(assignedRoles);
        }

        /// <summary>
        /// 获取用户分配的所有的用户组
        /// </summary>
        /// <param name="userWrapper"></param>
        /// <returns></returns>
        public static List<string> GetUserAssignedGroupIDs(SystemUserWrapper userWrapper)
        {
            if (userWrapper == null)
                throw new ArgumentNullException("userWrapper");

            List<SystemUserGroupEntity> assignedGroups = businessProxy.GetUserAssignedGroupsByUser(userWrapper.entity);

            List<string> groupsIDs = new List<string>();

            foreach (SystemUserGroupEntity group in assignedGroups)
            {
                groupsIDs.Add(group.GroupID.ToString());
            }

            return groupsIDs;
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

            if (businessProxy.CheckUserIfDeveloperAdminOrSystemAdmin(userWrapper.UserLoginID))
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

        public static void PatchAssignUserUserGroups(SystemUserWrapper userWrapper, List<string> usergroupids)
        {
            if (userWrapper == null)
                throw new ArgumentNullException("userWrapper");
            if (usergroupids == null)
                throw new ArgumentNullException("usergroupids");

            businessProxy.PatchAssignUserUserGroups(userWrapper.entity, usergroupids);
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

  
        public static SystemRoleWrapper GetUserMaxRoleTypeRole(SystemUserWrapper userWrapper)
        {
            return SystemRoleWrapper.ConvertEntityToWrapper(businessProxy.GetUserMaxRoleTypeRole(userWrapper.entity));
        }

        public static SystemRoleWrapper GetUserMinRoleTypeRole(SystemUserWrapper userWrapper)
        {
            return SystemRoleWrapper.ConvertEntityToWrapper(businessProxy.GetUserMinRoleTypeRole(userWrapper.entity));
        }

        public static List<SystemRoleWrapper> GetUserAssignedRoleByUserLoginId(string loginId)
        {
            return businessProxy.GetUserAssignedRoleByUserLoginId(loginId);
        }

        public static SystemRoleWrapper GetUserDefaultRoleByUserID(int userID)
        {
            return SystemRoleWrapper.ConvertEntityToWrapper(businessProxy.GetUserDefaultRoleByUserID(userID));
        }

        public static void SetUserDefaultRole(int userID,int roleID)
        {
            businessProxy.SetUserDefaultRole(userID,roleID);
        }

        public static bool UnlockUser(string userName)
        {
            return businessProxy.LockUser(userName, false);
        }

        public static void UnlockByIDS(List<int> ids)
        {
            businessProxy.LockByIDS(ids, false);
        }


        public static void LockByIDS(List<int> ids)
        {
            businessProxy.LockByIDS(ids, true);
        }


        public static bool CheckUserIfDeveloperAdminOrSystemAdmin(string loginID)
        {
            return businessProxy.CheckUserIfDeveloperAdminOrSystemAdmin(loginID);
        }

        public static bool SaveFirstChangePassword(string loginID, string newPassword)
        {
            try
            {
                businessProxy.SaveFirstChangePassword(loginID, newPassword);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }
        }

        public static int QuickAddUser(string loginID, string roleCode,string defaultPassword,string defaultEmail)
        {
            try
            {
                Membership.CreateUser(loginID, defaultPassword, loginID + defaultEmail);

                SystemUserWrapper user = SystemUserWrapper.FindByLoginID(loginID);

                user.UserName = loginID;

                SystemUserWrapper.Update(user);

                SystemRoleWrapper clientRole = SystemRoleWrapper.GetRoleByCode(roleCode);

                SystemUserWrapper.PatchAssignUserRoles(user, new List<string> { clientRole.RoleID.ToString() });

                return user.UserID;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return -1;
            }
        }


        public static List<SystemUserWrapper> FindAllByOrderByExpcept(string sortFieldName, bool isDesc, List<string> expceptUserLoginId, List<string> expceptRoleName, PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByExpcept(sortFieldName, isDesc, expceptUserLoginId, expceptRoleName, pageQueryParams));
        }

        public static void CreateDeveUser(string defaultPassword)
        {
            Membership.CreateUser(DEV_USER_ID, defaultPassword, DEV_USER_ID + "@163.ocm");

            SystemUserWrapper user = SystemUserWrapper.FindByLoginID(DEV_USER_ID);

            user.UserName = DEV_USER_ID;

            SystemUserWrapper.Update(user);
        }

        public static void CreateSysAdminUser(string defaultPassword)
        {
            Membership.CreateUser(SYS_USER_ID, defaultPassword, DEV_USER_ID + "@163.ocm");

            SystemUserWrapper user = SystemUserWrapper.FindByLoginID(SYS_USER_ID);

            user.UserName = SYS_USER_ID;

            SystemUserWrapper.Update(user);
        }

        public static void CreateSysOperatorUser()
        {
            Membership.CreateUser(SYSOPTOR_USER_ID, StringUtil.GetRandNumber(6), DEV_USER_ID + "@163.ocm");

            SystemUserWrapper user = SystemUserWrapper.FindByLoginID(SYSOPTOR_USER_ID);

            user.UserName = SYSOPTOR_USER_ID;

            user.IsApproved = false;

            user.IsLockedOut = false;

            SystemUserWrapper.Update(user);
        }


        public static int GetDeveUserID()
        {
            SystemUserWrapper user = GetInitalUserByLoginID(DEV_USER_ID);

            if(user!=null)
                return user.UserID;

            return 0;
        }

        public static int GetSysAdminUserID()
        {
            SystemUserWrapper user = GetInitalUserByLoginID(SYS_USER_ID);

            if (user != null)
                return user.UserID;

            return 0;
        }

        public static int GetSysOperatorUserID()
        {
            SystemUserWrapper user = GetInitalUserByLoginID(SYSOPTOR_USER_ID);

            if (user != null)
                return user.UserID;
            else
                CreateSysOperatorUser();

            user = GetInitalUserByLoginID(SYSOPTOR_USER_ID);

            if (user != null)
                return user.UserID;

            return 0;
        }


        public static int GetCurrentOperateUserID()
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.User != null)
                {
                    return SystemUserWrapper.GetInitalUserByLoginID(HttpContext.Current.User.Identity.Name).UserID;
                }
                if (HttpContext.Current.Session[BaseSecurityPage.Session_Key_LoginUser] != null)
                {
                    return
                        ((SystemUserWrapper)HttpContext.Current.Session[BaseSecurityPage.Session_Key_LoginUser]).UserID;
                }
            }

            return SystemUserWrapper.GetSysOperatorUserID();
        }

        public override int? GetDataCreateBy()
        {
            return this.CreateBy;
        }

        public override DateTime? GetDataCreateAt()
        {
            return this.CreateAt;
        }

        public override int? GetDataLastModifyBy()
        {
            return this.LastModifyBy;
        }

        public override DateTime? GetDataLastModifyAt()
        {
            return this.LastModifyAt;
        }

        public override string GetDataLastModifyComment()
        {
            return this.LastModifyComment;
        }

        public override string GetEntityTypeName()
        {
            return "用户";
        }

        public override string GetEntityName()
        {
            return this.UserLoginID;
        }

        public override string GetEntityID()
        {
            return this.UserID.ToString();
        }

        public override string GetEntityNo()
        {
            return this.UserLoginID;
        }
    }
}
