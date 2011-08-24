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
	public partial class SPChannelEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPChannelEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_CODE = "Code";
		public static readonly string PROPERTY_NAME_RECIEVEDURL = "RecievedUrl";
		public static readonly string PROPERTY_NAME_RECIEVEDNAME = "RecievedName";
		public static readonly string PROPERTY_NAME_ISALLOWNULLLINKID = "IsAllowNullLinkID";
		public static readonly string PROPERTY_NAME_ISMONITORREQUEST = "IsMonitorRequest";
		public static readonly string PROPERTY_NAME_ISDISABLE = "IsDisable";
		public static readonly string PROPERTY_NAME_DATAOKMESSAGE = "DataOkMessage";
		public static readonly string PROPERTY_NAME_DATAFAILEDMESSAGE = "DataFailedMessage";
		public static readonly string PROPERTY_NAME_REPORTOKMESSAGE = "ReportOkMessage";
		public static readonly string PROPERTY_NAME_REPORTFAILEDMESSAGE = "ReportFailedMessage";
		public static readonly string PROPERTY_NAME_STATSENDONCE = "StatSendOnce";
		public static readonly string PROPERTY_NAME_TYPEREQUEST = "TypeRequest";
		public static readonly string PROPERTY_NAME_DATAPARAMNAME = "DataParamName";
		public static readonly string PROPERTY_NAME_DATAPARAMVALUE = "DataParamValue";
		public static readonly string PROPERTY_NAME_REPORTPARAMNAME = "ReportParamName";
		public static readonly string PROPERTY_NAME_REPORTPARAMVALUE = "ReportParamValue";
		public static readonly string PROPERTY_NAME_HASFILTERS = "HasFilters";
		public static readonly string PROPERTY_NAME_STATUSPARAMNAME = "StatusParamName";
		public static readonly string PROPERTY_NAME_STATUSPARAMVALUE = "StatusParamValue";
		public static readonly string PROPERTY_NAME_PRICE = "Price";
		public static readonly string PROPERTY_NAME_DEFAULTRATE = "DefaultRate";
		public static readonly string PROPERTY_NAME_HASSTATREPORT = "HasStatReport";
		public static readonly string PROPERTY_NAME_CHANNELDETAILINFO = "ChannelDetailInfo";
		public static readonly string PROPERTY_NAME_UPPERID = "UpperID";
		public static readonly string PROPERTY_NAME_ISLOGREQUEST = "IsLogRequest";
		public static readonly string PROPERTY_NAME_CHANNELTYPE = "ChannelType";
		public static readonly string PROPERTY_NAME_CHANNELSTATUS = "ChannelStatus";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _id;
		private string _name;
		private string _description;
		private string _code;
		private string _recievedUrl;
		private string _recievedName;
		private bool? _isAllowNullLinkID;
		private bool? _isMonitorRequest;
		private bool? _isDisable;
		private string _dataOkMessage;
		private string _dataFailedMessage;
		private string _reportOkMessage;
		private string _reportFailedMessage;
		private bool? _statSendOnce;
		private bool? _typeRequest;
		private string _dataParamName;
		private string _dataParamValue;
		private string _reportParamName;
		private string _reportParamValue;
		private bool? _hasFilters;
		private string _statusParamName;
		private string _statusParamValue;
		private decimal? _price;
		private decimal? _defaultRate;
		private bool? _hasStatReport;
		private string _channelDetailInfo;
		private SPUpperEntity _upperID;
		private bool? _isLogRequest;
		private string _channelType;
		private string _channelStatus;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPChannelEntity()
		{
			_id = 0;
			_name = null;
			_description = null;
			_code = null;
			_recievedUrl = null;
			_recievedName = null;
			_isAllowNullLinkID = null;
			_isMonitorRequest = null;
			_isDisable = null;
			_dataOkMessage = null;
			_dataFailedMessage = null;
			_reportOkMessage = null;
			_reportFailedMessage = null;
			_statSendOnce = null;
			_typeRequest = null;
			_dataParamName = null;
			_dataParamValue = null;
			_reportParamName = null;
			_reportParamValue = null;
			_hasFilters = null;
			_statusParamName = null;
			_statusParamValue = null;
			_price = null;
			_defaultRate = null;
			_hasStatReport = null;
			_channelDetailInfo = null;
			_upperID = null;
			_isLogRequest = null;
			_channelType = null;
			_channelStatus = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SPChannelEntity( int id, string name, string description, string code, string recievedUrl, string recievedName, bool? isAllowNullLinkID, bool? isMonitorRequest, bool? isDisable, string dataOkMessage, string dataFailedMessage, string reportOkMessage, string reportFailedMessage, bool? statSendOnce, bool? typeRequest, string dataParamName, string dataParamValue, string reportParamName, string reportParamValue, bool? hasFilters, string statusParamName, string statusParamValue, decimal? price, decimal? defaultRate, bool? hasStatReport, string channelDetailInfo, SPUpperEntity upperID, bool? isLogRequest, string channelType, string channelStatus)
		{
			_id = id;
			_name = name;
			_description = description;
			_code = code;
			_recievedUrl = recievedUrl;
			_recievedName = recievedName;
			_isAllowNullLinkID = isAllowNullLinkID;
			_isMonitorRequest = isMonitorRequest;
			_isDisable = isDisable;
			_dataOkMessage = dataOkMessage;
			_dataFailedMessage = dataFailedMessage;
			_reportOkMessage = reportOkMessage;
			_reportFailedMessage = reportFailedMessage;
			_statSendOnce = statSendOnce;
			_typeRequest = typeRequest;
			_dataParamName = dataParamName;
			_dataParamValue = dataParamValue;
			_reportParamName = reportParamName;
			_reportParamValue = reportParamValue;
			_hasFilters = hasFilters;
			_statusParamName = statusParamName;
			_statusParamValue = statusParamValue;
			_price = price;
			_defaultRate = defaultRate;
			_hasStatReport = hasStatReport;
			_channelDetailInfo = channelDetailInfo;
			_upperID = upperID;
			_isLogRequest = isLogRequest;
			_channelType = channelType;
			_channelStatus = channelStatus;
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

				if( value != null && value.Length > 4000)
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

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Code", value, value.ToString());
				_isChanged |= (_code != value); _code = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string RecievedUrl
		{
			get { return _recievedUrl; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for RecievedUrl", value, value.ToString());
				_isChanged |= (_recievedUrl != value); _recievedUrl = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string RecievedName
		{
			get { return _recievedName; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for RecievedName", value, value.ToString());
				_isChanged |= (_recievedName != value); _recievedName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? IsAllowNullLinkID
		{
			get { return _isAllowNullLinkID; }

			set	
			{
				_isChanged |= (_isAllowNullLinkID != value); _isAllowNullLinkID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? IsMonitorRequest
		{
			get { return _isMonitorRequest; }

			set	
			{
				_isChanged |= (_isMonitorRequest != value); _isMonitorRequest = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? IsDisable
		{
			get { return _isDisable; }

			set	
			{
				_isChanged |= (_isDisable != value); _isDisable = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string DataOkMessage
		{
			get { return _dataOkMessage; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for DataOkMessage", value, value.ToString());
				_isChanged |= (_dataOkMessage != value); _dataOkMessage = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string DataFailedMessage
		{
			get { return _dataFailedMessage; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for DataFailedMessage", value, value.ToString());
				_isChanged |= (_dataFailedMessage != value); _dataFailedMessage = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ReportOkMessage
		{
			get { return _reportOkMessage; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ReportOkMessage", value, value.ToString());
				_isChanged |= (_reportOkMessage != value); _reportOkMessage = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ReportFailedMessage
		{
			get { return _reportFailedMessage; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ReportFailedMessage", value, value.ToString());
				_isChanged |= (_reportFailedMessage != value); _reportFailedMessage = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? StatSendOnce
		{
			get { return _statSendOnce; }

			set	
			{
				_isChanged |= (_statSendOnce != value); _statSendOnce = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? TypeRequest
		{
			get { return _typeRequest; }

			set	
			{
				_isChanged |= (_typeRequest != value); _typeRequest = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string DataParamName
		{
			get { return _dataParamName; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for DataParamName", value, value.ToString());
				_isChanged |= (_dataParamName != value); _dataParamName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string DataParamValue
		{
			get { return _dataParamValue; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for DataParamValue", value, value.ToString());
				_isChanged |= (_dataParamValue != value); _dataParamValue = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ReportParamName
		{
			get { return _reportParamName; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ReportParamName", value, value.ToString());
				_isChanged |= (_reportParamName != value); _reportParamName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ReportParamValue
		{
			get { return _reportParamValue; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ReportParamValue", value, value.ToString());
				_isChanged |= (_reportParamValue != value); _reportParamValue = value;
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
		/// 
		/// </summary>
		[DataMember]
		public virtual string StatusParamName
		{
			get { return _statusParamName; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for StatusParamName", value, value.ToString());
				_isChanged |= (_statusParamName != value); _statusParamName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string StatusParamValue
		{
			get { return _statusParamValue; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for StatusParamValue", value, value.ToString());
				_isChanged |= (_statusParamValue != value); _statusParamValue = value;
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
		public virtual decimal? DefaultRate
		{
			get { return _defaultRate; }

			set	
			{
				_isChanged |= (_defaultRate != value); _defaultRate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? HasStatReport
		{
			get { return _hasStatReport; }

			set	
			{
				_isChanged |= (_hasStatReport != value); _hasStatReport = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ChannelDetailInfo
		{
			get { return _channelDetailInfo; }

			set	
			{

				if( value != null && value.Length > 2147483646)
					throw new ArgumentOutOfRangeException("Invalid value for ChannelDetailInfo", value, value.ToString());
				_isChanged |= (_channelDetailInfo != value); _channelDetailInfo = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual SPUpperEntity UpperID
		{
			get { return _upperID; }

			set	
			{
				_isChanged |= (_upperID != value); _upperID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? IsLogRequest
		{
			get { return _isLogRequest; }

			set	
			{
				_isChanged |= (_isLogRequest != value); _isLogRequest = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ChannelType
		{
			get { return _channelType; }

			set	
			{

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for ChannelType", value, value.ToString());
				_isChanged |= (_channelType != value); _channelType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ChannelStatus
		{
			get { return _channelStatus; }

			set	
			{

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for ChannelStatus", value, value.ToString());
				_isChanged |= (_channelStatus != value); _channelStatus = value;
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
			
			SPChannelEntity castObj = (SPChannelEntity)obj;
			
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