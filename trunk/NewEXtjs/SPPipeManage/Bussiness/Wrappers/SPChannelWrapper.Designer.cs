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
    public partial class SPChannelWrapper
    {
        #region Member

		internal static readonly ISPChannelServiceProxy businessProxy = ((LD.SPPipeManage.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID", typeof(LD.SPPipeManage.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)))).SPChannelServiceProxyInstance;
		//internal static readonly ISPChannelServiceProxy businessProxy = ((ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID"))).SPChannelServiceProxyInstance;

        internal SPChannelEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SPChannelWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SPChannelWrapper() : this(new SPChannelEntity())
        {
            
        }

        internal SPChannelWrapper(SPChannelEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Entity.Tables.SPChannelEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_AREA = "Area";
		public static readonly string PROPERTY_NAME_OPERATOR = "Operator";
		public static readonly string PROPERTY_NAME_CHANNELCODE = "ChannelCode";
		public static readonly string PROPERTY_NAME_FUZZYCOMMAND = "FuzzyCommand";
		public static readonly string PROPERTY_NAME_ACCURATECOMMAND = "AccurateCommand";
		public static readonly string PROPERTY_NAME_PORT = "Port";
		public static readonly string PROPERTY_NAME_CHANNELTYPE = "ChannelType";
		public static readonly string PROPERTY_NAME_PRICE = "Price";
		public static readonly string PROPERTY_NAME_RATE = "Rate";
		public static readonly string PROPERTY_NAME_STATUS = "Status";
		public static readonly string PROPERTY_NAME_CREATETIME = "CreateTime";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_OKMESSAGE = "OkMessage";
		public static readonly string PROPERTY_NAME_FAILEDMESSAGE = "FailedMessage";
		public static readonly string PROPERTY_NAME_UPERID = "UperID";
		public static readonly string PROPERTY_NAME_CHANNELCODEPARAMSNAME = "ChannelCodeParamsName";
		public static readonly string PROPERTY_NAME_ISALLOWNULLLINKID = "IsAllowNullLinkID";
		public static readonly string PROPERTY_NAME_RECSTATREPORT = "RecStatReport";
		public static readonly string PROPERTY_NAME_STATPARAMSNAME = "StatParamsName";
		public static readonly string PROPERTY_NAME_STATPARAMSVALUES = "StatParamsValues";
		public static readonly string PROPERTY_NAME_HASREQUESTTYPEPARAMS = "HasRequestTypeParams";
		public static readonly string PROPERTY_NAME_REQUESTTYPEPARAMNAME = "RequestTypeParamName";
		public static readonly string PROPERTY_NAME_REQUESTTYPEVALUES = "RequestTypeValues";
		public static readonly string PROPERTY_NAME_HASFILTERS = "HasFilters";
		public static readonly string PROPERTY_NAME_CHANNELINFO = "ChannelInfo";
		public static readonly string PROPERTY_NAME_STATSENDONCE = "StatSendOnce";
		public static readonly string PROPERTY_NAME_ISMONITORINGREQUEST = "IsMonitoringRequest";
		public static readonly string PROPERTY_NAME_ISDISABLE = "IsDisable";
		public static readonly string PROPERTY_NAME_REPORTIDPARAMS = "ReportIDParams";
		public static readonly string PROPERTY_NAME_CHANNEDATA = "ChanneData";
		
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
		public string Area
		{
			get
			{
				return entity.Area;
			}
			set
			{
				entity.Area = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Operator
		{
			get
			{
				return entity.Operator;
			}
			set
			{
				entity.Operator = value;
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
		public string FuzzyCommand
		{
			get
			{
				return entity.FuzzyCommand;
			}
			set
			{
				entity.FuzzyCommand = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string AccurateCommand
		{
			get
			{
				return entity.AccurateCommand;
			}
			set
			{
				entity.AccurateCommand = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Port
		{
			get
			{
				return entity.Port;
			}
			set
			{
				entity.Port = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ChannelType
		{
			get
			{
				return entity.ChannelType;
			}
			set
			{
				entity.ChannelType = value;
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
		public int? Rate
		{
			get
			{
				return entity.Rate;
			}
			set
			{
				entity.Rate = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? Status
		{
			get
			{
				return entity.Status;
			}
			set
			{
				entity.Status = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public DateTime? CreateTime
		{
			get
			{
				return entity.CreateTime;
			}
			set
			{
				entity.CreateTime = value;
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
		public SPUperWrapper UperID
		{
			get
			{
				return SPUperWrapper.ConvertEntityToWrapper(entity.UperID) ;
			}
			set
			{
				entity.UperID = ((value == null) ? null : value.entity);
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ChannelCodeParamsName
		{
			get
			{
				return entity.ChannelCodeParamsName;
			}
			set
			{
				entity.ChannelCodeParamsName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool? IsAllowNullLinkID
		{
			get
			{
				return entity.IsAllowNullLinkID;
			}
			set
			{
				entity.IsAllowNullLinkID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool? RecStatReport
		{
			get
			{
				return entity.RecStatReport;
			}
			set
			{
				entity.RecStatReport = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string StatParamsName
		{
			get
			{
				return entity.StatParamsName;
			}
			set
			{
				entity.StatParamsName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string StatParamsValues
		{
			get
			{
				return entity.StatParamsValues;
			}
			set
			{
				entity.StatParamsValues = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool? HasRequestTypeParams
		{
			get
			{
				return entity.HasRequestTypeParams;
			}
			set
			{
				entity.HasRequestTypeParams = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string RequestTypeParamName
		{
			get
			{
				return entity.RequestTypeParamName;
			}
			set
			{
				entity.RequestTypeParamName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string RequestTypeValues
		{
			get
			{
				return entity.RequestTypeValues;
			}
			set
			{
				entity.RequestTypeValues = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool? HasFilters
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
		public string ChannelInfo
		{
			get
			{
				return entity.ChannelInfo;
			}
			set
			{
				entity.ChannelInfo = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool? StatSendOnce
		{
			get
			{
				return entity.StatSendOnce;
			}
			set
			{
				entity.StatSendOnce = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool? IsMonitoringRequest
		{
			get
			{
				return entity.IsMonitoringRequest;
			}
			set
			{
				entity.IsMonitoringRequest = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool? IsDisable
		{
			get
			{
				return entity.IsDisable;
			}
			set
			{
				entity.IsDisable = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ReportIDParams
		{
			get
			{
				return entity.ReportIDParams;
			}
			set
			{
				entity.ReportIDParams = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ChanneData
		{
			get
			{
				return entity.ChanneData;
			}
			set
			{
				entity.ChanneData = value;
			}
		}
		#endregion 





        #region "FKQuery"
		
        public static List<SPChannelWrapper> FindAllByOrderByAndFilterAndUperID(string orderByColumnName, bool isDesc,int pageIndex, int pageSize,    SPUperWrapper uperID,  out int recordCount)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndUperID(orderByColumnName, isDesc,pageIndex, pageSize,   uperID.entity,out recordCount));
        }

        public static List<SPChannelWrapper> FindAllByUperID(SPUperWrapper uperID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByUperID(uperID.entity));
        }
		



        #endregion

        #region Static Common Data Operation
		
		internal static List<SPChannelWrapper> ConvertToWrapperList(List<SPChannelEntity> entitylist)
        {
            List<SPChannelWrapper> list = new List<SPChannelWrapper>();
            foreach (SPChannelEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SPChannelWrapper> ConvertToWrapperList(IList<SPChannelEntity> entitylist)
        {
            List<SPChannelWrapper> list = new List<SPChannelWrapper>();
            foreach (SPChannelEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SPChannelEntity> ConvertToEntityList(List<SPChannelWrapper> wrapperlist)
        {
            List<SPChannelEntity> list = new List<SPChannelEntity>();
            foreach (SPChannelWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SPChannelWrapper ConvertEntityToWrapper(SPChannelEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SPChannelWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

