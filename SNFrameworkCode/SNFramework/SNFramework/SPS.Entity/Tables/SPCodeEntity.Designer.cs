// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SPS.Entity.Tables
{
	/// <summary>
	///	
	/// </summary>
	[DataContract]
	public partial class SPCodeEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPCodeEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_CODE = "Code";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		public static readonly string PROPERTY_NAME_MO = "Mo";
		public static readonly string PROPERTY_NAME_MOTYPE = "MOType";
		public static readonly string PROPERTY_NAME_ORDERINDEX = "OrderIndex";
		public static readonly string PROPERTY_NAME_SPCODE = "SPCode";
		public static readonly string PROPERTY_NAME_PROVINCE = "Province";
		public static readonly string PROPERTY_NAME_DISABLECITY = "DisableCity";
		public static readonly string PROPERTY_NAME_ISDIABLE = "IsDiable";
		public static readonly string PROPERTY_NAME_SPTYPE = "SPType";
		public static readonly string PROPERTY_NAME_CODELENGTH = "CodeLength";
		public static readonly string PROPERTY_NAME_DAYLIMIT = "DayLimit";
		public static readonly string PROPERTY_NAME_MONTHLIMIT = "MonthLimit";
		public static readonly string PROPERTY_NAME_PRICE = "Price";
		public static readonly string PROPERTY_NAME_SENDTEXT = "SendText";
		public static readonly string PROPERTY_NAME_HASFILTERS = "HasFilters";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _id;
		private string _name;
		private string _description;
		private string _code;
		private int? _channelID;
		private string _mo;
		private string _mOType;
		private int? _orderIndex;
		private string _sPCode;
		private string _province;
		private string _disableCity;
		private bool? _isDiable;
		private string _sPType;
		private int? _codeLength;
		private int? _dayLimit;
		private int? _monthLimit;
		private decimal? _price;
		private string _sendText;
		private bool? _hasFilters;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPCodeEntity()
		{
			_id = 0;
			_name = null;
			_description = null;
			_code = null;
			_channelID = null;
			_mo = null;
			_mOType = null;
			_orderIndex = null;
			_sPCode = null;
			_province = null;
			_disableCity = null;
			_isDiable = null;
			_sPType = null;
			_codeLength = null;
			_dayLimit = null;
			_monthLimit = null;
			_price = null;
			_sendText = null;
			_hasFilters = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SPCodeEntity( int id, string name, string description, string code, int? channelID, string mo, string mOType, int? orderIndex, string sPCode, string province, string disableCity, bool? isDiable, string sPType, int? codeLength, int? dayLimit, int? monthLimit, decimal? price, string sendText, bool? hasFilters)
		{
			_id = id;
			_name = name;
			_description = description;
			_code = code;
			_channelID = channelID;
			_mo = mo;
			_mOType = mOType;
			_orderIndex = orderIndex;
			_sPCode = sPCode;
			_province = province;
			_disableCity = disableCity;
			_isDiable = isDiable;
			_sPType = sPType;
			_codeLength = codeLength;
			_dayLimit = dayLimit;
			_monthLimit = monthLimit;
			_price = price;
			_sendText = sendText;
			_hasFilters = hasFilters;
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
		public virtual string Name
		{
			get { return _name; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
				_isChanged |= (_name != value); _name = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Description
		{
			get { return _description; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
				_isChanged |= (_description != value); _description = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Code
		{
			get { return _code; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Code", value, value.ToString());
				_isChanged |= (_code != value); _code = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? ChannelID
		{
			get { return _channelID; }

			set	
			{
				_isChanged |= (_channelID != value); _channelID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Mo
		{
			get { return _mo; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Mo", value, value.ToString());
				_isChanged |= (_mo != value); _mo = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string MOType
		{
			get { return _mOType; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for MOType", value, value.ToString());
				_isChanged |= (_mOType != value); _mOType = value;
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
		public virtual string SPCode
		{
			get { return _sPCode; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for SPCode", value, value.ToString());
				_isChanged |= (_sPCode != value); _sPCode = value;
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

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Province", value, value.ToString());
				_isChanged |= (_province != value); _province = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string DisableCity
		{
			get { return _disableCity; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for DisableCity", value, value.ToString());
				_isChanged |= (_disableCity != value); _disableCity = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? IsDiable
		{
			get { return _isDiable; }

			set	
			{
				_isChanged |= (_isDiable != value); _isDiable = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string SPType
		{
			get { return _sPType; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for SPType", value, value.ToString());
				_isChanged |= (_sPType != value); _sPType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? CodeLength
		{
			get { return _codeLength; }

			set	
			{
				_isChanged |= (_codeLength != value); _codeLength = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? DayLimit
		{
			get { return _dayLimit; }

			set	
			{
				_isChanged |= (_dayLimit != value); _dayLimit = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? MonthLimit
		{
			get { return _monthLimit; }

			set	
			{
				_isChanged |= (_monthLimit != value); _monthLimit = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual decimal? Price
		{
			get { return _price; }

			set	
			{
				_isChanged |= (_price != value); _price = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string SendText
		{
			get { return _sendText; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for SendText", value, value.ToString());
				_isChanged |= (_sendText != value); _sendText = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? HasFilters
		{
			get { return _hasFilters; }

			set	
			{
				_isChanged |= (_hasFilters != value); _hasFilters = value;
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
			
			SPCodeEntity castObj = (SPCodeEntity)obj;
			
			return ( castObj != null ) && ( this._id == castObj.Id );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id.GetHashCode();

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