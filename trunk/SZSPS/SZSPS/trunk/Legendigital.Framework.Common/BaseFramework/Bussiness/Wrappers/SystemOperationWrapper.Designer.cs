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
    public partial class SystemOperationWrapper
    {
        #region Member

		internal static readonly ISystemOperationServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemOperationServiceProxyInstance;
		//internal static readonly ISystemOperationServiceProxy businessProxy = ((ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID"))).SystemOperationServiceProxyInstance;

        internal SystemOperationEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SystemOperationWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SystemOperationWrapper() : this(new SystemOperationEntity())
        {
            
        }

        internal SystemOperationWrapper(SystemOperationEntity entityObj)
        {
            entity = entityObj;
        }
		#endregion
		
		#region Equals 和 HashCode 方法覆盖
		public override bool Equals(object obj)
        {
            if (obj == null && entity!=null)
            {
                if (entity.OperationID == 0)
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemOperationEntity";
		public static readonly string PROPERTY_NAME_OPERATIONID = "OperationID";
		public static readonly string PROPERTY_NAME_OPERATIONNAMECN = "OperationNameCn";
		public static readonly string PROPERTY_NAME_OPERATIONNAMEEN = "OperationNameEn";
		public static readonly string PROPERTY_NAME_OPERATIONDESCRIPTION = "OperationDescription";
		public static readonly string PROPERTY_NAME_ISSYSTEMOPERATION = "IsSystemOperation";
		public static readonly string PROPERTY_NAME_ISCANSINGLEOPERATION = "IsCanSingleOperation";
		public static readonly string PROPERTY_NAME_ISCANMUTILOPERATION = "IsCanMutilOperation";
		public static readonly string PROPERTY_NAME_ISENABLE = "IsEnable";
		public static readonly string PROPERTY_NAME_ISINLISTPAGE = "IsInListPage";
		public static readonly string PROPERTY_NAME_ISINSINGLEPAGE = "IsInSinglePage";
		public static readonly string PROPERTY_NAME_OPERATIONORDER = "OperationOrder";
		
        #endregion


		#region Public Property
		/// <summary>
		/// 主键
		/// </summary>		
		public int OperationID
		{
			get
			{
				return entity.OperationID;
			}
			set
			{
				entity.OperationID = value;
			}
		}
		/// <summary>
		/// 操作中文名
		/// </summary>		
		public string OperationNameCn
		{
			get
			{
				return entity.OperationNameCn;
			}
			set
			{
				entity.OperationNameCn = value;
			}
		}
		/// <summary>
		/// 操作代号
		/// </summary>		
		public string OperationNameEn
		{
			get
			{
				return entity.OperationNameEn;
			}
			set
			{
				entity.OperationNameEn = value;
			}
		}
		/// <summary>
		/// 操作描述
		/// </summary>		
		public string OperationDescription
		{
			get
			{
				return entity.OperationDescription;
			}
			set
			{
				entity.OperationDescription = value;
			}
		}
		/// <summary>
		/// 是否为系统操作
		/// </summary>		
		public bool IsSystemOperation
		{
			get
			{
				return entity.IsSystemOperation;
			}
			set
			{
				entity.IsSystemOperation = value;
			}
		}
		/// <summary>
		/// 是否可以单条数据操作
		/// </summary>		
		public bool IsCanSingleOperation
		{
			get
			{
				return entity.IsCanSingleOperation;
			}
			set
			{
				entity.IsCanSingleOperation = value;
			}
		}
		/// <summary>
		/// 是否可以多条数据操作
		/// </summary>		
		public bool IsCanMutilOperation
		{
			get
			{
				return entity.IsCanMutilOperation;
			}
			set
			{
				entity.IsCanMutilOperation = value;
			}
		}
		/// <summary>
		/// 是否生效
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
		/// 是否出现在列表页面
		/// </summary>		
		public bool IsInListPage
		{
			get
			{
				return entity.IsInListPage;
			}
			set
			{
				entity.IsInListPage = value;
			}
		}
		/// <summary>
		/// 是否出现在详细页面
		/// </summary>		
		public bool IsInSinglePage
		{
			get
			{
				return entity.IsInSinglePage;
			}
			set
			{
				entity.IsInSinglePage = value;
			}
		}
		/// <summary>
		/// 操作排序号
		/// </summary>		
		public int OperationOrder
		{
			get
			{
				return entity.OperationOrder;
			}
			set
			{
				entity.OperationOrder = value;
			}
		}
		#endregion 







        #region Static Common Data Operation
		
		internal static List<SystemOperationWrapper> ConvertToWrapperList(List<SystemOperationEntity> entitylist)
        {
            List<SystemOperationWrapper> list = new List<SystemOperationWrapper>();
            foreach (SystemOperationEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemOperationWrapper> ConvertToWrapperList(IList<SystemOperationEntity> entitylist)
        {
            List<SystemOperationWrapper> list = new List<SystemOperationWrapper>();
            foreach (SystemOperationEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemOperationEntity> ConvertToEntityList(List<SystemOperationWrapper> wrapperlist)
        {
            List<SystemOperationEntity> list = new List<SystemOperationEntity>();
            foreach (SystemOperationWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemOperationWrapper ConvertEntityToWrapper(SystemOperationEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.OperationID == 0)
                return null;

            return new SystemOperationWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace
