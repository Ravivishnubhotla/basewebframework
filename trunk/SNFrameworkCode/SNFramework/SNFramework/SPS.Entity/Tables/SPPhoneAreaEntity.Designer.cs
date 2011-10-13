// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Legendigital.Framework.Common.Entity;

namespace SPS.Entity.Tables
{
	/// <summary>
	///	
	/// </summary>
	[DataContract]
	public partial class SPPhoneAreaEntity  : BaseTableEntity,ICloneable
	{
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPPhoneAreaEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_PROVINCE = "Province";
		public static readonly string PROPERTY_NAME_CITY = "City";
		public static readonly string PROPERTY_NAME_PHONEPREFIX = "PhonePrefix";
		public static readonly string PROPERTY_NAME_CODETYPE = "CodeType";
		
        #endregion
	
 
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _id;
		private string _province;
		private string _city;
		private string _phonePrefix;
		private string _codeType;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPPhoneAreaEntity()
		{
			_id = 0;
			_province = null;
			_city = null;
			_phonePrefix = null;
			_codeType = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SPPhoneAreaEntity( int id, string province, string city, string phonePrefix, string codeType)
		{
			_id = id;
			_province = province;
			_city = city;
			_phonePrefix = phonePrefix;
			_codeType = codeType;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int Id
		{
			get { return _id; }

			set	
			{
				_isChanged |= (_id != value); _id = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Province
		{
			get { return _province; }

			set	
			{

				if( value != null && value.Length > 24)
					throw new ArgumentOutOfRangeException("Invalid value for Province", value, value.ToString());
				_isChanged |= (_province != value); _province = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string City
		{
			get { return _city; }

			set	
			{

				if( value != null && value.Length > 24)
					throw new ArgumentOutOfRangeException("Invalid value for City", value, value.ToString());
				_isChanged |= (_city != value); _city = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string PhonePrefix
		{
			get { return _phonePrefix; }

			set	
			{

				if( value != null && value.Length > 24)
					throw new ArgumentOutOfRangeException("Invalid value for PhonePrefix", value, value.ToString());
				_isChanged |= (_phonePrefix != value); _phonePrefix = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string CodeType
		{
			get { return _codeType; }

			set	
			{

				if( value != null && value.Length > 10)
					throw new ArgumentOutOfRangeException("Invalid value for CodeType", value, value.ToString());
				_isChanged |= (_codeType != value); _codeType = value;
			}
		}
	

		#endregion 

        

		#region Equals 和 HashCode 方法覆盖
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			 return this.CheckEquals(obj as SPPhoneAreaEntity);
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
	        return this._id;
	    }
		
		
	
		#region ICloneable methods
		
		public virtual object Clone()
		{
			return this.MemberwiseClone();
		}
		
		#endregion
	
	}
}
