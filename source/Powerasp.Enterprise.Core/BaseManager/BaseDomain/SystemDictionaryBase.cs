/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	系统字典表
	/// </summary>
	[Serializable]
	public abstract class SystemDictionaryBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemDictionary";
		public static readonly string PROPERTY_NAME_SYSTEMDICTIONARYID = "SystemDictionaryID";
		public static readonly string PROPERTY_NAME_SYSTEMDICTIONARYCATEGORYID = "SystemDictionaryCategoryID";
		public static readonly string PROPERTY_NAME_SYSTEMDICTIONARYKEY = "SystemDictionaryKey";
		public static readonly string PROPERTY_NAME_SYSTEMDICTIONARYVALUE = "SystemDictionaryValue";
		public static readonly string PROPERTY_NAME_SYSTEMDICTIONARYDESCIPTION = "SystemDictionaryDesciption";
		public static readonly string PROPERTY_NAME_SYSTEMDICTIONARYORDER = "SystemDictionaryOrder";
		public static readonly string PROPERTY_NAME_SYSTEMDICTIONARYISENABLE = "SystemDictionaryIsEnable";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _systemdictionary_id;
		private string _systemdictionary_categoryid;
		private string _systemdictionary_key;
		private string _systemdictionary_value;
		private string _systemdictionary_desciption;
		private int _systemdictionary_order;
		private bool _systemdictionary_isenable;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemDictionaryBase()
		{
			_systemdictionary_id = 0; 
			_systemdictionary_categoryid = String.Empty; 
			_systemdictionary_key = String.Empty; 
			_systemdictionary_value = String.Empty; 
			_systemdictionary_desciption = String.Empty; 
			_systemdictionary_order = 0; 
			_systemdictionary_isenable = false; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int SystemDictionaryID
		{
			get { return _systemdictionary_id; }
			set { _isChanged |= (_systemdictionary_id != value); _systemdictionary_id = value; }
		}
		/// <summary>
		/// 字典类别
		/// </summary>		
		public virtual string SystemDictionaryCategoryID
		{
			get { return _systemdictionary_categoryid; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for SystemDictionaryCategoryID", value, value.ToString());
				
				_isChanged |= (_systemdictionary_categoryid != value); _systemdictionary_categoryid = value;
			}
		}
		/// <summary>
		/// 字典键
		/// </summary>		
		public virtual string SystemDictionaryKey
		{
			get { return _systemdictionary_key; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for SystemDictionaryKey", value, value.ToString());
				
				_isChanged |= (_systemdictionary_key != value); _systemdictionary_key = value;
			}
		}
		/// <summary>
		/// 字典值
		/// </summary>		
		public virtual string SystemDictionaryValue
		{
			get { return _systemdictionary_value; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for SystemDictionaryValue", value, value.ToString());
				
				_isChanged |= (_systemdictionary_value != value); _systemdictionary_value = value;
			}
		}
		/// <summary>
		/// 字典项描述
		/// </summary>		
		public virtual string SystemDictionaryDesciption
		{
			get { return _systemdictionary_desciption; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for SystemDictionaryDesciption", value, value.ToString());
				
				_isChanged |= (_systemdictionary_desciption != value); _systemdictionary_desciption = value;
			}
		}
		/// <summary>
		/// 字典项次序
		/// </summary>		
		public virtual int SystemDictionaryOrder
		{
			get { return _systemdictionary_order; }
			set { _isChanged |= (_systemdictionary_order != value); _systemdictionary_order = value; }
		}
		/// <summary>
		/// 字典项是否可用
		/// </summary>		
		public virtual bool SystemDictionaryIsEnable
		{
			get { return _systemdictionary_isenable; }
			set { _isChanged |= (_systemdictionary_isenable != value); _systemdictionary_isenable = value; }
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
			SystemDictionaryBase castObj = (SystemDictionaryBase)obj; 
			return ( castObj != null ) &&
				( this._systemdictionary_id == castObj.SystemDictionaryID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _systemdictionary_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemDictionaryBase obj )
		{
			obj.SystemDictionaryCategoryID = this._systemdictionary_categoryid;
			obj.SystemDictionaryKey = this._systemdictionary_key;
			obj.SystemDictionaryValue = this._systemdictionary_value;
			obj.SystemDictionaryDesciption = this._systemdictionary_desciption;
			obj.SystemDictionaryOrder = this._systemdictionary_order;
			obj.SystemDictionaryIsEnable = this._systemdictionary_isenable;
		}
        #endregion
	}
}
