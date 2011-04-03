using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace Legendigital.Framework.Common.Data.NHibernate.DynamicQuery.Propertys
{
    public class IntProperty : TypedCriterionProperty
    {
        public IntProperty(Property _criterionProperty) : base(_criterionProperty, typeof(int))
        {
        }

        public ICriterion Between(int value1, int value2)
        {
            return criterionProperty.Between(value1, value2);
        }

        public ICriterion Eq(int value)
        {
            return criterionProperty.Eq(value);
        }

        public ICriterion Ge(int value)
        {
            return criterionProperty.Ge(value);
        }

        public ICriterion Gt(int value)
        {
            return criterionProperty.Gt(value);
        }

        public ICriterion Lt(int value)
        {
            return criterionProperty.Lt(value);
        }

        public ICriterion Le(int value)
        {
            return criterionProperty.Le(value);
        }

 

        public ICriterion In(List<int> values)
        {
            return criterionProperty.In(values);
        }

        public ICriterion In(int[] values)
        {
            return criterionProperty.In(values);
        }

 

 

    }
}
