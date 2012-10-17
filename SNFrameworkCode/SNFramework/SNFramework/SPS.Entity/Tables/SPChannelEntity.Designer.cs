// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SPChannelEntity.Designer.cs">
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
	public partial class SPChannelEntity  : BaseTableEntity<int>,ICloneable
	{
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPChannelEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_CODE = "Code";
		public static readonly string PROPERTY_NAME_DATAOKMESSAGE = "DataOkMessage";
		public static readonly string PROPERTY_NAME_DATAFAILEDMESSAGE = "DataFailedMessage";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_DATAADAPTERTYPE = "DataAdapterType";
		public static readonly string PROPERTY_NAME_DATAADAPTERURL = "DataAdapterUrl";
		public static readonly string PROPERTY_NAME_CHANNELTYPE = "ChannelType";
		public static readonly string PROPERTY_NAME_IVRFEETIMETYPE = "IVRFeeTimeType";
		public static readonly string PROPERTY_NAME_IVRTIMEFORMAT = "IVRTimeFormat";
		public static readonly string PROPERTY_NAME_ISSTATEREPORT = "IsStateReport";
		public static readonly string PROPERTY_NAME_STATEREPORTTYPE = "StateReportType";
		public static readonly string PROPERTY_NAME_REPORTOKMESSAGE = "ReportOkMessage";
		public static readonly string PROPERTY_NAME_REPORTFAILEDMESSAGE = "ReportFailedMessage";
		public static readonly string PROPERTY_NAME_STATEREPORTPARAMNAME = "StateReportParamName";
		public static readonly string PROPERTY_NAME_STATEREPORTPARAMVALUE = "StateReportParamValue";
		public static readonly string PROPERTY_NAME_REQUESTTYPEPARAMNAME = "RequestTypeParamName";
		public static readonly string PROPERTY_NAME_REQUESTTYPEPARAMSTATEREPORTVALUE = "RequestTypeParamStateReportValue";
		public static readonly string PROPERTY_NAME_REQUESTTYPEPARAMDATAREPORTVALUE = "RequestTypeParamDataReportValue";
		public static readonly string PROPERTY_NAME_HASFILTERS = "HasFilters";
		public static readonly string PROPERTY_NAME_ISMONITORREQUEST = "IsMonitorRequest";
		public static readonly string PROPERTY_NAME_ISLOGREQUEST = "IsLogRequest";
		public static readonly string PROPERTY_NAME_ISPARAMSCONVERT = "IsParamsConvert";
		public static readonly string PROPERTY_NAME_ISAUTOLINKID = "IsAutoLinkID";
		public static readonly string PROPERTY_NAME_AUTOLINKIDFIELDS = "AutoLinkIDFields";
		public static readonly string PROPERTY_NAME_LOGREQUESTTYPE = "LogRequestType";
		public static readonly string PROPERTY_NAME_PRICE = "Price";
		public static readonly string PROPERTY_NAME_DEFAULTRATE = "DefaultRate";
		public static readonly string PROPERTY_NAME_CHANNELDETAILINFO = "ChannelDetailInfo";
		public static readonly string PROPERTY_NAME_UPPERID = "UpperID";
		public static readonly string PROPERTY_NAME_CHANNELSTATUS = "ChannelStatus";
		public static readonly string PROPERTY_NAME_ISDISABLE = "IsDisable";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region upperID字段外键查询字段
        public const string PROPERTY_UPPERID_ALIAS_NAME = "UpperID_SPChannelEntity_Alias";
		public const string PROPERTY_UPPERID_ID = "UpperID_SPChannelEntity_Alias.Id";
		public const string PROPERTY_UPPERID_NAME = "UpperID_SPChannelEntity_Alias.Name";
		public const string PROPERTY_UPPERID_CODE = "UpperID_SPChannelEntity_Alias.Code";
		public const string PROPERTY_UPPERID_DESCRIPTION = "UpperID_SPChannelEntity_Alias.Description";
		public const string PROPERTY_UPPERID_CREATEBY = "UpperID_SPChannelEntity_Alias.CreateBy";
		public const string PROPERTY_UPPERID_CREATEAT = "UpperID_SPChannelEntity_Alias.CreateAt";
		public const string PROPERTY_UPPERID_LASTMODIFYBY = "UpperID_SPChannelEntity_Alias.LastModifyBy";
		public const string PROPERTY_UPPERID_LASTMODIFYAT = "UpperID_SPChannelEntity_Alias.LastModifyAt";
		public const string PROPERTY_UPPERID_LASTMODIFYCOMMENT = "UpperID_SPChannelEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _id;
		private string _name;
		private string _code;
		private string _dataOkMessage;
		private string _dataFailedMessage;
		private string _description;
		private string _dataAdapterType;
		private string _dataAdapterUrl;
		private string _channelType;
		private string _iVRFeeTimeType;
		private string _iVRTimeFormat;
		private bool _isStateReport;
		private string _stateReportType;
		private string _reportOkMessage;
		private string _reportFailedMessage;
		private string _stateReportParamName;
		private string _stateReportParamValue;
		private string _requestTypeParamName;
		private string _requestTypeParamStateReportValue;
		private string _requestTypeParamDataReportValue;
		private bool _hasFilters;
		private bool _isMonitorRequest;
		private bool _isLogRequest;
		private bool _isParamsConvert;
		private bool _isAutoLinkID;
		private string _autoLinkIDFields;
		private string _logRequestType;
		private decimal? _price;
		private decimal? _defaultRate;
		private string _channelDetailInfo;
		private SPUpperEntity _upperID;
		private string _channelStatus;
		private bool _isDisable;
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
		public SPChannelEntity()
		{
			_id = 0;
			_name = String.Empty;
			_code = String.Empty;
			_dataOkMessage = String.Empty;
			_dataFailedMessage = String.Empty;
			_description = String.Empty;
			_dataAdapterType = String.Empty;
			_dataAdapterUrl = String.Empty;
			_channelType = String.Empty;
			_iVRFeeTimeType = null;
			_iVRTimeFormat = null;
			_isStateReport = false;
			_stateReportType = String.Empty;
			_reportOkMessage = String.Empty;
			_reportFailedMessage = String.Empty;
			_stateReportParamName = String.Empty;
			_stateReportParamValue = String.Empty;
			_requestTypeParamName = String.Empty;
			_requestTypeParamStateReportValue = String.Empty;
			_requestTypeParamDataReportValue = String.Empty;
			_hasFilters = false;
			_isMonitorRequest = false;
			_isLogRequest = false;
			_isParamsConvert = false;
			_isAutoLinkID = false;
			_autoLinkIDFields = String.Empty;
			_logRequestType = null;
			_price = null;
			_defaultRate = null;
			_channelDetailInfo = null;
			_upperID = null;
			_channelStatus = null;
			_isDisable = false;
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
		public SPChannelEntity( int id, string name, string code, string dataOkMessage, string dataFailedMessage, string description, string dataAdapterType, string dataAdapterUrl, string channelType, string iVRFeeTimeType, string iVRTimeFormat, bool isStateReport, string stateReportType, string reportOkMessage, string reportFailedMessage, string stateReportParamName, string stateReportParamValue, string requestTypeParamName, string requestTypeParamStateReportValue, string requestTypeParamDataReportValue, bool hasFilters, bool isMonitorRequest, bool isLogRequest, bool isParamsConvert, bool isAutoLinkID, string autoLinkIDFields, string logRequestType, decimal? price, decimal? defaultRate, string channelDetailInfo, SPUpperEntity upperID, string channelStatus, bool isDisable, int? createBy, DateTime? createAt, int? lastModifyBy, DateTime? lastModifyAt, string lastModifyComment)
		{
			_id = id;
			_name = name;
			_code = code;
			_dataOkMessage = dataOkMessage;
			_dataFailedMessage = dataFailedMessage;
			_description = description;
			_dataAdapterType = dataAdapterType;
			_dataAdapterUrl = dataAdapterUrl;
			_channelType = channelType;
			_iVRFeeTimeType = iVRFeeTimeType;
			_iVRTimeFormat = iVRTimeFormat;
			_isStateReport = isStateReport;
			_stateReportType = stateReportType;
			_reportOkMessage = reportOkMessage;
			_reportFailedMessage = reportFailedMessage;
			_stateReportParamName = stateReportParamName;
			_stateReportParamValue = stateReportParamValue;
			_requestTypeParamName = requestTypeParamName;
			_requestTypeParamStateReportValue = requestTypeParamStateReportValue;
			_requestTypeParamDataReportValue = requestTypeParamDataReportValue;
			_hasFilters = hasFilters;
			_isMonitorRequest = isMonitorRequest;
			_isLogRequest = isLogRequest;
			_isParamsConvert = isParamsConvert;
			_isAutoLinkID = isAutoLinkID;
			_autoLinkIDFields = autoLinkIDFields;
			_logRequestType = logRequestType;
			_price = price;
			_defaultRate = defaultRate;
			_channelDetailInfo = channelDetailInfo;
			_upperID = upperID;
			_channelStatus = channelStatus;
			_isDisable = isDisable;
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

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
				_isChanged |= (_name != value); _name = value;
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
		public virtual string DataAdapterType
		{
			get { return _dataAdapterType; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for DataAdapterType", value, value.ToString());
				_isChanged |= (_dataAdapterType != value); _dataAdapterType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string DataAdapterUrl
		{
			get { return _dataAdapterUrl; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for DataAdapterUrl", value, value.ToString());
				_isChanged |= (_dataAdapterUrl != value); _dataAdapterUrl = value;
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
		public virtual string IVRFeeTimeType
		{
			get { return _iVRFeeTimeType; }

			set	
			{

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for IVRFeeTimeType", value, value.ToString());
				_isChanged |= (_iVRFeeTimeType != value); _iVRFeeTimeType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string IVRTimeFormat
		{
			get { return _iVRTimeFormat; }

			set	
			{

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for IVRTimeFormat", value, value.ToString());
				_isChanged |= (_iVRTimeFormat != value); _iVRTimeFormat = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool IsStateReport
		{
			get { return _isStateReport; }

			set	
			{
				_isChanged |= (_isStateReport != value); _isStateReport = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string StateReportType
		{
			get { return _stateReportType; }

			set	
			{

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for StateReportType", value, value.ToString());
				_isChanged |= (_stateReportType != value); _stateReportType = value;
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
		public virtual string StateReportParamName
		{
			get { return _stateReportParamName; }

			set	
			{

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for StateReportParamName", value, value.ToString());
				_isChanged |= (_stateReportParamName != value); _stateReportParamName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string StateReportParamValue
		{
			get { return _stateReportParamValue; }

			set	
			{

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for StateReportParamValue", value, value.ToString());
				_isChanged |= (_stateReportParamValue != value); _stateReportParamValue = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string RequestTypeParamName
		{
			get { return _requestTypeParamName; }

			set	
			{

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for RequestTypeParamName", value, value.ToString());
				_isChanged |= (_requestTypeParamName != value); _requestTypeParamName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string RequestTypeParamStateReportValue
		{
			get { return _requestTypeParamStateReportValue; }

			set	
			{

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for RequestTypeParamStateReportValue", value, value.ToString());
				_isChanged |= (_requestTypeParamStateReportValue != value); _requestTypeParamStateReportValue = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string RequestTypeParamDataReportValue
		{
			get { return _requestTypeParamDataReportValue; }

			set	
			{

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for RequestTypeParamDataReportValue", value, value.ToString());
				_isChanged |= (_requestTypeParamDataReportValue != value); _requestTypeParamDataReportValue = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool HasFilters
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
		public virtual bool IsMonitorRequest
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
		public virtual bool IsLogRequest
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
		public virtual bool IsParamsConvert
		{
			get { return _isParamsConvert; }

			set	
			{
				_isChanged |= (_isParamsConvert != value); _isParamsConvert = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool IsAutoLinkID
		{
			get { return _isAutoLinkID; }

			set	
			{
				_isChanged |= (_isAutoLinkID != value); _isAutoLinkID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string AutoLinkIDFields
		{
			get { return _autoLinkIDFields; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for AutoLinkIDFields", value, value.ToString());
				_isChanged |= (_autoLinkIDFields != value); _autoLinkIDFields = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string LogRequestType
		{
			get { return _logRequestType; }

			set	
			{

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for LogRequestType", value, value.ToString());
				_isChanged |= (_logRequestType != value); _logRequestType = value;
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
		/// 
		/// </summary>
		[DataMember]
		public virtual bool IsDisable
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
			 return this.CheckEquals(obj as SPChannelEntity);
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
