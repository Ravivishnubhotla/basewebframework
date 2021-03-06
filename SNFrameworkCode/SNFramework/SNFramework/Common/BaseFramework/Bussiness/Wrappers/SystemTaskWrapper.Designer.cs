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
    public partial class SystemTaskWrapper    //: BaseSpringNHibernateWrapper<SystemTaskEntity, ISystemTaskServiceProxy, SystemTaskWrapper,int>
    {
        #region Member

		internal static readonly ISystemTaskServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemTaskServiceProxyInstance;
		
		
		internal SystemTaskEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemTaskWrapper() : base(new SystemTaskEntity())
        {
            
        }

        internal SystemTaskWrapper(SystemTaskEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemTaskEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_TITLE = "Title";
		public static readonly string PROPERTY_NAME_TASKCONTENT = "TaskContent";
		public static readonly string PROPERTY_NAME_ASSIGNEDUSERID = "AssignedUserID";
		public static readonly string PROPERTY_NAME_STATUS = "Status";
		public static readonly string PROPERTY_NAME_DATEDUE = "DateDue";
		public static readonly string PROPERTY_NAME_DATESTART = "DateStart";
		public static readonly string PROPERTY_NAME_FINISHEDDATE = "FinishedDate";
		public static readonly string PROPERTY_NAME_ISALERTINHOME = "IsAlertInHome";
		public static readonly string PROPERTY_NAME_ISREAD = "IsRead";
		public static readonly string PROPERTY_NAME_PRIORITY = "Priority";
		public static readonly string PROPERTY_NAME_PARENTDATAID = "ParentDataID";
		public static readonly string PROPERTY_NAME_PARENTDATATYPE = "ParentDataType";
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
		[DataMember]
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
		[DataMember]
		public string Title
		{
			get
			{
				return entity.Title;
			}
			set
			{
				entity.Title = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string TaskContent
		{
			get
			{
				return entity.TaskContent;
			}
			set
			{
				entity.TaskContent = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? AssignedUserID
		{
			get
			{
				return entity.AssignedUserID;
			}
			set
			{
				entity.AssignedUserID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Status
		{
			get
			{
				return entity.Status;
			}
			set
			{
				entity.Status = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public DateTime? DateDue
		{
			get
			{
				return entity.DateDue;
			}
			set
			{
				entity.DateDue = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public DateTime? DateStart
		{
			get
			{
				return entity.DateStart;
			}
			set
			{
				entity.DateStart = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public DateTime? FinishedDate
		{
			get
			{
				return entity.FinishedDate;
			}
			set
			{
				entity.FinishedDate = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool? IsAlertInHome
		{
			get
			{
				return entity.IsAlertInHome;
			}
			set
			{
				entity.IsAlertInHome = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool? IsRead
		{
			get
			{
				return entity.IsRead;
			}
			set
			{
				entity.IsRead = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Priority
		{
			get
			{
				return entity.Priority;
			}
			set
			{
				entity.Priority = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
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
		[DataMember]
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
		
		internal static List<SystemTaskWrapper> ConvertToWrapperList(List<SystemTaskEntity> entitylist)
        {
            List<SystemTaskWrapper> list = new List<SystemTaskWrapper>();
            foreach (SystemTaskEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemTaskWrapper> ConvertToWrapperList(IList<SystemTaskEntity> entitylist)
        {
            List<SystemTaskWrapper> list = new List<SystemTaskWrapper>();
            foreach (SystemTaskEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemTaskEntity> ConvertToEntityList(List<SystemTaskWrapper> wrapperlist)
        {
            List<SystemTaskEntity> list = new List<SystemTaskEntity>();
            foreach (SystemTaskWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemTaskWrapper ConvertEntityToWrapper(SystemTaskEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SystemTaskWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

