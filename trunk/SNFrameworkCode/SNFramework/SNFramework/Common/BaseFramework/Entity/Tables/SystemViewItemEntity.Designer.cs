// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	??????
	/// </summary>
	[DataContract]
	public partial class SystemViewItemEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemViewItemEntity";
		public static readonly string PROPERTY_NAME_SYSTEMVIEWITEMID = "SystemViewItemID";
		public static readonly string PROPERTY_NAME_SYSTEMVIEWITEMNAMEEN = "SystemViewItemNameEn";
		public static readonly string PROPERTY_NAME_SYSTEMVIEWITEMNAMECN = "SystemViewItemNameCn";
		public static readonly string PROPERTY_NAME_SYSTEMVIEWITEMDESCRIPTION = "SystemViewItemDescription";
		public static readonly string PROPERTY_NAME_SYSTEMVIEWITEMDISPLAYFORMAT = "SystemViewItemDisplayFormat";
		public static readonly string PROPERTY_NAME_SYSTEMVIEWID = "SystemViewID";
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
		
		private int _systemViewItemID;
		private string _systemViewItemNameEn;
		private string _systemViewItemNameCn;
		private string _systemViewItemDescription;
		private string _systemViewItemDisplayFormat;
		private SystemViewEntity _systemViewID;
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
		public SystemViewItemEntity()
		{
			_systemViewItemID = 0;
			_systemViewItemNameEn = null;
			_systemViewItemNameCn = null;
			_systemViewItemDescription = null;
			_systemViewItemDisplayFormat = null;
			_systemViewID = null;
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
		public SystemViewItemEntity( int systemViewItemID, string systemViewItemNameEn, string systemViewItemNameCn, string systemViewItemDescription, string systemViewItemDisplayFormat, SystemViewEntity systemViewID, int? orderIndex, int? createBy, DateTime? createAt, int? lastModifyBy, DateTime? lastModifyAt, string lastModifyComment)
		{
			_systemViewItemID = systemViewItemID;
			_systemViewItemNameEn = systemViewItemNameEn;
			_systemViewItemNameCn = systemViewItemNameCn;
			_systemViewItemDescription = systemViewItemDescription;
			_systemViewItemDisplayFormat = systemViewItemDisplayFormat;
			_systemViewID = systemViewID;
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
		public virtual int SystemViewItemID
		{
			get { return _systemViewItemID; }

			set	
			{
				_isChanged |= (_systemViewItemID != value); _systemViewItemID = value;
			}
		}

		/// <summary>
		/// ?????
		/// </summary>
		[DataMember]
		public virtual string SystemViewItemNameEn
		{
			get { return _systemViewItemNameEn; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for SystemViewItemNameEn", value, value.ToString());
				_isChanged |= (_systemViewItemNameEn != value); _systemViewItemNameEn = value;
			}
		}

		/// <summary>
		/// ?????
		/// </summary>
		[DataMember]
		public virtual string SystemViewItemNameCn
		{
			get { return _systemViewItemNameCn; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for SystemViewItemNameCn", value, value.ToString());
				_isChanged |= (_systemViewItemNameCn != value); _systemViewItemNameCn = value;
			}
		}

		/// <summary>
		/// ????
		/// </summary>
		[DataMember]
		public virtual string SystemViewItemDescription
		{
			get { return _systemViewItemDescription; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for SystemViewItemDescription", value, value.ToString());
				_isChanged |= (_systemViewItemDescription != value); _systemViewItemDescription = value;
			}
		}

		/// <summary>
		/// ??????
		/// </summary>
		[DataMember]
		public virtual string SystemViewItemDisplayFormat
		{
			get { return _systemViewItemDisplayFormat; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for SystemViewItemDisplayFormat", value, value.ToString());
				_isChanged |= (_systemViewItemDisplayFormat != value); _systemViewItemDisplayFormat = value;
			}
		}

		/// <summary>
		/// ????ID
		/// </summary>
		[DataMember]
		public virtual SystemViewEntity SystemViewID
		{
			get { return _systemViewID; }

			set	
			{
				_isChanged |= (_systemViewID != value); _systemViewID = value;
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
			
			SystemViewItemEntity castObj = (SystemViewItemEntity)obj;
			
			return ( castObj != null ) && ( this._systemViewItemID == castObj.SystemViewItemID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _systemViewItemID.GetHashCode();

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
