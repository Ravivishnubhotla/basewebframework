using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemSettingBaseDao : BaseCastleNhibernateDao<SystemSetting>
    {
		#region property
		public static readonly Property PROPERTY_ID = Property.ForName(SystemSetting.PROPERTY_NAME_ID);
		public static readonly Property PROPERTY_SYSTEMNAME = Property.ForName(SystemSetting.PROPERTY_NAME_SYSTEMNAME);
		public static readonly Property PROPERTY_SYSTEMDESCRIPTION = Property.ForName(SystemSetting.PROPERTY_NAME_SYSTEMDESCRIPTION);
		public static readonly Property PROPERTY_SYSTEMURL = Property.ForName(SystemSetting.PROPERTY_NAME_SYSTEMURL);
		public static readonly Property PROPERTY_SYSTEMVERSION = Property.ForName(SystemSetting.PROPERTY_NAME_SYSTEMVERSION);
		public static readonly Property PROPERTY_SYSTEMLISENCE = Property.ForName(SystemSetting.PROPERTY_NAME_SYSTEMLISENCE);
		
        #endregion
		
        public SystemSettingBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemSettingBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
