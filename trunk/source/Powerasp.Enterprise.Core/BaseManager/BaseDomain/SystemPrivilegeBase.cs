/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	系统权限
	/// </summary>
	[Serializable]
	public abstract class SystemPrivilegeBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemPrivilege";
		public static readonly string PROPERTY_NAME_PRIVILEGEID = "PrivilegeID";
		public static readonly string PROPERTY_NAME_OPERATIONID = "OperationID";
		public static readonly string PROPERTY_NAME_RESOURCESID = "ResourcesID";
		public static readonly string PROPERTY_NAME_PRIVILEGECNNAME = "PrivilegeCnName";
		public static readonly string PROPERTY_NAME_PRIVILEGEENNAME = "PrivilegeEnName";
		public static readonly string PROPERTY_NAME_DEFAULTVALUE = "DefaultValue";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_PRIVILEGEORDER = "PrivilegeOrder";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _privilege_id;
		private SystemOperation _operation_id;
		private SystemResources _resources_id;
		private string _privilegecnname;
		private string _privilegeenname;
		private string _defaultvalue;
		private string _description;
		private int _privilegeorder;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemPrivilegeBase()
		{
			_privilege_id = 0; 
			_operation_id =  null; 
			_resources_id =  null; 
			_privilegecnname = String.Empty; 
			_privilegeenname = String.Empty; 
			_defaultvalue = String.Empty; 
			_description = String.Empty; 
			_privilegeorder = 0; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int PrivilegeID
		{
			get { return _privilege_id; }
			set { _isChanged |= (_privilege_id != value); _privilege_id = value; }
		}
		/// <summary>
		/// 对应操作ID
		/// </summary>		
		public virtual SystemOperation OperationID
		{
			get { return _operation_id; }
			set { _isChanged |= (_operation_id != value); _operation_id = value; }
		}
		/// <summary>
		/// 对应资源ID
		/// </summary>		
		public virtual SystemResources ResourcesID
		{
			get { return _resources_id; }
			set { _isChanged |= (_resources_id != value); _resources_id = value; }
		}
		/// <summary>
		/// 权限中文名
		/// </summary>		
		public virtual string PrivilegeCnName
		{
			get { return _privilegecnname; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for PrivilegeCnName", value, value.ToString());
				
				_isChanged |= (_privilegecnname != value); _privilegecnname = value;
			}
		}
		/// <summary>
		/// 权限英文名
		/// </summary>		
		public virtual string PrivilegeEnName
		{
			get { return _privilegeenname; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for PrivilegeEnName", value, value.ToString());
				
				_isChanged |= (_privilegeenname != value); _privilegeenname = value;
			}
		}
		/// <summary>
		/// 权限默认值
		/// </summary>		
		public virtual string DefaultValue
		{
			get { return _defaultvalue; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for DefaultValue", value, value.ToString());
				
				_isChanged |= (_defaultvalue != value); _defaultvalue = value;
			}
		}
		/// <summary>
		/// 权限描述
		/// </summary>		
		public virtual string Description
		{
			get { return _description; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
				
				_isChanged |= (_description != value); _description = value;
			}
		}
		/// <summary>
		/// 权限次序
		/// </summary>		
		public virtual int PrivilegeOrder
		{
			get { return _privilegeorder; }
			set { _isChanged |= (_privilegeorder != value); _privilegeorder = value; }
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
			SystemPrivilegeBase castObj = (SystemPrivilegeBase)obj; 
			return ( castObj != null ) &&
				( this._privilege_id == castObj.PrivilegeID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _privilege_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemPrivilegeBase obj )
		{
			obj.OperationID = this._operation_id;
			obj.ResourcesID = this._resources_id;
			obj.PrivilegeCnName = this._privilegecnname;
			obj.PrivilegeEnName = this._privilegeenname;
			obj.DefaultValue = this._defaultvalue;
			obj.Description = this._description;
			obj.PrivilegeOrder = this._privilegeorder;
		}
        #endregion
	}
}
