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
    public partial class SystemPrivilegeInRolesWrapper    //: BaseSpringNHibernateWrapper<SystemPrivilegeInRolesEntity, ISystemPrivilegeInRolesServiceProxy, SystemPrivilegeInRolesWrapper,int>
    {
        #region Member

		internal static readonly ISystemPrivilegeInRolesServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemPrivilegeInRolesServiceProxyInstance;
		
		
		internal SystemPrivilegeInRolesEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemPrivilegeInRolesWrapper() : base(new SystemPrivilegeInRolesEntity())
        {
            
        }

        internal SystemPrivilegeInRolesWrapper(SystemPrivilegeInRolesEntity entityObj)
            : base(entityObj)
        {
        }
		#endregion

        #region Process Column Name
        private static string ProcessColumnName(string columnName)
        {
            switch (columnName)
            {
		        case "RoleID_RoleID":
					return PROPERTY_ROLEID_ROLEID;
		        case "RoleID_RoleName":
					return PROPERTY_ROLEID_ROLENAME;
		        case "RoleID_RoleCode":
					return PROPERTY_ROLEID_ROLECODE;
		        case "RoleID_RoleDescription":
					return PROPERTY_ROLEID_ROLEDESCRIPTION;
		        case "RoleID_RoleIsSystemRole":
					return PROPERTY_ROLEID_ROLEISSYSTEMROLE;
		        case "RoleID_RoleType":
					return PROPERTY_ROLEID_ROLETYPE;
		        case "RoleID_CreateBy":
					return PROPERTY_ROLEID_CREATEBY;
		        case "RoleID_CreateAt":
					return PROPERTY_ROLEID_CREATEAT;
		        case "RoleID_LastModifyBy":
					return PROPERTY_ROLEID_LASTMODIFYBY;
		        case "RoleID_LastModifyAt":
					return PROPERTY_ROLEID_LASTMODIFYAT;
		        case "RoleID_LastModifyComment":
					return PROPERTY_ROLEID_LASTMODIFYCOMMENT;
		        case "PrivilegeID_PrivilegeID":
					return PROPERTY_PRIVILEGEID_PRIVILEGEID;
		        case "PrivilegeID_OperationID":
					return PROPERTY_PRIVILEGEID_OPERATIONID;
		        case "PrivilegeID_ResourcesID":
					return PROPERTY_PRIVILEGEID_RESOURCESID;
		        case "PrivilegeID_PrivilegeCnName":
					return PROPERTY_PRIVILEGEID_PRIVILEGECNNAME;
		        case "PrivilegeID_PrivilegeEnName":
					return PROPERTY_PRIVILEGEID_PRIVILEGEENNAME;
		        case "PrivilegeID_DefaultValue":
					return PROPERTY_PRIVILEGEID_DEFAULTVALUE;
		        case "PrivilegeID_Description":
					return PROPERTY_PRIVILEGEID_DESCRIPTION;
		        case "PrivilegeID_PrivilegeOrder":
					return PROPERTY_PRIVILEGEID_PRIVILEGEORDER;
		        case "PrivilegeID_PrivilegeType":
					return PROPERTY_PRIVILEGEID_PRIVILEGETYPE;
		        case "PrivilegeID_CreateBy":
					return PROPERTY_PRIVILEGEID_CREATEBY;
		        case "PrivilegeID_CreateAt":
					return PROPERTY_PRIVILEGEID_CREATEAT;
		        case "PrivilegeID_LastModifyBy":
					return PROPERTY_PRIVILEGEID_LASTMODIFYBY;
		        case "PrivilegeID_LastModifyAt":
					return PROPERTY_PRIVILEGEID_LASTMODIFYAT;
		        case "PrivilegeID_LastModifyComment":
					return PROPERTY_PRIVILEGEID_LASTMODIFYCOMMENT;
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemPrivilegeInRolesEntity";
		public static readonly string PROPERTY_NAME_PRIVILEGEROLEID = "PrivilegeRoleID";
		public static readonly string PROPERTY_NAME_ROLEID = "RoleID";
		public static readonly string PROPERTY_NAME_PRIVILEGEID = "PrivilegeID";
		public static readonly string PROPERTY_NAME_PRIVILEGEROLEVALUETYPE = "PrivilegeRoleValueType";
		public static readonly string PROPERTY_NAME_ENABLETYPE = "EnableType";
		public static readonly string PROPERTY_NAME_CREATETIME = "CreateTime";
		public static readonly string PROPERTY_NAME_UPDATETIME = "UpdateTime";
		public static readonly string PROPERTY_NAME_EXPIRYTIME = "ExpiryTime";
		public static readonly string PROPERTY_NAME_ENABLEPARAMETER = "EnableParameter";
		public static readonly string PROPERTY_NAME_PRIVILEGEROLEVALUE = "PrivilegeRoleValue";
		
        #endregion
	
 
		#region roleID字段外键查询字段
        public const string PROPERTY_ROLEID_ALIAS_NAME = "RoleID_SystemPrivilegeInRolesEntity_Alias";
		public const string PROPERTY_ROLEID_ROLEID = "RoleID_SystemPrivilegeInRolesEntity_Alias.RoleID";
		public const string PROPERTY_ROLEID_ROLENAME = "RoleID_SystemPrivilegeInRolesEntity_Alias.RoleName";
		public const string PROPERTY_ROLEID_ROLECODE = "RoleID_SystemPrivilegeInRolesEntity_Alias.RoleCode";
		public const string PROPERTY_ROLEID_ROLEDESCRIPTION = "RoleID_SystemPrivilegeInRolesEntity_Alias.RoleDescription";
		public const string PROPERTY_ROLEID_ROLEISSYSTEMROLE = "RoleID_SystemPrivilegeInRolesEntity_Alias.RoleIsSystemRole";
		public const string PROPERTY_ROLEID_ROLETYPE = "RoleID_SystemPrivilegeInRolesEntity_Alias.RoleType";
		public const string PROPERTY_ROLEID_CREATEBY = "RoleID_SystemPrivilegeInRolesEntity_Alias.CreateBy";
		public const string PROPERTY_ROLEID_CREATEAT = "RoleID_SystemPrivilegeInRolesEntity_Alias.CreateAt";
		public const string PROPERTY_ROLEID_LASTMODIFYBY = "RoleID_SystemPrivilegeInRolesEntity_Alias.LastModifyBy";
		public const string PROPERTY_ROLEID_LASTMODIFYAT = "RoleID_SystemPrivilegeInRolesEntity_Alias.LastModifyAt";
		public const string PROPERTY_ROLEID_LASTMODIFYCOMMENT = "RoleID_SystemPrivilegeInRolesEntity_Alias.LastModifyComment";
		#endregion
		#region privilegeID字段外键查询字段
        public const string PROPERTY_PRIVILEGEID_ALIAS_NAME = "PrivilegeID_SystemPrivilegeInRolesEntity_Alias";
		public const string PROPERTY_PRIVILEGEID_PRIVILEGEID = "PrivilegeID_SystemPrivilegeInRolesEntity_Alias.PrivilegeID";
		public const string PROPERTY_PRIVILEGEID_OPERATIONID = "PrivilegeID_SystemPrivilegeInRolesEntity_Alias.OperationID";
		public const string PROPERTY_PRIVILEGEID_RESOURCESID = "PrivilegeID_SystemPrivilegeInRolesEntity_Alias.ResourcesID";
		public const string PROPERTY_PRIVILEGEID_PRIVILEGECNNAME = "PrivilegeID_SystemPrivilegeInRolesEntity_Alias.PrivilegeCnName";
		public const string PROPERTY_PRIVILEGEID_PRIVILEGEENNAME = "PrivilegeID_SystemPrivilegeInRolesEntity_Alias.PrivilegeEnName";
		public const string PROPERTY_PRIVILEGEID_DEFAULTVALUE = "PrivilegeID_SystemPrivilegeInRolesEntity_Alias.DefaultValue";
		public const string PROPERTY_PRIVILEGEID_DESCRIPTION = "PrivilegeID_SystemPrivilegeInRolesEntity_Alias.Description";
		public const string PROPERTY_PRIVILEGEID_PRIVILEGEORDER = "PrivilegeID_SystemPrivilegeInRolesEntity_Alias.PrivilegeOrder";
		public const string PROPERTY_PRIVILEGEID_PRIVILEGETYPE = "PrivilegeID_SystemPrivilegeInRolesEntity_Alias.PrivilegeType";
		public const string PROPERTY_PRIVILEGEID_CREATEBY = "PrivilegeID_SystemPrivilegeInRolesEntity_Alias.CreateBy";
		public const string PROPERTY_PRIVILEGEID_CREATEAT = "PrivilegeID_SystemPrivilegeInRolesEntity_Alias.CreateAt";
		public const string PROPERTY_PRIVILEGEID_LASTMODIFYBY = "PrivilegeID_SystemPrivilegeInRolesEntity_Alias.LastModifyBy";
		public const string PROPERTY_PRIVILEGEID_LASTMODIFYAT = "PrivilegeID_SystemPrivilegeInRolesEntity_Alias.LastModifyAt";
		public const string PROPERTY_PRIVILEGEID_LASTMODIFYCOMMENT = "PrivilegeID_SystemPrivilegeInRolesEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		


		#region Public Property
		/// <summary>
		/// ??
		/// </summary>
		[DataMember]
		public int PrivilegeRoleID
		{
			get
			{
				return entity.PrivilegeRoleID;
			}
			set
			{
				entity.PrivilegeRoleID = value;
			}
		}
		/// <summary>
		/// ??ID
		/// </summary>
		[DataMember]
		public SystemRoleWrapper RoleID
		{
			get
			{
				return SystemRoleWrapper.ConvertEntityToWrapper(entity.RoleID) ;
			}
			set
			{
				entity.RoleID = ((value == null) ? null : value.Entity);
			}
		}
		/// <summary>
		/// ??ID
		/// </summary>
		[DataMember]
		public SystemPrivilegeWrapper PrivilegeID
		{
			get
			{
				return SystemPrivilegeWrapper.ConvertEntityToWrapper(entity.PrivilegeID) ;
			}
			set
			{
				entity.PrivilegeID = ((value == null) ? null : value.Entity);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string PrivilegeRoleValueType
		{
			get
			{
				return entity.PrivilegeRoleValueType;
			}
			set
			{
				entity.PrivilegeRoleValueType = value;
			}
		}
		/// <summary>
		/// ????
		/// </summary>
		[DataMember]
		public string EnableType
		{
			get
			{
				return entity.EnableType;
			}
			set
			{
				entity.EnableType = value;
			}
		}
		/// <summary>
		/// ????
		/// </summary>
		[DataMember]
		public DateTime CreateTime
		{
			get
			{
				return entity.CreateTime;
			}
			set
			{
				entity.CreateTime = value;
			}
		}
		/// <summary>
		/// ??????
		/// </summary>
		[DataMember]
		public DateTime UpdateTime
		{
			get
			{
				return entity.UpdateTime;
			}
			set
			{
				entity.UpdateTime = value;
			}
		}
		/// <summary>
		/// ????
		/// </summary>
		[DataMember]
		public DateTime ExpiryTime
		{
			get
			{
				return entity.ExpiryTime;
			}
			set
			{
				entity.ExpiryTime = value;
			}
		}
		/// <summary>
		/// ??????
		/// </summary>
		[DataMember]
		public bool EnableParameter
		{
			get
			{
				return entity.EnableParameter;
			}
			set
			{
				entity.EnableParameter = value;
			}
		}
		/// <summary>
		/// ?????
		/// </summary>
		[DataMember]
		public byte[] PrivilegeRoleValue
		{
			get
			{
				return entity.PrivilegeRoleValue;
			}
			set
			{
				entity.PrivilegeRoleValue = value;
			}
		}
		#endregion 


		#region Query Property
		
		
		#region roleID字段外键查询字段
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_ROLEID)]
        public int? RoleID_RoleID
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.RoleID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_ROLENAME)]
        public string RoleID_RoleName
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.RoleName;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_ROLECODE)]
        public string RoleID_RoleCode
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.RoleCode;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_ROLEDESCRIPTION)]
        public string RoleID_RoleDescription
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.RoleDescription;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_ROLEISSYSTEMROLE)]
        public bool? RoleID_RoleIsSystemRole
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.RoleIsSystemRole;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_ROLETYPE)]
        public string RoleID_RoleType
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.RoleType;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_CREATEBY)]
        public int? RoleID_CreateBy
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.CreateBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_CREATEAT)]
        public DateTime? RoleID_CreateAt
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.CreateAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_LASTMODIFYBY)]
        public int? RoleID_LastModifyBy
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.LastModifyBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_LASTMODIFYAT)]
        public DateTime? RoleID_LastModifyAt
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.LastModifyAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ROLEID_LASTMODIFYCOMMENT)]
        public string RoleID_LastModifyComment
        {
            get
            {
                if (this. RoleID == null)
                    return null;
                return  RoleID.LastModifyComment;
            }
        }
		#endregion
		#region privilegeID字段外键查询字段
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_PRIVILEGEID_PRIVILEGEID)]
        public int? PrivilegeID_PrivilegeID
        {
            get
            {
                if (this. PrivilegeID == null)
                    return null;
                return  PrivilegeID.PrivilegeID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_PRIVILEGEID_OPERATIONID)]
        public SystemOperationWrapper PrivilegeID_OperationID
        {
            get
            {
                if (this. PrivilegeID == null)
                    return null;
                return  PrivilegeID.OperationID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_PRIVILEGEID_RESOURCESID)]
        public SystemResourcesWrapper PrivilegeID_ResourcesID
        {
            get
            {
                if (this. PrivilegeID == null)
                    return null;
                return  PrivilegeID.ResourcesID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_PRIVILEGEID_PRIVILEGECNNAME)]
        public string PrivilegeID_PrivilegeCnName
        {
            get
            {
                if (this. PrivilegeID == null)
                    return null;
                return  PrivilegeID.PrivilegeCnName;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_PRIVILEGEID_PRIVILEGEENNAME)]
        public string PrivilegeID_PrivilegeEnName
        {
            get
            {
                if (this. PrivilegeID == null)
                    return null;
                return  PrivilegeID.PrivilegeEnName;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_PRIVILEGEID_DEFAULTVALUE)]
        public string PrivilegeID_DefaultValue
        {
            get
            {
                if (this. PrivilegeID == null)
                    return null;
                return  PrivilegeID.DefaultValue;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_PRIVILEGEID_DESCRIPTION)]
        public string PrivilegeID_Description
        {
            get
            {
                if (this. PrivilegeID == null)
                    return null;
                return  PrivilegeID.Description;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_PRIVILEGEID_PRIVILEGEORDER)]
        public int? PrivilegeID_PrivilegeOrder
        {
            get
            {
                if (this. PrivilegeID == null)
                    return null;
                return  PrivilegeID.PrivilegeOrder;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_PRIVILEGEID_PRIVILEGETYPE)]
        public string PrivilegeID_PrivilegeType
        {
            get
            {
                if (this. PrivilegeID == null)
                    return null;
                return  PrivilegeID.PrivilegeType;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_PRIVILEGEID_CREATEBY)]
        public int? PrivilegeID_CreateBy
        {
            get
            {
                if (this. PrivilegeID == null)
                    return null;
                return  PrivilegeID.CreateBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_PRIVILEGEID_CREATEAT)]
        public DateTime? PrivilegeID_CreateAt
        {
            get
            {
                if (this. PrivilegeID == null)
                    return null;
                return  PrivilegeID.CreateAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_PRIVILEGEID_LASTMODIFYBY)]
        public int? PrivilegeID_LastModifyBy
        {
            get
            {
                if (this. PrivilegeID == null)
                    return null;
                return  PrivilegeID.LastModifyBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_PRIVILEGEID_LASTMODIFYAT)]
        public DateTime? PrivilegeID_LastModifyAt
        {
            get
            {
                if (this. PrivilegeID == null)
                    return null;
                return  PrivilegeID.LastModifyAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_PRIVILEGEID_LASTMODIFYCOMMENT)]
        public string PrivilegeID_LastModifyComment
        {
            get
            {
                if (this. PrivilegeID == null)
                    return null;
                return  PrivilegeID.LastModifyComment;
            }
        }
		#endregion
      	
   
		#endregion


        #region "FKQuery"
		
        public static List<SystemPrivilegeInRolesWrapper> FindAllByOrderByAndFilterAndRoleID(string orderByColumnName, bool isDesc,   SystemRoleWrapper roleID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndRoleID(orderByColumnName, isDesc,   roleID.Entity, pageQueryParams));
        }

        public static List<SystemPrivilegeInRolesWrapper> FindAllByRoleID(SystemRoleWrapper roleID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByRoleID(roleID.Entity));
        }
		
		
        public static List<SystemPrivilegeInRolesWrapper> FindAllByOrderByAndFilterAndPrivilegeID(string orderByColumnName, bool isDesc,   SystemPrivilegeWrapper privilegeID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndPrivilegeID(orderByColumnName, isDesc,   privilegeID.Entity, pageQueryParams));
        }

        public static List<SystemPrivilegeInRolesWrapper> FindAllByPrivilegeID(SystemPrivilegeWrapper privilegeID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByPrivilegeID(privilegeID.Entity));
        }
		



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemPrivilegeInRolesWrapper> ConvertToWrapperList(List<SystemPrivilegeInRolesEntity> entitylist)
        {
            List<SystemPrivilegeInRolesWrapper> list = new List<SystemPrivilegeInRolesWrapper>();
            foreach (SystemPrivilegeInRolesEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemPrivilegeInRolesWrapper> ConvertToWrapperList(IList<SystemPrivilegeInRolesEntity> entitylist)
        {
            List<SystemPrivilegeInRolesWrapper> list = new List<SystemPrivilegeInRolesWrapper>();
            foreach (SystemPrivilegeInRolesEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemPrivilegeInRolesEntity> ConvertToEntityList(List<SystemPrivilegeInRolesWrapper> wrapperlist)
        {
            List<SystemPrivilegeInRolesEntity> list = new List<SystemPrivilegeInRolesEntity>();
            foreach (SystemPrivilegeInRolesWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemPrivilegeInRolesWrapper ConvertEntityToWrapper(SystemPrivilegeInRolesEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.PrivilegeRoleID == 0)
                return null;

            return new SystemPrivilegeInRolesWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

