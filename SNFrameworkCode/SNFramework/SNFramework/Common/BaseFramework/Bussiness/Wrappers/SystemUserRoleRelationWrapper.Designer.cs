// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Spring.Context.Support;
using Common.Logging;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
    public partial class SystemUserRoleRelationWrapper    //: BaseSpringNHibernateWrapper<SystemUserRoleRelationEntity, ISystemUserRoleRelationServiceProxy, SystemUserRoleRelationWrapper,int>
    {
        #region Member

		internal static readonly ISystemUserRoleRelationServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemUserRoleRelationServiceProxyInstance;
		
		
		internal SystemUserRoleRelationEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemUserRoleRelationWrapper() : base(new SystemUserRoleRelationEntity())
        {
            
        }

        internal SystemUserRoleRelationWrapper(SystemUserRoleRelationEntity entityObj)
            : base(entityObj)
        {
        }
		#endregion

        #region Process Column Name
        private static string ProcessColumnName(string columnName)
        {
            switch (columnName)
            {
		        case "UserID_UserID":
					return PROPERTY_USERID_USERID;
		        case "UserID_UserLoginID":
					return PROPERTY_USERID_USERLOGINID;
		        case "UserID_UserName":
					return PROPERTY_USERID_USERNAME;
		        case "UserID_UserEmail":
					return PROPERTY_USERID_USEREMAIL;
		        case "UserID_UserPassword":
					return PROPERTY_USERID_USERPASSWORD;
		        case "UserID_UserStatus":
					return PROPERTY_USERID_USERSTATUS;
		        case "UserID_UserCreateDate":
					return PROPERTY_USERID_USERCREATEDATE;
		        case "UserID_UserType":
					return PROPERTY_USERID_USERTYPE;
		        case "UserID_MobilePIN":
					return PROPERTY_USERID_MOBILEPIN;
		        case "UserID_PasswordFormat":
					return PROPERTY_USERID_PASSWORDFORMAT;
		        case "UserID_PasswordQuestion":
					return PROPERTY_USERID_PASSWORDQUESTION;
		        case "UserID_PasswordAnswer":
					return PROPERTY_USERID_PASSWORDANSWER;
		        case "UserID_Comments":
					return PROPERTY_USERID_COMMENTS;
		        case "UserID_IsApproved":
					return PROPERTY_USERID_ISAPPROVED;
		        case "UserID_IsLockedOut":
					return PROPERTY_USERID_ISLOCKEDOUT;
		        case "UserID_LastActivityDate":
					return PROPERTY_USERID_LASTACTIVITYDATE;
		        case "UserID_LastLoginDate":
					return PROPERTY_USERID_LASTLOGINDATE;
		        case "UserID_LastLockedOutDate":
					return PROPERTY_USERID_LASTLOCKEDOUTDATE;
		        case "UserID_LastPasswordChangeDate":
					return PROPERTY_USERID_LASTPASSWORDCHANGEDATE;
		        case "UserID_FailedPwdAttemptCnt":
					return PROPERTY_USERID_FAILEDPWDATTEMPTCNT;
		        case "UserID_FailedPwdAttemptWndStart":
					return PROPERTY_USERID_FAILEDPWDATTEMPTWNDSTART;
		        case "UserID_FailedPwdAnsAttemptCnt":
					return PROPERTY_USERID_FAILEDPWDANSATTEMPTCNT;
		        case "UserID_FailedPwdAnsAttemptWndStart":
					return PROPERTY_USERID_FAILEDPWDANSATTEMPTWNDSTART;
		        case "UserID_IsNeedChgPwd":
					return PROPERTY_USERID_ISNEEDCHGPWD;
		        case "UserID_PasswordSalt":
					return PROPERTY_USERID_PASSWORDSALT;
		        case "UserID_LoweredEmail":
					return PROPERTY_USERID_LOWEREDEMAIL;
		        case "UserID_ValidateType":
					return PROPERTY_USERID_VALIDATETYPE;
		        case "UserID_ADDomain":
					return PROPERTY_USERID_ADDOMAIN;
		        case "UserID_BindUKey":
					return PROPERTY_USERID_BINDUKEY;
		        case "UserID_USBKeySerial":
					return PROPERTY_USERID_USBKEYSERIAL;
		        case "UserID_USBKeyCode":
					return PROPERTY_USERID_USBKEYCODE;
		        case "UserID_SSOKey":
					return PROPERTY_USERID_SSOKEY;
		        case "UserID_CreateBy":
					return PROPERTY_USERID_CREATEBY;
		        case "UserID_CreateAt":
					return PROPERTY_USERID_CREATEAT;
		        case "UserID_LastModifyBy":
					return PROPERTY_USERID_LASTMODIFYBY;
		        case "UserID_LastModifyAt":
					return PROPERTY_USERID_LASTMODIFYAT;
		        case "UserID_LastModifyComment":
					return PROPERTY_USERID_LASTMODIFYCOMMENT;
		        case "UserID_LastLoginIP":
					return PROPERTY_USERID_LASTLOGINIP;
		        case "RoleID_RoleID":
					return PROPERTY_ROLEID_ROLEID;
		        case "RoleID_RoleName":
					return PROPERTY_ROLEID_ROLENAME;
		        case "RoleID_RoleCode":
					return PROPERTY_ROLEID_ROLECODE;
		        case "RoleID_RoleDescription":
					return PROPERTY_ROLEID_ROLEDESCRIPTION;
		        case "RoleID_RoleIsSystemRole":
					return PROPERTY_ROLEID_ROLEISSYSTEMROLE;
		        case "RoleID_RoleType":
					return PROPERTY_ROLEID_ROLETYPE;
		        case "RoleID_CreateBy":
					return PROPERTY_ROLEID_CREATEBY;
		        case "RoleID_CreateAt":
					return PROPERTY_ROLEID_CREATEAT;
		        case "RoleID_LastModifyBy":
					return PROPERTY_ROLEID_LASTMODIFYBY;
		        case "RoleID_LastModifyAt":
					return PROPERTY_ROLEID_LASTMODIFYAT;
		        case "RoleID_LastModifyComment":
					return PROPERTY_ROLEID_LASTMODIFYCOMMENT;
              default:
                    return columnName;
            }
        }

        private static void ProcessQueryFilters(List<QueryFilter> filters)
        {
            foreach (QueryFilter queryFilter in filters)
            {
                queryFilter.FilterFieldName = ProcessColumnName(queryFilter.FilterFieldName);
            }
        }
		#endregion
		
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemUserRoleRelationEntity";
		public static readonly string PROPERTY_NAME_USERROLEID = "UserRoleID";
		public static readonly string PROPERTY_NAME_USERID = "UserID";
		public static readonly string PROPERTY_NAME_ROLEID = "RoleID";
		
        #endregion
	
 
		#region userID字段外键查询字段
        public const string PROPERTY_USERID_ALIAS_NAME = "UserID_SystemUserRoleRelationEntity_Alias";
		public const string PROPERTY_USERID_USERID = "UserID_SystemUserRoleRelationEntity_Alias.UserID";
		public const string PROPERTY_USERID_USERLOGINID = "UserID_SystemUserRoleRelationEntity_Alias.UserLoginID";
		public const string PROPERTY_USERID_USERNAME = "UserID_SystemUserRoleRelationEntity_Alias.UserName";
		public const string PROPERTY_USERID_USEREMAIL = "UserID_SystemUserRoleRelationEntity_Alias.UserEmail";
		public const string PROPERTY_USERID_USERPASSWORD = "UserID_SystemUserRoleRelationEntity_Alias.UserPassword";
		public const string PROPERTY_USERID_USERSTATUS = "UserID_SystemUserRoleRelationEntity_Alias.UserStatus";
		public const string PROPERTY_USERID_USERCREATEDATE = "UserID_SystemUserRoleRelationEntity_Alias.UserCreateDate";
		public const string PROPERTY_USERID_USERTYPE = "UserID_SystemUserRoleRelationEntity_Alias.UserType";
		public const string PROPERTY_USERID_MOBILEPIN = "UserID_SystemUserRoleRelationEntity_Alias.MobilePIN";
		public const string PROPERTY_USERID_PASSWORDFORMAT = "UserID_SystemUserRoleRelationEntity_Alias.PasswordFormat";
		public const string PROPERTY_USERID_PASSWORDQUESTION = "UserID_SystemUserRoleRelationEntity_Alias.PasswordQuestion";
		public const string PROPERTY_USERID_PASSWORDANSWER = "UserID_SystemUserRoleRelationEntity_Alias.PasswordAnswer";
		public const string PROPERTY_USERID_COMMENTS = "UserID_SystemUserRoleRelationEntity_Alias.Comments";
		public const string PROPERTY_USERID_ISAPPROVED = "UserID_SystemUserRoleRelationEntity_Alias.IsApproved";
		public const string PROPERTY_USERID_ISLOCKEDOUT = "UserID_SystemUserRoleRelationEntity_Alias.IsLockedOut";
		public const string PROPERTY_USERID_LASTACTIVITYDATE = "UserID_SystemUserRoleRelationEntity_Alias.LastActivityDate";
		public const string PROPERTY_USERID_LASTLOGINDATE = "UserID_SystemUserRoleRelationEntity_Alias.LastLoginDate";
		public const string PROPERTY_USERID_LASTLOCKEDOUTDATE = "UserID_SystemUserRoleRelationEntity_Alias.LastLockedOutDate";
		public const string PROPERTY_USERID_LASTPASSWORDCHANGEDATE = "UserID_SystemUserRoleRelationEntity_Alias.LastPasswordChangeDate";
		public const string PROPERTY_USERID_FAILEDPWDATTEMPTCNT = "UserID_SystemUserRoleRelationEntity_Alias.FailedPwdAttemptCnt";
		public const string PROPERTY_USERID_FAILEDPWDATTEMPTWNDSTART = "UserID_SystemUserRoleRelationEntity_Alias.FailedPwdAttemptWndStart";
		public const string PROPERTY_USERID_FAILEDPWDANSATTEMPTCNT = "UserID_SystemUserRoleRelationEntity_Alias.FailedPwdAnsAttemptCnt";
		public const string PROPERTY_USERID_FAILEDPWDANSATTEMPTWNDSTART = "UserID_SystemUserRoleRelationEntity_Alias.FailedPwdAnsAttemptWndStart";
		public const string PROPERTY_USERID_ISNEEDCHGPWD = "UserID_SystemUserRoleRelationEntity_Alias.IsNeedChgPwd";
		public const string PROPERTY_USERID_PASSWORDSALT = "UserID_SystemUserRoleRelationEntity_Alias.PasswordSalt";
		public const string PROPERTY_USERID_LOWEREDEMAIL = "UserID_SystemUserRoleRelationEntity_Alias.LoweredEmail";
		public const string PROPERTY_USERID_VALIDATETYPE = "UserID_SystemUserRoleRelationEntity_Alias.ValidateType";
		public const string PROPERTY_USERID_ADDOMAIN = "UserID_SystemUserRoleRelationEntity_Alias.ADDomain";
		public const string PROPERTY_USERID_BINDUKEY = "UserID_SystemUserRoleRelationEntity_Alias.BindUKey";
		public const string PROPERTY_USERID_USBKEYSERIAL = "UserID_SystemUserRoleRelationEntity_Alias.USBKeySerial";
		public const string PROPERTY_USERID_USBKEYCODE = "UserID_SystemUserRoleRelationEntity_Alias.USBKeyCode";
		public const string PROPERTY_USERID_SSOKEY = "UserID_SystemUserRoleRelationEntity_Alias.SSOKey";
		public const string PROPERTY_USERID_CREATEBY = "UserID_SystemUserRoleRelationEntity_Alias.CreateBy";
		public const string PROPERTY_USERID_CREATEAT = "UserID_SystemUserRoleRelationEntity_Alias.CreateAt";
		public const string PROPERTY_USERID_LASTMODIFYBY = "UserID_SystemUserRoleRelationEntity_Alias.LastModifyBy";
		public const string PROPERTY_USERID_LASTMODIFYAT = "UserID_SystemUserRoleRelationEntity_Alias.LastModifyAt";
		public const string PROPERTY_USERID_LASTMODIFYCOMMENT = "UserID_SystemUserRoleRelationEntity_Alias.LastModifyComment";
		public const string PROPERTY_USERID_LASTLOGINIP = "UserID_SystemUserRoleRelationEntity_Alias.LastLoginIP";
		#endregion
		#region roleID字段外键查询字段
        public const string PROPERTY_ROLEID_ALIAS_NAME = "RoleID_SystemUserRoleRelationEntity_Alias";
		public const string PROPERTY_ROLEID_ROLEID = "RoleID_SystemUserRoleRelationEntity_Alias.RoleID";
		public const string PROPERTY_ROLEID_ROLENAME = "RoleID_SystemUserRoleRelationEntity_Alias.RoleName";
		public const string PROPERTY_ROLEID_ROLECODE = "RoleID_SystemUserRoleRelationEntity_Alias.RoleCode";
		public const string PROPERTY_ROLEID_ROLEDESCRIPTION = "RoleID_SystemUserRoleRelationEntity_Alias.RoleDescription";
		public const string PROPERTY_ROLEID_ROLEISSYSTEMROLE = "RoleID_SystemUserRoleRelationEntity_Alias.RoleIsSystemRole";
		public const string PROPERTY_ROLEID_ROLETYPE = "RoleID_SystemUserRoleRelationEntity_Alias.RoleType";
		public const string PROPERTY_ROLEID_CREATEBY = "RoleID_SystemUserRoleRelationEntity_Alias.CreateBy";
		public const string PROPERTY_ROLEID_CREATEAT = "RoleID_SystemUserRoleRelationEntity_Alias.CreateAt";
		public const string PROPERTY_ROLEID_LASTMODIFYBY = "RoleID_SystemUserRoleRelationEntity_Alias.LastModifyBy";
		public const string PROPERTY_ROLEID_LASTMODIFYAT = "RoleID_SystemUserRoleRelationEntity_Alias.LastModifyAt";
		public const string PROPERTY_ROLEID_LASTMODIFYCOMMENT = "RoleID_SystemUserRoleRelationEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		


		#region Public Property
		/// <summary>
		/// ??
		/// </summary>
		[DataMember]
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
		[DataMember]
		public SystemUserWrapper UserID
		{
			get
			{
				return SystemUserWrapper.ConvertEntityToWrapper(entity.UserID) ;
			}
			set
			{
				entity.UserID = ((value == null) ? null : value.Entity);
			}
		}
		/// <summary>
		/// ??ID
		/// </summary>
		[DataMember]
		public SystemRoleWrapper RoleID
		{
			get
			{
				return SystemRoleWrapper.ConvertEntityToWrapper(entity.RoleID) ;
			}
			set
			{
				entity.RoleID = ((value == null) ? null : value.Entity);
			}
		}
		#endregion 


		#region Query Property
		
		
		#region userID字段外键查询字段
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_USERID)]
        public int? UserID_UserID
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.UserID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_USERLOGINID)]
        public string UserID_UserLoginID
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.UserLoginID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_USERNAME)]
        public string UserID_UserName
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.UserName;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_USEREMAIL)]
        public string UserID_UserEmail
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.UserEmail;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_USERPASSWORD)]
        public string UserID_UserPassword
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.UserPassword;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_USERSTATUS)]
        public string UserID_UserStatus
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.UserStatus;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_USERCREATEDATE)]
        public DateTime? UserID_UserCreateDate
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.UserCreateDate;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_USERTYPE)]
        public string UserID_UserType
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.UserType;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_MOBILEPIN)]
        public string UserID_MobilePIN
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.MobilePIN;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_PASSWORDFORMAT)]
        public int? UserID_PasswordFormat
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.PasswordFormat;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_PASSWORDQUESTION)]
        public string UserID_PasswordQuestion
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.PasswordQuestion;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_PASSWORDANSWER)]
        public string UserID_PasswordAnswer
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.PasswordAnswer;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_COMMENTS)]
        public string UserID_Comments
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.Comments;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_ISAPPROVED)]
        public bool? UserID_IsApproved
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.IsApproved;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_ISLOCKEDOUT)]
        public bool? UserID_IsLockedOut
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.IsLockedOut;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_LASTACTIVITYDATE)]
        public DateTime? UserID_LastActivityDate
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.LastActivityDate;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_LASTLOGINDATE)]
        public DateTime? UserID_LastLoginDate
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.LastLoginDate;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_LASTLOCKEDOUTDATE)]
        public DateTime? UserID_LastLockedOutDate
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.LastLockedOutDate;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_LASTPASSWORDCHANGEDATE)]
        public DateTime? UserID_LastPasswordChangeDate
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.LastPasswordChangeDate;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_FAILEDPWDATTEMPTCNT)]
        public int? UserID_FailedPwdAttemptCnt
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.FailedPwdAttemptCnt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_FAILEDPWDATTEMPTWNDSTART)]
        public DateTime? UserID_FailedPwdAttemptWndStart
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.FailedPwdAttemptWndStart;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_FAILEDPWDANSATTEMPTCNT)]
        public int? UserID_FailedPwdAnsAttemptCnt
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.FailedPwdAnsAttemptCnt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_FAILEDPWDANSATTEMPTWNDSTART)]
        public DateTime? UserID_FailedPwdAnsAttemptWndStart
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.FailedPwdAnsAttemptWndStart;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_ISNEEDCHGPWD)]
        public bool? UserID_IsNeedChgPwd
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.IsNeedChgPwd;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_PASSWORDSALT)]
        public string UserID_PasswordSalt
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.PasswordSalt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_LOWEREDEMAIL)]
        public string UserID_LoweredEmail
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.LoweredEmail;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_VALIDATETYPE)]
        public string UserID_ValidateType
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.ValidateType;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_ADDOMAIN)]
        public string UserID_ADDomain
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.ADDomain;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_BINDUKEY)]
        public bool? UserID_BindUKey
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.BindUKey;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_USBKEYSERIAL)]
        public string UserID_USBKeySerial
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.USBKeySerial;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_USBKEYCODE)]
        public string UserID_USBKeyCode
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.USBKeyCode;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_SSOKEY)]
        public string UserID_SSOKey
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.SSOKey;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_CREATEBY)]
        public int? UserID_CreateBy
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.CreateBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_CREATEAT)]
        public DateTime? UserID_CreateAt
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.CreateAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_LASTMODIFYBY)]
        public int? UserID_LastModifyBy
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.LastModifyBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_LASTMODIFYAT)]
        public DateTime? UserID_LastModifyAt
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.LastModifyAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_LASTMODIFYCOMMENT)]
        public string UserID_LastModifyComment
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.LastModifyComment;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_LASTLOGINIP)]
        public string UserID_LastLoginIP
        {
            get
            {
                if (this. UserID == null)
                    return null;
                return  UserID.LastLoginIP;
            }
        }
		#endregion
		#region roleID字段外键查询字段
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_ROLEID)]
        public int? RoleID_RoleID
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.RoleID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_ROLENAME)]
        public string RoleID_RoleName
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.RoleName;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_ROLECODE)]
        public string RoleID_RoleCode
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.RoleCode;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_ROLEDESCRIPTION)]
        public string RoleID_RoleDescription
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.RoleDescription;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_ROLEISSYSTEMROLE)]
        public bool? RoleID_RoleIsSystemRole
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.RoleIsSystemRole;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_ROLETYPE)]
        public string RoleID_RoleType
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.RoleType;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_CREATEBY)]
        public int? RoleID_CreateBy
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.CreateBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_CREATEAT)]
        public DateTime? RoleID_CreateAt
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.CreateAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_LASTMODIFYBY)]
        public int? RoleID_LastModifyBy
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.LastModifyBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_LASTMODIFYAT)]
        public DateTime? RoleID_LastModifyAt
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.LastModifyAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_LASTMODIFYCOMMENT)]
        public string RoleID_LastModifyComment
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.LastModifyComment;
            }
        }
		#endregion
      	
   
		#endregion


        #region "FKQuery"
		
        public static List<SystemUserRoleRelationWrapper> FindAllByOrderByAndFilterAndUserID(string orderByColumnName, bool isDesc,   SystemUserWrapper userID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndUserID(orderByColumnName, isDesc,   userID.Entity, pageQueryParams));
        }

        public static List<SystemUserRoleRelationWrapper> FindAllByUserID(SystemUserWrapper userID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByUserID(userID.Entity));
        }
		
		
        public static List<SystemUserRoleRelationWrapper> FindAllByOrderByAndFilterAndRoleID(string orderByColumnName, bool isDesc,   SystemRoleWrapper roleID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndRoleID(orderByColumnName, isDesc,   roleID.Entity, pageQueryParams));
        }

        public static List<SystemUserRoleRelationWrapper> FindAllByRoleID(SystemRoleWrapper roleID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByRoleID(roleID.Entity));
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

