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
    public partial class SystemOperationWrapper
    {
        #region Member

		internal static readonly ISystemOperationServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemOperationServiceProxyInstance;
	 
	 
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
		public static readonly string PROPERTY_NAME_ISCOMMONOPERATION = "IsCommonOperation";
		public static readonly string PROPERTY_NAME_RESOURCEID = "ResourceID";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region resourceID字段外键查询字段
        public const string PROPERTY_RESOURCEID_ALIAS_NAME = "ResourceID_SystemOperationEntity_Alias";
		public const string PROPERTY_RESOURCEID_RESOURCESID = "ResourceID_SystemOperationEntity_Alias.ResourcesID";
		public const string PROPERTY_RESOURCEID_RESOURCESNAMECN = "ResourceID_SystemOperationEntity_Alias.ResourcesNameCn";
		public const string PROPERTY_RESOURCEID_RESOURCESNAMEEN = "ResourceID_SystemOperationEntity_Alias.ResourcesNameEn";
		public const string PROPERTY_RESOURCEID_RESOURCESDESCRIPTION = "ResourceID_SystemOperationEntity_Alias.ResourcesDescription";
		public const string PROPERTY_RESOURCEID_RESOURCESTYPE = "ResourceID_SystemOperationEntity_Alias.ResourcesType";
		public const string PROPERTY_RESOURCEID_RESOURCESLIMITEXPRESSION = "ResourceID_SystemOperationEntity_Alias.ResourcesLimitExpression";
		public const string PROPERTY_RESOURCEID_RESOURCESISRELATEUSER = "ResourceID_SystemOperationEntity_Alias.ResourcesIsRelateUser";
		public const string PROPERTY_RESOURCEID_MOUDLEID = "ResourceID_SystemOperationEntity_Alias.MoudleID";
		public const string PROPERTY_RESOURCEID_PARENTRESOURCESID = "ResourceID_SystemOperationEntity_Alias.ParentResourcesID";
		public const string PROPERTY_RESOURCEID_ORDERINDEX = "ResourceID_SystemOperationEntity_Alias.OrderIndex";
		public const string PROPERTY_RESOURCEID_CREATEBY = "ResourceID_SystemOperationEntity_Alias.CreateBy";
		public const string PROPERTY_RESOURCEID_CREATEAT = "ResourceID_SystemOperationEntity_Alias.CreateAt";
		public const string PROPERTY_RESOURCEID_LASTMODIFYBY = "ResourceID_SystemOperationEntity_Alias.LastModifyBy";
		public const string PROPERTY_RESOURCEID_LASTMODIFYAT = "ResourceID_SystemOperationEntity_Alias.LastModifyAt";
		public const string PROPERTY_RESOURCEID_LASTMODIFYCOMMENT = "ResourceID_SystemOperationEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		


		#region Public Property
		/// <summary>
		/// ??
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
		/// ?????
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
		/// ????
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
		/// ????
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
		/// ???????
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
		/// ??????????
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
		/// ??????????
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
		/// ????
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
		/// ?????????
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
		/// ?????????
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
		/// ?????
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
		/// <summary>
		/// 
		/// </summary>		
		public bool? IsCommonOperation
		{
			get
			{
				return entity.IsCommonOperation;
			}
			set
			{
				entity.IsCommonOperation = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public SystemResourcesWrapper ResourceID
		{
			get
			{
				return SystemResourcesWrapper.ConvertEntityToWrapper(entity.ResourceID) ;
			}
			set
			{
				entity.ResourceID = ((value == null) ? null : value.entity);
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


		#region Query Property
		
		
		#region resourceID字段外键查询字段
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_RESOURCEID_RESOURCESID)]
        public int? ResourceID_ResourcesID
        {
            get
            {
                if (this. ResourceID == null)
                    return null;
                return  ResourceID.ResourcesID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_RESOURCEID_RESOURCESNAMECN)]
        public string ResourceID_ResourcesNameCn
        {
            get
            {
                if (this. ResourceID == null)
                    return null;
                return  ResourceID.ResourcesNameCn;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_RESOURCEID_RESOURCESNAMEEN)]
        public string ResourceID_ResourcesNameEn
        {
            get
            {
                if (this. ResourceID == null)
                    return null;
                return  ResourceID.ResourcesNameEn;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_RESOURCEID_RESOURCESDESCRIPTION)]
        public string ResourceID_ResourcesDescription
        {
            get
            {
                if (this. ResourceID == null)
                    return null;
                return  ResourceID.ResourcesDescription;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_RESOURCEID_RESOURCESTYPE)]
        public string ResourceID_ResourcesType
        {
            get
            {
                if (this. ResourceID == null)
                    return null;
                return  ResourceID.ResourcesType;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_RESOURCEID_RESOURCESLIMITEXPRESSION)]
        public string ResourceID_ResourcesLimitExpression
        {
            get
            {
                if (this. ResourceID == null)
                    return null;
                return  ResourceID.ResourcesLimitExpression;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_RESOURCEID_RESOURCESISRELATEUSER)]
        public bool? ResourceID_ResourcesIsRelateUser
        {
            get
            {
                if (this. ResourceID == null)
                    return null;
                return  ResourceID.ResourcesIsRelateUser;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_RESOURCEID_MOUDLEID)]
        public SystemMoudleWrapper ResourceID_MoudleID
        {
            get
            {
                if (this. ResourceID == null)
                    return null;
                return  ResourceID.MoudleID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_RESOURCEID_PARENTRESOURCESID)]
        public SystemResourcesWrapper ResourceID_ParentResourcesID
        {
            get
            {
                if (this. ResourceID == null)
                    return null;
                return  ResourceID.ParentResourcesID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_RESOURCEID_ORDERINDEX)]
        public int? ResourceID_OrderIndex
        {
            get
            {
                if (this. ResourceID == null)
                    return null;
                return  ResourceID.OrderIndex;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_RESOURCEID_CREATEBY)]
        public int? ResourceID_CreateBy
        {
            get
            {
                if (this. ResourceID == null)
                    return null;
                return  ResourceID.CreateBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_RESOURCEID_CREATEAT)]
        public DateTime? ResourceID_CreateAt
        {
            get
            {
                if (this. ResourceID == null)
                    return null;
                return  ResourceID.CreateAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_RESOURCEID_LASTMODIFYBY)]
        public int? ResourceID_LastModifyBy
        {
            get
            {
                if (this. ResourceID == null)
                    return null;
                return  ResourceID.LastModifyBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_RESOURCEID_LASTMODIFYAT)]
        public DateTime? ResourceID_LastModifyAt
        {
            get
            {
                if (this. ResourceID == null)
                    return null;
                return  ResourceID.LastModifyAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_RESOURCEID_LASTMODIFYCOMMENT)]
        public string ResourceID_LastModifyComment
        {
            get
            {
                if (this. ResourceID == null)
                    return null;
                return  ResourceID.LastModifyComment;
            }
        }
		#endregion
      	
   
		#endregion


        #region "FKQuery"
		
        public static List<SystemOperationWrapper> FindAllByOrderByAndFilterAndResourceID(string orderByColumnName, bool isDesc,   SystemResourcesWrapper resourceID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndResourceID(orderByColumnName, isDesc,   resourceID.entity, pageQueryParams));
        }

        public static List<SystemOperationWrapper> FindAllByResourceID(SystemResourcesWrapper resourceID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByResourceID(resourceID.entity));
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
