using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemOperationBaseDao : BaseCastleNhibernateDao<SystemOperation>
    {
		#region property
		public static readonly Property PROPERTY_OPERATIONID = Property.ForName(SystemOperation.PROPERTY_NAME_OPERATIONID);
		public static readonly Property PROPERTY_OPERATIONNAMECN = Property.ForName(SystemOperation.PROPERTY_NAME_OPERATIONNAMECN);
		public static readonly Property PROPERTY_OPERATIONNAMEEN = Property.ForName(SystemOperation.PROPERTY_NAME_OPERATIONNAMEEN);
		public static readonly Property PROPERTY_OPERATIONDESCRIPTION = Property.ForName(SystemOperation.PROPERTY_NAME_OPERATIONDESCRIPTION);
		
        #endregion
		
        public SystemOperationBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemOperationBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
