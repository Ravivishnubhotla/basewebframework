// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	????
	/// </summary>
	[DataContract]
	public partial class SystemResourcesEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemResourcesEntity";
		public static readonly string PROPERTY_NAME_RESOURCESID = "ResourcesID";
		public static readonly string PROPERTY_NAME_RESOURCESNAMECN = "ResourcesNameCn";
		public static readonly string PROPERTY_NAME_RESOURCESNAMEEN = "ResourcesNameEn";
		public static readonly string PROPERTY_NAME_RESOURCESDESCRIPTION = "ResourcesDescription";
		public static readonly string PROPERTY_NAME_RESOURCESTYPE = "ResourcesType";
		public static readonly string PROPERTY_NAME_RESOURCESLIMITEXPRESSION = "ResourcesLimitExpression";
		public static readonly string PROPERTY_NAME_RESOURCESISRELATEUSER = "ResourcesIsRelateUser";
		public static readonly string PROPERTY_NAME_MOUDLEID = "MoudleID";
		public static readonly string PROPERTY_NAME_PARENTRESOURCESID = "ParentResourcesID";
		public static readonly string PROPERTY_NAME_ORDERINDEX = "OrderIndex";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _resourcesID;
		private string _resourcesNameCn;
		private string _resourcesNameEn;
		private string _resourcesDescription;
		private string _resourcesType;
		private string _resourcesLimitExpression;
		private bool _resourcesIsRelateUser;
		private SystemMoudleEntity _moudleID;
		private SystemResourcesEntity _parentResourcesID;
		private int? _orderIndex;
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
		public SystemResourcesEntity()
		{
			_resourcesID = 0;
			_resourcesNameCn = String.Empty;
			_resourcesNameEn = String.Empty;
			_resourcesDescription = null;
			_resourcesType = null;
			_resourcesLimitExpression = null;
			_resourcesIsRelateUser = false;
			_moudleID = null;
			_parentResourcesID = null;
			_orderIndex = null;
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
		public SystemResourcesEntity( int resourcesID, string resourcesNameCn, string resourcesNameEn, string resourcesDescription, string resourcesType, string resourcesLimitExpression, bool resourcesIsRelateUser, SystemMoudleEntity moudleID, SystemResourcesEntity parentResourcesID, int? orderIndex, int? createBy, DateTime? createAt, int? lastModifyBy, DateTime? lastModifyAt, string lastModifyComment)
		{
			_resourcesID = resourcesID;
			_resourcesNameCn = resourcesNameCn;
			_resourcesNameEn = resourcesNameEn;
			_resourcesDescription = resourcesDescription;
			_resourcesType = resourcesType;
			_resourcesLimitExpression = resourcesLimitExpression;
			_resourcesIsRelateUser = resourcesIsRelateUser;
			_moudleID = moudleID;
			_parentResourcesID = parentResourcesID;
			_orderIndex = orderIndex;
			_createBy = createBy;
			_createAt = createAt;
			_lastModifyBy = lastModifyBy;
			_lastModifyAt = lastModifyAt;
			_lastModifyComment = lastModifyComment;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// ??
		/// </summary>
		[DataMember]
		public virtual int ResourcesID
		{
			get { return _resourcesID; }

			set	
			{
				_isChanged |= (_resourcesID != value); _resourcesID = value;
			}
		}

		/// <summary>
		/// ?????
		/// </summary>
		[DataMember]
		public virtual string ResourcesNameCn
		{
			get { return _resourcesNameCn; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ResourcesNameCn", value, value.ToString());
				_isChanged |= (_resourcesNameCn != value); _resourcesNameCn = value;
			}
		}

		/// <summary>
		/// ?????
		/// </summary>
		[DataMember]
		public virtual string ResourcesNameEn
		{
			get { return _resourcesNameEn; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ResourcesNameEn", value, value.ToString());
				_isChanged |= (_resourcesNameEn != value); _resourcesNameEn = value;
			}
		}

		/// <summary>
		/// ????
		/// </summary>
		[DataMember]
		public virtual string ResourcesDescription
		{
			get { return _resourcesDescription; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for ResourcesDescription", value, value.ToString());
				_isChanged |= (_resourcesDescription != value); _resourcesDescription = value;
			}
		}

		/// <summary>
		/// ????
		/// </summary>
		[DataMember]
		public virtual string ResourcesType
		{
			get { return _resourcesType; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ResourcesType", value, value.ToString());
				_isChanged |= (_resourcesType != value); _resourcesType = value;
			}
		}

		/// <summary>
		/// ??????
		/// </summary>
		[DataMember]
		public virtual string ResourcesLimitExpression
		{
			get { return _resourcesLimitExpression; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for ResourcesLimitExpression", value, value.ToString());
				_isChanged |= (_resourcesLimitExpression != value); _resourcesLimitExpression = value;
			}
		}

		/// <summary>
		/// ?????????
		/// </summary>
		[DataMember]
		public virtual bool ResourcesIsRelateUser
		{
			get { return _resourcesIsRelateUser; }

			set	
			{
				_isChanged |= (_resourcesIsRelateUser != value); _resourcesIsRelateUser = value;
			}
		}

		/// <summary>
		/// ????
		/// </summary>
		[DataMember]
		public virtual SystemMoudleEntity MoudleID
		{
			get { return _moudleID; }

			set	
			{
				_isChanged |= (_moudleID != value); _moudleID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual SystemResourcesEntity ParentResourcesID
		{
			get { return _parentResourcesID; }

			set	
			{
				_isChanged |= (_parentResourcesID != value); _parentResourcesID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? OrderIndex
		{
			get { return _orderIndex; }

			set	
			{
				_isChanged |= (_orderIndex != value); _orderIndex = value;
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
			
			SystemResourcesEntity castObj = (SystemResourcesEntity)obj;
			
			return ( castObj != null ) && ( this._resourcesID == castObj.ResourcesID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _resourcesID.GetHashCode();

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
