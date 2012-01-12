using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Data.NHibernate.DynamicQuery
{
    [Serializable]
    public class RecordSortor
    {
        public string OrderByColumnName { get; set; }
        public bool IsDesc { get; set; }
    }
}
