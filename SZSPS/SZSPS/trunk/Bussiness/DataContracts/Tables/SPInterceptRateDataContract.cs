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
	public class SPInterceptRateDataContract
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Bussiness.DataContracts.Tables.SPInterceptRateDataContract";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_CLIENTID = "ClientID";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		public static readonly string PROPERTY_NAME_TOTALCOUNT = "TotalCount";
		public static readonly string PROPERTY_NAME_INTERCEPTCOUNT = "InterceptCount";
		public static readonly string PROPERTY_NAME_INTERCEPTRATE = "InterceptRate";
		public static readonly string PROPERTY_NAME_LASTSYCNDATE = "LastSycnDate";
		
        #endregion
	
        #region 私有成员变量
		
		private int _id;
		private int? _clientID;
		private int? _channelID;
		private int? _totalCount;
		private int? _interceptCount;
		private decimal? _interceptRate;
		private DateTime? _lastSycnDate;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPInterceptRateDataContract()
		{
			_id = 0;
			_clientID = null;
			_channelID = null;
			_totalCount = null;
			_interceptCount = null;
			_interceptRate = null;
			_lastSycnDate = null;
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
		public int? TotalCount
		{
			get { return _totalCount; }

			set	
			{
				_totalCount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? InterceptCount
		{
			get { return _interceptCount; }

			set	
			{
				_interceptCount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public decimal? InterceptRate
		{
			get { return _interceptRate; }

			set	
			{
				_interceptRate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public DateTime? LastSycnDate
		{
			get { return _lastSycnDate; }

			set	
			{
				_lastSycnDate = value;
			}
		}

		
		#endregion 


        public void FromWrapper(SPInterceptRateWrapper wrapper)
		{
			this.Id = wrapper.Id;
			this.ClientID = wrapper.ClientID;
			this.ChannelID = wrapper.ChannelID;
			this.TotalCount = wrapper.TotalCount;
			this.InterceptCount = wrapper.InterceptCount;
			this.InterceptRate = wrapper.InterceptRate;
			this.LastSycnDate = wrapper.LastSycnDate;
		}
		
		
		public SPInterceptRateWrapper ToWrapper()
        {
			SPInterceptRateWrapper wrapper = new SPInterceptRateWrapper();
			wrapper.Id = this.Id;
			wrapper.ClientID = this.ClientID;
			wrapper.ChannelID = this.ChannelID;
			wrapper.TotalCount = this.TotalCount;
			wrapper.InterceptCount = this.InterceptCount;
			wrapper.InterceptRate = this.InterceptRate;
			wrapper.LastSycnDate = this.LastSycnDate;
		
		return wrapper;
        }



   }
}
