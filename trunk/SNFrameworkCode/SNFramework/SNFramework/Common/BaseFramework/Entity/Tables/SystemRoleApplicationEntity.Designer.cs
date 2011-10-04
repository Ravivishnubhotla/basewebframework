// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	???????
	/// </summary>
	[DataContract]
	public partial class SystemRoleApplicationEntity : ICloneable
	{
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemRoleApplicationEntity";
		public static readonly string PROPERTY_NAME_SYSTEMROLEAPPLICATIONID = "SystemRoleApplicationID";
		public static readonly string PROPERTY_NAME_ROLEID = "RoleID";
		public static readonly string PROPERTY_NAME_APPLICATIONID = "ApplicationID";
		
        #endregion
	
 
		#region roleID字段外键查询字段
        public static readonly string PROPERTY_ROLEID_ALIAS_NAME = "RoleID_SystemRoleApplicationEntity_Alias";
		public static readonly string PROPERTY_ROLEID_ROLEID = "RoleID_SystemRoleApplicationEntity_Alias.RoleID";
		public static readonly string PROPERTY_ROLEID_ROLENAME = "RoleID_SystemRoleApplicationEntity_Alias.RoleName";
		public static readonly string PROPERTY_ROLEID_ROLECODE = "RoleID_SystemRoleApplicationEntity_Alias.RoleCode";
		public static readonly string PROPERTY_ROLEID_ROLEDESCRIPTION = "RoleID_SystemRoleApplicationEntity_Alias.RoleDescription";
		public static readonly string PROPERTY_ROLEID_ROLEISSYSTEMROLE = "RoleID_SystemRoleApplicationEntity_Alias.RoleIsSystemRole";
		public static readonly string PROPERTY_ROLEID_ROLETYPE = "RoleID_SystemRoleApplicationEntity_Alias.RoleType";
		public static readonly string PROPERTY_ROLEID_CREATEBY = "RoleID_SystemRoleApplicationEntity_Alias.CreateBy";
		public static readonly string PROPERTY_ROLEID_CREATEAT = "RoleID_SystemRoleApplicationEntity_Alias.CreateAt";
		public static readonly string PROPERTY_ROLEID_LASTMODIFYBY = "RoleID_SystemRoleApplicationEntity_Alias.LastModifyBy";
		public static readonly string PROPERTY_ROLEID_LASTMODIFYAT = "RoleID_SystemRoleApplicationEntity_Alias.LastModifyAt";
		public static readonly string PROPERTY_ROLEID_LASTMODIFYCOMMENT = "RoleID_SystemRoleApplicationEntity_Alias.LastModifyComment";
		#endregion
		#region applicationID字段外键查询字段
        public static readonly string PROPERTY_APPLICATIONID_ALIAS_NAME = "ApplicationID_SystemRoleApplicationEntity_Alias";
		public static readonly string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONID = "ApplicationID_SystemRoleApplicationEntity_Alias.SystemApplicationID";
		public static readonly string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONNAME = "ApplicationID_SystemRoleApplicationEntity_Alias.SystemApplicationName";
		public static readonly string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONCODE = "ApplicationID_SystemRoleApplicationEntity_Alias.SystemApplicationCode";
		public static readonly string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONDESCRIPTION = "ApplicationID_SystemRoleApplicationEntity_Alias.SystemApplicationDescription";
		public static readonly string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONURL = "ApplicationID_SystemRoleApplicationEntity_Alias.SystemApplicationUrl";
		public static readonly string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONISSYSTEMAPPLICATION = "ApplicationID_SystemRoleApplicationEntity_Alias.SystemApplicationIsSystemApplication";
		public static readonly string PROPERTY_APPLICATIONID_ORDERINDEX = "ApplicationID_SystemRoleApplicationEntity_Alias.OrderIndex";
		public static readonly string PROPERTY_APPLICATIONID_CREATEBY = "ApplicationID_SystemRoleApplicationEntity_Alias.CreateBy";
		public static readonly string PROPERTY_APPLICATIONID_CREATEAT = "ApplicationID_SystemRoleApplicationEntity_Alias.CreateAt";
		public static readonly string PROPERTY_APPLICATIONID_LASTMODIFYBY = "ApplicationID_SystemRoleApplicationEntity_Alias.LastModifyBy";
		public static readonly string PROPERTY_APPLICATIONID_LASTMODIFYAT = "ApplicationID_SystemRoleApplicationEntity_Alias.LastModifyAt";
		public static readonly string PROPERTY_APPLICATIONID_LASTMODIFYCOMMENT = "ApplicationID_SystemRoleApplicationEntity_Alias.LastModifyComment";
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
		/// ??
		/// </summary>
		[DataMember]
		public virtual int SystemRoleApplicationID
		{
			get { return _systemRoleApplicationID; }

			set	
			{
				_isChanged |= (_systemRoleApplicationID != value); _systemRoleApplicationID = value;
			}
		}

		/// <summary>
		/// ??ID
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
		/// ??ID
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
