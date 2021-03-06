// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SPClientCodeSycnParamsEntity.Designer.cs">
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
	public partial class SPClientCodeSycnParamsEntity  : BaseTableEntity<int>,ICloneable
	{
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPClientCodeSycnParamsEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_ISENABLE = "IsEnable";
		public static readonly string PROPERTY_NAME_ISREQUIRED = "IsRequired";
		public static readonly string PROPERTY_NAME_CODEID = "CodeID";
		public static readonly string PROPERTY_NAME_MAPPINGPARAMS = "MappingParams";
		public static readonly string PROPERTY_NAME_TITLE = "Title";
		public static readonly string PROPERTY_NAME_PARAMSVALUE = "ParamsValue";
		public static readonly string PROPERTY_NAME_PARAMSTYPE = "ParamsType";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region codeID字段外键查询字段
        public const string PROPERTY_CODEID_ALIAS_NAME = "CodeID_SPClientCodeSycnParamsEntity_Alias";
		public const string PROPERTY_CODEID_ID = "CodeID_SPClientCodeSycnParamsEntity_Alias.Id";
		public const string PROPERTY_CODEID_NAME = "CodeID_SPClientCodeSycnParamsEntity_Alias.Name";
		public const string PROPERTY_CODEID_DESCRIPTION = "CodeID_SPClientCodeSycnParamsEntity_Alias.Description";
		public const string PROPERTY_CODEID_CODE = "CodeID_SPClientCodeSycnParamsEntity_Alias.Code";
		public const string PROPERTY_CODEID_CODETYPE = "CodeID_SPClientCodeSycnParamsEntity_Alias.CodeType";
		public const string PROPERTY_CODEID_CHANNELID = "CodeID_SPClientCodeSycnParamsEntity_Alias.ChannelID";
		public const string PROPERTY_CODEID_MO = "CodeID_SPClientCodeSycnParamsEntity_Alias.Mo";
		public const string PROPERTY_CODEID_MOTYPE = "CodeID_SPClientCodeSycnParamsEntity_Alias.MOType";
		public const string PROPERTY_CODEID_MOLENGTH = "CodeID_SPClientCodeSycnParamsEntity_Alias.MOLength";
		public const string PROPERTY_CODEID_ORDERINDEX = "CodeID_SPClientCodeSycnParamsEntity_Alias.OrderIndex";
		public const string PROPERTY_CODEID_SPCODE = "CodeID_SPClientCodeSycnParamsEntity_Alias.SPCode";
		public const string PROPERTY_CODEID_SPCODETYPE = "CodeID_SPClientCodeSycnParamsEntity_Alias.SPCodeType";
		public const string PROPERTY_CODEID_SPCODELENGTH = "CodeID_SPClientCodeSycnParamsEntity_Alias.SPCodeLength";
		public const string PROPERTY_CODEID_HASFILTERS = "CodeID_SPClientCodeSycnParamsEntity_Alias.HasFilters";
		public const string PROPERTY_CODEID_HASPARAMSCONVERT = "CodeID_SPClientCodeSycnParamsEntity_Alias.HasParamsConvert";
		public const string PROPERTY_CODEID_ISDIABLE = "CodeID_SPClientCodeSycnParamsEntity_Alias.IsDiable";
		public const string PROPERTY_CODEID_PRICE = "CodeID_SPClientCodeSycnParamsEntity_Alias.Price";
		public const string PROPERTY_CODEID_OPERATIONTYPE = "CodeID_SPClientCodeSycnParamsEntity_Alias.OperationType";
		public const string PROPERTY_CODEID_HASDAYTOTALLIMIT = "CodeID_SPClientCodeSycnParamsEntity_Alias.HasDayTotalLimit";
		public const string PROPERTY_CODEID_DAYTOTALLIMITCOUNT = "CodeID_SPClientCodeSycnParamsEntity_Alias.DayTotalLimitCount";
		public const string PROPERTY_CODEID_HASPHONELIMIT = "CodeID_SPClientCodeSycnParamsEntity_Alias.HasPhoneLimit";
		public const string PROPERTY_CODEID_HASDAYMONTHLIMIT = "CodeID_SPClientCodeSycnParamsEntity_Alias.HasDayMonthLimit";
		public const string PROPERTY_CODEID_PHONELIMITDAYCOUNT = "CodeID_SPClientCodeSycnParamsEntity_Alias.PhoneLimitDayCount";
		public const string PROPERTY_CODEID_PHONELIMITMONTHCOUNT = "CodeID_SPClientCodeSycnParamsEntity_Alias.PhoneLimitMonthCount";
		public const string PROPERTY_CODEID_PHONELIMITTYPE = "CodeID_SPClientCodeSycnParamsEntity_Alias.PhoneLimitType";
		public const string PROPERTY_CODEID_LIMITPROVINCE = "CodeID_SPClientCodeSycnParamsEntity_Alias.LimitProvince";
		public const string PROPERTY_CODEID_LIMITPROVINCEAREA = "CodeID_SPClientCodeSycnParamsEntity_Alias.LimitProvinceArea";
		public const string PROPERTY_CODEID_PARENTID = "CodeID_SPClientCodeSycnParamsEntity_Alias.ParentID";
		public const string PROPERTY_CODEID_ISMATCHCASE = "CodeID_SPClientCodeSycnParamsEntity_Alias.IsMatchCase";
		public const string PROPERTY_CODEID_ISDAYTIMELIMIT = "CodeID_SPClientCodeSycnParamsEntity_Alias.IsDayTimeLimit";
		public const string PROPERTY_CODEID_DAYTIMELIMITRANGESTART = "CodeID_SPClientCodeSycnParamsEntity_Alias.DayTimeLimitRangeStart";
		public const string PROPERTY_CODEID_DAYTIMELIMITRANGEEND = "CodeID_SPClientCodeSycnParamsEntity_Alias.DayTimeLimitRangeEnd";
		public const string PROPERTY_CODEID_DAYTOTALLIMITINPROVINCE = "CodeID_SPClientCodeSycnParamsEntity_Alias.DayTotalLimitInProvince";
		public const string PROPERTY_CODEID_DAYTOTALLIMITINPROVINCEASSIGNEDCOUNT = "CodeID_SPClientCodeSycnParamsEntity_Alias.DayTotalLimitInProvinceAssignedCount";
		public const string PROPERTY_CODEID_CHANNELSTATUS = "CodeID_SPClientCodeSycnParamsEntity_Alias.ChannelStatus";
		public const string PROPERTY_CODEID_CREATEBY = "CodeID_SPClientCodeSycnParamsEntity_Alias.CreateBy";
		public const string PROPERTY_CODEID_CREATEAT = "CodeID_SPClientCodeSycnParamsEntity_Alias.CreateAt";
		public const string PROPERTY_CODEID_LASTMODIFYBY = "CodeID_SPClientCodeSycnParamsEntity_Alias.LastModifyBy";
		public const string PROPERTY_CODEID_LASTMODIFYAT = "CodeID_SPClientCodeSycnParamsEntity_Alias.LastModifyAt";
		public const string PROPERTY_CODEID_LASTMODIFYCOMMENT = "CodeID_SPClientCodeSycnParamsEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _id;
		private string _name;
		private string _description;
		private bool _isEnable;
		private bool _isRequired;
		private SPCodeEntity _codeID;
		private string _mappingParams;
		private string _title;
		private string _paramsValue;
		private string _paramsType;
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
		public SPClientCodeSycnParamsEntity()
		{
			_id = 0;
			_name = String.Empty;
			_description = String.Empty;
			_isEnable = false;
			_isRequired = false;
			_codeID = null;
			_mappingParams = String.Empty;
			_title = String.Empty;
			_paramsValue = String.Empty;
			_paramsType = String.Empty;
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
		public SPClientCodeSycnParamsEntity( int id, string name, string description, bool isEnable, bool isRequired, SPCodeEntity codeID, string mappingParams, string title, string paramsValue, string paramsType, int? createBy, DateTime? createAt, int? lastModifyBy, DateTime? lastModifyAt, string lastModifyComment)
		{
			_id = id;
			_name = name;
			_description = description;
			_isEnable = isEnable;
			_isRequired = isRequired;
			_codeID = codeID;
			_mappingParams = mappingParams;
			_title = title;
			_paramsValue = paramsValue;
			_paramsType = paramsType;
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

				if( value != null && value.Length > 400)
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

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
				_isChanged |= (_description != value); _description = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool IsEnable
		{
			get { return _isEnable; }

			set	
			{
				_isChanged |= (_isEnable != value); _isEnable = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool IsRequired
		{
			get { return _isRequired; }

			set	
			{
				_isChanged |= (_isRequired != value); _isRequired = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual SPCodeEntity CodeID
		{
			get { return _codeID; }

			set	
			{
				_isChanged |= (_codeID != value); _codeID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string MappingParams
		{
			get { return _mappingParams; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for MappingParams", value, value.ToString());
				_isChanged |= (_mappingParams != value); _mappingParams = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Title
		{
			get { return _title; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Title", value, value.ToString());
				_isChanged |= (_title != value); _title = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ParamsValue
		{
			get { return _paramsValue; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ParamsValue", value, value.ToString());
				_isChanged |= (_paramsValue != value); _paramsValue = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ParamsType
		{
			get { return _paramsType; }

			set	
			{

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for ParamsType", value, value.ToString());
				_isChanged |= (_paramsType != value); _paramsType = value;
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
			 return this.CheckEquals(obj as SPClientCodeSycnParamsEntity);
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
