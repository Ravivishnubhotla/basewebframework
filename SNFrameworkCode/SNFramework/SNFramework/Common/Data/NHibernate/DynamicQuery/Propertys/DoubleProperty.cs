using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace Legendigital.Framework.Common.Data.NHibernate.DynamicQuery.Propertys
{
    public class DoubleProperty: TypedCriterionProperty
    {
        public DoubleProperty(Property _criterionProperty) : base(_criterionProperty, typeof(double))
        {
        }

        public ICriterion Between(double value1, double value2)
        {
            return criterionProperty.Between(value1, value2);
        }

        public ICriterion Eq(double value)
        {
            return criterionProperty.Eq(value);
        }

        public ICriterion Ge(double value)
        {
            return criterionProperty.Ge(value);
        }

        public ICriterion Gt(double value)
        {
            return criterionProperty.Gt(value);
        }

        public ICriterion Lt(double value)
        {
            return criterionProperty.Lt(value);
        }

        public ICriterion Le(double value)
        {
            return criterionProperty.Le(value);
        }

 

        public ICriterion In(List<double> values)
        {
            return criterionProperty.In(values);
        }

        public ICriterion In(double[] values)
        {
            return criterionProperty.In(values);
        }
    }
}
