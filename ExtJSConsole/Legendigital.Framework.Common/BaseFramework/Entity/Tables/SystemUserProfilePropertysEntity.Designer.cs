// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	
	/// </summary>
	[DataContract]
	public partial class SystemUserProfilePropertysEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemUserProfilePropertysEntity";
		public static readonly string PROPERTY_NAME_PROPERTYID = "PropertyID";
		public static readonly string PROPERTY_NAME_PROPERTYNAME = "PropertyName";
		public static readonly string PROPERTY_NAME_PROPERTYDATATYPE = "PropertyDataType";
		public static readonly string PROPERTY_NAME_PROPERTYDESCRIPTION = "PropertyDescription";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _propertyID;
		private string _propertyName;
		private string _propertyDataType;
		private string _propertyDescription;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemUserProfilePropertysEntity()
		{
			_propertyID = 0;
			_propertyName = String.Empty;
			_propertyDataType = null;
			_propertyDescription = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemUserProfilePropertysEntity( int propertyID, string propertyName, string propertyDataType, string propertyDescription)
		{
			_propertyID = propertyID;
			_propertyName = propertyName;
			_propertyDataType = propertyDataType;
			_propertyDescription = propertyDescription;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int PropertyID
		{
			get { return _propertyID; }

			set	
			{
				_isChanged |= (_propertyID != value); _propertyID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string PropertyName
		{
			get { return _propertyName; }

			set	
			{

				if( value != null && value.Length > 2000)
					throw new ArgumentOutOfRangeException("Invalid value for PropertyName", value, value.ToString());
				_isChanged |= (_propertyName != value); _propertyName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string PropertyDataType
		{
			get { return _propertyDataType; }

			set	
			{

				if( value != null && value.Length > 800)
					throw new ArgumentOutOfRangeException("Invalid value for PropertyDataType", value, value.ToString());
				_isChanged |= (_propertyDataType != value); _propertyDataType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string PropertyDescription
		{
			get { return _propertyDescription; }

			set	
			{

				if( value != null && value.Length > 8000)
					throw new ArgumentOutOfRangeException("Invalid value for PropertyDescription", value, value.ToString());
				_isChanged |= (_propertyDescription != value); _propertyDescription = value;
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
			
			SystemUserProfilePropertysEntity castObj = (SystemUserProfilePropertysEntity)obj;
			
			return ( castObj != null ) && ( this._propertyID == castObj.PropertyID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _propertyID.GetHashCode();

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
