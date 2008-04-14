/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	系统数据模块字段
	/// </summary>
	[Serializable]
	public abstract class SystemMoudleFieldBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemMoudleField";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEFIELDID = "SystemMoudleFieldID";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEFIELDNAMEEN = "SystemMoudleFieldNameEn";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEFIELDNAMECN = "SystemMoudleFieldNameCn";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEFIELDNAMEDB = "SystemMoudleFieldNameDb";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEFIELDTYPE = "SystemMoudleFieldType";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEFIELDISREQUIRED = "SystemMoudleFieldIsRequired";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEFIELDDEFAULTVALUE = "SystemMoudleFieldDefaultValue";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEFIELDISKEYFIELD = "SystemMoudleFieldIsKeyField";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEFIELDSIZE = "SystemMoudleFieldSize";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEFIELDDESCRIPTION = "SystemMoudleFieldDescription";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEID = "SystemMoudleID";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _systemmoudlefield_id;
		private string _systemmoudlefield_nameen;
		private string _systemmoudlefield_namecn;
		private string _systemmoudlefield_namedb;
		private string _systemmoudlefield_type;
		private bool _systemmoudlefield_isrequired;
		private string _systemmoudlefield_defaultvalue;
		private bool _systemmoudlefield_iskeyfield;
		private int _systemmoudlefield_size;
		private string _systemmoudlefield_description;
		private SystemMoudle _systemmoudle_id;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemMoudleFieldBase()
		{
			_systemmoudlefield_id = 0; 
			_systemmoudlefield_nameen = String.Empty; 
			_systemmoudlefield_namecn = String.Empty; 
			_systemmoudlefield_namedb = String.Empty; 
			_systemmoudlefield_type = String.Empty; 
			_systemmoudlefield_isrequired = false; 
			_systemmoudlefield_defaultvalue = String.Empty; 
			_systemmoudlefield_iskeyfield = false; 
			_systemmoudlefield_size = 0; 
			_systemmoudlefield_description = String.Empty; 
			_systemmoudle_id =  null; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 字段ID
		/// </summary>		
		public virtual int SystemMoudleFieldID
		{
			get { return _systemmoudlefield_id; }
			set { _isChanged |= (_systemmoudlefield_id != value); _systemmoudlefield_id = value; }
		}
		/// <summary>
		/// 字段英文名
		/// </summary>		
		public virtual string SystemMoudleFieldNameEn
		{
			get { return _systemmoudlefield_nameen; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for SystemMoudleFieldNameEn", value, value.ToString());
				
				_isChanged |= (_systemmoudlefield_nameen != value); _systemmoudlefield_nameen = value;
			}
		}
		/// <summary>
		/// 字段中文名
		/// </summary>		
		public virtual string SystemMoudleFieldNameCn
		{
			get { return _systemmoudlefield_namecn; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for SystemMoudleFieldNameCn", value, value.ToString());
				
				_isChanged |= (_systemmoudlefield_namecn != value); _systemmoudlefield_namecn = value;
			}
		}
		/// <summary>
		/// 字段数据表名
		/// </summary>		
		public virtual string SystemMoudleFieldNameDb
		{
			get { return _systemmoudlefield_namedb; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for SystemMoudleFieldNameDb", value, value.ToString());
				
				_isChanged |= (_systemmoudlefield_namedb != value); _systemmoudlefield_namedb = value;
			}
		}
		/// <summary>
		/// 字段类型
		/// </summary>		
		public virtual string SystemMoudleFieldType
		{
			get { return _systemmoudlefield_type; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for SystemMoudleFieldType", value, value.ToString());
				
				_isChanged |= (_systemmoudlefield_type != value); _systemmoudlefield_type = value;
			}
		}
		/// <summary>
		/// 字段是否必填
		/// </summary>		
		public virtual bool SystemMoudleFieldIsRequired
		{
			get { return _systemmoudlefield_isrequired; }
			set { _isChanged |= (_systemmoudlefield_isrequired != value); _systemmoudlefield_isrequired = value; }
		}
		/// <summary>
		/// 字段默认值
		/// </summary>		
		public virtual string SystemMoudleFieldDefaultValue
		{
			get { return _systemmoudlefield_defaultvalue; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for SystemMoudleFieldDefaultValue", value, value.ToString());
				
				_isChanged |= (_systemmoudlefield_defaultvalue != value); _systemmoudlefield_defaultvalue = value;
			}
		}
		/// <summary>
		/// 字段是否为主键
		/// </summary>		
		public virtual bool SystemMoudleFieldIsKeyField
		{
			get { return _systemmoudlefield_iskeyfield; }
			set { _isChanged |= (_systemmoudlefield_iskeyfield != value); _systemmoudlefield_iskeyfield = value; }
		}
		/// <summary>
		/// 字段大小
		/// </summary>		
		public virtual int SystemMoudleFieldSize
		{
			get { return _systemmoudlefield_size; }
			set { _isChanged |= (_systemmoudlefield_size != value); _systemmoudlefield_size = value; }
		}
		/// <summary>
		/// 字段描述
		/// </summary>		
		public virtual string SystemMoudleFieldDescription
		{
			get { return _systemmoudlefield_description; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for SystemMoudleFieldDescription", value, value.ToString());
				
				_isChanged |= (_systemmoudlefield_description != value); _systemmoudlefield_description = value;
			}
		}
		/// <summary>
		/// 字段对应模块ID
		/// </summary>		
		public virtual SystemMoudle SystemMoudleID
		{
			get { return _systemmoudle_id; }
			set { _isChanged |= (_systemmoudle_id != value); _systemmoudle_id = value; }
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
			SystemMoudleFieldBase castObj = (SystemMoudleFieldBase)obj; 
			return ( castObj != null ) &&
				( this._systemmoudlefield_id == castObj.SystemMoudleFieldID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _systemmoudlefield_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemMoudleFieldBase obj )
		{
			obj.SystemMoudleFieldNameEn = this._systemmoudlefield_nameen;
			obj.SystemMoudleFieldNameCn = this._systemmoudlefield_namecn;
			obj.SystemMoudleFieldNameDb = this._systemmoudlefield_namedb;
			obj.SystemMoudleFieldType = this._systemmoudlefield_type;
			obj.SystemMoudleFieldIsRequired = this._systemmoudlefield_isrequired;
			obj.SystemMoudleFieldDefaultValue = this._systemmoudlefield_defaultvalue;
			obj.SystemMoudleFieldIsKeyField = this._systemmoudlefield_iskeyfield;
			obj.SystemMoudleFieldSize = this._systemmoudlefield_size;
			obj.SystemMoudleFieldDescription = this._systemmoudlefield_description;
			obj.SystemMoudleID = this._systemmoudle_id;
		}
        #endregion
	}
}
