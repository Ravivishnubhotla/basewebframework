using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemUserGroupUserRelationBaseDao : BaseCastleNhibernateDao<SystemUserGroupUserRelation>
    {
		#region property
		public static readonly Property PROPERTY_USERGROUPUSERID = Property.ForName(SystemUserGroupUserRelation.PROPERTY_NAME_USERGROUPUSERID);
		public static readonly Property PROPERTY_USERID = Property.ForName(SystemUserGroupUserRelation.PROPERTY_NAME_USERID);
		public static readonly Property PROPERTY_USERGROUPID = Property.ForName(SystemUserGroupUserRelation.PROPERTY_NAME_USERGROUPID);
		
        #endregion
		
        public SystemUserGroupUserRelationBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemUserGroupUserRelationBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
