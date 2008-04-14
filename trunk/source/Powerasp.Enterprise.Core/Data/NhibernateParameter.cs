using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Type;

namespace Powerasp.Enterprise.Core.Data
{
    public class NhibernateParameter
    {
        private IType dbType;
        private string parameterName;
        private object value;

        public IType DbType
        {
            get { return dbType; }
            set { dbType = value; }
        }

        public string ParameterName
        {
            get { return parameterName; }
            set { parameterName = value; }
        }

        public object Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}
