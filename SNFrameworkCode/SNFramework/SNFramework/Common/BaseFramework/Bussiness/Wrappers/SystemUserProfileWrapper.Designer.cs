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
    public partial class SystemUserProfileWrapper    //: BaseSpringNHibernateWrapper<SystemUserProfileEntity, ISystemUserProfileServiceProxy, SystemUserProfileWrapper,int>
    {
        #region Member

		internal static readonly ISystemUserProfileServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemUserProfileServiceProxyInstance;
		
		
		internal SystemUserProfileEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemUserProfileWrapper() : base(new SystemUserProfileEntity())
        {
            
        }

        internal SystemUserProfileWrapper(SystemUserProfileEntity entityObj)
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
		        case "PropertyID_PropertyID":
					return PROPERTY_PROPERTYID_PROPERTYID;
		        case "PropertyID_PropertyName":
					return PROPERTY_PROPERTYID_PROPERTYNAME;
		        case "PropertyID_PropertyDescription":
					return PROPERTY_PROPERTYID_PROPERTYDESCRIPTION;
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemUserProfileEntity";
		public static readonly string PROPERTY_NAME_PROFILEID = "ProfileID";
		public static readonly string PROPERTY_NAME_USERID = "UserID";
		public static readonly string PROPERTY_NAME_PROPERTYID = "PropertyID";
		public static readonly string PROPERTY_NAME_PROPERTYVALUESSTRING = "PropertyValuesString";
		public static readonly string PROPERTY_NAME_PROPERTYVALUESBINARY = "PropertyValuesBinary";
		public static readonly string PROPERTY_NAME_LASTUPDATEDDATE = "LastUpdatedDate";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region userID字段外键查询字段
        public const string PROPERTY_USERID_ALIAS_NAME = "UserID_SystemUserProfileEntity_Alias";
		public const string PROPERTY_USERID_USERID = "UserID_SystemUserProfileEntity_Alias.UserID";
		public const string PROPERTY_USERID_USERLOGINID = "UserID_SystemUserProfileEntity_Alias.UserLoginID";
		public const string PROPERTY_USERID_USERNAME = "UserID_SystemUserProfileEntity_Alias.UserName";
		public const string PROPERTY_USERID_USEREMAIL = "UserID_SystemUserProfileEntity_Alias.UserEmail";
		public const string PROPERTY_USERID_USERPASSWORD = "UserID_SystemUserProfileEntity_Alias.UserPassword";
		public const string PROPERTY_USERID_USERSTATUS = "UserID_SystemUserProfileEntity_Alias.UserStatus";
		public const string PROPERTY_USERID_USERCREATEDATE = "UserID_SystemUserProfileEntity_Alias.UserCreateDate";
		public const string PROPERTY_USERID_USERTYPE = "UserID_SystemUserProfileEntity_Alias.UserType";
		public const string PROPERTY_USERID_MOBILEPIN = "UserID_SystemUserProfileEntity_Alias.MobilePIN";
		public const string PROPERTY_USERID_PASSWORDFORMAT = "UserID_SystemUserProfileEntity_Alias.PasswordFormat";
		public const string PROPERTY_USERID_PASSWORDQUESTION = "UserID_SystemUserProfileEntity_Alias.PasswordQuestion";
		public const string PROPERTY_USERID_PASSWORDANSWER = "UserID_SystemUserProfileEntity_Alias.PasswordAnswer";
		public const string PROPERTY_USERID_COMMENTS = "UserID_SystemUserProfileEntity_Alias.Comments";
		public const string PROPERTY_USERID_ISAPPROVED = "UserID_SystemUserProfileEntity_Alias.IsApproved";
		public const string PROPERTY_USERID_ISLOCKEDOUT = "UserID_SystemUserProfileEntity_Alias.IsLockedOut";
		public const string PROPERTY_USERID_LASTACTIVITYDATE = "UserID_SystemUserProfileEntity_Alias.LastActivityDate";
		public const string PROPERTY_USERID_LASTLOGINDATE = "UserID_SystemUserProfileEntity_Alias.LastLoginDate";
		public const string PROPERTY_USERID_LASTLOCKEDOUTDATE = "UserID_SystemUserProfileEntity_Alias.LastLockedOutDate";
		public const string PROPERTY_USERID_LASTPASSWORDCHANGEDATE = "UserID_SystemUserProfileEntity_Alias.LastPasswordChangeDate";
		public const string PROPERTY_USERID_FAILEDPWDATTEMPTCNT = "UserID_SystemUserProfileEntity_Alias.FailedPwdAttemptCnt";
		public const string PROPERTY_USERID_FAILEDPWDATTEMPTWNDSTART = "UserID_SystemUserProfileEntity_Alias.FailedPwdAttemptWndStart";
		public const string PROPERTY_USERID_FAILEDPWDANSATTEMPTCNT = "UserID_SystemUserProfileEntity_Alias.FailedPwdAnsAttemptCnt";
		public const string PROPERTY_USERID_FAILEDPWDANSATTEMPTWNDSTART = "UserID_SystemUserProfileEntity_Alias.FailedPwdAnsAttemptWndStart";
		public const string PROPERTY_USERID_ISNEEDCHGPWD = "UserID_SystemUserProfileEntity_Alias.IsNeedChgPwd";
		public const string PROPERTY_USERID_PASSWORDSALT = "UserID_SystemUserProfileEntity_Alias.PasswordSalt";
		public const string PROPERTY_USERID_LOWEREDEMAIL = "UserID_SystemUserProfileEntity_Alias.LoweredEmail";
		public const string PROPERTY_USERID_VALIDATETYPE = "UserID_SystemUserProfileEntity_Alias.ValidateType";
		public const string PROPERTY_USERID_ADDOMAIN = "UserID_SystemUserProfileEntity_Alias.ADDomain";
		public const string PROPERTY_USERID_BINDUKEY = "UserID_SystemUserProfileEntity_Alias.BindUKey";
		public const string PROPERTY_USERID_USBKEYSERIAL = "UserID_SystemUserProfileEntity_Alias.USBKeySerial";
		public const string PROPERTY_USERID_USBKEYCODE = "UserID_SystemUserProfileEntity_Alias.USBKeyCode";
		public const string PROPERTY_USERID_SSOKEY = "UserID_SystemUserProfileEntity_Alias.SSOKey";
		public const string PROPERTY_USERID_CREATEBY = "UserID_SystemUserProfileEntity_Alias.CreateBy";
		public const string PROPERTY_USERID_CREATEAT = "UserID_SystemUserProfileEntity_Alias.CreateAt";
		public const string PROPERTY_USERID_LASTMODIFYBY = "UserID_SystemUserProfileEntity_Alias.LastModifyBy";
		public const string PROPERTY_USERID_LASTMODIFYAT = "UserID_SystemUserProfileEntity_Alias.LastModifyAt";
		public const string PROPERTY_USERID_LASTMODIFYCOMMENT = "UserID_SystemUserProfileEntity_Alias.LastModifyComment";
		public const string PROPERTY_USERID_LASTLOGINIP = "UserID_SystemUserProfileEntity_Alias.LastLoginIP";
		#endregion
		#region propertyID字段外键查询字段
        public const string PROPERTY_PROPERTYID_ALIAS_NAME = "PropertyID_SystemUserProfileEntity_Alias";
		public const string PROPERTY_PROPERTYID_PROPERTYID = "PropertyID_SystemUserProfileEntity_Alias.PropertyID";
		public const string PROPERTY_PROPERTYID_PROPERTYNAME = "PropertyID_SystemUserProfileEntity_Alias.PropertyName";
		public const string PROPERTY_PROPERTYID_PROPERTYDESCRIPTION = "PropertyID_SystemUserProfileEntity_Alias.PropertyDescription";
		#endregion
      	
	
	
		 
		
		
		
		


		#region Public Property
		/// <summary>
		/// ??
		/// </summary>
		[DataMember]
		public int ProfileID
		{
			get
			{
				return entity.ProfileID;
			}
			set
			{
				entity.ProfileID = value;
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
		public SystemUserProfilePropertysWrapper PropertyID
		{
			get
			{
				return SystemUserProfilePropertysWrapper.ConvertEntityToWrapper(entity.PropertyID) ;
			}
			set
			{
				entity.PropertyID = ((value == null) ? null : value.Entity);
			}
		}
		/// <summary>
		/// ???
		/// </summary>
		[DataMember]
		public string PropertyValuesString
		{
			get
			{
				return entity.PropertyValuesString;
			}
			set
			{
				entity.PropertyValuesString = value;
			}
		}
		/// <summary>
		/// ??????
		/// </summary>
		[DataMember]
		public byte[] PropertyValuesBinary
		{
			get
			{
				return entity.PropertyValuesBinary;
			}
			set
			{
				entity.PropertyValuesBinary = value;
			}
		}
		/// <summary>
		/// ??????
		/// </summary>
		[DataMember]
		public DateTime LastUpdatedDate
		{
			get
			{
				return entity.LastUpdatedDate;
			}
			set
			{
				entity.LastUpdatedDate = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? CreateBy
		{
			get
			{
				return entity.CreateBy;
			}
			set
			{
				entity.CreateBy = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public DateTime? CreateAt
		{
			get
			{
				return entity.CreateAt;
			}
			set
			{
				entity.CreateAt = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? LastModifyBy
		{
			get
			{
				return entity.LastModifyBy;
			}
			set
			{
				entity.LastModifyBy = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public DateTime? LastModifyAt
		{
			get
			{
				return entity.LastModifyAt;
			}
			set
			{
				entity.LastModifyAt = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string LastModifyComment
		{
			get
			{
				return entity.LastModifyComment;
			}
			set
			{
				entity.LastModifyComment = value;
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
		#region propertyID字段外键查询字段
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_PROPERTYID_PROPERTYID)]
        public int? PropertyID_PropertyID
        {
            get
            {
                if (this. PropertyID == null)
                    return null;
                return  PropertyID.PropertyID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_PROPERTYID_PROPERTYNAME)]
        public string PropertyID_PropertyName
        {
            get
            {
                if (this. PropertyID == null)
                    return null;
                return  PropertyID.PropertyName;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_PROPERTYID_PROPERTYDESCRIPTION)]
        public string PropertyID_PropertyDescription
        {
            get
            {
                if (this. PropertyID == null)
                    return null;
                return  PropertyID.PropertyDescription;
            }
        }
		#endregion
      	
   
		#endregion


        #region "FKQuery"
		
        public static List<SystemUserProfileWrapper> FindAllByOrderByAndFilterAndUserID(string orderByColumnName, bool isDesc,   SystemUserWrapper userID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndUserID(orderByColumnName, isDesc,   userID.Entity, pageQueryParams));
        }

        public static List<SystemUserProfileWrapper> FindAllByUserID(SystemUserWrapper userID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByUserID(userID.Entity));
        }
		
		
        public static List<SystemUserProfileWrapper> FindAllByOrderByAndFilterAndPropertyID(string orderByColumnName, bool isDesc,   SystemUserProfilePropertysWrapper propertyID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndPropertyID(orderByColumnName, isDesc,   propertyID.Entity, pageQueryParams));
        }

        public static List<SystemUserProfileWrapper> FindAllByPropertyID(SystemUserProfilePropertysWrapper propertyID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByPropertyID(propertyID.Entity));
        }
		



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemUserProfileWrapper> ConvertToWrapperList(List<SystemUserProfileEntity> entitylist)
        {
            List<SystemUserProfileWrapper> list = new List<SystemUserProfileWrapper>();
            foreach (SystemUserProfileEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemUserProfileWrapper> ConvertToWrapperList(IList<SystemUserProfileEntity> entitylist)
        {
            List<SystemUserProfileWrapper> list = new List<SystemUserProfileWrapper>();
            foreach (SystemUserProfileEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemUserProfileEntity> ConvertToEntityList(List<SystemUserProfileWrapper> wrapperlist)
        {
            List<SystemUserProfileEntity> list = new List<SystemUserProfileEntity>();
            foreach (SystemUserProfileWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemUserProfileWrapper ConvertEntityToWrapper(SystemUserProfileEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.ProfileID == 0)
                return null;

            return new SystemUserProfileWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

