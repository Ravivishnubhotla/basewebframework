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
    public partial class SPSClientWrapper   
    {
        #region Member

		internal static readonly ISPSClientServiceProxy businessProxy = ((SPS.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID", typeof(SPS.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)))).SPSClientServiceProxyInstance;
		
		
		internal SPSClientEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SPSClientWrapper() : base(new SPSClientEntity())
        {
            
        }

        internal SPSClientWrapper(SPSClientEntity entityObj)
            : base(entityObj)
        {
        }
		#endregion

        #region Process Column Name
        private static string ProcessColumnName(string columnName)
        {
            switch (columnName)
            {
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

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPSClientEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_USERID = "UserID";
		public static readonly string PROPERTY_NAME_ISDEFAULTCLIENT = "IsDefaultClient";
		public static readonly string PROPERTY_NAME_SYNCDATA = "SyncData";
		public static readonly string PROPERTY_NAME_SYCNRETRYTIMES = "SycnRetryTimes";
		public static readonly string PROPERTY_NAME_SYNCTYPE = "SyncType";
		public static readonly string PROPERTY_NAME_SYCNNOTINTERCEPTCOUNT = "SycnNotInterceptCount";
		public static readonly string PROPERTY_NAME_SYCNDATAURL = "SycnDataUrl";
		public static readonly string PROPERTY_NAME_SYCNOKMESSAGE = "SycnOkMessage";
		public static readonly string PROPERTY_NAME_SYCNFAILEDMESSAGE = "SycnFailedMessage";
		public static readonly string PROPERTY_NAME_ALIAS = "Alias";
		public static readonly string PROPERTY_NAME_INTERCEPTRATE = "InterceptRate";
		public static readonly string PROPERTY_NAME_DEFAULTPRICE = "DefaultPrice";
		public static readonly string PROPERTY_NAME_DEFAULTSHOWRECORDDAYS = "DefaultShowRecordDays";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
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
		[DataMember]
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
		[DataMember]
		public int UserID
		{
			get
			{
				return entity.UserID;
			}
			set
			{
				entity.UserID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool? IsDefaultClient
		{
			get
			{
				return entity.IsDefaultClient;
			}
			set
			{
				entity.IsDefaultClient = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool SyncData
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
		[DataMember]
		public int? SycnRetryTimes
		{
			get
			{
				return entity.SycnRetryTimes;
			}
			set
			{
				entity.SycnRetryTimes = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
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
		[DataMember]
		public int? SycnNotInterceptCount
		{
			get
			{
				return entity.SycnNotInterceptCount;
			}
			set
			{
				entity.SycnNotInterceptCount = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string SycnDataUrl
		{
			get
			{
				return entity.SycnDataUrl;
			}
			set
			{
				entity.SycnDataUrl = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string SycnOkMessage
		{
			get
			{
				return entity.SycnOkMessage;
			}
			set
			{
				entity.SycnOkMessage = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string SycnFailedMessage
		{
			get
			{
				return entity.SycnFailedMessage;
			}
			set
			{
				entity.SycnFailedMessage = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Alias
		{
			get
			{
				return entity.Alias;
			}
			set
			{
				entity.Alias = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public decimal InterceptRate
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
		[DataMember]
		public decimal DefaultPrice
		{
			get
			{
				return entity.DefaultPrice;
			}
			set
			{
				entity.DefaultPrice = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int DefaultShowRecordDays
		{
			get
			{
				return entity.DefaultShowRecordDays;
			}
			set
			{
				entity.DefaultShowRecordDays = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
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
		[DataMember]
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
		
		
      	
   
		#endregion


        #region "FKQuery"



        #endregion








        #region Static Common Data Operation
		
		internal static List<SPSClientWrapper> ConvertToWrapperList(List<SPSClientEntity> entitylist)
        {
            List<SPSClientWrapper> list = new List<SPSClientWrapper>();
            foreach (SPSClientEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SPSClientWrapper> ConvertToWrapperList(IList<SPSClientEntity> entitylist)
        {
            List<SPSClientWrapper> list = new List<SPSClientWrapper>();
            foreach (SPSClientEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SPSClientEntity> ConvertToEntityList(List<SPSClientWrapper> wrapperlist)
        {
            List<SPSClientEntity> list = new List<SPSClientEntity>();
            foreach (SPSClientWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SPSClientWrapper ConvertEntityToWrapper(SPSClientEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SPSClientWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

