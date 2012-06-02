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
    public partial class SystemOrganizationWrapper   : BaseSpringNHibernateWrapper<SystemOrganizationEntity, ISystemOrganizationServiceProxy, SystemOrganizationWrapper,int>
    {
        #region Member

		internal static readonly ISystemOrganizationServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemOrganizationServiceProxyInstance;
		
		
		internal SystemOrganizationEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemOrganizationWrapper() : base(new SystemOrganizationEntity())
        {
            
        }

        internal SystemOrganizationWrapper(SystemOrganizationEntity entityObj)
            : base(entityObj)
        {
        }
		#endregion

        #region Process Column Name
        private static string ProcessColumnName(string columnName)
        {
            switch (columnName)
            {
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemOrganizationEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_SHORTNAME = "ShortName";
		public static readonly string PROPERTY_NAME_CODE = "Code";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_LOGOURL = "LogoUrl";
		public static readonly string PROPERTY_NAME_TYPE = "Type";
		public static readonly string PROPERTY_NAME_MASTERNAME = "MasterName";
		public static readonly string PROPERTY_NAME_ISMAINORGANIZATION = "IsMainOrganization";
		public static readonly string PROPERTY_NAME_PARENTID = "ParentID";
		public static readonly string PROPERTY_NAME_ADDRESSID = "AddressID";
		public static readonly string PROPERTY_NAME_TELPHONE = "TelPhone";
		public static readonly string PROPERTY_NAME_FAXNUMBER = "FaxNumber";
		public static readonly string PROPERTY_NAME_WEBSITE = "WebSite";
		public static readonly string PROPERTY_NAME_EMAIL = "Email";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
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
		public string ShortName
		{
			get
			{
				return entity.ShortName;
			}
			set
			{
				entity.ShortName = value;
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
		public string LogoUrl
		{
			get
			{
				return entity.LogoUrl;
			}
			set
			{
				entity.LogoUrl = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Type
		{
			get
			{
				return entity.Type;
			}
			set
			{
				entity.Type = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string MasterName
		{
			get
			{
				return entity.MasterName;
			}
			set
			{
				entity.MasterName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool? IsMainOrganization
		{
			get
			{
				return entity.IsMainOrganization;
			}
			set
			{
				entity.IsMainOrganization = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public SystemOrganizationWrapper ParentID
		{
			get
			{
				return SystemOrganizationWrapper.ConvertEntityToWrapper(entity.ParentID) ;
			}
			set
			{
				entity.ParentID = ((value == null) ? null : value.Entity);
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? AddressID
		{
			get
			{
				return entity.AddressID;
			}
			set
			{
				entity.AddressID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string TelPhone
		{
			get
			{
				return entity.TelPhone;
			}
			set
			{
				entity.TelPhone = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string FaxNumber
		{
			get
			{
				return entity.FaxNumber;
			}
			set
			{
				entity.FaxNumber = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string WebSite
		{
			get
			{
				return entity.WebSite;
			}
			set
			{
				entity.WebSite = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Email
		{
			get
			{
				return entity.Email;
			}
			set
			{
				entity.Email = value;
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
		
		
      	
   
		#endregion


        #region "FKQuery"



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemOrganizationWrapper> ConvertToWrapperList(List<SystemOrganizationEntity> entitylist)
        {
            List<SystemOrganizationWrapper> list = new List<SystemOrganizationWrapper>();
            foreach (SystemOrganizationEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemOrganizationWrapper> ConvertToWrapperList(IList<SystemOrganizationEntity> entitylist)
        {
            List<SystemOrganizationWrapper> list = new List<SystemOrganizationWrapper>();
            foreach (SystemOrganizationEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemOrganizationEntity> ConvertToEntityList(List<SystemOrganizationWrapper> wrapperlist)
        {
            List<SystemOrganizationEntity> list = new List<SystemOrganizationEntity>();
            foreach (SystemOrganizationWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemOrganizationWrapper ConvertEntityToWrapper(SystemOrganizationEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SystemOrganizationWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

