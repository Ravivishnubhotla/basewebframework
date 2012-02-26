using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Type;

namespace Legendigital.Framework.Common.Data.NHibernate.Extend
{
    public class NhibernateParameter
    {
        private IType dbType;
        private string parameterName;
        private object value;

        public NhibernateParameter()
        {
        }


        public NhibernateParameter(IType dbType, string parameterName, object value)
        {
            this.dbType = dbType;
            this.parameterName = parameterName;
            this.value = value;
        }

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