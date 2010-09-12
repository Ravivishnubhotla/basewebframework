using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace LD.SPPipeManage.Bussiness.DataContracts.Tables
{
	/// <summary>
	///	
	/// </summary>
	[DataContract]
	public class SPPaymentInfoDataContract
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Bussiness.DataContracts.Tables.SPPaymentInfoDataContract";
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
		
		private int _id;
		private string _mobileNumber;
		private int? _channelID;
		private int? _clientID;
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
		public SPPaymentInfoDataContract()
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

	    #region 公共属性

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int Id
		{
			get { return _id; }

			set	
			{
				_id = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string MobileNumber
		{
			get { return _mobileNumber; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for MobileNumber", value, value.ToString());
				_mobileNumber = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? ChannelID
		{
			get { return _channelID; }

			set	
			{
				_channelID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? ClientID
		{
			get { return _clientID; }

			set	
			{
				_clientID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Message
		{
			get { return _message; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for Message", value, value.ToString());
				_message = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool? IsIntercept
		{
			get { return _isIntercept; }

			set	
			{
				_isIntercept = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public DateTime? CreateDate
		{
			get { return _createDate; }

			set	
			{
				_createDate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? RequestID
		{
			get { return _requestID; }

			set	
			{
				_requestID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Cpid
		{
			get { return _cpid; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for Cpid", value, value.ToString());
				_cpid = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Mid
		{
			get { return _mid; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for Mid", value, value.ToString());
				_mid = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Port
		{
			get { return _port; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for Port", value, value.ToString());
				_port = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Ywid
		{
			get { return _ywid; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for Ywid", value, value.ToString());
				_ywid = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Linkid
		{
			get { return _linkid; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for Linkid", value, value.ToString());
				_linkid = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Dest
		{
			get { return _dest; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for Dest", value, value.ToString());
				_dest = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Price
		{
			get { return _price; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Price", value, value.ToString());
				_price = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Ip
		{
			get { return _ip; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Ip", value, value.ToString());
				_ip = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool? SucesssToSend
		{
			get { return _sucesssToSend; }

			set	
			{
				_sucesssToSend = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string ExtendField1
		{
			get { return _extendField1; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField1", value, value.ToString());
				_extendField1 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string ExtendField2
		{
			get { return _extendField2; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField2", value, value.ToString());
				_extendField2 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string ExtendField3
		{
			get { return _extendField3; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField3", value, value.ToString());
				_extendField3 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string ExtendField4
		{
			get { return _extendField4; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField4", value, value.ToString());
				_extendField4 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string ExtendField5
		{
			get { return _extendField5; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField5", value, value.ToString());
				_extendField5 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string ExtendField6
		{
			get { return _extendField6; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField6", value, value.ToString());
				_extendField6 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string ExtendField7
		{
			get { return _extendField7; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField7", value, value.ToString());
				_extendField7 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string ExtendField8
		{
			get { return _extendField8; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField8", value, value.ToString());
				_extendField8 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string ExtendField9
		{
			get { return _extendField9; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField9", value, value.ToString());
				_extendField9 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool IsReport
		{
			get { return _isReport; }

			set	
			{
				_isReport = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string RequestContent
		{
			get { return _requestContent; }

			set	
			{

				if( value != null && value.Length > 2147483646)
					throw new ArgumentOutOfRangeException("Invalid value for RequestContent", value, value.ToString());
				_requestContent = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string City
		{
			get { return _city; }

			set	
			{

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for City", value, value.ToString());
				_city = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Province
		{
			get { return _province; }

			set	
			{

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for Province", value, value.ToString());
				_province = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool? IsTestData
		{
			get { return _isTestData; }

			set	
			{
				_isTestData = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? ChannleClientID
		{
			get { return _channleClientID; }

			set	
			{
				_channleClientID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool? IsSycnData
		{
			get { return _isSycnData; }

			set	
			{
				_isSycnData = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string SSycnDataUrl
		{
			get { return _sSycnDataUrl; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for SSycnDataUrl", value, value.ToString());
				_sSycnDataUrl = value;
			}
		}

		
		#endregion 


        public void FromWrapper(SPPaymentInfoWrapper wrapper)
		{
			this.Id = wrapper.Id;
			this.MobileNumber = wrapper.MobileNumber;
			this.ChannelID = (wrapper.ChannelID!=null) ? wrapper.ChannelID.Id : 0 ; 
			this.ClientID = (wrapper.ClientID!=null) ? wrapper.ClientID.Id : 0 ; 
			this.Message = wrapper.Message;
			this.IsIntercept = wrapper.IsIntercept;
			this.CreateDate = wrapper.CreateDate;
			this.RequestID = wrapper.RequestID;
			this.Cpid = wrapper.Cpid;
			this.Mid = wrapper.Mid;
			this.Port = wrapper.Port;
			this.Ywid = wrapper.Ywid;
			this.Linkid = wrapper.Linkid;
			this.Dest = wrapper.Dest;
			this.Price = wrapper.Price;
			this.Ip = wrapper.Ip;
			this.SucesssToSend = wrapper.SucesssToSend;
			this.ExtendField1 = wrapper.ExtendField1;
			this.ExtendField2 = wrapper.ExtendField2;
			this.ExtendField3 = wrapper.ExtendField3;
			this.ExtendField4 = wrapper.ExtendField4;
			this.ExtendField5 = wrapper.ExtendField5;
			this.ExtendField6 = wrapper.ExtendField6;
			this.ExtendField7 = wrapper.ExtendField7;
			this.ExtendField8 = wrapper.ExtendField8;
			this.ExtendField9 = wrapper.ExtendField9;
			this.IsReport = wrapper.IsReport;
			this.RequestContent = wrapper.RequestContent;
			this.City = wrapper.City;
			this.Province = wrapper.Province;
			this.IsTestData = wrapper.IsTestData;
			this.ChannleClientID = wrapper.ChannleClientID;
			this.IsSycnData = wrapper.IsSycnData;
			this.SSycnDataUrl = wrapper.SSycnDataUrl;
		}
		
		
		public SPPaymentInfoWrapper ToWrapper()
        {
			SPPaymentInfoWrapper wrapper = new SPPaymentInfoWrapper();
			wrapper.Id = this.Id;
			wrapper.MobileNumber = this.MobileNumber;
			wrapper.ChannelID =  (this.ChannelID==null) ? null : SPChannelWrapper.FindById(this.ChannelID);
			wrapper.ClientID =  (this.ClientID==null) ? null : SPClientWrapper.FindById(this.ClientID);
			wrapper.Message = this.Message;
			wrapper.IsIntercept = this.IsIntercept;
			wrapper.CreateDate = this.CreateDate;
			wrapper.RequestID = this.RequestID;
			wrapper.Cpid = this.Cpid;
			wrapper.Mid = this.Mid;
			wrapper.Port = this.Port;
			wrapper.Ywid = this.Ywid;
			wrapper.Linkid = this.Linkid;
			wrapper.Dest = this.Dest;
			wrapper.Price = this.Price;
			wrapper.Ip = this.Ip;
			wrapper.SucesssToSend = this.SucesssToSend;
			wrapper.ExtendField1 = this.ExtendField1;
			wrapper.ExtendField2 = this.ExtendField2;
			wrapper.ExtendField3 = this.ExtendField3;
			wrapper.ExtendField4 = this.ExtendField4;
			wrapper.ExtendField5 = this.ExtendField5;
			wrapper.ExtendField6 = this.ExtendField6;
			wrapper.ExtendField7 = this.ExtendField7;
			wrapper.ExtendField8 = this.ExtendField8;
			wrapper.ExtendField9 = this.ExtendField9;
			wrapper.IsReport = this.IsReport;
			wrapper.RequestContent = this.RequestContent;
			wrapper.City = this.City;
			wrapper.Province = this.Province;
			wrapper.IsTestData = this.IsTestData;
			wrapper.ChannleClientID = this.ChannleClientID;
			wrapper.IsSycnData = this.IsSycnData;
			wrapper.SSycnDataUrl = this.SSycnDataUrl;
		
		return wrapper;
        }



   }
}
