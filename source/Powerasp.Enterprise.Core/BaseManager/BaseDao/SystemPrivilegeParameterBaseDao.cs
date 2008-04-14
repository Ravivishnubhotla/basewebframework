using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemPrivilegeParameterBaseDao : BaseCastleNhibernateDao<SystemPrivilegeParameter>
    {
		#region property
		public static readonly Property PROPERTY_PRIVILEGEPARAMETERID = Property.ForName(SystemPrivilegeParameter.PROPERTY_NAME_PRIVILEGEPARAMETERID);
		public static readonly Property PROPERTY_ROLEID = Property.ForName(SystemPrivilegeParameter.PROPERTY_NAME_ROLEID);
		public static readonly Property PROPERTY_PRIVILEGEID = Property.ForName(SystemPrivilegeParameter.PROPERTY_NAME_PRIVILEGEID);
		public static readonly Property PROPERTY_BIZPARAMETER = Property.ForName(SystemPrivilegeParameter.PROPERTY_NAME_BIZPARAMETER);
		
        #endregion
		
        public SystemPrivilegeParameterBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemPrivilegeParameterBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
