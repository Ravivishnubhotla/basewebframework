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
	public partial class SPChannelEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Entity.Tables.SPChannelEntity";
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
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
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
		private SPUperEntity _uperID;
		private string _channelCodeParamsName;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPChannelEntity()
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
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SPChannelEntity( int id, string name, string description, string area, string operatorp, string channelCode, string fuzzyCommand, string accurateCommand, string port, string channelType, decimal? price, int? rate, int? status, DateTime? createTime, int? createBy, string okMessage, string failedMessage, SPUperEntity uperID, string channelCodeParamsName)
		{
			_id = id;
			_name = name;
			_description = description;
			_area = area;
			_operator = operatorp;
			_channelCode = channelCode;
			_fuzzyCommand = fuzzyCommand;
			_accurateCommand = accurateCommand;
			_port = port;
			_channelType = channelType;
			_price = price;
			_rate = rate;
			_status = status;
			_createTime = createTime;
			_createBy = createBy;
			_okMessage = okMessage;
			_failedMessage = failedMessage;
			_uperID = uperID;
			_channelCodeParamsName = channelCodeParamsName;
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
		public virtual string Name
		{
			get { return _name; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
				_isChanged |= (_name != value); _name = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Description
		{
			get { return _description; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
				_isChanged |= (_description != value); _description = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Area
		{
			get { return _area; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for Area", value, value.ToString());
				_isChanged |= (_area != value); _area = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Operator
		{
			get { return _operator; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Operator", value, value.ToString());
				_isChanged |= (_operator != value); _operator = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ChannelCode
		{
			get { return _channelCode; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ChannelCode", value, value.ToString());
				_isChanged |= (_channelCode != value); _channelCode = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string FuzzyCommand
		{
			get { return _fuzzyCommand; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for FuzzyCommand", value, value.ToString());
				_isChanged |= (_fuzzyCommand != value); _fuzzyCommand = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string AccurateCommand
		{
			get { return _accurateCommand; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for AccurateCommand", value, value.ToString());
				_isChanged |= (_accurateCommand != value); _accurateCommand = value;
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

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Port", value, value.ToString());
				_isChanged |= (_port != value); _port = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ChannelType
		{
			get { return _channelType; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ChannelType", value, value.ToString());
				_isChanged |= (_channelType != value); _channelType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual decimal? Price
		{
			get { return _price; }

			set	
			{
				_isChanged |= (_price != value); _price = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? Rate
		{
			get { return _rate; }

			set	
			{
				_isChanged |= (_rate != value); _rate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? Status
		{
			get { return _status; }

			set	
			{
				_isChanged |= (_status != value); _status = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? CreateTime
		{
			get { return _createTime; }

			set	
			{
				_isChanged |= (_createTime != value); _createTime = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? CreateBy
		{
			get { return _createBy; }

			set	
			{
				_isChanged |= (_createBy != value); _createBy = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string OkMessage
		{
			get { return _okMessage; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for OkMessage", value, value.ToString());
				_isChanged |= (_okMessage != value); _okMessage = value;
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

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for FailedMessage", value, value.ToString());
				_isChanged |= (_failedMessage != value); _failedMessage = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual SPUperEntity UperID
		{
			get { return _uperID; }

			set	
			{
				_isChanged |= (_uperID != value); _uperID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ChannelCodeParamsName
		{
			get { return _channelCodeParamsName; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ChannelCodeParamsName", value, value.ToString());
				_isChanged |= (_channelCodeParamsName != value); _channelCodeParamsName = value;
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
			
			SPChannelEntity castObj = (SPChannelEntity)obj;
			
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
