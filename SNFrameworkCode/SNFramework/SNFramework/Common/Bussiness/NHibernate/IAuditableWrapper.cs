using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Bussiness.NHibernate
{
    public interface IAuditableWrapper
    {
        int? CreateBy { get; set; }

        DateTime? CreateAt { get; set; }

        int? LastModifyBy { get; set; }

        DateTime? LastModifyAt { get; set; }

        string LastModifyComment { get; set; }

        string GetEntityTypeName();

        string GetEntityName();

        string GetEntityID();
    }
}
