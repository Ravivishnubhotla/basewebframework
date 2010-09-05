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
	public class SPStatReportDataContract
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Bussiness.DataContracts.Tables.SPStatReportDataContract";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		public static readonly string PROPERTY_NAME_STAT = "Stat";
		public static readonly string PROPERTY_NAME_LINKID = "LinkID";
		public static readonly string PROPERTY_NAME_QUERYSTRING = "QueryString";
		public static readonly string PROPERTY_NAME_REQUESTCONTENT = "RequestContent";
		public static readonly string PROPERTY_NAME_CREATEDATE = "CreateDate";
		
        #endregion
	
        #region 私有成员变量
		
		private int _id;
		private int _channelID;
		private string _stat;
		private string _linkID;
		private string _queryString;
		private string _requestContent;
		private DateTime? _createDate;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPStatReportDataContract()
		{
			_id = 0;
			_channelID = 0;
			_stat = null;
			_linkID = null;
			_queryString = null;
			_requestContent = null;
			_createDate = null;
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
		public string Stat
		{
			get { return _stat; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Stat", value, value.ToString());
				_stat = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string LinkID
		{
			get { return _linkID; }

			set	
			{

				if( value != null && value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for LinkID", value, value.ToString());
				_linkID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string QueryString
		{
			get { return _queryString; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for QueryString", value, value.ToString());
				_queryString = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string RequestContent
		{
			get { return _requestContent; }

			set	
			{

				if( value != null && value.Length > 2147483646)
					throw new ArgumentOutOfRangeException("Invalid value for RequestContent", value, value.ToString());
				_requestContent = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public DateTime? CreateDate
		{
			get { return _createDate; }

			set	
			{
				_createDate = value;
			}
		}

		
		#endregion 


        public void FromWrapper(SPStatReportWrapper wrapper)
		{
			this.Id = wrapper.Id;
			this.ChannelID = wrapper.ChannelID;
			this.Stat = wrapper.Stat;
			this.LinkID = wrapper.LinkID;
			this.QueryString = wrapper.QueryString;
			this.RequestContent = wrapper.RequestContent;
			this.CreateDate = wrapper.CreateDate;
		}
		
		
		public SPStatReportWrapper ToWrapper()
        {
			SPStatReportWrapper wrapper = new SPStatReportWrapper();
			wrapper.Id = this.Id;
			wrapper.ChannelID = this.ChannelID;
			wrapper.Stat = this.Stat;
			wrapper.LinkID = this.LinkID;
			wrapper.QueryString = this.QueryString;
			wrapper.RequestContent = this.RequestContent;
			wrapper.CreateDate = this.CreateDate;
		
		return wrapper;
        }



   }
}
