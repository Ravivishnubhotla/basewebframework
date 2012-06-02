// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Spring.Context.Support;
using Common.Logging;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
    public partial class SystemViewWrapper   : BaseSpringNHibernateWrapper<SystemViewEntity, ISystemViewServiceProxy, SystemViewWrapper,int>
    {
        #region Member

		internal static readonly ISystemViewServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemViewServiceProxyInstance;
		
		
		internal SystemViewEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemViewWrapper() : base(new SystemViewEntity())
        {
            
        }

        internal SystemViewWrapper(SystemViewEntity entityObj)
            : base(entityObj)
        {
        }
		#endregion

        #region Process Column Name
        private static string ProcessColumnName(string columnName)
        {
            switch (columnName)
            {
		        case "ApplicationID_SystemApplicationID":
					return PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONID;
		        case "ApplicationID_SystemApplicationName":
					return PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONNAME;
		        case "ApplicationID_SystemApplicationCode":
					return PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONCODE;
		        case "ApplicationID_SystemApplicationDescription":
					return PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONDESCRIPTION;
		        case "ApplicationID_SystemApplicationUrl":
					return PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONURL;
		        case "ApplicationID_SystemApplicationIsSystemApplication":
					return PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONISSYSTEMAPPLICATION;
		        case "ApplicationID_OrderIndex":
					return PROPERTY_APPLICATIONID_ORDERINDEX;
		        case "ApplicationID_CreateBy":
					return PROPERTY_APPLICATIONID_CREATEBY;
		        case "ApplicationID_CreateAt":
					return PROPERTY_APPLICATIONID_CREATEAT;
		        case "ApplicationID_LastModifyBy":
					return PROPERTY_APPLICATIONID_LASTMODIFYBY;
		        case "ApplicationID_LastModifyAt":
					return PROPERTY_APPLICATIONID_LASTMODIFYAT;
		        case "ApplicationID_LastModifyComment":
					return PROPERTY_APPLICATIONID_LASTMODIFYCOMMENT;
              default:
                    return columnName;
            }
        }

        private static void ProcessQueryFilters(List<QueryFilter> filters)
        {
            foreach (QueryFilter queryFilter in filters)
            {
                queryFilter.FilterFieldName = ProcessColumnName(queryFilter.FilterFieldName);
            }
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
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region applicationID字段外键查询字段
        public const string PROPERTY_APPLICATIONID_ALIAS_NAME = "ApplicationID_SystemViewEntity_Alias";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONID = "ApplicationID_SystemViewEntity_Alias.SystemApplicationID";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONNAME = "ApplicationID_SystemViewEntity_Alias.SystemApplicationName";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONCODE = "ApplicationID_SystemViewEntity_Alias.SystemApplicationCode";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONDESCRIPTION = "ApplicationID_SystemViewEntity_Alias.SystemApplicationDescription";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONURL = "ApplicationID_SystemViewEntity_Alias.SystemApplicationUrl";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONISSYSTEMAPPLICATION = "ApplicationID_SystemViewEntity_Alias.SystemApplicationIsSystemApplication";
		public const string PROPERTY_APPLICATIONID_ORDERINDEX = "ApplicationID_SystemViewEntity_Alias.OrderIndex";
		public const string PROPERTY_APPLICATIONID_CREATEBY = "ApplicationID_SystemViewEntity_Alias.CreateBy";
		public const string PROPERTY_APPLICATIONID_CREATEAT = "ApplicationID_SystemViewEntity_Alias.CreateAt";
		public const string PROPERTY_APPLICATIONID_LASTMODIFYBY = "ApplicationID_SystemViewEntity_Alias.LastModifyBy";
		public const string PROPERTY_APPLICATIONID_LASTMODIFYAT = "ApplicationID_SystemViewEntity_Alias.LastModifyAt";
		public const string PROPERTY_APPLICATIONID_LASTMODIFYCOMMENT = "ApplicationID_SystemViewEntity_Alias.LastModifyComment";
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
				entity.ApplicationID = ((value == null) ? null : value.Entity);
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
		
        public static List<SystemViewWrapper> FindAllByOrderByAndFilterAndApplicationID(string orderByColumnName, bool isDesc,   SystemApplicationWrapper applicationID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndApplicationID(orderByColumnName, isDesc,   applicationID.Entity, pageQueryParams));
        }

        public static List<SystemViewWrapper> FindAllByApplicationID(SystemApplicationWrapper applicationID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByApplicationID(applicationID.Entity));
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

