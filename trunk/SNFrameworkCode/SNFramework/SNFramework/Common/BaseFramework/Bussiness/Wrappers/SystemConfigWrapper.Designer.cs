// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
    public partial class SystemConfigWrapper    //: BaseSpringNHibernateWrapper<SystemConfigEntity, ISystemConfigServiceProxy, SystemConfigWrapper,int>
    {
        #region Member

		internal static readonly ISystemConfigServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemConfigServiceProxyInstance;
		
		
		internal SystemConfigEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemConfigWrapper() : base(new SystemConfigEntity())
        {
            
        }

        internal SystemConfigWrapper(SystemConfigEntity entityObj)
            : base(entityObj)
        {
        }
		#endregion

        #region Process Column Name
        private static string ProcessColumnName(string columnName)
        {
            switch (columnName)
            {
		        case "ConfigGroupID_Id":
					return PROPERTY_CONFIGGROUPID_ID;
		        case "ConfigGroupID_Name":
					return PROPERTY_CONFIGGROUPID_NAME;
		        case "ConfigGroupID_Code":
					return PROPERTY_CONFIGGROUPID_CODE;
		        case "ConfigGroupID_Description":
					return PROPERTY_CONFIGGROUPID_DESCRIPTION;
		        case "ConfigGroupID_IsEnable":
					return PROPERTY_CONFIGGROUPID_ISENABLE;
		        case "ConfigGroupID_IsSystem":
					return PROPERTY_CONFIGGROUPID_ISSYSTEM;
		        case "ConfigGroupID_CreateBy":
					return PROPERTY_CONFIGGROUPID_CREATEBY;
		        case "ConfigGroupID_CreateAt":
					return PROPERTY_CONFIGGROUPID_CREATEAT;
		        case "ConfigGroupID_LastModifyBy":
					return PROPERTY_CONFIGGROUPID_LASTMODIFYBY;
		        case "ConfigGroupID_LastModifyAt":
					return PROPERTY_CONFIGGROUPID_LASTMODIFYAT;
		        case "ConfigGroupID_LastModifyComment":
					return PROPERTY_CONFIGGROUPID_LASTMODIFYCOMMENT;
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemConfigEntity";
		public static readonly string PROPERTY_NAME_SYSTEMCONFIGID = "SystemConfigID";
		public static readonly string PROPERTY_NAME_CONFIGKEY = "ConfigKey";
		public static readonly string PROPERTY_NAME_CONFIGVALUE = "ConfigValue";
		public static readonly string PROPERTY_NAME_CONFIGDATATYPE = "ConfigDataType";
		public static readonly string PROPERTY_NAME_CONFIGDESCRIPTION = "ConfigDescription";
		public static readonly string PROPERTY_NAME_SORTINDEX = "SortIndex";
		public static readonly string PROPERTY_NAME_CONFIGGROUPID = "ConfigGroupID";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region configGroupID字段外键查询字段
        public const string PROPERTY_CONFIGGROUPID_ALIAS_NAME = "ConfigGroupID_SystemConfigEntity_Alias";
		public const string PROPERTY_CONFIGGROUPID_ID = "ConfigGroupID_SystemConfigEntity_Alias.Id";
		public const string PROPERTY_CONFIGGROUPID_NAME = "ConfigGroupID_SystemConfigEntity_Alias.Name";
		public const string PROPERTY_CONFIGGROUPID_CODE = "ConfigGroupID_SystemConfigEntity_Alias.Code";
		public const string PROPERTY_CONFIGGROUPID_DESCRIPTION = "ConfigGroupID_SystemConfigEntity_Alias.Description";
		public const string PROPERTY_CONFIGGROUPID_ISENABLE = "ConfigGroupID_SystemConfigEntity_Alias.IsEnable";
		public const string PROPERTY_CONFIGGROUPID_ISSYSTEM = "ConfigGroupID_SystemConfigEntity_Alias.IsSystem";
		public const string PROPERTY_CONFIGGROUPID_CREATEBY = "ConfigGroupID_SystemConfigEntity_Alias.CreateBy";
		public const string PROPERTY_CONFIGGROUPID_CREATEAT = "ConfigGroupID_SystemConfigEntity_Alias.CreateAt";
		public const string PROPERTY_CONFIGGROUPID_LASTMODIFYBY = "ConfigGroupID_SystemConfigEntity_Alias.LastModifyBy";
		public const string PROPERTY_CONFIGGROUPID_LASTMODIFYAT = "ConfigGroupID_SystemConfigEntity_Alias.LastModifyAt";
		public const string PROPERTY_CONFIGGROUPID_LASTMODIFYCOMMENT = "ConfigGroupID_SystemConfigEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		


		#region Public Property
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
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
		[DataMember]
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
		[DataMember]
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
		[DataMember]
		public string ConfigDataType
		{
			get
			{
				return entity.ConfigDataType;
			}
			set
			{
				entity.ConfigDataType = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
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
		[DataMember]
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
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public SystemConfigGroupWrapper ConfigGroupID
		{
			get
			{
				return SystemConfigGroupWrapper.ConvertEntityToWrapper(entity.ConfigGroupID) ;
			}
			set
			{
				entity.ConfigGroupID = ((value == null) ? null : value.Entity);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
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
		[DataMember]
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
		[DataMember]
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
		[DataMember]
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
		[DataMember]
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
		
		
		#region configGroupID字段外键查询字段
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CONFIGGROUPID_ID)]
        public int? ConfigGroupID_Id
        {
            get
            {
                if (this. ConfigGroupID == null)
                    return null;
                return  ConfigGroupID.Id;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CONFIGGROUPID_NAME)]
        public string ConfigGroupID_Name
        {
            get
            {
                if (this. ConfigGroupID == null)
                    return null;
                return  ConfigGroupID.Name;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CONFIGGROUPID_CODE)]
        public string ConfigGroupID_Code
        {
            get
            {
                if (this. ConfigGroupID == null)
                    return null;
                return  ConfigGroupID.Code;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CONFIGGROUPID_DESCRIPTION)]
        public string ConfigGroupID_Description
        {
            get
            {
                if (this. ConfigGroupID == null)
                    return null;
                return  ConfigGroupID.Description;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CONFIGGROUPID_ISENABLE)]
        public bool? ConfigGroupID_IsEnable
        {
            get
            {
                if (this. ConfigGroupID == null)
                    return null;
                return  ConfigGroupID.IsEnable;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CONFIGGROUPID_ISSYSTEM)]
        public bool? ConfigGroupID_IsSystem
        {
            get
            {
                if (this. ConfigGroupID == null)
                    return null;
                return  ConfigGroupID.IsSystem;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CONFIGGROUPID_CREATEBY)]
        public int? ConfigGroupID_CreateBy
        {
            get
            {
                if (this. ConfigGroupID == null)
                    return null;
                return  ConfigGroupID.CreateBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CONFIGGROUPID_CREATEAT)]
        public DateTime? ConfigGroupID_CreateAt
        {
            get
            {
                if (this. ConfigGroupID == null)
                    return null;
                return  ConfigGroupID.CreateAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CONFIGGROUPID_LASTMODIFYBY)]
        public int? ConfigGroupID_LastModifyBy
        {
            get
            {
                if (this. ConfigGroupID == null)
                    return null;
                return  ConfigGroupID.LastModifyBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CONFIGGROUPID_LASTMODIFYAT)]
        public DateTime? ConfigGroupID_LastModifyAt
        {
            get
            {
                if (this. ConfigGroupID == null)
                    return null;
                return  ConfigGroupID.LastModifyAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CONFIGGROUPID_LASTMODIFYCOMMENT)]
        public string ConfigGroupID_LastModifyComment
        {
            get
            {
                if (this. ConfigGroupID == null)
                    return null;
                return  ConfigGroupID.LastModifyComment;
            }
        }
		#endregion
      	
   
		#endregion


        #region "FKQuery"
		
        public static List<SystemConfigWrapper> FindAllByOrderByAndFilterAndConfigGroupID(string orderByColumnName, bool isDesc,   SystemConfigGroupWrapper configGroupID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndConfigGroupID(orderByColumnName, isDesc,   configGroupID.Entity, pageQueryParams));
        }

        public static List<SystemConfigWrapper> FindAllByConfigGroupID(SystemConfigGroupWrapper configGroupID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByConfigGroupID(configGroupID.Entity));
        }
		



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

