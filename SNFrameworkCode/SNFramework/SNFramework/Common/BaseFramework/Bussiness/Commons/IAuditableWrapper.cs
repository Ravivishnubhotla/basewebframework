using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Commons
{
    public interface IAuditableWrapper
    {
        int? GetDataCreateBy();

        DateTime? GetDataCreateAt();

        int? GetDataLastModifyBy();

        DateTime? GetDataLastModifyAt();

        string GetDataLastModifyComment();

        string GetEntityTypeName();

        string GetEntityName();

        string GetEntityID();
    }
}
