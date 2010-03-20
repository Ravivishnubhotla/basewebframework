// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	系统数据模块字段
	/// </summary>
	public partial class SystemMoudleFieldEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemMoudleFieldEntity";
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
		
		private int _systemMoudleFieldID;
		private string _systemMoudleFieldNameEn;
		private string _systemMoudleFieldNameCn;
		private string _systemMoudleFieldNameDb;
		private string _systemMoudleFieldType;
		private bool? _systemMoudleFieldIsRequired;
		private string _systemMoudleFieldDefaultValue;
		private bool? _systemMoudleFieldIsKeyField;
		private int? _systemMoudleFieldSize;
		private string _systemMoudleFieldDescription;
		private SystemMoudleEntity _systemMoudleID;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemMoudleFieldEntity()
		{
			_systemMoudleFieldID = 0;
			_systemMoudleFieldNameEn = null;
			_systemMoudleFieldNameCn = null;
			_systemMoudleFieldNameDb = null;
			_systemMoudleFieldType = null;
			_systemMoudleFieldIsRequired = null;
			_systemMoudleFieldDefaultValue = null;
			_systemMoudleFieldIsKeyField = null;
			_systemMoudleFieldSize = null;
			_systemMoudleFieldDescription = null;
			_systemMoudleID = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemMoudleFieldEntity( int systemMoudleFieldID, string systemMoudleFieldNameEn, string systemMoudleFieldNameCn, string systemMoudleFieldNameDb, string systemMoudleFieldType, bool? systemMoudleFieldIsRequired, string systemMoudleFieldDefaultValue, bool? systemMoudleFieldIsKeyField, int? systemMoudleFieldSize, string systemMoudleFieldDescription, SystemMoudleEntity systemMoudleID)
		{
			_systemMoudleFieldID = systemMoudleFieldID;
			_systemMoudleFieldNameEn = systemMoudleFieldNameEn;
			_systemMoudleFieldNameCn = systemMoudleFieldNameCn;
			_systemMoudleFieldNameDb = systemMoudleFieldNameDb;
			_systemMoudleFieldType = systemMoudleFieldType;
			_systemMoudleFieldIsRequired = systemMoudleFieldIsRequired;
			_systemMoudleFieldDefaultValue = systemMoudleFieldDefaultValue;
			_systemMoudleFieldIsKeyField = systemMoudleFieldIsKeyField;
			_systemMoudleFieldSize = systemMoudleFieldSize;
			_systemMoudleFieldDescription = systemMoudleFieldDescription;
			_systemMoudleID = systemMoudleID;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// 字段ID
		/// </summary>		
		public virtual int SystemMoudleFieldID
		{
			get { return _systemMoudleFieldID; }

			set	
			{
				_isChanged |= (_systemMoudleFieldID != value); _systemMoudleFieldID = value;
			}
		}

		/// <summary>
		/// 字段英文名
		/// </summary>		
		public virtual string SystemMoudleFieldNameEn
		{
			get { return _systemMoudleFieldNameEn; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for SystemMoudleFieldNameEn", value, value.ToString());
				_isChanged |= (_systemMoudleFieldNameEn != value); _systemMoudleFieldNameEn = value;
			}
		}

		/// <summary>
		/// 字段中文名
		/// </summary>		
		public virtual string SystemMoudleFieldNameCn
		{
			get { return _systemMoudleFieldNameCn; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for SystemMoudleFieldNameCn", value, value.ToString());
				_isChanged |= (_systemMoudleFieldNameCn != value); _systemMoudleFieldNameCn = value;
			}
		}

		/// <summary>
		/// 字段数据表名
		/// </summary>		
		public virtual string SystemMoudleFieldNameDb
		{
			get { return _systemMoudleFieldNameDb; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for SystemMoudleFieldNameDb", value, value.ToString());
				_isChanged |= (_systemMoudleFieldNameDb != value); _systemMoudleFieldNameDb = value;
			}
		}

		/// <summary>
		/// 字段类型
		/// </summary>		
		public virtual string SystemMoudleFieldType
		{
			get { return _systemMoudleFieldType; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for SystemMoudleFieldType", value, value.ToString());
				_isChanged |= (_systemMoudleFieldType != value); _systemMoudleFieldType = value;
			}
		}

		/// <summary>
		/// 字段是否必填
		/// </summary>		
		public virtual bool? SystemMoudleFieldIsRequired
		{
			get { return _systemMoudleFieldIsRequired; }

			set	
			{
				_isChanged |= (_systemMoudleFieldIsRequired != value); _systemMoudleFieldIsRequired = value;
			}
		}

		/// <summary>
		/// 字段默认值
		/// </summary>		
		public virtual string SystemMoudleFieldDefaultValue
		{
			get { return _systemMoudleFieldDefaultValue; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for SystemMoudleFieldDefaultValue", value, value.ToString());
				_isChanged |= (_systemMoudleFieldDefaultValue != value); _systemMoudleFieldDefaultValue = value;
			}
		}

		/// <summary>
		/// 字段是否为主键
		/// </summary>		
		public virtual bool? SystemMoudleFieldIsKeyField
		{
			get { return _systemMoudleFieldIsKeyField; }

			set	
			{
				_isChanged |= (_systemMoudleFieldIsKeyField != value); _systemMoudleFieldIsKeyField = value;
			}
		}

		/// <summary>
		/// 字段大小
		/// </summary>		
		public virtual int? SystemMoudleFieldSize
		{
			get { return _systemMoudleFieldSize; }

			set	
			{
				_isChanged |= (_systemMoudleFieldSize != value); _systemMoudleFieldSize = value;
			}
		}

		/// <summary>
		/// 字段描述
		/// </summary>		
		public virtual string SystemMoudleFieldDescription
		{
			get { return _systemMoudleFieldDescription; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for SystemMoudleFieldDescription", value, value.ToString());
				_isChanged |= (_systemMoudleFieldDescription != value); _systemMoudleFieldDescription = value;
			}
		}

		/// <summary>
		/// 字段对应模块ID
		/// </summary>		
		public virtual SystemMoudleEntity SystemMoudleID
		{
			get { return _systemMoudleID; }

			set	
			{
				_isChanged |= (_systemMoudleID != value); _systemMoudleID = value;
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
			
			SystemMoudleFieldEntity castObj = (SystemMoudleFieldEntity)obj;
			
			return ( castObj != null ) && ( this._systemMoudleFieldID == castObj.SystemMoudleFieldID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _systemMoudleFieldID.GetHashCode();

			return hash; 
		}
		#endregion
	
		#region ICloneable methods
		
		public virtual object Clone()
		{
			return this.MemberwiseClone();
		}
		
		#endregion
	
	}
}
