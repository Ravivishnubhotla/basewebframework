// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LD.SPPipeManage.Entity.Tables
{
	/// <summary>
	///	
	/// </summary>
	[DataContract]
	public partial class SPPaymentInfoEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Entity.Tables.SPPaymentInfoEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_MOBILENUMBER = "MobileNumber";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		public static readonly string PROPERTY_NAME_CLIENTID = "ClientID";
		public static readonly string PROPERTY_NAME_MESSAGE = "Message";
		public static readonly string PROPERTY_NAME_ISINTERCEPT = "IsIntercept";
		public static readonly string PROPERTY_NAME_CREATEDATE = "CreateDate";
		public static readonly string PROPERTY_NAME_REQUESTID = "RequestID";
		public static readonly string PROPERTY_NAME_CPID = "Cpid";
		public static readonly string PROPERTY_NAME_MID = "Mid";
		public static readonly string PROPERTY_NAME_PORT = "Port";
		public static readonly string PROPERTY_NAME_YWID = "Ywid";
		public static readonly string PROPERTY_NAME_LINKID = "Linkid";
		public static readonly string PROPERTY_NAME_DEST = "Dest";
		public static readonly string PROPERTY_NAME_PRICE = "Price";
		public static readonly string PROPERTY_NAME_IP = "Ip";
		public static readonly string PROPERTY_NAME_SUCESSSTOSEND = "SucesssToSend";
		public static readonly string PROPERTY_NAME_EXTENDFIELD1 = "ExtendField1";
		public static readonly string PROPERTY_NAME_EXTENDFIELD2 = "ExtendField2";
		public static readonly string PROPERTY_NAME_EXTENDFIELD3 = "ExtendField3";
		public static readonly string PROPERTY_NAME_EXTENDFIELD4 = "ExtendField4";
		public static readonly string PROPERTY_NAME_EXTENDFIELD5 = "ExtendField5";
		public static readonly string PROPERTY_NAME_EXTENDFIELD6 = "ExtendField6";
		public static readonly string PROPERTY_NAME_EXTENDFIELD7 = "ExtendField7";
		public static readonly string PROPERTY_NAME_EXTENDFIELD8 = "ExtendField8";
		public static readonly string PROPERTY_NAME_EXTENDFIELD9 = "ExtendField9";
		public static readonly string PROPERTY_NAME_ISREPORT = "IsReport";
		public static readonly string PROPERTY_NAME_REQUESTCONTENT = "RequestContent";
		public static readonly string PROPERTY_NAME_CITY = "City";
		public static readonly string PROPERTY_NAME_PROVINCE = "Province";
		public static readonly string PROPERTY_NAME_ISTESTDATA = "IsTestData";
		public static readonly string PROPERTY_NAME_CHANNLECLIENTID = "ChannleClientID";
		public static readonly string PROPERTY_NAME_ISSYCNDATA = "IsSycnData";
		public static readonly string PROPERTY_NAME_SSYCNDATAURL = "SSycnDataUrl";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _id;
		private string _mobileNumber;
		private SPChannelEntity _channelID;
		private SPClientEntity _clientID;
		private string _message;
		private bool? _isIntercept;
		private DateTime? _createDate;
		private int? _requestID;
		private string _cpid;
		private string _mid;
		private string _port;
		private string _ywid;
		private string _linkid;
		private string _dest;
		private string _price;
		private string _ip;
		private bool? _sucesssToSend;
		private string _extendField1;
		private string _extendField2;
		private string _extendField3;
		private string _extendField4;
		private string _extendField5;
		private string _extendField6;
		private string _extendField7;
		private string _extendField8;
		private string _extendField9;
		private bool _isReport;
		private string _requestContent;
		private string _city;
		private string _province;
		private bool? _isTestData;
		private int? _channleClientID;
		private bool? _isSycnData;
		private string _sSycnDataUrl;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPPaymentInfoEntity()
		{
			_id = 0;
			_mobileNumber = null;
			_channelID = null;
			_clientID = null;
			_message = null;
			_isIntercept = null;
			_createDate = null;
			_requestID = null;
			_cpid = null;
			_mid = null;
			_port = String.Empty;
			_ywid = null;
			_linkid = null;
			_dest = null;
			_price = null;
			_ip = null;
			_sucesssToSend = null;
			_extendField1 = null;
			_extendField2 = null;
			_extendField3 = null;
			_extendField4 = null;
			_extendField5 = null;
			_extendField6 = null;
			_extendField7 = null;
			_extendField8 = null;
			_extendField9 = null;
			_isReport = false;
			_requestContent = null;
			_city = null;
			_province = null;
			_isTestData = null;
			_channleClientID = null;
			_isSycnData = null;
			_sSycnDataUrl = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SPPaymentInfoEntity( int id, string mobileNumber, SPChannelEntity channelID, SPClientEntity clientID, string message, bool? isIntercept, DateTime? createDate, int? requestID, string cpid, string mid, string port, string ywid, string linkid, string dest, string price, string ip, bool? sucesssToSend, string extendField1, string extendField2, string extendField3, string extendField4, string extendField5, string extendField6, string extendField7, string extendField8, string extendField9, bool isReport, string requestContent, string city, string province, bool? isTestData, int? channleClientID, bool? isSycnData, string sSycnDataUrl)
		{
			_id = id;
			_mobileNumber = mobileNumber;
			_channelID = channelID;
			_clientID = clientID;
			_message = message;
			_isIntercept = isIntercept;
			_createDate = createDate;
			_requestID = requestID;
			_cpid = cpid;
			_mid = mid;
			_port = port;
			_ywid = ywid;
			_linkid = linkid;
			_dest = dest;
			_price = price;
			_ip = ip;
			_sucesssToSend = sucesssToSend;
			_extendField1 = extendField1;
			_extendField2 = extendField2;
			_extendField3 = extendField3;
			_extendField4 = extendField4;
			_extendField5 = extendField5;
			_extendField6 = extendField6;
			_extendField7 = extendField7;
			_extendField8 = extendField8;
			_extendField9 = extendField9;
			_isReport = isReport;
			_requestContent = requestContent;
			_city = city;
			_province = province;
			_isTestData = isTestData;
			_channleClientID = channleClientID;
			_isSycnData = isSycnData;
			_sSycnDataUrl = sSycnDataUrl;
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
		public virtual string MobileNumber
		{
			get { return _mobileNumber; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for MobileNumber", value, value.ToString());
				_isChanged |= (_mobileNumber != value); _mobileNumber = value;
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
		public virtual SPClientEntity ClientID
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
		public virtual string Message
		{
			get { return _message; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for Message", value, value.ToString());
				_isChanged |= (_message != value); _message = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? IsIntercept
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
		public virtual DateTime? CreateDate
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
		public virtual int? RequestID
		{
			get { return _requestID; }

			set	
			{
				_isChanged |= (_requestID != value); _requestID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Cpid
		{
			get { return _cpid; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for Cpid", value, value.ToString());
				_isChanged |= (_cpid != value); _cpid = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Mid
		{
			get { return _mid; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for Mid", value, value.ToString());
				_isChanged |= (_mid != value); _mid = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Port
		{
			get { return _port; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for Port", value, value.ToString());
				_isChanged |= (_port != value); _port = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Ywid
		{
			get { return _ywid; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for Ywid", value, value.ToString());
				_isChanged |= (_ywid != value); _ywid = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Linkid
		{
			get { return _linkid; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for Linkid", value, value.ToString());
				_isChanged |= (_linkid != value); _linkid = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Dest
		{
			get { return _dest; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for Dest", value, value.ToString());
				_isChanged |= (_dest != value); _dest = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Price
		{
			get { return _price; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Price", value, value.ToString());
				_isChanged |= (_price != value); _price = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Ip
		{
			get { return _ip; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Ip", value, value.ToString());
				_isChanged |= (_ip != value); _ip = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? SucesssToSend
		{
			get { return _sucesssToSend; }

			set	
			{
				_isChanged |= (_sucesssToSend != value); _sucesssToSend = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ExtendField1
		{
			get { return _extendField1; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField1", value, value.ToString());
				_isChanged |= (_extendField1 != value); _extendField1 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ExtendField2
		{
			get { return _extendField2; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField2", value, value.ToString());
				_isChanged |= (_extendField2 != value); _extendField2 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ExtendField3
		{
			get { return _extendField3; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField3", value, value.ToString());
				_isChanged |= (_extendField3 != value); _extendField3 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ExtendField4
		{
			get { return _extendField4; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField4", value, value.ToString());
				_isChanged |= (_extendField4 != value); _extendField4 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ExtendField5
		{
			get { return _extendField5; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField5", value, value.ToString());
				_isChanged |= (_extendField5 != value); _extendField5 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ExtendField6
		{
			get { return _extendField6; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField6", value, value.ToString());
				_isChanged |= (_extendField6 != value); _extendField6 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ExtendField7
		{
			get { return _extendField7; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField7", value, value.ToString());
				_isChanged |= (_extendField7 != value); _extendField7 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ExtendField8
		{
			get { return _extendField8; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField8", value, value.ToString());
				_isChanged |= (_extendField8 != value); _extendField8 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ExtendField9
		{
			get { return _extendField9; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField9", value, value.ToString());
				_isChanged |= (_extendField9 != value); _extendField9 = value;
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
		public virtual string RequestContent
		{
			get { return _requestContent; }

			set	
			{

				if( value != null && value.Length > 2147483646)
					throw new ArgumentOutOfRangeException("Invalid value for RequestContent", value, value.ToString());
				_isChanged |= (_requestContent != value); _requestContent = value;
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

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for City", value, value.ToString());
				_isChanged |= (_city != value); _city = value;
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

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for Province", value, value.ToString());
				_isChanged |= (_province != value); _province = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? IsTestData
		{
			get { return _isTestData; }

			set	
			{
				_isChanged |= (_isTestData != value); _isTestData = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? ChannleClientID
		{
			get { return _channleClientID; }

			set	
			{
				_isChanged |= (_channleClientID != value); _channleClientID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? IsSycnData
		{
			get { return _isSycnData; }

			set	
			{
				_isChanged |= (_isSycnData != value); _isSycnData = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string SSycnDataUrl
		{
			get { return _sSycnDataUrl; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for SSycnDataUrl", value, value.ToString());
				_isChanged |= (_sSycnDataUrl != value); _sSycnDataUrl = value;
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
			
			SPPaymentInfoEntity castObj = (SPPaymentInfoEntity)obj;
			
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
