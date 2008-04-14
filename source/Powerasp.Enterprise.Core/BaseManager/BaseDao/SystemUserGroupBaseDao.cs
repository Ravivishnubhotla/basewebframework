using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemUserGroupBaseDao : BaseCastleNhibernateDao<SystemUserGroup>
    {
		#region property
		public static readonly Property PROPERTY_GROUPID = Property.ForName(SystemUserGroup.PROPERTY_NAME_GROUPID);
		public static readonly Property PROPERTY_GROUPNAMECN = Property.ForName(SystemUserGroup.PROPERTY_NAME_GROUPNAMECN);
		public static readonly Property PROPERTY_GROUPNAMEEN = Property.ForName(SystemUserGroup.PROPERTY_NAME_GROUPNAMEEN);
		public static readonly Property PROPERTY_GROUPDESCRIPTION = Property.ForName(SystemUserGroup.PROPERTY_NAME_GROUPDESCRIPTION);
		
        #endregion
		
        public SystemUserGroupBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemUserGroupBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
