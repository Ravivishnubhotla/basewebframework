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
	public class SPRateDataContract
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Bussiness.DataContracts.Tables.SPRateDataContract";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		public static readonly string PROPERTY_NAME_CLINETID = "ClinetID";
		public static readonly string PROPERTY_NAME_INTERCEPTRATE = "InterceptRate";
		public static readonly string PROPERTY_NAME_UPRATE = "UpRate";
		public static readonly string PROPERTY_NAME_DOWNRATE = "DownRate";
		
        #endregion
	
        #region 私有成员变量
		
		private int _id;
		private int? _channelID;
		private int? _clinetID;
		private int? _interceptRate;
		private int? _upRate;
		private int? _downRate;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPRateDataContract()
		{
			_id = 0;
			_channelID = null;
			_clinetID = null;
			_interceptRate = null;
			_upRate = null;
			_downRate = null;
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
		public int? ClinetID
		{
			get { return _clinetID; }

			set	
			{
				_clinetID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? InterceptRate
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
		public int? UpRate
		{
			get { return _upRate; }

			set	
			{
				_upRate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? DownRate
		{
			get { return _downRate; }

			set	
			{
				_downRate = value;
			}
		}

		
		#endregion 


        public void FromWrapper(SPRateWrapper wrapper)
		{
			this.Id = wrapper.Id;
			this.ChannelID = wrapper.ChannelID;
			this.ClinetID = wrapper.ClinetID;
			this.InterceptRate = wrapper.InterceptRate;
			this.UpRate = wrapper.UpRate;
			this.DownRate = wrapper.DownRate;
		}
		
		
		public SPRateWrapper ToWrapper()
        {
			SPRateWrapper wrapper = new SPRateWrapper();
			wrapper.Id = this.Id;
			wrapper.ChannelID = this.ChannelID;
			wrapper.ClinetID = this.ClinetID;
			wrapper.InterceptRate = this.InterceptRate;
			wrapper.UpRate = this.UpRate;
			wrapper.DownRate = this.DownRate;
		
		return wrapper;
        }



   }
}
