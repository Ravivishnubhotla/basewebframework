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
	public class SPClientChannelSettingDataContract
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Bussiness.DataContracts.Tables.SPClientChannelSettingDataContract";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		public static readonly string PROPERTY_NAME_CLINETID = "ClinetID";
		public static readonly string PROPERTY_NAME_INTERCEPTRATE = "InterceptRate";
		public static readonly string PROPERTY_NAME_UPRATE = "UpRate";
		public static readonly string PROPERTY_NAME_DOWNRATE = "DownRate";
		public static readonly string PROPERTY_NAME_COMMANDTYPE = "CommandType";
		public static readonly string PROPERTY_NAME_COMMANDCODE = "CommandCode";
		public static readonly string PROPERTY_NAME_DISABLE = "Disable";
		public static readonly string PROPERTY_NAME_COMMANDCOLUMN = "CommandColumn";
		public static readonly string PROPERTY_NAME_INTERCEPTRATETYPE = "InterceptRateType";
		
        #endregion
	
        #region 私有成员变量
		
		private int _id;
		private int? _channelID;
		private int? _clinetID;
		private int? _interceptRate;
		private int? _upRate;
		private int? _downRate;
		private string _commandType;
		private string _commandCode;
		private bool? _disable;
		private string _commandColumn;
		private string _interceptRateType;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPClientChannelSettingDataContract()
		{
			_id = 0;
			_channelID = null;
			_clinetID = null;
			_interceptRate = null;
			_upRate = null;
			_downRate = null;
			_commandType = null;
			_commandCode = null;
			_disable = null;
			_commandColumn = null;
			_interceptRateType = null;
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

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string CommandType
		{
			get { return _commandType; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for CommandType", value, value.ToString());
				_commandType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string CommandCode
		{
			get { return _commandCode; }

			set	
			{

				if( value != null && value.Length > 1600)
					throw new ArgumentOutOfRangeException("Invalid value for CommandCode", value, value.ToString());
				_commandCode = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool? Disable
		{
			get { return _disable; }

			set	
			{
				_disable = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string CommandColumn
		{
			get { return _commandColumn; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for CommandColumn", value, value.ToString());
				_commandColumn = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string InterceptRateType
		{
			get { return _interceptRateType; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for InterceptRateType", value, value.ToString());
				_interceptRateType = value;
			}
		}

		
		#endregion 


        public void FromWrapper(SPClientChannelSettingWrapper wrapper)
		{
			this.Id = wrapper.Id;
			this.ChannelID = (wrapper.ChannelID!=null) ? wrapper.ChannelID.Id : 0 ; 
			this.ClinetID = (wrapper.ClinetID!=null) ? wrapper.ClinetID.Id : 0 ; 
			this.InterceptRate = wrapper.InterceptRate;
			this.UpRate = wrapper.UpRate;
			this.DownRate = wrapper.DownRate;
			this.CommandType = wrapper.CommandType;
			this.CommandCode = wrapper.CommandCode;
			this.Disable = wrapper.Disable;
			this.CommandColumn = wrapper.CommandColumn;
			this.InterceptRateType = wrapper.InterceptRateType;
		}
		
		
		public SPClientChannelSettingWrapper ToWrapper()
        {
			SPClientChannelSettingWrapper wrapper = new SPClientChannelSettingWrapper();
			wrapper.Id = this.Id;
			wrapper.ChannelID =  (this.ChannelID==null) ? null : SPChannelWrapper.FindById(this.ChannelID);
			wrapper.ClinetID =  (this.ClinetID==null) ? null : SPClientWrapper.FindById(this.ClinetID);
			wrapper.InterceptRate = this.InterceptRate;
			wrapper.UpRate = this.UpRate;
			wrapper.DownRate = this.DownRate;
			wrapper.CommandType = this.CommandType;
			wrapper.CommandCode = this.CommandCode;
			wrapper.Disable = this.Disable;
			wrapper.CommandColumn = this.CommandColumn;
			wrapper.InterceptRateType = this.InterceptRateType;
		
		return wrapper;
        }



   }
}
