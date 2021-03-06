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
	public class SPChannelParamsDataContract
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Bussiness.DataContracts.Tables.SPChannelParamsDataContract";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_ISENABLE = "IsEnable";
		public static readonly string PROPERTY_NAME_ISREQUIRED = "IsRequired";
		public static readonly string PROPERTY_NAME_PARAMSTYPE = "ParamsType";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		public static readonly string PROPERTY_NAME_PARAMSMAPPINGNAME = "ParamsMappingName";
		public static readonly string PROPERTY_NAME_TITLE = "Title";
		public static readonly string PROPERTY_NAME_SHOWINCLIENTGRID = "ShowInClientGrid";
		public static readonly string PROPERTY_NAME_ISUNIQUE = "IsUnique";
		
        #endregion
	
        #region 私有成员变量
		
		private int _id;
		private string _name;
		private string _description;
		private bool? _isEnable;
		private bool? _isRequired;
		private string _paramsType;
		private int _channelID;
		private string _paramsMappingName;
		private string _title;
		private bool? _showInClientGrid;
		private bool? _isUnique;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPChannelParamsDataContract()
		{
			_id = 0;
			_name = null;
			_description = null;
			_isEnable = null;
			_isRequired = null;
			_paramsType = null;
			_channelID = 0;
			_paramsMappingName = null;
			_title = null;
			_showInClientGrid = true;
			_isUnique = null;
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
		public string ParamsType
		{
			get { return _paramsType; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ParamsType", value, value.ToString());
				_paramsType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int ChannelID
		{
			get { return _channelID; }

			set	
			{
				_channelID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string ParamsMappingName
		{
			get { return _paramsMappingName; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for ParamsMappingName", value, value.ToString());
				_paramsMappingName = value;
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
		public bool? ShowInClientGrid
		{
			get { return _showInClientGrid; }

			set	
			{
				_showInClientGrid = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool? IsUnique
		{
			get { return _isUnique; }

			set	
			{
				_isUnique = value;
			}
		}

		
		#endregion 


        public void FromWrapper(SPChannelParamsWrapper wrapper)
		{
			this.Id = wrapper.Id;
			this.Name = wrapper.Name;
			this.Description = wrapper.Description;
			this.IsEnable = wrapper.IsEnable;
			this.IsRequired = wrapper.IsRequired;
			this.ParamsType = wrapper.ParamsType;
			this.ChannelID = (wrapper.ChannelID!=null) ? wrapper.ChannelID.Id : 0 ; 
			this.ParamsMappingName = wrapper.ParamsMappingName;
			this.Title = wrapper.Title;
			this.ShowInClientGrid = wrapper.ShowInClientGrid;
			this.IsUnique = wrapper.IsUnique;
		}
		
		
		public SPChannelParamsWrapper ToWrapper()
        {
			SPChannelParamsWrapper wrapper = new SPChannelParamsWrapper();
			wrapper.Id = this.Id;
			wrapper.Name = this.Name;
			wrapper.Description = this.Description;
			wrapper.IsEnable = this.IsEnable;
			wrapper.IsRequired = this.IsRequired;
			wrapper.ParamsType = this.ParamsType;
			wrapper.ChannelID =  (this.ChannelID==null) ? null : SPChannelWrapper.FindById(this.ChannelID);
			wrapper.ParamsMappingName = this.ParamsMappingName;
			wrapper.Title = this.Title;
			wrapper.ShowInClientGrid = this.ShowInClientGrid;
			wrapper.IsUnique = this.IsUnique;
		
		return wrapper;
        }



   }
}
