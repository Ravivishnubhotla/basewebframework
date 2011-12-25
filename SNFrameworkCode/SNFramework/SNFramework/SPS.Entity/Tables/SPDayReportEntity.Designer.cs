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
	public partial class SPDayReportEntity  : BaseTableEntity,ICloneable
	{
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPDayReportEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_REPORTDATE = "ReportDate";
		public static readonly string PROPERTY_NAME_TOTALCOUNT = "TotalCount";
		public static readonly string PROPERTY_NAME_TOTALSUCCESSCOUNT = "TotalSuccessCount";
		public static readonly string PROPERTY_NAME_INTERCEPTCOUNT = "InterceptCount";
		public static readonly string PROPERTY_NAME_DOWNTOTALCOUNT = "DownTotalCount";
		public static readonly string PROPERTY_NAME_DOWNSYCNSUCCESS = "DownSycnSuccess";
		public static readonly string PROPERTY_NAME_DOWNSYCNFAILED = "DownSycnFailed";
		public static readonly string PROPERTY_NAME_DOWNNOTSYCN = "DownNotSycn";
		public static readonly string PROPERTY_NAME_CLIENTID = "ClientID";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		public static readonly string PROPERTY_NAME_CODEID = "CodeID";
		public static readonly string PROPERTY_NAME_UPERID = "UperID";
		
        #endregion
	
 
		#region clientID字段外键查询字段
        public const string PROPERTY_CLIENTID_ALIAS_NAME = "ClientID_SPDayReportEntity_Alias";
		public const string PROPERTY_CLIENTID_ID = "ClientID_SPDayReportEntity_Alias.Id";
		public const string PROPERTY_CLIENTID_NAME = "ClientID_SPDayReportEntity_Alias.Name";
		public const string PROPERTY_CLIENTID_DESCRIPTION = "ClientID_SPDayReportEntity_Alias.Description";
		public const string PROPERTY_CLIENTID_USERID = "ClientID_SPDayReportEntity_Alias.UserID";
		public const string PROPERTY_CLIENTID_ISDEFAULTCLIENT = "ClientID_SPDayReportEntity_Alias.IsDefaultClient";
		public const string PROPERTY_CLIENTID_SYNCDATA = "ClientID_SPDayReportEntity_Alias.SyncData";
		public const string PROPERTY_CLIENTID_SYCNRETRYTIMES = "ClientID_SPDayReportEntity_Alias.SycnRetryTimes";
		public const string PROPERTY_CLIENTID_SYNCTYPE = "ClientID_SPDayReportEntity_Alias.SyncType";
		public const string PROPERTY_CLIENTID_SYCNNOTINTERCEPTCOUNT = "ClientID_SPDayReportEntity_Alias.SycnNotInterceptCount";
		public const string PROPERTY_CLIENTID_SYCNDATAURL = "ClientID_SPDayReportEntity_Alias.SycnDataUrl";
		public const string PROPERTY_CLIENTID_SYCNOKMESSAGE = "ClientID_SPDayReportEntity_Alias.SycnOkMessage";
		public const string PROPERTY_CLIENTID_SYCNFAILEDMESSAGE = "ClientID_SPDayReportEntity_Alias.SycnFailedMessage";
		public const string PROPERTY_CLIENTID_ALIAS = "ClientID_SPDayReportEntity_Alias.Alias";
		public const string PROPERTY_CLIENTID_INTERCEPTRATE = "ClientID_SPDayReportEntity_Alias.InterceptRate";
		public const string PROPERTY_CLIENTID_DEFAULTPRICE = "ClientID_SPDayReportEntity_Alias.DefaultPrice";
		public const string PROPERTY_CLIENTID_DEFAULTSHOWRECORDDAYS = "ClientID_SPDayReportEntity_Alias.DefaultShowRecordDays";
		public const string PROPERTY_CLIENTID_CREATEBY = "ClientID_SPDayReportEntity_Alias.CreateBy";
		public const string PROPERTY_CLIENTID_CREATEAT = "ClientID_SPDayReportEntity_Alias.CreateAt";
		public const string PROPERTY_CLIENTID_LASTMODIFYBY = "ClientID_SPDayReportEntity_Alias.LastModifyBy";
		public const string PROPERTY_CLIENTID_LASTMODIFYAT = "ClientID_SPDayReportEntity_Alias.LastModifyAt";
		public const string PROPERTY_CLIENTID_LASTMODIFYCOMMENT = "ClientID_SPDayReportEntity_Alias.LastModifyComment";
		#endregion
		#region channelID字段外键查询字段
        public const string PROPERTY_CHANNELID_ALIAS_NAME = "ChannelID_SPDayReportEntity_Alias";
		public const string PROPERTY_CHANNELID_ID = "ChannelID_SPDayReportEntity_Alias.Id";
		public const string PROPERTY_CHANNELID_NAME = "ChannelID_SPDayReportEntity_Alias.Name";
		public const string PROPERTY_CHANNELID_CODE = "ChannelID_SPDayReportEntity_Alias.Code";
		public const string PROPERTY_CHANNELID_DATAOKMESSAGE = "ChannelID_SPDayReportEntity_Alias.DataOkMessage";
		public const string PROPERTY_CHANNELID_DATAFAILEDMESSAGE = "ChannelID_SPDayReportEntity_Alias.DataFailedMessage";
		public const string PROPERTY_CHANNELID_DESCRIPTION = "ChannelID_SPDayReportEntity_Alias.Description";
		public const string PROPERTY_CHANNELID_DATAADAPTERTYPE = "ChannelID_SPDayReportEntity_Alias.DataAdapterType";
		public const string PROPERTY_CHANNELID_DATAADAPTERURL = "ChannelID_SPDayReportEntity_Alias.DataAdapterUrl";
		public const string PROPERTY_CHANNELID_CHANNELTYPE = "ChannelID_SPDayReportEntity_Alias.ChannelType";
		public const string PROPERTY_CHANNELID_IVRFEETIMETYPE = "ChannelID_SPDayReportEntity_Alias.IVRFeeTimeType";
		public const string PROPERTY_CHANNELID_IVRTIMEFORMAT = "ChannelID_SPDayReportEntity_Alias.IVRTimeFormat";
		public const string PROPERTY_CHANNELID_ISSTATEREPORT = "ChannelID_SPDayReportEntity_Alias.IsStateReport";
		public const string PROPERTY_CHANNELID_STATEREPORTTYPE = "ChannelID_SPDayReportEntity_Alias.StateReportType";
		public const string PROPERTY_CHANNELID_REPORTOKMESSAGE = "ChannelID_SPDayReportEntity_Alias.ReportOkMessage";
		public const string PROPERTY_CHANNELID_REPORTFAILEDMESSAGE = "ChannelID_SPDayReportEntity_Alias.ReportFailedMessage";
		public const string PROPERTY_CHANNELID_STATEREPORTPARAMNAME = "ChannelID_SPDayReportEntity_Alias.StateReportParamName";
		public const string PROPERTY_CHANNELID_STATEREPORTPARAMVALUE = "ChannelID_SPDayReportEntity_Alias.StateReportParamValue";
		public const string PROPERTY_CHANNELID_REQUESTTYPEPARAMNAME = "ChannelID_SPDayReportEntity_Alias.RequestTypeParamName";
		public const string PROPERTY_CHANNELID_REQUESTTYPEPARAMSTATEREPORTVALUE = "ChannelID_SPDayReportEntity_Alias.RequestTypeParamStateReportValue";
		public const string PROPERTY_CHANNELID_REQUESTTYPEPARAMDATAREPORTVALUE = "ChannelID_SPDayReportEntity_Alias.RequestTypeParamDataReportValue";
		public const string PROPERTY_CHANNELID_HASFILTERS = "ChannelID_SPDayReportEntity_Alias.HasFilters";
		public const string PROPERTY_CHANNELID_ISMONITORREQUEST = "ChannelID_SPDayReportEntity_Alias.IsMonitorRequest";
		public const string PROPERTY_CHANNELID_ISLOGREQUEST = "ChannelID_SPDayReportEntity_Alias.IsLogRequest";
		public const string PROPERTY_CHANNELID_ISPARAMSCONVERT = "ChannelID_SPDayReportEntity_Alias.IsParamsConvert";
		public const string PROPERTY_CHANNELID_ISAUTOLINKID = "ChannelID_SPDayReportEntity_Alias.IsAutoLinkID";
		public const string PROPERTY_CHANNELID_AUTOLINKIDFIELDS = "ChannelID_SPDayReportEntity_Alias.AutoLinkIDFields";
		public const string PROPERTY_CHANNELID_LOGREQUESTTYPE = "ChannelID_SPDayReportEntity_Alias.LogRequestType";
		public const string PROPERTY_CHANNELID_PRICE = "ChannelID_SPDayReportEntity_Alias.Price";
		public const string PROPERTY_CHANNELID_DEFAULTRATE = "ChannelID_SPDayReportEntity_Alias.DefaultRate";
		public const string PROPERTY_CHANNELID_CHANNELDETAILINFO = "ChannelID_SPDayReportEntity_Alias.ChannelDetailInfo";
		public const string PROPERTY_CHANNELID_UPPERID = "ChannelID_SPDayReportEntity_Alias.UpperID";
		public const string PROPERTY_CHANNELID_CHANNELSTATUS = "ChannelID_SPDayReportEntity_Alias.ChannelStatus";
		public const string PROPERTY_CHANNELID_ISDISABLE = "ChannelID_SPDayReportEntity_Alias.IsDisable";
		public const string PROPERTY_CHANNELID_CREATEBY = "ChannelID_SPDayReportEntity_Alias.CreateBy";
		public const string PROPERTY_CHANNELID_CREATEAT = "ChannelID_SPDayReportEntity_Alias.CreateAt";
		public const string PROPERTY_CHANNELID_LASTMODIFYBY = "ChannelID_SPDayReportEntity_Alias.LastModifyBy";
		public const string PROPERTY_CHANNELID_LASTMODIFYAT = "ChannelID_SPDayReportEntity_Alias.LastModifyAt";
		public const string PROPERTY_CHANNELID_LASTMODIFYCOMMENT = "ChannelID_SPDayReportEntity_Alias.LastModifyComment";
		#endregion
		#region codeID字段外键查询字段
        public const string PROPERTY_CODEID_ALIAS_NAME = "CodeID_SPDayReportEntity_Alias";
		public const string PROPERTY_CODEID_ID = "CodeID_SPDayReportEntity_Alias.Id";
		public const string PROPERTY_CODEID_NAME = "CodeID_SPDayReportEntity_Alias.Name";
		public const string PROPERTY_CODEID_DESCRIPTION = "CodeID_SPDayReportEntity_Alias.Description";
		public const string PROPERTY_CODEID_CODE = "CodeID_SPDayReportEntity_Alias.Code";
		public const string PROPERTY_CODEID_CODETYPE = "CodeID_SPDayReportEntity_Alias.CodeType";
		public const string PROPERTY_CODEID_CHANNELID = "CodeID_SPDayReportEntity_Alias.ChannelID";
		public const string PROPERTY_CODEID_MO = "CodeID_SPDayReportEntity_Alias.Mo";
		public const string PROPERTY_CODEID_MOTYPE = "CodeID_SPDayReportEntity_Alias.MOType";
		public const string PROPERTY_CODEID_MOLENGTH = "CodeID_SPDayReportEntity_Alias.MOLength";
		public const string PROPERTY_CODEID_ORDERINDEX = "CodeID_SPDayReportEntity_Alias.OrderIndex";
		public const string PROPERTY_CODEID_SPCODE = "CodeID_SPDayReportEntity_Alias.SPCode";
		public const string PROPERTY_CODEID_SPCODETYPE = "CodeID_SPDayReportEntity_Alias.SPCodeType";
		public const string PROPERTY_CODEID_SPCODELENGTH = "CodeID_SPDayReportEntity_Alias.SPCodeLength";
		public const string PROPERTY_CODEID_HASFILTERS = "CodeID_SPDayReportEntity_Alias.HasFilters";
		public const string PROPERTY_CODEID_HASPARAMSCONVERT = "CodeID_SPDayReportEntity_Alias.HasParamsConvert";
		public const string PROPERTY_CODEID_PROVINCE = "CodeID_SPDayReportEntity_Alias.Province";
		public const string PROPERTY_CODEID_DISABLECITY = "CodeID_SPDayReportEntity_Alias.DisableCity";
		public const string PROPERTY_CODEID_ISDIABLE = "CodeID_SPDayReportEntity_Alias.IsDiable";
		public const string PROPERTY_CODEID_DAYLIMIT = "CodeID_SPDayReportEntity_Alias.DayLimit";
		public const string PROPERTY_CODEID_MONTHLIMIT = "CodeID_SPDayReportEntity_Alias.MonthLimit";
		public const string PROPERTY_CODEID_PRICE = "CodeID_SPDayReportEntity_Alias.Price";
		public const string PROPERTY_CODEID_SENDTEXT = "CodeID_SPDayReportEntity_Alias.SendText";
		public const string PROPERTY_CODEID_CREATEBY = "CodeID_SPDayReportEntity_Alias.CreateBy";
		public const string PROPERTY_CODEID_CREATEAT = "CodeID_SPDayReportEntity_Alias.CreateAt";
		public const string PROPERTY_CODEID_LASTMODIFYBY = "CodeID_SPDayReportEntity_Alias.LastModifyBy";
		public const string PROPERTY_CODEID_LASTMODIFYAT = "CodeID_SPDayReportEntity_Alias.LastModifyAt";
		public const string PROPERTY_CODEID_LASTMODIFYCOMMENT = "CodeID_SPDayReportEntity_Alias.LastModifyComment";
		#endregion
		#region uperID字段外键查询字段
        public const string PROPERTY_UPERID_ALIAS_NAME = "UperID_SPDayReportEntity_Alias";
		public const string PROPERTY_UPERID_ID = "UperID_SPDayReportEntity_Alias.Id";
		public const string PROPERTY_UPERID_NAME = "UperID_SPDayReportEntity_Alias.Name";
		public const string PROPERTY_UPERID_CODE = "UperID_SPDayReportEntity_Alias.Code";
		public const string PROPERTY_UPERID_DESCRIPTION = "UperID_SPDayReportEntity_Alias.Description";
		public const string PROPERTY_UPERID_CREATEBY = "UperID_SPDayReportEntity_Alias.CreateBy";
		public const string PROPERTY_UPERID_CREATEAT = "UperID_SPDayReportEntity_Alias.CreateAt";
		public const string PROPERTY_UPERID_LASTMODIFYBY = "UperID_SPDayReportEntity_Alias.LastModifyBy";
		public const string PROPERTY_UPERID_LASTMODIFYAT = "UperID_SPDayReportEntity_Alias.LastModifyAt";
		public const string PROPERTY_UPERID_LASTMODIFYCOMMENT = "UperID_SPDayReportEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _id;
		private DateTime _reportDate;
		private int _totalCount;
		private int _totalSuccessCount;
		private int _interceptCount;
		private int _downTotalCount;
		private int _downSycnSuccess;
		private int _downSycnFailed;
		private int _downNotSycn;
		private SPSClientEntity _clientID;
		private SPChannelEntity _channelID;
		private SPCodeEntity _codeID;
		private SPUpperEntity _uperID;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPDayReportEntity()
		{
			_id = 0;
			_reportDate = DateTime.MinValue;
			_totalCount = 0;
			_totalSuccessCount = 0;
			_interceptCount = 0;
			_downTotalCount = 0;
			_downSycnSuccess = 0;
			_downSycnFailed = 0;
			_downNotSycn = 0;
			_clientID = null;
			_channelID = null;
			_codeID = null;
			_uperID = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SPDayReportEntity( int id, DateTime reportDate, int totalCount, int totalSuccessCount, int interceptCount, int downTotalCount, int downSycnSuccess, int downSycnFailed, int downNotSycn, SPSClientEntity clientID, SPChannelEntity channelID, SPCodeEntity codeID, SPUpperEntity uperID)
		{
			_id = id;
			_reportDate = reportDate;
			_totalCount = totalCount;
			_totalSuccessCount = totalSuccessCount;
			_interceptCount = interceptCount;
			_downTotalCount = downTotalCount;
			_downSycnSuccess = downSycnSuccess;
			_downSycnFailed = downSycnFailed;
			_downNotSycn = downNotSycn;
			_clientID = clientID;
			_channelID = channelID;
			_codeID = codeID;
			_uperID = uperID;
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
		public virtual DateTime ReportDate
		{
			get { return _reportDate; }

			set	
			{
				_isChanged |= (_reportDate != value); _reportDate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int TotalCount
		{
			get { return _totalCount; }

			set	
			{
				_isChanged |= (_totalCount != value); _totalCount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int TotalSuccessCount
		{
			get { return _totalSuccessCount; }

			set	
			{
				_isChanged |= (_totalSuccessCount != value); _totalSuccessCount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int InterceptCount
		{
			get { return _interceptCount; }

			set	
			{
				_isChanged |= (_interceptCount != value); _interceptCount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int DownTotalCount
		{
			get { return _downTotalCount; }

			set	
			{
				_isChanged |= (_downTotalCount != value); _downTotalCount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int DownSycnSuccess
		{
			get { return _downSycnSuccess; }

			set	
			{
				_isChanged |= (_downSycnSuccess != value); _downSycnSuccess = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int DownSycnFailed
		{
			get { return _downSycnFailed; }

			set	
			{
				_isChanged |= (_downSycnFailed != value); _downSycnFailed = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int DownNotSycn
		{
			get { return _downNotSycn; }

			set	
			{
				_isChanged |= (_downNotSycn != value); _downNotSycn = value;
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
		public virtual SPChannelEntity ChannelID
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
		public virtual SPUpperEntity UperID
		{
			get { return _uperID; }

			set	
			{
				_isChanged |= (_uperID != value); _uperID = value;
			}
		}
	

		#endregion 

        

		#region Equals 和 HashCode 方法覆盖
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			 return this.CheckEquals(obj as SPDayReportEntity);
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
