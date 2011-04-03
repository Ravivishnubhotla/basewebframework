using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace Legendigital.Framework.Common.Data.NHibernate.DynamicQuery
{
    public abstract class TypedCriterionProperty
    {
        protected Property criterionProperty;
        protected Type criterionType;

        public Property CriterionProperty
        {
            get { return criterionProperty; }
        }

        protected TypedCriterionProperty(Property _criterionProperty, Type _criterionType)
        {
            criterionProperty = _criterionProperty;
            criterionType = _criterionType;
        }

        public string[] Aliases
        {
            get
            {

                return criterionProperty.Aliases;               
            }
        }

        public IProjection As(string alias)
        {
            return criterionProperty.As(alias);
        }

        public AggregateProjection Min()
        {
            return criterionProperty.Min();
        }

        public AggregateProjection Avg()
        {
            return criterionProperty.Avg();
        }

        public CountProjection Count()
        {
            return criterionProperty.Count();
        }

        public AggregateProjection Max()
        {
            return criterionProperty.Max();
        }

        public AbstractCriterion Bt(DetachedCriteria subSelect)
        {
            return criterionProperty.Bt(subSelect);
        }

        public AbstractCriterion NotIn(DetachedCriteria subSelect)
        {
            return criterionProperty.NotIn(subSelect);
        }

        public AbstractCriterion In(DetachedCriteria subSelect)
        {
            return criterionProperty.In(subSelect);
        }


        public ICriterion Ge(DetachedCriteria subSelect)
        {
            return criterionProperty.Ge(subSelect);
        }

        public ICriterion GeAll(DetachedCriteria subSelect)
        {
            return criterionProperty.GeAll(subSelect);
        }

        public ICriterion GeSome(DetachedCriteria subSelect)
        {
            return criterionProperty.GeSome(subSelect);
        }

        public ICriterion GeProperty(string propertyName)
        {
            return criterionProperty.GeProperty(propertyName);
        }

        public ICriterion GtAll(DetachedCriteria subSelect)
        {
            return criterionProperty.GtAll(subSelect);
        }

        public ICriterion GtSome(DetachedCriteria subSelect)
        {
            return criterionProperty.GtSome(subSelect);
        }

        public ICriterion GtProperty(string propertyName)
        {
            return criterionProperty.GtProperty(propertyName);
        }

        public ICriterion Gt(DetachedCriteria subSelect)
        {
            return criterionProperty.Gt(subSelect);
        }

        public ICriterion Lt(DetachedCriteria subSelect)
        {
            return criterionProperty.Lt(subSelect);
        }

        public ICriterion LtAll(DetachedCriteria subSelect)
        {
            return criterionProperty.LtAll(subSelect);
        }

        public ICriterion LtSome(DetachedCriteria subSelect)
        {
            return criterionProperty.LtSome(subSelect);
        }

        public ICriterion LtProperty(string propertyName)
        {
            return criterionProperty.LtProperty(propertyName);
        }


        public ICriterion Le(DetachedCriteria subSelect)
        {
            return criterionProperty.Le(subSelect);
        }

        public ICriterion LeAll(DetachedCriteria subSelect)
        {
            return criterionProperty.LeAll(subSelect);
        }

        public ICriterion LeSome(DetachedCriteria subSelect)
        {
            return criterionProperty.LeSome(subSelect);
        }

        public ICriterion LeProperty(string propertyName)
        {
            return criterionProperty.LeProperty(propertyName);
        }

        public ICriterion Eq(DetachedCriteria subSelect)
        {
            return criterionProperty.Eq(subSelect);
        }

        public ICriterion EqAll(DetachedCriteria subSelect)
        {
            return criterionProperty.EqAll(subSelect);
        }

        public ICriterion EqProperty(string propertyName)
        {
            return criterionProperty.EqProperty(propertyName);
        }

        public ICriterion Ne(DetachedCriteria subSelect)
        {
            return criterionProperty.Ne(subSelect);
        }

        public ICriterion NotEqProperty(string other)
        {
            return criterionProperty.NotEqProperty(other);
        }

        public ICriterion NotEqProperty(Property property)
        {
            return criterionProperty.NotEqProperty(property);
        }

        public PropertyProjection Group()
        {
            return criterionProperty.Group();
        }

        public Order Desc()
        {
            return criterionProperty.Desc();
        }

        public Order Asc()
        {
            return criterionProperty.Asc();
        }


        public ICriterion IsNull()
        {
            return criterionProperty.IsNull();
        }

        public ICriterion IsNotNull()
        {
            return criterionProperty.IsNotNull();
        }

    }
}
