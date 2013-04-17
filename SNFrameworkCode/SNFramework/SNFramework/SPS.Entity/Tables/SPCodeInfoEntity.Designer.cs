// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SPCodeInfoEntity.Designer.cs">
//   Copyright (c) Foreveross Enterprises. All rights reserved.
// </copyright>
// <summary>
//   Generated by MyGeneration Version # (1.3.0.9)
// </summary>
// --------------------------------------------------------------------------------------------------------------------
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
	public partial class SPCodeInfoEntity  : BaseTableEntity<int>,ICloneable
	{
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPCodeInfoEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_SPCODEID = "SPCodeID";
		public static readonly string PROPERTY_NAME_PROVINCE = "Province";
		public static readonly string PROPERTY_NAME_DISABLECITY = "DisableCity";
		public static readonly string PROPERTY_NAME_DAYLIMIT = "DayLimit";
		public static readonly string PROPERTY_NAME_MONTHLIMIT = "MonthLimit";
		public static readonly string PROPERTY_NAME_SENDTEXT = "SendText";
		
        #endregion
	
 
		#region sPCodeID字段外键查询字段
        public const string PROPERTY_SPCODEID_ALIAS_NAME = "SPCodeID_SPCodeInfoEntity_Alias";
		public const string PROPERTY_SPCODEID_ID = "SPCodeID_SPCodeInfoEntity_Alias.Id";
		public const string PROPERTY_SPCODEID_NAME = "SPCodeID_SPCodeInfoEntity_Alias.Name";
		public const string PROPERTY_SPCODEID_DESCRIPTION = "SPCodeID_SPCodeInfoEntity_Alias.Description";
		public const string PROPERTY_SPCODEID_CODE = "SPCodeID_SPCodeInfoEntity_Alias.Code";
		public const string PROPERTY_SPCODEID_CODETYPE = "SPCodeID_SPCodeInfoEntity_Alias.CodeType";
		public const string PROPERTY_SPCODEID_CHANNELID = "SPCodeID_SPCodeInfoEntity_Alias.ChannelID";
		public const string PROPERTY_SPCODEID_MO = "SPCodeID_SPCodeInfoEntity_Alias.Mo";
		public const string PROPERTY_SPCODEID_MOTYPE = "SPCodeID_SPCodeInfoEntity_Alias.MOType";
		public const string PROPERTY_SPCODEID_MOLENGTH = "SPCodeID_SPCodeInfoEntity_Alias.MOLength";
		public const string PROPERTY_SPCODEID_ORDERINDEX = "SPCodeID_SPCodeInfoEntity_Alias.OrderIndex";
		public const string PROPERTY_SPCODEID_SPCODE = "SPCodeID_SPCodeInfoEntity_Alias.SPCode";
		public const string PROPERTY_SPCODEID_SPCODETYPE = "SPCodeID_SPCodeInfoEntity_Alias.SPCodeType";
		public const string PROPERTY_SPCODEID_SPCODELENGTH = "SPCodeID_SPCodeInfoEntity_Alias.SPCodeLength";
		public const string PROPERTY_SPCODEID_HASFILTERS = "SPCodeID_SPCodeInfoEntity_Alias.HasFilters";
		public const string PROPERTY_SPCODEID_HASPARAMSCONVERT = "SPCodeID_SPCodeInfoEntity_Alias.HasParamsConvert";
		public const string PROPERTY_SPCODEID_ISDIABLE = "SPCodeID_SPCodeInfoEntity_Alias.IsDiable";
		public const string PROPERTY_SPCODEID_PRICE = "SPCodeID_SPCodeInfoEntity_Alias.Price";
		public const string PROPERTY_SPCODEID_OPERATIONTYPE = "SPCodeID_SPCodeInfoEntity_Alias.OperationType";
		public const string PROPERTY_SPCODEID_HASDAYTOTALLIMIT = "SPCodeID_SPCodeInfoEntity_Alias.HasDayTotalLimit";
		public const string PROPERTY_SPCODEID_DAYTOTALLIMITCOUNT = "SPCodeID_SPCodeInfoEntity_Alias.DayTotalLimitCount";
		public const string PROPERTY_SPCODEID_HASPHONELIMIT = "SPCodeID_SPCodeInfoEntity_Alias.HasPhoneLimit";
		public const string PROPERTY_SPCODEID_PHONELIMITDAYCOUNT = "SPCodeID_SPCodeInfoEntity_Alias.PhoneLimitDayCount";
		public const string PROPERTY_SPCODEID_PHONELIMITMONTHCOUNT = "SPCodeID_SPCodeInfoEntity_Alias.PhoneLimitMonthCount";
		public const string PROPERTY_SPCODEID_PHONELIMITTYPE = "SPCodeID_SPCodeInfoEntity_Alias.PhoneLimitType";
		public const string PROPERTY_SPCODEID_LIMITPROVINCE = "SPCodeID_SPCodeInfoEntity_Alias.LimitProvince";
		public const string PROPERTY_SPCODEID_LIMITPROVINCEAREA = "SPCodeID_SPCodeInfoEntity_Alias.LimitProvinceArea";
		public const string PROPERTY_SPCODEID_PARENTID = "SPCodeID_SPCodeInfoEntity_Alias.ParentID";
		public const string PROPERTY_SPCODEID_ISMATCHCASE = "SPCodeID_SPCodeInfoEntity_Alias.IsMatchCase";
		public const string PROPERTY_SPCODEID_ISDAYTIMELIMIT = "SPCodeID_SPCodeInfoEntity_Alias.IsDayTimeLimit";
		public const string PROPERTY_SPCODEID_DAYTIMELIMITRANGESTART = "SPCodeID_SPCodeInfoEntity_Alias.DayTimeLimitRangeStart";
		public const string PROPERTY_SPCODEID_DAYTIMELIMITRANGEEND = "SPCodeID_SPCodeInfoEntity_Alias.DayTimeLimitRangeEnd";
		public const string PROPERTY_SPCODEID_CHANNELSTATUS = "SPCodeID_SPCodeInfoEntity_Alias.ChannelStatus";
		public const string PROPERTY_SPCODEID_CREATEBY = "SPCodeID_SPCodeInfoEntity_Alias.CreateBy";
		public const string PROPERTY_SPCODEID_CREATEAT = "SPCodeID_SPCodeInfoEntity_Alias.CreateAt";
		public const string PROPERTY_SPCODEID_LASTMODIFYBY = "SPCodeID_SPCodeInfoEntity_Alias.LastModifyBy";
		public const string PROPERTY_SPCODEID_LASTMODIFYAT = "SPCodeID_SPCodeInfoEntity_Alias.LastModifyAt";
		public const string PROPERTY_SPCODEID_LASTMODIFYCOMMENT = "SPCodeID_SPCodeInfoEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _id;
		private SPCodeEntity _sPCodeID;
		private string _province;
		private string _disableCity;
		private string _dayLimit;
		private string _monthLimit;
		private string _sendText;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPCodeInfoEntity()
		{
			_id = 0;
			_sPCodeID = null;
			_province = null;
			_disableCity = null;
			_dayLimit = null;
			_monthLimit = null;
			_sendText = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SPCodeInfoEntity( int id, SPCodeEntity sPCodeID, string province, string disableCity, string dayLimit, string monthLimit, string sendText)
		{
			_id = id;
			_sPCodeID = sPCodeID;
			_province = province;
			_disableCity = disableCity;
			_dayLimit = dayLimit;
			_monthLimit = monthLimit;
			_sendText = sendText;
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
		public virtual SPCodeEntity SPCodeID
		{
			get { return _sPCodeID; }

			set	
			{
				_isChanged |= (_sPCodeID != value); _sPCodeID = value;
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

				if( value != null && value.Length > 400)
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

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for DisableCity", value, value.ToString());
				_isChanged |= (_disableCity != value); _disableCity = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string DayLimit
		{
			get { return _dayLimit; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for DayLimit", value, value.ToString());
				_isChanged |= (_dayLimit != value); _dayLimit = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string MonthLimit
		{
			get { return _monthLimit; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for MonthLimit", value, value.ToString());
				_isChanged |= (_monthLimit != value); _monthLimit = value;
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

				if( value != null && value.Length > 8000)
					throw new ArgumentOutOfRangeException("Invalid value for SendText", value, value.ToString());
				_isChanged |= (_sendText != value); _sendText = value;
			}
		}
	

		#endregion 

        

		#region Equals 和 HashCode 方法覆盖
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			 return this.CheckEquals(obj as SPCodeInfoEntity);
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