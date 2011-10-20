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
    public partial class SystemAttachmentWrapper   
    {
        #region Member

		internal static readonly ISystemAttachmentServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemAttachmentServiceProxyInstance;
		
		
		internal SystemAttachmentEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemAttachmentWrapper() : base(new SystemAttachmentEntity())
        {
            
        }

        internal SystemAttachmentWrapper(SystemAttachmentEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemAttachmentEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_FILENAME = "FileName";
		public static readonly string PROPERTY_NAME_MD5 = "Md5";
		public static readonly string PROPERTY_NAME_SIZE = "Size";
		public static readonly string PROPERTY_NAME_FILEEXT = "FileExt";
		public static readonly string PROPERTY_NAME_PAGES = "Pages";
		public static readonly string PROPERTY_NAME_FILEPATH = "FilePath";
		public static readonly string PROPERTY_NAME_PARENTTYPE = "ParentType";
		public static readonly string PROPERTY_NAME_PARENTID = "ParentID";
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
		public string FileName
		{
			get
			{
				return entity.FileName;
			}
			set
			{
				entity.FileName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Md5
		{
			get
			{
				return entity.Md5;
			}
			set
			{
				entity.Md5 = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? Size
		{
			get
			{
				return entity.Size;
			}
			set
			{
				entity.Size = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string FileExt
		{
			get
			{
				return entity.FileExt;
			}
			set
			{
				entity.FileExt = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? Pages
		{
			get
			{
				return entity.Pages;
			}
			set
			{
				entity.Pages = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string FilePath
		{
			get
			{
				return entity.FilePath;
			}
			set
			{
				entity.FilePath = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ParentType
		{
			get
			{
				return entity.ParentType;
			}
			set
			{
				entity.ParentType = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? ParentID
		{
			get
			{
				return entity.ParentID;
			}
			set
			{
				entity.ParentID = value;
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
		
		internal static List<SystemAttachmentWrapper> ConvertToWrapperList(List<SystemAttachmentEntity> entitylist)
        {
            List<SystemAttachmentWrapper> list = new List<SystemAttachmentWrapper>();
            foreach (SystemAttachmentEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemAttachmentWrapper> ConvertToWrapperList(IList<SystemAttachmentEntity> entitylist)
        {
            List<SystemAttachmentWrapper> list = new List<SystemAttachmentWrapper>();
            foreach (SystemAttachmentEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemAttachmentEntity> ConvertToEntityList(List<SystemAttachmentWrapper> wrapperlist)
        {
            List<SystemAttachmentEntity> list = new List<SystemAttachmentEntity>();
            foreach (SystemAttachmentWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemAttachmentWrapper ConvertEntityToWrapper(SystemAttachmentEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SystemAttachmentWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace
