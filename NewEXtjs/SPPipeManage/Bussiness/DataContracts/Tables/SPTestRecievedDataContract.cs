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
	public class SPTestRecievedDataContract
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Bussiness.DataContracts.Tables.SPTestRecievedDataContract";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_RECIEVEDCONTENT = "RecievedContent";
		public static readonly string PROPERTY_NAME_RECIEVEDDATE = "RecievedDate";
		public static readonly string PROPERTY_NAME_RECIEVEDIP = "RecievedIP";
		public static readonly string PROPERTY_NAME_RECIEVEDSENDURL = "RecievedSendUrl";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		public static readonly string PROPERTY_NAME_CLIENTID = "ClientID";
		
        #endregion
	
        #region 私有成员变量
		
		private int _id;
		private string _recievedContent;
		private DateTime? _recievedDate;
		private string _recievedIP;
		private string _recievedSendUrl;
		private int? _channelID;
		private int? _clientID;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPTestRecievedDataContract()
		{
			_id = 0;
			_recievedContent = null;
			_recievedDate = null;
			_recievedIP = null;
			_recievedSendUrl = null;
			_channelID = null;
			_clientID = null;
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
		public string RecievedContent
		{
			get { return _recievedContent; }

			set	
			{

				if( value != null && value.Length > 2147483646)
					throw new ArgumentOutOfRangeException("Invalid value for RecievedContent", value, value.ToString());
				_recievedContent = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public DateTime? RecievedDate
		{
			get { return _recievedDate; }

			set	
			{
				_recievedDate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string RecievedIP
		{
			get { return _recievedIP; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for RecievedIP", value, value.ToString());
				_recievedIP = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string RecievedSendUrl
		{
			get { return _recievedSendUrl; }

			set	
			{

				if( value != null && value.Length > 1000)
					throw new ArgumentOutOfRangeException("Invalid value for RecievedSendUrl", value, value.ToString());
				_recievedSendUrl = value;
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

		
		#endregion 


        public void FromWrapper(SPTestRecievedWrapper wrapper)
		{
			this.Id = wrapper.Id;
			this.RecievedContent = wrapper.RecievedContent;
			this.RecievedDate = wrapper.RecievedDate;
			this.RecievedIP = wrapper.RecievedIP;
			this.RecievedSendUrl = wrapper.RecievedSendUrl;
			this.ChannelID = wrapper.ChannelID;
			this.ClientID = wrapper.ClientID;
		}
		
		
		public SPTestRecievedWrapper ToWrapper()
        {
			SPTestRecievedWrapper wrapper = new SPTestRecievedWrapper();
			wrapper.Id = this.Id;
			wrapper.RecievedContent = this.RecievedContent;
			wrapper.RecievedDate = this.RecievedDate;
			wrapper.RecievedIP = this.RecievedIP;
			wrapper.RecievedSendUrl = this.RecievedSendUrl;
			wrapper.ChannelID = this.ChannelID;
			wrapper.ClientID = this.ClientID;
		
		return wrapper;
        }



   }
}
