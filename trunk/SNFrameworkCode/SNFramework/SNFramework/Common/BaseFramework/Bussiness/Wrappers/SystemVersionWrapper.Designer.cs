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
    public partial class SystemVersionWrapper   : BaseSpringNHibernateWrapper<SystemVersionEntity, ISystemVersionServiceProxy, SystemVersionWrapper,int>
    {
        #region Member

		internal static readonly ISystemVersionServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemVersionServiceProxyInstance;
		
		
		internal SystemVersionEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemVersionWrapper() : base(new SystemVersionEntity())
        {
            
        }

        internal SystemVersionWrapper(SystemVersionEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemVersionEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_OLDVERSION = "OldVersion";
		public static readonly string PROPERTY_NAME_NEWVERSION = "NewVersion";
		public static readonly string PROPERTY_NAME_OLDCHANGEFILELD = "OldChangeFileld";
		public static readonly string PROPERTY_NAME_NEWCHANGEFILELD = "NewChangeFileld";
		public static readonly string PROPERTY_NAME_PARENTDATATYPE = "ParentDataType";
		public static readonly string PROPERTY_NAME_PARENTDATAID = "ParentDataID";
		public static readonly string PROPERTY_NAME_CHANGEDATE = "ChangeDate";
		public static readonly string PROPERTY_NAME_CHANGEUSERID = "ChangeUserID";
		public static readonly string PROPERTY_NAME_CHANGEUSERNAME = "ChangeUserName";
		public static readonly string PROPERTY_NAME_COMMENT = "Comment";
		
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
		public string OldVersion
		{
			get
			{
				return entity.OldVersion;
			}
			set
			{
				entity.OldVersion = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string NewVersion
		{
			get
			{
				return entity.NewVersion;
			}
			set
			{
				entity.NewVersion = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string OldChangeFileld
		{
			get
			{
				return entity.OldChangeFileld;
			}
			set
			{
				entity.OldChangeFileld = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string NewChangeFileld
		{
			get
			{
				return entity.NewChangeFileld;
			}
			set
			{
				entity.NewChangeFileld = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ParentDataType
		{
			get
			{
				return entity.ParentDataType;
			}
			set
			{
				entity.ParentDataType = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? ParentDataID
		{
			get
			{
				return entity.ParentDataID;
			}
			set
			{
				entity.ParentDataID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public DateTime? ChangeDate
		{
			get
			{
				return entity.ChangeDate;
			}
			set
			{
				entity.ChangeDate = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? ChangeUserID
		{
			get
			{
				return entity.ChangeUserID;
			}
			set
			{
				entity.ChangeUserID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? ChangeUserName
		{
			get
			{
				return entity.ChangeUserName;
			}
			set
			{
				entity.ChangeUserName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Comment
		{
			get
			{
				return entity.Comment;
			}
			set
			{
				entity.Comment = value;
			}
		}
		#endregion 


		#region Query Property
		
		
      	
   
		#endregion


        #region "FKQuery"



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemVersionWrapper> ConvertToWrapperList(List<SystemVersionEntity> entitylist)
        {
            List<SystemVersionWrapper> list = new List<SystemVersionWrapper>();
            foreach (SystemVersionEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemVersionWrapper> ConvertToWrapperList(IList<SystemVersionEntity> entitylist)
        {
            List<SystemVersionWrapper> list = new List<SystemVersionWrapper>();
            foreach (SystemVersionEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemVersionEntity> ConvertToEntityList(List<SystemVersionWrapper> wrapperlist)
        {
            List<SystemVersionEntity> list = new List<SystemVersionEntity>();
            foreach (SystemVersionWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemVersionWrapper ConvertEntityToWrapper(SystemVersionEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SystemVersionWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

