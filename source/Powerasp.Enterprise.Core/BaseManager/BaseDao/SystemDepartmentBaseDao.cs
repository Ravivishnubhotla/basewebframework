using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Data;
using Powerasp.Enterprise.Core.BaseManager.Domain;





namespace Powerasp.Enterprise.Core.BaseManager.BaseDao
{
    public abstract class SystemDepartmentBaseDao : BaseCastleNhibernateDao<SystemDepartment>
    {
		#region property
		public static readonly Property PROPERTY_DEPARTMENTID = Property.ForName(SystemDepartment.PROPERTY_NAME_DEPARTMENTID);
		public static readonly Property PROPERTY_PARENTDEPARTMENTID = Property.ForName(SystemDepartment.PROPERTY_NAME_PARENTDEPARTMENTID);
		public static readonly Property PROPERTY_DEPARTMENTNAMECN = Property.ForName(SystemDepartment.PROPERTY_NAME_DEPARTMENTNAMECN);
		public static readonly Property PROPERTY_DEPARTMENTNAMEEN = Property.ForName(SystemDepartment.PROPERTY_NAME_DEPARTMENTNAMEEN);
		public static readonly Property PROPERTY_DEPARTMENTDECRIPTION = Property.ForName(SystemDepartment.PROPERTY_NAME_DEPARTMENTDECRIPTION);
		
        #endregion
		
        public SystemDepartmentBaseDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemDepartmentBaseDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
