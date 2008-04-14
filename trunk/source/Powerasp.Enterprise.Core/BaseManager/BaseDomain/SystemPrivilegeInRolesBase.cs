/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	角色权限分配
	/// </summary>
	[Serializable]
	public abstract class SystemPrivilegeInRolesBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemPrivilegeInRoles";
		public static readonly string PROPERTY_NAME_PRIVILEGEROLEID = "PrivilegeRoleID";
		public static readonly string PROPERTY_NAME_ROLEID = "RoleID";
		public static readonly string PROPERTY_NAME_PRIVILEGEID = "PrivilegeID";
		public static readonly string PROPERTY_NAME_PRIVILEGEROLEVALUE = "PrivilegeRoleValue";
		public static readonly string PROPERTY_NAME_ENABLETYPE = "EnableType";
		public static readonly string PROPERTY_NAME_CREATETIME = "CreateTime";
		public static readonly string PROPERTY_NAME_UPDATETIME = "UpdateTime";
		public static readonly string PROPERTY_NAME_EXPIRYTIME = "ExpiryTime";
		public static readonly string PROPERTY_NAME_ENABLEPARAMETER = "EnableParameter";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _privilegeroleid;
		private SystemRole _role_id;
		private SystemPrivilege _privilege_id;
		private string _privilegerolevalue;
		private string _enabletype;
		private DateTime? _createtime;
		private DateTime? _updatetime;
		private DateTime? _expirytime;
		private bool _enableparameter;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemPrivilegeInRolesBase()
		{
			_privilegeroleid = 0; 
			_role_id =  null; 
			_privilege_id =  null; 
			_privilegerolevalue = String.Empty; 
			_enabletype = String.Empty; 
			_createtime =  null;  
			_updatetime =  null;  
			_expirytime =  null;  
			_enableparameter = false; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int PrivilegeRoleID
		{
			get { return _privilegeroleid; }
			set { _isChanged |= (_privilegeroleid != value); _privilegeroleid = value; }
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
		/// 权限ID
		/// </summary>		
		public virtual SystemPrivilege PrivilegeID
		{
			get { return _privilege_id; }
			set { _isChanged |= (_privilege_id != value); _privilege_id = value; }
		}
		/// <summary>
		/// 权限分配值
		/// </summary>		
		public virtual string PrivilegeRoleValue
		{
			get { return _privilegerolevalue; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for PrivilegeRoleValue", value, value.ToString());
				
				_isChanged |= (_privilegerolevalue != value); _privilegerolevalue = value;
			}
		}
		/// <summary>
		/// 授权类型
		/// </summary>		
		public virtual string EnableType
		{
			get { return _enabletype; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for EnableType", value, value.ToString());
				
				_isChanged |= (_enabletype != value); _enabletype = value;
			}
		}
		/// <summary>
		/// 创建时间
		/// </summary>		
		public virtual DateTime? CreateTime
		{
			get { return _createtime; }
			set { _isChanged |= (_createtime != value); _createtime = value; }
		}
		/// <summary>
		/// 最后更新时间
		/// </summary>		
		public virtual DateTime? UpdateTime
		{
			get { return _updatetime; }
			set { _isChanged |= (_updatetime != value); _updatetime = value; }
		}
		/// <summary>
		/// 过期时间
		/// </summary>		
		public virtual DateTime? ExpiryTime
		{
			get { return _expirytime; }
			set { _isChanged |= (_expirytime != value); _expirytime = value; }
		}
		/// <summary>
		/// 是否允许参数
		/// </summary>		
		public virtual bool EnableParameter
		{
			get { return _enableparameter; }
			set { _isChanged |= (_enableparameter != value); _enableparameter = value; }
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
			SystemPrivilegeInRolesBase castObj = (SystemPrivilegeInRolesBase)obj; 
			return ( castObj != null ) &&
				( this._privilegeroleid == castObj.PrivilegeRoleID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _privilegeroleid.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemPrivilegeInRolesBase obj )
		{
			obj.RoleID = this._role_id;
			obj.PrivilegeID = this._privilege_id;
			obj.PrivilegeRoleValue = this._privilegerolevalue;
			obj.EnableType = this._enabletype;
			obj.CreateTime = this._createtime;
			obj.UpdateTime = this._updatetime;
			obj.ExpiryTime = this._expirytime;
			obj.EnableParameter = this._enableparameter;
		}
        #endregion
	}
}
