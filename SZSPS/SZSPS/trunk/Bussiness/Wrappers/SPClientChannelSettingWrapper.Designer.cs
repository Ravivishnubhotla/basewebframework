// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Spring.Context.Support;
using Common.Logging;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables.Container;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;

namespace LD.SPPipeManage.Bussiness.Wrappers
{
    public partial class SPClientChannelSettingWrapper
    {
        #region Member

		internal static readonly ISPClientChannelSettingServiceProxy businessProxy = ((LD.SPPipeManage.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID", typeof(LD.SPPipeManage.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)))).SPClientChannelSettingServiceProxyInstance;
		//internal static readonly ISPClientChannelSettingServiceProxy businessProxy = ((ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID"))).SPClientChannelSettingServiceProxyInstance;

        internal SPClientChannelSettingEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SPClientChannelSettingWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SPClientChannelSettingWrapper() : this(new SPClientChannelSettingEntity())
        {
            
        }

        internal SPClientChannelSettingWrapper(SPClientChannelSettingEntity entityObj)
        {
            entity = entityObj;
        }
		#endregion
		
		#region Equals 和 HashCode 方法覆盖
		public override bool Equals(object obj)
        {
            if (obj == null && entity!=null)
            {
                if (entity.Id == 0)
                    return true;

                return false;
            }
            return entity.Equals(obj);
        }

        public override int GetHashCode()
        {
            return entity.GetHashCode();
        }
		#endregion
		
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Entity.Tables.SPClientChannelSettingEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		public static readonly string PROPERTY_NAME_CLINETID = "ClinetID";
		public static readonly string PROPERTY_NAME_INTERCEPTRATE = "InterceptRate";
		public static readonly string PROPERTY_NAME_UPRATE = "UpRate";
		public static readonly string PROPERTY_NAME_DOWNRATE = "DownRate";
		public static readonly string PROPERTY_NAME_COMMANDTYPE = "CommandType";
		public static readonly string PROPERTY_NAME_COMMANDCODE = "CommandCode";
		public static readonly string PROPERTY_NAME_DISABLE = "Disable";
		public static readonly string PROPERTY_NAME_COMMANDCOLUMN = "CommandColumn";
		public static readonly string PROPERTY_NAME_INTERCEPTRATETYPE = "InterceptRateType";
		public static readonly string PROPERTY_NAME_SYNCDATA = "SyncData";
		public static readonly string PROPERTY_NAME_SYNCDATAURL = "SyncDataUrl";
		public static readonly string PROPERTY_NAME_OKMESSAGE = "OkMessage";
		public static readonly string PROPERTY_NAME_FAILEDMESSAGE = "FailedMessage";
		public static readonly string PROPERTY_NAME_SYNCTYPE = "SyncType";
		public static readonly string PROPERTY_NAME_ORDERINDEX = "OrderIndex";
		public static readonly string PROPERTY_NAME_CHANNELCODE = "ChannelCode";
		public static readonly string PROPERTY_NAME_ALLOWFILTER = "AllowFilter";
		public static readonly string PROPERTY_NAME_ALLOWANDDISABLEAREA = "AllowAndDisableArea";
		public static readonly string PROPERTY_NAME_SETTLEMENTPERIOD = "SettlementPeriod";
		public static readonly string PROPERTY_NAME_DAYLIMIT = "DayLimit";
		public static readonly string PROPERTY_NAME_MONTHLIMIT = "MonthLimit";
		public static readonly string PROPERTY_NAME_SENDTEXT = "SendText";
		public static readonly string PROPERTY_NAME_GETWAY = "Getway";
		public static readonly string PROPERTY_NAME_DEFAULTNOINTERCEPTCOUNT = "DefaultNoInterceptCount";
		public static readonly string PROPERTY_NAME_HASDAYMONTHLIMIT = "HasDayMonthLimit";
		public static readonly string PROPERTY_NAME_DAYLIMITCOUNT = "DayLimitCount";
		public static readonly string PROPERTY_NAME_MONTHLIMITCOUNT = "MonthLimitCount";
		public static readonly string PROPERTY_NAME_HASDAYTOTALLIMIT = "HasDayTotalLimit";
		public static readonly string PROPERTY_NAME_DAYTOTALLIMIT = "DayTotalLimit";
		public static readonly string PROPERTY_NAME_DAYTOTALLIMITINPROVINCE = "DayTotalLimitInProvince";
		public static readonly string PROPERTY_NAME_DAYTOTALLIMITINPROVINCEASSIGNEDCOUNT = "DayTotalLimitInProvinceAssignedCount";
		
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
		public SPChannelWrapper ChannelID
		{
			get
			{
				return SPChannelWrapper.ConvertEntityToWrapper(entity.ChannelID) ;
			}
			set
			{
				entity.ChannelID = ((value == null) ? null : value.entity);
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public SPClientWrapper ClinetID
		{
			get
			{
				return SPClientWrapper.ConvertEntityToWrapper(entity.ClinetID) ;
			}
			set
			{
				entity.ClinetID = ((value == null) ? null : value.entity);
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? InterceptRate
		{
			get
			{
				return entity.InterceptRate;
			}
			set
			{
				entity.InterceptRate = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? UpRate
		{
			get
			{
				return entity.UpRate;
			}
			set
			{
				entity.UpRate = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? DownRate
		{
			get
			{
				return entity.DownRate;
			}
			set
			{
				entity.DownRate = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string CommandType
		{
			get
			{
				return entity.CommandType;
			}
			set
			{
				entity.CommandType = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string CommandCode
		{
			get
			{
				return entity.CommandCode;
			}
			set
			{
				entity.CommandCode = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool? Disable
		{
			get
			{
				return entity.Disable;
			}
			set
			{
				entity.Disable = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string CommandColumn
		{
			get
			{
				return entity.CommandColumn;
			}
			set
			{
				entity.CommandColumn = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string InterceptRateType
		{
			get
			{
				return entity.InterceptRateType;
			}
			set
			{
				entity.InterceptRateType = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool? SyncData
		{
			get
			{
				return entity.SyncData;
			}
			set
			{
				entity.SyncData = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string SyncDataUrl
		{
			get
			{
				return entity.SyncDataUrl;
			}
			set
			{
				entity.SyncDataUrl = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string OkMessage
		{
			get
			{
				return entity.OkMessage;
			}
			set
			{
				entity.OkMessage = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string FailedMessage
		{
			get
			{
				return entity.FailedMessage;
			}
			set
			{
				entity.FailedMessage = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string SyncType
		{
			get
			{
				return entity.SyncType;
			}
			set
			{
				entity.SyncType = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? OrderIndex
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
		public string ChannelCode
		{
			get
			{
				return entity.ChannelCode;
			}
			set
			{
				entity.ChannelCode = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool? AllowFilter
		{
			get
			{
				return entity.AllowFilter;
			}
			set
			{
				entity.AllowFilter = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string AllowAndDisableArea
		{
			get
			{
				return entity.AllowAndDisableArea;
			}
			set
			{
				entity.AllowAndDisableArea = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string SettlementPeriod
		{
			get
			{
				return entity.SettlementPeriod;
			}
			set
			{
				entity.SettlementPeriod = value;
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
		public string Getway
		{
			get
			{
				return entity.Getway;
			}
			set
			{
				entity.Getway = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int DefaultNoInterceptCount
		{
			get
			{
				return entity.DefaultNoInterceptCount;
			}
			set
			{
				entity.DefaultNoInterceptCount = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool? HasDayMonthLimit
		{
			get
			{
				return entity.HasDayMonthLimit;
			}
			set
			{
				entity.HasDayMonthLimit = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? DayLimitCount
		{
			get
			{
				return entity.DayLimitCount;
			}
			set
			{
				entity.DayLimitCount = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? MonthLimitCount
		{
			get
			{
				return entity.MonthLimitCount;
			}
			set
			{
				entity.MonthLimitCount = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool? HasDayTotalLimit
		{
			get
			{
				return entity.HasDayTotalLimit;
			}
			set
			{
				entity.HasDayTotalLimit = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? DayTotalLimit
		{
			get
			{
				return entity.DayTotalLimit;
			}
			set
			{
				entity.DayTotalLimit = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool? DayTotalLimitInProvince
		{
			get
			{
				return entity.DayTotalLimitInProvince;
			}
			set
			{
				entity.DayTotalLimitInProvince = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string DayTotalLimitInProvinceAssignedCount
		{
			get
			{
				return entity.DayTotalLimitInProvinceAssignedCount;
			}
			set
			{
				entity.DayTotalLimitInProvinceAssignedCount = value;
			}
		}
		#endregion 





        #region "FKQuery"
		
        public static List<SPClientChannelSettingWrapper> FindAllByOrderByAndFilterAndChannelID(string orderByColumnName, bool isDesc,int pageIndex, int pageSize,    SPChannelWrapper channelID,  out int recordCount)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndChannelID(orderByColumnName, isDesc,pageIndex, pageSize,   channelID.entity,out recordCount));
        }

        public static List<SPClientChannelSettingWrapper> FindAllByChannelID(SPChannelWrapper channelID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByChannelID(channelID.entity));
        }
		
		
        public static List<SPClientChannelSettingWrapper> FindAllByOrderByAndFilterAndClinetID(string orderByColumnName, bool isDesc,int pageIndex, int pageSize,    SPClientWrapper clinetID,  out int recordCount)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndClinetID(orderByColumnName, isDesc,pageIndex, pageSize,   clinetID.entity,out recordCount));
        }

        public static List<SPClientChannelSettingWrapper> FindAllByClinetID(SPClientWrapper clinetID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByClinetID(clinetID.entity));
        }
		



        #endregion

        #region Static Common Data Operation
		
		internal static List<SPClientChannelSettingWrapper> ConvertToWrapperList(List<SPClientChannelSettingEntity> entitylist)
        {
            List<SPClientChannelSettingWrapper> list = new List<SPClientChannelSettingWrapper>();
            foreach (SPClientChannelSettingEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SPClientChannelSettingWrapper> ConvertToWrapperList(IList<SPClientChannelSettingEntity> entitylist)
        {
            List<SPClientChannelSettingWrapper> list = new List<SPClientChannelSettingWrapper>();
            foreach (SPClientChannelSettingEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SPClientChannelSettingEntity> ConvertToEntityList(List<SPClientChannelSettingWrapper> wrapperlist)
        {
            List<SPClientChannelSettingEntity> list = new List<SPClientChannelSettingEntity>();
            foreach (SPClientChannelSettingWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SPClientChannelSettingWrapper ConvertEntityToWrapper(SPClientChannelSettingEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SPClientChannelSettingWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

