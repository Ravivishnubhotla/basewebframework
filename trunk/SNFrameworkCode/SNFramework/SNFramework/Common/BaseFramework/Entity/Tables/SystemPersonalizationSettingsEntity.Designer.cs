// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Legendigital.Framework.Common.Entity;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	
	/// </summary>
	[DataContract]
	public partial class SystemPersonalizationSettingsEntity  : BaseTableEntity,ICloneable
	{
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
		public const string PROPERTY_USERID_DEPARTMENTID = "UserId_SystemPersonalizationSettingsEntity_Alias.DepartmentID";
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
		public const string PROPERTY_USERID_CREATEBY = "UserId_SystemPersonalizationSettingsEntity_Alias.CreateBy";
		public const string PROPERTY_USERID_CREATEAT = "UserId_SystemPersonalizationSettingsEntity_Alias.CreateAt";
		public const string PROPERTY_USERID_LASTMODIFYBY = "UserId_SystemPersonalizationSettingsEntity_Alias.LastModifyBy";
		public const string PROPERTY_USERID_LASTMODIFYAT = "UserId_SystemPersonalizationSettingsEntity_Alias.LastModifyAt";
		public const string PROPERTY_USERID_LASTMODIFYCOMMENT = "UserId_SystemPersonalizationSettingsEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _personalizationID;
		private SystemApplicationEntity _applicationID;
		private SystemUserEntity _userId;
		private string _path;
		private byte[] _pageSettings;
		private DateTime? _lastUpdatedDate;
		private int? _createBy;
		private DateTime? _createAt;
		private int? _lastModifyBy;
		private DateTime? _lastModifyAt;
		private string _lastModifyComment;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemPersonalizationSettingsEntity()
		{
			_personalizationID = 0;
			_applicationID = null;
			_userId = null;
			_path = String.Empty;
			_pageSettings = new byte[1];
			_lastUpdatedDate = null;
			_createBy = null;
			_createAt = null;
			_lastModifyBy = null;
			_lastModifyAt = null;
			_lastModifyComment = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemPersonalizationSettingsEntity( int personalizationID, SystemApplicationEntity applicationID, SystemUserEntity userId, string path, byte[] pageSettings, DateTime? lastUpdatedDate, int? createBy, DateTime? createAt, int? lastModifyBy, DateTime? lastModifyAt, string lastModifyComment)
		{
			_personalizationID = personalizationID;
			_applicationID = applicationID;
			_userId = userId;
			_path = path;
			_pageSettings = pageSettings;
			_lastUpdatedDate = lastUpdatedDate;
			_createBy = createBy;
			_createAt = createAt;
			_lastModifyBy = lastModifyBy;
			_lastModifyAt = lastModifyAt;
			_lastModifyComment = lastModifyComment;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int PersonalizationID
		{
			get { return _personalizationID; }

			set	
			{
				_isChanged |= (_personalizationID != value); _personalizationID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual SystemApplicationEntity ApplicationID
		{
			get { return _applicationID; }

			set	
			{
				_isChanged |= (_applicationID != value); _applicationID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual SystemUserEntity UserId
		{
			get { return _userId; }

			set	
			{
				_isChanged |= (_userId != value); _userId = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Path
		{
			get { return _path; }

			set	
			{

				if( value != null && value.Length > 1000)
					throw new ArgumentOutOfRangeException("Invalid value for Path", value, value.ToString());
				_isChanged |= (_path != value); _path = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual byte[] PageSettings
		{
			get { return _pageSettings; }

			set	
			{

				if( value != null && value.Length > 2147483647)
					throw new ArgumentOutOfRangeException("Invalid value for PageSettings", value, value.ToString());
				_isChanged |= (_pageSettings != value); _pageSettings = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? LastUpdatedDate
		{
			get { return _lastUpdatedDate; }

			set	
			{
				_isChanged |= (_lastUpdatedDate != value); _lastUpdatedDate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? CreateBy
		{
			get { return _createBy; }

			set	
			{
				_isChanged |= (_createBy != value); _createBy = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? CreateAt
		{
			get { return _createAt; }

			set	
			{
				_isChanged |= (_createAt != value); _createAt = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? LastModifyBy
		{
			get { return _lastModifyBy; }

			set	
			{
				_isChanged |= (_lastModifyBy != value); _lastModifyBy = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? LastModifyAt
		{
			get { return _lastModifyAt; }

			set	
			{
				_isChanged |= (_lastModifyAt != value); _lastModifyAt = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string LastModifyComment
		{
			get { return _lastModifyComment; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for LastModifyComment", value, value.ToString());
				_isChanged |= (_lastModifyComment != value); _lastModifyComment = value;
			}
		}
	

		#endregion 

        

		#region Equals 和 HashCode 方法覆盖
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			 return this.CheckEquals(obj as SystemPersonalizationSettingsEntity);
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			return GetEntityHashCode();
		}
		#endregion
		
		public override object GetDataEntityKey()
	    {
	        return this._personalizationID;
	    }
		
		
	
		#region ICloneable methods
		
		public virtual object Clone()
		{
			return this.MemberwiseClone();
		}
		
		#endregion
	
	}
}