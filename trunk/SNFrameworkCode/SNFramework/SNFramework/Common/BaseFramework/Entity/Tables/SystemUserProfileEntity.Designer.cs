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
	public partial class SystemUserProfileEntity  : BaseTableEntity,ICloneable
	{
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
		public const string PROPERTY_USERID_DEPARTMENTID = "UserID_SystemUserProfileEntity_Alias.DepartmentID";
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
		public const string PROPERTY_USERID_CREATEBY = "UserID_SystemUserProfileEntity_Alias.CreateBy";
		public const string PROPERTY_USERID_CREATEAT = "UserID_SystemUserProfileEntity_Alias.CreateAt";
		public const string PROPERTY_USERID_LASTMODIFYBY = "UserID_SystemUserProfileEntity_Alias.LastModifyBy";
		public const string PROPERTY_USERID_LASTMODIFYAT = "UserID_SystemUserProfileEntity_Alias.LastModifyAt";
		public const string PROPERTY_USERID_LASTMODIFYCOMMENT = "UserID_SystemUserProfileEntity_Alias.LastModifyComment";
		#endregion
		#region propertyID字段外键查询字段
        public const string PROPERTY_PROPERTYID_ALIAS_NAME = "PropertyID_SystemUserProfileEntity_Alias";
		public const string PROPERTY_PROPERTYID_PROPERTYID = "PropertyID_SystemUserProfileEntity_Alias.PropertyID";
		public const string PROPERTY_PROPERTYID_PROPERTYNAME = "PropertyID_SystemUserProfileEntity_Alias.PropertyName";
		public const string PROPERTY_PROPERTYID_PROPERTYDESCRIPTION = "PropertyID_SystemUserProfileEntity_Alias.PropertyDescription";
		#endregion
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _profileID;
		private SystemUserEntity _userID;
		private SystemUserProfilePropertysEntity _propertyID;
		private string _propertyValuesString;
		private byte[] _propertyValuesBinary;
		private DateTime _lastUpdatedDate;
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
		public SystemUserProfileEntity()
		{
			_profileID = 0;
			_userID = null;
			_propertyID = null;
			_propertyValuesString = null;
			_propertyValuesBinary = null;
			_lastUpdatedDate = DateTime.MinValue;
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
		public SystemUserProfileEntity( int profileID, SystemUserEntity userID, SystemUserProfilePropertysEntity propertyID, string propertyValuesString, byte[] propertyValuesBinary, DateTime lastUpdatedDate, int? createBy, DateTime? createAt, int? lastModifyBy, DateTime? lastModifyAt, string lastModifyComment)
		{
			_profileID = profileID;
			_userID = userID;
			_propertyID = propertyID;
			_propertyValuesString = propertyValuesString;
			_propertyValuesBinary = propertyValuesBinary;
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
		/// ??
		/// </summary>
		[DataMember]
		public virtual int ProfileID
		{
			get { return _profileID; }

			set	
			{
				_isChanged |= (_profileID != value); _profileID = value;
			}
		}

		/// <summary>
		/// ??ID
		/// </summary>
		[DataMember]
		public virtual SystemUserEntity UserID
		{
			get { return _userID; }

			set	
			{
				_isChanged |= (_userID != value); _userID = value;
			}
		}

		/// <summary>
		/// ??ID
		/// </summary>
		[DataMember]
		public virtual SystemUserProfilePropertysEntity PropertyID
		{
			get { return _propertyID; }

			set	
			{
				_isChanged |= (_propertyID != value); _propertyID = value;
			}
		}

		/// <summary>
		/// ???
		/// </summary>
		[DataMember]
		public virtual string PropertyValuesString
		{
			get { return _propertyValuesString; }

			set	
			{

				if( value != null && value.Length > 2147483646)
					throw new ArgumentOutOfRangeException("Invalid value for PropertyValuesString", value, value.ToString());
				_isChanged |= (_propertyValuesString != value); _propertyValuesString = value;
			}
		}

		/// <summary>
		/// ??????
		/// </summary>
		[DataMember]
		public virtual byte[] PropertyValuesBinary
		{
			get { return _propertyValuesBinary; }

			set	
			{

				if( value != null && value.Length > 2147483647)
					throw new ArgumentOutOfRangeException("Invalid value for PropertyValuesBinary", value, value.ToString());
				_isChanged |= (_propertyValuesBinary != value); _propertyValuesBinary = value;
			}
		}

		/// <summary>
		/// ??????
		/// </summary>
		[DataMember]
		public virtual DateTime LastUpdatedDate
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
			 return this.CheckEquals(obj as SystemUserProfileEntity);
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
	        return this._profileID;
	    }
		
		
	
		#region ICloneable methods
		
		public virtual object Clone()
		{
			return this.MemberwiseClone();
		}
		
		#endregion
	
	}
}