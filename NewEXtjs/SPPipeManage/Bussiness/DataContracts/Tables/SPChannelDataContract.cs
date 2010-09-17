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
	public class SPChannelDataContract
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Bussiness.DataContracts.Tables.SPChannelDataContract";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_AREA = "Area";
		public static readonly string PROPERTY_NAME_OPERATOR = "Operator";
		public static readonly string PROPERTY_NAME_CHANNELCODE = "ChannelCode";
		public static readonly string PROPERTY_NAME_FUZZYCOMMAND = "FuzzyCommand";
		public static readonly string PROPERTY_NAME_ACCURATECOMMAND = "AccurateCommand";
		public static readonly string PROPERTY_NAME_PORT = "Port";
		public static readonly string PROPERTY_NAME_CHANNELTYPE = "ChannelType";
		public static readonly string PROPERTY_NAME_PRICE = "Price";
		public static readonly string PROPERTY_NAME_RATE = "Rate";
		public static readonly string PROPERTY_NAME_STATUS = "Status";
		public static readonly string PROPERTY_NAME_CREATETIME = "CreateTime";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_OKMESSAGE = "OkMessage";
		public static readonly string PROPERTY_NAME_FAILEDMESSAGE = "FailedMessage";
		public static readonly string PROPERTY_NAME_UPERID = "UperID";
		public static readonly string PROPERTY_NAME_CHANNELCODEPARAMSNAME = "ChannelCodeParamsName";
		public static readonly string PROPERTY_NAME_ISALLOWNULLLINKID = "IsAllowNullLinkID";
		public static readonly string PROPERTY_NAME_RECSTATREPORT = "RecStatReport";
		public static readonly string PROPERTY_NAME_STATPARAMSNAME = "StatParamsName";
		public static readonly string PROPERTY_NAME_STATPARAMSVALUES = "StatParamsValues";
		
        #endregion
	
        #region 私有成员变量
		
		private int _id;
		private string _name;
		private string _description;
		private string _area;
		private string _operator;
		private string _channelCode;
		private string _fuzzyCommand;
		private string _accurateCommand;
		private string _port;
		private string _channelType;
		private decimal? _price;
		private int? _rate;
		private int? _status;
		private DateTime? _createTime;
		private int? _createBy;
		private string _okMessage;
		private string _failedMessage;
		private int? _uperID;
		private string _channelCodeParamsName;
		private bool? _isAllowNullLinkID;
		private bool? _recStatReport;
		private string _statParamsName;
		private string _statParamsValues;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPChannelDataContract()
		{
			_id = 0;
			_name = null;
			_description = null;
			_area = null;
			_operator = null;
			_channelCode = null;
			_fuzzyCommand = null;
			_accurateCommand = null;
			_port = null;
			_channelType = null;
			_price = null;
			_rate = null;
			_status = null;
			_createTime = null;
			_createBy = null;
			_okMessage = null;
			_failedMessage = null;
			_uperID = null;
			_channelCodeParamsName = null;
			_isAllowNullLinkID = null;
			_recStatReport = null;
			_statParamsName = null;
			_statParamsValues = null;
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
		public string Name
		{
			get { return _name; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
				_name = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Description
		{
			get { return _description; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
				_description = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Area
		{
			get { return _area; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for Area", value, value.ToString());
				_area = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Operator
		{
			get { return _operator; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Operator", value, value.ToString());
				_operator = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string ChannelCode
		{
			get { return _channelCode; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ChannelCode", value, value.ToString());
				_channelCode = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string FuzzyCommand
		{
			get { return _fuzzyCommand; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for FuzzyCommand", value, value.ToString());
				_fuzzyCommand = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string AccurateCommand
		{
			get { return _accurateCommand; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for AccurateCommand", value, value.ToString());
				_accurateCommand = value;
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

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Port", value, value.ToString());
				_port = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string ChannelType
		{
			get { return _channelType; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ChannelType", value, value.ToString());
				_channelType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public decimal? Price
		{
			get { return _price; }

			set	
			{
				_price = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? Rate
		{
			get { return _rate; }

			set	
			{
				_rate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? Status
		{
			get { return _status; }

			set	
			{
				_status = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public DateTime? CreateTime
		{
			get { return _createTime; }

			set	
			{
				_createTime = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? CreateBy
		{
			get { return _createBy; }

			set	
			{
				_createBy = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string OkMessage
		{
			get { return _okMessage; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for OkMessage", value, value.ToString());
				_okMessage = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string FailedMessage
		{
			get { return _failedMessage; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for FailedMessage", value, value.ToString());
				_failedMessage = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? UperID
		{
			get { return _uperID; }

			set	
			{
				_uperID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string ChannelCodeParamsName
		{
			get { return _channelCodeParamsName; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ChannelCodeParamsName", value, value.ToString());
				_channelCodeParamsName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool? IsAllowNullLinkID
		{
			get { return _isAllowNullLinkID; }

			set	
			{
				_isAllowNullLinkID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool? RecStatReport
		{
			get { return _recStatReport; }

			set	
			{
				_recStatReport = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string StatParamsName
		{
			get { return _statParamsName; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for StatParamsName", value, value.ToString());
				_statParamsName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string StatParamsValues
		{
			get { return _statParamsValues; }

			set	
			{

				if( value != null && value.Length > 1000)
					throw new ArgumentOutOfRangeException("Invalid value for StatParamsValues", value, value.ToString());
				_statParamsValues = value;
			}
		}

		
		#endregion 


        public void FromWrapper(SPChannelWrapper wrapper)
		{
			this.Id = wrapper.Id;
			this.Name = wrapper.Name;
			this.Description = wrapper.Description;
			this.Area = wrapper.Area;
			this.Operator = wrapper.Operator;
			this.ChannelCode = wrapper.ChannelCode;
			this.FuzzyCommand = wrapper.FuzzyCommand;
			this.AccurateCommand = wrapper.AccurateCommand;
			this.Port = wrapper.Port;
			this.ChannelType = wrapper.ChannelType;
			this.Price = wrapper.Price;
			this.Rate = wrapper.Rate;
			this.Status = wrapper.Status;
			this.CreateTime = wrapper.CreateTime;
			this.CreateBy = wrapper.CreateBy;
			this.OkMessage = wrapper.OkMessage;
			this.FailedMessage = wrapper.FailedMessage;
			this.UperID = (wrapper.UperID!=null) ? wrapper.UperID.Id : 0 ; 
			this.ChannelCodeParamsName = wrapper.ChannelCodeParamsName;
			this.IsAllowNullLinkID = wrapper.IsAllowNullLinkID;
			this.RecStatReport = wrapper.RecStatReport;
			this.StatParamsName = wrapper.StatParamsName;
			this.StatParamsValues = wrapper.StatParamsValues;
		}
		
		
		public SPChannelWrapper ToWrapper()
        {
			SPChannelWrapper wrapper = new SPChannelWrapper();
			wrapper.Id = this.Id;
			wrapper.Name = this.Name;
			wrapper.Description = this.Description;
			wrapper.Area = this.Area;
			wrapper.Operator = this.Operator;
			wrapper.ChannelCode = this.ChannelCode;
			wrapper.FuzzyCommand = this.FuzzyCommand;
			wrapper.AccurateCommand = this.AccurateCommand;
			wrapper.Port = this.Port;
			wrapper.ChannelType = this.ChannelType;
			wrapper.Price = this.Price;
			wrapper.Rate = this.Rate;
			wrapper.Status = this.Status;
			wrapper.CreateTime = this.CreateTime;
			wrapper.CreateBy = this.CreateBy;
			wrapper.OkMessage = this.OkMessage;
			wrapper.FailedMessage = this.FailedMessage;
			wrapper.UperID =  (this.UperID==null) ? null : SPUperWrapper.FindById(this.UperID);
			wrapper.ChannelCodeParamsName = this.ChannelCodeParamsName;
			wrapper.IsAllowNullLinkID = this.IsAllowNullLinkID;
			wrapper.RecStatReport = this.RecStatReport;
			wrapper.StatParamsName = this.StatParamsName;
			wrapper.StatParamsValues = this.StatParamsValues;
		
		return wrapper;
        }



   }
}
