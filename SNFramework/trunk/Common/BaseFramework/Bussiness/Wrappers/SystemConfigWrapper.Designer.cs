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
    public partial class SystemConfigWrapper
    {
        #region Member

		internal static readonly ISystemConfigServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemConfigServiceProxyInstance;
	 
	 
        internal SystemConfigEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SystemConfigWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SystemConfigWrapper() : this(new SystemConfigEntity())
        {
            
        }

        internal SystemConfigWrapper(SystemConfigEntity entityObj)
        {
            entity = entityObj;
        }
		#endregion
		
		#region Equals 和 HashCode 方法覆盖
		public override bool Equals(object obj)
        {
            if (obj == null && entity!=null)
            {
                if (entity.SystemConfigID == 0)
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemConfigEntity";
		public static readonly string PROPERTY_NAME_SYSTEMCONFIGID = "SystemConfigID";
		public static readonly string PROPERTY_NAME_CONFIGKEY = "ConfigKey";
		public static readonly string PROPERTY_NAME_CONFIGVALUE = "ConfigValue";
		public static readonly string PROPERTY_NAME_CONFIGDESCRIPTION = "ConfigDescription";
		public static readonly string PROPERTY_NAME_SORTINDEX = "SortIndex";
		
        #endregion


		#region Public Property
		/// <summary>
		/// 
		/// </summary>		
		public int SystemConfigID
		{
			get
			{
				return entity.SystemConfigID;
			}
			set
			{
				entity.SystemConfigID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ConfigKey
		{
			get
			{
				return entity.ConfigKey;
			}
			set
			{
				entity.ConfigKey = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ConfigValue
		{
			get
			{
				return entity.ConfigValue;
			}
			set
			{
				entity.ConfigValue = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ConfigDescription
		{
			get
			{
				return entity.ConfigDescription;
			}
			set
			{
				entity.ConfigDescription = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? SortIndex
		{
			get
			{
				return entity.SortIndex;
			}
			set
			{
				entity.SortIndex = value;
			}
		}
		#endregion 





        #region "FKQuery"



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemConfigWrapper> ConvertToWrapperList(List<SystemConfigEntity> entitylist)
        {
            List<SystemConfigWrapper> list = new List<SystemConfigWrapper>();
            foreach (SystemConfigEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemConfigWrapper> ConvertToWrapperList(IList<SystemConfigEntity> entitylist)
        {
            List<SystemConfigWrapper> list = new List<SystemConfigWrapper>();
            foreach (SystemConfigEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemConfigEntity> ConvertToEntityList(List<SystemConfigWrapper> wrapperlist)
        {
            List<SystemConfigEntity> list = new List<SystemConfigEntity>();
            foreach (SystemConfigWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemConfigWrapper ConvertEntityToWrapper(SystemConfigEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.SystemConfigID == 0)
                return null;

            return new SystemConfigWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

