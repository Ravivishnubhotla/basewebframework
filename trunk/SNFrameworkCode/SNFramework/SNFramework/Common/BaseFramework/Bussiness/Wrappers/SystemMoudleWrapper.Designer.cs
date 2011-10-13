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
    public partial class SystemMoudleWrapper
    {
        #region Member

		internal static readonly ISystemMoudleServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemMoudleServiceProxyInstance;
	 
	 
        internal SystemMoudleEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SystemMoudleWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SystemMoudleWrapper() : this(new SystemMoudleEntity())
        {
            
        }

        internal SystemMoudleWrapper(SystemMoudleEntity entityObj)
        {
            entity = entityObj;
        }
		#endregion
		
		#region Equals 和 HashCode 方法覆盖
		public override bool Equals(object obj)
        {
            if (obj == null && entity!=null)
            {
                if (entity.MoudleID == 0)
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemMoudleEntity";
		public static readonly string PROPERTY_NAME_MOUDLEID = "MoudleID";
		public static readonly string PROPERTY_NAME_MOUDLENAMECN = "MoudleNameCn";
		public static readonly string PROPERTY_NAME_MOUDLENAMEEN = "MoudleNameEn";
		public static readonly string PROPERTY_NAME_MOUDLENAMEDB = "MoudleNameDb";
		public static readonly string PROPERTY_NAME_MOUDLEDESCRIPTION = "MoudleDescription";
		public static readonly string PROPERTY_NAME_APPLICATIONID = "ApplicationID";
		public static readonly string PROPERTY_NAME_MOUDLEISSYSTEMMOUDLE = "MoudleIsSystemMoudle";
		public static readonly string PROPERTY_NAME_ORDERINDEX = "OrderIndex";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region applicationID字段外键查询字段
        public const string PROPERTY_APPLICATIONID_ALIAS_NAME = "ApplicationID_SystemMoudleEntity_Alias";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONID = "ApplicationID_SystemMoudleEntity_Alias.SystemApplicationID";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONNAME = "ApplicationID_SystemMoudleEntity_Alias.SystemApplicationName";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONCODE = "ApplicationID_SystemMoudleEntity_Alias.SystemApplicationCode";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONDESCRIPTION = "ApplicationID_SystemMoudleEntity_Alias.SystemApplicationDescription";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONURL = "ApplicationID_SystemMoudleEntity_Alias.SystemApplicationUrl";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONISSYSTEMAPPLICATION = "ApplicationID_SystemMoudleEntity_Alias.SystemApplicationIsSystemApplication";
		public const string PROPERTY_APPLICATIONID_ORDERINDEX = "ApplicationID_SystemMoudleEntity_Alias.OrderIndex";
		public const string PROPERTY_APPLICATIONID_CREATEBY = "ApplicationID_SystemMoudleEntity_Alias.CreateBy";
		public const string PROPERTY_APPLICATIONID_CREATEAT = "ApplicationID_SystemMoudleEntity_Alias.CreateAt";
		public const string PROPERTY_APPLICATIONID_LASTMODIFYBY = "ApplicationID_SystemMoudleEntity_Alias.LastModifyBy";
		public const string PROPERTY_APPLICATIONID_LASTMODIFYAT = "ApplicationID_SystemMoudleEntity_Alias.LastModifyAt";
		public const string PROPERTY_APPLICATIONID_LASTMODIFYCOMMENT = "ApplicationID_SystemMoudleEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		


		#region Public Property
		/// <summary>
		/// Primary Key
		/// </summary>		
		public int MoudleID
		{
			get
			{
				return entity.MoudleID;
			}
			set
			{
				entity.MoudleID = value;
			}
		}
		/// <summary>
		/// Moudle Name
		/// </summary>		
		public string MoudleNameCn
		{
			get
			{
				return entity.MoudleNameCn;
			}
			set
			{
				entity.MoudleNameCn = value;
			}
		}
		/// <summary>
		/// Moudle Code
		/// </summary>		
		public string MoudleNameEn
		{
			get
			{
				return entity.MoudleNameEn;
			}
			set
			{
				entity.MoudleNameEn = value;
			}
		}
		/// <summary>
		/// moudle of Table
		/// </summary>		
		public string MoudleNameDb
		{
			get
			{
				return entity.MoudleNameDb;
			}
			set
			{
				entity.MoudleNameDb = value;
			}
		}
		/// <summary>
		/// Moudle Description
		/// </summary>		
		public string MoudleDescription
		{
			get
			{
				return entity.MoudleDescription;
			}
			set
			{
				entity.MoudleDescription = value;
			}
		}
		/// <summary>
		/// Application ID
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
		/// Is System Moudle
		/// </summary>		
		public bool MoudleIsSystemMoudle
		{
			get
			{
				return entity.MoudleIsSystemMoudle;
			}
			set
			{
				entity.MoudleIsSystemMoudle = value;
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


		#region Query Property
		
		
		#region applicationID字段外键查询字段
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONID)]
        public int? ApplicationID_SystemApplicationID
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.SystemApplicationID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONNAME)]
        public string ApplicationID_SystemApplicationName
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.SystemApplicationName;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONCODE)]
        public string ApplicationID_SystemApplicationCode
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.SystemApplicationCode;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONDESCRIPTION)]
        public string ApplicationID_SystemApplicationDescription
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.SystemApplicationDescription;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONURL)]
        public string ApplicationID_SystemApplicationUrl
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.SystemApplicationUrl;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONISSYSTEMAPPLICATION)]
        public bool? ApplicationID_SystemApplicationIsSystemApplication
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.SystemApplicationIsSystemApplication;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_ORDERINDEX)]
        public int? ApplicationID_OrderIndex
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.OrderIndex;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_CREATEBY)]
        public int? ApplicationID_CreateBy
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.CreateBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_CREATEAT)]
        public DateTime? ApplicationID_CreateAt
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.CreateAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_LASTMODIFYBY)]
        public int? ApplicationID_LastModifyBy
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.LastModifyBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_LASTMODIFYAT)]
        public DateTime? ApplicationID_LastModifyAt
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.LastModifyAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_LASTMODIFYCOMMENT)]
        public string ApplicationID_LastModifyComment
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.LastModifyComment;
            }
        }
		#endregion
      	
   
		#endregion


        #region "FKQuery"
		
        public static List<SystemMoudleWrapper> FindAllByOrderByAndFilterAndApplicationID(string orderByColumnName, bool isDesc,   SystemApplicationWrapper applicationID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndApplicationID(orderByColumnName, isDesc,   applicationID.entity, pageQueryParams));
        }

        public static List<SystemMoudleWrapper> FindAllByApplicationID(SystemApplicationWrapper applicationID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByApplicationID(applicationID.entity));
        }
		



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemMoudleWrapper> ConvertToWrapperList(List<SystemMoudleEntity> entitylist)
        {
            List<SystemMoudleWrapper> list = new List<SystemMoudleWrapper>();
            foreach (SystemMoudleEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemMoudleWrapper> ConvertToWrapperList(IList<SystemMoudleEntity> entitylist)
        {
            List<SystemMoudleWrapper> list = new List<SystemMoudleWrapper>();
            foreach (SystemMoudleEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemMoudleEntity> ConvertToEntityList(List<SystemMoudleWrapper> wrapperlist)
        {
            List<SystemMoudleEntity> list = new List<SystemMoudleEntity>();
            foreach (SystemMoudleWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemMoudleWrapper ConvertEntityToWrapper(SystemMoudleEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.MoudleID == 0)
                return null;

            return new SystemMoudleWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

