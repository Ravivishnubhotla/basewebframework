using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemUserRoleRelationBaseDao : BaseCastleNhibernateDao<SystemUserRoleRelation>
    {
		#region property
		public static readonly Property PROPERTY_USERROLEID = Property.ForName(SystemUserRoleRelation.PROPERTY_NAME_USERROLEID);
		public static readonly Property PROPERTY_USERID = Property.ForName(SystemUserRoleRelation.PROPERTY_NAME_USERID);
		public static readonly Property PROPERTY_ROLEID = Property.ForName(SystemUserRoleRelation.PROPERTY_NAME_ROLEID);
		
        #endregion
		
        public SystemUserRoleRelationBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemUserRoleRelationBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
