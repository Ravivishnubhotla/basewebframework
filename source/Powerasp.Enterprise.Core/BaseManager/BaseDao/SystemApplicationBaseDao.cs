using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemApplicationBaseDao : BaseCastleNhibernateDao<SystemApplication>
    {
		#region property
		public static readonly Property PROPERTY_SYSTEMAPPLICATIONID = Property.ForName(SystemApplication.PROPERTY_NAME_SYSTEMAPPLICATIONID);
		public static readonly Property PROPERTY_SYSTEMAPPLICATIONNAME = Property.ForName(SystemApplication.PROPERTY_NAME_SYSTEMAPPLICATIONNAME);
		public static readonly Property PROPERTY_SYSTEMAPPLICATIONDESCRIPTION = Property.ForName(SystemApplication.PROPERTY_NAME_SYSTEMAPPLICATIONDESCRIPTION);
		public static readonly Property PROPERTY_SYSTEMAPPLICATIONURL = Property.ForName(SystemApplication.PROPERTY_NAME_SYSTEMAPPLICATIONURL);
		
        #endregion
		
        public SystemApplicationBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemApplicationBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
