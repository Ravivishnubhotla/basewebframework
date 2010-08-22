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
	public partial class SPFailedRequestEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Entity.Tables.SPFailedRequestEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_RECIEVEDCONTENT = "RecievedContent";
		public static readonly string PROPERTY_NAME_RECIEVEDDATE = "RecievedDate";
		public static readonly string PROPERTY_NAME_RECIEVEDIP = "RecievedIP";
		public static readonly string PROPERTY_NAME_RECIEVEDSENDURL = "RecievedSendUrl";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		public static readonly string PROPERTY_NAME_CLIENTID = "ClientID";
		public static readonly string PROPERTY_NAME_FAILEDMESSAGE = "FailedMessage";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _id;
		private string _recievedContent;
		private DateTime? _recievedDate;
		private string _recievedIP;
		private string _recievedSendUrl;
		private int? _channelID;
		private int? _clientID;
		private string _failedMessage;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPFailedRequestEntity()
		{
			_id = 0;
			_recievedContent = null;
			_recievedDate = null;
			_recievedIP = null;
			_recievedSendUrl = null;
			_channelID = null;
			_clientID = null;
			_failedMessage = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SPFailedRequestEntity( int id, string recievedContent, DateTime? recievedDate, string recievedIP, string recievedSendUrl, int? channelID, int? clientID, string failedMessage)
		{
			_id = id;
			_recievedContent = recievedContent;
			_recievedDate = recievedDate;
			_recievedIP = recievedIP;
			_recievedSendUrl = recievedSendUrl;
			_channelID = channelID;
			_clientID = clientID;
			_failedMessage = failedMessage;
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

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for RecievedSendUrl", value, value.ToString());
				_isChanged |= (_recievedSendUrl != value); _recievedSendUrl = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? ChannelID
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
		public virtual int? ClientID
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
		public virtual string FailedMessage
		{
			get { return _failedMessage; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for FailedMessage", value, value.ToString());
				_isChanged |= (_failedMessage != value); _failedMessage = value;
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
			
			SPFailedRequestEntity castObj = (SPFailedRequestEntity)obj;
			
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
