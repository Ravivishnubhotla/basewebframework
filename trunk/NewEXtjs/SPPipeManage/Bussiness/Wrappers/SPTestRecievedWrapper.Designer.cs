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
    public partial class SPTestRecievedWrapper
    {
        #region Member

		internal static readonly ISPTestRecievedServiceProxy businessProxy = ((LD.SPPipeManage.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID", typeof(LD.SPPipeManage.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)))).SPTestRecievedServiceProxyInstance;
		//internal static readonly ISPTestRecievedServiceProxy businessProxy = ((ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID"))).SPTestRecievedServiceProxyInstance;

        internal SPTestRecievedEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SPTestRecievedWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SPTestRecievedWrapper() : this(new SPTestRecievedEntity())
        {
            
        }

        internal SPTestRecievedWrapper(SPTestRecievedEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Entity.Tables.SPTestRecievedEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_RECIEVEDCONTENT = "RecievedContent";
		public static readonly string PROPERTY_NAME_RECIEVEDDATE = "RecievedDate";
		public static readonly string PROPERTY_NAME_RECIEVEDIP = "RecievedIP";
		public static readonly string PROPERTY_NAME_RECIEVEDSENDURL = "RecievedSendUrl";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		public static readonly string PROPERTY_NAME_CLIENTID = "ClientID";
		
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
		public string RecievedContent
		{
			get
			{
				return entity.RecievedContent;
			}
			set
			{
				entity.RecievedContent = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public DateTime? RecievedDate
		{
			get
			{
				return entity.RecievedDate;
			}
			set
			{
				entity.RecievedDate = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string RecievedIP
		{
			get
			{
				return entity.RecievedIP;
			}
			set
			{
				entity.RecievedIP = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string RecievedSendUrl
		{
			get
			{
				return entity.RecievedSendUrl;
			}
			set
			{
				entity.RecievedSendUrl = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? ChannelID
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
		public int? ClientID
		{
			get
			{
				return entity.ClientID;
			}
			set
			{
				entity.ClientID = value;
			}
		}
		#endregion 





        #region "FKQuery"



        #endregion








        #region Static Common Data Operation
		
		internal static List<SPTestRecievedWrapper> ConvertToWrapperList(List<SPTestRecievedEntity> entitylist)
        {
            List<SPTestRecievedWrapper> list = new List<SPTestRecievedWrapper>();
            foreach (SPTestRecievedEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SPTestRecievedWrapper> ConvertToWrapperList(IList<SPTestRecievedEntity> entitylist)
        {
            List<SPTestRecievedWrapper> list = new List<SPTestRecievedWrapper>();
            foreach (SPTestRecievedEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SPTestRecievedEntity> ConvertToEntityList(List<SPTestRecievedWrapper> wrapperlist)
        {
            List<SPTestRecievedEntity> list = new List<SPTestRecievedEntity>();
            foreach (SPTestRecievedWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SPTestRecievedWrapper ConvertEntityToWrapper(SPTestRecievedEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SPTestRecievedWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

