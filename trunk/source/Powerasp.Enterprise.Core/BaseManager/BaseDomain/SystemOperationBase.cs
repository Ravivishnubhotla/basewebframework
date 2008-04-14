/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	系统操作
	/// </summary>
	[Serializable]
	public abstract class SystemOperationBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemOperation";
		public static readonly string PROPERTY_NAME_OPERATIONID = "OperationID";
		public static readonly string PROPERTY_NAME_OPERATIONNAMECN = "OperationNameCn";
		public static readonly string PROPERTY_NAME_OPERATIONNAMEEN = "OperationNameEn";
		public static readonly string PROPERTY_NAME_OPERATIONDESCRIPTION = "OperationDescription";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _operation_id;
		private string _operation_namecn;
		private string _operation_nameen;
		private string _operation_description;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemOperationBase()
		{
			_operation_id = 0; 
			_operation_namecn = String.Empty; 
			_operation_nameen = String.Empty; 
			_operation_description = String.Empty; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int OperationID
		{
			get { return _operation_id; }
			set { _isChanged |= (_operation_id != value); _operation_id = value; }
		}
		/// <summary>
		/// 操作中文名
		/// </summary>		
		public virtual string OperationNameCn
		{
			get { return _operation_namecn; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for OperationNameCn", value, value.ToString());
				
				_isChanged |= (_operation_namecn != value); _operation_namecn = value;
			}
		}
		/// <summary>
		/// 操作代号
		/// </summary>		
		public virtual string OperationNameEn
		{
			get { return _operation_nameen; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for OperationNameEn", value, value.ToString());
				
				_isChanged |= (_operation_nameen != value); _operation_nameen = value;
			}
		}
		/// <summary>
		/// 操作描述
		/// </summary>		
		public virtual string OperationDescription
		{
			get { return _operation_description; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for OperationDescription", value, value.ToString());
				
				_isChanged |= (_operation_description != value); _operation_description = value;
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
			SystemOperationBase castObj = (SystemOperationBase)obj; 
			return ( castObj != null ) &&
				( this._operation_id == castObj.OperationID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _operation_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemOperationBase obj )
		{
			obj.OperationNameCn = this._operation_namecn;
			obj.OperationNameEn = this._operation_nameen;
			obj.OperationDescription = this._operation_description;
		}
        #endregion
	}
}
