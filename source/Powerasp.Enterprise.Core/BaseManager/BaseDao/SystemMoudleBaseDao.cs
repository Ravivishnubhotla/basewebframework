using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemMoudleBaseDao : BaseCastleNhibernateDao<SystemMoudle>
    {
		#region property
		public static readonly Property PROPERTY_MOUDLEID = Property.ForName(SystemMoudle.PROPERTY_NAME_MOUDLEID);
		public static readonly Property PROPERTY_MOUDLENAMECN = Property.ForName(SystemMoudle.PROPERTY_NAME_MOUDLENAMECN);
		public static readonly Property PROPERTY_MOUDLENAMEEN = Property.ForName(SystemMoudle.PROPERTY_NAME_MOUDLENAMEEN);
		public static readonly Property PROPERTY_MOUDLENAMEDB = Property.ForName(SystemMoudle.PROPERTY_NAME_MOUDLENAMEDB);
		public static readonly Property PROPERTY_MOUDLEDESCRIPTION = Property.ForName(SystemMoudle.PROPERTY_NAME_MOUDLEDESCRIPTION);
		public static readonly Property PROPERTY_APPLICATIONID = Property.ForName(SystemMoudle.PROPERTY_NAME_APPLICATIONID);
		public static readonly Property PROPERTY_MOUDLEISSYSTEMMOUDLE = Property.ForName(SystemMoudle.PROPERTY_NAME_MOUDLEISSYSTEMMOUDLE);
		
        #endregion
		
        public SystemMoudleBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemMoudleBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
