using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemLogBaseDao : BaseCastleNhibernateDao<SystemLog>
    {
		#region property
		public static readonly Property PROPERTY_LOGID = Property.ForName(SystemLog.PROPERTY_NAME_LOGID);
		public static readonly Property PROPERTY_LOGLEVEL = Property.ForName(SystemLog.PROPERTY_NAME_LOGLEVEL);
		public static readonly Property PROPERTY_LOGTYPE = Property.ForName(SystemLog.PROPERTY_NAME_LOGTYPE);
		public static readonly Property PROPERTY_LOGDATE = Property.ForName(SystemLog.PROPERTY_NAME_LOGDATE);
		public static readonly Property PROPERTY_LOGSOURCE = Property.ForName(SystemLog.PROPERTY_NAME_LOGSOURCE);
		public static readonly Property PROPERTY_LOGUSER = Property.ForName(SystemLog.PROPERTY_NAME_LOGUSER);
		public static readonly Property PROPERTY_LOGDESCRPTION = Property.ForName(SystemLog.PROPERTY_NAME_LOGDESCRPTION);
		public static readonly Property PROPERTY_LOGREQUESTINFO = Property.ForName(SystemLog.PROPERTY_NAME_LOGREQUESTINFO);
		public static readonly Property PROPERTY_LOGRELATEMOUDLEID = Property.ForName(SystemLog.PROPERTY_NAME_LOGRELATEMOUDLEID);
		public static readonly Property PROPERTY_LOGRELATEMOUDLEDATAID = Property.ForName(SystemLog.PROPERTY_NAME_LOGRELATEMOUDLEDATAID);
		public static readonly Property PROPERTY_LOGRELATEUSERID = Property.ForName(SystemLog.PROPERTY_NAME_LOGRELATEUSERID);
		public static readonly Property PROPERTY_LOGRELATEDATETIME = Property.ForName(SystemLog.PROPERTY_NAME_LOGRELATEDATETIME);
		
        #endregion
		
        public SystemLogBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemLogBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
