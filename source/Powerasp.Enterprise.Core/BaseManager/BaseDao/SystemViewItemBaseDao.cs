using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemViewItemBaseDao : BaseCastleNhibernateDao<SystemViewItem>
    {
		#region property
		public static readonly Property PROPERTY_SYSTEMVIEWITEMID = Property.ForName(SystemViewItem.PROPERTY_NAME_SYSTEMVIEWITEMID);
		public static readonly Property PROPERTY_SYSTEMVIEWITEMNAMEEN = Property.ForName(SystemViewItem.PROPERTY_NAME_SYSTEMVIEWITEMNAMEEN);
		public static readonly Property PROPERTY_SYSTEMVIEWITEMNAMECN = Property.ForName(SystemViewItem.PROPERTY_NAME_SYSTEMVIEWITEMNAMECN);
		public static readonly Property PROPERTY_SYSTEMVIEWITEMDESCRIPTION = Property.ForName(SystemViewItem.PROPERTY_NAME_SYSTEMVIEWITEMDESCRIPTION);
		public static readonly Property PROPERTY_SYSTEMVIEWITEMDISPLAYFORMAT = Property.ForName(SystemViewItem.PROPERTY_NAME_SYSTEMVIEWITEMDISPLAYFORMAT);
		public static readonly Property PROPERTY_SYSTEMVIEWID = Property.ForName(SystemViewItem.PROPERTY_NAME_SYSTEMVIEWID);
		
        #endregion
		
        public SystemViewItemBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemViewItemBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
