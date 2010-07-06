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
    public partial class SPPaymentInfoWrapper
    {
        #region Member

		internal static readonly ISPPaymentInfoServiceProxy businessProxy = ((LD.SPPipeManage.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID", typeof(LD.SPPipeManage.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)))).SPPaymentInfoServiceProxyInstance;
		//internal static readonly ISPPaymentInfoServiceProxy businessProxy = ((ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID"))).SPPaymentInfoServiceProxyInstance;

        internal SPPaymentInfoEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SPPaymentInfoWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SPPaymentInfoWrapper() : this(new SPPaymentInfoEntity())
        {
            
        }

        internal SPPaymentInfoWrapper(SPPaymentInfoEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Entity.Tables.SPPaymentInfoEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_MOBILENUMBER = "MobileNumber";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		public static readonly string PROPERTY_NAME_CLIENTID = "ClientID";
		public static readonly string PROPERTY_NAME_MESSAGE = "Message";
		public static readonly string PROPERTY_NAME_ISINTERCEPT = "IsIntercept";
		public static readonly string PROPERTY_NAME_CREATEDATE = "CreateDate";
		public static readonly string PROPERTY_NAME_REQUESTID = "RequestID";
		public static readonly string PROPERTY_NAME_CPID = "Cpid";
		public static readonly string PROPERTY_NAME_MID = "Mid";
		public static readonly string PROPERTY_NAME_PORT = "Port";
		public static readonly string PROPERTY_NAME_YWID = "Ywid";
		public static readonly string PROPERTY_NAME_IP = "Ip";
		public static readonly string PROPERTY_NAME_SUCESSSTOSEND = "SucesssToSend";
		public static readonly string PROPERTY_NAME_EXTENDFIELD1 = "ExtendField1";
		public static readonly string PROPERTY_NAME_EXTENDFIELD2 = "ExtendField2";
		public static readonly string PROPERTY_NAME_EXTENDFIELD3 = "ExtendField3";
		public static readonly string PROPERTY_NAME_EXTENDFIELD4 = "ExtendField4";
		public static readonly string PROPERTY_NAME_EXTENDFIELD5 = "ExtendField5";
		public static readonly string PROPERTY_NAME_EXTENDFIELD6 = "ExtendField6";
		public static readonly string PROPERTY_NAME_EXTENDFIELD7 = "ExtendField7";
		public static readonly string PROPERTY_NAME_EXTENDFIELD8 = "ExtendField8";
		public static readonly string PROPERTY_NAME_EXTENDFIELD9 = "ExtendField9";
		public static readonly string PROPERTY_NAME_ISREPORT = "IsReport";
		public static readonly string PROPERTY_NAME_REQUESTCONTENT = "RequestContent";
		
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
		public string MobileNumber
		{
			get
			{
				return entity.MobileNumber;
			}
			set
			{
				entity.MobileNumber = value;
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
		public SPClientWrapper ClientID
		{
			get
			{
				return SPClientWrapper.ConvertEntityToWrapper(entity.ClientID) ;
			}
			set
			{
				entity.ClientID = ((value == null) ? null : value.entity);
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Message
		{
			get
			{
				return entity.Message;
			}
			set
			{
				entity.Message = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool? IsIntercept
		{
			get
			{
				return entity.IsIntercept;
			}
			set
			{
				entity.IsIntercept = value;
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
		public int? RequestID
		{
			get
			{
				return entity.RequestID;
			}
			set
			{
				entity.RequestID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Cpid
		{
			get
			{
				return entity.Cpid;
			}
			set
			{
				entity.Cpid = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Mid
		{
			get
			{
				return entity.Mid;
			}
			set
			{
				entity.Mid = value;
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
		public string Ywid
		{
			get
			{
				return entity.Ywid;
			}
			set
			{
				entity.Ywid = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Ip
		{
			get
			{
				return entity.Ip;
			}
			set
			{
				entity.Ip = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool? SucesssToSend
		{
			get
			{
				return entity.SucesssToSend;
			}
			set
			{
				entity.SucesssToSend = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ExtendField1
		{
			get
			{
				return entity.ExtendField1;
			}
			set
			{
				entity.ExtendField1 = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ExtendField2
		{
			get
			{
				return entity.ExtendField2;
			}
			set
			{
				entity.ExtendField2 = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ExtendField3
		{
			get
			{
				return entity.ExtendField3;
			}
			set
			{
				entity.ExtendField3 = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ExtendField4
		{
			get
			{
				return entity.ExtendField4;
			}
			set
			{
				entity.ExtendField4 = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ExtendField5
		{
			get
			{
				return entity.ExtendField5;
			}
			set
			{
				entity.ExtendField5 = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ExtendField6
		{
			get
			{
				return entity.ExtendField6;
			}
			set
			{
				entity.ExtendField6 = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ExtendField7
		{
			get
			{
				return entity.ExtendField7;
			}
			set
			{
				entity.ExtendField7 = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ExtendField8
		{
			get
			{
				return entity.ExtendField8;
			}
			set
			{
				entity.ExtendField8 = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ExtendField9
		{
			get
			{
				return entity.ExtendField9;
			}
			set
			{
				entity.ExtendField9 = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool IsReport
		{
			get
			{
				return entity.IsReport;
			}
			set
			{
				entity.IsReport = value;
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
		#endregion 







        #region Static Common Data Operation
		
		internal static List<SPPaymentInfoWrapper> ConvertToWrapperList(List<SPPaymentInfoEntity> entitylist)
        {
            List<SPPaymentInfoWrapper> list = new List<SPPaymentInfoWrapper>();
            foreach (SPPaymentInfoEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SPPaymentInfoWrapper> ConvertToWrapperList(IList<SPPaymentInfoEntity> entitylist)
        {
            List<SPPaymentInfoWrapper> list = new List<SPPaymentInfoWrapper>();
            foreach (SPPaymentInfoEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SPPaymentInfoEntity> ConvertToEntityList(List<SPPaymentInfoWrapper> wrapperlist)
        {
            List<SPPaymentInfoEntity> list = new List<SPPaymentInfoEntity>();
            foreach (SPPaymentInfoWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SPPaymentInfoWrapper ConvertEntityToWrapper(SPPaymentInfoEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SPPaymentInfoWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

