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
		public static readonly string PROPERTY_NAME_IP = "Ip";
		public static readonly string PROPERTY_NAME_SUCESSSTOSEND = "SucesssToSend";
		
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
		private string _ip;
		private bool? _sucesssToSend;
		
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
			_ip = null;
			_sucesssToSend = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SPPaymentInfoEntity( int id, string mobileNumber, SPChannelEntity channelID, SPClientEntity clientID, string message, bool? isIntercept, DateTime? createDate, int? requestID, string cpid, string mid, string port, string ywid, string ip, bool? sucesssToSend)
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
			_ip = ip;
			_sucesssToSend = sucesssToSend;
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