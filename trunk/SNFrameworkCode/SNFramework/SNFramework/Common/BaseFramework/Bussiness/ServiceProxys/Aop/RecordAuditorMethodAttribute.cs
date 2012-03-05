using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Aop
{
    public delegate void RecordAuditorHandle(int createUserID, DateTime createTime,string relateMoudleName ,int relateMoudleID);

    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class RecordAuditorMethodAttribute : Attribute
    {
        public RecordAuditorHandle AuditorActionHandle { get; set; }
    }
}
