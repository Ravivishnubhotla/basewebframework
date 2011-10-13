// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Legendigital.Framework.Common.Entity;

namespace SPS.Entity.Tables
{
	/// <summary>
	///	
	/// </summary>
	[DataContract]
	public partial class SPSClientEntity  : BaseTableEntity,ICloneable
	{
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPSClientEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_USERID = "UserID";
		public static readonly string PROPERTY_NAME_ISDEFAULTCLIENT = "IsDefaultClient";
		public static readonly string PROPERTY_NAME_SYNCDATA = "SyncData";
		public static readonly string PROPERTY_NAME_SYCNRETRYTIMES = "SycnRetryTimes";
		public static readonly string PROPERTY_NAME_SYNCTYPE = "SyncType";
		public static readonly string PROPERTY_NAME_SYCNNOTINTERCEPTCOUNT = "SycnNotInterceptCount";
		public static readonly string PROPERTY_NAME_SYCNDATAURL = "SycnDataUrl";
		public static readonly string PROPERTY_NAME_SYCNOKMESSAGE = "SycnOkMessage";
		public static readonly string PROPERTY_NAME_SYCNFAILEDMESSAGE = "SycnFailedMessage";
		public static readonly string PROPERTY_NAME_ALIAS = "Alias";
		public static readonly string PROPERTY_NAME_INTERCEPTRATE = "InterceptRate";
		public static readonly string PROPERTY_NAME_DEFAULTPRICE = "DefaultPrice";
		public static readonly string PROPERTY_NAME_DEFAULTSHOWRECORDDAYS = "DefaultShowRecordDays";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _id;
		private string _name;
		private string _description;
		private int _userID;
		private bool? _isDefaultClient;
		private bool _syncData;
		private int? _sycnRetryTimes;
		private string _syncType;
		private int? _sycnNotInterceptCount;
		private string _sycnDataUrl;
		private string _sycnOkMessage;
		private string _sycnFailedMessage;
		private string _alias;
		private decimal _interceptRate;
		private decimal _defaultPrice;
		private int _defaultShowRecordDays;
		private int? _createBy;
		private DateTime? _createAt;
		private int? _lastModifyBy;
		private DateTime? _lastModifyAt;
		private string _lastModifyComment;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPSClientEntity()
		{
			_id = 0;
			_name = String.Empty;
			_description = String.Empty;
			_userID = 0;
			_isDefaultClient = null;
			_syncData = false;
			_sycnRetryTimes = null;
			_syncType = null;
			_sycnNotInterceptCount = null;
			_sycnDataUrl = null;
			_sycnOkMessage = null;
			_sycnFailedMessage = null;
			_alias = null;
			_interceptRate = 0;
			_defaultPrice = 0;
			_defaultShowRecordDays = 0;
			_createBy = null;
			_createAt = null;
			_lastModifyBy = null;
			_lastModifyAt = null;
			_lastModifyComment = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SPSClientEntity( int id, string name, string description, int userID, bool? isDefaultClient, bool syncData, int? sycnRetryTimes, string syncType, int? sycnNotInterceptCount, string sycnDataUrl, string sycnOkMessage, string sycnFailedMessage, string alias, decimal interceptRate, decimal defaultPrice, int defaultShowRecordDays, int? createBy, DateTime? createAt, int? lastModifyBy, DateTime? lastModifyAt, string lastModifyComment)
		{
			_id = id;
			_name = name;
			_description = description;
			_userID = userID;
			_isDefaultClient = isDefaultClient;
			_syncData = syncData;
			_sycnRetryTimes = sycnRetryTimes;
			_syncType = syncType;
			_sycnNotInterceptCount = sycnNotInterceptCount;
			_sycnDataUrl = sycnDataUrl;
			_sycnOkMessage = sycnOkMessage;
			_sycnFailedMessage = sycnFailedMessage;
			_alias = alias;
			_interceptRate = interceptRate;
			_defaultPrice = defaultPrice;
			_defaultShowRecordDays = defaultShowRecordDays;
			_createBy = createBy;
			_createAt = createAt;
			_lastModifyBy = lastModifyBy;
			_lastModifyAt = lastModifyAt;
			_lastModifyComment = lastModifyComment;
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
		public virtual int UserID
		{
			get { return _userID; }

			set	
			{
				_isChanged |= (_userID != value); _userID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? IsDefaultClient
		{
			get { return _isDefaultClient; }

			set	
			{
				_isChanged |= (_isDefaultClient != value); _isDefaultClient = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool SyncData
		{
			get { return _syncData; }

			set	
			{
				_isChanged |= (_syncData != value); _syncData = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? SycnRetryTimes
		{
			get { return _sycnRetryTimes; }

			set	
			{
				_isChanged |= (_sycnRetryTimes != value); _sycnRetryTimes = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string SyncType
		{
			get { return _syncType; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for SyncType", value, value.ToString());
				_isChanged |= (_syncType != value); _syncType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? SycnNotInterceptCount
		{
			get { return _sycnNotInterceptCount; }

			set	
			{
				_isChanged |= (_sycnNotInterceptCount != value); _sycnNotInterceptCount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string SycnDataUrl
		{
			get { return _sycnDataUrl; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for SycnDataUrl", value, value.ToString());
				_isChanged |= (_sycnDataUrl != value); _sycnDataUrl = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string SycnOkMessage
		{
			get { return _sycnOkMessage; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for SycnOkMessage", value, value.ToString());
				_isChanged |= (_sycnOkMessage != value); _sycnOkMessage = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string SycnFailedMessage
		{
			get { return _sycnFailedMessage; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for SycnFailedMessage", value, value.ToString());
				_isChanged |= (_sycnFailedMessage != value); _sycnFailedMessage = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Alias
		{
			get { return _alias; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Alias", value, value.ToString());
				_isChanged |= (_alias != value); _alias = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual decimal InterceptRate
		{
			get { return _interceptRate; }

			set	
			{
				_isChanged |= (_interceptRate != value); _interceptRate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual decimal DefaultPrice
		{
			get { return _defaultPrice; }

			set	
			{
				_isChanged |= (_defaultPrice != value); _defaultPrice = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int DefaultShowRecordDays
		{
			get { return _defaultShowRecordDays; }

			set	
			{
				_isChanged |= (_defaultShowRecordDays != value); _defaultShowRecordDays = value;
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
		public virtual DateTime? CreateAt
		{
			get { return _createAt; }

			set	
			{
				_isChanged |= (_createAt != value); _createAt = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? LastModifyBy
		{
			get { return _lastModifyBy; }

			set	
			{
				_isChanged |= (_lastModifyBy != value); _lastModifyBy = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? LastModifyAt
		{
			get { return _lastModifyAt; }

			set	
			{
				_isChanged |= (_lastModifyAt != value); _lastModifyAt = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string LastModifyComment
		{
			get { return _lastModifyComment; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for LastModifyComment", value, value.ToString());
				_isChanged |= (_lastModifyComment != value); _lastModifyComment = value;
			}
		}
	

		#endregion 

        

		#region Equals 和 HashCode 方法覆盖
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			 return this.CheckEquals(obj as SPSClientEntity);
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			return GetEntityHashCode();
		}
		#endregion
		
		public override object GetDataEntityKey()
	    {
	        return this._id;
	    }
		
		
	
		#region ICloneable methods
		
		public virtual object Clone()
		{
			return this.MemberwiseClone();
		}
		
		#endregion
	
	}
}
