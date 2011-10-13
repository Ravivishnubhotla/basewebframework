// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Legendigital.Framework.Common.Entity;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	SystemConfig
	/// </summary>
	[DataContract]
	public partial class SystemConfigEntity  : BaseTableEntity,ICloneable
	{
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemConfigEntity";
		public static readonly string PROPERTY_NAME_SYSTEMCONFIGID = "SystemConfigID";
		public static readonly string PROPERTY_NAME_CONFIGKEY = "ConfigKey";
		public static readonly string PROPERTY_NAME_CONFIGVALUE = "ConfigValue";
		public static readonly string PROPERTY_NAME_CONFIGDATATYPE = "ConfigDataType";
		public static readonly string PROPERTY_NAME_CONFIGDESCRIPTION = "ConfigDescription";
		public static readonly string PROPERTY_NAME_SORTINDEX = "SortIndex";
		public static readonly string PROPERTY_NAME_CONFIGGROUPID = "ConfigGroupID";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region configGroupID字段外键查询字段
        public const string PROPERTY_CONFIGGROUPID_ALIAS_NAME = "ConfigGroupID_SystemConfigEntity_Alias";
		public const string PROPERTY_CONFIGGROUPID_ID = "ConfigGroupID_SystemConfigEntity_Alias.Id";
		public const string PROPERTY_CONFIGGROUPID_NAME = "ConfigGroupID_SystemConfigEntity_Alias.Name";
		public const string PROPERTY_CONFIGGROUPID_CODE = "ConfigGroupID_SystemConfigEntity_Alias.Code";
		public const string PROPERTY_CONFIGGROUPID_DESCRIPTION = "ConfigGroupID_SystemConfigEntity_Alias.Description";
		public const string PROPERTY_CONFIGGROUPID_ISENABLE = "ConfigGroupID_SystemConfigEntity_Alias.IsEnable";
		public const string PROPERTY_CONFIGGROUPID_ISSYSTEM = "ConfigGroupID_SystemConfigEntity_Alias.IsSystem";
		public const string PROPERTY_CONFIGGROUPID_CREATEBY = "ConfigGroupID_SystemConfigEntity_Alias.CreateBy";
		public const string PROPERTY_CONFIGGROUPID_CREATEAT = "ConfigGroupID_SystemConfigEntity_Alias.CreateAt";
		public const string PROPERTY_CONFIGGROUPID_LASTMODIFYBY = "ConfigGroupID_SystemConfigEntity_Alias.LastModifyBy";
		public const string PROPERTY_CONFIGGROUPID_LASTMODIFYAT = "ConfigGroupID_SystemConfigEntity_Alias.LastModifyAt";
		public const string PROPERTY_CONFIGGROUPID_LASTMODIFYCOMMENT = "ConfigGroupID_SystemConfigEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _systemConfigID;
		private string _configKey;
		private string _configValue;
		private string _configDataType;
		private string _configDescription;
		private int? _sortIndex;
		private SystemConfigGroupEntity _configGroupID;
		private int? _createBy;
		private DateTime? _createAt;
		private int? _lastModifyBy;
		private DateTime? _lastModifyAt;
		private string _lastModifyComment;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemConfigEntity()
		{
			_systemConfigID = 0;
			_configKey = null;
			_configValue = null;
			_configDataType = null;
			_configDescription = null;
			_sortIndex = null;
			_configGroupID = null;
			_createBy = null;
			_createAt = null;
			_lastModifyBy = null;
			_lastModifyAt = null;
			_lastModifyComment = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemConfigEntity( int systemConfigID, string configKey, string configValue, string configDataType, string configDescription, int? sortIndex, SystemConfigGroupEntity configGroupID, int? createBy, DateTime? createAt, int? lastModifyBy, DateTime? lastModifyAt, string lastModifyComment)
		{
			_systemConfigID = systemConfigID;
			_configKey = configKey;
			_configValue = configValue;
			_configDataType = configDataType;
			_configDescription = configDescription;
			_sortIndex = sortIndex;
			_configGroupID = configGroupID;
			_createBy = createBy;
			_createAt = createAt;
			_lastModifyBy = lastModifyBy;
			_lastModifyAt = lastModifyAt;
			_lastModifyComment = lastModifyComment;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int SystemConfigID
		{
			get { return _systemConfigID; }

			set	
			{
				_isChanged |= (_systemConfigID != value); _systemConfigID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ConfigKey
		{
			get { return _configKey; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ConfigKey", value, value.ToString());
				_isChanged |= (_configKey != value); _configKey = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ConfigValue
		{
			get { return _configValue; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ConfigValue", value, value.ToString());
				_isChanged |= (_configValue != value); _configValue = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ConfigDataType
		{
			get { return _configDataType; }

			set	
			{

				if( value != null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for ConfigDataType", value, value.ToString());
				_isChanged |= (_configDataType != value); _configDataType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ConfigDescription
		{
			get { return _configDescription; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for ConfigDescription", value, value.ToString());
				_isChanged |= (_configDescription != value); _configDescription = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? SortIndex
		{
			get { return _sortIndex; }

			set	
			{
				_isChanged |= (_sortIndex != value); _sortIndex = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual SystemConfigGroupEntity ConfigGroupID
		{
			get { return _configGroupID; }

			set	
			{
				_isChanged |= (_configGroupID != value); _configGroupID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? CreateBy
		{
			get { return _createBy; }

			set	
			{
				_isChanged |= (_createBy != value); _createBy = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? CreateAt
		{
			get { return _createAt; }

			set	
			{
				_isChanged |= (_createAt != value); _createAt = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? LastModifyBy
		{
			get { return _lastModifyBy; }

			set	
			{
				_isChanged |= (_lastModifyBy != value); _lastModifyBy = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? LastModifyAt
		{
			get { return _lastModifyAt; }

			set	
			{
				_isChanged |= (_lastModifyAt != value); _lastModifyAt = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string LastModifyComment
		{
			get { return _lastModifyComment; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for LastModifyComment", value, value.ToString());
				_isChanged |= (_lastModifyComment != value); _lastModifyComment = value;
			}
		}
	

		#endregion 

        

		#region Equals 和 HashCode 方法覆盖
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			 return this.CheckEquals(obj as SystemConfigEntity);
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			return GetEntityHashCode();
		}
		#endregion
		
		public override object GetDataEntityKey()
	    {
	        return this._systemConfigID;
	    }
		
		
	
		#region ICloneable methods
		
		public virtual object Clone()
		{
			return this.MemberwiseClone();
		}
		
		#endregion
	
	}
}
