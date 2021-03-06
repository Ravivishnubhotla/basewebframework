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
    public partial class SystemTimeZoneWrapper    //: BaseSpringNHibernateWrapper<SystemTimeZoneEntity, ISystemTimeZoneServiceProxy, SystemTimeZoneWrapper,int>
    {
        #region Member

		internal static readonly ISystemTimeZoneServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemTimeZoneServiceProxyInstance;
		
		
		internal SystemTimeZoneEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemTimeZoneWrapper() : base(new SystemTimeZoneEntity())
        {
            
        }

        internal SystemTimeZoneWrapper(SystemTimeZoneEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemTimeZoneEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_NAMECN = "NameCn";
		public static readonly string PROPERTY_NAME_DISPLAYNAME = "DisplayName";
		public static readonly string PROPERTY_NAME_DISPLAYNAMECN = "DisplayNameCn";
		public static readonly string PROPERTY_NAME_STANDARDNAME = "StandardName";
		public static readonly string PROPERTY_NAME_STANDARDNAMECN = "StandardNameCn";
		public static readonly string PROPERTY_NAME_DAYLIGHTNAME = "DaylightName";
		public static readonly string PROPERTY_NAME_UTCOFFSET = "UTCOffset";
		public static readonly string PROPERTY_NAME_SUPPORTDST = "SupportDST";
		public static readonly string PROPERTY_NAME_DAYLIGHTDELTA = "DaylightDelta";
		
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
		public string NameCn
		{
			get
			{
				return entity.NameCn;
			}
			set
			{
				entity.NameCn = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string DisplayName
		{
			get
			{
				return entity.DisplayName;
			}
			set
			{
				entity.DisplayName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string DisplayNameCn
		{
			get
			{
				return entity.DisplayNameCn;
			}
			set
			{
				entity.DisplayNameCn = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string StandardName
		{
			get
			{
				return entity.StandardName;
			}
			set
			{
				entity.StandardName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string StandardNameCn
		{
			get
			{
				return entity.StandardNameCn;
			}
			set
			{
				entity.StandardNameCn = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string DaylightName
		{
			get
			{
				return entity.DaylightName;
			}
			set
			{
				entity.DaylightName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int UTCOffset
		{
			get
			{
				return entity.UTCOffset;
			}
			set
			{
				entity.UTCOffset = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public bool SupportDST
		{
			get
			{
				return entity.SupportDST;
			}
			set
			{
				entity.SupportDST = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int DaylightDelta
		{
			get
			{
				return entity.DaylightDelta;
			}
			set
			{
				entity.DaylightDelta = value;
			}
		}
		#endregion 


		#region Query Property
		
		
      	
   
		#endregion


        #region "FKQuery"



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemTimeZoneWrapper> ConvertToWrapperList(List<SystemTimeZoneEntity> entitylist)
        {
            List<SystemTimeZoneWrapper> list = new List<SystemTimeZoneWrapper>();
            foreach (SystemTimeZoneEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemTimeZoneWrapper> ConvertToWrapperList(IList<SystemTimeZoneEntity> entitylist)
        {
            List<SystemTimeZoneWrapper> list = new List<SystemTimeZoneWrapper>();
            foreach (SystemTimeZoneEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemTimeZoneEntity> ConvertToEntityList(List<SystemTimeZoneWrapper> wrapperlist)
        {
            List<SystemTimeZoneEntity> list = new List<SystemTimeZoneEntity>();
            foreach (SystemTimeZoneWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemTimeZoneWrapper ConvertEntityToWrapper(SystemTimeZoneEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SystemTimeZoneWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

