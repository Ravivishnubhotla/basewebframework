// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Spring.Context.Support;
using Common.Logging;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables.Container;
using SPS.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;

namespace SPS.Bussiness.Wrappers
{
    public partial class SPUpperWrapper    : BaseSpringNHibernateWrapper<SPUpperEntity, ISPUpperServiceProxy, SPUpperWrapper,int>
    {
        #region Member

		internal static readonly ISPUpperServiceProxy businessProxy = ((SPS.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID", typeof(SPS.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)))).SPUpperServiceProxyInstance;
		
		
		internal SPUpperEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SPUpperWrapper() : base(new SPUpperEntity())
        {
            
        }

        internal SPUpperWrapper(SPUpperEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPUpperEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_CODE = "Code";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
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
		public int CreateBy
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
		public DateTime CreateAt
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
		public int LastModifyBy
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
		public DateTime LastModifyAt
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
		
		internal static List<SPUpperWrapper> ConvertToWrapperList(List<SPUpperEntity> entitylist)
        {
            List<SPUpperWrapper> list = new List<SPUpperWrapper>();
            foreach (SPUpperEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SPUpperWrapper> ConvertToWrapperList(IList<SPUpperEntity> entitylist)
        {
            List<SPUpperWrapper> list = new List<SPUpperWrapper>();
            foreach (SPUpperEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SPUpperEntity> ConvertToEntityList(List<SPUpperWrapper> wrapperlist)
        {
            List<SPUpperEntity> list = new List<SPUpperEntity>();
            foreach (SPUpperWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SPUpperWrapper ConvertEntityToWrapper(SPUpperEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SPUpperWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

