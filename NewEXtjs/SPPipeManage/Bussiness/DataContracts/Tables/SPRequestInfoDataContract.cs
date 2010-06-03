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
	public class SPRequestInfoDataContract
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Bussiness.DataContracts.Tables.SPRequestInfoDataContract";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_IP = "Ip";
		public static readonly string PROPERTY_NAME_REQUESTINFO = "RequestInfo";
		public static readonly string PROPERTY_NAME_REQUESTDATE = "RequestDate";
		public static readonly string PROPERTY_NAME_ISTOPAYMENT = "IsToPayment";
		public static readonly string PROPERTY_NAME_REQUESTURL = "RequestUrl";
		public static readonly string PROPERTY_NAME_DATAID = "DataID";
		
        #endregion
	
        #region 私有成员变量
		
		private int _id;
		private string _ip;
		private string _requestInfo;
		private DateTime? _requestDate;
		private bool? _isToPayment;
		private string _requestUrl;
		private int? _dataID;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPRequestInfoDataContract()
		{
			_id = 0;
			_ip = null;
			_requestInfo = null;
			_requestDate = null;
			_isToPayment = null;
			_requestUrl = null;
			_dataID = null;
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
		public string Ip
		{
			get { return _ip; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Ip", value, value.ToString());
				_ip = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string RequestInfo
		{
			get { return _requestInfo; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for RequestInfo", value, value.ToString());
				_requestInfo = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public DateTime? RequestDate
		{
			get { return _requestDate; }

			set	
			{
				_requestDate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool? IsToPayment
		{
			get { return _isToPayment; }

			set	
			{
				_isToPayment = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string RequestUrl
		{
			get { return _requestUrl; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for RequestUrl", value, value.ToString());
				_requestUrl = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? DataID
		{
			get { return _dataID; }

			set	
			{
				_dataID = value;
			}
		}

		
		#endregion 


        public void FromWrapper(SPRequestInfoWrapper wrapper)
		{
			this.Id = wrapper.Id;
			this.Ip = wrapper.Ip;
			this.RequestInfo = wrapper.RequestInfo;
			this.RequestDate = wrapper.RequestDate;
			this.IsToPayment = wrapper.IsToPayment;
			this.RequestUrl = wrapper.RequestUrl;
			this.DataID = wrapper.DataID;
		}
		
		
		public SPRequestInfoWrapper ToWrapper()
        {
			SPRequestInfoWrapper wrapper = new SPRequestInfoWrapper();
			wrapper.Id = this.Id;
			wrapper.Ip = this.Ip;
			wrapper.RequestInfo = this.RequestInfo;
			wrapper.RequestDate = this.RequestDate;
			wrapper.IsToPayment = this.IsToPayment;
			wrapper.RequestUrl = this.RequestUrl;
			wrapper.DataID = this.DataID;
		
		return wrapper;
        }



   }
}
