using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemRoleBaseDao : BaseCastleNhibernateDao<SystemRole>
    {
		#region property
		public static readonly Property PROPERTY_ROLEID = Property.ForName(SystemRole.PROPERTY_NAME_ROLEID);
		public static readonly Property PROPERTY_ROLENAME = Property.ForName(SystemRole.PROPERTY_NAME_ROLENAME);
		public static readonly Property PROPERTY_ROLEDESCRIPTION = Property.ForName(SystemRole.PROPERTY_NAME_ROLEDESCRIPTION);
		public static readonly Property PROPERTY_ROLEISSYSTEMROLE = Property.ForName(SystemRole.PROPERTY_NAME_ROLEISSYSTEMROLE);
		
        #endregion
		
        public SystemRoleBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemRoleBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
