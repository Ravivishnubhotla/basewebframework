// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Spring.Context.Support;
using Common.Logging;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables.Container;
using SPS.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;

namespace SPS.Bussiness.Wrappers
{
    public partial class SPCodeWrapper   
    {
        #region Member

		internal static readonly ISPCodeServiceProxy businessProxy = ((SPS.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID", typeof(SPS.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)))).SPCodeServiceProxyInstance;
		
		
		internal SPCodeEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SPCodeWrapper() : base(new SPCodeEntity())
        {
            
        }

        internal SPCodeWrapper(SPCodeEntity entityObj)
            : base(entityObj)
        {
        }
		#endregion

        #region Process Column Name
        private static string ProcessColumnName(string columnName)
        {
            switch (columnName)
            {
		        case "ChannelID_Id":
					return PROPERTY_CHANNELID_ID;
		        case "ChannelID_Name":
					return PROPERTY_CHANNELID_NAME;
		        case "ChannelID_Code":
					return PROPERTY_CHANNELID_CODE;
		        case "ChannelID_DataOkMessage":
					return PROPERTY_CHANNELID_DATAOKMESSAGE;
		        case "ChannelID_DataFailedMessage":
					return PROPERTY_CHANNELID_DATAFAILEDMESSAGE;
		        case "ChannelID_Description":
					return PROPERTY_CHANNELID_DESCRIPTION;
		        case "ChannelID_DataAdapterType":
					return PROPERTY_CHANNELID_DATAADAPTERTYPE;
		        case "ChannelID_DataAdapterUrl":
					return PROPERTY_CHANNELID_DATAADAPTERURL;
		        case "ChannelID_ChannelType":
					return PROPERTY_CHANNELID_CHANNELTYPE;
		        case "ChannelID_IVRFeeTimeType":
					return PROPERTY_CHANNELID_IVRFEETIMETYPE;
		        case "ChannelID_IVRTimeFormat":
					return PROPERTY_CHANNELID_IVRTIMEFORMAT;
		        case "ChannelID_IsStateReport":
					return PROPERTY_CHANNELID_ISSTATEREPORT;
		        case "ChannelID_StateReportType":
					return PROPERTY_CHANNELID_STATEREPORTTYPE;
		        case "ChannelID_ReportOkMessage":
					return PROPERTY_CHANNELID_REPORTOKMESSAGE;
		        case "ChannelID_ReportFailedMessage":
					return PROPERTY_CHANNELID_REPORTFAILEDMESSAGE;
		        case "ChannelID_StateReportParamName":
					return PROPERTY_CHANNELID_STATEREPORTPARAMNAME;
		        case "ChannelID_StateReportParamValue":
					return PROPERTY_CHANNELID_STATEREPORTPARAMVALUE;
		        case "ChannelID_RequestTypeParamName":
					return PROPERTY_CHANNELID_REQUESTTYPEPARAMNAME;
		        case "ChannelID_RequestTypeParamStateReportValue":
					return PROPERTY_CHANNELID_REQUESTTYPEPARAMSTATEREPORTVALUE;
		        case "ChannelID_RequestTypeParamDataReportValue":
					return PROPERTY_CHANNELID_REQUESTTYPEPARAMDATAREPORTVALUE;
		        case "ChannelID_HasFilters":
					return PROPERTY_CHANNELID_HASFILTERS;
		        case "ChannelID_IsMonitorRequest":
					return PROPERTY_CHANNELID_ISMONITORREQUEST;
		        case "ChannelID_IsLogRequest":
					return PROPERTY_CHANNELID_ISLOGREQUEST;
		        case "ChannelID_IsParamsConvert":
					return PROPERTY_CHANNELID_ISPARAMSCONVERT;
		        case "ChannelID_IsAutoLinkID":
					return PROPERTY_CHANNELID_ISAUTOLINKID;
		        case "ChannelID_AutoLinkIDFields":
					return PROPERTY_CHANNELID_AUTOLINKIDFIELDS;
		        case "ChannelID_LogRequestType":
					return PROPERTY_CHANNELID_LOGREQUESTTYPE;
		        case "ChannelID_Price":
					return PROPERTY_CHANNELID_PRICE;
		        case "ChannelID_DefaultRate":
					return PROPERTY_CHANNELID_DEFAULTRATE;
		        case "ChannelID_ChannelDetailInfo":
					return PROPERTY_CHANNELID_CHANNELDETAILINFO;
		        case "ChannelID_UpperID":
					return PROPERTY_CHANNELID_UPPERID;
		        case "ChannelID_ChannelStatus":
					return PROPERTY_CHANNELID_CHANNELSTATUS;
		        case "ChannelID_IsDisable":
					return PROPERTY_CHANNELID_ISDISABLE;
		        case "ChannelID_CreateBy":
					return PROPERTY_CHANNELID_CREATEBY;
		        case "ChannelID_CreateAt":
					return PROPERTY_CHANNELID_CREATEAT;
		        case "ChannelID_LastModifyBy":
					return PROPERTY_CHANNELID_LASTMODIFYBY;
		        case "ChannelID_LastModifyAt":
					return PROPERTY_CHANNELID_LASTMODIFYAT;
		        case "ChannelID_LastModifyComment":
					return PROPERTY_CHANNELID_LASTMODIFYCOMMENT;
              default:
                    return columnName;
            }
        }

        private static void ProcessQueryFilters(List<QueryFilter> filters)
        {
            foreach (QueryFilter queryFilter in filters)
            {
                queryFilter.FilterFieldName = ProcessColumnName(queryFilter.FilterFieldName);
            }
        }
		#endregion
		
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPCodeEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_CODE = "Code";
		public static readonly string PROPERTY_NAME_CODETYPE = "CodeType";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		public static readonly string PROPERTY_NAME_MO = "Mo";
		public static readonly string PROPERTY_NAME_MOTYPE = "MOType";
		public static readonly string PROPERTY_NAME_MOLENGTH = "MOLength";
		public static readonly string PROPERTY_NAME_ORDERINDEX = "OrderIndex";
		public static readonly string PROPERTY_NAME_SPCODE = "SPCode";
		public static readonly string PROPERTY_NAME_SPCODETYPE = "SPCodeType";
		public static readonly string PROPERTY_NAME_SPCODELENGTH = "SPCodeLength";
		public static readonly string PROPERTY_NAME_HASFILTERS = "HasFilters";
		public static readonly string PROPERTY_NAME_HASPARAMSCONVERT = "HasParamsConvert";
		public static readonly string PROPERTY_NAME_PROVINCE = "Province";
		public static readonly string PROPERTY_NAME_DISABLECITY = "DisableCity";
		public static readonly string PROPERTY_NAME_ISDIABLE = "IsDiable";
		public static readonly string PROPERTY_NAME_DAYLIMIT = "DayLimit";
		public static readonly string PROPERTY_NAME_MONTHLIMIT = "MonthLimit";
		public static readonly string PROPERTY_NAME_PRICE = "Price";
		public static readonly string PROPERTY_NAME_SENDTEXT = "SendText";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region channelID字段外键查询字段
        public const string PROPERTY_CHANNELID_ALIAS_NAME = "ChannelID_SPCodeEntity_Alias";
		public const string PROPERTY_CHANNELID_ID = "ChannelID_SPCodeEntity_Alias.Id";
		public const string PROPERTY_CHANNELID_NAME = "ChannelID_SPCodeEntity_Alias.Name";
		public const string PROPERTY_CHANNELID_CODE = "ChannelID_SPCodeEntity_Alias.Code";
		public const string PROPERTY_CHANNELID_DATAOKMESSAGE = "ChannelID_SPCodeEntity_Alias.DataOkMessage";
		public const string PROPERTY_CHANNELID_DATAFAILEDMESSAGE = "ChannelID_SPCodeEntity_Alias.DataFailedMessage";
		public const string PROPERTY_CHANNELID_DESCRIPTION = "ChannelID_SPCodeEntity_Alias.Description";
		public const string PROPERTY_CHANNELID_DATAADAPTERTYPE = "ChannelID_SPCodeEntity_Alias.DataAdapterType";
		public const string PROPERTY_CHANNELID_DATAADAPTERURL = "ChannelID_SPCodeEntity_Alias.DataAdapterUrl";
		public const string PROPERTY_CHANNELID_CHANNELTYPE = "ChannelID_SPCodeEntity_Alias.ChannelType";
		public const string PROPERTY_CHANNELID_IVRFEETIMETYPE = "ChannelID_SPCodeEntity_Alias.IVRFeeTimeType";
		public const string PROPERTY_CHANNELID_IVRTIMEFORMAT = "ChannelID_SPCodeEntity_Alias.IVRTimeFormat";
		public const string PROPERTY_CHANNELID_ISSTATEREPORT = "ChannelID_SPCodeEntity_Alias.IsStateReport";
		public const string PROPERTY_CHANNELID_STATEREPORTTYPE = "ChannelID_SPCodeEntity_Alias.StateReportType";
		public const string PROPERTY_CHANNELID_REPORTOKMESSAGE = "ChannelID_SPCodeEntity_Alias.ReportOkMessage";
		public const string PROPERTY_CHANNELID_REPORTFAILEDMESSAGE = "ChannelID_SPCodeEntity_Alias.ReportFailedMessage";
		public const string PROPERTY_CHANNELID_STATEREPORTPARAMNAME = "ChannelID_SPCodeEntity_Alias.StateReportParamName";
		public const string PROPERTY_CHANNELID_STATEREPORTPARAMVALUE = "ChannelID_SPCodeEntity_Alias.StateReportParamValue";
		public const string PROPERTY_CHANNELID_REQUESTTYPEPARAMNAME = "ChannelID_SPCodeEntity_Alias.RequestTypeParamName";
		public const string PROPERTY_CHANNELID_REQUESTTYPEPARAMSTATEREPORTVALUE = "ChannelID_SPCodeEntity_Alias.RequestTypeParamStateReportValue";
		public const string PROPERTY_CHANNELID_REQUESTTYPEPARAMDATAREPORTVALUE = "ChannelID_SPCodeEntity_Alias.RequestTypeParamDataReportValue";
		public const string PROPERTY_CHANNELID_HASFILTERS = "ChannelID_SPCodeEntity_Alias.HasFilters";
		public const string PROPERTY_CHANNELID_ISMONITORREQUEST = "ChannelID_SPCodeEntity_Alias.IsMonitorRequest";
		public const string PROPERTY_CHANNELID_ISLOGREQUEST = "ChannelID_SPCodeEntity_Alias.IsLogRequest";
		public const string PROPERTY_CHANNELID_ISPARAMSCONVERT = "ChannelID_SPCodeEntity_Alias.IsParamsConvert";
		public const string PROPERTY_CHANNELID_ISAUTOLINKID = "ChannelID_SPCodeEntity_Alias.IsAutoLinkID";
		public const string PROPERTY_CHANNELID_AUTOLINKIDFIELDS = "ChannelID_SPCodeEntity_Alias.AutoLinkIDFields";
		public const string PROPERTY_CHANNELID_LOGREQUESTTYPE = "ChannelID_SPCodeEntity_Alias.LogRequestType";
		public const string PROPERTY_CHANNELID_PRICE = "ChannelID_SPCodeEntity_Alias.Price";
		public const string PROPERTY_CHANNELID_DEFAULTRATE = "ChannelID_SPCodeEntity_Alias.DefaultRate";
		public const string PROPERTY_CHANNELID_CHANNELDETAILINFO = "ChannelID_SPCodeEntity_Alias.ChannelDetailInfo";
		public const string PROPERTY_CHANNELID_UPPERID = "ChannelID_SPCodeEntity_Alias.UpperID";
		public const string PROPERTY_CHANNELID_CHANNELSTATUS = "ChannelID_SPCodeEntity_Alias.ChannelStatus";
		public const string PROPERTY_CHANNELID_ISDISABLE = "ChannelID_SPCodeEntity_Alias.IsDisable";
		public const string PROPERTY_CHANNELID_CREATEBY = "ChannelID_SPCodeEntity_Alias.CreateBy";
		public const string PROPERTY_CHANNELID_CREATEAT = "ChannelID_SPCodeEntity_Alias.CreateAt";
		public const string PROPERTY_CHANNELID_LASTMODIFYBY = "ChannelID_SPCodeEntity_Alias.LastModifyBy";
		public const string PROPERTY_CHANNELID_LASTMODIFYAT = "ChannelID_SPCodeEntity_Alias.LastModifyAt";
		public const string PROPERTY_CHANNELID_LASTMODIFYCOMMENT = "ChannelID_SPCodeEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		


		#region Public Property
		/// <summary>
		/// 
		/// </summary>		
		public int Id
		{
			get
			{
				return entity.Id;
			}
			set
			{
				entity.Id = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Name
		{
			get
			{
				return entity.Name;
			}
			set
			{
				entity.Name = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Description
		{
			get
			{
				return entity.Description;
			}
			set
			{
				entity.Description = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Code
		{
			get
			{
				return entity.Code;
			}
			set
			{
				entity.Code = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string CodeType
		{
			get
			{
				return entity.CodeType;
			}
			set
			{
				entity.CodeType = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public SPChannelWrapper ChannelID
		{
			get
			{
				return SPChannelWrapper.ConvertEntityToWrapper(entity.ChannelID) ;
			}
			set
			{
				entity.ChannelID = ((value == null) ? null : value.Entity);
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Mo
		{
			get
			{
				return entity.Mo;
			}
			set
			{
				entity.Mo = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string MOType
		{
			get
			{
				return entity.MOType;
			}
			set
			{
				entity.MOType = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? MOLength
		{
			get
			{
				return entity.MOLength;
			}
			set
			{
				entity.MOLength = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int OrderIndex
		{
			get
			{
				return entity.OrderIndex;
			}
			set
			{
				entity.OrderIndex = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string SPCode
		{
			get
			{
				return entity.SPCode;
			}
			set
			{
				entity.SPCode = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string SPCodeType
		{
			get
			{
				return entity.SPCodeType;
			}
			set
			{
				entity.SPCodeType = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? SPCodeLength
		{
			get
			{
				return entity.SPCodeLength;
			}
			set
			{
				entity.SPCodeLength = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool HasFilters
		{
			get
			{
				return entity.HasFilters;
			}
			set
			{
				entity.HasFilters = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool HasParamsConvert
		{
			get
			{
				return entity.HasParamsConvert;
			}
			set
			{
				entity.HasParamsConvert = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Province
		{
			get
			{
				return entity.Province;
			}
			set
			{
				entity.Province = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string DisableCity
		{
			get
			{
				return entity.DisableCity;
			}
			set
			{
				entity.DisableCity = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool IsDiable
		{
			get
			{
				return entity.IsDiable;
			}
			set
			{
				entity.IsDiable = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string DayLimit
		{
			get
			{
				return entity.DayLimit;
			}
			set
			{
				entity.DayLimit = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string MonthLimit
		{
			get
			{
				return entity.MonthLimit;
			}
			set
			{
				entity.MonthLimit = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public decimal? Price
		{
			get
			{
				return entity.Price;
			}
			set
			{
				entity.Price = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string SendText
		{
			get
			{
				return entity.SendText;
			}
			set
			{
				entity.SendText = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? CreateBy
		{
			get
			{
				return entity.CreateBy;
			}
			set
			{
				entity.CreateBy = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public DateTime? CreateAt
		{
			get
			{
				return entity.CreateAt;
			}
			set
			{
				entity.CreateAt = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? LastModifyBy
		{
			get
			{
				return entity.LastModifyBy;
			}
			set
			{
				entity.LastModifyBy = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public DateTime? LastModifyAt
		{
			get
			{
				return entity.LastModifyAt;
			}
			set
			{
				entity.LastModifyAt = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string LastModifyComment
		{
			get
			{
				return entity.LastModifyComment;
			}
			set
			{
				entity.LastModifyComment = value;
			}
		}
		#endregion 


		#region Query Property
		
		
		#region channelID字段外键查询字段
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_ID)]
        public int? ChannelID_Id
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.Id;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_NAME)]
        public string ChannelID_Name
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.Name;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_CODE)]
        public string ChannelID_Code
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.Code;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_DATAOKMESSAGE)]
        public string ChannelID_DataOkMessage
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.DataOkMessage;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_DATAFAILEDMESSAGE)]
        public string ChannelID_DataFailedMessage
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.DataFailedMessage;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_DESCRIPTION)]
        public string ChannelID_Description
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.Description;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_DATAADAPTERTYPE)]
        public string ChannelID_DataAdapterType
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.DataAdapterType;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_DATAADAPTERURL)]
        public string ChannelID_DataAdapterUrl
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.DataAdapterUrl;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_CHANNELTYPE)]
        public string ChannelID_ChannelType
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.ChannelType;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_IVRFEETIMETYPE)]
        public string ChannelID_IVRFeeTimeType
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.IVRFeeTimeType;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_IVRTIMEFORMAT)]
        public string ChannelID_IVRTimeFormat
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.IVRTimeFormat;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_ISSTATEREPORT)]
        public bool? ChannelID_IsStateReport
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.IsStateReport;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_STATEREPORTTYPE)]
        public string ChannelID_StateReportType
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.StateReportType;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_REPORTOKMESSAGE)]
        public string ChannelID_ReportOkMessage
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.ReportOkMessage;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_REPORTFAILEDMESSAGE)]
        public string ChannelID_ReportFailedMessage
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.ReportFailedMessage;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_STATEREPORTPARAMNAME)]
        public string ChannelID_StateReportParamName
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.StateReportParamName;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_STATEREPORTPARAMVALUE)]
        public string ChannelID_StateReportParamValue
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.StateReportParamValue;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_REQUESTTYPEPARAMNAME)]
        public string ChannelID_RequestTypeParamName
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.RequestTypeParamName;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_REQUESTTYPEPARAMSTATEREPORTVALUE)]
        public string ChannelID_RequestTypeParamStateReportValue
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.RequestTypeParamStateReportValue;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_REQUESTTYPEPARAMDATAREPORTVALUE)]
        public string ChannelID_RequestTypeParamDataReportValue
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.RequestTypeParamDataReportValue;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_HASFILTERS)]
        public bool? ChannelID_HasFilters
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.HasFilters;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_ISMONITORREQUEST)]
        public bool? ChannelID_IsMonitorRequest
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.IsMonitorRequest;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_ISLOGREQUEST)]
        public bool? ChannelID_IsLogRequest
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.IsLogRequest;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_ISPARAMSCONVERT)]
        public bool? ChannelID_IsParamsConvert
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.IsParamsConvert;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_ISAUTOLINKID)]
        public bool? ChannelID_IsAutoLinkID
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.IsAutoLinkID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_AUTOLINKIDFIELDS)]
        public string ChannelID_AutoLinkIDFields
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.AutoLinkIDFields;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_LOGREQUESTTYPE)]
        public string ChannelID_LogRequestType
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.LogRequestType;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_PRICE)]
        public decimal? ChannelID_Price
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.Price;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_DEFAULTRATE)]
        public decimal? ChannelID_DefaultRate
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.DefaultRate;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_CHANNELDETAILINFO)]
        public string ChannelID_ChannelDetailInfo
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.ChannelDetailInfo;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_UPPERID)]
        public SPUpperWrapper ChannelID_UpperID
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.UpperID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_CHANNELSTATUS)]
        public string ChannelID_ChannelStatus
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.ChannelStatus;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_ISDISABLE)]
        public bool? ChannelID_IsDisable
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.IsDisable;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_CREATEBY)]
        public int? ChannelID_CreateBy
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.CreateBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_CREATEAT)]
        public DateTime? ChannelID_CreateAt
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.CreateAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_LASTMODIFYBY)]
        public int? ChannelID_LastModifyBy
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.LastModifyBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_LASTMODIFYAT)]
        public DateTime? ChannelID_LastModifyAt
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.LastModifyAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CHANNELID_LASTMODIFYCOMMENT)]
        public string ChannelID_LastModifyComment
        {
            get
            {
                if (this. ChannelID == null)
                    return null;
                return  ChannelID.LastModifyComment;
            }
        }
		#endregion
      	
   
		#endregion


        #region "FKQuery"
		
        public static List<SPCodeWrapper> FindAllByOrderByAndFilterAndChannelID(string orderByColumnName, bool isDesc,   SPChannelWrapper channelID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndChannelID(orderByColumnName, isDesc,   channelID.Entity, pageQueryParams));
        }

        public static List<SPCodeWrapper> FindAllByChannelID(SPChannelWrapper channelID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByChannelID(channelID.Entity));
        }
		



        #endregion








        #region Static Common Data Operation
		
		internal static List<SPCodeWrapper> ConvertToWrapperList(List<SPCodeEntity> entitylist)
        {
            List<SPCodeWrapper> list = new List<SPCodeWrapper>();
            foreach (SPCodeEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SPCodeWrapper> ConvertToWrapperList(IList<SPCodeEntity> entitylist)
        {
            List<SPCodeWrapper> list = new List<SPCodeWrapper>();
            foreach (SPCodeEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SPCodeEntity> ConvertToEntityList(List<SPCodeWrapper> wrapperlist)
        {
            List<SPCodeEntity> list = new List<SPCodeEntity>();
            foreach (SPCodeWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SPCodeWrapper ConvertEntityToWrapper(SPCodeEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SPCodeWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

