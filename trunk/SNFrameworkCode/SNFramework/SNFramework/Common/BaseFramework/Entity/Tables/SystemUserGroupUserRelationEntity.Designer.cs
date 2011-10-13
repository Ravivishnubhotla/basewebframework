// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Legendigital.Framework.Common.Entity;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	?????????
	/// </summary>
	[DataContract]
	public partial class SystemUserGroupUserRelationEntity  : BaseTableEntity,ICloneable
	{
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemUserGroupUserRelationEntity";
		public static readonly string PROPERTY_NAME_USERGROUPUSERID = "UserGroupUserID";
		public static readonly string PROPERTY_NAME_USERID = "UserID";
		public static readonly string PROPERTY_NAME_USERGROUPID = "UserGroupID";
		
        #endregion
	
 
		#region userID字段外键查询字段
        public const string PROPERTY_USERID_ALIAS_NAME = "UserID_SystemUserGroupUserRelationEntity_Alias";
		public const string PROPERTY_USERID_USERID = "UserID_SystemUserGroupUserRelationEntity_Alias.UserID";
		public const string PROPERTY_USERID_USERLOGINID = "UserID_SystemUserGroupUserRelationEntity_Alias.UserLoginID";
		public const string PROPERTY_USERID_USERNAME = "UserID_SystemUserGroupUserRelationEntity_Alias.UserName";
		public const string PROPERTY_USERID_USEREMAIL = "UserID_SystemUserGroupUserRelationEntity_Alias.UserEmail";
		public const string PROPERTY_USERID_USERPASSWORD = "UserID_SystemUserGroupUserRelationEntity_Alias.UserPassword";
		public const string PROPERTY_USERID_USERSTATUS = "UserID_SystemUserGroupUserRelationEntity_Alias.UserStatus";
		public const string PROPERTY_USERID_USERCREATEDATE = "UserID_SystemUserGroupUserRelationEntity_Alias.UserCreateDate";
		public const string PROPERTY_USERID_USERTYPE = "UserID_SystemUserGroupUserRelationEntity_Alias.UserType";
		public const string PROPERTY_USERID_DEPARTMENTID = "UserID_SystemUserGroupUserRelationEntity_Alias.DepartmentID";
		public const string PROPERTY_USERID_MOBILEPIN = "UserID_SystemUserGroupUserRelationEntity_Alias.MobilePIN";
		public const string PROPERTY_USERID_PASSWORDFORMAT = "UserID_SystemUserGroupUserRelationEntity_Alias.PasswordFormat";
		public const string PROPERTY_USERID_PASSWORDQUESTION = "UserID_SystemUserGroupUserRelationEntity_Alias.PasswordQuestion";
		public const string PROPERTY_USERID_PASSWORDANSWER = "UserID_SystemUserGroupUserRelationEntity_Alias.PasswordAnswer";
		public const string PROPERTY_USERID_COMMENTS = "UserID_SystemUserGroupUserRelationEntity_Alias.Comments";
		public const string PROPERTY_USERID_ISAPPROVED = "UserID_SystemUserGroupUserRelationEntity_Alias.IsApproved";
		public const string PROPERTY_USERID_ISLOCKEDOUT = "UserID_SystemUserGroupUserRelationEntity_Alias.IsLockedOut";
		public const string PROPERTY_USERID_LASTACTIVITYDATE = "UserID_SystemUserGroupUserRelationEntity_Alias.LastActivityDate";
		public const string PROPERTY_USERID_LASTLOGINDATE = "UserID_SystemUserGroupUserRelationEntity_Alias.LastLoginDate";
		public const string PROPERTY_USERID_LASTLOCKEDOUTDATE = "UserID_SystemUserGroupUserRelationEntity_Alias.LastLockedOutDate";
		public const string PROPERTY_USERID_LASTPASSWORDCHANGEDATE = "UserID_SystemUserGroupUserRelationEntity_Alias.LastPasswordChangeDate";
		public const string PROPERTY_USERID_FAILEDPWDATTEMPTCNT = "UserID_SystemUserGroupUserRelationEntity_Alias.FailedPwdAttemptCnt";
		public const string PROPERTY_USERID_FAILEDPWDATTEMPTWNDSTART = "UserID_SystemUserGroupUserRelationEntity_Alias.FailedPwdAttemptWndStart";
		public const string PROPERTY_USERID_FAILEDPWDANSATTEMPTCNT = "UserID_SystemUserGroupUserRelationEntity_Alias.FailedPwdAnsAttemptCnt";
		public const string PROPERTY_USERID_FAILEDPWDANSATTEMPTWNDSTART = "UserID_SystemUserGroupUserRelationEntity_Alias.FailedPwdAnsAttemptWndStart";
		public const string PROPERTY_USERID_ISNEEDCHGPWD = "UserID_SystemUserGroupUserRelationEntity_Alias.IsNeedChgPwd";
		public const string PROPERTY_USERID_PASSWORDSALT = "UserID_SystemUserGroupUserRelationEntity_Alias.PasswordSalt";
		public const string PROPERTY_USERID_LOWEREDEMAIL = "UserID_SystemUserGroupUserRelationEntity_Alias.LoweredEmail";
		public const string PROPERTY_USERID_CREATEBY = "UserID_SystemUserGroupUserRelationEntity_Alias.CreateBy";
		public const string PROPERTY_USERID_CREATEAT = "UserID_SystemUserGroupUserRelationEntity_Alias.CreateAt";
		public const string PROPERTY_USERID_LASTMODIFYBY = "UserID_SystemUserGroupUserRelationEntity_Alias.LastModifyBy";
		public const string PROPERTY_USERID_LASTMODIFYAT = "UserID_SystemUserGroupUserRelationEntity_Alias.LastModifyAt";
		public const string PROPERTY_USERID_LASTMODIFYCOMMENT = "UserID_SystemUserGroupUserRelationEntity_Alias.LastModifyComment";
		#endregion
		#region userGroupID字段外键查询字段
        public const string PROPERTY_USERGROUPID_ALIAS_NAME = "UserGroupID_SystemUserGroupUserRelationEntity_Alias";
		public const string PROPERTY_USERGROUPID_GROUPID = "UserGroupID_SystemUserGroupUserRelationEntity_Alias.GroupID";
		public const string PROPERTY_USERGROUPID_GROUPNAMECN = "UserGroupID_SystemUserGroupUserRelationEntity_Alias.GroupNameCn";
		public const string PROPERTY_USERGROUPID_GROUPNAMEEN = "UserGroupID_SystemUserGroupUserRelationEntity_Alias.GroupNameEn";
		public const string PROPERTY_USERGROUPID_GROUPDESCRIPTION = "UserGroupID_SystemUserGroupUserRelationEntity_Alias.GroupDescription";
		public const string PROPERTY_USERGROUPID_CREATEBY = "UserGroupID_SystemUserGroupUserRelationEntity_Alias.CreateBy";
		public const string PROPERTY_USERGROUPID_CREATEAT = "UserGroupID_SystemUserGroupUserRelationEntity_Alias.CreateAt";
		public const string PROPERTY_USERGROUPID_LASTMODIFYBY = "UserGroupID_SystemUserGroupUserRelationEntity_Alias.LastModifyBy";
		public const string PROPERTY_USERGROUPID_LASTMODIFYAT = "UserGroupID_SystemUserGroupUserRelationEntity_Alias.LastModifyAt";
		public const string PROPERTY_USERGROUPID_LASTMODIFYCOMMENT = "UserGroupID_SystemUserGroupUserRelationEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _userGroupUserID;
		private SystemUserEntity _userID;
		private SystemUserGroupEntity _userGroupID;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemUserGroupUserRelationEntity()
		{
			_userGroupUserID = 0;
			_userID = null;
			_userGroupID = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemUserGroupUserRelationEntity( int userGroupUserID, SystemUserEntity userID, SystemUserGroupEntity userGroupID)
		{
			_userGroupUserID = userGroupUserID;
			_userID = userID;
			_userGroupID = userGroupID;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// ??
		/// </summary>
		[DataMember]
		public virtual int UserGroupUserID
		{
			get { return _userGroupUserID; }

			set	
			{
				_isChanged |= (_userGroupUserID != value); _userGroupUserID = value;
			}
		}

		/// <summary>
		/// ??
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
		/// ???
		/// </summary>
		[DataMember]
		public virtual SystemUserGroupEntity UserGroupID
		{
			get { return _userGroupID; }

			set	
			{
				_isChanged |= (_userGroupID != value); _userGroupID = value;
			}
		}
	

		#endregion 

        

		#region Equals 和 HashCode 方法覆盖
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			 return this.CheckEquals(obj as SystemUserGroupUserRelationEntity);
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
	        return this._userGroupUserID;
	    }
		
		
	
		#region ICloneable methods
		
		public virtual object Clone()
		{
			return this.MemberwiseClone();
		}
		
		#endregion
	
	}
}
