using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemShortMessageBaseDao : BaseCastleNhibernateDao<SystemShortMessage>
    {
		#region property
		public static readonly Property PROPERTY_SHORTMESSAGEID = Property.ForName(SystemShortMessage.PROPERTY_NAME_SHORTMESSAGEID);
		public static readonly Property PROPERTY_SHORTMESSAGETITLE = Property.ForName(SystemShortMessage.PROPERTY_NAME_SHORTMESSAGETITLE);
		public static readonly Property PROPERTY_SHORTMESSAGECATEGORY = Property.ForName(SystemShortMessage.PROPERTY_NAME_SHORTMESSAGECATEGORY);
		public static readonly Property PROPERTY_SHORTMESSAGECONTENT = Property.ForName(SystemShortMessage.PROPERTY_NAME_SHORTMESSAGECONTENT);
		public static readonly Property PROPERTY_SHORTMESSAGESENDER = Property.ForName(SystemShortMessage.PROPERTY_NAME_SHORTMESSAGESENDER);
		public static readonly Property PROPERTY_SHORTMESSAGESENDDATE = Property.ForName(SystemShortMessage.PROPERTY_NAME_SHORTMESSAGESENDDATE);
		public static readonly Property PROPERTY_SHORTMESSAGERECEIVERID = Property.ForName(SystemShortMessage.PROPERTY_NAME_SHORTMESSAGERECEIVERID);
		public static readonly Property PROPERTY_SHORTMESSAGEISREAD = Property.ForName(SystemShortMessage.PROPERTY_NAME_SHORTMESSAGEISREAD);
		
        #endregion
		
        public SystemShortMessageBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemShortMessageBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
