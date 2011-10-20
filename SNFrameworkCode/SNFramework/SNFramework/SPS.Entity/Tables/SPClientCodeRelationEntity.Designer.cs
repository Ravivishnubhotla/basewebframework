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
	public partial class SPClientCodeRelationEntity  : BaseTableEntity,ICloneable
	{
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPClientCodeRelationEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_CODEID = "CodeID";
		public static readonly string PROPERTY_NAME_CLIENTID = "ClientID";
		public static readonly string PROPERTY_NAME_PRICE = "Price";
		public static readonly string PROPERTY_NAME_INTERCEPTRATE = "InterceptRate";
		public static readonly string PROPERTY_NAME_USECLIENTDEFAULTSYCNSETTING = "UseClientDefaultSycnSetting";
		public static readonly string PROPERTY_NAME_SYNCDATA = "SyncData";
		public static readonly string PROPERTY_NAME_SYCNRETRYTIMES = "SycnRetryTimes";
		public static readonly string PROPERTY_NAME_SYNCTYPE = "SyncType";
		public static readonly string PROPERTY_NAME_SYCNDATAURL = "SycnDataUrl";
		public static readonly string PROPERTY_NAME_SYCNOKMESSAGE = "SycnOkMessage";
		public static readonly string PROPERTY_NAME_SYCNFAILEDMESSAGE = "SycnFailedMessage";
		public static readonly string PROPERTY_NAME_STARTDATE = "StartDate";
		public static readonly string PROPERTY_NAME_ENDDATE = "EndDate";
		public static readonly string PROPERTY_NAME_ISENABLE = "IsEnable";
		public static readonly string PROPERTY_NAME_SYCNNOTINTERCEPTCOUNT = "SycnNotInterceptCount";
		public static readonly string PROPERTY_NAME_DEFAULTSHOWRECORDDAYS = "DefaultShowRecordDays";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region codeID字段外键查询字段
        public const string PROPERTY_CODEID_ALIAS_NAME = "CodeID_SPClientCodeRelationEntity_Alias";
		public const string PROPERTY_CODEID_ID = "CodeID_SPClientCodeRelationEntity_Alias.Id";
		public const string PROPERTY_CODEID_NAME = "CodeID_SPClientCodeRelationEntity_Alias.Name";
		public const string PROPERTY_CODEID_DESCRIPTION = "CodeID_SPClientCodeRelationEntity_Alias.Description";
		public const string PROPERTY_CODEID_CODE = "CodeID_SPClientCodeRelationEntity_Alias.Code";
		public const string PROPERTY_CODEID_CODETYPE = "CodeID_SPClientCodeRelationEntity_Alias.CodeType";
		public const string PROPERTY_CODEID_CHANNELID = "CodeID_SPClientCodeRelationEntity_Alias.ChannelID";
		public const string PROPERTY_CODEID_MO = "CodeID_SPClientCodeRelationEntity_Alias.Mo";
		public const string PROPERTY_CODEID_MOTYPE = "CodeID_SPClientCodeRelationEntity_Alias.MOType";
		public const string PROPERTY_CODEID_MOLENGTH = "CodeID_SPClientCodeRelationEntity_Alias.MOLength";
		public const string PROPERTY_CODEID_ORDERINDEX = "CodeID_SPClientCodeRelationEntity_Alias.OrderIndex";
		public const string PROPERTY_CODEID_SPCODE = "CodeID_SPClientCodeRelationEntity_Alias.SPCode";
		public const string PROPERTY_CODEID_SPCODETYPE = "CodeID_SPClientCodeRelationEntity_Alias.SPCodeType";
		public const string PROPERTY_CODEID_SPCODELENGTH = "CodeID_SPClientCodeRelationEntity_Alias.SPCodeLength";
		public const string PROPERTY_CODEID_HASFILTERS = "CodeID_SPClientCodeRelationEntity_Alias.HasFilters";
		public const string PROPERTY_CODEID_HASPARAMSCONVERT = "CodeID_SPClientCodeRelationEntity_Alias.HasParamsConvert";
		public const string PROPERTY_CODEID_PROVINCE = "CodeID_SPClientCodeRelationEntity_Alias.Province";
		public const string PROPERTY_CODEID_DISABLECITY = "CodeID_SPClientCodeRelationEntity_Alias.DisableCity";
		public const string PROPERTY_CODEID_ISDIABLE = "CodeID_SPClientCodeRelationEntity_Alias.IsDiable";
		public const string PROPERTY_CODEID_DAYLIMIT = "CodeID_SPClientCodeRelationEntity_Alias.DayLimit";
		public const string PROPERTY_CODEID_MONTHLIMIT = "CodeID_SPClientCodeRelationEntity_Alias.MonthLimit";
		public const string PROPERTY_CODEID_PRICE = "CodeID_SPClientCodeRelationEntity_Alias.Price";
		public const string PROPERTY_CODEID_SENDTEXT = "CodeID_SPClientCodeRelationEntity_Alias.SendText";
		public const string PROPERTY_CODEID_CREATEBY = "CodeID_SPClientCodeRelationEntity_Alias.CreateBy";
		public const string PROPERTY_CODEID_CREATEAT = "CodeID_SPClientCodeRelationEntity_Alias.CreateAt";
		public const string PROPERTY_CODEID_LASTMODIFYBY = "CodeID_SPClientCodeRelationEntity_Alias.LastModifyBy";
		public const string PROPERTY_CODEID_LASTMODIFYAT = "CodeID_SPClientCodeRelationEntity_Alias.LastModifyAt";
		public const string PROPERTY_CODEID_LASTMODIFYCOMMENT = "CodeID_SPClientCodeRelationEntity_Alias.LastModifyComment";
		#endregion
		#region clientID字段外键查询字段
        public const string PROPERTY_CLIENTID_ALIAS_NAME = "ClientID_SPClientCodeRelationEntity_Alias";
		public const string PROPERTY_CLIENTID_ID = "ClientID_SPClientCodeRelationEntity_Alias.Id";
		public const string PROPERTY_CLIENTID_NAME = "ClientID_SPClientCodeRelationEntity_Alias.Name";
		public const string PROPERTY_CLIENTID_DESCRIPTION = "ClientID_SPClientCodeRelationEntity_Alias.Description";
		public const string PROPERTY_CLIENTID_USERID = "ClientID_SPClientCodeRelationEntity_Alias.UserID";
		public const string PROPERTY_CLIENTID_ISDEFAULTCLIENT = "ClientID_SPClientCodeRelationEntity_Alias.IsDefaultClient";
		public const string PROPERTY_CLIENTID_SYNCDATA = "ClientID_SPClientCodeRelationEntity_Alias.SyncData";
		public const string PROPERTY_CLIENTID_SYCNRETRYTIMES = "ClientID_SPClientCodeRelationEntity_Alias.SycnRetryTimes";
		public const string PROPERTY_CLIENTID_SYNCTYPE = "ClientID_SPClientCodeRelationEntity_Alias.SyncType";
		public const string PROPERTY_CLIENTID_SYCNNOTINTERCEPTCOUNT = "ClientID_SPClientCodeRelationEntity_Alias.SycnNotInterceptCount";
		public const string PROPERTY_CLIENTID_SYCNDATAURL = "ClientID_SPClientCodeRelationEntity_Alias.SycnDataUrl";
		public const string PROPERTY_CLIENTID_SYCNOKMESSAGE = "ClientID_SPClientCodeRelationEntity_Alias.SycnOkMessage";
		public const string PROPERTY_CLIENTID_SYCNFAILEDMESSAGE = "ClientID_SPClientCodeRelationEntity_Alias.SycnFailedMessage";
		public const string PROPERTY_CLIENTID_ALIAS = "ClientID_SPClientCodeRelationEntity_Alias.Alias";
		public const string PROPERTY_CLIENTID_INTERCEPTRATE = "ClientID_SPClientCodeRelationEntity_Alias.InterceptRate";
		public const string PROPERTY_CLIENTID_DEFAULTPRICE = "ClientID_SPClientCodeRelationEntity_Alias.DefaultPrice";
		public const string PROPERTY_CLIENTID_DEFAULTSHOWRECORDDAYS = "ClientID_SPClientCodeRelationEntity_Alias.DefaultShowRecordDays";
		public const string PROPERTY_CLIENTID_CREATEBY = "ClientID_SPClientCodeRelationEntity_Alias.CreateBy";
		public const string PROPERTY_CLIENTID_CREATEAT = "ClientID_SPClientCodeRelationEntity_Alias.CreateAt";
		public const string PROPERTY_CLIENTID_LASTMODIFYBY = "ClientID_SPClientCodeRelationEntity_Alias.LastModifyBy";
		public const string PROPERTY_CLIENTID_LASTMODIFYAT = "ClientID_SPClientCodeRelationEntity_Alias.LastModifyAt";
		public const string PROPERTY_CLIENTID_LASTMODIFYCOMMENT = "ClientID_SPClientCodeRelationEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _id;
		private SPCodeEntity _codeID;
		private SPSClientEntity _clientID;
		private decimal _price;
		private decimal _interceptRate;
		private bool _useClientDefaultSycnSetting;
		private bool _syncData;
		private string _sycnRetryTimes;
		private string _syncType;
		private string _sycnDataUrl;
		private string _sycnOkMessage;
		private string _sycnFailedMessage;
		private DateTime? _startDate;
		private DateTime? _endDate;
		private bool _isEnable;
		private int _sycnNotInterceptCount;
		private int _defaultShowRecordDays;
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
		public SPClientCodeRelationEntity()
		{
			_id = 0;
			_codeID = null;
			_clientID = null;
			_price = 0;
			_interceptRate = 0;
			_useClientDefaultSycnSetting = false;
			_syncData = false;
			_sycnRetryTimes = String.Empty;
			_syncType = String.Empty;
			_sycnDataUrl = String.Empty;
			_sycnOkMessage = String.Empty;
			_sycnFailedMessage = String.Empty;
			_startDate = null;
			_endDate = null;
			_isEnable = false;
			_sycnNotInterceptCount = 0;
			_defaultShowRecordDays = 0;
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
		public SPClientCodeRelationEntity( int id, SPCodeEntity codeID, SPSClientEntity clientID, decimal price, decimal interceptRate, bool useClientDefaultSycnSetting, bool syncData, string sycnRetryTimes, string syncType, string sycnDataUrl, string sycnOkMessage, string sycnFailedMessage, DateTime? startDate, DateTime? endDate, bool isEnable, int sycnNotInterceptCount, int defaultShowRecordDays, int? createBy, DateTime? createAt, int? lastModifyBy, DateTime? lastModifyAt, string lastModifyComment)
		{
			_id = id;
			_codeID = codeID;
			_clientID = clientID;
			_price = price;
			_interceptRate = interceptRate;
			_useClientDefaultSycnSetting = useClientDefaultSycnSetting;
			_syncData = syncData;
			_sycnRetryTimes = sycnRetryTimes;
			_syncType = syncType;
			_sycnDataUrl = sycnDataUrl;
			_sycnOkMessage = sycnOkMessage;
			_sycnFailedMessage = sycnFailedMessage;
			_startDate = startDate;
			_endDate = endDate;
			_isEnable = isEnable;
			_sycnNotInterceptCount = sycnNotInterceptCount;
			_defaultShowRecordDays = defaultShowRecordDays;
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
		public virtual SPSClientEntity ClientID
		{
			get { return _clientID; }

			set	
			{
				_isChanged |= (_clientID != value); _clientID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual decimal Price
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
		public virtual decimal InterceptRate
		{
			get { return _interceptRate; }

			set	
			{
				_isChanged |= (_interceptRate != value); _interceptRate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool UseClientDefaultSycnSetting
		{
			get { return _useClientDefaultSycnSetting; }

			set	
			{
				_isChanged |= (_useClientDefaultSycnSetting != value); _useClientDefaultSycnSetting = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool SyncData
		{
			get { return _syncData; }

			set	
			{
				_isChanged |= (_syncData != value); _syncData = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string SycnRetryTimes
		{
			get { return _sycnRetryTimes; }

			set	
			{

				if( value != null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for SycnRetryTimes", value, value.ToString());
				_isChanged |= (_sycnRetryTimes != value); _sycnRetryTimes = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string SyncType
		{
			get { return _syncType; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for SyncType", value, value.ToString());
				_isChanged |= (_syncType != value); _syncType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string SycnDataUrl
		{
			get { return _sycnDataUrl; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for SycnDataUrl", value, value.ToString());
				_isChanged |= (_sycnDataUrl != value); _sycnDataUrl = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string SycnOkMessage
		{
			get { return _sycnOkMessage; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for SycnOkMessage", value, value.ToString());
				_isChanged |= (_sycnOkMessage != value); _sycnOkMessage = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string SycnFailedMessage
		{
			get { return _sycnFailedMessage; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for SycnFailedMessage", value, value.ToString());
				_isChanged |= (_sycnFailedMessage != value); _sycnFailedMessage = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? StartDate
		{
			get { return _startDate; }

			set	
			{
				_isChanged |= (_startDate != value); _startDate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? EndDate
		{
			get { return _endDate; }

			set	
			{
				_isChanged |= (_endDate != value); _endDate = value;
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
		public virtual int SycnNotInterceptCount
		{
			get { return _sycnNotInterceptCount; }

			set	
			{
				_isChanged |= (_sycnNotInterceptCount != value); _sycnNotInterceptCount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int DefaultShowRecordDays
		{
			get { return _defaultShowRecordDays; }

			set	
			{
				_isChanged |= (_defaultShowRecordDays != value); _defaultShowRecordDays = value;
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
			 return this.CheckEquals(obj as SPClientCodeRelationEntity);
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