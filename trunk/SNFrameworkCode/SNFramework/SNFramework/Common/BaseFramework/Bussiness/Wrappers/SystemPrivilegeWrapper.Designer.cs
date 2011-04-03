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
    public partial class SystemPrivilegeWrapper
    {
        #region Member

		internal static readonly ISystemPrivilegeServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemPrivilegeServiceProxyInstance;
	 
	 
        internal SystemPrivilegeEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SystemPrivilegeWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SystemPrivilegeWrapper() : this(new SystemPrivilegeEntity())
        {
            
        }

        internal SystemPrivilegeWrapper(SystemPrivilegeEntity entityObj)
        {
            entity = entityObj;
        }
		#endregion
		
		#region Equals 和 HashCode 方法覆盖
		public override bool Equals(object obj)
        {
            if (obj == null && entity!=null)
            {
                if (entity.PrivilegeID == 0)
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemPrivilegeEntity";
		public static readonly string PROPERTY_NAME_PRIVILEGEID = "PrivilegeID";
		public static readonly string PROPERTY_NAME_OPERATIONID = "OperationID";
		public static readonly string PROPERTY_NAME_RESOURCESID = "ResourcesID";
		public static readonly string PROPERTY_NAME_PRIVILEGECNNAME = "PrivilegeCnName";
		public static readonly string PROPERTY_NAME_PRIVILEGEENNAME = "PrivilegeEnName";
		public static readonly string PROPERTY_NAME_DEFAULTVALUE = "DefaultValue";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_PRIVILEGEORDER = "PrivilegeOrder";
		public static readonly string PROPERTY_NAME_PRIVILEGECATEGORY = "PrivilegeCategory";
		public static readonly string PROPERTY_NAME_PRIVILEGETYPE = "PrivilegeType";
		
        #endregion


		#region Public Property
		/// <summary>
		/// Primary Key
		/// </summary>		
		public int PrivilegeID
		{
			get
			{
				return entity.PrivilegeID;
			}
			set
			{
				entity.PrivilegeID = value;
			}
		}
		/// <summary>
		/// Operation ID
		/// </summary>		
		public SystemOperationWrapper OperationID
		{
			get
			{
				return SystemOperationWrapper.ConvertEntityToWrapper(entity.OperationID) ;
			}
			set
			{
				entity.OperationID = ((value == null) ? null : value.entity);
			}
		}
		/// <summary>
		/// Resources ID
		/// </summary>		
		public SystemResourcesWrapper ResourcesID
		{
			get
			{
				return SystemResourcesWrapper.ConvertEntityToWrapper(entity.ResourcesID) ;
			}
			set
			{
				entity.ResourcesID = ((value == null) ? null : value.entity);
			}
		}
		/// <summary>
		/// Permission Name
		/// </summary>		
		public string PrivilegeCnName
		{
			get
			{
				return entity.PrivilegeCnName;
			}
			set
			{
				entity.PrivilegeCnName = value;
			}
		}
		/// <summary>
		/// Permission Code
		/// </summary>		
		public string PrivilegeEnName
		{
			get
			{
				return entity.PrivilegeEnName;
			}
			set
			{
				entity.PrivilegeEnName = value;
			}
		}
		/// <summary>
		/// Default Value
		/// </summary>		
		public string DefaultValue
		{
			get
			{
				return entity.DefaultValue;
			}
			set
			{
				entity.DefaultValue = value;
			}
		}
		/// <summary>
		/// Permission Description
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
		/// Permission Order
		/// </summary>		
		public int PrivilegeOrder
		{
			get
			{
				return entity.PrivilegeOrder;
			}
			set
			{
				entity.PrivilegeOrder = value;
			}
		}
		/// <summary>
		/// permission Category
		/// </summary>		
		public string PrivilegeCategory
		{
			get
			{
				return entity.PrivilegeCategory;
			}
			set
			{
				entity.PrivilegeCategory = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string PrivilegeType
		{
			get
			{
				return entity.PrivilegeType;
			}
			set
			{
				entity.PrivilegeType = value;
			}
		}
		#endregion 





        #region "FKQuery"
		
        public static List<SystemPrivilegeWrapper> FindAllByOrderByAndFilterAndOperationID(string orderByColumnName, bool isDesc,   SystemOperationWrapper operationID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndOperationID(orderByColumnName, isDesc,   operationID.entity, pageQueryParams));
        }

        public static List<SystemPrivilegeWrapper> FindAllByOperationID(SystemOperationWrapper operationID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOperationID(operationID.entity));
        }
		
		
        public static List<SystemPrivilegeWrapper> FindAllByOrderByAndFilterAndResourcesID(string orderByColumnName, bool isDesc,   SystemResourcesWrapper resourcesID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndResourcesID(orderByColumnName, isDesc,   resourcesID.entity, pageQueryParams));
        }

        public static List<SystemPrivilegeWrapper> FindAllByResourcesID(SystemResourcesWrapper resourcesID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByResourcesID(resourcesID.entity));
        }
		



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemPrivilegeWrapper> ConvertToWrapperList(List<SystemPrivilegeEntity> entitylist)
        {
            List<SystemPrivilegeWrapper> list = new List<SystemPrivilegeWrapper>();
            foreach (SystemPrivilegeEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemPrivilegeWrapper> ConvertToWrapperList(IList<SystemPrivilegeEntity> entitylist)
        {
            List<SystemPrivilegeWrapper> list = new List<SystemPrivilegeWrapper>();
            foreach (SystemPrivilegeEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemPrivilegeEntity> ConvertToEntityList(List<SystemPrivilegeWrapper> wrapperlist)
        {
            List<SystemPrivilegeEntity> list = new List<SystemPrivilegeEntity>();
            foreach (SystemPrivilegeWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemPrivilegeWrapper ConvertEntityToWrapper(SystemPrivilegeEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.PrivilegeID == 0)
                return null;

            return new SystemPrivilegeWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

