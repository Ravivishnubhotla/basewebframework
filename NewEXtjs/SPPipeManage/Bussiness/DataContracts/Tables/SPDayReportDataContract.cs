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
	public class SPDayReportDataContract
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Bussiness.DataContracts.Tables.SPDayReportDataContract";
		public static readonly string PROPERTY_NAME_REPORTID = "ReportID";
		public static readonly string PROPERTY_NAME_REPORTDATE = "ReportDate";
		public static readonly string PROPERTY_NAME_UPTOTALCOUNT = "UpTotalCount";
		public static readonly string PROPERTY_NAME_UPSUCCESS = "UpSuccess";
		public static readonly string PROPERTY_NAME_UPINTERCEPT = "UpIntercept";
		public static readonly string PROPERTY_NAME_DOWNTOTALCOUNT = "DownTotalCount";
		public static readonly string PROPERTY_NAME_DOWNSUCCESS = "DownSuccess";
		public static readonly string PROPERTY_NAME_DOWNINTERCEPT = "DownIntercept";
		public static readonly string PROPERTY_NAME_DAYXMLFILENAME = "DayXmlFileName";
		
        #endregion
	
        #region 私有成员变量
		
		private int _reportID;
		private DateTime? _reportDate;
		private int? _upTotalCount;
		private int? _upSuccess;
		private int? _upIntercept;
		private int? _downTotalCount;
		private int? _downSuccess;
		private int? _downIntercept;
		private string _dayXmlFileName;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPDayReportDataContract()
		{
			_reportID = 0;
			_reportDate = null;
			_upTotalCount = null;
			_upSuccess = null;
			_upIntercept = null;
			_downTotalCount = null;
			_downSuccess = null;
			_downIntercept = null;
			_dayXmlFileName = null;
		}
		#endregion

	    #region 公共属性

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int ReportID
		{
			get { return _reportID; }

			set	
			{
				_reportID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public DateTime? ReportDate
		{
			get { return _reportDate; }

			set	
			{
				_reportDate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? UpTotalCount
		{
			get { return _upTotalCount; }

			set	
			{
				_upTotalCount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? UpSuccess
		{
			get { return _upSuccess; }

			set	
			{
				_upSuccess = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? UpIntercept
		{
			get { return _upIntercept; }

			set	
			{
				_upIntercept = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? DownTotalCount
		{
			get { return _downTotalCount; }

			set	
			{
				_downTotalCount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? DownSuccess
		{
			get { return _downSuccess; }

			set	
			{
				_downSuccess = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? DownIntercept
		{
			get { return _downIntercept; }

			set	
			{
				_downIntercept = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string DayXmlFileName
		{
			get { return _dayXmlFileName; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for DayXmlFileName", value, value.ToString());
				_dayXmlFileName = value;
			}
		}

		
		#endregion 


        public void FromWrapper(SPDayReportWrapper wrapper)
		{
			this.ReportID = wrapper.ReportID;
			this.ReportDate = wrapper.ReportDate;
			this.UpTotalCount = wrapper.UpTotalCount;
			this.UpSuccess = wrapper.UpSuccess;
			this.UpIntercept = wrapper.UpIntercept;
			this.DownTotalCount = wrapper.DownTotalCount;
			this.DownSuccess = wrapper.DownSuccess;
			this.DownIntercept = wrapper.DownIntercept;
			this.DayXmlFileName = wrapper.DayXmlFileName;
		}
		
		
		public SPDayReportWrapper ToWrapper()
        {
			SPDayReportWrapper wrapper = new SPDayReportWrapper();
			wrapper.ReportID = this.ReportID;
			wrapper.ReportDate = this.ReportDate;
			wrapper.UpTotalCount = this.UpTotalCount;
			wrapper.UpSuccess = this.UpSuccess;
			wrapper.UpIntercept = this.UpIntercept;
			wrapper.DownTotalCount = this.DownTotalCount;
			wrapper.DownSuccess = this.DownSuccess;
			wrapper.DownIntercept = this.DownIntercept;
			wrapper.DayXmlFileName = this.DayXmlFileName;
		
		return wrapper;
        }



   }
}
