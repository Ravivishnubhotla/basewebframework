// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	用户用户组对应关系
	/// </summary>
	[DataContract]
	public partial class SystemUserGroupUserRelationEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemUserGroupUserRelationEntity";
		public static readonly string PROPERTY_NAME_USERGROUPUSERID = "UserGroupUserID";
		public static readonly string PROPERTY_NAME_USERID = "UserID";
		public static readonly string PROPERTY_NAME_USERGROUPID = "UserGroupID";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
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
		/// 主键
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
		/// 用户
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
		/// 用户组
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
		/// <summary>
		/// 返回对象是否被改变。
		/// </summary>
		public virtual bool IsChanged
		{
			get { return _isChanged; }
		}
		
		/// <summary>
		/// Returns whether or not the object has changed it's values.
		/// </summary>
		public virtual bool IsDeleted
		{
			get { return _isDeleted; }
		}
		
		#endregion 

        #region 公共方法
		
		/// <summary>
		/// mark the item as deleted
		/// </summary>
		public virtual void MarkAsDeleted()
		{
			_isDeleted = true;
			_isChanged = true;
		}
		
		#endregion

		#region Equals 和 HashCode 方法覆盖
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			if( this == obj ) return true;
			
			if( ( obj == null ) || ( obj.GetType() != this.GetType() ) ) return false;
			
			SystemUserGroupUserRelationEntity castObj = (SystemUserGroupUserRelationEntity)obj;
			
			return ( castObj != null ) && ( this._userGroupUserID == castObj.UserGroupUserID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _userGroupUserID.GetHashCode();

			return hash; 
		}
		#endregion
	
		#region ICloneable methods
		
		public virtual object Clone()
		{
			return this.MemberwiseClone();
		}
		
		#endregion
	
	}
}
