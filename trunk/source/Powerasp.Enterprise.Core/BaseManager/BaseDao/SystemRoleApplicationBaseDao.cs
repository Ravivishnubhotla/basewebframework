using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemRoleApplicationBaseDao : BaseCastleNhibernateDao<SystemRoleApplication>
    {
		#region property
		public static readonly Property PROPERTY_SYSTEMROLEAPPLICATIONID = Property.ForName(SystemRoleApplication.PROPERTY_NAME_SYSTEMROLEAPPLICATIONID);
		public static readonly Property PROPERTY_ROLEID = Property.ForName(SystemRoleApplication.PROPERTY_NAME_ROLEID);
		public static readonly Property PROPERTY_APPLICATIONID = Property.ForName(SystemRoleApplication.PROPERTY_NAME_APPLICATIONID);
		
        #endregion
		
        public SystemRoleApplicationBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemRoleApplicationBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
