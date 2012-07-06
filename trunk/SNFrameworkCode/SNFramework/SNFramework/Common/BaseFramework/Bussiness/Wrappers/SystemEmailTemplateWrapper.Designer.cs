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
    public partial class SystemEmailTemplateWrapper    : BaseSpringNHibernateWrapper<SystemEmailTemplateEntity, ISystemEmailTemplateServiceProxy, SystemEmailTemplateWrapper,int>
    {
        #region Member

		internal static readonly ISystemEmailTemplateServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemEmailTemplateServiceProxyInstance;
		
		
		internal SystemEmailTemplateEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemEmailTemplateWrapper() : base(new SystemEmailTemplateEntity())
        {
            
        }

        internal SystemEmailTemplateWrapper(SystemEmailTemplateEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemEmailTemplateEntity";
		public static readonly string PROPERTY_NAME_EMAILTEMPLATEID = "EmailTemplateID";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_CODE = "Code";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_TEMPLATETYPE = "TemplateType";
		public static readonly string PROPERTY_NAME_TITLETEMPLATE = "TitleTemplate";
		public static readonly string PROPERTY_NAME_BODYTEMPLATE = "BodyTemplate";
		public static readonly string PROPERTY_NAME_PARAMS = "Params";
		public static readonly string PROPERTY_NAME_ISHTMLEMAIL = "IsHtmlEmail";
		public static readonly string PROPERTY_NAME_ISENABLE = "IsEnable";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
      	
	
	
		 
		
		
		
		


		#region Public Property
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int EmailTemplateID
		{
			get
			{
				return entity.EmailTemplateID;
			}
			set
			{
				entity.EmailTemplateID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
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
		[DataMember]
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
		[DataMember]
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
		[DataMember]
		public string TemplateType
		{
			get
			{
				return entity.TemplateType;
			}
			set
			{
				entity.TemplateType = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string TitleTemplate
		{
			get
			{
				return entity.TitleTemplate;
			}
			set
			{
				entity.TitleTemplate = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string BodyTemplate
		{
			get
			{
				return entity.BodyTemplate;
			}
			set
			{
				entity.BodyTemplate = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Params
		{
			get
			{
				return entity.Params;
			}
			set
			{
				entity.Params = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool? IsHtmlEmail
		{
			get
			{
				return entity.IsHtmlEmail;
			}
			set
			{
				entity.IsHtmlEmail = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool? IsEnable
		{
			get
			{
				return entity.IsEnable;
			}
			set
			{
				entity.IsEnable = value;
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
		
		internal static List<SystemEmailTemplateWrapper> ConvertToWrapperList(List<SystemEmailTemplateEntity> entitylist)
        {
            List<SystemEmailTemplateWrapper> list = new List<SystemEmailTemplateWrapper>();
            foreach (SystemEmailTemplateEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemEmailTemplateWrapper> ConvertToWrapperList(IList<SystemEmailTemplateEntity> entitylist)
        {
            List<SystemEmailTemplateWrapper> list = new List<SystemEmailTemplateWrapper>();
            foreach (SystemEmailTemplateEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemEmailTemplateEntity> ConvertToEntityList(List<SystemEmailTemplateWrapper> wrapperlist)
        {
            List<SystemEmailTemplateEntity> list = new List<SystemEmailTemplateEntity>();
            foreach (SystemEmailTemplateWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemEmailTemplateWrapper ConvertEntityToWrapper(SystemEmailTemplateEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.EmailTemplateID == 0)
                return null;

            return new SystemEmailTemplateWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

