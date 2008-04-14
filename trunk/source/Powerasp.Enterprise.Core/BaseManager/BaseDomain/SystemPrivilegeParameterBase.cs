/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	权限参数
	/// </summary>
	[Serializable]
	public abstract class SystemPrivilegeParameterBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemPrivilegeParameter";
		public static readonly string PROPERTY_NAME_PRIVILEGEPARAMETERID = "PrivilegeParameterID";
		public static readonly string PROPERTY_NAME_ROLEID = "RoleID";
		public static readonly string PROPERTY_NAME_PRIVILEGEID = "PrivilegeID";
		public static readonly string PROPERTY_NAME_BIZPARAMETER = "BizParameter";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _privilegeparameterid;
		private SystemRole _roleid;
		private SystemPrivilege _privilegeid;
		private string _bizparameter;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemPrivilegeParameterBase()
		{
			_privilegeparameterid = 0; 
			_roleid =  null; 
			_privilegeid =  null; 
			_bizparameter = String.Empty; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int PrivilegeParameterID
		{
			get { return _privilegeparameterid; }
			set { _isChanged |= (_privilegeparameterid != value); _privilegeparameterid = value; }
		}
		/// <summary>
		/// 角色ID
		/// </summary>		
		public virtual SystemRole RoleID
		{
			get { return _roleid; }
			set { _isChanged |= (_roleid != value); _roleid = value; }
		}
		/// <summary>
		/// 权限ID
		/// </summary>		
		public virtual SystemPrivilege PrivilegeID
		{
			get { return _privilegeid; }
			set { _isChanged |= (_privilegeid != value); _privilegeid = value; }
		}
		/// <summary>
		/// 参数
		/// </summary>		
		public virtual string BizParameter
		{
			get { return _bizparameter; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for BizParameter", value, value.ToString());
				
				_isChanged |= (_bizparameter != value); _bizparameter = value;
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
			SystemPrivilegeParameterBase castObj = (SystemPrivilegeParameterBase)obj; 
			return ( castObj != null ) &&
				( this._privilegeparameterid == castObj.PrivilegeParameterID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _privilegeparameterid.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemPrivilegeParameterBase obj )
		{
			obj.RoleID = this._roleid;
			obj.PrivilegeID = this._privilegeid;
			obj.BizParameter = this._bizparameter;
		}
        #endregion
	}
}
