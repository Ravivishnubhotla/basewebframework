// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Legendigital.Framework.Common.Entity;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	
	/// </summary>
	[DataContract]
	public partial class SystemPhoneAreaEntity  : BaseTableEntity<int>  ,ICloneable
	{
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemPhoneAreaEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_PHONEPREFIX = "PhonePrefix";
		public static readonly string PROPERTY_NAME_PROVINCE = "Province";
		public static readonly string PROPERTY_NAME_CITY = "City";
		public static readonly string PROPERTY_NAME_OPERATORTYPE = "OperatorType";
		public static readonly string PROPERTY_NAME_CARDTYPE = "CardType";
		public static readonly string PROPERTY_NAME_AREACODE = "AreaCode";
		public static readonly string PROPERTY_NAME_ZIPCODE = "ZipCode";
		
        #endregion
	
 
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _id;
		private string _phonePrefix;
		private string _province;
		private string _city;
		private string _operatorType;
		private string _cardType;
		private string _areaCode;
		private string _zipCode;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemPhoneAreaEntity()
		{
			_id = 0;
			_phonePrefix = null;
			_province = null;
			_city = null;
			_operatorType = null;
			_cardType = null;
			_areaCode = null;
			_zipCode = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemPhoneAreaEntity( int id, string phonePrefix, string province, string city, string operatorType, string cardType, string areaCode, string zipCode)
		{
			_id = id;
			_phonePrefix = phonePrefix;
			_province = province;
			_city = city;
			_operatorType = operatorType;
			_cardType = cardType;
			_areaCode = areaCode;
			_zipCode = zipCode;
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
		public virtual string OperatorType
		{
			get { return _operatorType; }

			set	
			{

				if( value != null && value.Length > 4)
					throw new ArgumentOutOfRangeException("Invalid value for OperatorType", value, value.ToString());
				_isChanged |= (_operatorType != value); _operatorType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string CardType
		{
			get { return _cardType; }

			set	
			{

				if( value != null && value.Length > 30)
					throw new ArgumentOutOfRangeException("Invalid value for CardType", value, value.ToString());
				_isChanged |= (_cardType != value); _cardType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string AreaCode
		{
			get { return _areaCode; }

			set	
			{

				if( value != null && value.Length > 12)
					throw new ArgumentOutOfRangeException("Invalid value for AreaCode", value, value.ToString());
				_isChanged |= (_areaCode != value); _areaCode = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ZipCode
		{
			get { return _zipCode; }

			set	
			{

				if( value != null && value.Length > 16)
					throw new ArgumentOutOfRangeException("Invalid value for ZipCode", value, value.ToString());
				_isChanged |= (_zipCode != value); _zipCode = value;
			}
		}
	

		#endregion 

        

		#region Equals 和 HashCode 方法覆盖
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			 return this.CheckEquals(obj as SystemPhoneAreaEntity);
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			return GetEntityHashCode();
		}
		#endregion
		
		public override int GetDataEntityKey()
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
