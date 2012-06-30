// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SPRecordEntity.Designer.cs">
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
	public partial class SPRecordEntity  : BaseTableEntity<int>,ICloneable
	{
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPRecordEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_LINKID = "LinkID";
		public static readonly string PROPERTY_NAME_MO = "Mo";
		public static readonly string PROPERTY_NAME_MOBILE = "Mobile";
		public static readonly string PROPERTY_NAME_SPNUMBER = "SpNumber";
		public static readonly string PROPERTY_NAME_PROVINCE = "Province";
		public static readonly string PROPERTY_NAME_CITY = "City";
		public static readonly string PROPERTY_NAME_OPERATORTYPE = "OperatorType";
		public static readonly string PROPERTY_NAME_CREATEDATE = "CreateDate";
		public static readonly string PROPERTY_NAME_ISREPORT = "IsReport";
		public static readonly string PROPERTY_NAME_ISINTERCEPT = "IsIntercept";
		public static readonly string PROPERTY_NAME_ISSYCNTOCLIENT = "IsSycnToClient";
		public static readonly string PROPERTY_NAME_ISSYCNSUCCESSED = "IsSycnSuccessed";
		public static readonly string PROPERTY_NAME_ISSTATOK = "IsStatOK";
		public static readonly string PROPERTY_NAME_SYCNRETRYTIMES = "SycnRetryTimes";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		public static readonly string PROPERTY_NAME_CLIENTID = "ClientID";
		public static readonly string PROPERTY_NAME_CODEID = "CodeID";
		public static readonly string PROPERTY_NAME_CLIENTCODERELATIONID = "ClientCodeRelationID";
		public static readonly string PROPERTY_NAME_PRICE = "Price";
		public static readonly string PROPERTY_NAME_COUNT = "Count";
		
        #endregion
	
 
		#region channelID字段外键查询字段
        public const string PROPERTY_CHANNELID_ALIAS_NAME = "ChannelID_SPRecordEntity_Alias";
		public const string PROPERTY_CHANNELID_ID = "ChannelID_SPRecordEntity_Alias.Id";
		public const string PROPERTY_CHANNELID_NAME = "ChannelID_SPRecordEntity_Alias.Name";
		public const string PROPERTY_CHANNELID_CODE = "ChannelID_SPRecordEntity_Alias.Code";
		public const string PROPERTY_CHANNELID_DATAOKMESSAGE = "ChannelID_SPRecordEntity_Alias.DataOkMessage";
		public const string PROPERTY_CHANNELID_DATAFAILEDMESSAGE = "ChannelID_SPRecordEntity_Alias.DataFailedMessage";
		public const string PROPERTY_CHANNELID_DESCRIPTION = "ChannelID_SPRecordEntity_Alias.Description";
		public const string PROPERTY_CHANNELID_DATAADAPTERTYPE = "ChannelID_SPRecordEntity_Alias.DataAdapterType";
		public const string PROPERTY_CHANNELID_DATAADAPTERURL = "ChannelID_SPRecordEntity_Alias.DataAdapterUrl";
		public const string PROPERTY_CHANNELID_CHANNELTYPE = "ChannelID_SPRecordEntity_Alias.ChannelType";
		public const string PROPERTY_CHANNELID_IVRFEETIMETYPE = "ChannelID_SPRecordEntity_Alias.IVRFeeTimeType";
		public const string PROPERTY_CHANNELID_IVRTIMEFORMAT = "ChannelID_SPRecordEntity_Alias.IVRTimeFormat";
		public const string PROPERTY_CHANNELID_ISSTATEREPORT = "ChannelID_SPRecordEntity_Alias.IsStateReport";
		public const string PROPERTY_CHANNELID_STATEREPORTTYPE = "ChannelID_SPRecordEntity_Alias.StateReportType";
		public const string PROPERTY_CHANNELID_REPORTOKMESSAGE = "ChannelID_SPRecordEntity_Alias.ReportOkMessage";
		public const string PROPERTY_CHANNELID_REPORTFAILEDMESSAGE = "ChannelID_SPRecordEntity_Alias.ReportFailedMessage";
		public const string PROPERTY_CHANNELID_STATEREPORTPARAMNAME = "ChannelID_SPRecordEntity_Alias.StateReportParamName";
		public const string PROPERTY_CHANNELID_STATEREPORTPARAMVALUE = "ChannelID_SPRecordEntity_Alias.StateReportParamValue";
		public const string PROPERTY_CHANNELID_REQUESTTYPEPARAMNAME = "ChannelID_SPRecordEntity_Alias.RequestTypeParamName";
		public const string PROPERTY_CHANNELID_REQUESTTYPEPARAMSTATEREPORTVALUE = "ChannelID_SPRecordEntity_Alias.RequestTypeParamStateReportValue";
		public const string PROPERTY_CHANNELID_REQUESTTYPEPARAMDATAREPORTVALUE = "ChannelID_SPRecordEntity_Alias.RequestTypeParamDataReportValue";
		public const string PROPERTY_CHANNELID_HASFILTERS = "ChannelID_SPRecordEntity_Alias.HasFilters";
		public const string PROPERTY_CHANNELID_ISMONITORREQUEST = "ChannelID_SPRecordEntity_Alias.IsMonitorRequest";
		public const string PROPERTY_CHANNELID_ISLOGREQUEST = "ChannelID_SPRecordEntity_Alias.IsLogRequest";
		public const string PROPERTY_CHANNELID_ISPARAMSCONVERT = "ChannelID_SPRecordEntity_Alias.IsParamsConvert";
		public const string PROPERTY_CHANNELID_ISAUTOLINKID = "ChannelID_SPRecordEntity_Alias.IsAutoLinkID";
		public const string PROPERTY_CHANNELID_AUTOLINKIDFIELDS = "ChannelID_SPRecordEntity_Alias.AutoLinkIDFields";
		public const string PROPERTY_CHANNELID_LOGREQUESTTYPE = "ChannelID_SPRecordEntity_Alias.LogRequestType";
		public const string PROPERTY_CHANNELID_PRICE = "ChannelID_SPRecordEntity_Alias.Price";
		public const string PROPERTY_CHANNELID_DEFAULTRATE = "ChannelID_SPRecordEntity_Alias.DefaultRate";
		public const string PROPERTY_CHANNELID_CHANNELDETAILINFO = "ChannelID_SPRecordEntity_Alias.ChannelDetailInfo";
		public const string PROPERTY_CHANNELID_UPPERID = "ChannelID_SPRecordEntity_Alias.UpperID";
		public const string PROPERTY_CHANNELID_CHANNELSTATUS = "ChannelID_SPRecordEntity_Alias.ChannelStatus";
		public const string PROPERTY_CHANNELID_ISDISABLE = "ChannelID_SPRecordEntity_Alias.IsDisable";
		public const string PROPERTY_CHANNELID_CREATEBY = "ChannelID_SPRecordEntity_Alias.CreateBy";
		public const string PROPERTY_CHANNELID_CREATEAT = "ChannelID_SPRecordEntity_Alias.CreateAt";
		public const string PROPERTY_CHANNELID_LASTMODIFYBY = "ChannelID_SPRecordEntity_Alias.LastModifyBy";
		public const string PROPERTY_CHANNELID_LASTMODIFYAT = "ChannelID_SPRecordEntity_Alias.LastModifyAt";
		public const string PROPERTY_CHANNELID_LASTMODIFYCOMMENT = "ChannelID_SPRecordEntity_Alias.LastModifyComment";
		#endregion
		#region clientID字段外键查询字段
        public const string PROPERTY_CLIENTID_ALIAS_NAME = "ClientID_SPRecordEntity_Alias";
		public const string PROPERTY_CLIENTID_ID = "ClientID_SPRecordEntity_Alias.Id";
		public const string PROPERTY_CLIENTID_NAME = "ClientID_SPRecordEntity_Alias.Name";
		public const string PROPERTY_CLIENTID_DESCRIPTION = "ClientID_SPRecordEntity_Alias.Description";
		public const string PROPERTY_CLIENTID_USERID = "ClientID_SPRecordEntity_Alias.UserID";
		public const string PROPERTY_CLIENTID_ISDEFAULTCLIENT = "ClientID_SPRecordEntity_Alias.IsDefaultClient";
		public const string PROPERTY_CLIENTID_SYNCDATA = "ClientID_SPRecordEntity_Alias.SyncData";
		public const string PROPERTY_CLIENTID_SYCNNOTINTERCEPTCOUNT = "ClientID_SPRecordEntity_Alias.SycnNotInterceptCount";
		public const string PROPERTY_CLIENTID_SYNCDATASETTING = "ClientID_SPRecordEntity_Alias.SyncDataSetting";
		public const string PROPERTY_CLIENTID_ALIAS = "ClientID_SPRecordEntity_Alias.Alias";
		public const string PROPERTY_CLIENTID_INTERCEPTRATE = "ClientID_SPRecordEntity_Alias.InterceptRate";
		public const string PROPERTY_CLIENTID_DEFAULTPRICE = "ClientID_SPRecordEntity_Alias.DefaultPrice";
		public const string PROPERTY_CLIENTID_DEFAULTSHOWRECORDDAYS = "ClientID_SPRecordEntity_Alias.DefaultShowRecordDays";
		public const string PROPERTY_CLIENTID_CREATEBY = "ClientID_SPRecordEntity_Alias.CreateBy";
		public const string PROPERTY_CLIENTID_CREATEAT = "ClientID_SPRecordEntity_Alias.CreateAt";
		public const string PROPERTY_CLIENTID_LASTMODIFYBY = "ClientID_SPRecordEntity_Alias.LastModifyBy";
		public const string PROPERTY_CLIENTID_LASTMODIFYAT = "ClientID_SPRecordEntity_Alias.LastModifyAt";
		public const string PROPERTY_CLIENTID_LASTMODIFYCOMMENT = "ClientID_SPRecordEntity_Alias.LastModifyComment";
		#endregion
		#region codeID字段外键查询字段
        public const string PROPERTY_CODEID_ALIAS_NAME = "CodeID_SPRecordEntity_Alias";
		public const string PROPERTY_CODEID_ID = "CodeID_SPRecordEntity_Alias.Id";
		public const string PROPERTY_CODEID_NAME = "CodeID_SPRecordEntity_Alias.Name";
		public const string PROPERTY_CODEID_DESCRIPTION = "CodeID_SPRecordEntity_Alias.Description";
		public const string PROPERTY_CODEID_CODE = "CodeID_SPRecordEntity_Alias.Code";
		public const string PROPERTY_CODEID_CODETYPE = "CodeID_SPRecordEntity_Alias.CodeType";
		public const string PROPERTY_CODEID_CHANNELID = "CodeID_SPRecordEntity_Alias.ChannelID";
		public const string PROPERTY_CODEID_MO = "CodeID_SPRecordEntity_Alias.Mo";
		public const string PROPERTY_CODEID_MOTYPE = "CodeID_SPRecordEntity_Alias.MOType";
		public const string PROPERTY_CODEID_MOLENGTH = "CodeID_SPRecordEntity_Alias.MOLength";
		public const string PROPERTY_CODEID_ORDERINDEX = "CodeID_SPRecordEntity_Alias.OrderIndex";
		public const string PROPERTY_CODEID_SPCODE = "CodeID_SPRecordEntity_Alias.SPCode";
		public const string PROPERTY_CODEID_SPCODETYPE = "CodeID_SPRecordEntity_Alias.SPCodeType";
		public const string PROPERTY_CODEID_SPCODELENGTH = "CodeID_SPRecordEntity_Alias.SPCodeLength";
		public const string PROPERTY_CODEID_HASFILTERS = "CodeID_SPRecordEntity_Alias.HasFilters";
		public const string PROPERTY_CODEID_HASPARAMSCONVERT = "CodeID_SPRecordEntity_Alias.HasParamsConvert";
		public const string PROPERTY_CODEID_ISDIABLE = "CodeID_SPRecordEntity_Alias.IsDiable";
		public const string PROPERTY_CODEID_PRICE = "CodeID_SPRecordEntity_Alias.Price";
		public const string PROPERTY_CODEID_OPERATIONTYPE = "CodeID_SPRecordEntity_Alias.OperationType";
		public const string PROPERTY_CODEID_HASDAYTOTALLIMIT = "CodeID_SPRecordEntity_Alias.HasDayTotalLimit";
		public const string PROPERTY_CODEID_DAYTOTALLIMITCOUNT = "CodeID_SPRecordEntity_Alias.DayTotalLimitCount";
		public const string PROPERTY_CODEID_HASPHONELIMIT = "CodeID_SPRecordEntity_Alias.HasPhoneLimit";
		public const string PROPERTY_CODEID_PHONELIMITDAYCOUNT = "CodeID_SPRecordEntity_Alias.PhoneLimitDayCount";
		public const string PROPERTY_CODEID_PHONELIMITMONTHCOUNT = "CodeID_SPRecordEntity_Alias.PhoneLimitMonthCount";
		public const string PROPERTY_CODEID_PHONELIMITTYPE = "CodeID_SPRecordEntity_Alias.PhoneLimitType";
		public const string PROPERTY_CODEID_LIMITPROVINCE = "CodeID_SPRecordEntity_Alias.LimitProvince";
		public const string PROPERTY_CODEID_LIMITPROVINCEAREA = "CodeID_SPRecordEntity_Alias.LimitProvinceArea";
		public const string PROPERTY_CODEID_PARENTID = "CodeID_SPRecordEntity_Alias.ParentID";
		public const string PROPERTY_CODEID_CREATEBY = "CodeID_SPRecordEntity_Alias.CreateBy";
		public const string PROPERTY_CODEID_CREATEAT = "CodeID_SPRecordEntity_Alias.CreateAt";
		public const string PROPERTY_CODEID_LASTMODIFYBY = "CodeID_SPRecordEntity_Alias.LastModifyBy";
		public const string PROPERTY_CODEID_LASTMODIFYAT = "CodeID_SPRecordEntity_Alias.LastModifyAt";
		public const string PROPERTY_CODEID_LASTMODIFYCOMMENT = "CodeID_SPRecordEntity_Alias.LastModifyComment";
		#endregion
		#region clientCodeRelationID字段外键查询字段
        public const string PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME = "ClientCodeRelationID_SPRecordEntity_Alias";
		public const string PROPERTY_CLIENTCODERELATIONID_ID = "ClientCodeRelationID_SPRecordEntity_Alias.Id";
		public const string PROPERTY_CLIENTCODERELATIONID_CODEID = "ClientCodeRelationID_SPRecordEntity_Alias.CodeID";
		public const string PROPERTY_CLIENTCODERELATIONID_CLIENTID = "ClientCodeRelationID_SPRecordEntity_Alias.ClientID";
		public const string PROPERTY_CLIENTCODERELATIONID_PRICE = "ClientCodeRelationID_SPRecordEntity_Alias.Price";
		public const string PROPERTY_CLIENTCODERELATIONID_INTERCEPTRATE = "ClientCodeRelationID_SPRecordEntity_Alias.InterceptRate";
		public const string PROPERTY_CLIENTCODERELATIONID_USECLIENTDEFAULTSYCNSETTING = "ClientCodeRelationID_SPRecordEntity_Alias.UseClientDefaultSycnSetting";
		public const string PROPERTY_CLIENTCODERELATIONID_SYNCDATA = "ClientCodeRelationID_SPRecordEntity_Alias.SyncData";
		public const string PROPERTY_CLIENTCODERELATIONID_SYCNRETRYTIMES = "ClientCodeRelationID_SPRecordEntity_Alias.SycnRetryTimes";
		public const string PROPERTY_CLIENTCODERELATIONID_SYNCDATASETTING = "ClientCodeRelationID_SPRecordEntity_Alias.SyncDataSetting";
		public const string PROPERTY_CLIENTCODERELATIONID_STARTDATE = "ClientCodeRelationID_SPRecordEntity_Alias.StartDate";
		public const string PROPERTY_CLIENTCODERELATIONID_ENDDATE = "ClientCodeRelationID_SPRecordEntity_Alias.EndDate";
		public const string PROPERTY_CLIENTCODERELATIONID_ISENABLE = "ClientCodeRelationID_SPRecordEntity_Alias.IsEnable";
		public const string PROPERTY_CLIENTCODERELATIONID_SYCNNOTINTERCEPTCOUNT = "ClientCodeRelationID_SPRecordEntity_Alias.SycnNotInterceptCount";
		public const string PROPERTY_CLIENTCODERELATIONID_DEFAULTSHOWRECORDDAYS = "ClientCodeRelationID_SPRecordEntity_Alias.DefaultShowRecordDays";
		public const string PROPERTY_CLIENTCODERELATIONID_CREATEBY = "ClientCodeRelationID_SPRecordEntity_Alias.CreateBy";
		public const string PROPERTY_CLIENTCODERELATIONID_CREATEAT = "ClientCodeRelationID_SPRecordEntity_Alias.CreateAt";
		public const string PROPERTY_CLIENTCODERELATIONID_LASTMODIFYBY = "ClientCodeRelationID_SPRecordEntity_Alias.LastModifyBy";
		public const string PROPERTY_CLIENTCODERELATIONID_LASTMODIFYAT = "ClientCodeRelationID_SPRecordEntity_Alias.LastModifyAt";
		public const string PROPERTY_CLIENTCODERELATIONID_LASTMODIFYCOMMENT = "ClientCodeRelationID_SPRecordEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _id;
		private string _linkID;
		private string _mo;
		private string _mobile;
		private string _spNumber;
		private string _province;
		private string _city;
		private string _operatorType;
		private DateTime _createDate;
		private bool _isReport;
		private bool _isIntercept;
		private bool _isSycnToClient;
		private bool _isSycnSuccessed;
		private bool _isStatOK;
		private int _sycnRetryTimes;
		private SPChannelEntity _channelID;
		private SPSClientEntity _clientID;
		private SPCodeEntity _codeID;
		private SPClientCodeRelationEntity _clientCodeRelationID;
		private decimal? _price;
		private int _count;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPRecordEntity()
		{
			_id = 0;
			_linkID = String.Empty;
			_mo = null;
			_mobile = String.Empty;
			_spNumber = null;
			_province = String.Empty;
			_city = String.Empty;
			_operatorType = String.Empty;
			_createDate = DateTime.MinValue;
			_isReport = false;
			_isIntercept = false;
			_isSycnToClient = false;
			_isSycnSuccessed = false;
			_isStatOK = false;
			_sycnRetryTimes = 0;
			_channelID = null;
			_clientID = null;
			_codeID = null;
			_clientCodeRelationID = null;
			_price = null;
			_count = 0;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SPRecordEntity( int id, string linkID, string mo, string mobile, string spNumber, string province, string city, string operatorType, DateTime createDate, bool isReport, bool isIntercept, bool isSycnToClient, bool isSycnSuccessed, bool isStatOK, int sycnRetryTimes, SPChannelEntity channelID, SPSClientEntity clientID, SPCodeEntity codeID, SPClientCodeRelationEntity clientCodeRelationID, decimal? price, int count)
		{
			_id = id;
			_linkID = linkID;
			_mo = mo;
			_mobile = mobile;
			_spNumber = spNumber;
			_province = province;
			_city = city;
			_operatorType = operatorType;
			_createDate = createDate;
			_isReport = isReport;
			_isIntercept = isIntercept;
			_isSycnToClient = isSycnToClient;
			_isSycnSuccessed = isSycnSuccessed;
			_isStatOK = isStatOK;
			_sycnRetryTimes = sycnRetryTimes;
			_channelID = channelID;
			_clientID = clientID;
			_codeID = codeID;
			_clientCodeRelationID = clientCodeRelationID;
			_price = price;
			_count = count;
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
		public virtual string LinkID
		{
			get { return _linkID; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for LinkID", value, value.ToString());
				_isChanged |= (_linkID != value); _linkID = value;
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
		public virtual string Mobile
		{
			get { return _mobile; }

			set	
			{

				if( value != null && value.Length > 30)
					throw new ArgumentOutOfRangeException("Invalid value for Mobile", value, value.ToString());
				_isChanged |= (_mobile != value); _mobile = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string SpNumber
		{
			get { return _spNumber; }

			set	
			{

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for SpNumber", value, value.ToString());
				_isChanged |= (_spNumber != value); _spNumber = value;
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

				if( value != null && value.Length > 12)
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

				if( value != null && value.Length > 16)
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
		public virtual DateTime CreateDate
		{
			get { return _createDate; }

			set	
			{
				_isChanged |= (_createDate != value); _createDate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool IsReport
		{
			get { return _isReport; }

			set	
			{
				_isChanged |= (_isReport != value); _isReport = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool IsIntercept
		{
			get { return _isIntercept; }

			set	
			{
				_isChanged |= (_isIntercept != value); _isIntercept = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool IsSycnToClient
		{
			get { return _isSycnToClient; }

			set	
			{
				_isChanged |= (_isSycnToClient != value); _isSycnToClient = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool IsSycnSuccessed
		{
			get { return _isSycnSuccessed; }

			set	
			{
				_isChanged |= (_isSycnSuccessed != value); _isSycnSuccessed = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool IsStatOK
		{
			get { return _isStatOK; }

			set	
			{
				_isChanged |= (_isStatOK != value); _isStatOK = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int SycnRetryTimes
		{
			get { return _sycnRetryTimes; }

			set	
			{
				_isChanged |= (_sycnRetryTimes != value); _sycnRetryTimes = value;
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
		public virtual SPClientCodeRelationEntity ClientCodeRelationID
		{
			get { return _clientCodeRelationID; }

			set	
			{
				_isChanged |= (_clientCodeRelationID != value); _clientCodeRelationID = value;
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
		public virtual int Count
		{
			get { return _count; }

			set	
			{
				_isChanged |= (_count != value); _count = value;
			}
		}
	

		#endregion 

        

		#region Equals 和 HashCode 方法覆盖
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			 return this.CheckEquals(obj as SPRecordEntity);
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
