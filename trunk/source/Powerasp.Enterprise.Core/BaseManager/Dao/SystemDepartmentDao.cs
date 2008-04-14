using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using NHibernate.Mapping;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.BaseManager.BaseDao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.Dao
{
    public class SystemDepartmentDao : SystemDepartmentBaseDao
    {
        public SystemDepartmentDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemDepartmentDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }


        public List<SystemDepartment> GetSubDepartmentByParentDepartment(SystemDepartment parentDepartment)
        {
            DetachedCriteria departmentCriteria = DetachedCriteria.For(typeof(SystemDepartment));
            if (parentDepartment == null)
                departmentCriteria.Add(SystemDepartmentDao.PROPERTY_PARENTDEPARTMENTID.IsNull());
            else
                departmentCriteria.Add(SystemDepartmentDao.PROPERTY_PARENTDEPARTMENTID.Eq(parentDepartment));

            return  this.FindListByDetachedCriteriaQuery(departmentCriteria);

        }
    }
}
