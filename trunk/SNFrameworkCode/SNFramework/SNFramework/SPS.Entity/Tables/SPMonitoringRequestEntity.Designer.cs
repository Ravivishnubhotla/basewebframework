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
	public partial class SPMonitoringRequestEntity  : BaseTableEntity,ICloneable
	{
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPMonitoringRequestEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_RECIEVEDCONTENT = "RecievedContent";
		public static readonly string PROPERTY_NAME_RECIEVEDDATE = "RecievedDate";
		public static readonly string PROPERTY_NAME_RECIEVEDIP = "RecievedIP";
		public static readonly string PROPERTY_NAME_RECIEVEDSENDURL = "RecievedSendUrl";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		
        #endregion
	
 
		#region channelID字段外键查询字段
        public const string PROPERTY_CHANNELID_ALIAS_NAME = "ChannelID_SPMonitoringRequestEntity_Alias";
		public const string PROPERTY_CHANNELID_ID = "ChannelID_SPMonitoringRequestEntity_Alias.Id";
		public const string PROPERTY_CHANNELID_NAME = "ChannelID_SPMonitoringRequestEntity_Alias.Name";
		public const string PROPERTY_CHANNELID_CODE = "ChannelID_SPMonitoringRequestEntity_Alias.Code";
		public const string PROPERTY_CHANNELID_DATAOKMESSAGE = "ChannelID_SPMonitoringRequestEntity_Alias.DataOkMessage";
		public const string PROPERTY_CHANNELID_DATAFAILEDMESSAGE = "ChannelID_SPMonitoringRequestEntity_Alias.DataFailedMessage";
		public const string PROPERTY_CHANNELID_DESCRIPTION = "ChannelID_SPMonitoringRequestEntity_Alias.Description";
		public const string PROPERTY_CHANNELID_DATAADAPTERTYPE = "ChannelID_SPMonitoringRequestEntity_Alias.DataAdapterType";
		public const string PROPERTY_CHANNELID_DATAADAPTERURL = "ChannelID_SPMonitoringRequestEntity_Alias.DataAdapterUrl";
		public const string PROPERTY_CHANNELID_CHANNELTYPE = "ChannelID_SPMonitoringRequestEntity_Alias.ChannelType";
		public const string PROPERTY_CHANNELID_IVRFEETIMETYPE = "ChannelID_SPMonitoringRequestEntity_Alias.IVRFeeTimeType";
		public const string PROPERTY_CHANNELID_IVRTIMEFORMAT = "ChannelID_SPMonitoringRequestEntity_Alias.IVRTimeFormat";
		public const string PROPERTY_CHANNELID_ISSTATEREPORT = "ChannelID_SPMonitoringRequestEntity_Alias.IsStateReport";
		public const string PROPERTY_CHANNELID_STATEREPORTTYPE = "ChannelID_SPMonitoringRequestEntity_Alias.StateReportType";
		public const string PROPERTY_CHANNELID_REPORTOKMESSAGE = "ChannelID_SPMonitoringRequestEntity_Alias.ReportOkMessage";
		public const string PROPERTY_CHANNELID_REPORTFAILEDMESSAGE = "ChannelID_SPMonitoringRequestEntity_Alias.ReportFailedMessage";
		public const string PROPERTY_CHANNELID_STATEREPORTPARAMNAME = "ChannelID_SPMonitoringRequestEntity_Alias.StateReportParamName";
		public const string PROPERTY_CHANNELID_STATEREPORTPARAMVALUE = "ChannelID_SPMonitoringRequestEntity_Alias.StateReportParamValue";
		public const string PROPERTY_CHANNELID_REQUESTTYPEPARAMNAME = "ChannelID_SPMonitoringRequestEntity_Alias.RequestTypeParamName";
		public const string PROPERTY_CHANNELID_REQUESTTYPEPARAMSTATEREPORTVALUE = "ChannelID_SPMonitoringRequestEntity_Alias.RequestTypeParamStateReportValue";
		public const string PROPERTY_CHANNELID_REQUESTTYPEPARAMDATAREPORTVALUE = "ChannelID_SPMonitoringRequestEntity_Alias.RequestTypeParamDataReportValue";
		public const string PROPERTY_CHANNELID_HASFILTERS = "ChannelID_SPMonitoringRequestEntity_Alias.HasFilters";
		public const string PROPERTY_CHANNELID_ISMONITORREQUEST = "ChannelID_SPMonitoringRequestEntity_Alias.IsMonitorRequest";
		public const string PROPERTY_CHANNELID_ISLOGREQUEST = "ChannelID_SPMonitoringRequestEntity_Alias.IsLogRequest";
		public const string PROPERTY_CHANNELID_ISPARAMSCONVERT = "ChannelID_SPMonitoringRequestEntity_Alias.IsParamsConvert";
		public const string PROPERTY_CHANNELID_ISAUTOLINKID = "ChannelID_SPMonitoringRequestEntity_Alias.IsAutoLinkID";
		public const string PROPERTY_CHANNELID_AUTOLINKIDFIELDS = "ChannelID_SPMonitoringRequestEntity_Alias.AutoLinkIDFields";
		public const string PROPERTY_CHANNELID_LOGREQUESTTYPE = "ChannelID_SPMonitoringRequestEntity_Alias.LogRequestType";
		public const string PROPERTY_CHANNELID_PRICE = "ChannelID_SPMonitoringRequestEntity_Alias.Price";
		public const string PROPERTY_CHANNELID_DEFAULTRATE = "ChannelID_SPMonitoringRequestEntity_Alias.DefaultRate";
		public const string PROPERTY_CHANNELID_CHANNELDETAILINFO = "ChannelID_SPMonitoringRequestEntity_Alias.ChannelDetailInfo";
		public const string PROPERTY_CHANNELID_UPPERID = "ChannelID_SPMonitoringRequestEntity_Alias.UpperID";
		public const string PROPERTY_CHANNELID_CHANNELSTATUS = "ChannelID_SPMonitoringRequestEntity_Alias.ChannelStatus";
		public const string PROPERTY_CHANNELID_ISDISABLE = "ChannelID_SPMonitoringRequestEntity_Alias.IsDisable";
		public const string PROPERTY_CHANNELID_CREATEBY = "ChannelID_SPMonitoringRequestEntity_Alias.CreateBy";
		public const string PROPERTY_CHANNELID_CREATEAT = "ChannelID_SPMonitoringRequestEntity_Alias.CreateAt";
		public const string PROPERTY_CHANNELID_LASTMODIFYBY = "ChannelID_SPMonitoringRequestEntity_Alias.LastModifyBy";
		public const string PROPERTY_CHANNELID_LASTMODIFYAT = "ChannelID_SPMonitoringRequestEntity_Alias.LastModifyAt";
		public const string PROPERTY_CHANNELID_LASTMODIFYCOMMENT = "ChannelID_SPMonitoringRequestEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _id;
		private string _recievedContent;
		private DateTime? _recievedDate;
		private string _recievedIP;
		private string _recievedSendUrl;
		private SPChannelEntity _channelID;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPMonitoringRequestEntity()
		{
			_id = 0;
			_recievedContent = null;
			_recievedDate = null;
			_recievedIP = null;
			_recievedSendUrl = null;
			_channelID = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SPMonitoringRequestEntity( int id, string recievedContent, DateTime? recievedDate, string recievedIP, string recievedSendUrl, SPChannelEntity channelID)
		{
			_id = id;
			_recievedContent = recievedContent;
			_recievedDate = recievedDate;
			_recievedIP = recievedIP;
			_recievedSendUrl = recievedSendUrl;
			_channelID = channelID;
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
		public virtual string RecievedContent
		{
			get { return _recievedContent; }

			set	
			{

				if( value != null && value.Length > 2147483646)
					throw new ArgumentOutOfRangeException("Invalid value for RecievedContent", value, value.ToString());
				_isChanged |= (_recievedContent != value); _recievedContent = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? RecievedDate
		{
			get { return _recievedDate; }

			set	
			{
				_isChanged |= (_recievedDate != value); _recievedDate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string RecievedIP
		{
			get { return _recievedIP; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for RecievedIP", value, value.ToString());
				_isChanged |= (_recievedIP != value); _recievedIP = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string RecievedSendUrl
		{
			get { return _recievedSendUrl; }

			set	
			{

				if( value != null && value.Length > 1000)
					throw new ArgumentOutOfRangeException("Invalid value for RecievedSendUrl", value, value.ToString());
				_isChanged |= (_recievedSendUrl != value); _recievedSendUrl = value;
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
	

		#endregion 

        

		#region Equals 和 HashCode 方法覆盖
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			 return this.CheckEquals(obj as SPMonitoringRequestEntity);
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