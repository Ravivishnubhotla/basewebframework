using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemUserGroupRoleRelationBaseDao : BaseCastleNhibernateDao<SystemUserGroupRoleRelation>
    {
		#region property
		public static readonly Property PROPERTY_USERGROUPROLEID = Property.ForName(SystemUserGroupRoleRelation.PROPERTY_NAME_USERGROUPROLEID);
		public static readonly Property PROPERTY_ROLEID = Property.ForName(SystemUserGroupRoleRelation.PROPERTY_NAME_ROLEID);
		public static readonly Property PROPERTY_USERGROUPID = Property.ForName(SystemUserGroupRoleRelation.PROPERTY_NAME_USERGROUPID);
		
        #endregion
		
        public SystemUserGroupRoleRelationBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemUserGroupRoleRelationBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
