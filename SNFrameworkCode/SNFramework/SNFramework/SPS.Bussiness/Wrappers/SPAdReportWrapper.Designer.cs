// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
    public partial class SPAdReportWrapper    //: BaseSpringNHibernateWrapper<SPAdReportEntity, ISPAdReportServiceProxy, SPAdReportWrapper,int>
    {
        #region Member

		internal static readonly ISPAdReportServiceProxy businessProxy = ((SPS.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID", typeof(SPS.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)))).SPAdReportServiceProxyInstance;
		
		
		internal SPAdReportEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SPAdReportWrapper() : base(new SPAdReportEntity())
        {
            
        }

        internal SPAdReportWrapper(SPAdReportEntity entityObj)
            : base(entityObj)
        {
        }
		#endregion

        #region Process Column Name
        private static string ProcessColumnName(string columnName)
        {
            switch (columnName)
            {
		        case "SPPackID_Id":
					return PROPERTY_SPPACKID_ID;
		        case "SPPackID_SPAdID":
					return PROPERTY_SPPACKID_SPADID;
		        case "SPPackID_Name":
					return PROPERTY_SPPACKID_NAME;
		        case "SPPackID_Code":
					return PROPERTY_SPPACKID_CODE;
		        case "SPPackID_Description":
					return PROPERTY_SPPACKID_DESCRIPTION;
		        case "SPPackID_AdPrice":
					return PROPERTY_SPPACKID_ADPRICE;
		        case "SPClientID_Id":
					return PROPERTY_SPCLIENTID_ID;
		        case "SPClientID_Name":
					return PROPERTY_SPCLIENTID_NAME;
		        case "SPClientID_Description":
					return PROPERTY_SPCLIENTID_DESCRIPTION;
		        case "SPClientID_UserID":
					return PROPERTY_SPCLIENTID_USERID;
		        case "SPClientID_IsDefaultClient":
					return PROPERTY_SPCLIENTID_ISDEFAULTCLIENT;
		        case "SPClientID_SyncData":
					return PROPERTY_SPCLIENTID_SYNCDATA;
		        case "SPClientID_SycnNotInterceptCount":
					return PROPERTY_SPCLIENTID_SYCNNOTINTERCEPTCOUNT;
		        case "SPClientID_SyncDataSetting":
					return PROPERTY_SPCLIENTID_SYNCDATASETTING;
		        case "SPClientID_Alias":
					return PROPERTY_SPCLIENTID_ALIAS;
		        case "SPClientID_IsEnable":
					return PROPERTY_SPCLIENTID_ISENABLE;
		        case "SPClientID_InterceptRate":
					return PROPERTY_SPCLIENTID_INTERCEPTRATE;
		        case "SPClientID_DefaultPrice":
					return PROPERTY_SPCLIENTID_DEFAULTPRICE;
		        case "SPClientID_DefaultShowRecordDays":
					return PROPERTY_SPCLIENTID_DEFAULTSHOWRECORDDAYS;
		        case "SPClientID_ChannelStatus":
					return PROPERTY_SPCLIENTID_CHANNELSTATUS;
		        case "SPClientID_CreateBy":
					return PROPERTY_SPCLIENTID_CREATEBY;
		        case "SPClientID_CreateAt":
					return PROPERTY_SPCLIENTID_CREATEAT;
		        case "SPClientID_LastModifyBy":
					return PROPERTY_SPCLIENTID_LASTMODIFYBY;
		        case "SPClientID_LastModifyAt":
					return PROPERTY_SPCLIENTID_LASTMODIFYAT;
		        case "SPClientID_LastModifyComment":
					return PROPERTY_SPCLIENTID_LASTMODIFYCOMMENT;
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

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPAdReportEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_SPADID = "SPAdID";
		public static readonly string PROPERTY_NAME_SPPACKID = "SPPackID";
		public static readonly string PROPERTY_NAME_SPCLIENTID = "SPClientID";
		public static readonly string PROPERTY_NAME_REPORTDATE = "ReportDate";
		public static readonly string PROPERTY_NAME_CLIENTCOUNT = "ClientCount";
		public static readonly string PROPERTY_NAME_ADCOUNT = "AdCount";
		public static readonly string PROPERTY_NAME_ADUSECOUNT = "AdUseCount";
		public static readonly string PROPERTY_NAME_ADCLIENTUSECOUNT = "AdClientUseCount";
		public static readonly string PROPERTY_NAME_ADDOWNCOUNT = "AdDownCount";
		public static readonly string PROPERTY_NAME_ADCLIENTDOWNCOUNT = "AdClientDownCount";
		public static readonly string PROPERTY_NAME_ADAMOUNT = "AdAmount";
		public static readonly string PROPERTY_NAME_CLIENTAMOUNT = "ClientAmount";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region sPPackID字段外键查询字段
        public const string PROPERTY_SPPACKID_ALIAS_NAME = "SPPackID_SPAdReportEntity_Alias";
		public const string PROPERTY_SPPACKID_ID = "SPPackID_SPAdReportEntity_Alias.Id";
		public const string PROPERTY_SPPACKID_SPADID = "SPPackID_SPAdReportEntity_Alias.SPAdID";
		public const string PROPERTY_SPPACKID_NAME = "SPPackID_SPAdReportEntity_Alias.Name";
		public const string PROPERTY_SPPACKID_CODE = "SPPackID_SPAdReportEntity_Alias.Code";
		public const string PROPERTY_SPPACKID_DESCRIPTION = "SPPackID_SPAdReportEntity_Alias.Description";
		public const string PROPERTY_SPPACKID_ADPRICE = "SPPackID_SPAdReportEntity_Alias.AdPrice";
		#endregion
		#region sPClientID字段外键查询字段
        public const string PROPERTY_SPCLIENTID_ALIAS_NAME = "SPClientID_SPAdReportEntity_Alias";
		public const string PROPERTY_SPCLIENTID_ID = "SPClientID_SPAdReportEntity_Alias.Id";
		public const string PROPERTY_SPCLIENTID_NAME = "SPClientID_SPAdReportEntity_Alias.Name";
		public const string PROPERTY_SPCLIENTID_DESCRIPTION = "SPClientID_SPAdReportEntity_Alias.Description";
		public const string PROPERTY_SPCLIENTID_USERID = "SPClientID_SPAdReportEntity_Alias.UserID";
		public const string PROPERTY_SPCLIENTID_ISDEFAULTCLIENT = "SPClientID_SPAdReportEntity_Alias.IsDefaultClient";
		public const string PROPERTY_SPCLIENTID_SYNCDATA = "SPClientID_SPAdReportEntity_Alias.SyncData";
		public const string PROPERTY_SPCLIENTID_SYCNNOTINTERCEPTCOUNT = "SPClientID_SPAdReportEntity_Alias.SycnNotInterceptCount";
		public const string PROPERTY_SPCLIENTID_SYNCDATASETTING = "SPClientID_SPAdReportEntity_Alias.SyncDataSetting";
		public const string PROPERTY_SPCLIENTID_ALIAS = "SPClientID_SPAdReportEntity_Alias.Alias";
		public const string PROPERTY_SPCLIENTID_ISENABLE = "SPClientID_SPAdReportEntity_Alias.IsEnable";
		public const string PROPERTY_SPCLIENTID_INTERCEPTRATE = "SPClientID_SPAdReportEntity_Alias.InterceptRate";
		public const string PROPERTY_SPCLIENTID_DEFAULTPRICE = "SPClientID_SPAdReportEntity_Alias.DefaultPrice";
		public const string PROPERTY_SPCLIENTID_DEFAULTSHOWRECORDDAYS = "SPClientID_SPAdReportEntity_Alias.DefaultShowRecordDays";
		public const string PROPERTY_SPCLIENTID_CHANNELSTATUS = "SPClientID_SPAdReportEntity_Alias.ChannelStatus";
		public const string PROPERTY_SPCLIENTID_CREATEBY = "SPClientID_SPAdReportEntity_Alias.CreateBy";
		public const string PROPERTY_SPCLIENTID_CREATEAT = "SPClientID_SPAdReportEntity_Alias.CreateAt";
		public const string PROPERTY_SPCLIENTID_LASTMODIFYBY = "SPClientID_SPAdReportEntity_Alias.LastModifyBy";
		public const string PROPERTY_SPCLIENTID_LASTMODIFYAT = "SPClientID_SPAdReportEntity_Alias.LastModifyAt";
		public const string PROPERTY_SPCLIENTID_LASTMODIFYCOMMENT = "SPClientID_SPAdReportEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		


		#region Public Property
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
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
		[DataMember]
		public int? SPAdID
		{
			get
			{
				return entity.SPAdID;
			}
			set
			{
				entity.SPAdID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public SPAdPackWrapper SPPackID
		{
			get
			{
				return SPAdPackWrapper.ConvertEntityToWrapper(entity.SPPackID) ;
			}
			set
			{
				entity.SPPackID = ((value == null) ? null : value.Entity);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public SPSClientWrapper SPClientID
		{
			get
			{
				return SPSClientWrapper.ConvertEntityToWrapper(entity.SPClientID) ;
			}
			set
			{
				entity.SPClientID = ((value == null) ? null : value.Entity);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public DateTime? ReportDate
		{
			get
			{
				return entity.ReportDate;
			}
			set
			{
				entity.ReportDate = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? ClientCount
		{
			get
			{
				return entity.ClientCount;
			}
			set
			{
				entity.ClientCount = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? AdCount
		{
			get
			{
				return entity.AdCount;
			}
			set
			{
				entity.AdCount = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? AdUseCount
		{
			get
			{
				return entity.AdUseCount;
			}
			set
			{
				entity.AdUseCount = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? AdClientUseCount
		{
			get
			{
				return entity.AdClientUseCount;
			}
			set
			{
				entity.AdClientUseCount = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? AdDownCount
		{
			get
			{
				return entity.AdDownCount;
			}
			set
			{
				entity.AdDownCount = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? AdClientDownCount
		{
			get
			{
				return entity.AdClientDownCount;
			}
			set
			{
				entity.AdClientDownCount = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public decimal? AdAmount
		{
			get
			{
				return entity.AdAmount;
			}
			set
			{
				entity.AdAmount = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public decimal? ClientAmount
		{
			get
			{
				return entity.ClientAmount;
			}
			set
			{
				entity.ClientAmount = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int CreateBy
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
		[DataMember]
		public DateTime CreateAt
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
		[DataMember]
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
		[DataMember]
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
		[DataMember]
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
		
		
		#region sPPackID字段外键查询字段
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPPACKID_ID)]
        public int? SPPackID_Id
        {
            get
            {
                if (this. SPPackID == null)
                    return null;
                return  SPPackID.Id;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPPACKID_SPADID)]
        public SPAdvertisementWrapper SPPackID_SPAdID
        {
            get
            {
                if (this. SPPackID == null)
                    return null;
                return  SPPackID.SPAdID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPPACKID_NAME)]
        public string SPPackID_Name
        {
            get
            {
                if (this. SPPackID == null)
                    return null;
                return  SPPackID.Name;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPPACKID_CODE)]
        public string SPPackID_Code
        {
            get
            {
                if (this. SPPackID == null)
                    return null;
                return  SPPackID.Code;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPPACKID_DESCRIPTION)]
        public string SPPackID_Description
        {
            get
            {
                if (this. SPPackID == null)
                    return null;
                return  SPPackID.Description;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPPACKID_ADPRICE)]
        public decimal? SPPackID_AdPrice
        {
            get
            {
                if (this. SPPackID == null)
                    return null;
                return  SPPackID.AdPrice;
            }
        }
		#endregion
		#region sPClientID字段外键查询字段
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPCLIENTID_ID)]
        public int? SPClientID_Id
        {
            get
            {
                if (this. SPClientID == null)
                    return null;
                return  SPClientID.Id;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPCLIENTID_NAME)]
        public string SPClientID_Name
        {
            get
            {
                if (this. SPClientID == null)
                    return null;
                return  SPClientID.Name;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPCLIENTID_DESCRIPTION)]
        public string SPClientID_Description
        {
            get
            {
                if (this. SPClientID == null)
                    return null;
                return  SPClientID.Description;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPCLIENTID_USERID)]
        public int? SPClientID_UserID
        {
            get
            {
                if (this. SPClientID == null)
                    return null;
                return  SPClientID.UserID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPCLIENTID_ISDEFAULTCLIENT)]
        public bool? SPClientID_IsDefaultClient
        {
            get
            {
                if (this. SPClientID == null)
                    return null;
                return  SPClientID.IsDefaultClient;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPCLIENTID_SYNCDATA)]
        public bool? SPClientID_SyncData
        {
            get
            {
                if (this. SPClientID == null)
                    return null;
                return  SPClientID.SyncData;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPCLIENTID_SYCNNOTINTERCEPTCOUNT)]
        public int? SPClientID_SycnNotInterceptCount
        {
            get
            {
                if (this. SPClientID == null)
                    return null;
                return  SPClientID.SycnNotInterceptCount;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPCLIENTID_SYNCDATASETTING)]
        public SPSDataSycnSettingWrapper SPClientID_SyncDataSetting
        {
            get
            {
                if (this. SPClientID == null)
                    return null;
                return  SPClientID.SyncDataSetting;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPCLIENTID_ALIAS)]
        public string SPClientID_Alias
        {
            get
            {
                if (this. SPClientID == null)
                    return null;
                return  SPClientID.Alias;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPCLIENTID_ISENABLE)]
        public bool? SPClientID_IsEnable
        {
            get
            {
                if (this. SPClientID == null)
                    return null;
                return  SPClientID.IsEnable;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPCLIENTID_INTERCEPTRATE)]
        public decimal? SPClientID_InterceptRate
        {
            get
            {
                if (this. SPClientID == null)
                    return null;
                return  SPClientID.InterceptRate;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPCLIENTID_DEFAULTPRICE)]
        public decimal? SPClientID_DefaultPrice
        {
            get
            {
                if (this. SPClientID == null)
                    return null;
                return  SPClientID.DefaultPrice;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPCLIENTID_DEFAULTSHOWRECORDDAYS)]
        public int? SPClientID_DefaultShowRecordDays
        {
            get
            {
                if (this. SPClientID == null)
                    return null;
                return  SPClientID.DefaultShowRecordDays;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPCLIENTID_CHANNELSTATUS)]
        public string SPClientID_ChannelStatus
        {
            get
            {
                if (this. SPClientID == null)
                    return null;
                return  SPClientID.ChannelStatus;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPCLIENTID_CREATEBY)]
        public int? SPClientID_CreateBy
        {
            get
            {
                if (this. SPClientID == null)
                    return null;
                return  SPClientID.CreateBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPCLIENTID_CREATEAT)]
        public DateTime? SPClientID_CreateAt
        {
            get
            {
                if (this. SPClientID == null)
                    return null;
                return  SPClientID.CreateAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPCLIENTID_LASTMODIFYBY)]
        public int? SPClientID_LastModifyBy
        {
            get
            {
                if (this. SPClientID == null)
                    return null;
                return  SPClientID.LastModifyBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPCLIENTID_LASTMODIFYAT)]
        public DateTime? SPClientID_LastModifyAt
        {
            get
            {
                if (this. SPClientID == null)
                    return null;
                return  SPClientID.LastModifyAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SPCLIENTID_LASTMODIFYCOMMENT)]
        public string SPClientID_LastModifyComment
        {
            get
            {
                if (this. SPClientID == null)
                    return null;
                return  SPClientID.LastModifyComment;
            }
        }
		#endregion
      	
   
		#endregion


        #region "FKQuery"
		
        public static List<SPAdReportWrapper> FindAllByOrderByAndFilterAndSPPackID(string orderByColumnName, bool isDesc,   SPAdPackWrapper sPPackID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndSPPackID(orderByColumnName, isDesc,   sPPackID.Entity, pageQueryParams));
        }

        public static List<SPAdReportWrapper> FindAllBySPPackID(SPAdPackWrapper sPPackID)
        {
            return ConvertToWrapperList(businessProxy.FindAllBySPPackID(sPPackID.Entity));
        }
		
		
        public static List<SPAdReportWrapper> FindAllByOrderByAndFilterAndSPClientID(string orderByColumnName, bool isDesc,   SPSClientWrapper sPClientID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndSPClientID(orderByColumnName, isDesc,   sPClientID.Entity, pageQueryParams));
        }

        public static List<SPAdReportWrapper> FindAllBySPClientID(SPSClientWrapper sPClientID)
        {
            return ConvertToWrapperList(businessProxy.FindAllBySPClientID(sPClientID.Entity));
        }
		



        #endregion








        #region Static Common Data Operation
		
		internal static List<SPAdReportWrapper> ConvertToWrapperList(List<SPAdReportEntity> entitylist)
        {
            List<SPAdReportWrapper> list = new List<SPAdReportWrapper>();
            foreach (SPAdReportEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SPAdReportWrapper> ConvertToWrapperList(IList<SPAdReportEntity> entitylist)
        {
            List<SPAdReportWrapper> list = new List<SPAdReportWrapper>();
            foreach (SPAdReportEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SPAdReportEntity> ConvertToEntityList(List<SPAdReportWrapper> wrapperlist)
        {
            List<SPAdReportEntity> list = new List<SPAdReportEntity>();
            foreach (SPAdReportWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SPAdReportWrapper ConvertEntityToWrapper(SPAdReportEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SPAdReportWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

