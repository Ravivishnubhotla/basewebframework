// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Spring.Context.Support;
using Common.Logging;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables.Container;
using SPS.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;

namespace SPS.Bussiness.Wrappers
{
    public partial class SPClientCodeRelationWrapper
    {
        #region Member

		internal static readonly ISPClientCodeRelationServiceProxy businessProxy = ((SPS.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID", typeof(SPS.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)))).SPClientCodeRelationServiceProxyInstance;
	 
	 
        internal SPClientCodeRelationEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SPClientCodeRelationWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SPClientCodeRelationWrapper() : this(new SPClientCodeRelationEntity())
        {
            
        }

        internal SPClientCodeRelationWrapper(SPClientCodeRelationEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPClientCodeRelationEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_CODEID = "CodeID";
		public static readonly string PROPERTY_NAME_CLIENTID = "ClientID";
		public static readonly string PROPERTY_NAME_INTERCEPTRATE = "InterceptRate";
		public static readonly string PROPERTY_NAME_RECIEVEDATAURL = "RecieveDataUrl";
		public static readonly string PROPERTY_NAME_SYNCDATA = "SyncData";
		public static readonly string PROPERTY_NAME_OKMESSAGE = "OkMessage";
		public static readonly string PROPERTY_NAME_FAILEDMESSAGE = "FailedMessage";
		public static readonly string PROPERTY_NAME_SYNCTYPE = "SyncType";
		public static readonly string PROPERTY_NAME_STARTDATE = "StartDate";
		public static readonly string PROPERTY_NAME_ENDDATE = "EndDate";
		public static readonly string PROPERTY_NAME_ISENABLE = "IsEnable";
		
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
		public SPCodeWrapper CodeID
		{
			get
			{
				return SPCodeWrapper.ConvertEntityToWrapper(entity.CodeID) ;
			}
			set
			{
				entity.CodeID = ((value == null) ? null : value.entity);
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public SPSClientWrapper ClientID
		{
			get
			{
				return SPSClientWrapper.ConvertEntityToWrapper(entity.ClientID) ;
			}
			set
			{
				entity.ClientID = ((value == null) ? null : value.entity);
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public decimal? InterceptRate
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
		public string RecieveDataUrl
		{
			get
			{
				return entity.RecieveDataUrl;
			}
			set
			{
				entity.RecieveDataUrl = value;
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
		public DateTime? StartDate
		{
			get
			{
				return entity.StartDate;
			}
			set
			{
				entity.StartDate = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public DateTime? EndDate
		{
			get
			{
				return entity.EndDate;
			}
			set
			{
				entity.EndDate = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool? IsEnable
		{
			get
			{
				return entity.IsEnable;
			}
			set
			{
				entity.IsEnable = value;
			}
		}
		#endregion 





        #region "FKQuery"
		
        public static List<SPClientCodeRelationWrapper> FindAllByOrderByAndFilterAndCodeID(string orderByColumnName, bool isDesc,   SPCodeWrapper codeID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndCodeID(orderByColumnName, isDesc,   codeID.entity, pageQueryParams));
        }

        public static List<SPClientCodeRelationWrapper> FindAllByCodeID(SPCodeWrapper codeID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByCodeID(codeID.entity));
        }
		
		
        public static List<SPClientCodeRelationWrapper> FindAllByOrderByAndFilterAndClientID(string orderByColumnName, bool isDesc,   SPSClientWrapper clientID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndClientID(orderByColumnName, isDesc,   clientID.entity, pageQueryParams));
        }

        public static List<SPClientCodeRelationWrapper> FindAllByClientID(SPSClientWrapper clientID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByClientID(clientID.entity));
        }
		



        #endregion








        #region Static Common Data Operation
		
		internal static List<SPClientCodeRelationWrapper> ConvertToWrapperList(List<SPClientCodeRelationEntity> entitylist)
        {
            List<SPClientCodeRelationWrapper> list = new List<SPClientCodeRelationWrapper>();
            foreach (SPClientCodeRelationEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SPClientCodeRelationWrapper> ConvertToWrapperList(IList<SPClientCodeRelationEntity> entitylist)
        {
            List<SPClientCodeRelationWrapper> list = new List<SPClientCodeRelationWrapper>();
            foreach (SPClientCodeRelationEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SPClientCodeRelationEntity> ConvertToEntityList(List<SPClientCodeRelationWrapper> wrapperlist)
        {
            List<SPClientCodeRelationEntity> list = new List<SPClientCodeRelationEntity>();
            foreach (SPClientCodeRelationWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SPClientCodeRelationWrapper ConvertEntityToWrapper(SPClientCodeRelationEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SPClientCodeRelationWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace
