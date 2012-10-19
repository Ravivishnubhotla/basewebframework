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
    public partial class SystemMenuWrapper    //: BaseSpringNHibernateWrapper<SystemMenuEntity, ISystemMenuServiceProxy, SystemMenuWrapper,int>
    {
        #region Member

		internal static readonly ISystemMenuServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemMenuServiceProxyInstance;
		
		
		internal SystemMenuEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemMenuWrapper() : base(new SystemMenuEntity())
        {
            
        }

        internal SystemMenuWrapper(SystemMenuEntity entityObj)
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
		        case "ApplicationID_Status":
					return PROPERTY_APPLICATIONID_STATUS;
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemMenuEntity";
		public static readonly string PROPERTY_NAME_MENUID = "MenuID";
		public static readonly string PROPERTY_NAME_MENUNAME = "MenuName";
		public static readonly string PROPERTY_NAME_MENUCODE = "MenuCode";
		public static readonly string PROPERTY_NAME_MENUDESCRIPTION = "MenuDescription";
		public static readonly string PROPERTY_NAME_MENUURL = "MenuUrl";
		public static readonly string PROPERTY_NAME_MENUURLTARGET = "MenuUrlTarget";
		public static readonly string PROPERTY_NAME_MENUICONURL = "MenuIconUrl";
		public static readonly string PROPERTY_NAME_MENUISCATEGORY = "MenuIsCategory";
		public static readonly string PROPERTY_NAME_PARENTMENUID = "ParentMenuID";
		public static readonly string PROPERTY_NAME_MENUORDER = "MenuOrder";
		public static readonly string PROPERTY_NAME_MENUTYPE = "MenuType";
		public static readonly string PROPERTY_NAME_MENUISSYSTEMMENU = "MenuIsSystemMenu";
		public static readonly string PROPERTY_NAME_MENUISENABLE = "MenuIsEnable";
		public static readonly string PROPERTY_NAME_APPLICATIONID = "ApplicationID";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region applicationID字段外键查询字段
        public const string PROPERTY_APPLICATIONID_ALIAS_NAME = "ApplicationID_SystemMenuEntity_Alias";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONID = "ApplicationID_SystemMenuEntity_Alias.SystemApplicationID";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONNAME = "ApplicationID_SystemMenuEntity_Alias.SystemApplicationName";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONCODE = "ApplicationID_SystemMenuEntity_Alias.SystemApplicationCode";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONDESCRIPTION = "ApplicationID_SystemMenuEntity_Alias.SystemApplicationDescription";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONURL = "ApplicationID_SystemMenuEntity_Alias.SystemApplicationUrl";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONISSYSTEMAPPLICATION = "ApplicationID_SystemMenuEntity_Alias.SystemApplicationIsSystemApplication";
		public const string PROPERTY_APPLICATIONID_STATUS = "ApplicationID_SystemMenuEntity_Alias.Status";
		public const string PROPERTY_APPLICATIONID_ORDERINDEX = "ApplicationID_SystemMenuEntity_Alias.OrderIndex";
		public const string PROPERTY_APPLICATIONID_CREATEBY = "ApplicationID_SystemMenuEntity_Alias.CreateBy";
		public const string PROPERTY_APPLICATIONID_CREATEAT = "ApplicationID_SystemMenuEntity_Alias.CreateAt";
		public const string PROPERTY_APPLICATIONID_LASTMODIFYBY = "ApplicationID_SystemMenuEntity_Alias.LastModifyBy";
		public const string PROPERTY_APPLICATIONID_LASTMODIFYAT = "ApplicationID_SystemMenuEntity_Alias.LastModifyAt";
		public const string PROPERTY_APPLICATIONID_LASTMODIFYCOMMENT = "ApplicationID_SystemMenuEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		


		#region Public Property
		/// <summary>
		/// Primary Key
		/// </summary>
		[DataMember]
		public int MenuID
		{
			get
			{
				return entity.MenuID;
			}
			set
			{
				entity.MenuID = value;
			}
		}
		/// <summary>
		/// Menu Name
		/// </summary>
		[DataMember]
		public string MenuName
		{
			get
			{
				return entity.MenuName;
			}
			set
			{
				entity.MenuName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string MenuCode
		{
			get
			{
				return entity.MenuCode;
			}
			set
			{
				entity.MenuCode = value;
			}
		}
		/// <summary>
		/// Menu Description
		/// </summary>
		[DataMember]
		public string MenuDescription
		{
			get
			{
				return entity.MenuDescription;
			}
			set
			{
				entity.MenuDescription = value;
			}
		}
		/// <summary>
		/// Menu Url
		/// </summary>
		[DataMember]
		public string MenuUrl
		{
			get
			{
				return entity.MenuUrl;
			}
			set
			{
				entity.MenuUrl = value;
			}
		}
		/// <summary>
		/// Menu Url Target Name
		/// </summary>
		[DataMember]
		public string MenuUrlTarget
		{
			get
			{
				return entity.MenuUrlTarget;
			}
			set
			{
				entity.MenuUrlTarget = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string MenuIconUrl
		{
			get
			{
				return entity.MenuIconUrl;
			}
			set
			{
				entity.MenuIconUrl = value;
			}
		}
		/// <summary>
		/// Menu Is Category
		/// </summary>
		[DataMember]
		public bool MenuIsCategory
		{
			get
			{
				return entity.MenuIsCategory;
			}
			set
			{
				entity.MenuIsCategory = value;
			}
		}
		/// <summary>
		/// Parent Menu
		/// </summary>
		[DataMember]
		public SystemMenuWrapper ParentMenuID
		{
			get
			{
				return SystemMenuWrapper.ConvertEntityToWrapper(entity.ParentMenuID) ;
			}
			set
			{
				entity.ParentMenuID = ((value == null) ? null : value.Entity);
			}
		}
		/// <summary>
		/// Menu Order
		/// </summary>
		[DataMember]
		public int? MenuOrder
		{
			get
			{
				return entity.MenuOrder;
			}
			set
			{
				entity.MenuOrder = value;
			}
		}
		/// <summary>
		/// Menu Type
		/// </summary>
		[DataMember]
		public string MenuType
		{
			get
			{
				return entity.MenuType;
			}
			set
			{
				entity.MenuType = value;
			}
		}
		/// <summary>
		/// Is System Menu
		/// </summary>
		[DataMember]
		public bool? MenuIsSystemMenu
		{
			get
			{
				return entity.MenuIsSystemMenu;
			}
			set
			{
				entity.MenuIsSystemMenu = value;
			}
		}
		/// <summary>
		/// Is Enable
		/// </summary>
		[DataMember]
		public bool? MenuIsEnable
		{
			get
			{
				return entity.MenuIsEnable;
			}
			set
			{
				entity.MenuIsEnable = value;
			}
		}
		/// <summary>
		/// Application
		/// </summary>
		[DataMember]
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
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_APPLICATIONID_STATUS)]
        public string ApplicationID_Status
        {
            get
            {
                if (this. ApplicationID == null)
                    return null;
                return  ApplicationID.Status;
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
		
        public static List<SystemMenuWrapper> FindAllByOrderByAndFilterAndApplicationID(string orderByColumnName, bool isDesc,   SystemApplicationWrapper applicationID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndApplicationID(orderByColumnName, isDesc,   applicationID.Entity, pageQueryParams));
        }

        public static List<SystemMenuWrapper> FindAllByApplicationID(SystemApplicationWrapper applicationID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByApplicationID(applicationID.Entity));
        }
		



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemMenuWrapper> ConvertToWrapperList(List<SystemMenuEntity> entitylist)
        {
            List<SystemMenuWrapper> list = new List<SystemMenuWrapper>();
            foreach (SystemMenuEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemMenuWrapper> ConvertToWrapperList(IList<SystemMenuEntity> entitylist)
        {
            List<SystemMenuWrapper> list = new List<SystemMenuWrapper>();
            foreach (SystemMenuEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemMenuEntity> ConvertToEntityList(List<SystemMenuWrapper> wrapperlist)
        {
            List<SystemMenuEntity> list = new List<SystemMenuEntity>();
            foreach (SystemMenuWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemMenuWrapper ConvertEntityToWrapper(SystemMenuEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.MenuID == 0)
                return null;

            return new SystemMenuWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

