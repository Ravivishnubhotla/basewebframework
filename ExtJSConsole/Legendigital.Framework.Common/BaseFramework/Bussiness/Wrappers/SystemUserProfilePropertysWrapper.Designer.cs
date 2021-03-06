// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Spring.Context.Support;
using Common.Logging;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
    public partial class SystemUserProfilePropertysWrapper
    {
        #region Member

		internal static readonly ISystemUserProfilePropertysServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemUserProfilePropertysServiceProxyInstance;
		//internal static readonly ISystemUserProfilePropertysServiceProxy businessProxy = ((ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID"))).SystemUserProfilePropertysServiceProxyInstance;

        internal SystemUserProfilePropertysEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SystemUserProfilePropertysWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SystemUserProfilePropertysWrapper() : this(new SystemUserProfilePropertysEntity())
        {
            
        }

        internal SystemUserProfilePropertysWrapper(SystemUserProfilePropertysEntity entityObj)
        {
            entity = entityObj;
        }
		#endregion
		
		#region Equals 和 HashCode 方法覆盖
		public override bool Equals(object obj)
        {
            if (obj == null && entity!=null)
            {
                if (entity.PropertyID == 0)
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemUserProfilePropertysEntity";
		public static readonly string PROPERTY_NAME_PROPERTYID = "PropertyID";
		public static readonly string PROPERTY_NAME_PROPERTYNAME = "PropertyName";
		public static readonly string PROPERTY_NAME_PROPERTYDATATYPE = "PropertyDataType";
		public static readonly string PROPERTY_NAME_PROPERTYDESCRIPTION = "PropertyDescription";
		
        #endregion


		#region Public Property
		/// <summary>
		/// 
		/// </summary>		
		public int PropertyID
		{
			get
			{
				return entity.PropertyID;
			}
			set
			{
				entity.PropertyID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string PropertyName
		{
			get
			{
				return entity.PropertyName;
			}
			set
			{
				entity.PropertyName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string PropertyDataType
		{
			get
			{
				return entity.PropertyDataType;
			}
			set
			{
				entity.PropertyDataType = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string PropertyDescription
		{
			get
			{
				return entity.PropertyDescription;
			}
			set
			{
				entity.PropertyDescription = value;
			}
		}
		#endregion 







        #region Static Common Data Operation
		
		internal static List<SystemUserProfilePropertysWrapper> ConvertToWrapperList(List<SystemUserProfilePropertysEntity> entitylist)
        {
            List<SystemUserProfilePropertysWrapper> list = new List<SystemUserProfilePropertysWrapper>();
            foreach (SystemUserProfilePropertysEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemUserProfilePropertysWrapper> ConvertToWrapperList(IList<SystemUserProfilePropertysEntity> entitylist)
        {
            List<SystemUserProfilePropertysWrapper> list = new List<SystemUserProfilePropertysWrapper>();
            foreach (SystemUserProfilePropertysEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemUserProfilePropertysEntity> ConvertToEntityList(List<SystemUserProfilePropertysWrapper> wrapperlist)
        {
            List<SystemUserProfilePropertysEntity> list = new List<SystemUserProfilePropertysEntity>();
            foreach (SystemUserProfilePropertysWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemUserProfilePropertysWrapper ConvertEntityToWrapper(SystemUserProfilePropertysEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.PropertyID == 0)
                return null;

            return new SystemUserProfilePropertysWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

