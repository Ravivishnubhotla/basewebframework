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
    public partial class SystemPhoneAreaWrapper    //: BaseSpringNHibernateWrapper<SystemPhoneAreaEntity, ISystemPhoneAreaServiceProxy, SystemPhoneAreaWrapper,int>
    {
        #region Member

		internal static readonly ISystemPhoneAreaServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemPhoneAreaServiceProxyInstance;
		
		
		internal SystemPhoneAreaEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemPhoneAreaWrapper() : base(new SystemPhoneAreaEntity())
        {
            
        }

        internal SystemPhoneAreaWrapper(SystemPhoneAreaEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemPhoneAreaEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_PHONEPREFIX = "PhonePrefix";
		public static readonly string PROPERTY_NAME_PROVINCE = "Province";
		public static readonly string PROPERTY_NAME_CITY = "City";
		public static readonly string PROPERTY_NAME_OPERATORTYPE = "OperatorType";
		public static readonly string PROPERTY_NAME_CARDTYPE = "CardType";
		public static readonly string PROPERTY_NAME_AREACODE = "AreaCode";
		public static readonly string PROPERTY_NAME_ZIPCODE = "ZipCode";
		
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
		public string PhonePrefix
		{
			get
			{
				return entity.PhonePrefix;
			}
			set
			{
				entity.PhonePrefix = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Province
		{
			get
			{
				return entity.Province;
			}
			set
			{
				entity.Province = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string City
		{
			get
			{
				return entity.City;
			}
			set
			{
				entity.City = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string OperatorType
		{
			get
			{
				return entity.OperatorType;
			}
			set
			{
				entity.OperatorType = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string CardType
		{
			get
			{
				return entity.CardType;
			}
			set
			{
				entity.CardType = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string AreaCode
		{
			get
			{
				return entity.AreaCode;
			}
			set
			{
				entity.AreaCode = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string ZipCode
		{
			get
			{
				return entity.ZipCode;
			}
			set
			{
				entity.ZipCode = value;
			}
		}
		#endregion 


		#region Query Property
		
		
      	
   
		#endregion


        #region "FKQuery"



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemPhoneAreaWrapper> ConvertToWrapperList(List<SystemPhoneAreaEntity> entitylist)
        {
            List<SystemPhoneAreaWrapper> list = new List<SystemPhoneAreaWrapper>();
            foreach (SystemPhoneAreaEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemPhoneAreaWrapper> ConvertToWrapperList(IList<SystemPhoneAreaEntity> entitylist)
        {
            List<SystemPhoneAreaWrapper> list = new List<SystemPhoneAreaWrapper>();
            foreach (SystemPhoneAreaEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemPhoneAreaEntity> ConvertToEntityList(List<SystemPhoneAreaWrapper> wrapperlist)
        {
            List<SystemPhoneAreaEntity> list = new List<SystemPhoneAreaEntity>();
            foreach (SystemPhoneAreaWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemPhoneAreaWrapper ConvertEntityToWrapper(SystemPhoneAreaEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SystemPhoneAreaWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

