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
	public partial class SPRequestInfoEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Entity.Tables.SPRequestInfoEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_IP = "Ip";
		public static readonly string PROPERTY_NAME_REQUESTINFO = "RequestInfo";
		public static readonly string PROPERTY_NAME_REQUESTDATE = "RequestDate";
		public static readonly string PROPERTY_NAME_ISTOPAYMENT = "IsToPayment";
		public static readonly string PROPERTY_NAME_REQUESTURL = "RequestUrl";
		public static readonly string PROPERTY_NAME_DATAID = "DataID";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _id;
		private string _ip;
		private string _requestInfo;
		private DateTime? _requestDate;
		private bool? _isToPayment;
		private string _requestUrl;
		private int? _dataID;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPRequestInfoEntity()
		{
			_id = 0;
			_ip = null;
			_requestInfo = null;
			_requestDate = null;
			_isToPayment = null;
			_requestUrl = null;
			_dataID = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SPRequestInfoEntity( int id, string ip, string requestInfo, DateTime? requestDate, bool? isToPayment, string requestUrl, int? dataID)
		{
			_id = id;
			_ip = ip;
			_requestInfo = requestInfo;
			_requestDate = requestDate;
			_isToPayment = isToPayment;
			_requestUrl = requestUrl;
			_dataID = dataID;
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
		public virtual string Ip
		{
			get { return _ip; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Ip", value, value.ToString());
				_isChanged |= (_ip != value); _ip = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string RequestInfo
		{
			get { return _requestInfo; }

			set	
			{

				if( value != null && value.Length > 2147483646)
					throw new ArgumentOutOfRangeException("Invalid value for RequestInfo", value, value.ToString());
				_isChanged |= (_requestInfo != value); _requestInfo = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? RequestDate
		{
			get { return _requestDate; }

			set	
			{
				_isChanged |= (_requestDate != value); _requestDate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? IsToPayment
		{
			get { return _isToPayment; }

			set	
			{
				_isChanged |= (_isToPayment != value); _isToPayment = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string RequestUrl
		{
			get { return _requestUrl; }

			set	
			{

				if( value != null && value.Length > 2147483646)
					throw new ArgumentOutOfRangeException("Invalid value for RequestUrl", value, value.ToString());
				_isChanged |= (_requestUrl != value); _requestUrl = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? DataID
		{
			get { return _dataID; }

			set	
			{
				_isChanged |= (_dataID != value); _dataID = value;
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
			
			SPRequestInfoEntity castObj = (SPRequestInfoEntity)obj;
			
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
