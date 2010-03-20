// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	角色应用分配表
	/// </summary>
	public partial class SystemRoleApplicationEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemRoleApplicationEntity";
		public static readonly string PROPERTY_NAME_SYSTEMROLEAPPLICATIONID = "SystemRoleApplicationID";
		public static readonly string PROPERTY_NAME_ROLEID = "RoleID";
		public static readonly string PROPERTY_NAME_APPLICATIONID = "ApplicationID";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _systemRoleApplicationID;
		private SystemRoleEntity _roleID;
		private SystemApplicationEntity _applicationID;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemRoleApplicationEntity()
		{
			_systemRoleApplicationID = 0;
			_roleID = null;
			_applicationID = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemRoleApplicationEntity( int systemRoleApplicationID, SystemRoleEntity roleID, SystemApplicationEntity applicationID)
		{
			_systemRoleApplicationID = systemRoleApplicationID;
			_roleID = roleID;
			_applicationID = applicationID;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int SystemRoleApplicationID
		{
			get { return _systemRoleApplicationID; }

			set	
			{
				_isChanged |= (_systemRoleApplicationID != value); _systemRoleApplicationID = value;
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
		/// 应用ID
		/// </summary>		
		public virtual SystemApplicationEntity ApplicationID
		{
			get { return _applicationID; }

			set	
			{
				_isChanged |= (_applicationID != value); _applicationID = value;
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
			
			SystemRoleApplicationEntity castObj = (SystemRoleApplicationEntity)obj;
			
			return ( castObj != null ) && ( this._systemRoleApplicationID == castObj.SystemRoleApplicationID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _systemRoleApplicationID.GetHashCode();

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
