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
    public partial class SystemRichTextWrapper    //: BaseSpringNHibernateWrapper<SystemRichTextEntity, ISystemRichTextServiceProxy, SystemRichTextWrapper,int>
    {
        #region Member

		internal static readonly ISystemRichTextServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemRichTextServiceProxyInstance;
		
		
		internal SystemRichTextEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemRichTextWrapper() : base(new SystemRichTextEntity())
        {
            
        }

        internal SystemRichTextWrapper(SystemRichTextEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemRichTextEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_TYPE = "Type";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_TEXTCONTENT = "TextContent";
		public static readonly string PROPERTY_NAME_PARENTTYPE = "ParentType";
		public static readonly string PROPERTY_NAME_PARENTID = "ParentID";
		
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
		public string TextContent
		{
			get
			{
				return entity.TextContent;
			}
			set
			{
				entity.TextContent = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
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
		[DataMember]
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
		#endregion 


		#region Query Property
		
		
      	
   
		#endregion


        #region "FKQuery"



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemRichTextWrapper> ConvertToWrapperList(List<SystemRichTextEntity> entitylist)
        {
            List<SystemRichTextWrapper> list = new List<SystemRichTextWrapper>();
            foreach (SystemRichTextEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemRichTextWrapper> ConvertToWrapperList(IList<SystemRichTextEntity> entitylist)
        {
            List<SystemRichTextWrapper> list = new List<SystemRichTextWrapper>();
            foreach (SystemRichTextEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemRichTextEntity> ConvertToEntityList(List<SystemRichTextWrapper> wrapperlist)
        {
            List<SystemRichTextEntity> list = new List<SystemRichTextEntity>();
            foreach (SystemRichTextWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemRichTextWrapper ConvertEntityToWrapper(SystemRichTextEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SystemRichTextWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

