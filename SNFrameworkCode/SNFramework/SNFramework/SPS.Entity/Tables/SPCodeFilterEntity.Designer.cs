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
	public partial class SPCodeFilterEntity  : BaseTableEntity,ICloneable
	{
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPCodeFilterEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_CODEID = "CodeID";
		public static readonly string PROPERTY_NAME_PARAMSNAME = "ParamsName";
		public static readonly string PROPERTY_NAME_FILTERTYPE = "FilterType";
		public static readonly string PROPERTY_NAME_FILTERVALUE = "FilterValue";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region codeID字段外键查询字段
        public const string PROPERTY_CODEID_ALIAS_NAME = "CodeID_SPCodeFilterEntity_Alias";
		public const string PROPERTY_CODEID_ID = "CodeID_SPCodeFilterEntity_Alias.Id";
		public const string PROPERTY_CODEID_NAME = "CodeID_SPCodeFilterEntity_Alias.Name";
		public const string PROPERTY_CODEID_DESCRIPTION = "CodeID_SPCodeFilterEntity_Alias.Description";
		public const string PROPERTY_CODEID_CODE = "CodeID_SPCodeFilterEntity_Alias.Code";
		public const string PROPERTY_CODEID_CODETYPE = "CodeID_SPCodeFilterEntity_Alias.CodeType";
		public const string PROPERTY_CODEID_CHANNELID = "CodeID_SPCodeFilterEntity_Alias.ChannelID";
		public const string PROPERTY_CODEID_MO = "CodeID_SPCodeFilterEntity_Alias.Mo";
		public const string PROPERTY_CODEID_MOTYPE = "CodeID_SPCodeFilterEntity_Alias.MOType";
		public const string PROPERTY_CODEID_MOLENGTH = "CodeID_SPCodeFilterEntity_Alias.MOLength";
		public const string PROPERTY_CODEID_ORDERINDEX = "CodeID_SPCodeFilterEntity_Alias.OrderIndex";
		public const string PROPERTY_CODEID_SPCODE = "CodeID_SPCodeFilterEntity_Alias.SPCode";
		public const string PROPERTY_CODEID_SPCODETYPE = "CodeID_SPCodeFilterEntity_Alias.SPCodeType";
		public const string PROPERTY_CODEID_SPCODELENGTH = "CodeID_SPCodeFilterEntity_Alias.SPCodeLength";
		public const string PROPERTY_CODEID_HASFILTERS = "CodeID_SPCodeFilterEntity_Alias.HasFilters";
		public const string PROPERTY_CODEID_HASPARAMSCONVERT = "CodeID_SPCodeFilterEntity_Alias.HasParamsConvert";
		public const string PROPERTY_CODEID_PROVINCE = "CodeID_SPCodeFilterEntity_Alias.Province";
		public const string PROPERTY_CODEID_DISABLECITY = "CodeID_SPCodeFilterEntity_Alias.DisableCity";
		public const string PROPERTY_CODEID_ISDIABLE = "CodeID_SPCodeFilterEntity_Alias.IsDiable";
		public const string PROPERTY_CODEID_DAYLIMIT = "CodeID_SPCodeFilterEntity_Alias.DayLimit";
		public const string PROPERTY_CODEID_MONTHLIMIT = "CodeID_SPCodeFilterEntity_Alias.MonthLimit";
		public const string PROPERTY_CODEID_PRICE = "CodeID_SPCodeFilterEntity_Alias.Price";
		public const string PROPERTY_CODEID_SENDTEXT = "CodeID_SPCodeFilterEntity_Alias.SendText";
		public const string PROPERTY_CODEID_CREATEBY = "CodeID_SPCodeFilterEntity_Alias.CreateBy";
		public const string PROPERTY_CODEID_CREATEAT = "CodeID_SPCodeFilterEntity_Alias.CreateAt";
		public const string PROPERTY_CODEID_LASTMODIFYBY = "CodeID_SPCodeFilterEntity_Alias.LastModifyBy";
		public const string PROPERTY_CODEID_LASTMODIFYAT = "CodeID_SPCodeFilterEntity_Alias.LastModifyAt";
		public const string PROPERTY_CODEID_LASTMODIFYCOMMENT = "CodeID_SPCodeFilterEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _id;
		private SPCodeEntity _codeID;
		private string _paramsName;
		private string _filterType;
		private string _filterValue;
		private int _createBy;
		private DateTime _createAt;
		private int? _lastModifyBy;
		private DateTime? _lastModifyAt;
		private string _lastModifyComment;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPCodeFilterEntity()
		{
			_id = 0;
			_codeID = null;
			_paramsName = String.Empty;
			_filterType = String.Empty;
			_filterValue = String.Empty;
			_createBy = 0;
			_createAt = DateTime.MinValue;
			_lastModifyBy = null;
			_lastModifyAt = null;
			_lastModifyComment = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SPCodeFilterEntity( int id, SPCodeEntity codeID, string paramsName, string filterType, string filterValue, int createBy, DateTime createAt, int? lastModifyBy, DateTime? lastModifyAt, string lastModifyComment)
		{
			_id = id;
			_codeID = codeID;
			_paramsName = paramsName;
			_filterType = filterType;
			_filterValue = filterValue;
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
		public virtual string ParamsName
		{
			get { return _paramsName; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ParamsName", value, value.ToString());
				_isChanged |= (_paramsName != value); _paramsName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string FilterType
		{
			get { return _filterType; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for FilterType", value, value.ToString());
				_isChanged |= (_filterType != value); _filterType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string FilterValue
		{
			get { return _filterValue; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for FilterValue", value, value.ToString());
				_isChanged |= (_filterValue != value); _filterValue = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int CreateBy
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
		public virtual DateTime CreateAt
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
			 return this.CheckEquals(obj as SPCodeFilterEntity);
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