using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace Legendigital.Framework.Common.Bussiness.NHibernate
{
    /// <summary>
    /// 查询过滤对象
    /// </summary>
    [Serializable]
    public class QueryFilter
    {
        public string filterFieldName;
        public string filterValue;
        public FilterFunction filterFunction;

        public string FilterFieldName
        {
            get { return filterFieldName; }
            set { filterFieldName = value; }
        }

        public string FilterValue
        {
            get { return filterValue; }
            set { filterValue = value; }
        }

        public FilterFunction FilterFunction
        {
            get { return filterFunction; }
            set { filterFunction = value; }
        }


        /// <summary>
        /// 值1：Between类型时使用
        /// </summary>
        public string FilterValue1
        {
            get
            {
                string[] spValues = FilterValue1.Split(("").ToCharArray());
                if (spValues.Length >= 2)
                {
                    return spValues[0];
                }
                return filterValue;
            }

        }
        /// <summary>
        /// 值2：Between类型时使用
        /// </summary>
        public string FilterValue2
        {
            get
            {
                string[] spValues = FilterValue1.Split(("").ToCharArray());
                if (spValues.Length >= 2)
                {
                    return filterValue.Substring(spValues[0].Length, filterValue.Length - spValues[0].Length);
                }
                return filterValue;
            }
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="filterFieldName"></param>
        /// <param name="filterValue"></param>
        /// <param name="filterFunction"></param>
        public QueryFilter(string filterFieldName, string filterValue, FilterFunction filterFunction)
        {
            this.filterFieldName = filterFieldName;
            this.filterValue = filterValue;
            this.filterFunction = filterFunction;
        }

        /// <summary>
        /// 将过滤条件转化为Nhibernate标准查询条件
        /// </summary>
        /// <param name="fieldType"></param>
        /// <returns></returns>
        internal ICriterion GenerateNhibernateCriterion(Type fieldType)
        {
            switch (filterFunction)
            {
                case FilterFunction.NoFilter:
                    return null;
                case FilterFunction.Contains:
                    return Property.ForName(this.filterFieldName).Like(filterValue,MatchMode.Anywhere);
                case FilterFunction.DoesNotContain:
                    return Expression.Not(Property.ForName(this.filterFieldName).Like(filterValue, MatchMode.Anywhere));
                case FilterFunction.StartsWith:
                    return Property.ForName(this.filterFieldName).Like(filterValue, MatchMode.Start);
                case FilterFunction.EndsWith:
                    return Property.ForName(this.filterFieldName).Like(filterValue, MatchMode.End);
                case FilterFunction.EqualTo:
                    return Property.ForName(this.filterFieldName).Eq(Convert.ChangeType(filterValue, fieldType));
                case FilterFunction.NotEqualTo:
                    return Expression.Not(Property.ForName(this.filterFieldName).Eq(Convert.ChangeType(filterValue, fieldType)));
                case FilterFunction.GreaterThan:
                    return Property.ForName(this.filterFieldName).Gt(Convert.ChangeType(filterValue, fieldType));
                case FilterFunction.LessThan:
                    return Property.ForName(this.filterFieldName).Lt(Convert.ChangeType(filterValue, fieldType));
                case FilterFunction.GreaterThanOrEqualTo:
                    return Property.ForName(this.filterFieldName).Ge(Convert.ChangeType(filterValue, fieldType));
                case FilterFunction.LessThanOrEqualTo:
                    return Property.ForName(this.filterFieldName).Le(Convert.ChangeType(filterValue, fieldType));
                case FilterFunction.Between:
                    return Property.ForName(this.filterFieldName).Between(Convert.ChangeType(FilterValue1, fieldType), Convert.ChangeType(FilterValue2, fieldType));
                case FilterFunction.NotBetween:
                    return Expression.Not(Property.ForName(this.filterFieldName).Between(Convert.ChangeType(FilterValue1, fieldType), Convert.ChangeType(FilterValue2, fieldType)));
                case FilterFunction.IsEmpty:
                    return Property.ForName(this.filterFieldName).IsEmpty();
                case FilterFunction.NotIsEmpty:
                    return Property.ForName(this.filterFieldName).IsNotEmpty();
                case FilterFunction.IsNull:
                    return Property.ForName(this.filterFieldName).IsNull();
                case FilterFunction.NotIsNull:
                    return Property.ForName(this.filterFieldName).IsNotNull();
                default :
                    return null;
            }
        }
    }
}
