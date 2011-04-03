using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace Legendigital.Framework.Common.Data.NHibernate.DynamicQuery.Propertys
{
    public class StringProperty : TypedCriterionProperty
    {
        public StringProperty(Property _criterionProperty) : base(_criterionProperty, typeof(string))
        {
        }

        public ICriterion Between(string value1, string value2)
        {
            return criterionProperty.Between(value1, value2);
        }

        public ICriterion Eq(string value)
        {
            return criterionProperty.Eq(value);
        }

        public ICriterion Ge(string value)
        {
            return criterionProperty.Ge(value);
        }

        public ICriterion Gt(string value)
        {
            return criterionProperty.Gt(value);
        }

        public ICriterion Lt(string value)
        {
            return criterionProperty.Lt(value);
        }

        public ICriterion Le(string value)
        {
            return criterionProperty.Le(value);
        }

        public ICriterion Like(string value)
        {
            return criterionProperty.Like(value);
        }

        public ICriterion In(List<string> values)
        {
            return criterionProperty.In(values);
        }

        public ICriterion In(string[] values)
        {
            return criterionProperty.In(values);
        }

        public ICriterion Like(string value,MatchMode matchMode)
        {
            return criterionProperty.Like(value, matchMode);
        }

        public ICriterion IsEmpty()
        {
            return criterionProperty.IsEmpty();
        }

        public ICriterion IsNotEmpty()
        {
            return criterionProperty.IsNotEmpty();
        }

    }
}
