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
    public partial class SystemRoleWrapper    //: BaseSpringNHibernateWrapper<SystemRoleEntity, ISystemRoleServiceProxy, SystemRoleWrapper,int>
    {
        #region Member

		internal static readonly ISystemRoleServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemRoleServiceProxyInstance;
		
		
		internal SystemRoleEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemRoleWrapper() : base(new SystemRoleEntity())
        {
            
        }

        internal SystemRoleWrapper(SystemRoleEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemRoleEntity";
		public static readonly string PROPERTY_NAME_ROLEID = "RoleID";
		public static readonly string PROPERTY_NAME_ROLENAME = "RoleName";
		public static readonly string PROPERTY_NAME_ROLECODE = "RoleCode";
		public static readonly string PROPERTY_NAME_ROLEDESCRIPTION = "RoleDescription";
		public static readonly string PROPERTY_NAME_ROLEISSYSTEMROLE = "RoleIsSystemRole";
		public static readonly string PROPERTY_NAME_ROLETYPE = "RoleType";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
      	
	
	
		 
		
		
		
		


		#region Public Property
		/// <summary>
		/// Primary Key
		/// </summary>
		[DataMember]
		public int RoleID
		{
			get
			{
				return entity.RoleID;
			}
			set
			{
				entity.RoleID = value;
			}
		}
		/// <summary>
		/// Role Name
		/// </summary>
		[DataMember]
		public string RoleName
		{
			get
			{
				return entity.RoleName;
			}
			set
			{
				entity.RoleName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string RoleCode
		{
			get
			{
				return entity.RoleCode;
			}
			set
			{
				entity.RoleCode = value;
			}
		}
		/// <summary>
		/// Role Description
		/// </summary>
		[DataMember]
		public string RoleDescription
		{
			get
			{
				return entity.RoleDescription;
			}
			set
			{
				entity.RoleDescription = value;
			}
		}
		/// <summary>
		/// Is System Role
		/// </summary>
		[DataMember]
		public bool? RoleIsSystemRole
		{
			get
			{
				return entity.RoleIsSystemRole;
			}
			set
			{
				entity.RoleIsSystemRole = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string RoleType
		{
			get
			{
				return entity.RoleType;
			}
			set
			{
				entity.RoleType = value;
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
		
		
      	
   
		#endregion


        #region "FKQuery"



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemRoleWrapper> ConvertToWrapperList(List<SystemRoleEntity> entitylist)
        {
            List<SystemRoleWrapper> list = new List<SystemRoleWrapper>();
            foreach (SystemRoleEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemRoleWrapper> ConvertToWrapperList(IList<SystemRoleEntity> entitylist)
        {
            List<SystemRoleWrapper> list = new List<SystemRoleWrapper>();
            foreach (SystemRoleEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemRoleEntity> ConvertToEntityList(List<SystemRoleWrapper> wrapperlist)
        {
            List<SystemRoleEntity> list = new List<SystemRoleEntity>();
            foreach (SystemRoleWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemRoleWrapper ConvertEntityToWrapper(SystemRoleEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.RoleID == 0)
                return null;

            return new SystemRoleWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

