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
    public partial class SPStatReportWrapper
    {
        #region Member

		internal static readonly ISPStatReportServiceProxy businessProxy = ((LD.SPPipeManage.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID", typeof(LD.SPPipeManage.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)))).SPStatReportServiceProxyInstance;
		//internal static readonly ISPStatReportServiceProxy businessProxy = ((ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID"))).SPStatReportServiceProxyInstance;

        internal SPStatReportEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SPStatReportWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SPStatReportWrapper() : this(new SPStatReportEntity())
        {
            
        }

        internal SPStatReportWrapper(SPStatReportEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Entity.Tables.SPStatReportEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		public static readonly string PROPERTY_NAME_STAT = "Stat";
		public static readonly string PROPERTY_NAME_LINKID = "LinkID";
		public static readonly string PROPERTY_NAME_QUERYSTRING = "QueryString";
		public static readonly string PROPERTY_NAME_REQUESTCONTENT = "RequestContent";
		public static readonly string PROPERTY_NAME_CREATEDATE = "CreateDate";
		public static readonly string PROPERTY_NAME_ISPAYOK = "IsPayOk";
		
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
		public int ChannelID
		{
			get
			{
				return entity.ChannelID;
			}
			set
			{
				entity.ChannelID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Stat
		{
			get
			{
				return entity.Stat;
			}
			set
			{
				entity.Stat = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string LinkID
		{
			get
			{
				return entity.LinkID;
			}
			set
			{
				entity.LinkID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string QueryString
		{
			get
			{
				return entity.QueryString;
			}
			set
			{
				entity.QueryString = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string RequestContent
		{
			get
			{
				return entity.RequestContent;
			}
			set
			{
				entity.RequestContent = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
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
		public bool? IsPayOk
		{
			get
			{
				return entity.IsPayOk;
			}
			set
			{
				entity.IsPayOk = value;
			}
		}
		#endregion 





        #region "FKQuery"



        #endregion

        #region Static Common Data Operation
		
		internal static List<SPStatReportWrapper> ConvertToWrapperList(List<SPStatReportEntity> entitylist)
        {
            List<SPStatReportWrapper> list = new List<SPStatReportWrapper>();
            foreach (SPStatReportEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SPStatReportWrapper> ConvertToWrapperList(IList<SPStatReportEntity> entitylist)
        {
            List<SPStatReportWrapper> list = new List<SPStatReportWrapper>();
            foreach (SPStatReportEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SPStatReportEntity> ConvertToEntityList(List<SPStatReportWrapper> wrapperlist)
        {
            List<SPStatReportEntity> list = new List<SPStatReportEntity>();
            foreach (SPStatReportWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SPStatReportWrapper ConvertEntityToWrapper(SPStatReportEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SPStatReportWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

