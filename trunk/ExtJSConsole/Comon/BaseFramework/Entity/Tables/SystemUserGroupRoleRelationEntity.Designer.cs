// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	部门角色关系
	/// </summary>
	public partial class SystemUserGroupRoleRelationEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemUserGroupRoleRelationEntity";
		public static readonly string PROPERTY_NAME_USERGROUPROLEID = "UserGroupRoleID";
		public static readonly string PROPERTY_NAME_ROLEID = "RoleID";
		public static readonly string PROPERTY_NAME_USERGROUPID = "UserGroupID";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _userGroupRoleID;
		private SystemRoleEntity _roleID;
		private SystemUserGroupEntity _userGroupID;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemUserGroupRoleRelationEntity()
		{
			_userGroupRoleID = 0;
			_roleID = null;
			_userGroupID = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemUserGroupRoleRelationEntity( int userGroupRoleID, SystemRoleEntity roleID, SystemUserGroupEntity userGroupID)
		{
			_userGroupRoleID = userGroupRoleID;
			_roleID = roleID;
			_userGroupID = userGroupID;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// 主键
		/// </summary>
		[DataMember]
		public virtual int UserGroupRoleID
		{
			get { return _userGroupRoleID; }

			set	
			{
				_isChanged |= (_userGroupRoleID != value); _userGroupRoleID = value;
			}
		}

		/// <summary>
		/// 角色ID
		/// </summary>
		[DataMember]
		public virtual SystemRoleEntity RoleID
		{
			get { return _roleID; }

			set	
			{
				_isChanged |= (_roleID != value); _roleID = value;
			}
		}

		/// <summary>
		/// 部门ID
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
			
			SystemUserGroupRoleRelationEntity castObj = (SystemUserGroupRoleRelationEntity)obj;
			
			return ( castObj != null ) && ( this._userGroupRoleID == castObj.UserGroupRoleID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _userGroupRoleID.GetHashCode();

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