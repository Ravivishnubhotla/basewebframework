// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Spring.Context.Support;
using Common.Logging;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
    public partial class SystemViewWrapper
    {
        #region Member

		internal static readonly ISystemViewServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemViewServiceProxyInstance;
	 
	 
        internal SystemViewEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SystemViewWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SystemViewWrapper() : this(new SystemViewEntity())
        {
            
        }

        internal SystemViewWrapper(SystemViewEntity entityObj)
        {
            entity = entityObj;
        }
		#endregion
		
		#region Equals 和 HashCode 方法覆盖
		public override bool Equals(object obj)
        {
            if (obj == null && entity!=null)
            {
                if (entity.SystemViewID == 0)
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemViewEntity";
		public static readonly string PROPERTY_NAME_SYSTEMVIEWID = "SystemViewID";
		public static readonly string PROPERTY_NAME_SYSTEMVIEWNAMECN = "SystemViewNameCn";
		public static readonly string PROPERTY_NAME_SYSTEMVIEWNAMEEN = "SystemViewNameEn";
		public static readonly string PROPERTY_NAME_APPLICATIONID = "ApplicationID";
		public static readonly string PROPERTY_NAME_SYSTEMVIEWDESCRIPTION = "SystemViewDescription";
		public static readonly string PROPERTY_NAME_ORDERINDEX = "OrderIndex";
		
        #endregion


		#region Public Property
		/// <summary>
		/// ??
		/// </summary>		
		public int SystemViewID
		{
			get
			{
				return entity.SystemViewID;
			}
			set
			{
				entity.SystemViewID = value;
			}
		}
		/// <summary>
		/// ?????
		/// </summary>		
		public string SystemViewNameCn
		{
			get
			{
				return entity.SystemViewNameCn;
			}
			set
			{
				entity.SystemViewNameCn = value;
			}
		}
		/// <summary>
		/// ?????
		/// </summary>		
		public string SystemViewNameEn
		{
			get
			{
				return entity.SystemViewNameEn;
			}
			set
			{
				entity.SystemViewNameEn = value;
			}
		}
		/// <summary>
		/// ??ID
		/// </summary>		
		public SystemApplicationWrapper ApplicationID
		{
			get
			{
				return SystemApplicationWrapper.ConvertEntityToWrapper(entity.ApplicationID) ;
			}
			set
			{
				entity.ApplicationID = ((value == null) ? null : value.entity);
			}
		}
		/// <summary>
		/// ????
		/// </summary>		
		public string SystemViewDescription
		{
			get
			{
				return entity.SystemViewDescription;
			}
			set
			{
				entity.SystemViewDescription = value;
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
		#endregion 





        #region "FKQuery"
		
        public static List<SystemViewWrapper> FindAllByOrderByAndFilterAndApplicationID(string orderByColumnName, bool isDesc,   SystemApplicationWrapper applicationID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndApplicationID(orderByColumnName, isDesc,   applicationID.entity, pageQueryParams));
        }

        public static List<SystemViewWrapper> FindAllByApplicationID(SystemApplicationWrapper applicationID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByApplicationID(applicationID.entity));
        }
		



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemViewWrapper> ConvertToWrapperList(List<SystemViewEntity> entitylist)
        {
            List<SystemViewWrapper> list = new List<SystemViewWrapper>();
            foreach (SystemViewEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemViewWrapper> ConvertToWrapperList(IList<SystemViewEntity> entitylist)
        {
            List<SystemViewWrapper> list = new List<SystemViewWrapper>();
            foreach (SystemViewEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemViewEntity> ConvertToEntityList(List<SystemViewWrapper> wrapperlist)
        {
            List<SystemViewEntity> list = new List<SystemViewEntity>();
            foreach (SystemViewWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemViewWrapper ConvertEntityToWrapper(SystemViewEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.SystemViewID == 0)
                return null;

            return new SystemViewWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

