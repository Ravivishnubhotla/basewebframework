using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Entity
{
    public interface IAuditableEntity
    {
        int? CreateBy { get; set; }

        DateTime? CreateAt { get; set; }

        int? LastModifyBy { get; set; }

        DateTime? LastModifyAt { get; set; }

        string LastModifyComment { get; set; }
    }
}
