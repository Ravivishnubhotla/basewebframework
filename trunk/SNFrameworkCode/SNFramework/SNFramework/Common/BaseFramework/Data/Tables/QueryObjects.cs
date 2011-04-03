using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using NHibernate;
using NHibernate.Criterion;

namespace Legendigital.Framework.Common.BaseFramework.Data.Tables
{
    public static class QueryObjects
    {
        public static DetachedCriteria GetUserAssignedRoles(SystemUserEntity user)
        {
            DetachedCriteria criteria = DetachedCriteria.For(typeof(SystemUserRoleRelationEntity));

            criteria.Add(SystemUserRoleRelationDataObject.PROPERTY_USERID.Eq(user));

            criteria.SetProjection(SystemUserRoleRelationDataObject.PROPERTY_ROLEID.CriterionProperty);

            return criteria;
        }
    }
}
