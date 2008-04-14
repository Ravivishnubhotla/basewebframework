/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	系统事件日志
	/// </summary>
	[Serializable]
	public abstract class SystemLogBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemLog";
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
		private int _log_id;
		private string _log_level;
		private string _log_type;
		private DateTime? _log_date;
		private string _log_source;
		private string _log_user;
		private string _log_descrption;
		private string _log_requestinfo;
		private int _log_relatemoudleid;
		private int _log_relatemoudledataid;
		private int _log_relateuserid;
		private DateTime? _log_relatedatetime;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemLogBase()
		{
			_log_id = 0; 
			_log_level = String.Empty; 
			_log_type = String.Empty; 
			_log_date =  null;  
			_log_source = String.Empty; 
			_log_user = String.Empty; 
			_log_descrption = String.Empty; 
			_log_requestinfo = String.Empty; 
			_log_relatemoudleid = 0; 
			_log_relatemoudledataid = 0; 
			_log_relateuserid = 0; 
			_log_relatedatetime =  null;  
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int LogID
		{
			get { return _log_id; }
			set { _isChanged |= (_log_id != value); _log_id = value; }
		}
		/// <summary>
		/// 日志级别
		/// </summary>		
		public virtual string LogLevel
		{
			get { return _log_level; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for LogLevel", value, value.ToString());
				
				_isChanged |= (_log_level != value); _log_level = value;
			}
		}
		/// <summary>
		/// 日志类型
		/// </summary>		
		public virtual string LogType
		{
			get { return _log_type; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for LogType", value, value.ToString());
				
				_isChanged |= (_log_type != value); _log_type = value;
			}
		}
		/// <summary>
		/// 日志日期
		/// </summary>		
		public virtual DateTime? LogDate
		{
			get { return _log_date; }
			set { _isChanged |= (_log_date != value); _log_date = value; }
		}
		/// <summary>
		/// 日志来源
		/// </summary>		
		public virtual string LogSource
		{
			get { return _log_source; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for LogSource", value, value.ToString());
				
				_isChanged |= (_log_source != value); _log_source = value;
			}
		}
		/// <summary>
		/// 日志用户
		/// </summary>		
		public virtual string LogUser
		{
			get { return _log_user; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for LogUser", value, value.ToString());
				
				_isChanged |= (_log_user != value); _log_user = value;
			}
		}
		/// <summary>
		/// 日志内容
		/// </summary>		
		public virtual string LogDescrption
		{
			get { return _log_descrption; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for LogDescrption", value, value.ToString());
				
				_isChanged |= (_log_descrption != value); _log_descrption = value;
			}
		}
		/// <summary>
		/// 日志请求信息
		/// </summary>		
		public virtual string LogRequestInfo
		{
			get { return _log_requestinfo; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for LogRequestInfo", value, value.ToString());
				
				_isChanged |= (_log_requestinfo != value); _log_requestinfo = value;
			}
		}
		/// <summary>
		/// 日志相关模块
		/// </summary>		
		public virtual int LogRelateMoudleID
		{
			get { return _log_relatemoudleid; }
			set { _isChanged |= (_log_relatemoudleid != value); _log_relatemoudleid = value; }
		}
		/// <summary>
		/// 日志相关模块数据ID
		/// </summary>		
		public virtual int LogRelateMoudleDataID
		{
			get { return _log_relatemoudledataid; }
			set { _isChanged |= (_log_relatemoudledataid != value); _log_relatemoudledataid = value; }
		}
		/// <summary>
		/// 日志相关用户ID
		/// </summary>		
		public virtual int LogRelateUserID
		{
			get { return _log_relateuserid; }
			set { _isChanged |= (_log_relateuserid != value); _log_relateuserid = value; }
		}
		/// <summary>
		/// 日志相关时间
		/// </summary>		
		public virtual DateTime? LogRelateDateTime
		{
			get { return _log_relatedatetime; }
			set { _isChanged |= (_log_relatedatetime != value); _log_relatedatetime = value; }
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
			SystemLogBase castObj = (SystemLogBase)obj; 
			return ( castObj != null ) &&
				( this._log_id == castObj.LogID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _log_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemLogBase obj )
		{
			obj.LogLevel = this._log_level;
			obj.LogType = this._log_type;
			obj.LogDate = this._log_date;
			obj.LogSource = this._log_source;
			obj.LogUser = this._log_user;
			obj.LogDescrption = this._log_descrption;
			obj.LogRequestInfo = this._log_requestinfo;
			obj.LogRelateMoudleID = this._log_relatemoudleid;
			obj.LogRelateMoudleDataID = this._log_relatemoudledataid;
			obj.LogRelateUserID = this._log_relateuserid;
			obj.LogRelateDateTime = this._log_relatedatetime;
		}
        #endregion
	}
}
