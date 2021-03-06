// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SystemLogEntity.Designer.cs">
//   Copyright (c) Foreveross Enterprises. All rights reserved.
// </copyright>
// <summary>
//   Generated by MyGeneration Version # (1.3.0.9)
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Legendigital.Framework.Common.Entity;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	SystemLog
	/// </summary>
	[DataContract]
	public partial class SystemLogEntity  : BaseTableEntity<int>,ICloneable
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
		public static readonly string PROPERTY_NAME_PARENTDATAID = "ParentDataID";
		public static readonly string PROPERTY_NAME_PARENTDATATYPE = "ParentDataType";
		public static readonly string PROPERTY_NAME_LOGRELATEUSERID = "LogRelateUserID";
		public static readonly string PROPERTY_NAME_LOGRELATEUSERNAME = "LogRelateUserName";
		public static readonly string PROPERTY_NAME_LOGRELATEDATETIME = "LogRelateDateTime";
		public static readonly string PROPERTY_NAME_DATANUMBER = "DataNumber";
		
        #endregion
	
 
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _logID;
		private string _logLevel;
		private string _logType;
		private DateTime _logDate;
		private string _logSource;
		private string _logUser;
		private string _logDescrption;
		private string _logRequestInfo;
		private int? _parentDataID;
		private string _parentDataType;
		private int? _logRelateUserID;
		private string _logRelateUserName;
		private DateTime? _logRelateDateTime;
		private string _dataNumber;
		
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
			_parentDataID = null;
			_parentDataType = null;
			_logRelateUserID = null;
			_logRelateUserName = null;
			_logRelateDateTime = null;
			_dataNumber = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemLogEntity( int logID, string logLevel, string logType, DateTime logDate, string logSource, string logUser, string logDescrption, string logRequestInfo, int? parentDataID, string parentDataType, int? logRelateUserID, string logRelateUserName, DateTime? logRelateDateTime, string dataNumber)
		{
			_logID = logID;
			_logLevel = logLevel;
			_logType = logType;
			_logDate = logDate;
			_logSource = logSource;
			_logUser = logUser;
			_logDescrption = logDescrption;
			_logRequestInfo = logRequestInfo;
			_parentDataID = parentDataID;
			_parentDataType = parentDataType;
			_logRelateUserID = logRelateUserID;
			_logRelateUserName = logRelateUserName;
			_logRelateDateTime = logRelateDateTime;
			_dataNumber = dataNumber;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// Log_ID
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
		/// Log_Level
		/// </summary>
		[DataMember]
		public virtual string LogLevel
		{
			get { return _logLevel; }

			set	
			{

				if( value != null && value.Length > 60)
					throw new ArgumentOutOfRangeException("Invalid value for LogLevel", value, value.ToString());
				_isChanged |= (_logLevel != value); _logLevel = value;
			}
		}

		/// <summary>
		/// Log_Type
		/// </summary>
		[DataMember]
		public virtual string LogType
		{
			get { return _logType; }

			set	
			{

				if( value != null && value.Length > 60)
					throw new ArgumentOutOfRangeException("Invalid value for LogType", value, value.ToString());
				_isChanged |= (_logType != value); _logType = value;
			}
		}

		/// <summary>
		/// Log_Date
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
		/// Log_Source
		/// </summary>
		[DataMember]
		public virtual string LogSource
		{
			get { return _logSource; }

			set	
			{

				if( value != null && value.Length > 60)
					throw new ArgumentOutOfRangeException("Invalid value for LogSource", value, value.ToString());
				_isChanged |= (_logSource != value); _logSource = value;
			}
		}

		/// <summary>
		/// Log_User
		/// </summary>
		[DataMember]
		public virtual string LogUser
		{
			get { return _logUser; }

			set	
			{

				if( value != null && value.Length > 60)
					throw new ArgumentOutOfRangeException("Invalid value for LogUser", value, value.ToString());
				_isChanged |= (_logUser != value); _logUser = value;
			}
		}

		/// <summary>
		/// Log_Descrption
		/// </summary>
		[DataMember]
		public virtual string LogDescrption
		{
			get { return _logDescrption; }

			set	
			{

				if( value != null && value.Length > 1600)
					throw new ArgumentOutOfRangeException("Invalid value for LogDescrption", value, value.ToString());
				_isChanged |= (_logDescrption != value); _logDescrption = value;
			}
		}

		/// <summary>
		/// Log_RequestInfo
		/// </summary>
		[DataMember]
		public virtual string LogRequestInfo
		{
			get { return _logRequestInfo; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for LogRequestInfo", value, value.ToString());
				_isChanged |= (_logRequestInfo != value); _logRequestInfo = value;
			}
		}

		/// <summary>
		/// Log_RelateMoudleID
		/// </summary>
		[DataMember]
		public virtual int? ParentDataID
		{
			get { return _parentDataID; }

			set	
			{
				_isChanged |= (_parentDataID != value); _parentDataID = value;
			}
		}

		/// <summary>
		/// Log_RelateMoudleDataID
		/// </summary>
		[DataMember]
		public virtual string ParentDataType
		{
			get { return _parentDataType; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ParentDataType", value, value.ToString());
				_isChanged |= (_parentDataType != value); _parentDataType = value;
			}
		}

		/// <summary>
		/// Log_RelateUserID
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
		public virtual string LogRelateUserName
		{
			get { return _logRelateUserName; }

			set	
			{

				if( value != null && value.Length > 60)
					throw new ArgumentOutOfRangeException("Invalid value for LogRelateUserName", value, value.ToString());
				_isChanged |= (_logRelateUserName != value); _logRelateUserName = value;
			}
		}

		/// <summary>
		/// Log_RelateDateTime
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
		/// 
		/// </summary>
		[DataMember]
		public virtual string DataNumber
		{
			get { return _dataNumber; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for DataNumber", value, value.ToString());
				_isChanged |= (_dataNumber != value); _dataNumber = value;
			}
		}
	

		#endregion 

        

		#region Equals 和 HashCode 方法覆盖
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			 return this.CheckEquals(obj as SystemLogEntity);
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			return GetEntityHashCode();
		}
		#endregion
		
		public override int GetDataEntityKey()
	    {
	        return this._logID;
	    }
		
		
	
		#region ICloneable methods
		
		public virtual object Clone()
		{
			return this.MemberwiseClone();
		}
		
		#endregion
	
	}
}
