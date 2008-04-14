using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemPrivilegeBaseDao : BaseCastleNhibernateDao<SystemPrivilege>
    {
		#region property
		public static readonly Property PROPERTY_PRIVILEGEID = Property.ForName(SystemPrivilege.PROPERTY_NAME_PRIVILEGEID);
		public static readonly Property PROPERTY_OPERATIONID = Property.ForName(SystemPrivilege.PROPERTY_NAME_OPERATIONID);
		public static readonly Property PROPERTY_RESOURCESID = Property.ForName(SystemPrivilege.PROPERTY_NAME_RESOURCESID);
		public static readonly Property PROPERTY_PRIVILEGECNNAME = Property.ForName(SystemPrivilege.PROPERTY_NAME_PRIVILEGECNNAME);
		public static readonly Property PROPERTY_PRIVILEGEENNAME = Property.ForName(SystemPrivilege.PROPERTY_NAME_PRIVILEGEENNAME);
		public static readonly Property PROPERTY_DEFAULTVALUE = Property.ForName(SystemPrivilege.PROPERTY_NAME_DEFAULTVALUE);
		public static readonly Property PROPERTY_DESCRIPTION = Property.ForName(SystemPrivilege.PROPERTY_NAME_DESCRIPTION);
		public static readonly Property PROPERTY_PRIVILEGEORDER = Property.ForName(SystemPrivilege.PROPERTY_NAME_PRIVILEGEORDER);
		
        #endregion
		
        public SystemPrivilegeBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemPrivilegeBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
