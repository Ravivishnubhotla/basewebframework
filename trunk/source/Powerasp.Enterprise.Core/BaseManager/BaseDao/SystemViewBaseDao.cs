using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemViewBaseDao : BaseCastleNhibernateDao<SystemView>
    {
		#region property
		public static readonly Property PROPERTY_SYSTEMVIEWID = Property.ForName(SystemView.PROPERTY_NAME_SYSTEMVIEWID);
		public static readonly Property PROPERTY_SYSTEMVIEWNAMECN = Property.ForName(SystemView.PROPERTY_NAME_SYSTEMVIEWNAMECN);
		public static readonly Property PROPERTY_SYSTEMVIEWNAMEEN = Property.ForName(SystemView.PROPERTY_NAME_SYSTEMVIEWNAMEEN);
		public static readonly Property PROPERTY_APPLICATIONID = Property.ForName(SystemView.PROPERTY_NAME_APPLICATIONID);
		public static readonly Property PROPERTY_SYSTEMVIEWDESCRIPTION = Property.ForName(SystemView.PROPERTY_NAME_SYSTEMVIEWDESCRIPTION);
		
        #endregion
		
        public SystemViewBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemViewBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
