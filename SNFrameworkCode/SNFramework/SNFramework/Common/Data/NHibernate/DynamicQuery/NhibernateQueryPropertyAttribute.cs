using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Data.NHibernate.DynamicQuery
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false,Inherited=false)]
    public class NhibernateQueryPropertyAttribute : Attribute
    {
        public string MappingColumnName { get; set; }
        public string Description { get; set; }
    }
}
