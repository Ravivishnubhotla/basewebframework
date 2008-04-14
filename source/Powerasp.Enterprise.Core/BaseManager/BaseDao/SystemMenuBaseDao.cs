using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemMenuBaseDao : BaseCastleNhibernateDao<SystemMenu>
    {
		#region property
		public static readonly Property PROPERTY_MENUID = Property.ForName(SystemMenu.PROPERTY_NAME_MENUID);
		public static readonly Property PROPERTY_MENUNAME = Property.ForName(SystemMenu.PROPERTY_NAME_MENUNAME);
		public static readonly Property PROPERTY_MENUDESCRIPTION = Property.ForName(SystemMenu.PROPERTY_NAME_MENUDESCRIPTION);
		public static readonly Property PROPERTY_MENUURL = Property.ForName(SystemMenu.PROPERTY_NAME_MENUURL);
		public static readonly Property PROPERTY_MENUURLTARGET = Property.ForName(SystemMenu.PROPERTY_NAME_MENUURLTARGET);
		public static readonly Property PROPERTY_MENUISCATEGORY = Property.ForName(SystemMenu.PROPERTY_NAME_MENUISCATEGORY);
		public static readonly Property PROPERTY_PARENTMENUID = Property.ForName(SystemMenu.PROPERTY_NAME_PARENTMENUID);
		public static readonly Property PROPERTY_MENUORDER = Property.ForName(SystemMenu.PROPERTY_NAME_MENUORDER);
		public static readonly Property PROPERTY_MENUTYPE = Property.ForName(SystemMenu.PROPERTY_NAME_MENUTYPE);
		public static readonly Property PROPERTY_MENUISSYSTEMMENU = Property.ForName(SystemMenu.PROPERTY_NAME_MENUISSYSTEMMENU);
		public static readonly Property PROPERTY_MENUISENABLE = Property.ForName(SystemMenu.PROPERTY_NAME_MENUISENABLE);
		public static readonly Property PROPERTY_APPLICATIONID = Property.ForName(SystemMenu.PROPERTY_NAME_APPLICATIONID);
		
        #endregion
		
        public SystemMenuBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemMenuBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
