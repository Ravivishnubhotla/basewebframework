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
	public class SPSendClientParamsDataContract
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Bussiness.DataContracts.Tables.SPSendClientParamsDataContract";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_ISENABLE = "IsEnable";
		public static readonly string PROPERTY_NAME_ISREQUIRED = "IsRequired";
		public static readonly string PROPERTY_NAME_CLIENTID = "ClientID";
		public static readonly string PROPERTY_NAME_MAPPINGPARAMS = "MappingParams";
		public static readonly string PROPERTY_NAME_TITLE = "Title";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		
        #endregion
	
        #region 私有成员变量
		
		private int _id;
		private string _name;
		private string _description;
		private bool? _isEnable;
		private bool? _isRequired;
		private int? _clientID;
		private string _mappingParams;
		private string _title;
		private int? _channelID;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPSendClientParamsDataContract()
		{
			_id = 0;
			_name = null;
			_description = null;
			_isEnable = null;
			_isRequired = null;
			_clientID = null;
			_mappingParams = null;
			_title = null;
			_channelID = null;
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
		public bool? IsEnable
		{
			get { return _isEnable; }

			set	
			{
				_isEnable = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool? IsRequired
		{
			get { return _isRequired; }

			set	
			{
				_isRequired = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? ClientID
		{
			get { return _clientID; }

			set	
			{
				_clientID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string MappingParams
		{
			get { return _mappingParams; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for MappingParams", value, value.ToString());
				_mappingParams = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Title
		{
			get { return _title; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Title", value, value.ToString());
				_title = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? ChannelID
		{
			get { return _channelID; }

			set	
			{
				_channelID = value;
			}
		}

		
		#endregion 


        public void FromWrapper(SPSendClientParamsWrapper wrapper)
		{
			this.Id = wrapper.Id;
			this.Name = wrapper.Name;
			this.Description = wrapper.Description;
			this.IsEnable = wrapper.IsEnable;
			this.IsRequired = wrapper.IsRequired;
			this.ClientID = (wrapper.ClientID!=null) ? wrapper.ClientID.Id : 0 ; 
			this.MappingParams = wrapper.MappingParams;
			this.Title = wrapper.Title;
			this.ChannelID = wrapper.ChannelID;
		}
		
		
		public SPSendClientParamsWrapper ToWrapper()
        {
			SPSendClientParamsWrapper wrapper = new SPSendClientParamsWrapper();
			wrapper.Id = this.Id;
			wrapper.Name = this.Name;
			wrapper.Description = this.Description;
			wrapper.IsEnable = this.IsEnable;
			wrapper.IsRequired = this.IsRequired;
			wrapper.ClientID =  (this.ClientID==null) ? null : SPClientWrapper.FindById(this.ClientID);
			wrapper.MappingParams = this.MappingParams;
			wrapper.Title = this.Title;
			wrapper.ChannelID = this.ChannelID;
		
		return wrapper;
        }



   }
}
