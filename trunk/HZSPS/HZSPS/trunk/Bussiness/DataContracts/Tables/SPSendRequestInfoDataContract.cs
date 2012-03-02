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
	public class SPSendRequestInfoDataContract
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Bussiness.DataContracts.Tables.SPSendRequestInfoDataContract";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_TOURL = "ToUrl";
		public static readonly string PROPERTY_NAME_DATAID = "DataID";
		public static readonly string PROPERTY_NAME_ISSUCCESS = "IsSuccess";
		public static readonly string PROPERTY_NAME_ERRORCODE = "ErrorCode";
		public static readonly string PROPERTY_NAME_ERRORMESSAGE = "ErrorMessage";
		public static readonly string PROPERTY_NAME_SENDPARANS = "SendParans";
		
        #endregion
	
        #region 私有成员变量
		
		private int _id;
		private int? _toUrl;
		private int? _dataID;
		private bool? _isSuccess;
		private string _errorCode;
		private string _errorMessage;
		private string _sendParans;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPSendRequestInfoDataContract()
		{
			_id = 0;
			_toUrl = null;
			_dataID = null;
			_isSuccess = null;
			_errorCode = null;
			_errorMessage = null;
			_sendParans = null;
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
		public int? ToUrl
		{
			get { return _toUrl; }

			set	
			{
				_toUrl = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? DataID
		{
			get { return _dataID; }

			set	
			{
				_dataID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool? IsSuccess
		{
			get { return _isSuccess; }

			set	
			{
				_isSuccess = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string ErrorCode
		{
			get { return _errorCode; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ErrorCode", value, value.ToString());
				_errorCode = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string ErrorMessage
		{
			get { return _errorMessage; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for ErrorMessage", value, value.ToString());
				_errorMessage = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string SendParans
		{
			get { return _sendParans; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for SendParans", value, value.ToString());
				_sendParans = value;
			}
		}

		
		#endregion 


        public void FromWrapper(SPSendRequestInfoWrapper wrapper)
		{
			this.Id = wrapper.Id;
			this.ToUrl = wrapper.ToUrl;
			this.DataID = wrapper.DataID;
			this.IsSuccess = wrapper.IsSuccess;
			this.ErrorCode = wrapper.ErrorCode;
			this.ErrorMessage = wrapper.ErrorMessage;
			this.SendParans = wrapper.SendParans;
		}
		
		
		public SPSendRequestInfoWrapper ToWrapper()
        {
			SPSendRequestInfoWrapper wrapper = new SPSendRequestInfoWrapper();
			wrapper.Id = this.Id;
			wrapper.ToUrl = this.ToUrl;
			wrapper.DataID = this.DataID;
			wrapper.IsSuccess = this.IsSuccess;
			wrapper.ErrorCode = this.ErrorCode;
			wrapper.ErrorMessage = this.ErrorMessage;
			wrapper.SendParans = this.SendParans;
		
		return wrapper;
        }



   }
}
