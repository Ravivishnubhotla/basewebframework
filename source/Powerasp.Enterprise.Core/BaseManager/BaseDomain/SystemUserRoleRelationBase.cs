/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	系统用户角色分配
	/// </summary>
	[Serializable]
	public abstract class SystemUserRoleRelationBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemUserRoleRelation";
		public static readonly string PROPERTY_NAME_USERROLEID = "UserRoleID";
		public static readonly string PROPERTY_NAME_USERID = "UserID";
		public static readonly string PROPERTY_NAME_ROLEID = "RoleID";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _userrole_id;
		private SystemUser _user_id;
		private SystemRole _role_id;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemUserRoleRelationBase()
		{
			_userrole_id = 0; 
			_user_id =  null; 
			_role_id =  null; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int UserRoleID
		{
			get { return _userrole_id; }
			set { _isChanged |= (_userrole_id != value); _userrole_id = value; }
		}
		/// <summary>
		/// 用户ID
		/// </summary>		
		public virtual SystemUser UserID
		{
			get { return _user_id; }
			set { _isChanged |= (_user_id != value); _user_id = value; }
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
			SystemUserRoleRelationBase castObj = (SystemUserRoleRelationBase)obj; 
			return ( castObj != null ) &&
				( this._userrole_id == castObj.UserRoleID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _userrole_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemUserRoleRelationBase obj )
		{
			obj.UserID = this._user_id;
			obj.RoleID = this._role_id;
		}
        #endregion
	}
}
