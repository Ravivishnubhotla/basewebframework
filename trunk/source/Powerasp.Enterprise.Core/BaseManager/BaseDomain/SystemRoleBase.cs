/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	系统角色
	/// </summary>
	[Serializable]
	public abstract class SystemRoleBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemRole";
		public static readonly string PROPERTY_NAME_ROLEID = "RoleID";
		public static readonly string PROPERTY_NAME_ROLENAME = "RoleName";
		public static readonly string PROPERTY_NAME_ROLEDESCRIPTION = "RoleDescription";
		public static readonly string PROPERTY_NAME_ROLEISSYSTEMROLE = "RoleIsSystemRole";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _role_id;
		private string _role_name;
		private string _role_description;
		private bool _role_issystemrole;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemRoleBase()
		{
			_role_id = 0; 
			_role_name = String.Empty; 
			_role_description = String.Empty; 
			_role_issystemrole = false; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int RoleID
		{
			get { return _role_id; }
			set { _isChanged |= (_role_id != value); _role_id = value; }
		}
		/// <summary>
		/// 角色名称
		/// </summary>		
		public virtual string RoleName
		{
			get { return _role_name; }
			set	
			{
				if ( value != null)
					if( value.Length > 50)
						throw new ArgumentOutOfRangeException("Invalid value for RoleName", value, value.ToString());
				
				_isChanged |= (_role_name != value); _role_name = value;
			}
		}
		/// <summary>
		/// 角色描述
		/// </summary>		
		public virtual string RoleDescription
		{
			get { return _role_description; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for RoleDescription", value, value.ToString());
				
				_isChanged |= (_role_description != value); _role_description = value;
			}
		}
		/// <summary>
		/// 是否为系统角色
		/// </summary>		
		public virtual bool RoleIsSystemRole
		{
			get { return _role_issystemrole; }
			set { _isChanged |= (_role_issystemrole != value); _role_issystemrole = value; }
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
			SystemRoleBase castObj = (SystemRoleBase)obj; 
			return ( castObj != null ) &&
				( this._role_id == castObj.RoleID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _role_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemRoleBase obj )
		{
			obj.RoleName = this._role_name;
			obj.RoleDescription = this._role_description;
			obj.RoleIsSystemRole = this._role_issystemrole;
		}
        #endregion
	}
}
