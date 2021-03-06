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
	public partial class SystemEmailQueueEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemEmailQueueEntity";
		public static readonly string PROPERTY_NAME_QUEUEID = "QueueID";
		public static readonly string PROPERTY_NAME_TITLE = "Title";
		public static readonly string PROPERTY_NAME_BODY = "Body";
		public static readonly string PROPERTY_NAME_FROMADDRESS = "FromAddress";
		public static readonly string PROPERTY_NAME_FROMNAME = "FromName";
		public static readonly string PROPERTY_NAME_TOADDRESSS = "ToAddresss";
		public static readonly string PROPERTY_NAME_TONAMES = "ToNames";
		public static readonly string PROPERTY_NAME_CCADDRESSS = "CCAddresss";
		public static readonly string PROPERTY_NAME_CCNAMES = "CCNames";
		public static readonly string PROPERTY_NAME_BCCADDRESSS = "BCCAddresss";
		public static readonly string PROPERTY_NAME_BCCNAMES = "BCCNames";
		public static readonly string PROPERTY_NAME_EMAILTEMPLATEID = "EmailTemplateID";
		public static readonly string PROPERTY_NAME_STATUES = "Statues";
		public static readonly string PROPERTY_NAME_SENDRETRY = "SendRetry";
		public static readonly string PROPERTY_NAME_MAXRETRYTIME = "MaxRetryTime";
		public static readonly string PROPERTY_NAME_MAILLOG = "MailLog";
		public static readonly string PROPERTY_NAME_CREATEDATE = "CreateDate";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_SENDDATE = "SendDate";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _queueID;
		private string _title;
		private string _body;
		private string _fromAddress;
		private string _fromName;
		private string _toAddresss;
		private string _toNames;
		private string _cCAddresss;
		private string _cCNames;
		private string _bCCAddresss;
		private string _bCCNames;
		private int? _emailTemplateID;
		private string _statues;
		private int? _sendRetry;
		private int? _maxRetryTime;
		private string _mailLog;
		private DateTime? _createDate;
		private int? _createBy;
		private DateTime? _sendDate;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemEmailQueueEntity()
		{
			_queueID = 0;
			_title = null;
			_body = null;
			_fromAddress = null;
			_fromName = null;
			_toAddresss = null;
			_toNames = null;
			_cCAddresss = null;
			_cCNames = null;
			_bCCAddresss = null;
			_bCCNames = null;
			_emailTemplateID = null;
			_statues = null;
			_sendRetry = null;
			_maxRetryTime = null;
			_mailLog = null;
			_createDate = null;
			_createBy = null;
			_sendDate = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemEmailQueueEntity( int queueID, string title, string body, string fromAddress, string fromName, string toAddresss, string toNames, string cCAddresss, string cCNames, string bCCAddresss, string bCCNames, int? emailTemplateID, string statues, int? sendRetry, int? maxRetryTime, string mailLog, DateTime? createDate, int? createBy, DateTime? sendDate)
		{
			_queueID = queueID;
			_title = title;
			_body = body;
			_fromAddress = fromAddress;
			_fromName = fromName;
			_toAddresss = toAddresss;
			_toNames = toNames;
			_cCAddresss = cCAddresss;
			_cCNames = cCNames;
			_bCCAddresss = bCCAddresss;
			_bCCNames = bCCNames;
			_emailTemplateID = emailTemplateID;
			_statues = statues;
			_sendRetry = sendRetry;
			_maxRetryTime = maxRetryTime;
			_mailLog = mailLog;
			_createDate = createDate;
			_createBy = createBy;
			_sendDate = sendDate;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int QueueID
		{
			get { return _queueID; }

			set	
			{
				_isChanged |= (_queueID != value); _queueID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Title
		{
			get { return _title; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Title", value, value.ToString());
				_isChanged |= (_title != value); _title = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Body
		{
			get { return _body; }

			set	
			{

				if( value != null && value.Length > 2147483646)
					throw new ArgumentOutOfRangeException("Invalid value for Body", value, value.ToString());
				_isChanged |= (_body != value); _body = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string FromAddress
		{
			get { return _fromAddress; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for FromAddress", value, value.ToString());
				_isChanged |= (_fromAddress != value); _fromAddress = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string FromName
		{
			get { return _fromName; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for FromName", value, value.ToString());
				_isChanged |= (_fromName != value); _fromName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ToAddresss
		{
			get { return _toAddresss; }

			set	
			{

				if( value != null && value.Length > 2147483646)
					throw new ArgumentOutOfRangeException("Invalid value for ToAddresss", value, value.ToString());
				_isChanged |= (_toAddresss != value); _toAddresss = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ToNames
		{
			get { return _toNames; }

			set	
			{

				if( value != null && value.Length > 2147483646)
					throw new ArgumentOutOfRangeException("Invalid value for ToNames", value, value.ToString());
				_isChanged |= (_toNames != value); _toNames = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string CCAddresss
		{
			get { return _cCAddresss; }

			set	
			{

				if( value != null && value.Length > 2147483646)
					throw new ArgumentOutOfRangeException("Invalid value for CCAddresss", value, value.ToString());
				_isChanged |= (_cCAddresss != value); _cCAddresss = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string CCNames
		{
			get { return _cCNames; }

			set	
			{

				if( value != null && value.Length > 2147483646)
					throw new ArgumentOutOfRangeException("Invalid value for CCNames", value, value.ToString());
				_isChanged |= (_cCNames != value); _cCNames = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string BCCAddresss
		{
			get { return _bCCAddresss; }

			set	
			{

				if( value != null && value.Length > 2147483646)
					throw new ArgumentOutOfRangeException("Invalid value for BCCAddresss", value, value.ToString());
				_isChanged |= (_bCCAddresss != value); _bCCAddresss = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string BCCNames
		{
			get { return _bCCNames; }

			set	
			{

				if( value != null && value.Length > 2147483646)
					throw new ArgumentOutOfRangeException("Invalid value for BCCNames", value, value.ToString());
				_isChanged |= (_bCCNames != value); _bCCNames = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? EmailTemplateID
		{
			get { return _emailTemplateID; }

			set	
			{
				_isChanged |= (_emailTemplateID != value); _emailTemplateID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Statues
		{
			get { return _statues; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Statues", value, value.ToString());
				_isChanged |= (_statues != value); _statues = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? SendRetry
		{
			get { return _sendRetry; }

			set	
			{
				_isChanged |= (_sendRetry != value); _sendRetry = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? MaxRetryTime
		{
			get { return _maxRetryTime; }

			set	
			{
				_isChanged |= (_maxRetryTime != value); _maxRetryTime = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string MailLog
		{
			get { return _mailLog; }

			set	
			{

				if( value != null && value.Length > 2147483646)
					throw new ArgumentOutOfRangeException("Invalid value for MailLog", value, value.ToString());
				_isChanged |= (_mailLog != value); _mailLog = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? CreateDate
		{
			get { return _createDate; }

			set	
			{
				_isChanged |= (_createDate != value); _createDate = value;
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
		public virtual DateTime? SendDate
		{
			get { return _sendDate; }

			set	
			{
				_isChanged |= (_sendDate != value); _sendDate = value;
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
			
			SystemEmailQueueEntity castObj = (SystemEmailQueueEntity)obj;
			
			return ( castObj != null ) && ( this._queueID == castObj.QueueID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _queueID.GetHashCode();

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
