/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	部门角色关系
	/// </summary>
	[Serializable]
	public abstract class SystemUserGroupRoleRelationBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemUserGroupRoleRelation";
		public static readonly string PROPERTY_NAME_USERGROUPROLEID = "UserGroupRoleID";
		public static readonly string PROPERTY_NAME_ROLEID = "RoleID";
		public static readonly string PROPERTY_NAME_USERGROUPID = "UserGroupID";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _usergrouprole_id;
		private SystemRole _role_id;
		private SystemUserGroup _usergroup_id;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemUserGroupRoleRelationBase()
		{
			_usergrouprole_id = 0; 
			_role_id =  null; 
			_usergroup_id =  null; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int UserGroupRoleID
		{
			get { return _usergrouprole_id; }
			set { _isChanged |= (_usergrouprole_id != value); _usergrouprole_id = value; }
		}
		/// <summary>
		/// 角色ID
		/// </summary>		
		public virtual SystemRole RoleID
		{
			get { return _role_id; }
			set { _isChanged |= (_role_id != value); _role_id = value; }
		}
		/// <summary>
		/// 部门ID
		/// </summary>		
		public virtual SystemUserGroup UserGroupID
		{
			get { return _usergroup_id; }
			set { _isChanged |= (_usergroup_id != value); _usergroup_id = value; }
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
			SystemUserGroupRoleRelationBase castObj = (SystemUserGroupRoleRelationBase)obj; 
			return ( castObj != null ) &&
				( this._usergrouprole_id == castObj.UserGroupRoleID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _usergrouprole_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemUserGroupRoleRelationBase obj )
		{
			obj.RoleID = this._role_id;
			obj.UserGroupID = this._usergroup_id;
		}
        #endregion
	}
}
