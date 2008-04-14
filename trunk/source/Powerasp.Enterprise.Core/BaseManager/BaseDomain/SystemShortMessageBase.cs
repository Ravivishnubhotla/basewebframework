/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	系统短消息
	/// </summary>
	[Serializable]
	public abstract class SystemShortMessageBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemShortMessage";
		public static readonly string PROPERTY_NAME_SHORTMESSAGEID = "ShortMessageID";
		public static readonly string PROPERTY_NAME_SHORTMESSAGETITLE = "ShortMessageTitle";
		public static readonly string PROPERTY_NAME_SHORTMESSAGECATEGORY = "ShortMessageCategory";
		public static readonly string PROPERTY_NAME_SHORTMESSAGECONTENT = "ShortMessageContent";
		public static readonly string PROPERTY_NAME_SHORTMESSAGESENDER = "ShortMessageSender";
		public static readonly string PROPERTY_NAME_SHORTMESSAGESENDDATE = "ShortMessageSendDate";
		public static readonly string PROPERTY_NAME_SHORTMESSAGERECEIVERID = "ShortMessageReceiverID";
		public static readonly string PROPERTY_NAME_SHORTMESSAGEISREAD = "ShortMessageIsRead";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _shortmessage_id;
		private string _shortmessage_title;
		private string _shortmessage_category;
		private string _shortmessage_content;
		private string _shortmessage_sender;
		private DateTime? _shortmessage_send_date;
		private int _shortmessage_receiver_id;
		private bool _shortmessage_isread;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemShortMessageBase()
		{
			_shortmessage_id = 0; 
			_shortmessage_title = String.Empty; 
			_shortmessage_category = String.Empty; 
			_shortmessage_content = String.Empty; 
			_shortmessage_sender = String.Empty; 
			_shortmessage_send_date =  null;  
			_shortmessage_receiver_id = 0; 
			_shortmessage_isread = false; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int ShortMessageID
		{
			get { return _shortmessage_id; }
			set { _isChanged |= (_shortmessage_id != value); _shortmessage_id = value; }
		}
		/// <summary>
		/// 标题
		/// </summary>		
		public virtual string ShortMessageTitle
		{
			get { return _shortmessage_title; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for ShortMessageTitle", value, value.ToString());
				
				_isChanged |= (_shortmessage_title != value); _shortmessage_title = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public virtual string ShortMessageCategory
		{
			get { return _shortmessage_category; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for ShortMessageCategory", value, value.ToString());
				
				_isChanged |= (_shortmessage_category != value); _shortmessage_category = value;
			}
		}
		/// <summary>
		/// 内容
		/// </summary>		
		public virtual string ShortMessageContent
		{
			get { return _shortmessage_content; }
			set	
			{
				if ( value != null)
					if( value.Length > 8000)
						throw new ArgumentOutOfRangeException("Invalid value for ShortMessageContent", value, value.ToString());
				
				_isChanged |= (_shortmessage_content != value); _shortmessage_content = value;
			}
		}
		/// <summary>
		/// 发送者ID
		/// </summary>		
		public virtual string ShortMessageSender
		{
			get { return _shortmessage_sender; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for ShortMessageSender", value, value.ToString());
				
				_isChanged |= (_shortmessage_sender != value); _shortmessage_sender = value;
			}
		}
		/// <summary>
		/// 发送日期
		/// </summary>		
		public virtual DateTime? ShortMessageSendDate
		{
			get { return _shortmessage_send_date; }
			set { _isChanged |= (_shortmessage_send_date != value); _shortmessage_send_date = value; }
		}
		/// <summary>
		/// 接受者ID
		/// </summary>		
		public virtual int ShortMessageReceiverID
		{
			get { return _shortmessage_receiver_id; }
			set { _isChanged |= (_shortmessage_receiver_id != value); _shortmessage_receiver_id = value; }
		}
		/// <summary>
		/// 是否已读
		/// </summary>		
		public virtual bool ShortMessageIsRead
		{
			get { return _shortmessage_isread; }
			set { _isChanged |= (_shortmessage_isread != value); _shortmessage_isread = value; }
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
			SystemShortMessageBase castObj = (SystemShortMessageBase)obj; 
			return ( castObj != null ) &&
				( this._shortmessage_id == castObj.ShortMessageID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _shortmessage_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemShortMessageBase obj )
		{
			obj.ShortMessageTitle = this._shortmessage_title;
			obj.ShortMessageCategory = this._shortmessage_category;
			obj.ShortMessageContent = this._shortmessage_content;
			obj.ShortMessageSender = this._shortmessage_sender;
			obj.ShortMessageSendDate = this._shortmessage_send_date;
			obj.ShortMessageReceiverID = this._shortmessage_receiver_id;
			obj.ShortMessageIsRead = this._shortmessage_isread;
		}
        #endregion
	}
}
