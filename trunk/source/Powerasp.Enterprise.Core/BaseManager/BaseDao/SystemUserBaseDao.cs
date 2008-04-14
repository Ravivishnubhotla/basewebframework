using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemUserBaseDao : BaseCastleNhibernateDao<SystemUser>
    {
		#region property
		public static readonly Property PROPERTY_USERID = Property.ForName(SystemUser.PROPERTY_NAME_USERID);
		public static readonly Property PROPERTY_USERLOGINID = Property.ForName(SystemUser.PROPERTY_NAME_USERLOGINID);
		public static readonly Property PROPERTY_USERNAME = Property.ForName(SystemUser.PROPERTY_NAME_USERNAME);
		public static readonly Property PROPERTY_USEREMAIL = Property.ForName(SystemUser.PROPERTY_NAME_USEREMAIL);
		public static readonly Property PROPERTY_USERPASSWORD = Property.ForName(SystemUser.PROPERTY_NAME_USERPASSWORD);
		public static readonly Property PROPERTY_USERSTATUS = Property.ForName(SystemUser.PROPERTY_NAME_USERSTATUS);
		public static readonly Property PROPERTY_USERCREATEDATE = Property.ForName(SystemUser.PROPERTY_NAME_USERCREATEDATE);
		public static readonly Property PROPERTY_USERTYPE = Property.ForName(SystemUser.PROPERTY_NAME_USERTYPE);
		public static readonly Property PROPERTY_DEPARTMENTID = Property.ForName(SystemUser.PROPERTY_NAME_DEPARTMENTID);
		
        #endregion
		
        public SystemUserBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemUserBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
