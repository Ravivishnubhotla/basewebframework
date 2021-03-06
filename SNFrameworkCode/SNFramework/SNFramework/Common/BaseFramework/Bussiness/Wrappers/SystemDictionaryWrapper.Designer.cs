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
    public partial class SystemDictionaryWrapper    //: BaseSpringNHibernateWrapper<SystemDictionaryEntity, ISystemDictionaryServiceProxy, SystemDictionaryWrapper,int>
    {
        #region Member

		internal static readonly ISystemDictionaryServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemDictionaryServiceProxyInstance;
		
		
		internal SystemDictionaryEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemDictionaryWrapper() : base(new SystemDictionaryEntity())
        {
            
        }

        internal SystemDictionaryWrapper(SystemDictionaryEntity entityObj)
            : base(entityObj)
        {
        }
		#endregion

        #region Process Column Name
        private static string ProcessColumnName(string columnName)
        {
            switch (columnName)
            {
		        case "SystemDictionaryGroupID_Id":
					return PROPERTY_SYSTEMDICTIONARYGROUPID_ID;
		        case "SystemDictionaryGroupID_Name":
					return PROPERTY_SYSTEMDICTIONARYGROUPID_NAME;
		        case "SystemDictionaryGroupID_Code":
					return PROPERTY_SYSTEMDICTIONARYGROUPID_CODE;
		        case "SystemDictionaryGroupID_Description":
					return PROPERTY_SYSTEMDICTIONARYGROUPID_DESCRIPTION;
		        case "SystemDictionaryGroupID_IsEnable":
					return PROPERTY_SYSTEMDICTIONARYGROUPID_ISENABLE;
		        case "SystemDictionaryGroupID_IsSystem":
					return PROPERTY_SYSTEMDICTIONARYGROUPID_ISSYSTEM;
		        case "SystemDictionaryGroupID_CreateBy":
					return PROPERTY_SYSTEMDICTIONARYGROUPID_CREATEBY;
		        case "SystemDictionaryGroupID_CreateAt":
					return PROPERTY_SYSTEMDICTIONARYGROUPID_CREATEAT;
		        case "SystemDictionaryGroupID_LastModifyBy":
					return PROPERTY_SYSTEMDICTIONARYGROUPID_LASTMODIFYBY;
		        case "SystemDictionaryGroupID_LastModifyAt":
					return PROPERTY_SYSTEMDICTIONARYGROUPID_LASTMODIFYAT;
		        case "SystemDictionaryGroupID_LastModifyComment":
					return PROPERTY_SYSTEMDICTIONARYGROUPID_LASTMODIFYCOMMENT;
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemDictionaryEntity";
		public static readonly string PROPERTY_NAME_SYSTEMDICTIONARYID = "SystemDictionaryID";
		public static readonly string PROPERTY_NAME_SYSTEMDICTIONARYGROUPID = "SystemDictionaryGroupID";
		public static readonly string PROPERTY_NAME_SYSTEMDICTIONARYKEY = "SystemDictionaryKey";
		public static readonly string PROPERTY_NAME_SYSTEMDICTIONARYCODE = "SystemDictionaryCode";
		public static readonly string PROPERTY_NAME_SYSTEMDICTIONARYVALUE = "SystemDictionaryValue";
		public static readonly string PROPERTY_NAME_SYSTEMDICTIONARYDESCIPTION = "SystemDictionaryDesciption";
		public static readonly string PROPERTY_NAME_SYSTEMDICTIONARYORDER = "SystemDictionaryOrder";
		public static readonly string PROPERTY_NAME_SYSTEMDICTIONARYISENABLE = "SystemDictionaryIsEnable";
		public static readonly string PROPERTY_NAME_SYSTEMDICTIONARYISSYSTEM = "SystemDictionaryIsSystem";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region systemDictionaryGroupID字段外键查询字段
        public const string PROPERTY_SYSTEMDICTIONARYGROUPID_ALIAS_NAME = "SystemDictionaryGroupID_SystemDictionaryEntity_Alias";
		public const string PROPERTY_SYSTEMDICTIONARYGROUPID_ID = "SystemDictionaryGroupID_SystemDictionaryEntity_Alias.Id";
		public const string PROPERTY_SYSTEMDICTIONARYGROUPID_NAME = "SystemDictionaryGroupID_SystemDictionaryEntity_Alias.Name";
		public const string PROPERTY_SYSTEMDICTIONARYGROUPID_CODE = "SystemDictionaryGroupID_SystemDictionaryEntity_Alias.Code";
		public const string PROPERTY_SYSTEMDICTIONARYGROUPID_DESCRIPTION = "SystemDictionaryGroupID_SystemDictionaryEntity_Alias.Description";
		public const string PROPERTY_SYSTEMDICTIONARYGROUPID_ISENABLE = "SystemDictionaryGroupID_SystemDictionaryEntity_Alias.IsEnable";
		public const string PROPERTY_SYSTEMDICTIONARYGROUPID_ISSYSTEM = "SystemDictionaryGroupID_SystemDictionaryEntity_Alias.IsSystem";
		public const string PROPERTY_SYSTEMDICTIONARYGROUPID_CREATEBY = "SystemDictionaryGroupID_SystemDictionaryEntity_Alias.CreateBy";
		public const string PROPERTY_SYSTEMDICTIONARYGROUPID_CREATEAT = "SystemDictionaryGroupID_SystemDictionaryEntity_Alias.CreateAt";
		public const string PROPERTY_SYSTEMDICTIONARYGROUPID_LASTMODIFYBY = "SystemDictionaryGroupID_SystemDictionaryEntity_Alias.LastModifyBy";
		public const string PROPERTY_SYSTEMDICTIONARYGROUPID_LASTMODIFYAT = "SystemDictionaryGroupID_SystemDictionaryEntity_Alias.LastModifyAt";
		public const string PROPERTY_SYSTEMDICTIONARYGROUPID_LASTMODIFYCOMMENT = "SystemDictionaryGroupID_SystemDictionaryEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		


		#region Public Property
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int SystemDictionaryID
		{
			get
			{
				return entity.SystemDictionaryID;
			}
			set
			{
				entity.SystemDictionaryID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public SystemDictionaryGroupWrapper SystemDictionaryGroupID
		{
			get
			{
				return SystemDictionaryGroupWrapper.ConvertEntityToWrapper(entity.SystemDictionaryGroupID) ;
			}
			set
			{
				entity.SystemDictionaryGroupID = ((value == null) ? null : value.Entity);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string SystemDictionaryKey
		{
			get
			{
				return entity.SystemDictionaryKey;
			}
			set
			{
				entity.SystemDictionaryKey = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string SystemDictionaryCode
		{
			get
			{
				return entity.SystemDictionaryCode;
			}
			set
			{
				entity.SystemDictionaryCode = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string SystemDictionaryValue
		{
			get
			{
				return entity.SystemDictionaryValue;
			}
			set
			{
				entity.SystemDictionaryValue = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string SystemDictionaryDesciption
		{
			get
			{
				return entity.SystemDictionaryDesciption;
			}
			set
			{
				entity.SystemDictionaryDesciption = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? SystemDictionaryOrder
		{
			get
			{
				return entity.SystemDictionaryOrder;
			}
			set
			{
				entity.SystemDictionaryOrder = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool? SystemDictionaryIsEnable
		{
			get
			{
				return entity.SystemDictionaryIsEnable;
			}
			set
			{
				entity.SystemDictionaryIsEnable = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool? SystemDictionaryIsSystem
		{
			get
			{
				return entity.SystemDictionaryIsSystem;
			}
			set
			{
				entity.SystemDictionaryIsSystem = value;
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
		
		
		#region systemDictionaryGroupID字段外键查询字段
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SYSTEMDICTIONARYGROUPID_ID)]
        public int? SystemDictionaryGroupID_Id
        {
            get
            {
                if (this. SystemDictionaryGroupID == null)
                    return null;
                return  SystemDictionaryGroupID.Id;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SYSTEMDICTIONARYGROUPID_NAME)]
        public string SystemDictionaryGroupID_Name
        {
            get
            {
                if (this. SystemDictionaryGroupID == null)
                    return null;
                return  SystemDictionaryGroupID.Name;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SYSTEMDICTIONARYGROUPID_CODE)]
        public string SystemDictionaryGroupID_Code
        {
            get
            {
                if (this. SystemDictionaryGroupID == null)
                    return null;
                return  SystemDictionaryGroupID.Code;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SYSTEMDICTIONARYGROUPID_DESCRIPTION)]
        public string SystemDictionaryGroupID_Description
        {
            get
            {
                if (this. SystemDictionaryGroupID == null)
                    return null;
                return  SystemDictionaryGroupID.Description;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SYSTEMDICTIONARYGROUPID_ISENABLE)]
        public bool? SystemDictionaryGroupID_IsEnable
        {
            get
            {
                if (this. SystemDictionaryGroupID == null)
                    return null;
                return  SystemDictionaryGroupID.IsEnable;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SYSTEMDICTIONARYGROUPID_ISSYSTEM)]
        public bool? SystemDictionaryGroupID_IsSystem
        {
            get
            {
                if (this. SystemDictionaryGroupID == null)
                    return null;
                return  SystemDictionaryGroupID.IsSystem;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SYSTEMDICTIONARYGROUPID_CREATEBY)]
        public int? SystemDictionaryGroupID_CreateBy
        {
            get
            {
                if (this. SystemDictionaryGroupID == null)
                    return null;
                return  SystemDictionaryGroupID.CreateBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SYSTEMDICTIONARYGROUPID_CREATEAT)]
        public DateTime? SystemDictionaryGroupID_CreateAt
        {
            get
            {
                if (this. SystemDictionaryGroupID == null)
                    return null;
                return  SystemDictionaryGroupID.CreateAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SYSTEMDICTIONARYGROUPID_LASTMODIFYBY)]
        public int? SystemDictionaryGroupID_LastModifyBy
        {
            get
            {
                if (this. SystemDictionaryGroupID == null)
                    return null;
                return  SystemDictionaryGroupID.LastModifyBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SYSTEMDICTIONARYGROUPID_LASTMODIFYAT)]
        public DateTime? SystemDictionaryGroupID_LastModifyAt
        {
            get
            {
                if (this. SystemDictionaryGroupID == null)
                    return null;
                return  SystemDictionaryGroupID.LastModifyAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_SYSTEMDICTIONARYGROUPID_LASTMODIFYCOMMENT)]
        public string SystemDictionaryGroupID_LastModifyComment
        {
            get
            {
                if (this. SystemDictionaryGroupID == null)
                    return null;
                return  SystemDictionaryGroupID.LastModifyComment;
            }
        }
		#endregion
      	
   
		#endregion


        #region "FKQuery"
		
        public static List<SystemDictionaryWrapper> FindAllByOrderByAndFilterAndSystemDictionaryGroupID(string orderByColumnName, bool isDesc,   SystemDictionaryGroupWrapper systemDictionaryGroupID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndSystemDictionaryGroupID(orderByColumnName, isDesc,   systemDictionaryGroupID.Entity, pageQueryParams));
        }

        public static List<SystemDictionaryWrapper> FindAllBySystemDictionaryGroupID(SystemDictionaryGroupWrapper systemDictionaryGroupID)
        {
            return ConvertToWrapperList(businessProxy.FindAllBySystemDictionaryGroupID(systemDictionaryGroupID.Entity));
        }
		



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemDictionaryWrapper> ConvertToWrapperList(List<SystemDictionaryEntity> entitylist)
        {
            List<SystemDictionaryWrapper> list = new List<SystemDictionaryWrapper>();
            foreach (SystemDictionaryEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemDictionaryWrapper> ConvertToWrapperList(IList<SystemDictionaryEntity> entitylist)
        {
            List<SystemDictionaryWrapper> list = new List<SystemDictionaryWrapper>();
            foreach (SystemDictionaryEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemDictionaryEntity> ConvertToEntityList(List<SystemDictionaryWrapper> wrapperlist)
        {
            List<SystemDictionaryEntity> list = new List<SystemDictionaryEntity>();
            foreach (SystemDictionaryWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemDictionaryWrapper ConvertEntityToWrapper(SystemDictionaryEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.SystemDictionaryID == 0)
                return null;

            return new SystemDictionaryWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

