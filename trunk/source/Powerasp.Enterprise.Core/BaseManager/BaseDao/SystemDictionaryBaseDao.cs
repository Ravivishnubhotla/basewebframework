using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemDictionaryBaseDao : BaseCastleNhibernateDao<SystemDictionary>
    {
		#region property
		public static readonly Property PROPERTY_SYSTEMDICTIONARYID = Property.ForName(SystemDictionary.PROPERTY_NAME_SYSTEMDICTIONARYID);
		public static readonly Property PROPERTY_SYSTEMDICTIONARYCATEGORYID = Property.ForName(SystemDictionary.PROPERTY_NAME_SYSTEMDICTIONARYCATEGORYID);
		public static readonly Property PROPERTY_SYSTEMDICTIONARYKEY = Property.ForName(SystemDictionary.PROPERTY_NAME_SYSTEMDICTIONARYKEY);
		public static readonly Property PROPERTY_SYSTEMDICTIONARYVALUE = Property.ForName(SystemDictionary.PROPERTY_NAME_SYSTEMDICTIONARYVALUE);
		public static readonly Property PROPERTY_SYSTEMDICTIONARYDESCIPTION = Property.ForName(SystemDictionary.PROPERTY_NAME_SYSTEMDICTIONARYDESCIPTION);
		public static readonly Property PROPERTY_SYSTEMDICTIONARYORDER = Property.ForName(SystemDictionary.PROPERTY_NAME_SYSTEMDICTIONARYORDER);
		public static readonly Property PROPERTY_SYSTEMDICTIONARYISENABLE = Property.ForName(SystemDictionary.PROPERTY_NAME_SYSTEMDICTIONARYISENABLE);
		
        #endregion
		
        public SystemDictionaryBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemDictionaryBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
