using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemPrivilegeInRolesBaseDao : BaseCastleNhibernateDao<SystemPrivilegeInRoles>
    {
		#region property
		public static readonly Property PROPERTY_PRIVILEGEROLEID = Property.ForName(SystemPrivilegeInRoles.PROPERTY_NAME_PRIVILEGEROLEID);
		public static readonly Property PROPERTY_ROLEID = Property.ForName(SystemPrivilegeInRoles.PROPERTY_NAME_ROLEID);
		public static readonly Property PROPERTY_PRIVILEGEID = Property.ForName(SystemPrivilegeInRoles.PROPERTY_NAME_PRIVILEGEID);
		public static readonly Property PROPERTY_PRIVILEGEROLEVALUE = Property.ForName(SystemPrivilegeInRoles.PROPERTY_NAME_PRIVILEGEROLEVALUE);
		public static readonly Property PROPERTY_ENABLETYPE = Property.ForName(SystemPrivilegeInRoles.PROPERTY_NAME_ENABLETYPE);
		public static readonly Property PROPERTY_CREATETIME = Property.ForName(SystemPrivilegeInRoles.PROPERTY_NAME_CREATETIME);
		public static readonly Property PROPERTY_UPDATETIME = Property.ForName(SystemPrivilegeInRoles.PROPERTY_NAME_UPDATETIME);
		public static readonly Property PROPERTY_EXPIRYTIME = Property.ForName(SystemPrivilegeInRoles.PROPERTY_NAME_EXPIRYTIME);
		public static readonly Property PROPERTY_ENABLEPARAMETER = Property.ForName(SystemPrivilegeInRoles.PROPERTY_NAME_ENABLEPARAMETER);
		
        #endregion
		
        public SystemPrivilegeInRolesBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemPrivilegeInRolesBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
