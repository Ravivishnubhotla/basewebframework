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
    public partial class SPParamsConvertRuleWrapper    //: BaseSpringNHibernateWrapper<SPParamsConvertRuleEntity, ISPParamsConvertRuleServiceProxy, SPParamsConvertRuleWrapper,int>
    {
        #region Member

		internal static readonly ISPParamsConvertRuleServiceProxy businessProxy = ((SPS.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID", typeof(SPS.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)))).SPParamsConvertRuleServiceProxyInstance;
		
		
		internal SPParamsConvertRuleEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SPParamsConvertRuleWrapper() : base(new SPParamsConvertRuleEntity())
        {
            
        }

        internal SPParamsConvertRuleWrapper(SPParamsConvertRuleEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPParamsConvertRuleEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_PARENTDATAID = "ParentDataID";
		public static readonly string PROPERTY_NAME_PARENTDATATYPE = "ParentDataType";
		public static readonly string PROPERTY_NAME_CONVERTCODE = "ConvertCode";
		public static readonly string PROPERTY_NAME_CONVERTTYPE = "ConvertType";
		
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
		public string ConvertCode
		{
			get
			{
				return entity.ConvertCode;
			}
			set
			{
				entity.ConvertCode = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string ConvertType
		{
			get
			{
				return entity.ConvertType;
			}
			set
			{
				entity.ConvertType = value;
			}
		}
		#endregion 


		#region Query Property
		
		
      	
   
		#endregion


        #region "FKQuery"



        #endregion








        #region Static Common Data Operation
		
		internal static List<SPParamsConvertRuleWrapper> ConvertToWrapperList(List<SPParamsConvertRuleEntity> entitylist)
        {
            List<SPParamsConvertRuleWrapper> list = new List<SPParamsConvertRuleWrapper>();
            foreach (SPParamsConvertRuleEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SPParamsConvertRuleWrapper> ConvertToWrapperList(IList<SPParamsConvertRuleEntity> entitylist)
        {
            List<SPParamsConvertRuleWrapper> list = new List<SPParamsConvertRuleWrapper>();
            foreach (SPParamsConvertRuleEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SPParamsConvertRuleEntity> ConvertToEntityList(List<SPParamsConvertRuleWrapper> wrapperlist)
        {
            List<SPParamsConvertRuleEntity> list = new List<SPParamsConvertRuleEntity>();
            foreach (SPParamsConvertRuleWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SPParamsConvertRuleWrapper ConvertEntityToWrapper(SPParamsConvertRuleEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SPParamsConvertRuleWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace
