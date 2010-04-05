// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	
	/// </summary>
	[DataContract]
	public partial class SystemLogEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemLogEntity";
		public static readonly string PROPERTY_NAME_LOGID = "LogID";
		public static readonly string PROPERTY_NAME_LOGLEVEL = "LogLevel";
		public static readonly string PROPERTY_NAME_LOGTYPE = "LogType";
		public static readonly string PROPERTY_NAME_LOGDATE = "LogDate";
		public static readonly string PROPERTY_NAME_LOGSOURCE = "LogSource";
		public static readonly string PROPERTY_NAME_LOGUSER = "LogUser";
		public static readonly string PROPERTY_NAME_LOGDESCRPTION = "LogDescrption";
		public static readonly string PROPERTY_NAME_LOGREQUESTINFO = "LogRequestInfo";
		public static readonly string PROPERTY_NAME_LOGRELATEMOUDLEID = "LogRelateMoudleID";
		public static readonly string PROPERTY_NAME_LOGRELATEMOUDLEDATAID = "LogRelateMoudleDataID";
		public static readonly string PROPERTY_NAME_LOGRELATEUSERID = "LogRelateUserID";
		public static readonly string PROPERTY_NAME_LOGRELATEDATETIME = "LogRelateDateTime";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _logID;
		private string _logLevel;
		private string _logType;
		private DateTime _logDate;
		private string _logSource;
		private string _logUser;
		private string _logDescrption;
		private string _logRequestInfo;
		private int? _logRelateMoudleID;
		private int? _logRelateMoudleDataID;
		private int? _logRelateUserID;
		private DateTime? _logRelateDateTime;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemLogEntity()
		{
			_logID = 0;
			_logLevel = String.Empty;
			_logType = null;
			_logDate = DateTime.MinValue;
			_logSource = String.Empty;
			_logUser = String.Empty;
			_logDescrption = String.Empty;
			_logRequestInfo = null;
			_logRelateMoudleID = null;
			_logRelateMoudleDataID = null;
			_logRelateUserID = null;
			_logRelateDateTime = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemLogEntity( int logID, string logLevel, string logType, DateTime logDate, string logSource, string logUser, string logDescrption, string logRequestInfo, int? logRelateMoudleID, int? logRelateMoudleDataID, int? logRelateUserID, DateTime? logRelateDateTime)
		{
			_logID = logID;
			_logLevel = logLevel;
			_logType = logType;
			_logDate = logDate;
			_logSource = logSource;
			_logUser = logUser;
			_logDescrption = logDescrption;
			_logRequestInfo = logRequestInfo;
			_logRelateMoudleID = logRelateMoudleID;
			_logRelateMoudleDataID = logRelateMoudleDataID;
			_logRelateUserID = logRelateUserID;
			_logRelateDateTime = logRelateDateTime;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int LogID
		{
			get { return _logID; }

			set	
			{
				_isChanged |= (_logID != value); _logID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string LogLevel
		{
			get { return _logLevel; }

			set	
			{

				if( value != null && value.Length > 800)
					throw new ArgumentOutOfRangeException("Invalid value for LogLevel", value, value.ToString());
				_isChanged |= (_logLevel != value); _logLevel = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string LogType
		{
			get { return _logType; }

			set	
			{

				if( value != null && value.Length > 800)
					throw new ArgumentOutOfRangeException("Invalid value for LogType", value, value.ToString());
				_isChanged |= (_logType != value); _logType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime LogDate
		{
			get { return _logDate; }

			set	
			{
				_isChanged |= (_logDate != value); _logDate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string LogSource
		{
			get { return _logSource; }

			set	
			{

				if( value != null && value.Length > 800)
					throw new ArgumentOutOfRangeException("Invalid value for LogSource", value, value.ToString());
				_isChanged |= (_logSource != value); _logSource = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string LogUser
		{
			get { return _logUser; }

			set	
			{

				if( value != null && value.Length > 800)
					throw new ArgumentOutOfRangeException("Invalid value for LogUser", value, value.ToString());
				_isChanged |= (_logUser != value); _logUser = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string LogDescrption
		{
			get { return _logDescrption; }

			set	
			{

				if( value != null && value.Length > 8000)
					throw new ArgumentOutOfRangeException("Invalid value for LogDescrption", value, value.ToString());
				_isChanged |= (_logDescrption != value); _logDescrption = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string LogRequestInfo
		{
			get { return _logRequestInfo; }

			set	
			{

				if( value != null && value.Length > 800)
					throw new ArgumentOutOfRangeException("Invalid value for LogRequestInfo", value, value.ToString());
				_isChanged |= (_logRequestInfo != value); _logRequestInfo = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? LogRelateMoudleID
		{
			get { return _logRelateMoudleID; }

			set	
			{
				_isChanged |= (_logRelateMoudleID != value); _logRelateMoudleID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? LogRelateMoudleDataID
		{
			get { return _logRelateMoudleDataID; }

			set	
			{
				_isChanged |= (_logRelateMoudleDataID != value); _logRelateMoudleDataID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? LogRelateUserID
		{
			get { return _logRelateUserID; }

			set	
			{
				_isChanged |= (_logRelateUserID != value); _logRelateUserID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? LogRelateDateTime
		{
			get { return _logRelateDateTime; }

			set	
			{
				_isChanged |= (_logRelateDateTime != value); _logRelateDateTime = value;
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
			
			SystemLogEntity castObj = (SystemLogEntity)obj;
			
			return ( castObj != null ) && ( this._logID == castObj.LogID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _logID.GetHashCode();

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