using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace Legendigital.Framework.Common.Data.NHibernate.DynamicQuery.Propertys
{
    public class DecimalProperty : TypedCriterionProperty
    {
        public DecimalProperty(Property _criterionProperty)
            : base(_criterionProperty, typeof(decimal))
        {
        }

        public ICriterion Between(decimal value1, decimal value2)
        {
            return criterionProperty.Between(value1, value2);
        }

        public ICriterion Eq(decimal value)
        {
            return criterionProperty.Eq(value);
        }

        public ICriterion Ge(decimal value)
        {
            return criterionProperty.Ge(value);
        }

        public ICriterion Gt(decimal value)
        {
            return criterionProperty.Gt(value);
        }

        public ICriterion Lt(decimal value)
        {
            return criterionProperty.Lt(value);
        }

        public ICriterion Le(decimal value)
        {
            return criterionProperty.Le(value);
        }

        public ICriterion In(List<decimal> values)
        {
            return criterionProperty.In(values);
        }

        public ICriterion In(decimal[] values)
        {
            return criterionProperty.In(values);
        }

 

 

    }
}
