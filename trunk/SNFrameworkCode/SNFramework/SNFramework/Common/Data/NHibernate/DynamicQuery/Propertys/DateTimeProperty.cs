using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace Legendigital.Framework.Common.Data.NHibernate.DynamicQuery.Propertys
{
    public class DateTimeProperty : TypedCriterionProperty
    {
        public DateTimeProperty(Property _criterionProperty)
            : base(_criterionProperty, typeof(DateTime))
        {
        }

        public ICriterion Between(DateTime value1, DateTime value2)
        {
            return criterionProperty.Between(value1, value2);
        }

        public ICriterion Eq(DateTime value)
        {
            return criterionProperty.Eq(value);
        }

        public ICriterion Ge(DateTime value)
        {
            return criterionProperty.Ge(value);
        }

        public ICriterion Gt(DateTime value)
        {
            return criterionProperty.Gt(value);
        }

        public ICriterion Lt(DateTime value)
        {
            return criterionProperty.Lt(value);
        }

        public ICriterion Le(DateTime value)
        {
            return criterionProperty.Le(value);
        }



        public ICriterion In(List<DateTime> values)
        {
            return criterionProperty.In(values);
        }

        public ICriterion In(DateTime[] values)
        {
            return criterionProperty.In(values);
        }
    }
}
