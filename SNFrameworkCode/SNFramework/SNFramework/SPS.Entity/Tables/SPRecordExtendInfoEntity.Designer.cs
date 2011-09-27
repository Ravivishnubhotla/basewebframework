// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SPS.Entity.Tables
{
	/// <summary>
	///	
	/// </summary>
	[DataContract]
	public partial class SPRecordExtendInfoEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPRecordExtendInfoEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_RECORDID = "RecordID";
		public static readonly string PROPERTY_NAME_IP = "Ip";
		public static readonly string PROPERTY_NAME_SSYCNDATAURL = "SSycnDataUrl";
		public static readonly string PROPERTY_NAME_REQUESTCONTENT = "RequestContent";
		public static readonly string PROPERTY_NAME_EXTENDFIELD1 = "ExtendField1";
		public static readonly string PROPERTY_NAME_EXTENDFIELD2 = "ExtendField2";
		public static readonly string PROPERTY_NAME_EXTENDFIELD3 = "ExtendField3";
		public static readonly string PROPERTY_NAME_EXTENDFIELD4 = "ExtendField4";
		public static readonly string PROPERTY_NAME_EXTENDFIELD5 = "ExtendField5";
		public static readonly string PROPERTY_NAME_EXTENDFIELD6 = "ExtendField6";
		public static readonly string PROPERTY_NAME_EXTENDFIELD8 = "ExtendField8";
		public static readonly string PROPERTY_NAME_EXTENDFIELD7 = "ExtendField7";
		public static readonly string PROPERTY_NAME_EXTENDFIELD9 = "ExtendField9";
		public static readonly string PROPERTY_NAME_EXTENDFIELD10 = "ExtendField10";
		public static readonly string PROPERTY_NAME_STATE = "State";
		public static readonly string PROPERTY_NAME_FEETIME = "FeeTime";
		public static readonly string PROPERTY_NAME_STARTTIME = "StartTime";
		public static readonly string PROPERTY_NAME_ENDTIME = "EndTime";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _id;
		private SPRecordEntity _recordID;
		private string _ip;
		private string _sSycnDataUrl;
		private string _requestContent;
		private string _extendField1;
		private string _extendField2;
		private string _extendField3;
		private string _extendField4;
		private string _extendField5;
		private string _extendField6;
		private string _extendField8;
		private string _extendField7;
		private string _extendField9;
		private string _extendField10;
		private string _state;
		private string _feeTime;
		private string _startTime;
		private string _endTime;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPRecordExtendInfoEntity()
		{
			_id = 0;
			_recordID = null;
			_ip = null;
			_sSycnDataUrl = null;
			_requestContent = null;
			_extendField1 = null;
			_extendField2 = null;
			_extendField3 = null;
			_extendField4 = null;
			_extendField5 = null;
			_extendField6 = null;
			_extendField8 = null;
			_extendField7 = null;
			_extendField9 = null;
			_extendField10 = null;
			_state = null;
			_feeTime = null;
			_startTime = null;
			_endTime = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SPRecordExtendInfoEntity( int id, SPRecordEntity recordID, string ip, string sSycnDataUrl, string requestContent, string extendField1, string extendField2, string extendField3, string extendField4, string extendField5, string extendField6, string extendField8, string extendField7, string extendField9, string extendField10, string state, string feeTime, string startTime, string endTime)
		{
			_id = id;
			_recordID = recordID;
			_ip = ip;
			_sSycnDataUrl = sSycnDataUrl;
			_requestContent = requestContent;
			_extendField1 = extendField1;
			_extendField2 = extendField2;
			_extendField3 = extendField3;
			_extendField4 = extendField4;
			_extendField5 = extendField5;
			_extendField6 = extendField6;
			_extendField8 = extendField8;
			_extendField7 = extendField7;
			_extendField9 = extendField9;
			_extendField10 = extendField10;
			_state = state;
			_feeTime = feeTime;
			_startTime = startTime;
			_endTime = endTime;
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
		public virtual SPRecordEntity RecordID
		{
			get { return _recordID; }

			set	
			{
				_isChanged |= (_recordID != value); _recordID = value;
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

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for Ip", value, value.ToString());
				_isChanged |= (_ip != value); _ip = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string SSycnDataUrl
		{
			get { return _sSycnDataUrl; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for SSycnDataUrl", value, value.ToString());
				_isChanged |= (_sSycnDataUrl != value); _sSycnDataUrl = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string RequestContent
		{
			get { return _requestContent; }

			set	
			{

				if( value != null && value.Length > 2147483646)
					throw new ArgumentOutOfRangeException("Invalid value for RequestContent", value, value.ToString());
				_isChanged |= (_requestContent != value); _requestContent = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ExtendField1
		{
			get { return _extendField1; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField1", value, value.ToString());
				_isChanged |= (_extendField1 != value); _extendField1 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ExtendField2
		{
			get { return _extendField2; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField2", value, value.ToString());
				_isChanged |= (_extendField2 != value); _extendField2 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ExtendField3
		{
			get { return _extendField3; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField3", value, value.ToString());
				_isChanged |= (_extendField3 != value); _extendField3 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ExtendField4
		{
			get { return _extendField4; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField4", value, value.ToString());
				_isChanged |= (_extendField4 != value); _extendField4 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ExtendField5
		{
			get { return _extendField5; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField5", value, value.ToString());
				_isChanged |= (_extendField5 != value); _extendField5 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ExtendField6
		{
			get { return _extendField6; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField6", value, value.ToString());
				_isChanged |= (_extendField6 != value); _extendField6 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ExtendField8
		{
			get { return _extendField8; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField8", value, value.ToString());
				_isChanged |= (_extendField8 != value); _extendField8 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ExtendField7
		{
			get { return _extendField7; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField7", value, value.ToString());
				_isChanged |= (_extendField7 != value); _extendField7 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ExtendField9
		{
			get { return _extendField9; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField9", value, value.ToString());
				_isChanged |= (_extendField9 != value); _extendField9 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ExtendField10
		{
			get { return _extendField10; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ExtendField10", value, value.ToString());
				_isChanged |= (_extendField10 != value); _extendField10 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string State
		{
			get { return _state; }

			set	
			{

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for State", value, value.ToString());
				_isChanged |= (_state != value); _state = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string FeeTime
		{
			get { return _feeTime; }

			set	
			{

				if( value != null && value.Length > 6)
					throw new ArgumentOutOfRangeException("Invalid value for FeeTime", value, value.ToString());
				_isChanged |= (_feeTime != value); _feeTime = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string StartTime
		{
			get { return _startTime; }

			set	
			{

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for StartTime", value, value.ToString());
				_isChanged |= (_startTime != value); _startTime = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string EndTime
		{
			get { return _endTime; }

			set	
			{

				if( value != null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for EndTime", value, value.ToString());
				_isChanged |= (_endTime != value); _endTime = value;
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
			
			SPRecordExtendInfoEntity castObj = (SPRecordExtendInfoEntity)obj;
			
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