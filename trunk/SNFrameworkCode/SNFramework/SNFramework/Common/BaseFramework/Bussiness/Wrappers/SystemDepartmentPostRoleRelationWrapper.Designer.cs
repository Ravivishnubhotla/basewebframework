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
    public partial class SystemDepartmentPostRoleRelationWrapper   
    {
        #region Member

		internal static readonly ISystemDepartmentPostRoleRelationServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemDepartmentPostRoleRelationServiceProxyInstance;
		
		
		internal SystemDepartmentPostRoleRelationEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemDepartmentPostRoleRelationWrapper() : base(new SystemDepartmentPostRoleRelationEntity())
        {
            
        }

        internal SystemDepartmentPostRoleRelationWrapper(SystemDepartmentPostRoleRelationEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemDepartmentPostRoleRelationEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_DEPARTMENTID = "DepartmentID";
		public static readonly string PROPERTY_NAME_POSTID = "PostID";
		public static readonly string PROPERTY_NAME_ROLEID = "RoleID";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		
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
		public int? DepartmentID
		{
			get
			{
				return entity.DepartmentID;
			}
			set
			{
				entity.DepartmentID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? PostID
		{
			get
			{
				return entity.PostID;
			}
			set
			{
				entity.PostID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? RoleID
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
		#endregion 


		#region Query Property
		
		
      	
   
		#endregion


        #region "FKQuery"



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemDepartmentPostRoleRelationWrapper> ConvertToWrapperList(List<SystemDepartmentPostRoleRelationEntity> entitylist)
        {
            List<SystemDepartmentPostRoleRelationWrapper> list = new List<SystemDepartmentPostRoleRelationWrapper>();
            foreach (SystemDepartmentPostRoleRelationEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemDepartmentPostRoleRelationWrapper> ConvertToWrapperList(IList<SystemDepartmentPostRoleRelationEntity> entitylist)
        {
            List<SystemDepartmentPostRoleRelationWrapper> list = new List<SystemDepartmentPostRoleRelationWrapper>();
            foreach (SystemDepartmentPostRoleRelationEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemDepartmentPostRoleRelationEntity> ConvertToEntityList(List<SystemDepartmentPostRoleRelationWrapper> wrapperlist)
        {
            List<SystemDepartmentPostRoleRelationEntity> list = new List<SystemDepartmentPostRoleRelationEntity>();
            foreach (SystemDepartmentPostRoleRelationWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemDepartmentPostRoleRelationWrapper ConvertEntityToWrapper(SystemDepartmentPostRoleRelationEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SystemDepartmentPostRoleRelationWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

