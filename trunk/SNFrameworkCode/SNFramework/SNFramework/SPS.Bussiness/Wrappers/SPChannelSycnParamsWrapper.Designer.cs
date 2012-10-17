// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Spring.Context.Support;
using Common.Logging;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables.Container;
using SPS.Bussiness.ServiceProxys.Tables;

namespace SPS.Bussiness.Wrappers
{
    public partial class SPChannelSycnParamsWrapper
    {
        #region Member

		internal static readonly ISPChannelSycnParamsServiceProxy businessProxy = ((SPS.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID", typeof(SPS.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)))).SPChannelSycnParamsServiceProxyInstance;
		//internal static readonly ISPChannelSycnParamsServiceProxy businessProxy = ((ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID"))).SPChannelSycnParamsServiceProxyInstance;

        internal SPChannelSycnParamsEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SPChannelSycnParamsWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SPChannelSycnParamsWrapper() : this(new SPChannelSycnParamsEntity())
        {
            
        }

        internal SPChannelSycnParamsWrapper(SPChannelSycnParamsEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPChannelSycnParamsEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_ISENABLE = "IsEnable";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		public static readonly string PROPERTY_NAME_MAPPINGPARAMS = "MappingParams";
		public static readonly string PROPERTY_NAME_TITLE = "Title";
		public static readonly string PROPERTY_NAME_PARAMSVALUE = "ParamsValue";
		public static readonly string PROPERTY_NAME_PARAMSTYPE = "ParamsType";
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
		public bool IsEnable
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
		public string MappingParams
		{
			get
			{
				return entity.MappingParams;
			}
			set
			{
				entity.MappingParams = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
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
		public string ParamsValue
		{
			get
			{
				return entity.ParamsValue;
			}
			set
			{
				entity.ParamsValue = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ParamsType
		{
			get
			{
				return entity.ParamsType;
			}
			set
			{
				entity.ParamsType = value;
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





        #region "FKQuery"
		
        public static List<SPChannelSycnParamsWrapper> FindAllByOrderByAndFilterAndChannelID(string orderByColumnName, bool isDesc,int pageIndex, int pageSize,    SPChannelWrapper channelID,  out int recordCount)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndChannelID(orderByColumnName, isDesc,pageIndex, pageSize,   channelID.entity,out recordCount));
        }

        public static List<SPChannelSycnParamsWrapper> FindAllByChannelID(SPChannelWrapper channelID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByChannelID(channelID.entity));
        }
		



        #endregion

        #region Static Common Data Operation
		
		internal static List<SPChannelSycnParamsWrapper> ConvertToWrapperList(List<SPChannelSycnParamsEntity> entitylist)
        {
            List<SPChannelSycnParamsWrapper> list = new List<SPChannelSycnParamsWrapper>();
            foreach (SPChannelSycnParamsEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SPChannelSycnParamsWrapper> ConvertToWrapperList(IList<SPChannelSycnParamsEntity> entitylist)
        {
            List<SPChannelSycnParamsWrapper> list = new List<SPChannelSycnParamsWrapper>();
            foreach (SPChannelSycnParamsEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SPChannelSycnParamsEntity> ConvertToEntityList(List<SPChannelSycnParamsWrapper> wrapperlist)
        {
            List<SPChannelSycnParamsEntity> list = new List<SPChannelSycnParamsEntity>();
            foreach (SPChannelSycnParamsWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SPChannelSycnParamsWrapper ConvertEntityToWrapper(SPChannelSycnParamsEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SPChannelSycnParamsWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

