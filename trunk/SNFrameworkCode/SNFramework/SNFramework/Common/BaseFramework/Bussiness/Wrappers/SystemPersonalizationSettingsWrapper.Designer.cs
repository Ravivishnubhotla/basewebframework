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
    public partial class SystemPersonalizationSettingsWrapper    //: BaseSpringNHibernateWrapper<SystemPersonalizationSettingsEntity, ISystemPersonalizationSettingsServiceProxy, SystemPersonalizationSettingsWrapper,int>
    {
        #region Member

		internal static readonly ISystemPersonalizationSettingsServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemPersonalizationSettingsServiceProxyInstance;
		
		
		internal SystemPersonalizationSettingsEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemPersonalizationSettingsWrapper() : base(new SystemPersonalizationSettingsEntity())
        {
            
        }

        internal SystemPersonalizationSettingsWrapper(SystemPersonalizationSettingsEntity entityObj)
            : base(entityObj)
        {
        }
		#endregion

        #region Process Column Name
        private static string ProcessColumnName(string columnName)
        {
            switch (columnName)
            {
		        case "ApplicationID_SystemApplicationID":
					return PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONID;
		        case "ApplicationID_SystemApplicationName":
					return PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONNAME;
		        case "ApplicationID_SystemApplicationCode":
					return PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONCODE;
		        case "ApplicationID_SystemApplicationDescription":
					return PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONDESCRIPTION;
		        case "ApplicationID_SystemApplicationUrl":
					return PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONURL;
		        case "ApplicationID_SystemApplicationIsSystemApplication":
					return PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONISSYSTEMAPPLICATION;
		        case "ApplicationID_Status":
					return PROPERTY_APPLICATIONID_STATUS;
		        case "ApplicationID_OrderIndex":
					return PROPERTY_APPLICATIONID_ORDERINDEX;
		        case "ApplicationID_CreateBy":
					return PROPERTY_APPLICATIONID_CREATEBY;
		        case "ApplicationID_CreateAt":
					return PROPERTY_APPLICATIONID_CREATEAT;
		        case "ApplicationID_LastModifyBy":
					return PROPERTY_APPLICATIONID_LASTMODIFYBY;
		        case "ApplicationID_LastModifyAt":
					return PROPERTY_APPLICATIONID_LASTMODIFYAT;
		        case "ApplicationID_LastModifyComment":
					return PROPERTY_APPLICATIONID_LASTMODIFYCOMMENT;
		        case "UserId_UserID":
					return PROPERTY_USERID_USERID;
		        case "UserId_UserLoginID":
					return PROPERTY_USERID_USERLOGINID;
		        case "UserId_UserName":
					return PROPERTY_USERID_USERNAME;
		        case "UserId_UserEmail":
					return PROPERTY_USERID_USEREMAIL;
		        case "UserId_UserPassword":
					return PROPERTY_USERID_USERPASSWORD;
		        case "UserId_UserStatus":
					return PROPERTY_USERID_USERSTATUS;
		        case "UserId_UserCreateDate":
					return PROPERTY_USERID_USERCREATEDATE;
		        case "UserId_UserType":
					return PROPERTY_USERID_USERTYPE;
		        case "UserId_MobilePIN":
					return PROPERTY_USERID_MOBILEPIN;
		        case "UserId_PasswordFormat":
					return PROPERTY_USERID_PASSWORDFORMAT;
		        case "UserId_PasswordQuestion":
					return PROPERTY_USERID_PASSWORDQUESTION;
		        case "UserId_PasswordAnswer":
					return PROPERTY_USERID_PASSWORDANSWER;
		        case "UserId_Comments":
					return PROPERTY_USERID_COMMENTS;
		        case "UserId_IsApproved":
					return PROPERTY_USERID_ISAPPROVED;
		        case "UserId_IsLockedOut":
					return PROPERTY_USERID_ISLOCKEDOUT;
		        case "UserId_LastActivityDate":
					return PROPERTY_USERID_LASTACTIVITYDATE;
		        case "UserId_LastLoginDate":
					return PROPERTY_USERID_LASTLOGINDATE;
		        case "UserId_LastLockedOutDate":
					return PROPERTY_USERID_LASTLOCKEDOUTDATE;
		        case "UserId_LastPasswordChangeDate":
					return PROPERTY_USERID_LASTPASSWORDCHANGEDATE;
		        case "UserId_FailedPwdAttemptCnt":
					return PROPERTY_USERID_FAILEDPWDATTEMPTCNT;
		        case "UserId_FailedPwdAttemptWndStart":
					return PROPERTY_USERID_FAILEDPWDATTEMPTWNDSTART;
		        case "UserId_FailedPwdAnsAttemptCnt":
					return PROPERTY_USERID_FAILEDPWDANSATTEMPTCNT;
		        case "UserId_FailedPwdAnsAttemptWndStart":
					return PROPERTY_USERID_FAILEDPWDANSATTEMPTWNDSTART;
		        case "UserId_IsNeedChgPwd":
					return PROPERTY_USERID_ISNEEDCHGPWD;
		        case "UserId_PasswordSalt":
					return PROPERTY_USERID_PASSWORDSALT;
		        case "UserId_LoweredEmail":
					return PROPERTY_USERID_LOWEREDEMAIL;
		        case "UserId_ValidateType":
					return PROPERTY_USERID_VALIDATETYPE;
		        case "UserId_ADDomain":
					return PROPERTY_USERID_ADDOMAIN;
		        case "UserId_BindUKey":
					return PROPERTY_USERID_BINDUKEY;
		        case "UserId_USBKeySerial":
					return PROPERTY_USERID_USBKEYSERIAL;
		        case "UserId_USBKeyCode":
					return PROPERTY_USERID_USBKEYCODE;
		        case "UserId_SSOKey":
					return PROPERTY_USERID_SSOKEY;
		        case "UserId_CreateBy":
					return PROPERTY_USERID_CREATEBY;
		        case "UserId_CreateAt":
					return PROPERTY_USERID_CREATEAT;
		        case "UserId_LastModifyBy":
					return PROPERTY_USERID_LASTMODIFYBY;
		        case "UserId_LastModifyAt":
					return PROPERTY_USERID_LASTMODIFYAT;
		        case "UserId_LastModifyComment":
					return PROPERTY_USERID_LASTMODIFYCOMMENT;
		        case "UserId_LastLoginIP":
					return PROPERTY_USERID_LASTLOGINIP;
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemPersonalizationSettingsEntity";
		public static readonly string PROPERTY_NAME_PERSONALIZATIONID = "PersonalizationID";
		public static readonly string PROPERTY_NAME_APPLICATIONID = "ApplicationID";
		public static readonly string PROPERTY_NAME_USERID = "UserId";
		public static readonly string PROPERTY_NAME_PATH = "Path";
		public static readonly string PROPERTY_NAME_PAGESETTINGS = "PageSettings";
		public static readonly string PROPERTY_NAME_LASTUPDATEDDATE = "LastUpdatedDate";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region applicationID字段外键查询字段
        public const string PROPERTY_APPLICATIONID_ALIAS_NAME = "ApplicationID_SystemPersonalizationSettingsEntity_Alias";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONID = "ApplicationID_SystemPersonalizationSettingsEntity_Alias.SystemApplicationID";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONNAME = "ApplicationID_SystemPersonalizationSettingsEntity_Alias.SystemApplicationName";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONCODE = "ApplicationID_SystemPersonalizationSettingsEntity_Alias.SystemApplicationCode";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONDESCRIPTION = "ApplicationID_SystemPersonalizationSettingsEntity_Alias.SystemApplicationDescription";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONURL = "ApplicationID_SystemPersonalizationSettingsEntity_Alias.SystemApplicationUrl";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONISSYSTEMAPPLICATION = "ApplicationID_SystemPersonalizationSettingsEntity_Alias.SystemApplicationIsSystemApplication";
		public const string PROPERTY_APPLICATIONID_STATUS = "ApplicationID_SystemPersonalizationSettingsEntity_Alias.Status";
		public const string PROPERTY_APPLICATIONID_ORDERINDEX = "ApplicationID_SystemPersonalizationSettingsEntity_Alias.OrderIndex";
		public const string PROPERTY_APPLICATIONID_CREATEBY = "ApplicationID_SystemPersonalizationSettingsEntity_Alias.CreateBy";
		public const string PROPERTY_APPLICATIONID_CREATEAT = "ApplicationID_SystemPersonalizationSettingsEntity_Alias.CreateAt";
		public const string PROPERTY_APPLICATIONID_LASTMODIFYBY = "ApplicationID_SystemPersonalizationSettingsEntity_Alias.LastModifyBy";
		public const string PROPERTY_APPLICATIONID_LASTMODIFYAT = "ApplicationID_SystemPersonalizationSettingsEntity_Alias.LastModifyAt";
		public const string PROPERTY_APPLICATIONID_LASTMODIFYCOMMENT = "ApplicationID_SystemPersonalizationSettingsEntity_Alias.LastModifyComment";
		#endregion
		#region userId字段外键查询字段
        public const string PROPERTY_USERID_ALIAS_NAME = "UserId_SystemPersonalizationSettingsEntity_Alias";
		public const string PROPERTY_USERID_USERID = "UserId_SystemPersonalizationSettingsEntity_Alias.UserID";
		public const string PROPERTY_USERID_USERLOGINID = "UserId_SystemPersonalizationSettingsEntity_Alias.UserLoginID";
		public const string PROPERTY_USERID_USERNAME = "UserId_SystemPersonalizationSettingsEntity_Alias.UserName";
		public const string PROPERTY_USERID_USEREMAIL = "UserId_SystemPersonalizationSettingsEntity_Alias.UserEmail";
		public const string PROPERTY_USERID_USERPASSWORD = "UserId_SystemPersonalizationSettingsEntity_Alias.UserPassword";
		public const string PROPERTY_USERID_USERSTATUS = "UserId_SystemPersonalizationSettingsEntity_Alias.UserStatus";
		public const string PROPERTY_USERID_USERCREATEDATE = "UserId_SystemPersonalizationSettingsEntity_Alias.UserCreateDate";
		public const string PROPERTY_USERID_USERTYPE = "UserId_SystemPersonalizationSettingsEntity_Alias.UserType";
		public const string PROPERTY_USERID_MOBILEPIN = "UserId_SystemPersonalizationSettingsEntity_Alias.MobilePIN";
		public const string PROPERTY_USERID_PASSWORDFORMAT = "UserId_SystemPersonalizationSettingsEntity_Alias.PasswordFormat";
		public const string PROPERTY_USERID_PASSWORDQUESTION = "UserId_SystemPersonalizationSettingsEntity_Alias.PasswordQuestion";
		public const string PROPERTY_USERID_PASSWORDANSWER = "UserId_SystemPersonalizationSettingsEntity_Alias.PasswordAnswer";
		public const string PROPERTY_USERID_COMMENTS = "UserId_SystemPersonalizationSettingsEntity_Alias.Comments";
		public const string PROPERTY_USERID_ISAPPROVED = "UserId_SystemPersonalizationSettingsEntity_Alias.IsApproved";
		public const string PROPERTY_USERID_ISLOCKEDOUT = "UserId_SystemPersonalizationSettingsEntity_Alias.IsLockedOut";
		public const string PROPERTY_USERID_LASTACTIVITYDATE = "UserId_SystemPersonalizationSettingsEntity_Alias.LastActivityDate";
		public const string PROPERTY_USERID_LASTLOGINDATE = "UserId_SystemPersonalizationSettingsEntity_Alias.LastLoginDate";
		public const string PROPERTY_USERID_LASTLOCKEDOUTDATE = "UserId_SystemPersonalizationSettingsEntity_Alias.LastLockedOutDate";
		public const string PROPERTY_USERID_LASTPASSWORDCHANGEDATE = "UserId_SystemPersonalizationSettingsEntity_Alias.LastPasswordChangeDate";
		public const string PROPERTY_USERID_FAILEDPWDATTEMPTCNT = "UserId_SystemPersonalizationSettingsEntity_Alias.FailedPwdAttemptCnt";
		public const string PROPERTY_USERID_FAILEDPWDATTEMPTWNDSTART = "UserId_SystemPersonalizationSettingsEntity_Alias.FailedPwdAttemptWndStart";
		public const string PROPERTY_USERID_FAILEDPWDANSATTEMPTCNT = "UserId_SystemPersonalizationSettingsEntity_Alias.FailedPwdAnsAttemptCnt";
		public const string PROPERTY_USERID_FAILEDPWDANSATTEMPTWNDSTART = "UserId_SystemPersonalizationSettingsEntity_Alias.FailedPwdAnsAttemptWndStart";
		public const string PROPERTY_USERID_ISNEEDCHGPWD = "UserId_SystemPersonalizationSettingsEntity_Alias.IsNeedChgPwd";
		public const string PROPERTY_USERID_PASSWORDSALT = "UserId_SystemPersonalizationSettingsEntity_Alias.PasswordSalt";
		public const string PROPERTY_USERID_LOWEREDEMAIL = "UserId_SystemPersonalizationSettingsEntity_Alias.LoweredEmail";
		public const string PROPERTY_USERID_VALIDATETYPE = "UserId_SystemPersonalizationSettingsEntity_Alias.ValidateType";
		public const string PROPERTY_USERID_ADDOMAIN = "UserId_SystemPersonalizationSettingsEntity_Alias.ADDomain";
		public const string PROPERTY_USERID_BINDUKEY = "UserId_SystemPersonalizationSettingsEntity_Alias.BindUKey";
		public const string PROPERTY_USERID_USBKEYSERIAL = "UserId_SystemPersonalizationSettingsEntity_Alias.USBKeySerial";
		public const string PROPERTY_USERID_USBKEYCODE = "UserId_SystemPersonalizationSettingsEntity_Alias.USBKeyCode";
		public const string PROPERTY_USERID_SSOKEY = "UserId_SystemPersonalizationSettingsEntity_Alias.SSOKey";
		public const string PROPERTY_USERID_CREATEBY = "UserId_SystemPersonalizationSettingsEntity_Alias.CreateBy";
		public const string PROPERTY_USERID_CREATEAT = "UserId_SystemPersonalizationSettingsEntity_Alias.CreateAt";
		public const string PROPERTY_USERID_LASTMODIFYBY = "UserId_SystemPersonalizationSettingsEntity_Alias.LastModifyBy";
		public const string PROPERTY_USERID_LASTMODIFYAT = "UserId_SystemPersonalizationSettingsEntity_Alias.LastModifyAt";
		public const string PROPERTY_USERID_LASTMODIFYCOMMENT = "UserId_SystemPersonalizationSettingsEntity_Alias.LastModifyComment";
		public const string PROPERTY_USERID_LASTLOGINIP = "UserId_SystemPersonalizationSettingsEntity_Alias.LastLoginIP";
		#endregion
      	
	
	
		 
		
		
		
		


		#region Public Property
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int PersonalizationID
		{
			get
			{
				return entity.PersonalizationID;
			}
			set
			{
				entity.PersonalizationID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public SystemApplicationWrapper ApplicationID
		{
			get
			{
				return SystemApplicationWrapper.ConvertEntityToWrapper(entity.ApplicationID) ;
			}
			set
			{
				entity.ApplicationID = ((value == null) ? null : value.Entity);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public SystemUserWrapper UserId
		{
			get
			{
				return SystemUserWrapper.ConvertEntityToWrapper(entity.UserId) ;
			}
			set
			{
				entity.UserId = ((value == null) ? null : value.Entity);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Path
		{
			get
			{
				return entity.Path;
			}
			set
			{
				entity.Path = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public byte[] PageSettings
		{
			get
			{
				return entity.PageSettings;
			}
			set
			{
				entity.PageSettings = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public DateTime? LastUpdatedDate
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
		
		
		#region applicationID字段外键查询字段
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONID)]
        public int? ApplicationID_SystemApplicationID
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.SystemApplicationID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONNAME)]
        public string ApplicationID_SystemApplicationName
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.SystemApplicationName;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONCODE)]
        public string ApplicationID_SystemApplicationCode
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.SystemApplicationCode;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONDESCRIPTION)]
        public string ApplicationID_SystemApplicationDescription
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.SystemApplicationDescription;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONURL)]
        public string ApplicationID_SystemApplicationUrl
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.SystemApplicationUrl;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONISSYSTEMAPPLICATION)]
        public bool? ApplicationID_SystemApplicationIsSystemApplication
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.SystemApplicationIsSystemApplication;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_STATUS)]
        public string ApplicationID_Status
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.Status;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_ORDERINDEX)]
        public int? ApplicationID_OrderIndex
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.OrderIndex;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_CREATEBY)]
        public int? ApplicationID_CreateBy
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.CreateBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_CREATEAT)]
        public DateTime? ApplicationID_CreateAt
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.CreateAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_LASTMODIFYBY)]
        public int? ApplicationID_LastModifyBy
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.LastModifyBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_LASTMODIFYAT)]
        public DateTime? ApplicationID_LastModifyAt
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.LastModifyAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_LASTMODIFYCOMMENT)]
        public string ApplicationID_LastModifyComment
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.LastModifyComment;
            }
        }
		#endregion
		#region userId字段外键查询字段
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_USERID)]
        public int? UserId_UserID
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.UserID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_USERLOGINID)]
        public string UserId_UserLoginID
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.UserLoginID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_USERNAME)]
        public string UserId_UserName
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.UserName;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_USEREMAIL)]
        public string UserId_UserEmail
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.UserEmail;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_USERPASSWORD)]
        public string UserId_UserPassword
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.UserPassword;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_USERSTATUS)]
        public string UserId_UserStatus
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.UserStatus;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_USERCREATEDATE)]
        public DateTime? UserId_UserCreateDate
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.UserCreateDate;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_USERTYPE)]
        public string UserId_UserType
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.UserType;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_MOBILEPIN)]
        public string UserId_MobilePIN
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.MobilePIN;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_PASSWORDFORMAT)]
        public int? UserId_PasswordFormat
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.PasswordFormat;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_PASSWORDQUESTION)]
        public string UserId_PasswordQuestion
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.PasswordQuestion;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_PASSWORDANSWER)]
        public string UserId_PasswordAnswer
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.PasswordAnswer;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_COMMENTS)]
        public string UserId_Comments
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.Comments;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_ISAPPROVED)]
        public bool? UserId_IsApproved
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.IsApproved;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_ISLOCKEDOUT)]
        public bool? UserId_IsLockedOut
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.IsLockedOut;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_LASTACTIVITYDATE)]
        public DateTime? UserId_LastActivityDate
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.LastActivityDate;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_LASTLOGINDATE)]
        public DateTime? UserId_LastLoginDate
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.LastLoginDate;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_LASTLOCKEDOUTDATE)]
        public DateTime? UserId_LastLockedOutDate
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.LastLockedOutDate;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_LASTPASSWORDCHANGEDATE)]
        public DateTime? UserId_LastPasswordChangeDate
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.LastPasswordChangeDate;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_FAILEDPWDATTEMPTCNT)]
        public int? UserId_FailedPwdAttemptCnt
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.FailedPwdAttemptCnt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_FAILEDPWDATTEMPTWNDSTART)]
        public DateTime? UserId_FailedPwdAttemptWndStart
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.FailedPwdAttemptWndStart;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_FAILEDPWDANSATTEMPTCNT)]
        public int? UserId_FailedPwdAnsAttemptCnt
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.FailedPwdAnsAttemptCnt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_FAILEDPWDANSATTEMPTWNDSTART)]
        public DateTime? UserId_FailedPwdAnsAttemptWndStart
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.FailedPwdAnsAttemptWndStart;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_ISNEEDCHGPWD)]
        public bool? UserId_IsNeedChgPwd
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.IsNeedChgPwd;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_PASSWORDSALT)]
        public string UserId_PasswordSalt
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.PasswordSalt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_LOWEREDEMAIL)]
        public string UserId_LoweredEmail
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.LoweredEmail;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_VALIDATETYPE)]
        public string UserId_ValidateType
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.ValidateType;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_ADDOMAIN)]
        public string UserId_ADDomain
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.ADDomain;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_BINDUKEY)]
        public bool? UserId_BindUKey
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.BindUKey;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_USBKEYSERIAL)]
        public string UserId_USBKeySerial
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.USBKeySerial;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_USBKEYCODE)]
        public string UserId_USBKeyCode
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.USBKeyCode;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_SSOKEY)]
        public string UserId_SSOKey
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.SSOKey;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_CREATEBY)]
        public int? UserId_CreateBy
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.CreateBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_CREATEAT)]
        public DateTime? UserId_CreateAt
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.CreateAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_LASTMODIFYBY)]
        public int? UserId_LastModifyBy
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.LastModifyBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_LASTMODIFYAT)]
        public DateTime? UserId_LastModifyAt
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.LastModifyAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_LASTMODIFYCOMMENT)]
        public string UserId_LastModifyComment
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.LastModifyComment;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_USERID_LASTLOGINIP)]
        public string UserId_LastLoginIP
        {
            get
            {
                if (this. UserId == null)
                    return null;
                return  UserId.LastLoginIP;
            }
        }
		#endregion
      	
   
		#endregion


        #region "FKQuery"
		
        public static List<SystemPersonalizationSettingsWrapper> FindAllByOrderByAndFilterAndApplicationID(string orderByColumnName, bool isDesc,   SystemApplicationWrapper applicationID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndApplicationID(orderByColumnName, isDesc,   applicationID.Entity, pageQueryParams));
        }

        public static List<SystemPersonalizationSettingsWrapper> FindAllByApplicationID(SystemApplicationWrapper applicationID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByApplicationID(applicationID.Entity));
        }
		
		
        public static List<SystemPersonalizationSettingsWrapper> FindAllByOrderByAndFilterAndUserId(string orderByColumnName, bool isDesc,   SystemUserWrapper userId,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndUserId(orderByColumnName, isDesc,   userId.Entity, pageQueryParams));
        }

        public static List<SystemPersonalizationSettingsWrapper> FindAllByUserId(SystemUserWrapper userId)
        {
            return ConvertToWrapperList(businessProxy.FindAllByUserId(userId.Entity));
        }
		



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemPersonalizationSettingsWrapper> ConvertToWrapperList(List<SystemPersonalizationSettingsEntity> entitylist)
        {
            List<SystemPersonalizationSettingsWrapper> list = new List<SystemPersonalizationSettingsWrapper>();
            foreach (SystemPersonalizationSettingsEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemPersonalizationSettingsWrapper> ConvertToWrapperList(IList<SystemPersonalizationSettingsEntity> entitylist)
        {
            List<SystemPersonalizationSettingsWrapper> list = new List<SystemPersonalizationSettingsWrapper>();
            foreach (SystemPersonalizationSettingsEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemPersonalizationSettingsEntity> ConvertToEntityList(List<SystemPersonalizationSettingsWrapper> wrapperlist)
        {
            List<SystemPersonalizationSettingsEntity> list = new List<SystemPersonalizationSettingsEntity>();
            foreach (SystemPersonalizationSettingsWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemPersonalizationSettingsWrapper ConvertEntityToWrapper(SystemPersonalizationSettingsEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.PersonalizationID == 0)
                return null;

            return new SystemPersonalizationSettingsWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

