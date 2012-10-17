// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Spring.Context.Support;
using Common.Logging;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables.Container;
using SPS.Bussiness.ServiceProxys.Tables;

namespace SPS.Bussiness.Wrappers
{
    public partial class SPFilterRuleWrapper
    {
        #region Member

		internal static readonly ISPFilterRuleServiceProxy businessProxy = ((SPS.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID", typeof(SPS.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)))).SPFilterRuleServiceProxyInstance;
		//internal static readonly ISPFilterRuleServiceProxy businessProxy = ((ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID"))).SPFilterRuleServiceProxyInstance;

        internal SPFilterRuleEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SPFilterRuleWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SPFilterRuleWrapper() : this(new SPFilterRuleEntity())
        {
            
        }

        internal SPFilterRuleWrapper(SPFilterRuleEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPFilterRuleEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_PARENTDATAID = "ParentDataID";
		public static readonly string PROPERTY_NAME_PARENTDATATYPE = "ParentDataType";
		public static readonly string PROPERTY_NAME_RULECODE = "RuleCode";
		public static readonly string PROPERTY_NAME_FILTERTYPE = "FilterType";
		
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
		public string RuleCode
		{
			get
			{
				return entity.RuleCode;
			}
			set
			{
				entity.RuleCode = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string FilterType
		{
			get
			{
				return entity.FilterType;
			}
			set
			{
				entity.FilterType = value;
			}
		}
		#endregion 





        #region "FKQuery"



        #endregion

        #region Static Common Data Operation
		
		internal static List<SPFilterRuleWrapper> ConvertToWrapperList(List<SPFilterRuleEntity> entitylist)
        {
            List<SPFilterRuleWrapper> list = new List<SPFilterRuleWrapper>();
            foreach (SPFilterRuleEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SPFilterRuleWrapper> ConvertToWrapperList(IList<SPFilterRuleEntity> entitylist)
        {
            List<SPFilterRuleWrapper> list = new List<SPFilterRuleWrapper>();
            foreach (SPFilterRuleEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SPFilterRuleEntity> ConvertToEntityList(List<SPFilterRuleWrapper> wrapperlist)
        {
            List<SPFilterRuleEntity> list = new List<SPFilterRuleEntity>();
            foreach (SPFilterRuleWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SPFilterRuleWrapper ConvertEntityToWrapper(SPFilterRuleEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SPFilterRuleWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

