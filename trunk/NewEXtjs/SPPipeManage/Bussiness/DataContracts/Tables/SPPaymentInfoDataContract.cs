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

		
		#endregion 


        public void FromWrapper(SPPaymentInfoWrapper wrapper)
		{
			this.Id = wrapper.Id;
			this.MobileNumber = wrapper.MobileNumber;
			this.ChannelID = wrapper.ChannelID;
			this.ClientID = wrapper.ClientID;
			this.Message = wrapper.Message;
			this.IsIntercept = wrapper.IsIntercept;
			this.CreateDate = wrapper.CreateDate;
			this.RequestID = wrapper.RequestID;
		}
		
		
		public SPPaymentInfoWrapper ToWrapper()
        {
			SPPaymentInfoWrapper wrapper = new SPPaymentInfoWrapper();
			wrapper.Id = this.Id;
			wrapper.MobileNumber = this.MobileNumber;
			wrapper.ChannelID = this.ChannelID;
			wrapper.ClientID = this.ClientID;
			wrapper.Message = this.Message;
			wrapper.IsIntercept = this.IsIntercept;
			wrapper.CreateDate = this.CreateDate;
			wrapper.RequestID = this.RequestID;
		
		return wrapper;
        }



   }
}
