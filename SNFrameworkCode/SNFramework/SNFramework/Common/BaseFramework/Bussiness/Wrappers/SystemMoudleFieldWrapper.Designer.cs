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
    public partial class SystemMoudleFieldWrapper
    {
        #region Member

		internal static readonly ISystemMoudleFieldServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemMoudleFieldServiceProxyInstance;
	 
	 
        internal SystemMoudleFieldEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SystemMoudleFieldWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SystemMoudleFieldWrapper() : this(new SystemMoudleFieldEntity())
        {
            
        }

        internal SystemMoudleFieldWrapper(SystemMoudleFieldEntity entityObj)
        {
            entity = entityObj;
        }
		#endregion
		
		#region Equals 和 HashCode 方法覆盖
		public override bool Equals(object obj)
        {
            if (obj == null && entity!=null)
            {
                if (entity.SystemMoudleFieldID == 0)
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemMoudleFieldEntity";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEFIELDID = "SystemMoudleFieldID";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEFIELDNAMEEN = "SystemMoudleFieldNameEn";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEFIELDNAMECN = "SystemMoudleFieldNameCn";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEFIELDNAMEDB = "SystemMoudleFieldNameDb";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEFIELDTYPE = "SystemMoudleFieldType";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEFIELDISREQUIRED = "SystemMoudleFieldIsRequired";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEFIELDDEFAULTVALUE = "SystemMoudleFieldDefaultValue";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEFIELDISKEYFIELD = "SystemMoudleFieldIsKeyField";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEFIELDSIZE = "SystemMoudleFieldSize";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEFIELDDESCRIPTION = "SystemMoudleFieldDescription";
		public static readonly string PROPERTY_NAME_SYSTEMMOUDLEID = "SystemMoudleID";
		public static readonly string PROPERTY_NAME_ORDERINDEX = "OrderIndex";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion


		#region Public Property
		/// <summary>
		/// ??ID
		/// </summary>		
		public int SystemMoudleFieldID
		{
			get
			{
				return entity.SystemMoudleFieldID;
			}
			set
			{
				entity.SystemMoudleFieldID = value;
			}
		}
		/// <summary>
		/// ?????
		/// </summary>		
		public string SystemMoudleFieldNameEn
		{
			get
			{
				return entity.SystemMoudleFieldNameEn;
			}
			set
			{
				entity.SystemMoudleFieldNameEn = value;
			}
		}
		/// <summary>
		/// ?????
		/// </summary>		
		public string SystemMoudleFieldNameCn
		{
			get
			{
				return entity.SystemMoudleFieldNameCn;
			}
			set
			{
				entity.SystemMoudleFieldNameCn = value;
			}
		}
		/// <summary>
		/// ??????
		/// </summary>		
		public string SystemMoudleFieldNameDb
		{
			get
			{
				return entity.SystemMoudleFieldNameDb;
			}
			set
			{
				entity.SystemMoudleFieldNameDb = value;
			}
		}
		/// <summary>
		/// ????
		/// </summary>		
		public string SystemMoudleFieldType
		{
			get
			{
				return entity.SystemMoudleFieldType;
			}
			set
			{
				entity.SystemMoudleFieldType = value;
			}
		}
		/// <summary>
		/// ??????
		/// </summary>		
		public bool? SystemMoudleFieldIsRequired
		{
			get
			{
				return entity.SystemMoudleFieldIsRequired;
			}
			set
			{
				entity.SystemMoudleFieldIsRequired = value;
			}
		}
		/// <summary>
		/// ?????
		/// </summary>		
		public string SystemMoudleFieldDefaultValue
		{
			get
			{
				return entity.SystemMoudleFieldDefaultValue;
			}
			set
			{
				entity.SystemMoudleFieldDefaultValue = value;
			}
		}
		/// <summary>
		/// ???????
		/// </summary>		
		public bool? SystemMoudleFieldIsKeyField
		{
			get
			{
				return entity.SystemMoudleFieldIsKeyField;
			}
			set
			{
				entity.SystemMoudleFieldIsKeyField = value;
			}
		}
		/// <summary>
		/// ????
		/// </summary>		
		public int? SystemMoudleFieldSize
		{
			get
			{
				return entity.SystemMoudleFieldSize;
			}
			set
			{
				entity.SystemMoudleFieldSize = value;
			}
		}
		/// <summary>
		/// ????
		/// </summary>		
		public string SystemMoudleFieldDescription
		{
			get
			{
				return entity.SystemMoudleFieldDescription;
			}
			set
			{
				entity.SystemMoudleFieldDescription = value;
			}
		}
		/// <summary>
		/// ??????ID
		/// </summary>		
		public SystemMoudleWrapper SystemMoudleID
		{
			get
			{
				return SystemMoudleWrapper.ConvertEntityToWrapper(entity.SystemMoudleID) ;
			}
			set
			{
				entity.SystemMoudleID = ((value == null) ? null : value.entity);
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
		
        public static List<SystemMoudleFieldWrapper> FindAllByOrderByAndFilterAndSystemMoudleID(string orderByColumnName, bool isDesc,   SystemMoudleWrapper systemMoudleID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndSystemMoudleID(orderByColumnName, isDesc,   systemMoudleID.entity, pageQueryParams));
        }

        public static List<SystemMoudleFieldWrapper> FindAllBySystemMoudleID(SystemMoudleWrapper systemMoudleID)
        {
            return ConvertToWrapperList(businessProxy.FindAllBySystemMoudleID(systemMoudleID.entity));
        }
		



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemMoudleFieldWrapper> ConvertToWrapperList(List<SystemMoudleFieldEntity> entitylist)
        {
            List<SystemMoudleFieldWrapper> list = new List<SystemMoudleFieldWrapper>();
            foreach (SystemMoudleFieldEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemMoudleFieldWrapper> ConvertToWrapperList(IList<SystemMoudleFieldEntity> entitylist)
        {
            List<SystemMoudleFieldWrapper> list = new List<SystemMoudleFieldWrapper>();
            foreach (SystemMoudleFieldEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemMoudleFieldEntity> ConvertToEntityList(List<SystemMoudleFieldWrapper> wrapperlist)
        {
            List<SystemMoudleFieldEntity> list = new List<SystemMoudleFieldEntity>();
            foreach (SystemMoudleFieldWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemMoudleFieldWrapper ConvertEntityToWrapper(SystemMoudleFieldEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.SystemMoudleFieldID == 0)
                return null;

            return new SystemMoudleFieldWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace
