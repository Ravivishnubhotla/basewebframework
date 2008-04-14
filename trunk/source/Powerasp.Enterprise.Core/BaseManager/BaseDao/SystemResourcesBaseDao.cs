using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemResourcesBaseDao : BaseCastleNhibernateDao<SystemResources>
    {
		#region property
		public static readonly Property PROPERTY_RESOURCESID = Property.ForName(SystemResources.PROPERTY_NAME_RESOURCESID);
		public static readonly Property PROPERTY_RESOURCESNAMECN = Property.ForName(SystemResources.PROPERTY_NAME_RESOURCESNAMECN);
		public static readonly Property PROPERTY_RESOURCESNAMEEN = Property.ForName(SystemResources.PROPERTY_NAME_RESOURCESNAMEEN);
		public static readonly Property PROPERTY_RESOURCESDESCRIPTION = Property.ForName(SystemResources.PROPERTY_NAME_RESOURCESDESCRIPTION);
		public static readonly Property PROPERTY_RESOURCESTYPE = Property.ForName(SystemResources.PROPERTY_NAME_RESOURCESTYPE);
		public static readonly Property PROPERTY_RESOURCESLIMITEXPRESSION = Property.ForName(SystemResources.PROPERTY_NAME_RESOURCESLIMITEXPRESSION);
		public static readonly Property PROPERTY_RESOURCESISRELATEUSER = Property.ForName(SystemResources.PROPERTY_NAME_RESOURCESISRELATEUSER);
		public static readonly Property PROPERTY_MOUDLEID = Property.ForName(SystemResources.PROPERTY_NAME_MOUDLEID);
		
        #endregion
		
        public SystemResourcesBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemResourcesBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
