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
    public partial class SystemRoleMenuRelationWrapper    //: BaseSpringNHibernateWrapper<SystemRoleMenuRelationEntity, ISystemRoleMenuRelationServiceProxy, SystemRoleMenuRelationWrapper,int>
    {
        #region Member

		internal static readonly ISystemRoleMenuRelationServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemRoleMenuRelationServiceProxyInstance;
		
		
		internal SystemRoleMenuRelationEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemRoleMenuRelationWrapper() : base(new SystemRoleMenuRelationEntity())
        {
            
        }

        internal SystemRoleMenuRelationWrapper(SystemRoleMenuRelationEntity entityObj)
            : base(entityObj)
        {
        }
		#endregion

        #region Process Column Name
        private static string ProcessColumnName(string columnName)
        {
            switch (columnName)
            {
		        case "MenuID_MenuID":
					return PROPERTY_MENUID_MENUID;
		        case "MenuID_MenuName":
					return PROPERTY_MENUID_MENUNAME;
		        case "MenuID_MenuCode":
					return PROPERTY_MENUID_MENUCODE;
		        case "MenuID_MenuDescription":
					return PROPERTY_MENUID_MENUDESCRIPTION;
		        case "MenuID_MenuUrl":
					return PROPERTY_MENUID_MENUURL;
		        case "MenuID_MenuUrlTarget":
					return PROPERTY_MENUID_MENUURLTARGET;
		        case "MenuID_MenuIconUrl":
					return PROPERTY_MENUID_MENUICONURL;
		        case "MenuID_MenuIsCategory":
					return PROPERTY_MENUID_MENUISCATEGORY;
		        case "MenuID_ParentMenuID":
					return PROPERTY_MENUID_PARENTMENUID;
		        case "MenuID_MenuOrder":
					return PROPERTY_MENUID_MENUORDER;
		        case "MenuID_MenuType":
					return PROPERTY_MENUID_MENUTYPE;
		        case "MenuID_MenuIsSystemMenu":
					return PROPERTY_MENUID_MENUISSYSTEMMENU;
		        case "MenuID_MenuIsEnable":
					return PROPERTY_MENUID_MENUISENABLE;
		        case "MenuID_ApplicationID":
					return PROPERTY_MENUID_APPLICATIONID;
		        case "MenuID_CreateBy":
					return PROPERTY_MENUID_CREATEBY;
		        case "MenuID_CreateAt":
					return PROPERTY_MENUID_CREATEAT;
		        case "MenuID_LastModifyBy":
					return PROPERTY_MENUID_LASTMODIFYBY;
		        case "MenuID_LastModifyAt":
					return PROPERTY_MENUID_LASTMODIFYAT;
		        case "MenuID_LastModifyComment":
					return PROPERTY_MENUID_LASTMODIFYCOMMENT;
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemRoleMenuRelationEntity";
		public static readonly string PROPERTY_NAME_MENUROLEID = "MenuRoleID";
		public static readonly string PROPERTY_NAME_MENUID = "MenuID";
		public static readonly string PROPERTY_NAME_ROLEID = "RoleID";
		
        #endregion
	
 
		#region menuID字段外键查询字段
        public const string PROPERTY_MENUID_ALIAS_NAME = "MenuID_SystemRoleMenuRelationEntity_Alias";
		public const string PROPERTY_MENUID_MENUID = "MenuID_SystemRoleMenuRelationEntity_Alias.MenuID";
		public const string PROPERTY_MENUID_MENUNAME = "MenuID_SystemRoleMenuRelationEntity_Alias.MenuName";
		public const string PROPERTY_MENUID_MENUCODE = "MenuID_SystemRoleMenuRelationEntity_Alias.MenuCode";
		public const string PROPERTY_MENUID_MENUDESCRIPTION = "MenuID_SystemRoleMenuRelationEntity_Alias.MenuDescription";
		public const string PROPERTY_MENUID_MENUURL = "MenuID_SystemRoleMenuRelationEntity_Alias.MenuUrl";
		public const string PROPERTY_MENUID_MENUURLTARGET = "MenuID_SystemRoleMenuRelationEntity_Alias.MenuUrlTarget";
		public const string PROPERTY_MENUID_MENUICONURL = "MenuID_SystemRoleMenuRelationEntity_Alias.MenuIconUrl";
		public const string PROPERTY_MENUID_MENUISCATEGORY = "MenuID_SystemRoleMenuRelationEntity_Alias.MenuIsCategory";
		public const string PROPERTY_MENUID_PARENTMENUID = "MenuID_SystemRoleMenuRelationEntity_Alias.ParentMenuID";
		public const string PROPERTY_MENUID_MENUORDER = "MenuID_SystemRoleMenuRelationEntity_Alias.MenuOrder";
		public const string PROPERTY_MENUID_MENUTYPE = "MenuID_SystemRoleMenuRelationEntity_Alias.MenuType";
		public const string PROPERTY_MENUID_MENUISSYSTEMMENU = "MenuID_SystemRoleMenuRelationEntity_Alias.MenuIsSystemMenu";
		public const string PROPERTY_MENUID_MENUISENABLE = "MenuID_SystemRoleMenuRelationEntity_Alias.MenuIsEnable";
		public const string PROPERTY_MENUID_APPLICATIONID = "MenuID_SystemRoleMenuRelationEntity_Alias.ApplicationID";
		public const string PROPERTY_MENUID_CREATEBY = "MenuID_SystemRoleMenuRelationEntity_Alias.CreateBy";
		public const string PROPERTY_MENUID_CREATEAT = "MenuID_SystemRoleMenuRelationEntity_Alias.CreateAt";
		public const string PROPERTY_MENUID_LASTMODIFYBY = "MenuID_SystemRoleMenuRelationEntity_Alias.LastModifyBy";
		public const string PROPERTY_MENUID_LASTMODIFYAT = "MenuID_SystemRoleMenuRelationEntity_Alias.LastModifyAt";
		public const string PROPERTY_MENUID_LASTMODIFYCOMMENT = "MenuID_SystemRoleMenuRelationEntity_Alias.LastModifyComment";
		#endregion
		#region roleID字段外键查询字段
        public const string PROPERTY_ROLEID_ALIAS_NAME = "RoleID_SystemRoleMenuRelationEntity_Alias";
		public const string PROPERTY_ROLEID_ROLEID = "RoleID_SystemRoleMenuRelationEntity_Alias.RoleID";
		public const string PROPERTY_ROLEID_ROLENAME = "RoleID_SystemRoleMenuRelationEntity_Alias.RoleName";
		public const string PROPERTY_ROLEID_ROLECODE = "RoleID_SystemRoleMenuRelationEntity_Alias.RoleCode";
		public const string PROPERTY_ROLEID_ROLEDESCRIPTION = "RoleID_SystemRoleMenuRelationEntity_Alias.RoleDescription";
		public const string PROPERTY_ROLEID_ROLEISSYSTEMROLE = "RoleID_SystemRoleMenuRelationEntity_Alias.RoleIsSystemRole";
		public const string PROPERTY_ROLEID_ROLETYPE = "RoleID_SystemRoleMenuRelationEntity_Alias.RoleType";
		public const string PROPERTY_ROLEID_CREATEBY = "RoleID_SystemRoleMenuRelationEntity_Alias.CreateBy";
		public const string PROPERTY_ROLEID_CREATEAT = "RoleID_SystemRoleMenuRelationEntity_Alias.CreateAt";
		public const string PROPERTY_ROLEID_LASTMODIFYBY = "RoleID_SystemRoleMenuRelationEntity_Alias.LastModifyBy";
		public const string PROPERTY_ROLEID_LASTMODIFYAT = "RoleID_SystemRoleMenuRelationEntity_Alias.LastModifyAt";
		public const string PROPERTY_ROLEID_LASTMODIFYCOMMENT = "RoleID_SystemRoleMenuRelationEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		


		#region Public Property
		/// <summary>
		/// ??
		/// </summary>
		[DataMember]
		public int MenuRoleID
		{
			get
			{
				return entity.MenuRoleID;
			}
			set
			{
				entity.MenuRoleID = value;
			}
		}
		/// <summary>
		/// ??ID
		/// </summary>
		[DataMember]
		public SystemMenuWrapper MenuID
		{
			get
			{
				return SystemMenuWrapper.ConvertEntityToWrapper(entity.MenuID) ;
			}
			set
			{
				entity.MenuID = ((value == null) ? null : value.Entity);
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
		#endregion 


		#region Query Property
		
		
		#region menuID字段外键查询字段
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_MENUID_MENUID)]
        public int? MenuID_MenuID
        {
            get
            {
                if (this. MenuID == null)
                    return null;
                return  MenuID.MenuID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_MENUID_MENUNAME)]
        public string MenuID_MenuName
        {
            get
            {
                if (this. MenuID == null)
                    return null;
                return  MenuID.MenuName;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_MENUID_MENUCODE)]
        public string MenuID_MenuCode
        {
            get
            {
                if (this. MenuID == null)
                    return null;
                return  MenuID.MenuCode;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_MENUID_MENUDESCRIPTION)]
        public string MenuID_MenuDescription
        {
            get
            {
                if (this. MenuID == null)
                    return null;
                return  MenuID.MenuDescription;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_MENUID_MENUURL)]
        public string MenuID_MenuUrl
        {
            get
            {
                if (this. MenuID == null)
                    return null;
                return  MenuID.MenuUrl;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_MENUID_MENUURLTARGET)]
        public string MenuID_MenuUrlTarget
        {
            get
            {
                if (this. MenuID == null)
                    return null;
                return  MenuID.MenuUrlTarget;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_MENUID_MENUICONURL)]
        public string MenuID_MenuIconUrl
        {
            get
            {
                if (this. MenuID == null)
                    return null;
                return  MenuID.MenuIconUrl;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_MENUID_MENUISCATEGORY)]
        public bool? MenuID_MenuIsCategory
        {
            get
            {
                if (this. MenuID == null)
                    return null;
                return  MenuID.MenuIsCategory;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_MENUID_PARENTMENUID)]
        public SystemMenuWrapper MenuID_ParentMenuID
        {
            get
            {
                if (this. MenuID == null)
                    return null;
                return  MenuID.ParentMenuID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_MENUID_MENUORDER)]
        public int? MenuID_MenuOrder
        {
            get
            {
                if (this. MenuID == null)
                    return null;
                return  MenuID.MenuOrder;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_MENUID_MENUTYPE)]
        public string MenuID_MenuType
        {
            get
            {
                if (this. MenuID == null)
                    return null;
                return  MenuID.MenuType;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_MENUID_MENUISSYSTEMMENU)]
        public bool? MenuID_MenuIsSystemMenu
        {
            get
            {
                if (this. MenuID == null)
                    return null;
                return  MenuID.MenuIsSystemMenu;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_MENUID_MENUISENABLE)]
        public bool? MenuID_MenuIsEnable
        {
            get
            {
                if (this. MenuID == null)
                    return null;
                return  MenuID.MenuIsEnable;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_MENUID_APPLICATIONID)]
        public SystemApplicationWrapper MenuID_ApplicationID
        {
            get
            {
                if (this. MenuID == null)
                    return null;
                return  MenuID.ApplicationID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_MENUID_CREATEBY)]
        public int? MenuID_CreateBy
        {
            get
            {
                if (this. MenuID == null)
                    return null;
                return  MenuID.CreateBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_MENUID_CREATEAT)]
        public DateTime? MenuID_CreateAt
        {
            get
            {
                if (this. MenuID == null)
                    return null;
                return  MenuID.CreateAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_MENUID_LASTMODIFYBY)]
        public int? MenuID_LastModifyBy
        {
            get
            {
                if (this. MenuID == null)
                    return null;
                return  MenuID.LastModifyBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_MENUID_LASTMODIFYAT)]
        public DateTime? MenuID_LastModifyAt
        {
            get
            {
                if (this. MenuID == null)
                    return null;
                return  MenuID.LastModifyAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_MENUID_LASTMODIFYCOMMENT)]
        public string MenuID_LastModifyComment
        {
            get
            {
                if (this. MenuID == null)
                    return null;
                return  MenuID.LastModifyComment;
            }
        }
		#endregion
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
      	
   
		#endregion


        #region "FKQuery"
		
        public static List<SystemRoleMenuRelationWrapper> FindAllByOrderByAndFilterAndMenuID(string orderByColumnName, bool isDesc,   SystemMenuWrapper menuID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndMenuID(orderByColumnName, isDesc,   menuID.Entity, pageQueryParams));
        }

        public static List<SystemRoleMenuRelationWrapper> FindAllByMenuID(SystemMenuWrapper menuID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByMenuID(menuID.Entity));
        }
		
		
        public static List<SystemRoleMenuRelationWrapper> FindAllByOrderByAndFilterAndRoleID(string orderByColumnName, bool isDesc,   SystemRoleWrapper roleID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndRoleID(orderByColumnName, isDesc,   roleID.Entity, pageQueryParams));
        }

        public static List<SystemRoleMenuRelationWrapper> FindAllByRoleID(SystemRoleWrapper roleID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByRoleID(roleID.Entity));
        }
		



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemRoleMenuRelationWrapper> ConvertToWrapperList(List<SystemRoleMenuRelationEntity> entitylist)
        {
            List<SystemRoleMenuRelationWrapper> list = new List<SystemRoleMenuRelationWrapper>();
            foreach (SystemRoleMenuRelationEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemRoleMenuRelationWrapper> ConvertToWrapperList(IList<SystemRoleMenuRelationEntity> entitylist)
        {
            List<SystemRoleMenuRelationWrapper> list = new List<SystemRoleMenuRelationWrapper>();
            foreach (SystemRoleMenuRelationEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemRoleMenuRelationEntity> ConvertToEntityList(List<SystemRoleMenuRelationWrapper> wrapperlist)
        {
            List<SystemRoleMenuRelationEntity> list = new List<SystemRoleMenuRelationEntity>();
            foreach (SystemRoleMenuRelationWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemRoleMenuRelationWrapper ConvertEntityToWrapper(SystemRoleMenuRelationEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.MenuRoleID == 0)
                return null;

            return new SystemRoleMenuRelationWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

