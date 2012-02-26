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
	public class SPClientDataContract
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Bussiness.DataContracts.Tables.SPClientDataContract";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_RECIEVEDATAURL = "RecieveDataUrl";
		public static readonly string PROPERTY_NAME_USERID = "UserID";
		public static readonly string PROPERTY_NAME_SYNCDATA = "SyncData";
		public static readonly string PROPERTY_NAME_OKMESSAGE = "OkMessage";
		public static readonly string PROPERTY_NAME_FAILEDMESSAGE = "FailedMessage";
		public static readonly string PROPERTY_NAME_SYNCTYPE = "SyncType";
		public static readonly string PROPERTY_NAME_SPCLIENTGROUPID = "SPClientGroupID";
		public static readonly string PROPERTY_NAME_ISDEFAULTCLIENT = "IsDefaultClient";
		public static readonly string PROPERTY_NAME_ALIAS = "Alias";
		
        #endregion
	
        #region 私有成员变量
		
		private int _id;
		private string _name;
		private string _description;
		private string _recieveDataUrl;
		private int? _userID;
		private bool? _syncData;
		private string _okMessage;
		private string _failedMessage;
		private string _syncType;
		private int? _sPClientGroupID;
		private bool? _isDefaultClient;
		private string _alias;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPClientDataContract()
		{
			_id = 0;
			_name = null;
			_description = null;
			_recieveDataUrl = null;
			_userID = null;
			_syncData = null;
			_okMessage = null;
			_failedMessage = null;
			_syncType = null;
			_sPClientGroupID = null;
			_isDefaultClient = null;
			_alias = null;
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
		public string Name
		{
			get { return _name; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
				_name = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Description
		{
			get { return _description; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
				_description = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string RecieveDataUrl
		{
			get { return _recieveDataUrl; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for RecieveDataUrl", value, value.ToString());
				_recieveDataUrl = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? UserID
		{
			get { return _userID; }

			set	
			{
				_userID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool? SyncData
		{
			get { return _syncData; }

			set	
			{
				_syncData = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string OkMessage
		{
			get { return _okMessage; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for OkMessage", value, value.ToString());
				_okMessage = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string FailedMessage
		{
			get { return _failedMessage; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for FailedMessage", value, value.ToString());
				_failedMessage = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string SyncType
		{
			get { return _syncType; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for SyncType", value, value.ToString());
				_syncType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? SPClientGroupID
		{
			get { return _sPClientGroupID; }

			set	
			{
				_sPClientGroupID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool? IsDefaultClient
		{
			get { return _isDefaultClient; }

			set	
			{
				_isDefaultClient = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Alias
		{
			get { return _alias; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Alias", value, value.ToString());
				_alias = value;
			}
		}

		
		#endregion 


        public void FromWrapper(SPClientWrapper wrapper)
		{
			this.Id = wrapper.Id;
			this.Name = wrapper.Name;
			this.Description = wrapper.Description;
			this.RecieveDataUrl = wrapper.RecieveDataUrl;
			this.UserID = wrapper.UserID;
			this.SyncData = wrapper.SyncData;
			this.OkMessage = wrapper.OkMessage;
			this.FailedMessage = wrapper.FailedMessage;
			this.SyncType = wrapper.SyncType;
			this.SPClientGroupID = (wrapper.SPClientGroupID!=null) ? wrapper.SPClientGroupID.Id : 0 ; 
			this.IsDefaultClient = wrapper.IsDefaultClient;
			this.Alias = wrapper.Alias;
		}
		
		
		public SPClientWrapper ToWrapper()
        {
			SPClientWrapper wrapper = new SPClientWrapper();
			wrapper.Id = this.Id;
			wrapper.Name = this.Name;
			wrapper.Description = this.Description;
			wrapper.RecieveDataUrl = this.RecieveDataUrl;
			wrapper.UserID = this.UserID;
			wrapper.SyncData = this.SyncData;
			wrapper.OkMessage = this.OkMessage;
			wrapper.FailedMessage = this.FailedMessage;
			wrapper.SyncType = this.SyncType;
			wrapper.SPClientGroupID =  (this.SPClientGroupID==null) ? null : SPClientGroupWrapper.FindById(this.SPClientGroupID);
			wrapper.IsDefaultClient = this.IsDefaultClient;
			wrapper.Alias = this.Alias;
		
		return wrapper;
        }



   }
}
