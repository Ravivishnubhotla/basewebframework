// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;


namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	系统用户角色分配
	/// </summary>
	
	public partial class SystemUserRoleRelationEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemUserRoleRelationEntity";
		public static readonly string PROPERTY_NAME_USERROLEID = "UserRoleID";
		public static readonly string PROPERTY_NAME_USERID = "UserID";
		public static readonly string PROPERTY_NAME_ROLEID = "RoleID";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _userRoleID;
		private SystemUserEntity _userID;
		private SystemRoleEntity _roleID;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemUserRoleRelationEntity()
		{
			_userRoleID = 0;
			_userID = null;
			_roleID = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemUserRoleRelationEntity( int userRoleID, SystemUserEntity userID, SystemRoleEntity roleID)
		{
			_userRoleID = userRoleID;
			_userID = userID;
			_roleID = roleID;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// 主键
		/// </summary>
		
		public virtual int UserRoleID
		{
			get { return _userRoleID; }

			set	
			{
				_isChanged |= (_userRoleID != value); _userRoleID = value;
			}
		}

		/// <summary>
		/// 用户ID
		/// </summary>
		
		public virtual SystemUserEntity UserID
		{
			get { return _userID; }

			set	
			{
				_isChanged |= (_userID != value); _userID = value;
			}
		}

		/// <summary>
		/// 角色ID
		/// </summary>
		
		public virtual SystemRoleEntity RoleID
		{
			get { return _roleID; }

			set	
			{
				_isChanged |= (_roleID != value); _roleID = value;
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
			
			SystemUserRoleRelationEntity castObj = (SystemUserRoleRelationEntity)obj;
			
			return ( castObj != null ) && ( this._userRoleID == castObj.UserRoleID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _userRoleID.GetHashCode();

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
