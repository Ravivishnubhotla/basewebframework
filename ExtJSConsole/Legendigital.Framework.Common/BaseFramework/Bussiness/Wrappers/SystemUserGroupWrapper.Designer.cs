// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Spring.Context.Support;
using Common.Logging;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
    public partial class SystemUserGroupWrapper
    {
        #region Member

		internal static readonly ISystemUserGroupServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemUserGroupServiceProxyInstance;
		//internal static readonly ISystemUserGroupServiceProxy businessProxy = ((ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID"))).SystemUserGroupServiceProxyInstance;

        internal SystemUserGroupEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SystemUserGroupWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SystemUserGroupWrapper() : this(new SystemUserGroupEntity())
        {
            
        }

        internal SystemUserGroupWrapper(SystemUserGroupEntity entityObj)
        {
            entity = entityObj;
        }
		#endregion
		
		#region Equals 和 HashCode 方法覆盖
		public override bool Equals(object obj)
        {
            if (obj == null && entity!=null)
            {
                if (entity.GroupID == 0)
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemUserGroupEntity";
		public static readonly string PROPERTY_NAME_GROUPID = "GroupID";
		public static readonly string PROPERTY_NAME_GROUPNAMECN = "GroupNameCn";
		public static readonly string PROPERTY_NAME_GROUPNAMEEN = "GroupNameEn";
		public static readonly string PROPERTY_NAME_GROUPDESCRIPTION = "GroupDescription";
		
        #endregion


		#region Public Property
		/// <summary>
		/// 
		/// </summary>		
		public int GroupID
		{
			get
			{
				return entity.GroupID;
			}
			set
			{
				entity.GroupID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string GroupNameCn
		{
			get
			{
				return entity.GroupNameCn;
			}
			set
			{
				entity.GroupNameCn = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string GroupNameEn
		{
			get
			{
				return entity.GroupNameEn;
			}
			set
			{
				entity.GroupNameEn = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string GroupDescription
		{
			get
			{
				return entity.GroupDescription;
			}
			set
			{
				entity.GroupDescription = value;
			}
		}
		#endregion 







        #region Static Common Data Operation
		
		internal static List<SystemUserGroupWrapper> ConvertToWrapperList(List<SystemUserGroupEntity> entitylist)
        {
            List<SystemUserGroupWrapper> list = new List<SystemUserGroupWrapper>();
            foreach (SystemUserGroupEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemUserGroupWrapper> ConvertToWrapperList(IList<SystemUserGroupEntity> entitylist)
        {
            List<SystemUserGroupWrapper> list = new List<SystemUserGroupWrapper>();
            foreach (SystemUserGroupEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemUserGroupEntity> ConvertToEntityList(List<SystemUserGroupWrapper> wrapperlist)
        {
            List<SystemUserGroupEntity> list = new List<SystemUserGroupEntity>();
            foreach (SystemUserGroupWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemUserGroupWrapper ConvertEntityToWrapper(SystemUserGroupEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.GroupID == 0)
                return null;

            return new SystemUserGroupWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

