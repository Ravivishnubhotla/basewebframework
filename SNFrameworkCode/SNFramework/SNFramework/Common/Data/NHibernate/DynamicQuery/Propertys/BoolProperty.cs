using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace Legendigital.Framework.Common.Data.NHibernate.DynamicQuery.Propertys
{
    public class BoolProperty : TypedCriterionProperty
    {
        public BoolProperty(Property _criterionProperty)
            : base(_criterionProperty, typeof(bool))
        {
        }

        public ICriterion Eq(bool value)
        {
            return criterionProperty.Eq(value);
        }

        public ICriterion In(List<bool> values)
        {
            return criterionProperty.In(values);
        }

        public ICriterion In(bool[] values)
        {
            return criterionProperty.In(values);
        }
    }
}
