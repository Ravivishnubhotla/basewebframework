// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Spring.Context.Support;
using Common.Logging;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
    public partial class SystemEmailQueueWrapper    : BaseSpringNHibernateWrapper<SystemEmailQueueEntity, ISystemEmailQueueServiceProxy, SystemEmailQueueWrapper,int>
    {
        #region Member

		internal static readonly ISystemEmailQueueServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemEmailQueueServiceProxyInstance;
		
		
		internal SystemEmailQueueEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemEmailQueueWrapper() : base(new SystemEmailQueueEntity())
        {
            
        }

        internal SystemEmailQueueWrapper(SystemEmailQueueEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemEmailQueueEntity";
		public static readonly string PROPERTY_NAME_QUEUEID = "QueueID";
		public static readonly string PROPERTY_NAME_TITLE = "Title";
		public static readonly string PROPERTY_NAME_BODY = "Body";
		public static readonly string PROPERTY_NAME_FROMADDRESS = "FromAddress";
		public static readonly string PROPERTY_NAME_FROMNAME = "FromName";
		public static readonly string PROPERTY_NAME_TOADDRESSS = "ToAddresss";
		public static readonly string PROPERTY_NAME_TONAMES = "ToNames";
		public static readonly string PROPERTY_NAME_CCADDRESSS = "CCAddresss";
		public static readonly string PROPERTY_NAME_CCNAMES = "CCNames";
		public static readonly string PROPERTY_NAME_BCCADDRESSS = "BCCAddresss";
		public static readonly string PROPERTY_NAME_BCCNAMES = "BCCNames";
		public static readonly string PROPERTY_NAME_EMAILTEMPLATEID = "EmailTemplateID";
		public static readonly string PROPERTY_NAME_STATUES = "Statues";
		public static readonly string PROPERTY_NAME_SENDRETRY = "SendRetry";
		public static readonly string PROPERTY_NAME_MAXRETRYTIME = "MaxRetryTime";
		public static readonly string PROPERTY_NAME_MAILLOG = "MailLog";
		public static readonly string PROPERTY_NAME_CREATEDATE = "CreateDate";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_SENDCONFIG = "SendConfig";
		public static readonly string PROPERTY_NAME_SENDDATE = "SendDate";
		public static readonly string PROPERTY_NAME_ORDERINDEX = "OrderIndex";
		
        #endregion
	
 
      	
	
	
		 
		
		
		
		


		#region Public Property
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int QueueID
		{
			get
			{
				return entity.QueueID;
			}
			set
			{
				entity.QueueID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Title
		{
			get
			{
				return entity.Title;
			}
			set
			{
				entity.Title = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Body
		{
			get
			{
				return entity.Body;
			}
			set
			{
				entity.Body = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string FromAddress
		{
			get
			{
				return entity.FromAddress;
			}
			set
			{
				entity.FromAddress = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string FromName
		{
			get
			{
				return entity.FromName;
			}
			set
			{
				entity.FromName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string ToAddresss
		{
			get
			{
				return entity.ToAddresss;
			}
			set
			{
				entity.ToAddresss = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string ToNames
		{
			get
			{
				return entity.ToNames;
			}
			set
			{
				entity.ToNames = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string CCAddresss
		{
			get
			{
				return entity.CCAddresss;
			}
			set
			{
				entity.CCAddresss = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string CCNames
		{
			get
			{
				return entity.CCNames;
			}
			set
			{
				entity.CCNames = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string BCCAddresss
		{
			get
			{
				return entity.BCCAddresss;
			}
			set
			{
				entity.BCCAddresss = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string BCCNames
		{
			get
			{
				return entity.BCCNames;
			}
			set
			{
				entity.BCCNames = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int EmailTemplateID
		{
			get
			{
				return entity.EmailTemplateID;
			}
			set
			{
				entity.EmailTemplateID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Statues
		{
			get
			{
				return entity.Statues;
			}
			set
			{
				entity.Statues = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? SendRetry
		{
			get
			{
				return entity.SendRetry;
			}
			set
			{
				entity.SendRetry = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? MaxRetryTime
		{
			get
			{
				return entity.MaxRetryTime;
			}
			set
			{
				entity.MaxRetryTime = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string MailLog
		{
			get
			{
				return entity.MailLog;
			}
			set
			{
				entity.MailLog = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public DateTime? CreateDate
		{
			get
			{
				return entity.CreateDate;
			}
			set
			{
				entity.CreateDate = value;
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
		public string SendConfig
		{
			get
			{
				return entity.SendConfig;
			}
			set
			{
				entity.SendConfig = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public DateTime? SendDate
		{
			get
			{
				return entity.SendDate;
			}
			set
			{
				entity.SendDate = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
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
		#endregion 


		#region Query Property
		
		
      	
   
		#endregion


        #region "FKQuery"



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemEmailQueueWrapper> ConvertToWrapperList(List<SystemEmailQueueEntity> entitylist)
        {
            List<SystemEmailQueueWrapper> list = new List<SystemEmailQueueWrapper>();
            foreach (SystemEmailQueueEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemEmailQueueWrapper> ConvertToWrapperList(IList<SystemEmailQueueEntity> entitylist)
        {
            List<SystemEmailQueueWrapper> list = new List<SystemEmailQueueWrapper>();
            foreach (SystemEmailQueueEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemEmailQueueEntity> ConvertToEntityList(List<SystemEmailQueueWrapper> wrapperlist)
        {
            List<SystemEmailQueueEntity> list = new List<SystemEmailQueueEntity>();
            foreach (SystemEmailQueueWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemEmailQueueWrapper ConvertEntityToWrapper(SystemEmailQueueEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.QueueID == 0)
                return null;

            return new SystemEmailQueueWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

