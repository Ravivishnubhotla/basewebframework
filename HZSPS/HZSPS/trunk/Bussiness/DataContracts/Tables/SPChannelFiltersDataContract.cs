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
	public class SPChannelFiltersDataContract
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Bussiness.DataContracts.Tables.SPChannelFiltersDataContract";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		public static readonly string PROPERTY_NAME_PARAMSNAME = "ParamsName";
		public static readonly string PROPERTY_NAME_FILTERTYPE = "FilterType";
		public static readonly string PROPERTY_NAME_FILTERVALUE = "FilterValue";
		
        #endregion
	
        #region 私有成员变量
		
		private int _id;
		private int? _channelID;
		private string _paramsName;
		private string _filterType;
		private string _filterValue;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPChannelFiltersDataContract()
		{
			_id = 0;
			_channelID = null;
			_paramsName = null;
			_filterType = null;
			_filterValue = null;
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
		public int? ChannelID
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
		public string ParamsName
		{
			get { return _paramsName; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ParamsName", value, value.ToString());
				_paramsName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string FilterType
		{
			get { return _filterType; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for FilterType", value, value.ToString());
				_filterType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string FilterValue
		{
			get { return _filterValue; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for FilterValue", value, value.ToString());
				_filterValue = value;
			}
		}

		
		#endregion 


        public void FromWrapper(SPChannelFiltersWrapper wrapper)
		{
			this.Id = wrapper.Id;
			this.ChannelID = wrapper.ChannelID;
			this.ParamsName = wrapper.ParamsName;
			this.FilterType = wrapper.FilterType;
			this.FilterValue = wrapper.FilterValue;
		}
		
		
		public SPChannelFiltersWrapper ToWrapper()
        {
			SPChannelFiltersWrapper wrapper = new SPChannelFiltersWrapper();
			wrapper.Id = this.Id;
			wrapper.ChannelID = this.ChannelID;
			wrapper.ParamsName = this.ParamsName;
			wrapper.FilterType = this.FilterType;
			wrapper.FilterValue = this.FilterValue;
		
		return wrapper;
        }



   }
}
