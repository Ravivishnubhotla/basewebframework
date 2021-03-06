// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SystemUserEntity.Designer.cs">
//   Copyright (c) Foreveross Enterprises. All rights reserved.
// </copyright>
// <summary>
//   Generated by MyGeneration Version # (1.3.0.9)
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Legendigital.Framework.Common.Entity;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	System User
	/// </summary>
	[DataContract]
	public partial class SystemUserEntity  : BaseTableEntity<int>,ICloneable
	{
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemUserEntity";
		public static readonly string PROPERTY_NAME_USERID = "UserID";
		public static readonly string PROPERTY_NAME_USERLOGINID = "UserLoginID";
		public static readonly string PROPERTY_NAME_USERNAME = "UserName";
		public static readonly string PROPERTY_NAME_USEREMAIL = "UserEmail";
		public static readonly string PROPERTY_NAME_USERPASSWORD = "UserPassword";
		public static readonly string PROPERTY_NAME_USERSTATUS = "UserStatus";
		public static readonly string PROPERTY_NAME_USERCREATEDATE = "UserCreateDate";
		public static readonly string PROPERTY_NAME_USERTYPE = "UserType";
		public static readonly string PROPERTY_NAME_MOBILEPIN = "MobilePIN";
		public static readonly string PROPERTY_NAME_PASSWORDFORMAT = "PasswordFormat";
		public static readonly string PROPERTY_NAME_PASSWORDQUESTION = "PasswordQuestion";
		public static readonly string PROPERTY_NAME_PASSWORDANSWER = "PasswordAnswer";
		public static readonly string PROPERTY_NAME_COMMENTS = "Comments";
		public static readonly string PROPERTY_NAME_ISAPPROVED = "IsApproved";
		public static readonly string PROPERTY_NAME_ISLOCKEDOUT = "IsLockedOut";
		public static readonly string PROPERTY_NAME_LASTACTIVITYDATE = "LastActivityDate";
		public static readonly string PROPERTY_NAME_LASTLOGINDATE = "LastLoginDate";
		public static readonly string PROPERTY_NAME_LASTLOCKEDOUTDATE = "LastLockedOutDate";
		public static readonly string PROPERTY_NAME_LASTPASSWORDCHANGEDATE = "LastPasswordChangeDate";
		public static readonly string PROPERTY_NAME_FAILEDPWDATTEMPTCNT = "FailedPwdAttemptCnt";
		public static readonly string PROPERTY_NAME_FAILEDPWDATTEMPTWNDSTART = "FailedPwdAttemptWndStart";
		public static readonly string PROPERTY_NAME_FAILEDPWDANSATTEMPTCNT = "FailedPwdAnsAttemptCnt";
		public static readonly string PROPERTY_NAME_FAILEDPWDANSATTEMPTWNDSTART = "FailedPwdAnsAttemptWndStart";
		public static readonly string PROPERTY_NAME_ISNEEDCHGPWD = "IsNeedChgPwd";
		public static readonly string PROPERTY_NAME_PASSWORDSALT = "PasswordSalt";
		public static readonly string PROPERTY_NAME_LOWEREDEMAIL = "LoweredEmail";
		public static readonly string PROPERTY_NAME_VALIDATETYPE = "ValidateType";
		public static readonly string PROPERTY_NAME_ADDOMAIN = "ADDomain";
		public static readonly string PROPERTY_NAME_BINDUKEY = "BindUKey";
		public static readonly string PROPERTY_NAME_USBKEYSERIAL = "USBKeySerial";
		public static readonly string PROPERTY_NAME_USBKEYCODE = "USBKeyCode";
		public static readonly string PROPERTY_NAME_SSOKEY = "SSOKey";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		public static readonly string PROPERTY_NAME_LASTLOGINIP = "LastLoginIP";
		
        #endregion
	
 
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _userID;
		private string _userLoginID;
		private string _userName;
		private string _userEmail;
		private string _userPassword;
		private string _userStatus;
		private DateTime _userCreateDate;
		private string _userType;
		private string _mobilePIN;
		private int _passwordFormat;
		private string _passwordQuestion;
		private string _passwordAnswer;
		private string _comments;
		private bool _isApproved;
		private bool _isLockedOut;
		private DateTime _lastActivityDate;
		private DateTime _lastLoginDate;
		private DateTime _lastLockedOutDate;
		private DateTime _lastPasswordChangeDate;
		private int _failedPwdAttemptCnt;
		private DateTime _failedPwdAttemptWndStart;
		private int _failedPwdAnsAttemptCnt;
		private DateTime _failedPwdAnsAttemptWndStart;
		private bool _isNeedChgPwd;
		private string _passwordSalt;
		private string _loweredEmail;
		private string _validateType;
		private string _aDDomain;
		private bool? _bindUKey;
		private string _uSBKeySerial;
		private string _uSBKeyCode;
		private string _sSOKey;
		private int? _createBy;
		private DateTime? _createAt;
		private int? _lastModifyBy;
		private DateTime? _lastModifyAt;
		private string _lastModifyComment;
		private string _lastLoginIP;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemUserEntity()
		{
			_userID = 0;
			_userLoginID = String.Empty;
			_userName = String.Empty;
			_userEmail = String.Empty;
			_userPassword = String.Empty;
			_userStatus = String.Empty;
			_userCreateDate = DateTime.MinValue;
			_userType = String.Empty;
			_mobilePIN = null;
			_passwordFormat = 0;
			_passwordQuestion = null;
			_passwordAnswer = null;
			_comments = null;
			_isApproved = false;
			_isLockedOut = false;
			_lastActivityDate = DateTime.MinValue;
			_lastLoginDate = DateTime.MinValue;
			_lastLockedOutDate = DateTime.MinValue;
			_lastPasswordChangeDate = DateTime.MinValue;
			_failedPwdAttemptCnt = 0;
			_failedPwdAttemptWndStart = DateTime.MinValue;
			_failedPwdAnsAttemptCnt = 0;
			_failedPwdAnsAttemptWndStart = DateTime.MinValue;
			_isNeedChgPwd = false;
			_passwordSalt = null;
			_loweredEmail = null;
			_validateType = null;
			_aDDomain = null;
			_bindUKey = null;
			_uSBKeySerial = null;
			_uSBKeyCode = null;
			_sSOKey = null;
			_createBy = null;
			_createAt = null;
			_lastModifyBy = null;
			_lastModifyAt = null;
			_lastModifyComment = null;
			_lastLoginIP = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemUserEntity( int userID, string userLoginID, string userName, string userEmail, string userPassword, string userStatus, DateTime userCreateDate, string userType, string mobilePIN, int passwordFormat, string passwordQuestion, string passwordAnswer, string comments, bool isApproved, bool isLockedOut, DateTime lastActivityDate, DateTime lastLoginDate, DateTime lastLockedOutDate, DateTime lastPasswordChangeDate, int failedPwdAttemptCnt, DateTime failedPwdAttemptWndStart, int failedPwdAnsAttemptCnt, DateTime failedPwdAnsAttemptWndStart, bool isNeedChgPwd, string passwordSalt, string loweredEmail, string validateType, string aDDomain, bool? bindUKey, string uSBKeySerial, string uSBKeyCode, string sSOKey, int? createBy, DateTime? createAt, int? lastModifyBy, DateTime? lastModifyAt, string lastModifyComment, string lastLoginIP)
		{
			_userID = userID;
			_userLoginID = userLoginID;
			_userName = userName;
			_userEmail = userEmail;
			_userPassword = userPassword;
			_userStatus = userStatus;
			_userCreateDate = userCreateDate;
			_userType = userType;
			_mobilePIN = mobilePIN;
			_passwordFormat = passwordFormat;
			_passwordQuestion = passwordQuestion;
			_passwordAnswer = passwordAnswer;
			_comments = comments;
			_isApproved = isApproved;
			_isLockedOut = isLockedOut;
			_lastActivityDate = lastActivityDate;
			_lastLoginDate = lastLoginDate;
			_lastLockedOutDate = lastLockedOutDate;
			_lastPasswordChangeDate = lastPasswordChangeDate;
			_failedPwdAttemptCnt = failedPwdAttemptCnt;
			_failedPwdAttemptWndStart = failedPwdAttemptWndStart;
			_failedPwdAnsAttemptCnt = failedPwdAnsAttemptCnt;
			_failedPwdAnsAttemptWndStart = failedPwdAnsAttemptWndStart;
			_isNeedChgPwd = isNeedChgPwd;
			_passwordSalt = passwordSalt;
			_loweredEmail = loweredEmail;
			_validateType = validateType;
			_aDDomain = aDDomain;
			_bindUKey = bindUKey;
			_uSBKeySerial = uSBKeySerial;
			_uSBKeyCode = uSBKeyCode;
			_sSOKey = sSOKey;
			_createBy = createBy;
			_createAt = createAt;
			_lastModifyBy = lastModifyBy;
			_lastModifyAt = lastModifyAt;
			_lastModifyComment = lastModifyComment;
			_lastLoginIP = lastLoginIP;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// Primary Key
		/// </summary>
		[DataMember]
		public virtual int UserID
		{
			get { return _userID; }

			set	
			{
				_isChanged |= (_userID != value); _userID = value;
			}
		}

		/// <summary>
		/// Login ID
		/// </summary>
		[DataMember]
		public virtual string UserLoginID
		{
			get { return _userLoginID; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for UserLoginID", value, value.ToString());
				_isChanged |= (_userLoginID != value); _userLoginID = value;
			}
		}

		/// <summary>
		/// User Name
		/// </summary>
		[DataMember]
		public virtual string UserName
		{
			get { return _userName; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for UserName", value, value.ToString());
				_isChanged |= (_userName != value); _userName = value;
			}
		}

		/// <summary>
		/// Email
		/// </summary>
		[DataMember]
		public virtual string UserEmail
		{
			get { return _userEmail; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for UserEmail", value, value.ToString());
				_isChanged |= (_userEmail != value); _userEmail = value;
			}
		}

		/// <summary>
		/// Password
		/// </summary>
		[DataMember]
		public virtual string UserPassword
		{
			get { return _userPassword; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for UserPassword", value, value.ToString());
				_isChanged |= (_userPassword != value); _userPassword = value;
			}
		}

		/// <summary>
		/// Status
		/// </summary>
		[DataMember]
		public virtual string UserStatus
		{
			get { return _userStatus; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for UserStatus", value, value.ToString());
				_isChanged |= (_userStatus != value); _userStatus = value;
			}
		}

		/// <summary>
		/// Create Date
		/// </summary>
		[DataMember]
		public virtual DateTime UserCreateDate
		{
			get { return _userCreateDate; }

			set	
			{
				_isChanged |= (_userCreateDate != value); _userCreateDate = value;
			}
		}

		/// <summary>
		/// User Type
		/// </summary>
		[DataMember]
		public virtual string UserType
		{
			get { return _userType; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for UserType", value, value.ToString());
				_isChanged |= (_userType != value); _userType = value;
			}
		}

		/// <summary>
		/// MobilePIN
		/// </summary>
		[DataMember]
		public virtual string MobilePIN
		{
			get { return _mobilePIN; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for MobilePIN", value, value.ToString());
				_isChanged |= (_mobilePIN != value); _mobilePIN = value;
			}
		}

		/// <summary>
		/// PasswordF ormat
		/// </summary>
		[DataMember]
		public virtual int PasswordFormat
		{
			get { return _passwordFormat; }

			set	
			{
				_isChanged |= (_passwordFormat != value); _passwordFormat = value;
			}
		}

		/// <summary>
		/// Password Question
		/// </summary>
		[DataMember]
		public virtual string PasswordQuestion
		{
			get { return _passwordQuestion; }

			set	
			{

				if( value != null && value.Length > 510)
					throw new ArgumentOutOfRangeException("Invalid value for PasswordQuestion", value, value.ToString());
				_isChanged |= (_passwordQuestion != value); _passwordQuestion = value;
			}
		}

		/// <summary>
		/// Password Answer
		/// </summary>
		[DataMember]
		public virtual string PasswordAnswer
		{
			get { return _passwordAnswer; }

			set	
			{

				if( value != null && value.Length > 510)
					throw new ArgumentOutOfRangeException("Invalid value for PasswordAnswer", value, value.ToString());
				_isChanged |= (_passwordAnswer != value); _passwordAnswer = value;
			}
		}

		/// <summary>
		/// Comments
		/// </summary>
		[DataMember]
		public virtual string Comments
		{
			get { return _comments; }

			set	
			{

				if( value != null && value.Length > 6000)
					throw new ArgumentOutOfRangeException("Invalid value for Comments", value, value.ToString());
				_isChanged |= (_comments != value); _comments = value;
			}
		}

		/// <summary>
		/// Is Approved
		/// </summary>
		[DataMember]
		public virtual bool IsApproved
		{
			get { return _isApproved; }

			set	
			{
				_isChanged |= (_isApproved != value); _isApproved = value;
			}
		}

		/// <summary>
		/// Is Locked Out
		/// </summary>
		[DataMember]
		public virtual bool IsLockedOut
		{
			get { return _isLockedOut; }

			set	
			{
				_isChanged |= (_isLockedOut != value); _isLockedOut = value;
			}
		}

		/// <summary>
		/// Last Activity Date
		/// </summary>
		[DataMember]
		public virtual DateTime LastActivityDate
		{
			get { return _lastActivityDate; }

			set	
			{
				_isChanged |= (_lastActivityDate != value); _lastActivityDate = value;
			}
		}

		/// <summary>
		/// Last Login Date
		/// </summary>
		[DataMember]
		public virtual DateTime LastLoginDate
		{
			get { return _lastLoginDate; }

			set	
			{
				_isChanged |= (_lastLoginDate != value); _lastLoginDate = value;
			}
		}

		/// <summary>
		/// Last Locked Out Date
		/// </summary>
		[DataMember]
		public virtual DateTime LastLockedOutDate
		{
			get { return _lastLockedOutDate; }

			set	
			{
				_isChanged |= (_lastLockedOutDate != value); _lastLockedOutDate = value;
			}
		}

		/// <summary>
		/// Last Password Change Date
		/// </summary>
		[DataMember]
		public virtual DateTime LastPasswordChangeDate
		{
			get { return _lastPasswordChangeDate; }

			set	
			{
				_isChanged |= (_lastPasswordChangeDate != value); _lastPasswordChangeDate = value;
			}
		}

		/// <summary>
		/// Failed Password Attempt Count
		/// </summary>
		[DataMember]
		public virtual int FailedPwdAttemptCnt
		{
			get { return _failedPwdAttemptCnt; }

			set	
			{
				_isChanged |= (_failedPwdAttemptCnt != value); _failedPwdAttemptCnt = value;
			}
		}

		/// <summary>
		/// Failed Password Attempt DateTime
		/// </summary>
		[DataMember]
		public virtual DateTime FailedPwdAttemptWndStart
		{
			get { return _failedPwdAttemptWndStart; }

			set	
			{
				_isChanged |= (_failedPwdAttemptWndStart != value); _failedPwdAttemptWndStart = value;
			}
		}

		/// <summary>
		/// Failed Password Answer Attempt Count
		/// </summary>
		[DataMember]
		public virtual int FailedPwdAnsAttemptCnt
		{
			get { return _failedPwdAnsAttemptCnt; }

			set	
			{
				_isChanged |= (_failedPwdAnsAttemptCnt != value); _failedPwdAnsAttemptCnt = value;
			}
		}

		/// <summary>
		/// Failed Password Answer Attempt DateTime
		/// </summary>
		[DataMember]
		public virtual DateTime FailedPwdAnsAttemptWndStart
		{
			get { return _failedPwdAnsAttemptWndStart; }

			set	
			{
				_isChanged |= (_failedPwdAnsAttemptWndStart != value); _failedPwdAnsAttemptWndStart = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool IsNeedChgPwd
		{
			get { return _isNeedChgPwd; }

			set	
			{
				_isChanged |= (_isNeedChgPwd != value); _isNeedChgPwd = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string PasswordSalt
		{
			get { return _passwordSalt; }

			set	
			{

				if( value != null && value.Length > 256)
					throw new ArgumentOutOfRangeException("Invalid value for PasswordSalt", value, value.ToString());
				_isChanged |= (_passwordSalt != value); _passwordSalt = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string LoweredEmail
		{
			get { return _loweredEmail; }

			set	
			{

				if( value != null && value.Length > 256)
					throw new ArgumentOutOfRangeException("Invalid value for LoweredEmail", value, value.ToString());
				_isChanged |= (_loweredEmail != value); _loweredEmail = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ValidateType
		{
			get { return _validateType; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ValidateType", value, value.ToString());
				_isChanged |= (_validateType != value); _validateType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ADDomain
		{
			get { return _aDDomain; }

			set	
			{

				if( value != null && value.Length > 1000)
					throw new ArgumentOutOfRangeException("Invalid value for ADDomain", value, value.ToString());
				_isChanged |= (_aDDomain != value); _aDDomain = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? BindUKey
		{
			get { return _bindUKey; }

			set	
			{
				_isChanged |= (_bindUKey != value); _bindUKey = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string USBKeySerial
		{
			get { return _uSBKeySerial; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for USBKeySerial", value, value.ToString());
				_isChanged |= (_uSBKeySerial != value); _uSBKeySerial = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string USBKeyCode
		{
			get { return _uSBKeyCode; }

			set	
			{

				if( value != null && value.Length > 1000)
					throw new ArgumentOutOfRangeException("Invalid value for USBKeyCode", value, value.ToString());
				_isChanged |= (_uSBKeyCode != value); _uSBKeyCode = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string SSOKey
		{
			get { return _sSOKey; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for SSOKey", value, value.ToString());
				_isChanged |= (_sSOKey != value); _sSOKey = value;
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

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string LastLoginIP
		{
			get { return _lastLoginIP; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for LastLoginIP", value, value.ToString());
				_isChanged |= (_lastLoginIP != value); _lastLoginIP = value;
			}
		}
	

		#endregion 

        

		#region Equals 和 HashCode 方法覆盖
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			 return this.CheckEquals(obj as SystemUserEntity);
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			return GetEntityHashCode();
		}
		#endregion
		
		public override int GetDataEntityKey()
	    {
	        return this._userID;
	    }
		
		
	
		#region ICloneable methods
		
		public virtual object Clone()
		{
			return this.MemberwiseClone();
		}
		
		#endregion
	
	}
}
