// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Spring.Context.Support;
using Common.Logging;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
    public partial class SystemAttachmentContentWrapper
    {
        #region Member

		internal static readonly ISystemAttachmentContentServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemAttachmentContentServiceProxyInstance;
	 
	 
        internal SystemAttachmentContentEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SystemAttachmentContentWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SystemAttachmentContentWrapper() : this(new SystemAttachmentContentEntity())
        {
            
        }

        internal SystemAttachmentContentWrapper(SystemAttachmentContentEntity entityObj)
        {
            entity = entityObj;
        }
		#endregion
		
		#region Equals 和 HashCode 方法覆盖
		public override bool Equals(object obj)
        {
            if (obj == null && entity!=null)
            {
                if (entity.Id == 0)
                    return true;

                return false;
            }
            return entity.Equals(obj);
        }

        public override int GetHashCode()
        {
            return entity.GetHashCode();
        }
		#endregion
		
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemAttachmentContentEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_ATTACMENTID = "AttacmentID";
		public static readonly string PROPERTY_NAME_FILECONTENT = "FileContent";
		
        #endregion
	
 
		#region attacmentID字段外键查询字段
        public const string PROPERTY_ATTACMENTID_ALIAS_NAME = "AttacmentID_SystemAttachmentContentEntity_Alias";
		public const string PROPERTY_ATTACMENTID_ID = "AttacmentID_SystemAttachmentContentEntity_Alias.Id";
		public const string PROPERTY_ATTACMENTID_NAME = "AttacmentID_SystemAttachmentContentEntity_Alias.Name";
		public const string PROPERTY_ATTACMENTID_DESCRIPTION = "AttacmentID_SystemAttachmentContentEntity_Alias.Description";
		public const string PROPERTY_ATTACMENTID_FILENAME = "AttacmentID_SystemAttachmentContentEntity_Alias.FileName";
		public const string PROPERTY_ATTACMENTID_MD5 = "AttacmentID_SystemAttachmentContentEntity_Alias.Md5";
		public const string PROPERTY_ATTACMENTID_SIZE = "AttacmentID_SystemAttachmentContentEntity_Alias.Size";
		public const string PROPERTY_ATTACMENTID_FILEEXT = "AttacmentID_SystemAttachmentContentEntity_Alias.FileExt";
		public const string PROPERTY_ATTACMENTID_PAGES = "AttacmentID_SystemAttachmentContentEntity_Alias.Pages";
		public const string PROPERTY_ATTACMENTID_FILEPATH = "AttacmentID_SystemAttachmentContentEntity_Alias.FilePath";
		public const string PROPERTY_ATTACMENTID_PARENTTYPE = "AttacmentID_SystemAttachmentContentEntity_Alias.ParentType";
		public const string PROPERTY_ATTACMENTID_PARENTID = "AttacmentID_SystemAttachmentContentEntity_Alias.ParentID";
		public const string PROPERTY_ATTACMENTID_CREATEBY = "AttacmentID_SystemAttachmentContentEntity_Alias.CreateBy";
		public const string PROPERTY_ATTACMENTID_CREATEAT = "AttacmentID_SystemAttachmentContentEntity_Alias.CreateAt";
		public const string PROPERTY_ATTACMENTID_LASTMODIFYBY = "AttacmentID_SystemAttachmentContentEntity_Alias.LastModifyBy";
		public const string PROPERTY_ATTACMENTID_LASTMODIFYAT = "AttacmentID_SystemAttachmentContentEntity_Alias.LastModifyAt";
		public const string PROPERTY_ATTACMENTID_LASTMODIFYCOMMENT = "AttacmentID_SystemAttachmentContentEntity_Alias.LastModifyComment";
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
		public SystemAttachmentWrapper AttacmentID
		{
			get
			{
				return SystemAttachmentWrapper.ConvertEntityToWrapper(entity.AttacmentID) ;
			}
			set
			{
				entity.AttacmentID = ((value == null) ? null : value.entity);
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public byte[] FileContent
		{
			get
			{
				return entity.FileContent;
			}
			set
			{
				entity.FileContent = value;
			}
		}
		#endregion 


		#region Query Property
		
		
		#region attacmentID字段外键查询字段
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ATTACMENTID_ID)]
        public int? AttacmentID_Id
        {
            get
            {
                if (this. AttacmentID == null)
                    return null;
                return  AttacmentID.Id;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ATTACMENTID_NAME)]
        public string AttacmentID_Name
        {
            get
            {
                if (this. AttacmentID == null)
                    return null;
                return  AttacmentID.Name;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ATTACMENTID_DESCRIPTION)]
        public string AttacmentID_Description
        {
            get
            {
                if (this. AttacmentID == null)
                    return null;
                return  AttacmentID.Description;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ATTACMENTID_FILENAME)]
        public string AttacmentID_FileName
        {
            get
            {
                if (this. AttacmentID == null)
                    return null;
                return  AttacmentID.FileName;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ATTACMENTID_MD5)]
        public string AttacmentID_Md5
        {
            get
            {
                if (this. AttacmentID == null)
                    return null;
                return  AttacmentID.Md5;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ATTACMENTID_SIZE)]
        public int? AttacmentID_Size
        {
            get
            {
                if (this. AttacmentID == null)
                    return null;
                return  AttacmentID.Size;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ATTACMENTID_FILEEXT)]
        public string AttacmentID_FileExt
        {
            get
            {
                if (this. AttacmentID == null)
                    return null;
                return  AttacmentID.FileExt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ATTACMENTID_PAGES)]
        public int? AttacmentID_Pages
        {
            get
            {
                if (this. AttacmentID == null)
                    return null;
                return  AttacmentID.Pages;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ATTACMENTID_FILEPATH)]
        public string AttacmentID_FilePath
        {
            get
            {
                if (this. AttacmentID == null)
                    return null;
                return  AttacmentID.FilePath;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ATTACMENTID_PARENTTYPE)]
        public string AttacmentID_ParentType
        {
            get
            {
                if (this. AttacmentID == null)
                    return null;
                return  AttacmentID.ParentType;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ATTACMENTID_PARENTID)]
        public int? AttacmentID_ParentID
        {
            get
            {
                if (this. AttacmentID == null)
                    return null;
                return  AttacmentID.ParentID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ATTACMENTID_CREATEBY)]
        public int? AttacmentID_CreateBy
        {
            get
            {
                if (this. AttacmentID == null)
                    return null;
                return  AttacmentID.CreateBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ATTACMENTID_CREATEAT)]
        public DateTime? AttacmentID_CreateAt
        {
            get
            {
                if (this. AttacmentID == null)
                    return null;
                return  AttacmentID.CreateAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ATTACMENTID_LASTMODIFYBY)]
        public int? AttacmentID_LastModifyBy
        {
            get
            {
                if (this. AttacmentID == null)
                    return null;
                return  AttacmentID.LastModifyBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ATTACMENTID_LASTMODIFYAT)]
        public DateTime? AttacmentID_LastModifyAt
        {
            get
            {
                if (this. AttacmentID == null)
                    return null;
                return  AttacmentID.LastModifyAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_ATTACMENTID_LASTMODIFYCOMMENT)]
        public string AttacmentID_LastModifyComment
        {
            get
            {
                if (this. AttacmentID == null)
                    return null;
                return  AttacmentID.LastModifyComment;
            }
        }
		#endregion
      	
   
		#endregion


        #region "FKQuery"
		
        public static List<SystemAttachmentContentWrapper> FindAllByOrderByAndFilterAndAttacmentID(string orderByColumnName, bool isDesc,   SystemAttachmentWrapper attacmentID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndAttacmentID(orderByColumnName, isDesc,   attacmentID.entity, pageQueryParams));
        }

        public static List<SystemAttachmentContentWrapper> FindAllByAttacmentID(SystemAttachmentWrapper attacmentID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByAttacmentID(attacmentID.entity));
        }
		



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemAttachmentContentWrapper> ConvertToWrapperList(List<SystemAttachmentContentEntity> entitylist)
        {
            List<SystemAttachmentContentWrapper> list = new List<SystemAttachmentContentWrapper>();
            foreach (SystemAttachmentContentEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemAttachmentContentWrapper> ConvertToWrapperList(IList<SystemAttachmentContentEntity> entitylist)
        {
            List<SystemAttachmentContentWrapper> list = new List<SystemAttachmentContentWrapper>();
            foreach (SystemAttachmentContentEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemAttachmentContentEntity> ConvertToEntityList(List<SystemAttachmentContentWrapper> wrapperlist)
        {
            List<SystemAttachmentContentEntity> list = new List<SystemAttachmentContentEntity>();
            foreach (SystemAttachmentContentWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemAttachmentContentWrapper ConvertEntityToWrapper(SystemAttachmentContentEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SystemAttachmentContentWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace
