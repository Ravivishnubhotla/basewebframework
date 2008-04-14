using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemRoleMenuRelationBaseDao : BaseCastleNhibernateDao<SystemRoleMenuRelation>
    {
		#region property
		public static readonly Property PROPERTY_MENUROLEID = Property.ForName(SystemRoleMenuRelation.PROPERTY_NAME_MENUROLEID);
		public static readonly Property PROPERTY_MENUID = Property.ForName(SystemRoleMenuRelation.PROPERTY_NAME_MENUID);
		public static readonly Property PROPERTY_ROLEID = Property.ForName(SystemRoleMenuRelation.PROPERTY_NAME_ROLEID);
		
        #endregion
		
        public SystemRoleMenuRelationBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemRoleMenuRelationBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
