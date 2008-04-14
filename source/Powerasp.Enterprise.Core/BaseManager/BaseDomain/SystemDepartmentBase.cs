/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	系统用户部门
	/// </summary>
	[Serializable]
	public abstract class SystemDepartmentBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemDepartment";
		public static readonly string PROPERTY_NAME_DEPARTMENTID = "DepartmentID";
		public static readonly string PROPERTY_NAME_PARENTDEPARTMENTID = "ParentDepartmentID";
		public static readonly string PROPERTY_NAME_DEPARTMENTNAMECN = "DepartmentNameCn";
		public static readonly string PROPERTY_NAME_DEPARTMENTNAMEEN = "DepartmentNameEn";
		public static readonly string PROPERTY_NAME_DEPARTMENTDECRIPTION = "DepartmentDecription";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _department_id;
		private SystemDepartment _parent_department_id;
		private string _department_namecn;
		private string _department_nameen;
		private string _department_decription;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemDepartmentBase()
		{
			_department_id = 0; 
			_parent_department_id =  null; 
			_department_namecn = String.Empty; 
			_department_nameen = String.Empty; 
			_department_decription = String.Empty; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int DepartmentID
		{
			get { return _department_id; }
			set { _isChanged |= (_department_id != value); _department_id = value; }
		}
		/// <summary>
		/// 父部门
		/// </summary>		
		public virtual SystemDepartment ParentDepartmentID
		{
			get { return _parent_department_id; }
			set { _isChanged |= (_parent_department_id != value); _parent_department_id = value; }
		}
		/// <summary>
		/// 部门中文名
		/// </summary>		
		public virtual string DepartmentNameCn
		{
			get { return _department_namecn; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for DepartmentNameCn", value, value.ToString());
				
				_isChanged |= (_department_namecn != value); _department_namecn = value;
			}
		}
		/// <summary>
		/// 部门英文名
		/// </summary>		
		public virtual string DepartmentNameEn
		{
			get { return _department_nameen; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for DepartmentNameEn", value, value.ToString());
				
				_isChanged |= (_department_nameen != value); _department_nameen = value;
			}
		}
		/// <summary>
		/// 部门描述
		/// </summary>		
		public virtual string DepartmentDecription
		{
			get { return _department_decription; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for DepartmentDecription", value, value.ToString());
				
				_isChanged |= (_department_decription != value); _department_decription = value;
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
			SystemDepartmentBase castObj = (SystemDepartmentBase)obj; 
			return ( castObj != null ) &&
				( this._department_id == castObj.DepartmentID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _department_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemDepartmentBase obj )
		{
			obj.ParentDepartmentID = this._parent_department_id;
			obj.DepartmentNameCn = this._department_namecn;
			obj.DepartmentNameEn = this._department_nameen;
			obj.DepartmentDecription = this._department_decription;
		}
        #endregion
	}
}
