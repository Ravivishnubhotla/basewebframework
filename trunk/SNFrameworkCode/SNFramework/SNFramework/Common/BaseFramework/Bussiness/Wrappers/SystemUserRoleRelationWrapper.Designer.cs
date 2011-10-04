// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Spring.Context.Support;
using Common.Logging;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
    public partial class SystemUserRoleRelationWrapper
    {
        #region Member

		internal static readonly ISystemUserRoleRelationServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemUserRoleRelationServiceProxyInstance;
	 
	 
        internal SystemUserRoleRelationEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SystemUserRoleRelationWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SystemUserRoleRelationWrapper() : this(new SystemUserRoleRelationEntity())
        {
            
        }

        internal SystemUserRoleRelationWrapper(SystemUserRoleRelationEntity entityObj)
        {
            entity = entityObj;
        }
		#endregion
		
		#region Equals 和 HashCode 方法覆盖
		public override bool Equals(object obj)
        {
            if (obj == null && entity!=null)
            {
                if (entity.UserRoleID == 0)
                    return true;

                return false;
            }
            return entity.Equals(obj);
        }

        public override int GetHashCode()
        {
            return entity.GetHashCode();
        }
		#endregion
		
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemUserRoleRelationEntity";
		public static readonly string PROPERTY_NAME_USERROLEID = "UserRoleID";
		public static readonly string PROPERTY_NAME_USERID = "UserID";
		public static readonly string PROPERTY_NAME_ROLEID = "RoleID";
		
        #endregion
	
 
		#region userID字段外键查询字段
        public static readonly string PROPERTY_USERID_ALIAS_NAME = "UserID_SystemUserRoleRelationEntity_Alias";
		public static readonly string PROPERTY_USERID_USERID = "UserID_SystemUserRoleRelationEntity_Alias.UserID";
		public static readonly string PROPERTY_USERID_USERLOGINID = "UserID_SystemUserRoleRelationEntity_Alias.UserLoginID";
		public static readonly string PROPERTY_USERID_USERNAME = "UserID_SystemUserRoleRelationEntity_Alias.UserName";
		public static readonly string PROPERTY_USERID_USEREMAIL = "UserID_SystemUserRoleRelationEntity_Alias.UserEmail";
		public static readonly string PROPERTY_USERID_USERPASSWORD = "UserID_SystemUserRoleRelationEntity_Alias.UserPassword";
		public static readonly string PROPERTY_USERID_USERSTATUS = "UserID_SystemUserRoleRelationEntity_Alias.UserStatus";
		public static readonly string PROPERTY_USERID_USERCREATEDATE = "UserID_SystemUserRoleRelationEntity_Alias.UserCreateDate";
		public static readonly string PROPERTY_USERID_USERTYPE = "UserID_SystemUserRoleRelationEntity_Alias.UserType";
		public static readonly string PROPERTY_USERID_DEPARTMENTID = "UserID_SystemUserRoleRelationEntity_Alias.DepartmentID";
		public static readonly string PROPERTY_USERID_MOBILEPIN = "UserID_SystemUserRoleRelationEntity_Alias.MobilePIN";
		public static readonly string PROPERTY_USERID_PASSWORDFORMAT = "UserID_SystemUserRoleRelationEntity_Alias.PasswordFormat";
		public static readonly string PROPERTY_USERID_PASSWORDQUESTION = "UserID_SystemUserRoleRelationEntity_Alias.PasswordQuestion";
		public static readonly string PROPERTY_USERID_PASSWORDANSWER = "UserID_SystemUserRoleRelationEntity_Alias.PasswordAnswer";
		public static readonly string PROPERTY_USERID_COMMENTS = "UserID_SystemUserRoleRelationEntity_Alias.Comments";
		public static readonly string PROPERTY_USERID_ISAPPROVED = "UserID_SystemUserRoleRelationEntity_Alias.IsApproved";
		public static readonly string PROPERTY_USERID_ISLOCKEDOUT = "UserID_SystemUserRoleRelationEntity_Alias.IsLockedOut";
		public static readonly string PROPERTY_USERID_LASTACTIVITYDATE = "UserID_SystemUserRoleRelationEntity_Alias.LastActivityDate";
		public static readonly string PROPERTY_USERID_LASTLOGINDATE = "UserID_SystemUserRoleRelationEntity_Alias.LastLoginDate";
		public static readonly string PROPERTY_USERID_LASTLOCKEDOUTDATE = "UserID_SystemUserRoleRelationEntity_Alias.LastLockedOutDate";
		public static readonly string PROPERTY_USERID_LASTPASSWORDCHANGEDATE = "UserID_SystemUserRoleRelationEntity_Alias.LastPasswordChangeDate";
		public static readonly string PROPERTY_USERID_FAILEDPWDATTEMPTCNT = "UserID_SystemUserRoleRelationEntity_Alias.FailedPwdAttemptCnt";
		public static readonly string PROPERTY_USERID_FAILEDPWDATTEMPTWNDSTART = "UserID_SystemUserRoleRelationEntity_Alias.FailedPwdAttemptWndStart";
		public static readonly string PROPERTY_USERID_FAILEDPWDANSATTEMPTCNT = "UserID_SystemUserRoleRelationEntity_Alias.FailedPwdAnsAttemptCnt";
		public static readonly string PROPERTY_USERID_FAILEDPWDANSATTEMPTWNDSTART = "UserID_SystemUserRoleRelationEntity_Alias.FailedPwdAnsAttemptWndStart";
		public static readonly string PROPERTY_USERID_ISNEEDCHGPWD = "UserID_SystemUserRoleRelationEntity_Alias.IsNeedChgPwd";
		public static readonly string PROPERTY_USERID_PASSWORDSALT = "UserID_SystemUserRoleRelationEntity_Alias.PasswordSalt";
		public static readonly string PROPERTY_USERID_LOWEREDEMAIL = "UserID_SystemUserRoleRelationEntity_Alias.LoweredEmail";
		public static readonly string PROPERTY_USERID_CREATEBY = "UserID_SystemUserRoleRelationEntity_Alias.CreateBy";
		public static readonly string PROPERTY_USERID_CREATEAT = "UserID_SystemUserRoleRelationEntity_Alias.CreateAt";
		public static readonly string PROPERTY_USERID_LASTMODIFYBY = "UserID_SystemUserRoleRelationEntity_Alias.LastModifyBy";
		public static readonly string PROPERTY_USERID_LASTMODIFYAT = "UserID_SystemUserRoleRelationEntity_Alias.LastModifyAt";
		public static readonly string PROPERTY_USERID_LASTMODIFYCOMMENT = "UserID_SystemUserRoleRelationEntity_Alias.LastModifyComment";
		#endregion
		#region roleID字段外键查询字段
        public static readonly string PROPERTY_ROLEID_ALIAS_NAME = "RoleID_SystemUserRoleRelationEntity_Alias";
		public static readonly string PROPERTY_ROLEID_ROLEID = "RoleID_SystemUserRoleRelationEntity_Alias.RoleID";
		public static readonly string PROPERTY_ROLEID_ROLENAME = "RoleID_SystemUserRoleRelationEntity_Alias.RoleName";
		public static readonly string PROPERTY_ROLEID_ROLECODE = "RoleID_SystemUserRoleRelationEntity_Alias.RoleCode";
		public static readonly string PROPERTY_ROLEID_ROLEDESCRIPTION = "RoleID_SystemUserRoleRelationEntity_Alias.RoleDescription";
		public static readonly string PROPERTY_ROLEID_ROLEISSYSTEMROLE = "RoleID_SystemUserRoleRelationEntity_Alias.RoleIsSystemRole";
		public static readonly string PROPERTY_ROLEID_ROLETYPE = "RoleID_SystemUserRoleRelationEntity_Alias.RoleType";
		public static readonly string PROPERTY_ROLEID_CREATEBY = "RoleID_SystemUserRoleRelationEntity_Alias.CreateBy";
		public static readonly string PROPERTY_ROLEID_CREATEAT = "RoleID_SystemUserRoleRelationEntity_Alias.CreateAt";
		public static readonly string PROPERTY_ROLEID_LASTMODIFYBY = "RoleID_SystemUserRoleRelationEntity_Alias.LastModifyBy";
		public static readonly string PROPERTY_ROLEID_LASTMODIFYAT = "RoleID_SystemUserRoleRelationEntity_Alias.LastModifyAt";
		public static readonly string PROPERTY_ROLEID_LASTMODIFYCOMMENT = "RoleID_SystemUserRoleRelationEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		


		#region Public Property
		/// <summary>
		/// ??
		/// </summary>		
		public int UserRoleID
		{
			get
			{
				return entity.UserRoleID;
			}
			set
			{
				entity.UserRoleID = value;
			}
		}
		/// <summary>
		/// ??ID
		/// </summary>		
		public SystemUserWrapper UserID
		{
			get
			{
				return SystemUserWrapper.ConvertEntityToWrapper(entity.UserID) ;
			}
			set
			{
				entity.UserID = ((value == null) ? null : value.entity);
			}
		}
		/// <summary>
		/// ??ID
		/// </summary>		
		public SystemRoleWrapper RoleID
		{
			get
			{
				return SystemRoleWrapper.ConvertEntityToWrapper(entity.RoleID) ;
			}
			set
			{
				entity.RoleID = ((value == null) ? null : value.entity);
			}
		}
		#endregion 





        #region "FKQuery"
		
        public static List<SystemUserRoleRelationWrapper> FindAllByOrderByAndFilterAndUserID(string orderByColumnName, bool isDesc,   SystemUserWrapper userID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndUserID(orderByColumnName, isDesc,   userID.entity, pageQueryParams));
        }

        public static List<SystemUserRoleRelationWrapper> FindAllByUserID(SystemUserWrapper userID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByUserID(userID.entity));
        }
		
		
        public static List<SystemUserRoleRelationWrapper> FindAllByOrderByAndFilterAndRoleID(string orderByColumnName, bool isDesc,   SystemRoleWrapper roleID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndRoleID(orderByColumnName, isDesc,   roleID.entity, pageQueryParams));
        }

        public static List<SystemUserRoleRelationWrapper> FindAllByRoleID(SystemRoleWrapper roleID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByRoleID(roleID.entity));
        }
		



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemUserRoleRelationWrapper> ConvertToWrapperList(List<SystemUserRoleRelationEntity> entitylist)
        {
            List<SystemUserRoleRelationWrapper> list = new List<SystemUserRoleRelationWrapper>();
            foreach (SystemUserRoleRelationEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemUserRoleRelationWrapper> ConvertToWrapperList(IList<SystemUserRoleRelationEntity> entitylist)
        {
            List<SystemUserRoleRelationWrapper> list = new List<SystemUserRoleRelationWrapper>();
            foreach (SystemUserRoleRelationEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemUserRoleRelationEntity> ConvertToEntityList(List<SystemUserRoleRelationWrapper> wrapperlist)
        {
            List<SystemUserRoleRelationEntity> list = new List<SystemUserRoleRelationEntity>();
            foreach (SystemUserRoleRelationWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemUserRoleRelationWrapper ConvertEntityToWrapper(SystemUserRoleRelationEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.UserRoleID == 0)
                return null;

            return new SystemUserRoleRelationWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

