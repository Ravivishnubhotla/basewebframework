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
    public partial class SystemPostWrapper   
    {
        #region Member

		internal static readonly ISystemPostServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemPostServiceProxyInstance;
		
		
		internal SystemPostEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemPostWrapper() : base(new SystemPostEntity())
        {
            
        }

        internal SystemPostWrapper(SystemPostEntity entityObj)
            : base(entityObj)
        {
        }
		#endregion

        #region Process Column Name
        private static string ProcessColumnName(string columnName)
        {
            switch (columnName)
            {
		        case "OrganizationID_Id":
					return PROPERTY_ORGANIZATIONID_ID;
		        case "OrganizationID_Name":
					return PROPERTY_ORGANIZATIONID_NAME;
		        case "OrganizationID_ShortName":
					return PROPERTY_ORGANIZATIONID_SHORTNAME;
		        case "OrganizationID_Code":
					return PROPERTY_ORGANIZATIONID_CODE;
		        case "OrganizationID_Description":
					return PROPERTY_ORGANIZATIONID_DESCRIPTION;
		        case "OrganizationID_LogoUrl":
					return PROPERTY_ORGANIZATIONID_LOGOURL;
		        case "OrganizationID_Type":
					return PROPERTY_ORGANIZATIONID_TYPE;
		        case "OrganizationID_MasterName":
					return PROPERTY_ORGANIZATIONID_MASTERNAME;
		        case "OrganizationID_IsMainOrganization":
					return PROPERTY_ORGANIZATIONID_ISMAINORGANIZATION;
		        case "OrganizationID_ParentID":
					return PROPERTY_ORGANIZATIONID_PARENTID;
		        case "OrganizationID_AddressID":
					return PROPERTY_ORGANIZATIONID_ADDRESSID;
		        case "OrganizationID_TelPhone":
					return PROPERTY_ORGANIZATIONID_TELPHONE;
		        case "OrganizationID_FaxNumber":
					return PROPERTY_ORGANIZATIONID_FAXNUMBER;
		        case "OrganizationID_WebSite":
					return PROPERTY_ORGANIZATIONID_WEBSITE;
		        case "OrganizationID_Email":
					return PROPERTY_ORGANIZATIONID_EMAIL;
		        case "OrganizationID_CreateBy":
					return PROPERTY_ORGANIZATIONID_CREATEBY;
		        case "OrganizationID_CreateAt":
					return PROPERTY_ORGANIZATIONID_CREATEAT;
		        case "OrganizationID_LastModifyBy":
					return PROPERTY_ORGANIZATIONID_LASTMODIFYBY;
		        case "OrganizationID_LastModifyAt":
					return PROPERTY_ORGANIZATIONID_LASTMODIFYAT;
		        case "OrganizationID_LastModifyComment":
					return PROPERTY_ORGANIZATIONID_LASTMODIFYCOMMENT;
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemPostEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_CODE = "Code";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_ORGANIZATIONID = "OrganizationID";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region organizationID字段外键查询字段
        public const string PROPERTY_ORGANIZATIONID_ALIAS_NAME = "OrganizationID_SystemPostEntity_Alias";
		public const string PROPERTY_ORGANIZATIONID_ID = "OrganizationID_SystemPostEntity_Alias.Id";
		public const string PROPERTY_ORGANIZATIONID_NAME = "OrganizationID_SystemPostEntity_Alias.Name";
		public const string PROPERTY_ORGANIZATIONID_SHORTNAME = "OrganizationID_SystemPostEntity_Alias.ShortName";
		public const string PROPERTY_ORGANIZATIONID_CODE = "OrganizationID_SystemPostEntity_Alias.Code";
		public const string PROPERTY_ORGANIZATIONID_DESCRIPTION = "OrganizationID_SystemPostEntity_Alias.Description";
		public const string PROPERTY_ORGANIZATIONID_LOGOURL = "OrganizationID_SystemPostEntity_Alias.LogoUrl";
		public const string PROPERTY_ORGANIZATIONID_TYPE = "OrganizationID_SystemPostEntity_Alias.Type";
		public const string PROPERTY_ORGANIZATIONID_MASTERNAME = "OrganizationID_SystemPostEntity_Alias.MasterName";
		public const string PROPERTY_ORGANIZATIONID_ISMAINORGANIZATION = "OrganizationID_SystemPostEntity_Alias.IsMainOrganization";
		public const string PROPERTY_ORGANIZATIONID_PARENTID = "OrganizationID_SystemPostEntity_Alias.ParentID";
		public const string PROPERTY_ORGANIZATIONID_ADDRESSID = "OrganizationID_SystemPostEntity_Alias.AddressID";
		public const string PROPERTY_ORGANIZATIONID_TELPHONE = "OrganizationID_SystemPostEntity_Alias.TelPhone";
		public const string PROPERTY_ORGANIZATIONID_FAXNUMBER = "OrganizationID_SystemPostEntity_Alias.FaxNumber";
		public const string PROPERTY_ORGANIZATIONID_WEBSITE = "OrganizationID_SystemPostEntity_Alias.WebSite";
		public const string PROPERTY_ORGANIZATIONID_EMAIL = "OrganizationID_SystemPostEntity_Alias.Email";
		public const string PROPERTY_ORGANIZATIONID_CREATEBY = "OrganizationID_SystemPostEntity_Alias.CreateBy";
		public const string PROPERTY_ORGANIZATIONID_CREATEAT = "OrganizationID_SystemPostEntity_Alias.CreateAt";
		public const string PROPERTY_ORGANIZATIONID_LASTMODIFYBY = "OrganizationID_SystemPostEntity_Alias.LastModifyBy";
		public const string PROPERTY_ORGANIZATIONID_LASTMODIFYAT = "OrganizationID_SystemPostEntity_Alias.LastModifyAt";
		public const string PROPERTY_ORGANIZATIONID_LASTMODIFYCOMMENT = "OrganizationID_SystemPostEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		


		#region Public Property
		/// <summary>
		/// 
		/// </summary>		
		public int Id
		{
			get
			{
				return entity.Id;
			}
			set
			{
				entity.Id = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Name
		{
			get
			{
				return entity.Name;
			}
			set
			{
				entity.Name = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Code
		{
			get
			{
				return entity.Code;
			}
			set
			{
				entity.Code = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Description
		{
			get
			{
				return entity.Description;
			}
			set
			{
				entity.Description = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public SystemOrganizationWrapper OrganizationID
		{
			get
			{
				return SystemOrganizationWrapper.ConvertEntityToWrapper(entity.OrganizationID) ;
			}
			set
			{
				entity.OrganizationID = ((value == null) ? null : value.Entity);
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
		
		
		#region organizationID字段外键查询字段
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ORGANIZATIONID_ID)]
        public int? OrganizationID_Id
        {
            get
            {
                if (this. OrganizationID == null)
                    return null;
                return  OrganizationID.Id;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ORGANIZATIONID_NAME)]
        public string OrganizationID_Name
        {
            get
            {
                if (this. OrganizationID == null)
                    return null;
                return  OrganizationID.Name;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ORGANIZATIONID_SHORTNAME)]
        public string OrganizationID_ShortName
        {
            get
            {
                if (this. OrganizationID == null)
                    return null;
                return  OrganizationID.ShortName;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ORGANIZATIONID_CODE)]
        public string OrganizationID_Code
        {
            get
            {
                if (this. OrganizationID == null)
                    return null;
                return  OrganizationID.Code;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ORGANIZATIONID_DESCRIPTION)]
        public string OrganizationID_Description
        {
            get
            {
                if (this. OrganizationID == null)
                    return null;
                return  OrganizationID.Description;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ORGANIZATIONID_LOGOURL)]
        public string OrganizationID_LogoUrl
        {
            get
            {
                if (this. OrganizationID == null)
                    return null;
                return  OrganizationID.LogoUrl;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ORGANIZATIONID_TYPE)]
        public string OrganizationID_Type
        {
            get
            {
                if (this. OrganizationID == null)
                    return null;
                return  OrganizationID.Type;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ORGANIZATIONID_MASTERNAME)]
        public string OrganizationID_MasterName
        {
            get
            {
                if (this. OrganizationID == null)
                    return null;
                return  OrganizationID.MasterName;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ORGANIZATIONID_ISMAINORGANIZATION)]
        public bool? OrganizationID_IsMainOrganization
        {
            get
            {
                if (this. OrganizationID == null)
                    return null;
                return  OrganizationID.IsMainOrganization;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ORGANIZATIONID_PARENTID)]
        public SystemOrganizationWrapper OrganizationID_ParentID
        {
            get
            {
                if (this. OrganizationID == null)
                    return null;
                return  OrganizationID.ParentID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ORGANIZATIONID_ADDRESSID)]
        public int? OrganizationID_AddressID
        {
            get
            {
                if (this. OrganizationID == null)
                    return null;
                return  OrganizationID.AddressID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ORGANIZATIONID_TELPHONE)]
        public string OrganizationID_TelPhone
        {
            get
            {
                if (this. OrganizationID == null)
                    return null;
                return  OrganizationID.TelPhone;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ORGANIZATIONID_FAXNUMBER)]
        public string OrganizationID_FaxNumber
        {
            get
            {
                if (this. OrganizationID == null)
                    return null;
                return  OrganizationID.FaxNumber;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ORGANIZATIONID_WEBSITE)]
        public string OrganizationID_WebSite
        {
            get
            {
                if (this. OrganizationID == null)
                    return null;
                return  OrganizationID.WebSite;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ORGANIZATIONID_EMAIL)]
        public string OrganizationID_Email
        {
            get
            {
                if (this. OrganizationID == null)
                    return null;
                return  OrganizationID.Email;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ORGANIZATIONID_CREATEBY)]
        public int? OrganizationID_CreateBy
        {
            get
            {
                if (this. OrganizationID == null)
                    return null;
                return  OrganizationID.CreateBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ORGANIZATIONID_CREATEAT)]
        public DateTime? OrganizationID_CreateAt
        {
            get
            {
                if (this. OrganizationID == null)
                    return null;
                return  OrganizationID.CreateAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ORGANIZATIONID_LASTMODIFYBY)]
        public int? OrganizationID_LastModifyBy
        {
            get
            {
                if (this. OrganizationID == null)
                    return null;
                return  OrganizationID.LastModifyBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ORGANIZATIONID_LASTMODIFYAT)]
        public DateTime? OrganizationID_LastModifyAt
        {
            get
            {
                if (this. OrganizationID == null)
                    return null;
                return  OrganizationID.LastModifyAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ORGANIZATIONID_LASTMODIFYCOMMENT)]
        public string OrganizationID_LastModifyComment
        {
            get
            {
                if (this. OrganizationID == null)
                    return null;
                return  OrganizationID.LastModifyComment;
            }
        }
		#endregion
      	
   
		#endregion


        #region "FKQuery"
		
        public static List<SystemPostWrapper> FindAllByOrderByAndFilterAndOrganizationID(string orderByColumnName, bool isDesc,   SystemOrganizationWrapper organizationID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndOrganizationID(orderByColumnName, isDesc,   organizationID.Entity, pageQueryParams));
        }

        public static List<SystemPostWrapper> FindAllByOrganizationID(SystemOrganizationWrapper organizationID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrganizationID(organizationID.Entity));
        }
		



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemPostWrapper> ConvertToWrapperList(List<SystemPostEntity> entitylist)
        {
            List<SystemPostWrapper> list = new List<SystemPostWrapper>();
            foreach (SystemPostEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemPostWrapper> ConvertToWrapperList(IList<SystemPostEntity> entitylist)
        {
            List<SystemPostWrapper> list = new List<SystemPostWrapper>();
            foreach (SystemPostEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemPostEntity> ConvertToEntityList(List<SystemPostWrapper> wrapperlist)
        {
            List<SystemPostEntity> list = new List<SystemPostEntity>();
            foreach (SystemPostWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemPostWrapper ConvertEntityToWrapper(SystemPostEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SystemPostWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

