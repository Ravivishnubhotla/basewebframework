using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace Legendigital.Framework.Common.Data.NHibernate.DynamicQuery.Propertys
{
    public class EntityProperty<T> : TypedCriterionProperty
    {
        public EntityProperty(Property _criterionProperty)
            : base(_criterionProperty, typeof(T))
        {
        }

        public ICriterion Eq(T value)
        {
            return criterionProperty.Eq(value);
        }

        public ICriterion In(List<T> values)
        {
            return criterionProperty.In(values);
        }

        public ICriterion In(T[] values)
        {
            return criterionProperty.In(values);
        }
    }
}
