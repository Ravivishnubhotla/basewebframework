using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace Legendigital.Framework.Common.Data.NHibernate.DynamicQuery.Propertys
{
    public class ByteArrayProperty : TypedCriterionProperty
    {
        public ByteArrayProperty(Property _criterionProperty)
            : base(_criterionProperty, typeof(byte[]))
        {
        }



        public ICriterion Eq(byte[] value)
        {
            return criterionProperty.Eq(value);
        }



        public ICriterion In(List<byte[]> values)
        {
            return criterionProperty.In(values);
        }

        public ICriterion In(byte[][] values)
        {
            return criterionProperty.In(values);
        }

        

    }
}
