using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Bussiness.NHibernate
{
    public interface IDataLogableWrapper
    {
          int? CreateBy { get; set; }

          DateTime? CreateAt { get; set; }

          int? LastModifyBy { get; set; }

          DateTime? LastModifyAt { get; set; }

          string LastModifyComment { get; set; }

          void SetCreatByInfo(int createBy, DateTime createAt, string createComment);

          void SetModifyByInfo(int lastModifyBy, DateTime lastModifyAt, string modifyComment);
    }
}
