// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	系统资源
	/// </summary>
	public partial class SystemResourcesEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemResourcesEntity";
		public static readonly string PROPERTY_NAME_RESOURCESID = "ResourcesID";
		public static readonly string PROPERTY_NAME_RESOURCESNAMECN = "ResourcesNameCn";
		public static readonly string PROPERTY_NAME_RESOURCESNAMEEN = "ResourcesNameEn";
		public static readonly string PROPERTY_NAME_RESOURCESDESCRIPTION = "ResourcesDescription";
		public static readonly string PROPERTY_NAME_RESOURCESTYPE = "ResourcesType";
		public static readonly string PROPERTY_NAME_RESOURCESCATEGORY = "ResourcesCategory";
		public static readonly string PROPERTY_NAME_RESOURCESLIMITEXPRESSION = "ResourcesLimitExpression";
		public static readonly string PROPERTY_NAME_RESOURCESISRELATEUSER = "ResourcesIsRelateUser";
		public static readonly string PROPERTY_NAME_MOUDLEID = "MoudleID";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _resourcesID;
		private string _resourcesNameCn;
		private string _resourcesNameEn;
		private string _resourcesDescription;
		private string _resourcesType;
		private string _resourcesCategory;
		private string _resourcesLimitExpression;
		private bool _resourcesIsRelateUser;
		private SystemMoudleEntity _moudleID;
		
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
			_resourcesCategory = null;
			_resourcesLimitExpression = null;
			_resourcesIsRelateUser = false;
			_moudleID = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemResourcesEntity( int resourcesID, string resourcesNameCn, string resourcesNameEn, string resourcesDescription, string resourcesType, string resourcesCategory, string resourcesLimitExpression, bool resourcesIsRelateUser, SystemMoudleEntity moudleID)
		{
			_resourcesID = resourcesID;
			_resourcesNameCn = resourcesNameCn;
			_resourcesNameEn = resourcesNameEn;
			_resourcesDescription = resourcesDescription;
			_resourcesType = resourcesType;
			_resourcesCategory = resourcesCategory;
			_resourcesLimitExpression = resourcesLimitExpression;
			_resourcesIsRelateUser = resourcesIsRelateUser;
			_moudleID = moudleID;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// 主键
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
		/// 资源中文名
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
		/// 资源英文名
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
		/// 资源描述
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
		/// 资源类型
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
		/// 
		/// </summary>
		[DataMember]
		public virtual string ResourcesCategory
		{
			get { return _resourcesCategory; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ResourcesCategory", value, value.ToString());
				_isChanged |= (_resourcesCategory != value); _resourcesCategory = value;
			}
		}

		/// <summary>
		/// 资源限制条件
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
		/// 资源是否于用户相关
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
		/// 所属模块
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
