// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	System Permission
	/// </summary>
	[DataContract]
	public partial class SystemPrivilegeEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemPrivilegeEntity";
		public static readonly string PROPERTY_NAME_PRIVILEGEID = "PrivilegeID";
		public static readonly string PROPERTY_NAME_OPERATIONID = "OperationID";
		public static readonly string PROPERTY_NAME_RESOURCESID = "ResourcesID";
		public static readonly string PROPERTY_NAME_PRIVILEGECNNAME = "PrivilegeCnName";
		public static readonly string PROPERTY_NAME_PRIVILEGEENNAME = "PrivilegeEnName";
		public static readonly string PROPERTY_NAME_DEFAULTVALUE = "DefaultValue";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_PRIVILEGEORDER = "PrivilegeOrder";
		public static readonly string PROPERTY_NAME_PRIVILEGETYPE = "PrivilegeType";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _privilegeID;
		private SystemOperationEntity _operationID;
		private SystemResourcesEntity _resourcesID;
		private string _privilegeCnName;
		private string _privilegeEnName;
		private string _defaultValue;
		private string _description;
		private int _privilegeOrder;
		private string _privilegeType;
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
		public SystemPrivilegeEntity()
		{
			_privilegeID = 0;
			_operationID = null;
			_resourcesID = null;
			_privilegeCnName = String.Empty;
			_privilegeEnName = String.Empty;
			_defaultValue = null;
			_description = null;
			_privilegeOrder = 0;
			_privilegeType = null;
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
		public SystemPrivilegeEntity( int privilegeID, SystemOperationEntity operationID, SystemResourcesEntity resourcesID, string privilegeCnName, string privilegeEnName, string defaultValue, string description, int privilegeOrder, string privilegeType, int? createBy, DateTime? createAt, int? lastModifyBy, DateTime? lastModifyAt, string lastModifyComment)
		{
			_privilegeID = privilegeID;
			_operationID = operationID;
			_resourcesID = resourcesID;
			_privilegeCnName = privilegeCnName;
			_privilegeEnName = privilegeEnName;
			_defaultValue = defaultValue;
			_description = description;
			_privilegeOrder = privilegeOrder;
			_privilegeType = privilegeType;
			_createBy = createBy;
			_createAt = createAt;
			_lastModifyBy = lastModifyBy;
			_lastModifyAt = lastModifyAt;
			_lastModifyComment = lastModifyComment;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// Primary Key
		/// </summary>
		[DataMember]
		public virtual int PrivilegeID
		{
			get { return _privilegeID; }

			set	
			{
				_isChanged |= (_privilegeID != value); _privilegeID = value;
			}
		}

		/// <summary>
		/// Operation ID
		/// </summary>
		[DataMember]
		public virtual SystemOperationEntity OperationID
		{
			get { return _operationID; }

			set	
			{
				_isChanged |= (_operationID != value); _operationID = value;
			}
		}

		/// <summary>
		/// Resources ID
		/// </summary>
		[DataMember]
		public virtual SystemResourcesEntity ResourcesID
		{
			get { return _resourcesID; }

			set	
			{
				_isChanged |= (_resourcesID != value); _resourcesID = value;
			}
		}

		/// <summary>
		/// Permission Name
		/// </summary>
		[DataMember]
		public virtual string PrivilegeCnName
		{
			get { return _privilegeCnName; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for PrivilegeCnName", value, value.ToString());
				_isChanged |= (_privilegeCnName != value); _privilegeCnName = value;
			}
		}

		/// <summary>
		/// Permission Code
		/// </summary>
		[DataMember]
		public virtual string PrivilegeEnName
		{
			get { return _privilegeEnName; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for PrivilegeEnName", value, value.ToString());
				_isChanged |= (_privilegeEnName != value); _privilegeEnName = value;
			}
		}

		/// <summary>
		/// Default Value
		/// </summary>
		[DataMember]
		public virtual string DefaultValue
		{
			get { return _defaultValue; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for DefaultValue", value, value.ToString());
				_isChanged |= (_defaultValue != value); _defaultValue = value;
			}
		}

		/// <summary>
		/// Permission Description
		/// </summary>
		[DataMember]
		public virtual string Description
		{
			get { return _description; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
				_isChanged |= (_description != value); _description = value;
			}
		}

		/// <summary>
		/// Permission Order
		/// </summary>
		[DataMember]
		public virtual int PrivilegeOrder
		{
			get { return _privilegeOrder; }

			set	
			{
				_isChanged |= (_privilegeOrder != value); _privilegeOrder = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string PrivilegeType
		{
			get { return _privilegeType; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for PrivilegeType", value, value.ToString());
				_isChanged |= (_privilegeType != value); _privilegeType = value;
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
			
			SystemPrivilegeEntity castObj = (SystemPrivilegeEntity)obj;
			
			return ( castObj != null ) && ( this._privilegeID == castObj.PrivilegeID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _privilegeID.GetHashCode();

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
