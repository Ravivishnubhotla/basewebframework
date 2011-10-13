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
    public partial class SystemSettingWrapper
    {
        #region Member

		internal static readonly ISystemSettingServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemSettingServiceProxyInstance;
	 
	 
        internal SystemSettingEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SystemSettingWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SystemSettingWrapper() : this(new SystemSettingEntity())
        {
            
        }

        internal SystemSettingWrapper(SystemSettingEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemSettingEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_SYSTEMNAME = "SystemName";
		public static readonly string PROPERTY_NAME_SYSTEMDESCRIPTION = "SystemDescription";
		public static readonly string PROPERTY_NAME_SYSTEMURL = "SystemUrl";
		public static readonly string PROPERTY_NAME_SYSTEMVERSION = "SystemVersion";
		public static readonly string PROPERTY_NAME_SYSTEMLISENCE = "SystemLisence";
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
		public string SystemName
		{
			get
			{
				return entity.SystemName;
			}
			set
			{
				entity.SystemName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string SystemDescription
		{
			get
			{
				return entity.SystemDescription;
			}
			set
			{
				entity.SystemDescription = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string SystemUrl
		{
			get
			{
				return entity.SystemUrl;
			}
			set
			{
				entity.SystemUrl = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string SystemVersion
		{
			get
			{
				return entity.SystemVersion;
			}
			set
			{
				entity.SystemVersion = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string SystemLisence
		{
			get
			{
				return entity.SystemLisence;
			}
			set
			{
				entity.SystemLisence = value;
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
		
		internal static List<SystemSettingWrapper> ConvertToWrapperList(List<SystemSettingEntity> entitylist)
        {
            List<SystemSettingWrapper> list = new List<SystemSettingWrapper>();
            foreach (SystemSettingEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemSettingWrapper> ConvertToWrapperList(IList<SystemSettingEntity> entitylist)
        {
            List<SystemSettingWrapper> list = new List<SystemSettingWrapper>();
            foreach (SystemSettingEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemSettingEntity> ConvertToEntityList(List<SystemSettingWrapper> wrapperlist)
        {
            List<SystemSettingEntity> list = new List<SystemSettingEntity>();
            foreach (SystemSettingWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemSettingWrapper ConvertEntityToWrapper(SystemSettingEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SystemSettingWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

