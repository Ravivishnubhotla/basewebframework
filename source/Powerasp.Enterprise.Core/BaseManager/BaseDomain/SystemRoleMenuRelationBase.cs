/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	系统角色菜单分配
	/// </summary>
	[Serializable]
	public abstract class SystemRoleMenuRelationBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemRoleMenuRelation";
		public static readonly string PROPERTY_NAME_MENUROLEID = "MenuRoleID";
		public static readonly string PROPERTY_NAME_MENUID = "MenuID";
		public static readonly string PROPERTY_NAME_ROLEID = "RoleID";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _menurole_id;
		private SystemMenu _menu_id;
		private SystemRole _role_id;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemRoleMenuRelationBase()
		{
			_menurole_id = 0; 
			_menu_id =  null; 
			_role_id =  null; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int MenuRoleID
		{
			get { return _menurole_id; }
			set { _isChanged |= (_menurole_id != value); _menurole_id = value; }
		}
		/// <summary>
		/// 菜单ID
		/// </summary>		
		public virtual SystemMenu MenuID
		{
			get { return _menu_id; }
			set { _isChanged |= (_menu_id != value); _menu_id = value; }
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
			SystemRoleMenuRelationBase castObj = (SystemRoleMenuRelationBase)obj; 
			return ( castObj != null ) &&
				( this._menurole_id == castObj.MenuRoleID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _menurole_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemRoleMenuRelationBase obj )
		{
			obj.MenuID = this._menu_id;
			obj.RoleID = this._role_id;
		}
        #endregion
	}
}
