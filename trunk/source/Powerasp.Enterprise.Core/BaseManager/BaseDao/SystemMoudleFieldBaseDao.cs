using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemMoudleFieldBaseDao : BaseCastleNhibernateDao<SystemMoudleField>
    {
		#region property
		public static readonly Property PROPERTY_SYSTEMMOUDLEFIELDID = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEFIELDID);
		public static readonly Property PROPERTY_SYSTEMMOUDLEFIELDNAMEEN = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEFIELDNAMEEN);
		public static readonly Property PROPERTY_SYSTEMMOUDLEFIELDNAMECN = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEFIELDNAMECN);
		public static readonly Property PROPERTY_SYSTEMMOUDLEFIELDNAMEDB = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEFIELDNAMEDB);
		public static readonly Property PROPERTY_SYSTEMMOUDLEFIELDTYPE = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEFIELDTYPE);
		public static readonly Property PROPERTY_SYSTEMMOUDLEFIELDISREQUIRED = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEFIELDISREQUIRED);
		public static readonly Property PROPERTY_SYSTEMMOUDLEFIELDDEFAULTVALUE = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEFIELDDEFAULTVALUE);
		public static readonly Property PROPERTY_SYSTEMMOUDLEFIELDISKEYFIELD = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEFIELDISKEYFIELD);
		public static readonly Property PROPERTY_SYSTEMMOUDLEFIELDSIZE = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEFIELDSIZE);
		public static readonly Property PROPERTY_SYSTEMMOUDLEFIELDDESCRIPTION = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEFIELDDESCRIPTION);
		public static readonly Property PROPERTY_SYSTEMMOUDLEID = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEID);
		
        #endregion
		
        public SystemMoudleFieldBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemMoudleFieldBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
